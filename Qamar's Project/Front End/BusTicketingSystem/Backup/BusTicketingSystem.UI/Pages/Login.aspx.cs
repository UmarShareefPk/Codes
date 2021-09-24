using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL;
using BusTicketingSystem.BAL;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
   

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           if(!IsPostBack)
           {
               Session["User"] = null;
           }

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            var mgr = new BusTicketingSystemManager();
            string username = usernameTB.Text;
            string password = passwordTB.Text;

            var user = mgr.GetUserDetail(username, password);

            if(!user.IsValidUser)
            {
                StatusLabel.Text = "In correct Username or password.";
                StatusLabel.Visible = true;
                return;
            }

            Session["User"] = user;

            if(user.Role.Name == "Doctor" || user.Role.Name == "Driver" || user.Role.Name == "Security Guard" || user.Role.Name == "Bus Hostess")
            {
                Response.Redirect("StaffDuties.aspx");
            }

            if (user.Role.Name == "Customer" )
            {
                Response.Redirect("CustomerProfile.aspx");
            }

            if (user.Role.Name == "Manager")
            {
                Response.Redirect("ConfirmReservations.aspx");
            }

            if (user.Role.Name == "Call Operator")
            {
                Response.Redirect("Routes.aspx");
            }

            if (user.Role.Name == "Admin")
            {
                Response.Redirect("News.aspx");
            }

        }
    }
}