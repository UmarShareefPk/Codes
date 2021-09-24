using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class CancelReservations : System.Web.UI.Page
    {


        ReservationsTableAdapter reservationTa = new ReservationsTableAdapter();
        CargoTableAdapter cargoTa = new CargoTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Common.UserRole() != "Manager")
                    Response.Redirect("Error.aspx");


                var reservations = reservationTa.GetAllReservationsToCancel();
                reservationsGridView.DataSource = reservations;
                reservationsGridView.DataBind();

                var cargo = cargoTa.GetAllCargoToCancel();
                CargoGridView.DataSource = cargo;
                CargoGridView.DataBind();

            }
        }


        protected void reservationsGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

            var reservations = reservationTa.GetAllReservationsToCancel();
            reservationsGridView.PageIndex = e.NewPageIndex;
            reservationsGridView.DataSource = reservations;
            reservationsGridView.DataBind();
        }

        protected void CargoGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

            var cargo = cargoTa.GetAllCargoToCancel();
            CargoGridView.PageIndex = e.NewPageIndex;
            CargoGridView.DataSource = cargo;
            CargoGridView.DataBind();
        }



    }
}