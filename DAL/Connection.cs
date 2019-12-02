using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class Connection
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q1QGNFE;Initial Catalog=module5a;Integrated Security=True");
        DataTable dt = new DataTable();
        public DataTable GetDataInfo(string query)
        {
            //Query trả về một bảng 
            Connection conn = new Connection();
            if (conn.con.State == ConnectionState.Closed)
            {
                conn.con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn.con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public List<string> GetListDataInt(string query)
        {
            //trả về danh sách int
            List<string> ans = new List<string>();
            Connection conn = new Connection();
            if (conn.con.State == ConnectionState.Closed)
            {
                conn.con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn.con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ans.Add(rd.GetInt32(0).ToString());
                }
                return ans;
            }
            catch
            {
                throw;
            }
        }

        public void ExecuteQuery(string query)
        {
            //thực thi đoan query không có dữ liệu trả về
            Connection conn = new Connection();
            if (conn.con.State == ConnectionState.Closed)
            {
                conn.con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn.con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
            }
            catch
            {
                throw;
            }
        }
        /////////////////////////////////////////////////
        ///QUERY - SQL SERVER
        //////////////////////////////////////////////////

        //////////////////////////////////////////////////
        //Amenitites Query 
        //////////////////////////////////////////////////
        public DataTable GetListAmenities(string tick_id)
        {
            //Lấy danh sách các amentities có trong cơ sở dữ liệu theo khoang 
            try
            {
                Connection objDAL = new Connection();
                DataTable dt = objDAL.GetDataInfo("SELECT Amenities.ID,Amenities.AmenService,Amenities.Price,AmenitiesTickets.Price AS PRICE_TICK_AMEN FROM Amenities INNER JOIN AmenitiesCabinType ON Amenities.ID = AmenitiesCabinType.AmenitiesID  INNER JOIN Tickets ON AmenitiesCabinType.CabinTypeID = Tickets.CabinType LEFT JOIN AmenitiesTickets ON AmenitiesTickets.TicketID = Tickets.ID AND AmenitiesTickets.AmenitiesID = Amenities.ID WHERE Tickets.ID = '" + tick_id + "'");
                //Dữ liệu trả về ban đầu theo dạng sau
                //ID        -   INFO    -   PRICE- giá đã mua
                //amt_01	-   BEER    -	20  -	20
                //amt_10	    IWW         0	    NULL
                DataTable dtemp = new DataTable();
                dtemp.Columns.Add("ID", typeof(string));
                dtemp.Columns.Add("Info", typeof(string));
                dtemp.Columns.Add("Price", typeof(double));
                dtemp.Columns.Add("Price_bought", typeof(string));
                DataRow workRow;
                //định dạng lại datatable và add vào một datatable mới
                //ID        -   INFO         -   PRICE - giá đã mua
                //amt_01	-   BEER($20)    -     20  -	20
                //amt_10	    IWW($15)     -     0   -    NULL
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
                        workRow[1] = row[1].ToString() + " ( $" + row[2].ToString() + " )";
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

        //////////////////////////////////////////////////
        //Amenities Tickets Query
        //////////////////////////////////////////////////
        public void ChangeAmenTick(string ticket_id, string amenity_id, string type, int price)
        {
            //sự kiện update lại form sau khi đã chọn xong dịch vụ đã mua
            Connection objDal = new Connection();
            if (type == "DEL")
            {
                //trả lại dịch vụ - xóa bản ghi trong db
                objDal.ExecuteQuery("DELETE FROM AmenitiesTickets WHERE AmenitiesTickets.AmenitiesID = '" + amenity_id + "' AND AmenitiesTickets.TicketID = '" + ticket_id + "'");
            }
            else
            {
                //mua mới dịch vụ 
                objDal.ExecuteQuery("INSERT INTO AmenitiesTickets VALUES('" + amenity_id + "','" + ticket_id + "'," + price + ")");
            }
        }

        public DataTable ReportAmenities(string flight_num)
        {
            Connection objDAL = new Connection();
            //lấy ra danh sách các dịch vụ
            DataTable list_amenity = objDAL.GetDataInfo("SELECT Amenities.AmenService FROM Amenities");
            //bảng lưu thông tin đầy đủ của cách dịch vụ theo cabin (giá trị null tức khoang đó không có sẵn dịch vụ)
            DataTable amen_by_cabin = new DataTable();

            //đặt tên cho header column là tên các dịch vụ
            for (int i = 0; i < list_amenity.Rows.Count; i++)
            {
                amen_by_cabin.Columns.Add(list_amenity.Rows[i]["AmenService"].ToString());
            }

            Connection objDAL1 = new Connection();
            DataTable list_cabin = objDAL1.GetDataInfo("SELECT ID FROM CabinTypes");

            //lấy ra dữ liệu của các dịch vụ theo từng cabin 1
            //mã cabin được lấy ra từ list_cabin
            for (int i = 0; i < list_cabin.Rows.Count; i++)
            {
                //bảng dịch vụ dưới dạng cột định dạng thành list và đổ vào datatable kết quả theo hàng (cột -> hàng)
                List<string> temp = objDAL.GetListDataInt("SELECT ISNULL(S.SOLUONG, 0 ) FROM Amenities LEFT JOIN (SELECT AmenitiesTickets.AmenitiesID, Tickets.CabinType, COUNT(*) AS SOLUONG FROM AmenitiesTickets INNER JOIN Tickets ON AmenitiesTickets.TicketID = Tickets.ID LEFT JOIN Schedules ON Tickets.ScheduleID = Schedules.ID WHERE Tickets.CabinType = '" + list_cabin.Rows[i]["ID"].ToString() + "' AND Schedules.FlightNumber = '" + flight_num + "' GROUP BY AmenitiesTickets.AmenitiesID, Tickets.CabinType) S ON Amenities.ID = S.AmenitiesID");
                amen_by_cabin.Rows.Add(temp.ToArray<string>());
            }

            return amen_by_cabin;
        }

        //////////////////////////////////////
        //Booking References
        //////////////////////////////////////

        public DataTable GetListTicket(string booking_reference)
        {
            try
            {
                Connection objDAL = new Connection();
                return objDAL.GetDataInfo("SELECT Tickets.ID,Tickets.ID+', '+Routes.ArrivalAirportID + '-' + Routes.DepartureAirportID + ', ' + CONVERT(NVARCHAR(10),Schedules.Date,103) + ', '+ CONVERT(NVARCHAR(5),Schedules.Time,8) AS INFO FROM Tickets INNER JOIN Schedules ON Tickets.ScheduleID = Schedules.ID INNER JOIN Routes ON Schedules.RouteID = Routes.ID WHERE BookingReference = '" + booking_reference + "'");
            }
            catch
            {
                throw;
            }
        }

        //////////////////////////////////////
        //Cabin
        //////////////////////////////////////

        public DataTable GetListCabin()
        {
            //lấy danh sách cabin trong db ra và trả về dạng datatable 
            try
            {
                Connection objDAL = new Connection();
                return objDAL.GetDataInfo("SELECT CabinTypes.Name FROM CabinTypes ");
            }
            catch
            {
                throw;
            }
        }

        //////////////////////////////////////
        //Schedule
        //////////////////////////////////////
        public bool IsExistFN(string flight_num)
        {
            //tìm kiếm xem có chuyến bay nào mang flight_num trong db không?
            try
            {
                Connection objDAL = new Connection();
                if (objDAL.GetDataInfo("SELECT * FROM Schedules WHERE Schedules.FlightNumber = '"+ flight_num + "'").Rows.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetListFlight(string date_picked)
        {
            //trả về danh sách các chuyến bay
            try
            {
                Connection objDAL = new Connection();
                return objDAL.GetDataInfo("SELECT Schedules.FlightNumber FROM Schedules WHERE Date = '" + date_picked + "'");
            }
            catch
            {
                throw;
            }
        }

        //////////////////////////////////////
        //Ticket
        //////////////////////////////////////
        ///

        public bool IsInvalidHour(string ticket_id)
        {
            //kiểm tra giờ thay đổi dịch vụ có hợp lệ không (24h trước h bay - 86400 giây, time > 86400s)
            Connection objDAL = new Connection();
            int time = int.Parse(objDAL.GetDataInfo("SELECT DATEDIFF(SECOND , FORMAT(GETDATE(),'HH:mm:ss'),Schedules.Time) + DATEDIFF(SECOND , FORMAT(GETDATE(),'yyyy/MM/dd'), Schedules.Date) AS DateDiff, Schedules.Time,  Schedules.Date FROM Schedules INNER JOIN Tickets ON Tickets.ScheduleID = Schedules.ID WHERE Tickets.ID = '" + ticket_id + "'").Rows[0][0].ToString());

            return (time > 86400);
        }
        public DataTable GetTicketInfo(string ticket_id)
        {
            //lấy danh sách các thuộc tính của ticket
            Connection objDAL = new Connection();
            return objDAL.GetDataInfo("SELECT Tickets.FirstName +' '+Tickets.LastName AS Fullname, Tickets.PassportNumber, CabinTypes.Name FROM Tickets INNER JOIN CabinTypes ON Tickets.CabinType = CabinTypes.ID WHERE Tickets.ID = '" + ticket_id + "'");
            //Fullname - Passport number - Cabin_name 
        }

    }
}
