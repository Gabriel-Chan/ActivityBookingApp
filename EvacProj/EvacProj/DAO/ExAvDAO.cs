using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace EvacProj
{
    public class ExAvDAO
    {
        private string UserName { get; set; }
        private string Password { get; set; }

        public ExAvDAO(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public int GetNumberOfExAvApplications()
        {

            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT COUNT(exav_id) AS numberOfExAvApps FROM apply WHERE applicant_username = :username", conn);

            cmd.Parameters.AddWithValue(":username", UserName);

            conn.Open();
            try
            {
                object numberOfApps = cmd.ExecuteScalar();
                if (Convert.IsDBNull(numberOfApps))
                    return 0;
                else
                    return Convert.ToInt32(numberOfApps);
            }
            finally
            {
                conn.Close();
            }
        }


        public List<ExAv> GetAvailableExAvs()
        {
            List<ExAv> availableExAvs = new List<ExAv>();
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT id FROM exav", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<int> exavIDs = new List<int>();
            conn.Open();
            try
            {
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    exavIDs.Add(Convert.ToInt32(dt.Rows[i]["id"]));
                }
                cmd.CommandText = "SELECT id, description, max_applicants FROM exav WHERE IS_EXAV_AVAILABLE(:exavID) = 1 AND id = :exavID";
                foreach (int exavID in exavIDs)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue(":exavID", exavID);
                    dt.Clear();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        int exAvId = Convert.ToInt32(dt.Rows[0]["id"]);
                        string description = Convert.ToString(dt.Rows[0]["description"]);
                        int maximumApplicants = Convert.ToInt32(dt.Rows[0]["max_applicants"]);
                        availableExAvs.Add(new ExAv(exAvId, description, maximumApplicants));
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            availableExAvs = availableExAvs.OrderBy(availExAv => availExAv.Description).ToList();
            return availableExAvs;
        }
    }
}