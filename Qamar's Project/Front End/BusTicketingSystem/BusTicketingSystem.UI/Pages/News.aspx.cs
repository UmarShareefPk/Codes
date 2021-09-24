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
    public partial class News : System.Web.UI.Page
    {
        public DataTable news = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");

            NewsTableAdapter newsTa = new NewsTableAdapter();
            news = newsTa.GetAllNews();

            NewsGridView.DataSource = news;
            NewsGridView.DataBind();

        }

        protected void NewsGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            NewsGridView.PageIndex = e.NewPageIndex;
            NewsGridView.DataSource = news;
            NewsGridView.DataBind();
        }
    }
}