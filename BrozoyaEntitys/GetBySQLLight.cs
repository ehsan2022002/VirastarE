using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace BrozoyaEntitys
{
    internal class GetBySQLLight
    {
        //String ConnString = @"data source=db\archive"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();
        private readonly string _connString = string.Empty;

        public GetBySQLLight()
        {
            //ConnString = @"data source="\\db\\borzoya"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();
            _connString = @"data source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                         @"\db\borzoya";
        }

        public DataTable GetTableBySql(string sql)
        {
            var adapter = new SQLiteDataAdapter();
            var myDataTable = new DataTable();
            try
            {
                using (var conn = new SQLiteConnection(_connString))
                {
                    adapter.SelectCommand = new SQLiteCommand(sql, conn);
                    adapter.Fill(myDataTable);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return myDataTable;
        }


        public string GetScalerBySql(string sql)
        {
            //String ConnString = @"data source=db\borzoya"; // ConfigurationManager.AppSettings["ConnectionString"].ToString();           
            var s = string.Empty;
            object obj;

            using (var cnn = new SQLiteConnection(_connString))
            {
                using (var cmd = new SQLiteCommand(cnn))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                            cnn.Open();

                        ///cmd.Connection = cnn;
                        cmd.CommandText = sql + " ORDER BY ID ASC LIMIT 1";

                        obj = cmd.ExecuteScalar();
                        if (obj != null)
                            s = obj.ToString();
                    }
                    catch (Exception)
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

        public string GetLastInsertId(string tableName)
        {
            var s = string.Empty;
            using (var cnn = new SQLiteConnection(_connString))
            {
                using (var cmd = new SQLiteCommand(cnn))
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed)
                            cnn.Open();

                        ///cmd.Connection = cnn;
                        cmd.CommandText = "SELECT rowid from " + tableName + " order by ROWID DESC limit 1";
                        s = cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception)
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


        public int? SetBySql(string sql)
        {
            var cnn = new SQLiteConnection(_connString);
            var cmd = new SQLiteCommand(cnn);

            cnn.Open();
            //cmd.Connection = cnn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            cnn.Close();
            return 0;
        }

        public void SetBlob(string sql, byte[] blob)
        {
            var cnn = new SQLiteConnection(_connString);
            var cmd = new SQLiteCommand(cnn);
            var pr = new SQLiteParameter();

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
    }
}