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
    public partial class AllEmployees : System.Web.UI.Page
    {
        public DataTable Employees = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");

            EmployeesTableAdapter employeeTa = new EmployeesTableAdapter();
            Employees = employeeTa.GetAllEmployees();

            EmployeesGridView.DataSource = Employees;
            EmployeesGridView.DataBind();
            
        }

        protected void EmployeesGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            EmployeesGridView.PageIndex = e.NewPageIndex;
            EmployeesGridView.DataSource = Employees;
            EmployeesGridView.DataBind();
        }
    }
}