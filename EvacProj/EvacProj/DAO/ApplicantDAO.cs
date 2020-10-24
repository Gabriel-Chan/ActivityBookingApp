using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace EvacProj
{
    public class ApplicantDAO
    {
        private string UserName { get; set; }
        private string Password { get; set; }

        public ApplicantDAO(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
        public Applicant ValidateApplicant()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT first_name, last_name FROM applicant WHERE username = :username", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue(":username", UserName);
            da.Fill(dt);

            if (dt.Rows.Count > 0) // if username found
            {
                string firstName = Convert.ToString(dt.Rows[0]["first_name"]);
                string lastName = Convert.ToString(dt.Rows[0]["last_name"]);
                return new Applicant(UserName, Password, firstName, lastName);
            }
            else
                return null;
        }

        public void WithdrawApplication(int ExAvID)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("DELETE FROM apply WHERE exav_id = :ExAvID", conn);
            cmd.Parameters.AddWithValue(":ExAvID", ExAvID);
            OracleTransaction trans;
            conn.Open();
            trans = conn.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}