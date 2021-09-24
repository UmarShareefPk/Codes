using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class StaffDuties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Common.UserRole() == "Admin" || Common.UserRole() == "Doctor" ||
                    Common.UserRole() == "Security Guard" || Common.UserRole() == "Driver" ||
                    Common.UserRole() == "Bus Hostess")
                {
                    DescriptionLit.Text = "Dear " + Common.ImportUser().EmployeementInformation.Name +
                                          " please see below the details of routes that you need to be on.";
                }
                var routes = routesTa.GetRoutesByEmployeeId(int.Parse(Common.ImportUser().EmployeementInformation.Id));
                RoutesGridView.DataSource = routes;
                RoutesGridView.DataBind();
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        
        }

        RoutesTableAdapter routesTa = new RoutesTableAdapter();
     

        protected void RoutesGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
         
            var routes = routesTa.GetRoutesByEmployeeId(int.Parse(Common.ImportUser().EmployeementInformation.Id));
            RoutesGridView.PageIndex = e.NewPageIndex;
            RoutesGridView.DataSource = routes;
            RoutesGridView.DataBind();
        }
    }
}