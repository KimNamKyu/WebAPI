using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

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

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = string.Format("server={0};user={1};password={2};database={3};port={4}", "gdc3.gudi.kr", "root", "1234", "test","21002");

            try
            {
                conn.Open();
                Console.WriteLine("Open Success");
                list.Add("Success");
            }
            catch 
            {
                Console.WriteLine("Fail!!");
                list.Add("Fail");
            }
            return list;
        }
    }
}
