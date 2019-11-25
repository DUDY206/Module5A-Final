using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5A.DAL;
using System.Data;
namespace Module5A.BLL
{
    class AmenitiesTicketsBLL
    {
        public void ChangeAmenTick(string ticket_id,string amenity_id,string type,int price)
        {
            DataDAL objDal = new DataDAL();
            if(type == "DEL")
            {
                objDal.ExecuteQuery("DELETE FROM AmenitiesTickets WHERE AmenitiesTickets.AmenitiesID = '" + amenity_id + "' AND AmenitiesTickets.TicketID = '" + ticket_id + "'");
            }
            else
            {
                objDal.ExecuteQuery("INSERT INTO AmenitiesTickets VALUES('"+ amenity_id + "','"+ ticket_id + "',"+ price + ")");
            }
        }

        public DataTable ReportAmenities(string flight_num)
        {
            DataDAL objDAL = new DataDAL();
            DataTable list_amenity = objDAL.GetDataInfo("SELECT Amenities.AmenService FROM Amenities");

            DataTable amen_by_cabin = new DataTable();
            for(int i = 0; i < list_amenity.Rows.Count; i++)
            {
                amen_by_cabin.Columns.Add(list_amenity.Rows[i]["AmenService"].ToString());
            }
            DataDAL objDAL1 = new DataDAL();
            DataTable list_cabin = objDAL1.GetDataInfo("SELECT ID FROM CabinTypes");
            for (int i = 0; i < list_cabin.Rows.Count; i++)
            {
                List<string> temp = objDAL.GetListDataString("SELECT ISNULL(S.SOLUONG, 0 ) FROM Amenities LEFT JOIN (SELECT AmenitiesTickets.AmenitiesID, Tickets.CabinType, COUNT(*) AS SOLUONG FROM AmenitiesTickets INNER JOIN Tickets ON AmenitiesTickets.TicketID = Tickets.ID LEFT JOIN Schedules ON Tickets.ScheduleID = Schedules.ID WHERE Tickets.CabinType = '" + list_cabin.Rows[i]["ID"].ToString() + "' AND Schedules.FlightNumber = '"+ flight_num + "' GROUP BY AmenitiesTickets.AmenitiesID, Tickets.CabinType) S ON Amenities.ID = S.AmenitiesID");
                amen_by_cabin.Rows.Add(temp.ToArray<string>());
            }

            return amen_by_cabin;
        }
    }
}
