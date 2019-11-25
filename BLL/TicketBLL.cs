using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5A.DAL;
using System.Data;
namespace Module5A.BLL
{
    class TicketBLL
    {
        public bool IsInvalidHour(string ticket_id)
        {
            DataDAL objDAL = new DataDAL();
            int time = int.Parse(objDAL.GetDataInfo("SELECT DATEDIFF(SECOND , FORMAT(GETDATE(),'HH:mm:ss'),Schedules.Time) + DATEDIFF(SECOND , FORMAT(GETDATE(),'yyyy/MM/dd'), Schedules.Date) AS DateDiff, Schedules.Time,  Schedules.Date FROM Schedules INNER JOIN Tickets ON Tickets.ScheduleID = Schedules.ID WHERE Tickets.ID = '" + ticket_id + "'").Rows[0][0].ToString());

            return (time > 0 && time < 86400);
        }
        public DataTable GetTicketInfo(string ticket_id)
        {
            DataDAL objDAL = new DataDAL();
            return objDAL.GetDataInfo("SELECT Tickets.FirstName +' '+Tickets.LastName AS Fullname, Tickets.PassportNumber, CabinTypes.Name FROM Tickets INNER JOIN CabinTypes ON Tickets.CabinType = CabinTypes.ID WHERE Tickets.ID = '" + ticket_id + "'");
        }
    }
}
