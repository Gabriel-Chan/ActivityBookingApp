using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;

namespace EvacProj
{
    public class DatabaseHelper
    {
        public static ApplicantDAO Login(string UserName, string Password)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1};", UserName, Password));
            conn.Open(); // Try to connect using given username/password - if can't connect, an exception is thrown
            conn.Close();
            return new ApplicantDAO(UserName, Password);
        }
    }
}