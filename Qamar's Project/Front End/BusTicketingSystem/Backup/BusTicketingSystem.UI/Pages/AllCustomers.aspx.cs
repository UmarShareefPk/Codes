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
    public partial class AllCustomers : System.Web.UI.Page
    {
        public DataTable AllCustomer = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");
            
            CustomersTableAdapter adp = new CustomersTableAdapter();
            AllCustomer = adp.GetAllCustomers();
            CustomersGridView.DataSource = AllCustomer;
            CustomersGridView.DataBind();
        }

        protected void CustomersGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            CustomersGridView.PageIndex = e.NewPageIndex;
            CustomersGridView.DataSource = AllCustomer;
            CustomersGridView.DataBind();
        }
    }
}