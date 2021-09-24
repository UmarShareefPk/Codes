using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BusTicketingSystem.UI.Pages
{
    public partial class PerformActions : System.Web.UI.Page
    {

        UsersTableAdapter usersTa = new UsersTableAdapter();
        ReservationsTableAdapter reservationTa = new ReservationsTableAdapter();
        CargoTableAdapter cargoTa = new CargoTableAdapter();
        CustomersTableAdapter customerTa = new CustomersTableAdapter();
        CustomerAccountInformationTableAdapter accountTa = new CustomerAccountInformationTableAdapter();
        BusSeatsTableAdapter busSeatTa = new BusSeatsTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Action"] != null)
            {
                string action = Request.QueryString["Action"];
                if (action == "ResetPassword")
                {
                    string id = Request.QueryString["Id"];

                    usersTa.UpdatePasswordById("password", int.Parse(id));

                    Response.Redirect("Users.aspx");

                }

                if(action == "ConfirmReservation")
                {
                    ConfirmReservation();
                }

               

                if (action == "ConfirmCargoReservation")
                {
                    ConfirmCargo();
                }

                if(action == "CancelReservation")
                {
                    CancelReservations();
                }

                if (action == "CancelCargoReservation")
                {
                    CancelCargoReservation();
                }
            }
        }// end page load
        
        public void CancelCargoReservation()
        {
            int id = int.Parse(Request.QueryString["Id"]);
            var cargo = cargoTa.GetCargoById(id);
            float charges = float.Parse(cargo.Rows[0]["Charges"].ToString());
            int customerId = int.Parse(cargo.Rows[0]["Customer_Id"].ToString());

            if (DateTime.Now.AddHours(3) > DateTime.Parse(cargo.Rows[0]["DepartureTime"].ToString()))
            {
                float fine = charges/2;
                if (bool.Parse(cargo.Rows[0]["ConfirmReservation"].ToString()))
                    fine = fine*(-1);

                accountTa.DeductAmountFromCustomerAmount(fine, customerId);
            }

            cargoTa.DeleteCargo(id);

            if (Request.QueryString["role"] != null && Request.QueryString["role"].ToLower() == "m")
                Response.Redirect("CancelReservations.aspx");

            Response.Redirect("CustomerProfile.aspx");
        }

        public void CancelReservations()
        {
            int id = int.Parse(Request.QueryString["Id"]);
            var reservation = reservationTa.GetReservationById(id);
            float fare = float.Parse(reservation.Rows[0]["Fare"].ToString());
            int customerId = int.Parse(reservation.Rows[0]["Customer_Id"].ToString());

            if(DateTime.Now.AddHours(3) > DateTime.Parse(reservation.Rows[0]["DepartureTime"].ToString()) )
            {
                float fine = fare / 2;
                if (bool.Parse(reservation.Rows[0]["ConfirmReservation"].ToString()))
                    fine = fine * (-1);

                accountTa.DeductAmountFromCustomerAmount(fine/2, customerId);
            }

            string seats = reservation.Rows[0]["BusSeat_Ids"].ToString();

            int routeId = int.Parse(reservation.Rows[0]["Route_Id"].ToString());

            var seatsList = seats.Split(',');
          
            foreach (var s in seatsList)
            {
                if(string.IsNullOrEmpty(s.Trim()))
                    continue;
          
                busSeatTa.BookSeat(false, routeId, int.Parse(s));
            }

            reservationTa.DeleteReservation(id);

            if (Request.QueryString["role"] != null && Request.QueryString["role"].ToLower() == "m")
                Response.Redirect("CancelReservations.aspx");

            Response.Redirect("CustomerProfile.aspx");

        }

        public void ConfirmReservation()
        {
            string id = Request.QueryString["Id"];
            reservationTa.ConfirmReservation(true, int.Parse(id));

            var reservation = reservationTa.GetReservationById(int.Parse(id));

            string email = "";
            string name = "";

            if (reservation.Rows[0]["Customer_Id"] == null || string.IsNullOrEmpty(reservation.Rows[0]["Customer_Id"].ToString()))
            {
                email = reservation.Rows[0]["Email"].ToString();
                name = reservation.Rows[0]["Name"].ToString();
            }
            else
            {
                var customer = customerTa.GetCustomerById(int.Parse(reservation.Rows[0]["Customer_Id"].ToString()));
                email = customer.Rows[0]["Email"].ToString();
                name = customer.Rows[0]["Name"].ToString();

                accountTa.DeductAmountFromCustomerAmount(float.Parse(reservation.Rows[0]["Fare"].ToString()),
                                                         int.Parse(reservation.Rows[0]["Customer_Id"].ToString()));
            }

            string body = "Dear <strong>" + name + "</strong>,<br/> " ;
            body += "Your reservation has been confirmed. Please find details in the attachment.";

            string pdf = "<h3 style='color:green;'>Your Reservation has been confirmed. Below are the details. </h3>";
            pdf += "Name :  <strong>" + name  +"</strong><br/> " ;
            pdf += "Departure :  " + reservation.Rows[0]["LocationA"].ToString() + ", " + reservation.Rows[0]["CityA"].ToString() + " at <strong>" +
                   DateTime.Parse(reservation.Rows[0]["DepartureTime"].ToString()).ToString("MMM dd, yyyy HH:mm tt") + "</strong><br/>";
            pdf += "Arrival : " + reservation.Rows[0]["LocationB"].ToString() + ", " + reservation.Rows[0]["CityB"].ToString() + " at <strong>" +
                 DateTime.Parse(reservation.Rows[0]["ArrivalTime"].ToString()).ToString("MMM dd, yyyy HH:mm tt") + "</strong><br/>";
            pdf += "Type : <strong>" + reservation.Rows[0]["Type"].ToString() + "</strong><br/>";
            pdf += "Fare : <strong>" + reservation.Rows[0]["Fare"].ToString() + " Rupees</strong><br/>";
            pdf += "Seats : <strong>" + reservation.Rows[0]["BusSeat_Ids"].ToString() + "</strong><br/>";
            GeneratePDF(pdf , "ConfirmReservation");

            List<string> files = new List<string>();
            files.Add(Server.MapPath("~/pdf/ConfirmReservation.pdf"));

            var mail = Common.SendEmail(email, "Confirm Reservation", body, files);

            File.SetAttributes(Server.MapPath("~/pdf/ConfirmReservation.pdf"), FileAttributes.Normal);
            System.IO.File.Delete(Server.MapPath("~/pdf/ConfirmReservation.pdf"));

            Response.Redirect("ConfirmReservations.aspx");
        }

        public void ConfirmCargo()
        {
            string id = Request.QueryString["Id"];
            cargoTa.ConfirmCargo(true, int.Parse(id));

            var cargo = cargoTa.GetCargoById(int.Parse(id));

            string email = "";
            string name = "";

            if (cargo.Rows[0]["Customer_Id"] == null || string.IsNullOrEmpty(cargo.Rows[0]["Customer_Id"].ToString()))
            {
                email = cargo.Rows[0]["Email"].ToString();
                name = cargo.Rows[0]["Name"].ToString();

            }
            else
            {
                var customer = customerTa.GetCustomerById(int.Parse(cargo.Rows[0]["Customer_Id"].ToString()));
                email = customer.Rows[0]["Email"].ToString();
                name = customer.Rows[0]["Name"].ToString();

                accountTa.DeductAmountFromCustomerAmount(float.Parse(cargo.Rows[0]["Charges"].ToString()),
                                                      int.Parse(cargo.Rows[0]["Customer_Id"].ToString()));
            }

            string body = "Dear <strong>" + name + "</strong>,<br/> ";
            body += "Your cargo reservation has been confirmed. Please find details in the attachment.";

            string pdf = "<h3 style='color:green;'>Your Cargo reservation has been confirmed. Below are the details. </h3>";
            pdf += "Name :  <strong>" + name + "</strong><br/> ";
            pdf += "From :  " + cargo.Rows[0]["LocationA"].ToString() + ", " + cargo.Rows[0]["CityA"].ToString() + " at <strong>" +
                   DateTime.Parse(cargo.Rows[0]["DepartureTime"].ToString()).ToString("MMM dd, yyyy HH:mm tt") + "</strong><br/>";
            pdf += "To : " + cargo.Rows[0]["LocationB"].ToString() + ", " + cargo.Rows[0]["CityB"].ToString() + " at <strong>" +
                 DateTime.Parse(cargo.Rows[0]["ArrivalTime"].ToString()).ToString("MMM dd, yyyy HH:mm tt") + "</strong><br/>";
            pdf += "Weight : <strong>" + cargo.Rows[0]["MaxWeight"].ToString() + " KG </strong><br/>";
            pdf += "Charges : <strong>" + cargo.Rows[0]["Charges"].ToString() + " Rupees</strong><br/>";
          
            GeneratePDF(pdf, "ConfirmCargo");

            List<string> files = new List<string>();
            files.Add(Server.MapPath("~/pdf/ConfirmCargo.pdf"));

            var mail = Common.SendEmail(email, "Confirm Cargo Reservation", body, files);

            File.SetAttributes(Server.MapPath("~/pdf/ConfirmCargo.pdf"), FileAttributes.Normal);
            System.IO.File.Delete(Server.MapPath("~/pdf/ConfirmCargo.pdf"));

            Response.Redirect("ConfirmReservations.aspx");
        }

        public void GeneratePDF(string text, string filename)
        {
            Document document = new Document();

            try
            {
                PdfWriter.GetInstance(document, new FileStream(Server.MapPath("~/") + "pdf/" + ""+ filename +".pdf", FileMode.Create));
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

               // Response.Redirect("~/pdf/print.pdf");
            }
            catch (Exception ex)
            {

            }
        }

    } // end class
}