using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace Velociraptor.AddOn
{
    class DBKeeper
    {
        private SqliteConnection conn = null;
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
            "notch_way" INTEGER,
	        "scan_type"	INTEGER DEFAULT 1,
            "scan_ok" INTEGER DEFAULT 1,
	        PRIMARY KEY("wafer_id")
            );
         */
        public DBKeeper()
        {
            SqliteDataReader s_reader=null;
            try
            {
                string data_source = "Data source=" + Constants.appConfigFolder + "wafer.db";
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
                        throw new AvvaDBException("DB Exception: Table Not Found");
                    }
                }
                else
                {
                    throw new AvvaDBException("DB Exception: Metadata Query Failed");
                }
                s_reader.Close();
            }
            catch (SqliteException ex)
            {
                if (s_reader != null) s_reader.Close();
                if (conn != null) conn.Close();
                throw new AvvaDBException("DB Connection Exception", ex);
            }
        }
        ~DBKeeper()
        {
            conn.Close();
        }
        public void Insert(ref SCAN_DATA data)
        {
            if (data.wafer_id == "" || data.points_cnt == 0)
            {
                throw new AvvaDBException("DB Exception: Insert Wafer data incomplete");
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
            }
            catch (SqliteException ex)
            {
                throw new AvvaDBException("DB Exception", ex);
            }

        }
        public void Query(string wafer_id, ref SCAN_DATA data)
        {
            if (wafer_id == "")
            {
                throw new AvvaDBException("DB Exception: Wafer ID Not Found");
            }

            SqliteCommand sql_cmd = conn.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM main.scan_data WHERE wafer_id = '"
                                + wafer_id + "' AND scan_ok=1;";
            SqliteDataReader s_reader = sql_cmd.ExecuteReader();
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
                throw new AvvaDBException("DB Exception", ex);
            }
            finally
            {
                s_reader.Close();
            }
        }
    }

    [Serializable]
    class AvvaDBException : AvvaException
    {
        public AvvaDBException(string description)
            : base(description) { }

        public AvvaDBException(string description, Exception inner)
            : base(description, inner) { }
    }
}
