using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace BrozoyaEntitys
{
    class GetBySQLLight
    {
        //String ConnString = @"data source=db\archive"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();
        String ConnString = "";

        public GetBySQLLight()
        {
            //ConnString = @"data source="\\db\\borzoya"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();
            ConnString = @"data source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\db\borzoya";
        }

        public DataTable GetTableBySQL(string SQL)
        {


            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            DataTable myDataTable = new DataTable();
            try
            {

                using (SQLiteConnection conn = new SQLiteConnection(ConnString))
                {
                    adapter.SelectCommand = new SQLiteCommand(SQL, conn);
                    adapter.Fill(myDataTable);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return myDataTable;

        }


        public string GetScalerBySQL(string SQL)
        {
            //String ConnString = @"data source=db\borzoya"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();           
            string s = string.Empty;
            object obj;

            using (SQLiteConnection cnn = new SQLiteConnection(ConnString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(cnn))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                            cnn.Open();

                        ///cmd.Connection = cnn;
                        cmd.CommandText = SQL + " ORDER BY ID ASC LIMIT 1";

                        obj = cmd.ExecuteScalar();
                        if (obj != null)
                            s = obj.ToString();
                    }
                    catch (Exception ex)
                    {
                        s = "";
                    }
                    finally
                    {
                        if (cnn.State == ConnectionState.Open)
                            cnn.Close();
                    }
                }
            }
            return s;
        }

        public string GetLastInsertID(string TableName)
        {
            string s = string.Empty;
            using (SQLiteConnection cnn = new SQLiteConnection(ConnString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(cnn))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                            cnn.Open();

                        ///cmd.Connection = cnn;
                        cmd.CommandText = "SELECT rowid from " + TableName + " order by ROWID DESC limit 1";
                        s = cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        s = "";
                    }
                    finally
                    {
                        if (cnn.State == ConnectionState.Open)
                            cnn.Close();
                    }
                }
            }
            return s;
        }


        public int? SetBySQL(string SQL)
        {
            SQLiteConnection cnn = new SQLiteConnection(ConnString);
            SQLiteCommand cmd = new SQLiteCommand(cnn);

            cnn.Open();
            //cmd.Connection = cnn;
            cmd.CommandText = SQL;

            cmd.ExecuteNonQuery();
            cnn.Close();
            return 0;
        }

        public void SetBlob(string sql, byte[] blob)
        {
            SQLiteConnection cnn = new SQLiteConnection(ConnString);
            SQLiteCommand cmd = new SQLiteCommand(cnn);
            SQLiteParameter pr = new SQLiteParameter();

            cnn.Open();
            cmd.CommandText = sql;
            //cmd.CommandText = "Update  T SET blobData = @img where ID=1";
            cmd.Prepare();

            pr.DbType = DbType.Binary;
            pr.ParameterName = "@img";
            pr.Size = blob.Length;

            //cmd.Parameters.Add("@img", DbType.Binary, blob.Length);
            cmd.Parameters.Add(pr);

            cmd.Parameters["@img"].Value = blob;
            cmd.ExecuteNonQuery();

            cnn.Close();
        }

        public byte[] GetBlobByID(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(ConnString);
            SQLiteCommand cmd = new SQLiteCommand(cnn);

            cnn.Open();

            cmd.CommandText = sql; // "SELECT Data FROM Images WHERE Id=1";
            byte[] data = (byte[])cmd.ExecuteScalar();

            cnn.Close();

            return data;
        }



    }
}
