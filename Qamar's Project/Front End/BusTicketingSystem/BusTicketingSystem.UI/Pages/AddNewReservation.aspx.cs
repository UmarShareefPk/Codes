using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;

namespace BusTicketingSystem.UI.Pages
{
    public partial class AddNewReservation : System.Web.UI.Page
    {
        RoutesTableAdapter routesTa = new RoutesTableAdapter();
        BusSeatsTableAdapter busSeatsTa = new BusSeatsTableAdapter();
        ReservationsTableAdapter reservationsTa = new ReservationsTableAdapter();
        BusesTableAdapter busTa = new BusesTableAdapter();
        CustomersTableAdapter customerTa = new CustomersTableAdapter();
        CustomersTableAdapter userTa = new CustomersTableAdapter();

        private int Fare = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!(Common.UserRole() == "Customer" || Common.UserRole() == "Call Operator"))
                    Response.Redirect("Error.aspx");

              //  GeneratePDF("hi");
                if(Request.QueryString["RouteId"] == null || Request.QueryString["TypeId"] == null)
                        Response.Redirect("Error.aspx");

                int routeId = int.Parse(Request.QueryString["RouteId"]);
                int routeType = int.Parse(Request.QueryString["TypeId"]);

                if(routeType == 3)
                    Response.Redirect("AddNewCargoReservation.aspx?routeId=" + routeId);

                SetSeats(routeId);

                if(Common.UserRole() == "Customer")
                {
                    PutCustomerDetails();
                }
                if (Common.UserRole() == "Call Operator")
                {
                    CustomerSearch.Visible = true;
                }

            }
        }

       void PutCustomerDetails()
       {
           var customer = Common.ImportUser().CustomerInformation;

           NameTb.Text = customer.Name;
           PhoneTb.Text = customer.Phone;
           EmailTb.Text = customer.Email;
           CnicTb.Text = customer.CNIC;

           NameTb.Enabled = false;
           PhoneTb.Enabled = false;
           EmailTb.Enabled = false;
           CnicTb.Enabled = false;
       }

        void SetSeats(int routeId)
        {
            var seats = busSeatsTa.GetBusSeatsByRouteId(routeId);
            string html = "";

            foreach (DataRow seat in seats.Rows)
            {
                if(!bool.Parse(seat["isBooked"].ToString()))
                {
                    html += "<span class='seat' id='" + seat["SeatNumber"] + "' title='" + seat["Type"] + "' style='color:Green;cursor:pointer;'>" + seat["SeatNumber"] + "</span> &nbsp;&nbsp; ";
                }
                else
                {
                    html += "<span class='' id='" + seat["SeatNumber"] + "' title='" + "Booked" + "' style='color:Black;'>" + seat["SeatNumber"] + "</span> &nbsp;&nbsp; ";
                }
                
            }

            SeatsLit.Text = html;

        }

        string SetFareAndBookSeats()
        {
            int busFare = int.Parse(routesTa.GetRouteById(int.Parse(Request.QueryString["RouteId"])).Rows[0]["Fare"].ToString());
            string description = "";
            var seats = Seats.Text.Split(',');
            int count = 0;
            int currentFare = 0;
            for (int i = 0; i < seats.Count(); i++)
            {
               if( string.IsNullOrEmpty(seats[i].Trim()))
                   continue;
                count++;

                busSeatsTa.BookSeat(true, int.Parse(Request.QueryString["RouteId"]), int.Parse(seats[i]));

                if(busSeatsTa.GetTypeBySeatNumber(int.Parse(seats[i]), int.Parse(Request.QueryString["RouteId"])).Rows[0]["Type"].ToString() == "Normal" )
                {
                    currentFare = currentFare + busFare;
                }
                else
                {
                    currentFare = currentFare + busFare + (int)(busFare/100 * 30);
                }

            }

            int discount = 0;
            if (count >= 5)
                discount = currentFare/100*10;

            Fare = currentFare - discount;

            description += "Total Seats : " + count + "<br/>";
            description += "Total Fare : " + currentFare + "<br/>";
            description += "Discount : " + discount + "<br/>";
            description += "Net Fare : " + Fare + "<br/>";

            return description;
        }


        protected void AddBtn_Click(object sender, EventArgs e)
        {


            NameTb.Text = NameTb.Text.Trim();
            CnicTb.Text = CnicTb.Text.Trim();
            PhoneTb.Text = PhoneTb.Text.Trim();
            EmailTb.Text = EmailTb.Text.Trim();

            if (!(Common.UserRole() == "Customer" || ( Common.UserRole() == "Call Operator" && Session["CustomerId"] != null) ))
            {


                if (NameTb.Text == "" || CnicTb.Text == "" || PhoneTb.Text == "" || EmailTb.Text == "")
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

                if (customerTa.IsCustomerUnique(CnicTb.Text) != 0)
                {
                    StatusLabel.Text = "A customer with this CNIC already exists. It should be unique.";
                    StatusLabel.Visible = true;
                    return;
                }

                if (customerTa.IsEmailAvailable(EmailTb.Text) != 0)
                {
                    StatusLabel.Text = "This Email address is already associated with a Customer. It should be unique.";
                    StatusLabel.Visible = true;
                    return;
                }
            }



            try
            {
                string message = SetFareAndBookSeats();
                string refNumber = "";
                if (Common.UserRole() == "Customer" )
                {
                    refNumber = "Res_" + Request.QueryString["RouteId"] + Common.ImportUser().CustomerInformation.Id  +DateTime.Now.Millisecond;
                    reservationsTa.AddReservation("", "", "", Seats.Text, int.Parse(Request.QueryString["RouteId"]),
                                                  refNumber , "",
                                                  int.Parse(Common.ImportUser().CustomerInformation.Id), false, Fare);

                    
                }

                else if( Common.UserRole() == "Call Operator" && Session["CustomerId"] != null )
                {
                    refNumber = "Res_" + Request.QueryString["RouteId"] + (string)Session["CustomerId"]  +DateTime.Now.Millisecond;
                    reservationsTa.AddReservation("", "", "", Seats.Text, int.Parse(Request.QueryString["RouteId"]),
                                                  refNumber, "",
                                                  int.Parse((string)Session["CustomerId"]), false, Fare);
                }
                else
                {
                    refNumber = "Res_" + Request.QueryString["RouteId"] + DateTime.Now.Millisecond;
                    reservationsTa.AddReservation(NameTb.Text, CnicTb.Text, PhoneTb.Text, Seats.Text, int.Parse(Request.QueryString["RouteId"]),
                                                  refNumber,EmailTb.Text ,
                                                 null, false, Fare);
                }


                SetSeats(int.Parse(Request.QueryString["RouteId"]));
                StatusLabel.Text = "Reservation has been booked. Please note reservation number " + refNumber + ". Details are below. <br/><br/>" + message;

                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;

            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Error occured. Please try later.";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                StatusLabel.Visible = true;

            }


        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("Routes.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {

            var customer = customerTa.GetCustomerByCnic(CNICSearchTb.Text.Trim());
            if(customer != null && customer.Rows.Count !=0)
            {
                NameTb.Text = customer.Rows[0]["Name"].ToString();
                PhoneTb.Text = customer.Rows[0]["Phone"].ToString();
                EmailTb.Text = customer.Rows[0]["Email"].ToString();
                CnicTb.Text = customer.Rows[0]["CNIC"].ToString();

                Session["CustomerId"] = customer.Rows[0]["Id"].ToString();

                NameTb.Enabled = false;
                PhoneTb.Enabled = false;
                EmailTb.Enabled = false;
                CnicTb.Enabled = false;
            }
        }

        public void GeneratePDF(string text)
        {
            Document document = new Document();

            try
            {
                PdfWriter.GetInstance(document, new FileStream(Server.MapPath("~/") + "pdf/" + "print.pdf", FileMode.Create));
                document.Open();

                var htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(
                                  new StringReader(text), null);

                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    document.Add((IElement)htmlarraylist[k]);

                }

                Paragraph mypara = new Paragraph();
                document.Add(mypara);

                document.Close();

                Response.Redirect("~/pdf/print.pdf");
            }
            catch (Exception ex)
            {
                
            }
        }


    }// end of class
}