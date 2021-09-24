using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class Users : System.Web.UI.Page
    {
        UsersTableAdapter usersTa = new UsersTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Common.UserRole() != "Admin")
                    Response.Redirect("Error.aspx");

                var users = usersTa.GetAllUsers();
                UsersGridView.DataSource = users;
                UsersGridView.DataBind();
            }
        }

        protected void UsersGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

            var users = usersTa.GetAllUsers();
            UsersGridView.PageIndex = e.NewPageIndex;
            UsersGridView.DataSource = users;
            UsersGridView.DataBind();
        }
    }
}