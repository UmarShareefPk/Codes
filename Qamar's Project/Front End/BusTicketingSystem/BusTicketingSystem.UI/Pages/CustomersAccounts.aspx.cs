using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class CustomersAccounts : System.Web.UI.Page
    {
        CustomerAccountInformationTableAdapter accountsTa = new CustomerAccountInformationTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
            {
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack)
            {
                var accounts = accountsTa.GetAllAccounts();
                accountsGridView.DataSource = accounts;
                accountsGridView.DataBind();
            }
        }

        protected void accountsGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

            var accounts = accountsTa.GetAllAccounts();
            accountsGridView.PageIndex = e.NewPageIndex;
            accountsGridView.DataSource = accounts;
            accountsGridView.DataBind();
        }
    }
}