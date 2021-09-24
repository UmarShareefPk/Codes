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
    public partial class AllTerminals : System.Web.UI.Page
    {
        DataTable terminals = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");

            TerminalsTableAdapter terminalTa = new TerminalsTableAdapter();

            terminals = terminalTa.GetAllTerminals();
            TerminalsGridView.DataSource = terminals;
            TerminalsGridView.DataBind();
        }

        protected void TerminalsGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            TerminalsGridView.PageIndex = e.NewPageIndex;
            TerminalsGridView.DataSource = terminals;
            TerminalsGridView.DataBind();
        }

    }
}