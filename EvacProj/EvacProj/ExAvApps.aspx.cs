using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvacProj
{
    public partial class ExAvApps : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Applicant applicant = (Applicant)Session["applicant"];
            ExAvDAO exAvDAO = new ExAvDAO(applicant.Username, applicant.Password);
            lblName.Text = applicant.FirstName + " " + applicant.LastName;
            lblPendApps.Text = exAvDAO.GetNumberOfExAvApplications().ToString();

            if (exAvDAO.GetAvailableExAvs().Count > 0)
            {
                gvAvailableApps.DataSource = exAvDAO.GetAvailableExAvs();
                gvAvailableApps.DataBind();
                lblError.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "There are no available excavations!!";
            }
        }

        protected void btnPend_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PendingApps.aspx");
        }

        protected void gvAvailableApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Applicant applicant = (Applicant)Session["applicant"];
            ApplyDAO applyDAO = new ApplyDAO(applicant.Username, applicant.Password);
            int index = Convert.ToInt32(e.CommandArgument);
            int exAvID = Convert.ToInt32(gvAvailableApps.Rows[index].Cells[1].Text);
            int month = Convert.ToInt32(ddMonths.SelectedItem.Value);

            if (e.CommandName == "APPLY")
            {
                try
                {
                    int success = applyDAO.Apply(exAvID, month);
                    if (success > 0)
                    {
                        Response.Redirect("~/PendingApps.aspx");
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "There are currently not enough slots for " + ddMonths.SelectedItem;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    lblError.Visible = true;
                }
            }
        }

        protected void gvAvailableApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
    }
}