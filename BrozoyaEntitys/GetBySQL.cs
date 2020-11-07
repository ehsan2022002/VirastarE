using System.Data;
using System.Data.SqlClient;

namespace BrozoyaEntitys
{
    internal class GetBySql
    {
        public DataTable GetTableBySQL(string SQL)
        {
            var ConnString =
                "Data Source=WIN-P6B57G49ND9;Initial Catalog=TestDB;Integrated Security=True"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();

            var adapter = new SqlDataAdapter();
            var myDataTable = new DataTable();
            try
            {
                using (var conn = new SqlConnection(ConnString))
                {
                    adapter.SelectCommand = new SqlCommand(SQL, conn);
                    adapter.Fill(myDataTable);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            catch
            {
                // ignored
            }

            return myDataTable;
        }

        public string GetScalerBySql(string sql)
        {
            var ConnString =
                "Data Source=WIN-P6B57G49ND9;Initial Catalog=TestDB;Integrated Security=True"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();
            var cnn = new SqlConnection(ConnString);
            var cmd = new SqlCommand();
            string s;
            try
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = sql;

                s = cmd.ExecuteScalar().ToString();
                cnn.Close();
            }
            catch
            {
                s = "";
            }

            return s;
        }


        public int? SetBySql(string sql)
        {
            var cnn = new SqlConnection("Data Source=WIN-P6B57G49ND9;Initial Catalog=TestDB;Integrated Security=True");
            var cmd = new SqlCommand();

            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            cnn.Close();

            return 0;
        }
    }
}