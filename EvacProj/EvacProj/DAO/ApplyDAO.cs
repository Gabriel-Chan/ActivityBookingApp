using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EvacProj
{
    public class ApplyDAO
    {
        private string UserName { get; set; }
        private string Password { get; set; }

        public ApplyDAO(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public List<ExAvApplication> GetExAvApplications()
        {

            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("select id, description, month from apply left join exav on exav.id = apply.exav_id where applicant_username = :UserName order by month", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataTable dt = new DataTable();
            List<ExAvApplication> exAvApplication = new List<ExAvApplication>();

            cmd.Parameters.AddWithValue(":UserName", UserName);

            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                String description = Convert.ToString(dr["description"]);
                String month = DateTimeFormatInfo.CurrentInfo.GetMonthName(Convert.ToInt32(dr["month"]));
                exAvApplication.Add(new ExAvApplication(id, description, month));
            }
            return exAvApplication;
        }
        public int Apply(int exAvId, int month)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("EXAV_APPLY", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pexav_id", exAvId);
            cmd.Parameters.AddWithValue("pmonth", month);
            cmd.Parameters.Add("psuccess", OracleType.Int32).Direction = ParameterDirection.Output;
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["psuccess"].Value);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}