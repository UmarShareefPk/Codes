using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class Routes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

            TerminalADdl.DataSource = datasource;
            TerminalADdl.DataTextField = "Location";
            TerminalADdl.DataValueField = "Id";
            TerminalADdl.DataBind();

            TerminalBDdl.DataSource = datasource;
            TerminalBDdl.DataTextField = "Location";
            TerminalBDdl.DataValueField = "Id";
            TerminalBDdl.DataBind();

            TerminalBDdl.SelectedIndex = 1;

            DateCalender.SelectedDate = DateTime.Now;
            DateCalender.StartDate = DateTime.Now;
            DateCalender.EndDate = DateTime.Now.AddDays(14);
            var date = DateTime.Now;

            var date2 = DateTime.Now.AddDays(14);
            var routes = routesTa.GetRoutesByCriteria(int.Parse(TypeDdl.SelectedValue), date.ToShortDateString(), date2.ToShortDateString(),
                                                     int.Parse(TerminalADdl.SelectedValue),
                                                     int.Parse(TerminalBDdl.SelectedValue));
            RoutesGridView.DataSource = routes;
            RoutesGridView.DataBind();

            base.OnInit(e);
        }
        RoutesTableAdapter routesTa = new RoutesTableAdapter();
        protected void RefreshBtn_Click(object sender, EventArgs e)
        {
             //DateTime date = DateTime.ParseExact(DateTb.Text, null, DateCalender.Format);
             var date2 = Request.Form[DateTb.UniqueID];
            var date = DateTime.Parse(date2);
            DateCalender.SelectedDate = date;
            var date3 = DateTime.Now.AddDays(14);
            var routes = routesTa.GetRoutesByCriteria(int.Parse(TypeDdl.SelectedValue), date.ToShortDateString(), date3.ToShortDateString(),
                                                      int.Parse(TerminalADdl.SelectedValue),
                                                      int.Parse(TerminalBDdl.SelectedValue));
            RoutesGridView.DataSource = routes;
            RoutesGridView.DataBind();
        }

        protected void RoutesGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            DateTime date = DateCalender.SelectedDate.Value;
            var date2 = DateTime.Now.AddDays(14);
            var routes = routesTa.GetRoutesByCriteria(int.Parse(TypeDdl.SelectedValue), date.ToShortDateString(), date2.ToShortDateString(),
                                                     int.Parse(TerminalADdl.SelectedValue),
                                                     int.Parse(TerminalBDdl.SelectedValue));
            RoutesGridView.PageIndex = e.NewPageIndex;
            RoutesGridView.DataSource = routes;
            RoutesGridView.DataBind();
        }
    }
}