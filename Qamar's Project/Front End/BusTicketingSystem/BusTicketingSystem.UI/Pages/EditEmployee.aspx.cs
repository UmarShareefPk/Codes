using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                    Response.Redirect("../Pages/Error.aspx");

            
                string Id = Request.QueryString["Id"];

                try
                {
                    var employee = employeeTa.GetEmployeeById(int.Parse(Id));
                    CnicTb.Text = employee.Rows[0]["CNIC"].ToString();
                    NameTb.Text = employee.Rows[0]["Name"].ToString();
                    PhoneTb.Text = employee.Rows[0]["Phone"].ToString();
                    SalaryTb.Text = employee.Rows[0]["Salary"].ToString();
                    var selectItem = TerminalsDdl.Items.FindByValue(employee.Rows[0]["Terminal_Id"].ToString());
                    if (selectItem != null)
                    {
                        TerminalsDdl.ClearSelection();
                        selectItem.Selected = true;
                    }

                    selectItem = DesignationDdl.Items.FindByValue(employee.Rows[0]["Designation"].ToString());
                    if (selectItem != null)
                    {
                        DesignationDdl.ClearSelection();
                        selectItem.Selected = true;
                    }
                  
                    HireDateTb.Text = DateTime.Parse(employee.Rows[0]["HireDate"].ToString()).ToString("MMM dd, yyyy");
                    HireDateCalender.SelectedDate = DateTime.Parse(employee.Rows[0]["HireDate"].ToString());

                    ActiveChk.Checked = bool.Parse(employee.Rows[0]["Active"].ToString());

                    if (Common.IsUserAdmin())
                        ActiveChk.Enabled = true;
                }
                catch (Exception ex)
                {

                    Response.Redirect("Error.aspx");
                }

            }
        }

        EmployeesTableAdapter employeeTa = new EmployeesTableAdapter();
        UsersTableAdapter usersTa = new UsersTableAdapter();
        UserRolesTableAdapter userRoleTa = new UserRolesTableAdapter();

        protected override void OnInit(EventArgs e)
        {
            var terminalTa = new TerminalsTableAdapter();
            var allTerminals = terminalTa.GetAllTerminals();
            var datasource = (from row in allTerminals.AsEnumerable()
                              select new
                              {
                                  Id = row["Id"],
                                  Location = row["Location"].ToString() + ", " + row["City"].ToString()
                              }
                             ).ToList();

            TerminalsDdl.DataSource = datasource;
            TerminalsDdl.DataTextField = "Location";
            TerminalsDdl.DataValueField = "Id";
            TerminalsDdl.DataBind();

            HireDateTb.Text = DateTime.Now.ToString("MMM dd, yyyy");
            HireDateCalender.EndDate = DateTime.Now;
            HireDateCalender.StartDate = DateTime.Now.AddYears(-20);
            HireDateCalender.SelectedDate = DateTime.Now;
            base.OnInit(e);
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
         

            NameTb.Text = NameTb.Text.Trim();
            PhoneTb.Text = PhoneTb.Text.Trim();
            SalaryTb.Text = SalaryTb.Text.Trim();

            if (string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(PhoneTb.Text) || string.IsNullOrEmpty(SalaryTb.Text))
            {
                StatusLabel.Text = "Please fill all fields.";
                StatusLabel.Visible = true;
                return;
            }

            if (Regex.Matches(CnicTb.Text, @"[a-zA-Z]").Count > 0 || CnicTb.Text.Length != 13)
            {
                StatusLabel.Text = "CNIC must be 13 digits long. Please do not add spaces or -";
                StatusLabel.Visible = true;
                return;
            }

            if (employeeTa.IsEmployeeUnique(CnicTb.Text) > 1)
            {
                StatusLabel.Text = "An employee with this CNIC already exists. It should be unique.";
                StatusLabel.Visible = true;
                return;
            }

            if (DesignationDdl.SelectedValue == "Manager" && employeeTa.GetEmployeeById(int.Parse(Request.QueryString["Id"])).Rows[0]["Designation"].ToString() != "Manager" && employeeTa.GetManagerByTerminalId(int.Parse(TerminalsDdl.SelectedValue)) != 0)
            {
                StatusLabel.Text = "Selected terminal already has a Manager.";
                StatusLabel.Visible = true;
                return;
            }

            float salary = 0;

            if (!float.TryParse(SalaryTb.Text, out salary))
            {
                StatusLabel.Text = "Salary must be in decimal.";
                StatusLabel.Visible = true;
                return;
            }


            try
            {

                employeeTa.UpdateEmployee(NameTb.Text, CnicTb.Text, DesignationDdl.SelectedValue,
                                          int.Parse(TerminalsDdl.SelectedValue), PhoneTb.Text,
                                          float.Parse(SalaryTb.Text),
                                          HireDateCalender.SelectedDate.Value.ToString("MM/dd/yyyy"), ActiveChk.Checked,int.Parse(Request.QueryString["Id"]));
                

                StatusLabel.Text = "Employee has been Edited.";
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;

              Response.Redirect("AllEmployees.aspx");
            }
            catch (Exception)
            {
                StatusLabel.Text = "Error occured. Please try later.";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                StatusLabel.Visible = true;

            }


        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string redirectLink = "AllEmployees.aspx";
            //if (Request.UrlReferrer != null)
            // redirectLink = Request.;

            Response.Redirect(redirectLink);
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            StatusLabel.ForeColor = System.Drawing.Color.Red;
            StatusLabel.Visible = false;

            NameTb.Text = "";
            PhoneTb.Text = "";
            SalaryTb.Text = "";
            TerminalsDdl.ClearSelection();
            DesignationDdl.ClearSelection();
            HireDateTb.Text = DateTime.Now.ToString("MMM dd, yyyy");
            HireDateCalender.SelectedDate = DateTime.Now;
        }
    }
}