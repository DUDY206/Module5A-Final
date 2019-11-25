using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Module5A.DAL;
namespace Module5A.BLL
{
    class BookingReferenceBLL
    {
        public DataTable GetListTicket(string booking_reference)
        {
            try
            {
                DataDAL objDAL = new DataDAL();
                return objDAL.GetDataInfo("SELECT Tickets.ID,Tickets.ID+', '+Routes.ArrivalAirportID + '-' + Routes.DepartureAirportID + ', ' + CONVERT(NVARCHAR(10),Schedules.Date,103) + ', '+ CONVERT(NVARCHAR(5),Schedules.Time,8) AS INFO FROM Tickets INNER JOIN Schedules ON Tickets.ScheduleID = Schedules.ID INNER JOIN Routes ON Schedules.RouteID = Routes.ID WHERE BookingReference = '" + booking_reference + "'");
            }
            catch
            {
                throw;
            }
        }
        
    }
}
