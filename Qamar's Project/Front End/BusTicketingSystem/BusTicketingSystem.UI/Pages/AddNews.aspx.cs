using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {

            NewsTb.Text = NewsTb.Text.Trim();


            if (string.IsNullOrEmpty(NewsTb.Text))
            {
                StatusLabel.Text = "Please enter description of News.";
                StatusLabel.Visible = true;
                return;
            }

            try
            {
               NewsTableAdapter newsTa = new NewsTableAdapter();
                newsTa.AddNews(NewsTb.Text);

                StatusLabel.Text = "News has been added.";
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;
                Response.Redirect("News.aspx");


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
            Response.Redirect("News.aspx");
        }
    }
}