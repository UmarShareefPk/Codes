using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class AllHotels : System.Web.UI.Page
    {
        public DataTable hotels = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");

            HotelsTableAdapter hotelTa = new HotelsTableAdapter();
            hotels = hotelTa.GetAllHotels();

            HotelsGridView.DataSource = hotels;
            HotelsGridView.DataBind();

        }

        protected void HotelsGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            HotelsGridView.PageIndex = e.NewPageIndex;
            HotelsGridView.DataSource = hotels;
            HotelsGridView.DataBind();
        }
    }
}