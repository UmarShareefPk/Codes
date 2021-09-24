using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class Fares : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");

            var cargoTa = new CargoWeightTableAdapter();
            var routesTa = new RoutesTableAdapter();
            CargoGridView.DataSource = cargoTa.GetAllCargoWeight();
            CargoGridView.DataBind();

            FaresGridView.DataSource = routesTa.GetFares();
            FaresGridView.DataBind();
        }
    }
}