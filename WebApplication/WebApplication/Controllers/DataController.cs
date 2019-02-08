using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    public class DataController : Controller
    {
        private ArrayList list;
        [Route("api/Select")]
        [HttpGet]
        public ArrayList Select()
        {
            list = new ArrayList();
            DataBase DB = new DataBase();
            MySqlConnection conn = DB.GetConnection();
            if(conn != null)
            {
                string sql = "select * from Notice;";
                MySqlDataReader sdr = DB.GetReader(sql);
                while (sdr.Read())
                {
                    Hashtable ht = new Hashtable();
                    string[] arr = new string[sdr.FieldCount];
                    for(int i = 0; i<sdr.FieldCount; i++)
                    {
                        ht.Add(sdr.GetName(i), sdr.GetValue(i));
                        arr[i] = sdr.GetValue(i).ToString();
                    }
                    list.Add(ht);
                }
            }
            else
            {
                list.Add("디비접속 오류");
            }
            return list;
        }
    }
}
