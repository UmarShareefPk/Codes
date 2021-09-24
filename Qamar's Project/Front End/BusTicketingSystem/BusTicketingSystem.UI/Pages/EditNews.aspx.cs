using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class EditNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                    Response.Redirect("../Pages/Error.aspx");

                if(Request.QueryString["del"] != null)
                {
                    var adp = new NewsTableAdapter();
                    adp.DeleteNews(int.Parse(Request.QueryString["Id"]));
                    Response.Redirect("News.aspx");
                }

                var newsTa = new NewsTableAdapter();
                string newsId = Request.QueryString["Id"];

                try
                {
                    var news = newsTa.GetNewsById(int.Parse(newsId));

                    NewsTb.Text = news.Rows[0]["News"].ToString();

                }
                catch (Exception ex)
                {

                    Response.Redirect("Error.aspx");
                }

            }
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
                newsTa.Update(NewsTb.Text, int.Parse(Request.QueryString["Id"]));

                StatusLabel.Text = "News has been Edited.";
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