using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Module5A.DAL;
namespace Module5A.BLL
{
    class AmenitiesBLL
    {
        
        public DataTable GetListAmenities(string tick_id)
        {
            //Lấy danh sách các amentities có trong cơ sở dữ liệu theo khoang 
            try
            {
                DataDAL objDAL = new DataDAL();
                DataTable dt =  objDAL.GetDataInfo("SELECT Amenities.ID,Amenities.AmenService,Amenities.Price,AmenitiesTickets.Price AS PRICE_TICK_AMEN FROM Amenities INNER JOIN AmenitiesCabinType ON Amenities.ID = AmenitiesCabinType.AmenitiesID  INNER JOIN Tickets ON AmenitiesCabinType.CabinTypeID = Tickets.CabinType LEFT JOIN AmenitiesTickets ON AmenitiesTickets.TicketID = Tickets.ID AND AmenitiesTickets.AmenitiesID = Amenities.ID WHERE Tickets.ID = '"+tick_id+"'");
               
                DataTable dtemp = new DataTable();
                dtemp.Columns.Add("ID", typeof(string));
                dtemp.Columns.Add("Info", typeof(string));
                dtemp.Columns.Add("Price", typeof(double));
                dtemp.Columns.Add("Price_bought", typeof(string));
                DataRow workRow;
                //định dạng lại datatable

                foreach (DataRow row in dt.Rows)
                {
                    workRow = dtemp.NewRow();
                    workRow[0] = row[0];
                    workRow[2] = double.Parse(row[2].ToString());
                    workRow[3] = row[3];
                    if (row[2].ToString() == "0")
                    {
                        workRow[1] = row[1].ToString() + " ( Free )";
                    }
                    else
                    {
                        workRow[1] = row[1].ToString() + " ( $"+ row[2].ToString() + " )";
                    }
                    dtemp.Rows.Add(workRow);
                }
                return dtemp;
            }
            catch
            {
                throw;
            }
        }
        public int CheckAmenities(string tick_id,string amenity_id)
        {
            try
            {
                DataDAL objDAL = new DataDAL();
                DataTable dt = objDAL.GetDataInfo("SELECT PRICE FROM AmenitiesTickets WHERE AmenitiesTickets.AmenitiesID = '"+ amenity_id + "' AND AmenitiesTickets.TicketID='"+ tick_id + "'");
                if(dt.Rows.Count != 0)
                {
                    //dịch vụ đã mua 
                    if (dt.Rows[0][0].ToString() == "0")
                    {
                        //dịch vụ miễn phí
                        return 0;
                    }
                    else
                    {
                        //dịch vụ trả tiền
                        return 1;
                    }
                }
                //dịch vụ chưa mua
                return -1;
            }
            catch
            {
                throw;
            }
        }

        
    }
}
