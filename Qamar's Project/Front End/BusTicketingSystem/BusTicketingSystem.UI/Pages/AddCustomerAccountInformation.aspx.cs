using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class AddCustomerAccountInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Common.UserRole() != "Customer")
                Response.Redirect("Error.aspx");
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {


            CardNumberTb.Text = CardNumberTb.Text.Trim();

            if (string.IsNullOrEmpty(CardNumberTb.Text))

            {
                StatusLabel.Text = "Please fill all fields.";
                StatusLabel.Visible = true;
                return;
            }
           
            if (CardNumberTb.Text.Length != 16 )
            {
                StatusLabel.Text = "Credit Card Number must be 16 characters long.";
                StatusLabel.Visible = true;
                return;
            }
          

            try
            {
                CustomerAccountInformationTableAdapter adp = new CustomerAccountInformationTableAdapter();

                adp.AddAccountInformation(int.Parse(Request.QueryString["Id"]), CardNumberTb.Text, 50000);
                

                StatusLabel.Text = "Credit Card Information has been saved.";
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;

                CardNumberTb.Text = "";
                AddBtn.Enabled = false;
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

            CardNumberTb.Text = "";
 
        }




    }
}