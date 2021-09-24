using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;
using BusTicketingSystem.CL;

namespace BusTicketingSystem.UI.Pages
{
    public partial class CustomerProfile : System.Web.UI.Page
    {
        public Customer customer = new Customer();
        public DataTable accountInfo = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Common.UserRole() != "Customer")
                    Response.Redirect("Error.aspx");

                customer = Common.ImportUser().CustomerInformation;

                CustomerAccountInformationTableAdapter adp = new CustomerAccountInformationTableAdapter();

                accountInfo = adp.GetCustomerAccountInformationByCustomerId(int.Parse(customer.Id));

                var reservations = reservationTa.GetReservationByCustomerId(int.Parse(Common.ImportUser().CustomerInformation.Id));
                reservationsGridView.DataSource = reservations;
                reservationsGridView.DataBind();

                var cargo = cargoTa.GetCargoByCustomerId(int.Parse(Common.ImportUser().CustomerInformation.Id));
             CargoGridView.DataSource = cargo;
                CargoGridView.DataBind();

            }
        }


        ReservationsTableAdapter reservationTa = new ReservationsTableAdapter();
        CargoTableAdapter cargoTa = new CargoTableAdapter();


        protected void reservationsGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

            var reservations = reservationTa.GetReservationByCustomerId(int.Parse(Common.ImportUser().CustomerInformation.Id));
            reservationsGridView.PageIndex = e.NewPageIndex;
            reservationsGridView.DataSource = reservations;
            reservationsGridView.DataBind();
        }

        protected void CargoGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

            var cargo = cargoTa.GetCargoByCustomerId(int.Parse(Common.ImportUser().CustomerInformation.Id));
            CargoGridView.PageIndex = e.NewPageIndex;
            CargoGridView.DataSource = cargo;
            CargoGridView.DataBind();
        }

    }
}