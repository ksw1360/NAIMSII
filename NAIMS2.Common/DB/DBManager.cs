using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Browsing;

namespace NAIMS2.Common.DB
{
    public class DBManager : IDisposable
    {
        public IDbConnection? baseConn = null;
        public DBManager() {
            if(!System.IO.File.Exists(Config.DBFile))
            {
                System.IO.File.Copy(Constants.DB_FILE_ORIGIN, Config.DBFile);
            }
            this.baseConn = new SQLiteConnection($"Data Source={Config.DBFile};Mode=ReadWriteCreate");
            this.baseConn.Open();
        }

        private int executeNonQuery(String sql, IDbConnection? conn = null)
        {
            var c = (conn == null ? this.baseConn : conn);

            var command = c.CreateCommand();
            command.CommandText = sql;

            int affectedRows = c.CreateCommand().ExecuteNonQuery();

            return affectedRows;
        }
        public int Insert(String sql, IDbConnection? conn = null)
        {
            return executeNonQuery(sql, conn);
        }

        public int Update(String sql, IDbConnection? conn = null)
        {
            return executeNonQuery(sql, conn);
        }

        public int Delate(String sql, IDbConnection? conn = null)
        {
            return executeNonQuery(sql, conn);
        }
        public DataSet Select(String sql, IDbConnection? conn = null)
        {
            var c = (conn == null ? this.baseConn : conn);
            var command = c.CreateCommand();
            command.CommandText = sql;

            var da = new SQLiteDataAdapter((SQLiteCommand)command);


            var ds = new DataSet();
            da.Fill(ds);

            command.Dispose();

            //var reader = command.ExecuteReader();
            //var result = reader.Read();
            //ds.Load(reader, LoadOption.OverwriteChanges, "Table");
            //reader.Close();

            return ds;
        }

        public static DataSet Test()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("FileName");
            dt.Columns.Add("FileType");
            dt.Columns.Add("RecvName");
            dt.Columns.Add("FileSize", typeof(int));
            dt.Columns.Add("PercentFinished", typeof(double));

            for(int i=0; i < 10; i++)
            {
                dt.Rows.Add($"Name{i}", $"Type{i}", $"Recv{i}", (i + 1) * 1321, 80.0);
            }

            ds.Tables.Add(dt);

            return ds;
        }
        public void Dispose()
        {
            if(this.baseConn != null) this.baseConn.Close();
        }
    }
}
