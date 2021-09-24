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
    public partial class EditCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                    Response.Redirect("../Pages/Error.aspx");

                var customerTa = new CustomersTableAdapter();
                string customerId = Request.QueryString["Id"];

                try
                {
                    var customer = customerTa.GetCustomerById(int.Parse(customerId));

                    NameTb.Text = customer.Rows[0]["Name"].ToString();
                    CnicTb.Text = customer.Rows[0]["CNIC"].ToString();
                    PhoneTb.Text = customer.Rows[0]["Phone"].ToString();
                    EmailTb.Text = customer.Rows[0]["Email"].ToString();

                    ActiveChk.Checked = bool.Parse(customer.Rows[0]["Active"].ToString());

                    if (Common.IsUserAdmin())
                        ActiveChk.Enabled = true;
                }
                catch (Exception ex)
                {

                    Response.Redirect("Error.aspx");
                }

            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var customerTa = new CustomersTableAdapter();
            var userTa = new UsersTableAdapter();

            NameTb.Text = NameTb.Text.Trim();
            CnicTb.Text = CnicTb.Text.Trim();
            PhoneTb.Text = PhoneTb.Text.Trim();
            EmailTb.Text = EmailTb.Text.Trim();
         

            if (NameTb.Text == "" || CnicTb.Text == "" || PhoneTb.Text == "" || EmailTb.Text == "" )
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

            if (customerTa.IsCustomerUnique(CnicTb.Text) > 1)
            {
                StatusLabel.Text = "A customer with this CNIC already exists. It should be unique.";
                StatusLabel.Visible = true;
                return;
            }

            if (customerTa.IsEmailAvailable(EmailTb.Text) > 1)
            {
                StatusLabel.Text = "This Email address is already associated with a Customer. It should be unique.";
                StatusLabel.Visible = true;
                return;
            }

          

            try
            {
                customerTa.UpdateCustomer(NameTb.Text, CnicTb.Text, EmailTb.Text, PhoneTb.Text,
                                     DateTime.Now.ToShortDateString(), ActiveChk.Checked, int.Parse(Request.QueryString["Id"]));
              
                StatusLabel.Text = "Customer information has been edited.";
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
        
        }
    }
}