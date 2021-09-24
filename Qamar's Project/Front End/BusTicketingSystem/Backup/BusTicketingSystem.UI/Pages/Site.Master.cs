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
    public partial class Site : System.Web.UI.MasterPage
    {
        public DataTable News = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            NewsTableAdapter adp = new NewsTableAdapter();
            News = adp.GetAllNews();
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            /* Session.Abandon();
             Response.Redirect("Login.aspx");
             */
        }
    }
}