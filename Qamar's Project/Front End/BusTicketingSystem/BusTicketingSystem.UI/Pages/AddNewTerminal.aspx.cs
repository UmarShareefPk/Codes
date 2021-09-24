using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class AddNewTerminal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var terminalTa = new TerminalsTableAdapter();

            StatusLabel.ForeColor = System.Drawing.Color.Red;

            LocationTb.Text = LocationTb.Text.Trim();
            PhoneTb.Text = PhoneTb.Text.Trim();
            CityTb.Text = CityTb.Text.Trim();

            if( string.IsNullOrEmpty(LocationTb.Text) || string.IsNullOrEmpty(PhoneTb.Text) || string.IsNullOrEmpty(CityTb.Text))
            {
                StatusLabel.Text = "Please fill all fields.";
                StatusLabel.Visible = true;
                return;
            }

            if(terminalTa.DoesTerminalExist(CityTb.Text, LocationTb.Text) != 0)
            {
                StatusLabel.Text = "This terminal already exist.";
                StatusLabel.Visible = true;
                return;
            }

            try
            {
                terminalTa.AddNewTerminal(LocationTb.Text, PhoneTb.Text, CityTb.Text);
                StatusLabel.Text = "Terminal has been added.";
                Response.Redirect("AllTerminals.aspx");
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;
                LocationTb.Text = "";
                PhoneTb.Text = "";
                CityTb.Text = "";
                return;
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Error occured. Please try later.";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                StatusLabel.Visible = true;
            }

        }


        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string redirectLink = "AllTerminals.aspx";
            //if (Request.UrlReferrer != null)
            // redirectLink = Request.;

            Response.Redirect(redirectLink);
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            StatusLabel.ForeColor = System.Drawing.Color.Red;
            StatusLabel.Visible = false;
            LocationTb.Text = "";
            PhoneTb.Text = "";
            CityTb.Text = "";
        }
    }
}