using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.BAL;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var customerTa = new CustomersTableAdapter();
            var userTa = new UsersTableAdapter();

            var mgr = new BusTicketingSystemManager();
            string username = UsernameTb.Text;
            string password = PasswordTb.Text;

            var user = mgr.GetUserDetail(username, password);

            

            NewPasswordTb.Text = NewPasswordTb.Text.Trim();
            UsernameTb.Text = UsernameTb.Text.Trim();
            PasswordTb.Text = PasswordTb.Text.Trim();
            ConfirmPasswordTb.Text = ConfirmPasswordTb.Text.Trim();

            if (NewPasswordTb.Text == "" || UsernameTb.Text == "" || PasswordTb.Text == "" || ConfirmPasswordTb.Text == "")
            {
                StatusLabel.Text = "Please fill all fields.";
                StatusLabel.Visible = true;
                return;
            }
            

            if (NewPasswordTb.Text != ConfirmPasswordTb.Text)
            {
                StatusLabel.Text = "New Password and Confirm Passwords are not matching.";
                StatusLabel.Visible = true;
                return;
            }

            try
            {
                if (!user.IsValidUser)
                {
                    StatusLabel.Text = "Incorrect Username or password.";
                    StatusLabel.Visible = true;
                    return;
                }
                UsersTableAdapter adp = new UsersTableAdapter();
                adp.UpdatePassword(NewPasswordTb.Text, UsernameTb.Text);

                NewPasswordTb.Text = "";
                UsernameTb.Text = "";
                PasswordTb.Text = "";
                ConfirmPasswordTb.Text = "";

                StatusLabel.Text = "Password has been updated. <a href='login.aspx'>Login</a> now.";
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

       
    }
}