using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5A.DAL;
using System.Data;
namespace Module5A.BLL
{
    class Cabin
    {
        public DataTable GetListCabin()
        {
            try
            {
                DataDAL objDAL = new DataDAL();
                return objDAL.GetDataInfo("SELECT CabinTypes.Name FROM CabinTypes ");
            }
            catch
            {
                throw;
            }
        }
    }
}
