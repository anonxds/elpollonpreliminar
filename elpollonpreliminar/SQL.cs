
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elpollonpreliminar
{
    class SQL
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter db;

        private void setcon()
        {
            con = new SqlConnection("Server=tcp:pruebastec.database.windows.net,1433;Initial Catalog=elpollon;Persist Security Info=False;User ID=alexis;Password=Azure1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public void Exe(String query)
        {
            setcon();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

        }

    }
}

