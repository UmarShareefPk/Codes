using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BusTicketingSystem.UI.Pages
{
    public partial class AddNewCargoReservation : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if(!IsPostBack)
            {
                if (!(Common.UserRole() == "Customer" || Common.UserRole() == "Call Operator"))
                    Response.Redirect("Error.aspx");

                var table = cargoWeightTa.GetAllCargoWeight();
                var datasource = (from row in table.AsEnumerable()
                                  select new
                                  {
                                      Id = row["Id"],
                                      Weight = row["minWeight"].ToString() + "KG to " + row["maxWeight"].ToString() + "KG"
                                  }
                           ).ToList();
                WeightsDdl.DataSource = datasource;
                WeightsDdl.DataValueField = "Id";
                WeightsDdl.DataTextField = "Weight";
                WeightsDdl.DataBind();
                ChargesTB.Text = table.Rows[0]["Charges"].ToString();
            }


        }

        RoutesTableAdapter routesTa = new RoutesTableAdapter();
        BusSeatsTableAdapter busSeatsTa = new BusSeatsTableAdapter();
        ReservationsTableAdapter reservationsTa = new ReservationsTableAdapter();
        BusesTableAdapter busTa = new BusesTableAdapter();
        CustomersTableAdapter customerTa = new CustomersTableAdapter();
        CustomersTableAdapter userTa = new CustomersTableAdapter();
        CargoTableAdapter cargoTa = new CargoTableAdapter();
        CargoWeightTableAdapter cargoWeightTa = new CargoWeightTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //  GeneratePDF("hi");
                if (Request.QueryString["RouteId"] == null)
                    Response.Redirect("Error.aspx");
               

                if (Common.UserRole() == "Customer")
                         PutCustomerDetails();
              
                if (Common.UserRole() == "Call Operator")
                        CustomerSearch.Visible = true;
                

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

        protected void AddBtn_Click(object sender, EventArgs e)
        {


            NameTb.Text = NameTb.Text.Trim();
            CnicTb.Text = CnicTb.Text.Trim();
            PhoneTb.Text = PhoneTb.Text.Trim();
            EmailTb.Text = EmailTb.Text.Trim();

            if (!(Common.UserRole() == "Customer" || (Common.UserRole() == "Call Operator" && Session["CustomerId"] != null)))
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
              
                string refNumber = "";
                if (Common.UserRole() == "Customer")
                {
                    refNumber = "cargo_" + Request.QueryString["RouteId"] + Common.ImportUser().CustomerInformation.Id + DateTime.Now.Millisecond;
                    cargoTa.AddNewCargo("", "", "", int.Parse(WeightsDdl.SelectedValue),
                                        int.Parse(Request.QueryString["RouteId"]), false,
                                        int.Parse(Common.ImportUser().CustomerInformation.Id), "", false,refNumber);


                }

                else if (Common.UserRole() == "Call Operator" && Session["CustomerId"] != null)
                {
                    refNumber = "Cargo_" + Request.QueryString["RouteId"] + (string)Session["CustomerId"] + DateTime.Now.Millisecond;
           
                    cargoTa.AddNewCargo("", "", "", int.Parse(WeightsDdl.SelectedValue),
                                       int.Parse(Request.QueryString["RouteId"]), false,
                                       int.Parse((string)Session["CustomerId"]), "", false,refNumber);
                }
                else
                {
                    refNumber = "Cargo_" + Request.QueryString["RouteId"] + DateTime.Now.Millisecond;
                  
                    cargoTa.AddNewCargo(NameTb.Text, CnicTb.Text, PhoneTb.Text, int.Parse(WeightsDdl.SelectedValue),
                                       int.Parse(Request.QueryString["RouteId"]), false,
                                       null, EmailTb.Text, false,refNumber);
                }


         
                StatusLabel.Text = "Reservation for  has been booked. Please note reservation number " + refNumber + ". Details are below. <br/><br/>" + "Charges : " + ChargesTB.Text;

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
            if (customer != null && customer.Rows.Count != 0)
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

        protected void WeightsDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargesTB.Text =
                cargoWeightTa.GetCargoWeightById(int.Parse(WeightsDdl.SelectedValue)).Rows[0]["Charges"].ToString();
        }


    }// end of class
}