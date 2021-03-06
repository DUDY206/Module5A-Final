﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace Module5A
{
    public partial class MakeReports : Form
    {
        public MakeReports()
        {
            InitializeComponent();
        }
        ComboBox cbxFlight = new ComboBox();
        Button btnFindFlight = new Button();
        string info;
        private void cbx_ffli_CheckedChanged(object sender, EventArgs e)
        {
            //tìm kiếm theo flight_num
            if(cbx_ffli.Checked == true)
            {
                //chọn lại vị trí cho nút make repory
                //ẩn các nút thuộc tính cho lựa chọn tìm kiếm theo ngày
                btnMakeRP.Location = new Point(266, 7);
                txtInput.Show();
                dtp.Hide();
                cbxFlight.Hide();
                txtInput.Text = "Input Flight ID here!";
                cbx_fday.CheckState = CheckState.Unchecked;
            }
        }
       private void ChangeDate(object sender, EventArgs e)
        {
            BussinessLayer objBLL = new BussinessLayer();
            DataTable listFlight = objBLL.GetListFlight(dtp.Text);

            if (listFlight.Rows.Count == 0)
            {
                MessageBox.Show("There aren't any Flight on this day!");
                cbxFlight.DataSource = null;
            }
            else
            {
                cbxFlight.DataSource = listFlight;
                cbxFlight.DisplayMember = "FlightNumber";
                //cbxFlight.ValueMember = "FlightNumber";
            }

        }
        private void cbx_fday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_fday.Checked == true)
            {
                //tạo các nút mới khi lựa chọn tìm kiếm theo ngày (cbxFlight,btnFindFlight)
                btnMakeRP.Location = new Point(266, 31);
                txtInput.Hide();
                dtp.Show();
                cbxFlight.Show();
                dtp.CustomFormat = "yyyy-MM-dd";
                cbx_ffli.CheckState = CheckState.Unchecked;
                cbxFlight.Size = new Size(141, 20);
                cbxFlight.Location = new Point(119, 32);
                btnFindFlight.Text = "Find Filght";
                btnFindFlight.Size = new Size(129, 23);
                btnFindFlight.Location = new Point(266, 7);
                cbxFlight.DataSource = null;
                btnFindFlight.Click += ChangeDate;
                this.Controls.Add(cbxFlight);
                this.Controls.Add(btnFindFlight);

            }
        }

        private void btnMakeRP_Click(object sender, EventArgs e)
        {
            dgvTotalAmenity.DataSource = null;
            if (cbx_ffli.Checked == true)
            {
                info = txtInput.Text;
                PushDataToDGV(info);
            }
            else if(cbx_fday.Checked == true)
            {
                info = cbxFlight.Text;
                PushDataToDGV(info);
            }
            else
            {
                MessageBox.Show("Please select Option to make report");
            }
        }

        private void PushDataToDGV(string info)
        {
            //hàm trả về dữ liệu cho report thông qua flight number
            BussinessLayer objBLL = new BussinessLayer();
            BussinessLayer objCabin = new BussinessLayer();
            DataTable listCabin = objCabin.GetListCabin();
            bool ans = new BussinessLayer().IsExistFN(info);
            if (ans == false)
            {
                MessageBox.Show("Flight number is invalid!");
            }
            else
            {
                //đổ datasource cho datagridview
                dgvTotalAmenity.DataSource = objBLL.ReportAmenities(info);
                for (int i = 0; i < listCabin.Rows.Count; i++)
                {
                    //gán header name thông qua list đã query trước
                    dgvTotalAmenity.Rows[i].HeaderCell.Value = listCabin.Rows[i]["Name"].ToString();
                }
                dgvTotalAmenity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTotalAmenity.RowHeadersWidth = 200;
            }
        }

        private void txtInput_Click(object sender, EventArgs e)
        {

            txtInput.Text = "";
        }

        private void MakeReports_Load(object sender, EventArgs e)
        {
            dtp.Hide();
        }
    }
}
