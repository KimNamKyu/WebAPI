using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class DataBase
    {
        public MySqlConnection conn;

        public DataBase()
        {
            conn = GetConnection();
        }

        public MySqlConnection GetConnection()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = string.Format("server={0};user={1};password={2};database={3};port={4}", "gdc3.gudi.kr", "root", "1234", "test", "21002");

            try
            {
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }

        public MySqlDataReader GetReader(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand(sql, conn);
                return comm.ExecuteReader() ;
            }
            catch
            {
                return null;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand(sql, conn);
                comm.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
