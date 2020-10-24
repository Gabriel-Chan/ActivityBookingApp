using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvacProj
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                      ApplicantDAO applicant = DatabaseHelper.Login(txtUserName.Text.ToUpper(), txtPassword.Text);
                      if (applicant.ValidateApplicant() != null)
                      {
                        Session.Add("applicant", applicant.ValidateApplicant());
                        Response.Redirect("~/PendingApps.aspx");
                      }
                      else
                      {
                            lblInvalid.Visible = true;
                      }
                }
                catch (Exception)
                {
                    lblInvalid.Visible = true;
                }
            }
        }
    }
}