using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozoyaEntitys
{

    class GetBySQL
    {
        public DataTable GetTableBySQL(string SQL)
        {

            String ConnString = "Data Source=WIN-P6B57G49ND9;Initial Catalog=TestDB;Integrated Security=True"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    adapter.SelectCommand = new SqlCommand(SQL, conn);
                    adapter.Fill(myDataTable);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            catch
            {
            }
            return myDataTable;

        }

        public string GetScalerBySQL(string SQL)
        {


            String ConnString = "Data Source=WIN-P6B57G49ND9;Initial Catalog=TestDB;Integrated Security=True"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection cnn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            string s;
            try
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = SQL;

                s = cmd.ExecuteScalar().ToString();
                cnn.Close();
            }
            catch
            {
                s = "";
            }

            return s;
        }



        public int? SetBySQL(string SQL)
        {
            SqlConnection cnn = new SqlConnection("Data Source=WIN-P6B57G49ND9;Initial Catalog=TestDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();

            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = SQL;

            cmd.ExecuteNonQuery();
            cnn.Close();

            return 0;
        }




    }
}
