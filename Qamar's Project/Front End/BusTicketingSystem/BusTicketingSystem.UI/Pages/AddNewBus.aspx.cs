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
    public partial class AddNewBus : System.Web.UI.Page
    {
        TerminalsTableAdapter terminalTa = new TerminalsTableAdapter();
        EmployeesTableAdapter employeeTa = new EmployeesTableAdapter();
        BusesTableAdapter busTa = new BusesTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");
        }

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

            SetEmployees(int.Parse(TerminalsDdl.SelectedValue));

            base.OnInit(e);
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            

            NumberTb.Text = NumberTb.Text.Trim();

            if (string.IsNullOrEmpty(NumberTb.Text) )
            {
                StatusLabel.Text = "Please fill all fields.";
                StatusLabel.Visible = true;
                return;
            }

            if (TypeDdl.SelectedValue != "3")
            {
                if (string.IsNullOrEmpty(TotalSeatsTb.Text) || int.Parse(TotalSeatsTb.Text) <= 0)
                {
                    StatusLabel.Text = "Total Seats must be an integer bigger than 0";
                    StatusLabel.Visible = true;
                    return;
                }
             }
            else 
            {
                if (string.IsNullOrEmpty(TotalWeightTb.Text) || int.Parse(TotalWeightTb.Text) <= 0)
                {
                    StatusLabel.Text = "Total Weight must be an integer bigger than 0";
                    StatusLabel.Visible = true;
                    return;
                }
            }
           

            try
            {
                int? totalSeats = null;
                int? totalWeight = null;

                if(TypeDdl.SelectedValue == "1" || TypeDdl.SelectedValue == "2" )
                    totalSeats = int.Parse(TotalSeatsTb.Text);
                else    
                    totalWeight = int.Parse(TotalWeightTb.Text);

                busTa.AddNewBus(NumberTb.Text, int.Parse(TypeDdl.SelectedValue), int.Parse(TerminalsDdl.SelectedValue), totalSeats,
                                totalWeight, int.Parse(DriverDdl.SelectedValue), int.Parse(DoctorDdl.SelectedValue),
                                int.Parse(BusHostessDdl.SelectedValue), int.Parse(SecurityGuardDdl.SelectedValue), int.Parse(TerminalsDdl.SelectedValue));
            

                StatusLabel.Text = "Bus has been added.";
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;

                NumberTb.Text = "";
                TerminalsDdl.ClearSelection();
                TypeDdl.ClearSelection();
                DoctorDdl.ClearSelection();
                DriverDdl.ClearSelection();
                BusHostessDdl.ClearSelection();
                SecurityGuardDdl.ClearSelection();
                TotalSeatsTb.Text = "";
                TotalWeightTb.Text = "";
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
            string redirectLink = "Login.aspx";
            //if (Request.UrlReferrer != null)
            // redirectLink = Request.;

            Response.Redirect(redirectLink);
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            StatusLabel.ForeColor = System.Drawing.Color.Red;
            StatusLabel.Visible = false;

            NumberTb.Text = "";
            TerminalsDdl.ClearSelection();
            SetEmployees(int.Parse(TerminalsDdl.SelectedValue));
            TypeDdl.ClearSelection();
            DoctorDdl.ClearSelection();
            DriverDdl.ClearSelection();
            BusHostessDdl.ClearSelection();
            SecurityGuardDdl.ClearSelection();
            TotalSeatsTb.Text = "";
            TotalWeightTb.Text = "";
        }

        protected void TerminalsDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEmployees(int.Parse(TerminalsDdl.SelectedValue));

        }

        protected void TypeDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TypeDdl.SelectedValue == "3")
            {
                DoctorDdl.Enabled = false;
                BusHostessDdl.Enabled = false;
            }

        }

        void SetEmployees(int terminalId)
        {
            var drivers = employeeTa.GetEmployeeByTerminalAndDesignation("Driver", terminalId);
            var doctors = employeeTa.GetEmployeeByTerminalAndDesignation("Doctor", terminalId);
            var SecurityGuards = employeeTa.GetEmployeeByTerminalAndDesignation("Security Guard", terminalId);
            var BusHostess = employeeTa.GetEmployeeByTerminalAndDesignation("Bus Hostess", terminalId);

            var employeeDatasource = (from row in drivers.AsEnumerable()
                                      select new
                                      {
                                          Id = row["Id"],
                                          Employee = row["Name"].ToString() + " (" + row["CNIC"].ToString() + ")"
                                      }
                             ).ToList();

            DriverDdl.DataSource = employeeDatasource;
            DriverDdl.DataTextField = "Employee";
            DriverDdl.DataValueField = "Id";
            DriverDdl.DataBind();

            employeeDatasource = (from row in doctors.AsEnumerable()
                                  select new
                                  {
                                      Id = row["Id"],
                                      Employee = row["Name"].ToString() + " (" + row["CNIC"].ToString() + ")"
                                  }
                             ).ToList();

            DoctorDdl.DataSource = employeeDatasource;
            DoctorDdl.DataTextField = "Employee";
            DoctorDdl.DataValueField = "Id";
            DoctorDdl.DataBind();


            employeeDatasource = (from row in SecurityGuards.AsEnumerable()
                                  select new
                                  {
                                      Id = row["Id"],
                                      Employee = row["Name"].ToString() + " (" + row["CNIC"].ToString() + ")"
                                  }
                             ).ToList();

            SecurityGuardDdl.DataSource = employeeDatasource;
            SecurityGuardDdl.DataTextField = "Employee";
            SecurityGuardDdl.DataValueField = "Id";
            SecurityGuardDdl.DataBind();

            employeeDatasource = (from row in BusHostess.AsEnumerable()
                                  select new
                                  {
                                      Id = row["Id"],
                                      Employee = row["Name"].ToString() + " (" + row["CNIC"].ToString() + ")"
                                  }
                       ).ToList();

            BusHostessDdl.DataSource = employeeDatasource;
            BusHostessDdl.DataTextField = "Employee";
            BusHostessDdl.DataValueField = "Id";
            BusHostessDdl.DataBind();



        }
    }
}