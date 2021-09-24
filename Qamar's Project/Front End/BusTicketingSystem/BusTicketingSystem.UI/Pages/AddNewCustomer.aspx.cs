using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL;
using BusTicketingSystem.BAL;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;
using System.Text.RegularExpressions;

namespace BusTicketingSystem.UI.Pages
{
    public partial class AddNewCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var customerTa = new CustomersTableAdapter();
            var userTa = new UsersTableAdapter();

            NameTb.Text = NameTb.Text.Trim();
            CnicTb.Text = CnicTb.Text.Trim();
            PhoneTb.Text = PhoneTb.Text.Trim();
            EmailTb.Text = EmailTb.Text.Trim();
            UsernameTb.Text = UsernameTb.Text.Trim();
            PasswordTb.Text = PasswordTb.Text.Trim();
            ConfirmPasswordTb.Text = ConfirmPasswordTb.Text.Trim();

            if(NameTb.Text == "" || CnicTb.Text == "" || PhoneTb.Text == "" || EmailTb.Text == "" || UsernameTb.Text == "" || PasswordTb.Text == "" || ConfirmPasswordTb.Text == "")
            {
                StatusLabel.Text = "Please fill all fields.";
                StatusLabel.Visible = true;
                return;
            }
            
            if(Regex.Matches(CnicTb.Text,@"[a-zA-Z]").Count > 0 || CnicTb.Text.Length != 13)
            {
                StatusLabel.Text = "CNIC must be 13 digits long. Please do not add spaces or -";
                StatusLabel.Visible = true;
                return;
            }

            if(customerTa.IsCustomerUnique(CnicTb.Text) != 0  )
            {
                StatusLabel.Text = "A customer with this CNIC already exists. It should be unique.";
                StatusLabel.Visible = true;
                return;
            }

            if(customerTa.IsEmailAvailable(EmailTb.Text) != 0)
            {
                StatusLabel.Text = "This Email address is already associated with a Customer. It should be unique.";
                StatusLabel.Visible = true;
                return;
            }

            if (userTa.IsUsernameAvailable(UsernameTb.Text) != 0)
            {
                StatusLabel.Text = "Username is not available.";
                StatusLabel.Visible = true;
                return;
            }

            if(PasswordTb.Text != ConfirmPasswordTb.Text)
            {
                StatusLabel.Text = "Passwords are not matching.";
                StatusLabel.Visible = true;
                return;
            }

            try
            {
                customerTa.AddNewCustomer(NameTb.Text, CnicTb.Text, EmailTb.Text, PhoneTb.Text,
                                     DateTime.Now.ToShortDateString(), true);
                string id = customerTa.GetCustomerByCnic(CnicTb.Text).Rows[0]["Id"].ToString();
                userTa.AddNewUser(null, UsernameTb.Text, PasswordTb.Text, DateTime.Now, DateTime.Now, 7, int.Parse(id));

                NameTb.Text = "";
                CnicTb.Text = "";
                PhoneTb.Text = "";
                EmailTb.Text = "";
                UsernameTb.Text = "";
                PasswordTb.Text = "";
                ConfirmPasswordTb.Text = "";

                StatusLabel.Text = "Customer has been added. Would you like to <a href='../pages/AddCustomerAccountInformation.aspx?Id="+ id +"'>add</a> account information.";
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;

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

            NameTb.Text = "";
            CnicTb.Text = "";
            PhoneTb.Text = "";
            EmailTb.Text = "";
            UsernameTb.Text = "";
            PasswordTb.Text = "";
            ConfirmPasswordTb.Text = "";
        }
    }
}