using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class UpdateFare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {

            FareTb.Text = FareTb.Text.Trim();


            if (string.IsNullOrEmpty(FareTb.Text) || int.Parse(FareTb.Text) <= 0)
            {
                StatusLabel.Text = "Please enter proper value of fare.";
                StatusLabel.Visible = true;
                return;
            }
            
            try
            {
                if(Request.QueryString["Cargo"] != null)
                {
                    var cargoTa = new CargoWeightTableAdapter();
                    cargoTa.UpdateCargoFare(int.Parse(FareTb.Text), int.Parse(Request.QueryString["Id"]));
                }
                else
                {
                    var routeTa = new RoutesTableAdapter();
                    routeTa.UpdateFare(int.Parse(FareTb.Text), int.Parse(Request.QueryString["Id"]));
                }
           
                Response.Redirect("Fares.aspx");
              


            }
            catch (Exception)
            {
                StatusLabel.Text = "Error occured. Please try later.";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                StatusLabel.Visible = true;

            }


        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fares.aspx");
        }

    }
}