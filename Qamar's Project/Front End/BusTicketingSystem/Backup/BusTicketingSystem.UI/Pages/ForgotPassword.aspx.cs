using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            UsersTableAdapter usersTa = new UsersTableAdapter();
            CustomersTableAdapter customerTa = new CustomersTableAdapter();
            EmployeesTableAdapter employeeTa = new EmployeesTableAdapter();



            if (string.IsNullOrEmpty(UsernameTb.Text))
            {
                StatusLabel.Text = "Please enter Username";
                StatusLabel.Visible = true;
                return;
            }

            var user = usersTa.GetUserByUsername(UsernameTb.Text);

            if(user == null || user.Rows.Count == 0)
            {
                StatusLabel.Text = "Username does not exist.";
                StatusLabel.Visible = true;
                return;
            }


            try
            {
                string email = "";

                if (user.Rows[0]["Customer_Id"] == null || string.IsNullOrEmpty(user.Rows[0]["Customer_Id"].ToString()) )
                {
                    email = employeeTa.GetEmployeeById(int.Parse(user.Rows[0]["Employee_Id"].ToString())).Rows[0]["Email"].ToString();
                }

                if (user.Rows[0]["Employee_Id"] == null || string.IsNullOrEmpty(user.Rows[0]["Employee_Id"].ToString()))
                {
                    email = employeeTa.GetEmployeeById(int.Parse(user.Rows[0]["Customer_Id"].ToString())).Rows[0]["Email"].ToString();
                }

                string message = "Your password for username \""+ UsernameTb.Text +"\" is \"" + user.Rows[0]["password"].ToString() + "\"";
                string subject = "Your Password for Bus Ticketing System";

               var msg =  Common.SendEmail(email, subject, message, null);

                if(msg.ToLower().Contains("error"))
                {
                    StatusLabel.Text = "Cannot send email.";
                    StatusLabel.Visible = true;
                    return;
                    
                }

                ScriptManager.RegisterStartupScript(this, GetType(),"asd","alert('Your password has been emailed to you.');",true);
                Response.Redirect("Login.aspx");



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
            Response.Redirect("Login.aspx");
        }
    }
}