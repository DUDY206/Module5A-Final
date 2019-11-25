using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5A.DAL;
using System.Data;
namespace Module5A.BLL
{
    class Schedule
    {
        public bool IsExistFN(string flight_num)
        {
            try
            {
                DataDAL objDAL = new DataDAL();
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
            try
            {
                DataDAL objDAL = new DataDAL();
                return objDAL.GetDataInfo("SELECT Schedules.FlightNumber FROM Schedules WHERE Date = '" + date_picked + "'");
            }
            catch
            {
                throw;
            }
        }
        
    }
}
