using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Module5A.DAL
{
    class Connection
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q1QGNFE;Initial Catalog=module5a;Integrated Security=True");
    }
}
