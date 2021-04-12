using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace Velociraptor.AddOn
{
    class DBKeeper
    {
        private SqliteConnection conn = null;
        public string Message { get; set; }
        public struct SCAN_DATA
        {
            public string wafer_id;
            public int points_cnt;
            public int row1;
            public int col1;
            public int row2;
            public int col2;
            public int notch_way;
            public int scan_type; //1: 1um, 5: 5um
            public int scan_ok;
        }
        /*
         CREATE TABLE "scan_data" (
	        "wafer_id"	TEXT,
	        "points_cnt"	INTEGER,
	        "row1"	INTEGER,
	        "col1"	INTEGER,
	        "row2"	INTEGER,
	        "col2"	INTEGER,
	        "scan_type"	INTEGER DEFAULT 1,
            "scan_ok" INTEGER DEFAULT 1,
	        PRIMARY KEY("wafer_id")
            );
         */
        public DBKeeper()
        {
            Message = "";
            SqliteDataReader s_reader=null;
            try
            {
                string data_source = "Data source=" + Application.StartupPath
                                    + "/wafer.db";
                conn = new SqliteConnection(data_source);
                conn.Open();
                SqliteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='scan_data';";
                s_reader = sql_cmd.ExecuteReader();
                if (s_reader.Read())
                {
                    string temp = s_reader["name"].ToString();
                    if (temp != "scan_data")
                    {
                        Message = "[Sql] 找不到資料表";
                    }
                }
                else
                {
                    Message = "[Sql] 查詢資料表失敗";
                }
                s_reader.Close();
            }
            catch (SqliteException ex)
            {
                Message = "[Sql] 資料庫連線失敗 -- error code " + ex.Message;
                if (s_reader != null) s_reader.Close();
                if (conn != null) conn.Close();
            }
        }
        public bool OpenSucceeded()
        {
            return Message == "";
        }
        ~DBKeeper()
        {
            conn.Close();
        }
        public bool Insert(ref SCAN_DATA data)
        {
            if (data.wafer_id == "" || data.points_cnt == 0)
            {
                Message = "[Sql] wafer儲存資料不完整";
                return false;
            }

            SqliteCommand sql_cmd = conn.CreateCommand();

            try
            {
                sql_cmd.CommandText = "INSERT INTO main.scan_data (wafer_id, points_cnt, row1, col1, row2, col2, notch_way, scan_type, scan_ok) VALUES ("
                                        + data.wafer_id + ","
                                        + data.points_cnt.ToString() + ","
                                        + data.row1.ToString() + ","
                                        + data.col1.ToString() + ","
                                        + data.row2.ToString() + ","
                                        + data.col2.ToString() + ","
                                        + data.notch_way.ToString() + ","
                                        + data.scan_type.ToString() + ","
                                        + data.scan_ok.ToString() 
                                        + ");";
                sql_cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqliteException ex)
            {
                Message = "Insert DB failed -- error code " + ex.Message;
                return false;
            }

        }
        public bool Query(string wafer_id, ref SCAN_DATA data)
        {
            if (wafer_id == "")
            {
                Message = "無wafer ID";
                return false;
            }

            SqliteCommand sql_cmd = conn.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM main.scan_data WHERE wafer_id = '"
                                + wafer_id + "' AND scan_ok=1;";
            SqliteDataReader s_reader = sql_cmd.ExecuteReader();
            bool query_ok = true;
            try
            {
                while (s_reader.Read())
                {
                    data.wafer_id = wafer_id;
                    data.points_cnt = (int)s_reader["points_cnt"];
                    data.row1 = (int)s_reader["row1"];
                    data.col1 = (int)s_reader["col1"];
                    data.row2 = (int)s_reader["row2"];
                    data.col2 = (int)s_reader["col2"];
                    data.notch_way = (int)s_reader["notch_way"];
                    data.scan_type = (int)s_reader["scan_type"];
                    break;
                }
            }
            catch (SqliteException ex)
            {
                Message = "Select DB failed -- error code " + ex.Message;
                query_ok = false;
            }
            finally
            {
                s_reader.Close();
            }
            return query_ok;
        }

    }
}
