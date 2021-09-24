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
    public partial class AddNewRoute : System.Web.UI.Page
    {
        TerminalsTableAdapter terminalTa = new TerminalsTableAdapter();
        BusesTableAdapter busTa = new BusesTableAdapter();
        RoutesTableAdapter routeTa = new RoutesTableAdapter();
        BusSeatsTableAdapter seatsTa = new BusSeatsTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");
        }

        protected override void OnInit(EventArgs e)
        {
            InitializeValues();


            base.OnInit(e);
        }

        void InitializeValues()
        {
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

            var buses = busTa.GetBusesByCurrentLocation(int.Parse(TerminalADdl.SelectedValue), 1);

            busDdl.DataSource = buses;
            busDdl.DataTextField = "Number";
            busDdl.DataValueField = "Id";
            busDdl.DataBind();

            if (busDdl.Items.Count > 0)
            {
                SetRoutesByBus(int.Parse(busDdl.SelectedValue));
            }
            else
            {
                RoutesGridView.Visible = false;
            }

            DepartureDateTb.Text = DateTime.Now.ToString("MMM dd, yyyy");
          //  Calendarextender1.EndDate = DateTime.Now;
            Calendarextender1.StartDate = DateTime.Now;
            Calendarextender1.SelectedDate = DateTime.Now;

            ArrivalDateTb.Text = DateTime.Now.ToString("MMM dd, yyyy");
        //    Calendarextender2.EndDate = DateTime.Now;
            Calendarextender2.StartDate = DateTime.Now;
            Calendarextender2.SelectedDate = DateTime.Now;

            aHourTb.Text = "00";
            dHourTb.Text = "00";
            aMinTb.Text = "00";
            dMinTb.Text = "00";
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
          

            aHourTb.Text = aHourTb.Text.Trim();
            dHourTb.Text = dHourTb.Text.Trim();
            aMinTb.Text = aMinTb.Text.Trim();
            dMinTb.Text = dMinTb.Text.Trim();

            if(busDdl.Items.Count == 0)
            {
                StatusLabel.Text = "No Bus is available at "+ TerminalADdl.SelectedItem +" (Terminal A). Pleass add bus first.";
                StatusLabel.Visible = true;
                return;
            }

            if(TerminalADdl.SelectedValue == TerminalBDdl.SelectedValue)
            {
                StatusLabel.Text = "Terminal A and Terminal B cannot be the same.";
                StatusLabel.Visible = true;
                return;
            }

           if(!IstIimeProper())
           {
               StatusLabel.Text = "Time is not valid.";
               StatusLabel.Visible = true;
               return;
           }

            if(GetArrivalTime() <= GetDepartureTime())
            {
                StatusLabel.Text = "Arrival Time must be later than Departure Time.";
                StatusLabel.Visible = true;
                return;
            }

            if ( RouteTypeDdl.SelectedValue != "3" && (string.IsNullOrEmpty(FareTb.Text) || int.Parse(FareTb.Text) <= 0))
            {
                StatusLabel.Text = "Fare must be a decimal greater than 0.";
                StatusLabel.Visible = true;
                return;
            }

            try
            {
                int? fare = null; 
                 fare=   RouteTypeDdl.SelectedValue == "3" ? fare : int.Parse(FareTb.Text);

            routeTa.AddNewRoute(int.Parse(busDdl.SelectedValue), int.Parse(TerminalADdl.SelectedValue), int.Parse(TerminalBDdl.SelectedValue),
                                    GetDepartureTime(), GetArrivalTime(), int.Parse(RouteTypeDdl.SelectedValue),fare);
                var table = routeTa.GetRouteId(int.Parse(busDdl.SelectedValue), int.Parse(TerminalADdl.SelectedValue), int.Parse(TerminalBDdl.SelectedValue),
                                    GetDepartureTime(), GetArrivalTime(), int.Parse(RouteTypeDdl.SelectedValue));
                
                string id = table.Rows[0]["Id"].ToString();

                if (RouteTypeDdl.SelectedValue != "3")
                   AddSeats(int.Parse(id) , int.Parse(busDdl.SelectedValue));
            
                StatusLabel.Text = "Route has been added.";
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;

                aHourTb.Text = "00";
                dHourTb.Text = "00";
                aMinTb.Text = "00";
                dMinTb.Text = "00";

                RouteTypeDdl.ClearSelection();
                TerminalADdl.ClearSelection();
                TerminalBDdl.ClearSelection();
                TerminalBDdl.SelectedIndex = 1;
                var buses = busTa.GetBusesByCurrentLocation(int.Parse(TerminalADdl.SelectedValue), 1);

                busDdl.DataSource = buses;
                busDdl.DataTextField = "Number";
                busDdl.DataValueField = "Id";
                busDdl.DataBind();
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Error occured. Please try later.";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                StatusLabel.Visible = true;

            }


        }

        bool IstIimeProper()
        {
            if (int.Parse(dHourTb.Text) > 23 || int.Parse(dHourTb.Text) < 0)
                return false;
            if (int.Parse(aHourTb.Text) > 23 || int.Parse(aHourTb.Text) < 0)
                return false;
            if (int.Parse(aMinTb.Text) > 59 || int.Parse(aMinTb.Text) < 0)
                return false;
            if (int.Parse(dMinTb.Text) > 59 || int.Parse(dMinTb.Text) < 0)
                return false;
        

            return true;
        }

        void AddSeats(int routeId, int busId)
        {
            int totalSeats = int.Parse(busTa.GetBusById(busId).Rows[0]["NumberOfSeats"].ToString());

            int i = 1;
            for(i = 1 ; i <= totalSeats - 2 ; i++)
            {
                seatsTa.AddSeat(routeId, i, false, "Normal");
            }

            seatsTa.AddSeat(routeId, i , false, "Emergency");
            seatsTa.AddSeat(routeId, i+1, false, "Emergency");
        }


        DateTime GetDepartureTime()
        {
            var date = Request.Form[DepartureDateTb.UniqueID];
            Calendarextender1.SelectedDate = DateTime.Parse(date);
            var d = DateTime.Parse(date);
            DateTime departure = new DateTime(d.Year, d.Month, d.Day, int.Parse(dHourTb.Text), int.Parse(dMinTb.Text), 0);

            return departure;
        }

        DateTime GetArrivalTime()
        {
            var date = Request.Form[ArrivalDateTb.UniqueID];
            Calendarextender2.SelectedDate = DateTime.Parse(date);
            var a = DateTime.Parse(date);
            DateTime Arrival = new DateTime(a.Year, a.Month, a.Day, int.Parse(aHourTb.Text), int.Parse(aMinTb.Text), 0);
            return Arrival;
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

            aHourTb.Text = "00";
            dHourTb.Text = "00";
            aMinTb.Text = "00";
            dMinTb.Text = "00";

            RouteTypeDdl.ClearSelection();
            TerminalADdl.ClearSelection();
            TerminalBDdl.ClearSelection();
            TerminalBDdl.SelectedIndex = 1;
            busDdl.ClearSelection();
        }

        protected void TerminalADdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var buses = busTa.GetBusesByCurrentLocation(int.Parse(TerminalADdl.SelectedValue) , int.Parse(RouteTypeDdl.SelectedValue));

            busDdl.DataSource = buses;
            busDdl.DataTextField = "Number";
            busDdl.DataValueField = "Id";
            busDdl.DataBind();

            if(busDdl.Items.Count > 0)
            {
                SetRoutesByBus(int.Parse(busDdl.SelectedValue));
            }
            else
            {
                RoutesGridView.Visible = false;
            }
        }

        RoutesTableAdapter routesTa = new RoutesTableAdapter();

        protected void RoutesGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

            var routes = routesTa.GetRoutesByBusId(int.Parse(busDdl.SelectedValue));
            RoutesGridView.PageIndex = e.NewPageIndex;
            RoutesGridView.DataSource = routes;
            RoutesGridView.DataBind();
        }

        void SetRoutesByBus (int busId)
        {
            var routes = routesTa.GetRoutesByBusId(busId);
            RoutesGridView.DataSource = routes;
            RoutesGridView.DataBind();
            RoutesGridView.Visible = true;
        }

        protected void busDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (busDdl.Items.Count > 0)
            {
                SetRoutesByBus(int.Parse(busDdl.SelectedValue));
            }
            else
            {
                RoutesGridView.Visible = false;
            }
           
        }

    }
}