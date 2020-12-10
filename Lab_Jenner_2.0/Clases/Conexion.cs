using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clases
{
    public class Conexion
    {
        public SqlConnection cn;
        public SqlCommand cmd;
        public SqlDataReader r;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Jenner;Integrated Security=True");
                cn.Open();

            }
            catch(Exception err)
            {
                throw err;
            }


        }
    }
}
