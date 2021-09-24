using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class EditTerminal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                    Response.Redirect("../Pages/Error.aspx");

                var terminalTa = new TerminalsTableAdapter();
                string customerId = Request.QueryString["Id"];

                try
                {
                    var terminal = terminalTa.GetTerminalById(int.Parse(customerId));

                    LocationTb.Text = terminal.Rows[0]["Location"].ToString();
                    CityTb.Text = terminal.Rows[0]["City"].ToString();
                    PhoneTb.Text = terminal.Rows[0]["Phone"].ToString();
                 
                }
                catch (Exception ex)
                {

                    Response.Redirect("Error.aspx");
                }

            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var terminalTa = new TerminalsTableAdapter();

            StatusLabel.ForeColor = System.Drawing.Color.Red;

            LocationTb.Text = LocationTb.Text.Trim();
            PhoneTb.Text = PhoneTb.Text.Trim();
            CityTb.Text = CityTb.Text.Trim();

            if (string.IsNullOrEmpty(LocationTb.Text) || string.IsNullOrEmpty(PhoneTb.Text) || string.IsNullOrEmpty(CityTb.Text))
            {
                StatusLabel.Text = "Please fill all fields.";
                StatusLabel.Visible = true;
                return;
            }

            if (terminalTa.DoesTerminalExist(CityTb.Text, LocationTb.Text) > 1)
            {
                StatusLabel.Text = "This terminal already exist.";
                StatusLabel.Visible = true;
                return;
            }

            try
            {
                terminalTa.UpdateTerminal(LocationTb.Text, PhoneTb.Text, CityTb.Text, int.Parse(Request.QueryString["Id"]));
                StatusLabel.Text = "Terminal has been Edited.";
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;
                string redirectLink = "AllTerminals.aspx";
                Response.Redirect(redirectLink);
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
            Response.Redirect(redirectLink);
        }

    }
}