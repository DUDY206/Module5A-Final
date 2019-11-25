using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module5A.BLL;
namespace Module5A
{

    public partial class PurchaseAmenities : Form
    {
        public PurchaseAmenities()
        {
            InitializeComponent();
        }
        long total_price = 0;
        DataTable listAmentities;
        //tự động tính tiền khi thay đổi checkbox
        public void Auto_Cal_Price(Object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            if(e.NewValue == CheckState.Checked)
            {
                total_price += long.Parse(listAmentities.Rows[index]["Price"].ToString());
            }
            else
            {
                total_price -= long.Parse(listAmentities.Rows[index]["Price"].ToString());
            }
            lbTotalPrice.Text = "$"+total_price.ToString();
            lbDuties.Text = "$" + (total_price * 0.05).ToString();
            lbTotalPay.Text = "$" + (total_price * 1.05).ToString();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            BookingReferenceBLL objBLL = new BookingReferenceBLL();
            DataTable listTicket = objBLL.GetListTicket(txtBookingReference.Text);
            cbxTicket.DataSource = listTicket;
            //không tìm thấy chuyến bay theo mã booking
            if(listTicket.Rows.Count == 0)
            {
                MessageBox.Show("Cannot found Fight!");
                Reset_Form(true);
            }
            else
            {
                btnShowAmen.Enabled = true;
                cbxTicket.Enabled = true;
                cbxTicket.DisplayMember = "INFO";
                cbxTicket.ValueMember = "ID";
            }
           
            
        }
        //list checklistbox các dịch vụ
        CheckedListBox clbx = new CheckedListBox();

        private void btnShowAmen_Click(object sender, EventArgs e)
        {
            clbx.DataSource = null;
            groupBox2.Controls.Clear();
            TicketBLL objBLL = new TicketBLL();
            string tick_id = cbxTicket.SelectedValue.ToString();
            if (objBLL.IsInvalidHour(tick_id))
            {
                btnSave.Enabled = true;
                total_price = 0;
                //Lấy ra thông tin tên tuổi, passport, cabin ngồi
                DataTable ticket_info = objBLL.GetTicketInfo(tick_id);
                lblFullName.Text = ticket_info.Rows[0]["Fullname"].ToString();
                lblPassportNumber.Text = ticket_info.Rows[0]["PassportNumber"].ToString();
                lblCabinClass.Text = ticket_info.Rows[0]["Name"].ToString();

                // tạo ra list checkboxlist các dịch vụ
                clbx.Location = new Point(26, 19);
                clbx.Size = new System.Drawing.Size(550, 60);
                clbx.BackColor = CheckedListBox.DefaultBackColor;
                clbx.BorderStyle = BorderStyle.None;
                clbx.ColumnWidth = 180;
                clbx.MultiColumn = true;
                clbx.CheckOnClick = true;
                AmenitiesBLL objAmentitiesBLL = new AmenitiesBLL();
                listAmentities = objAmentitiesBLL.GetListAmenities(tick_id);
                clbx.DataSource = listAmentities;
                clbx.DisplayMember = "Info";
                clbx.ValueMember = "ID";
                groupBox2.Controls.Add(clbx);

                clbx.ItemCheck += Auto_Cal_Price;
                //các trạng thái tương ứng trong db: đã mua, chưa mua, free
                for(int i = 0; i < listAmentities.Rows.Count; i++)
                {
                    if(listAmentities.Rows[i]["Price"].ToString() == "0")
                    {
                        clbx.SetItemCheckState(i, CheckState.Indeterminate);
                    }else if(!String.IsNullOrEmpty(listAmentities.Rows[i]["Price_bought"].ToString()))
                    {
                        clbx.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        clbx.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
                //mặc định giá ban đầu là 0 khi lấy từ db ra
                total_price = 0;
                lbTotalPrice.Text = "$0";
                lbDuties.Text = "$0";
                lbTotalPay.Text = "$0";
            }
            else
            {
                btnSave.Enabled = false;
                MessageBox.Show("This service is avaibable up to 24 hours before the flight!");
            }
        }
        private void Reset_Form(bool ok)
        {
            cbxTicket.Text = "";
            lbTotalPrice.Text = "[$XX]";
            lbDuties.Text = "[$XX]";
            lbTotalPay.Text = "[$XX]";
            lblFullName.Text = "[ XXXXX XXXXXXXXXXX ]";
            lblPassportNumber.Text = "[ XXXXX XXXXXXXXXXX ]";
            lblCabinClass.Text = "[ XXXXX XXXXXXXXXXX ]";


            if(ok == true)
            {
                btnShowAmen.Enabled = false;
                cbxTicket.Enabled = false;
            }
            btnSave.Enabled = false;
            groupBox2.Controls.Clear();
        }

        private void PurchaseAmenities_Load(object sender, EventArgs e)
        {
            Reset_Form(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = "Do you confirm buy there amenities?";
            string title = "Save and confirm";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < listAmentities.Rows.Count; i++)
                {
                    AmenitiesTicketsBLL objBLL = new AmenitiesTicketsBLL();
                    string tick_id = cbxTicket.SelectedValue.ToString();
                    string amenity_id = listAmentities.Rows[i]["ID"].ToString();
                    //trường hợp mua thêm
                    if (clbx.GetItemCheckState(i) == CheckState.Checked && String.IsNullOrEmpty(listAmentities.Rows[i]["Price_bought"].ToString()))
                    {
                        int price = int.Parse(listAmentities.Rows[i]["Price"].ToString());
                        objBLL.ChangeAmenTick(tick_id, amenity_id, "ADD", price);
                        
                    }
                    //trường hợp xóa sản phẩm đã mua
                    else if (clbx.GetItemCheckState(i) == CheckState.Unchecked && !String.IsNullOrEmpty(listAmentities.Rows[i]["Price_bought"].ToString()))
                    {
                        objBLL.ChangeAmenTick(tick_id, amenity_id, "DEL", 0);
                    }
                }
                MessageBox.Show("Change buying amenities successfully");
                Reset_Form(true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
