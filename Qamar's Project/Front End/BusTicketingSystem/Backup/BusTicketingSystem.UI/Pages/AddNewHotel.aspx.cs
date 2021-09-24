﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.UI.Pages
{
    public partial class AddNewHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.UserRole() != "Admin")
                Response.Redirect("Error.aspx");
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

            TerminalsDdl.DataSource = datasource;
            TerminalsDdl.DataTextField = "Location";
            TerminalsDdl.DataValueField = "Id";
            TerminalsDdl.DataBind();
            
            base.OnInit(e);
        }

                protected void AddBtn_Click(object sender, EventArgs e)
        {
         
            NameTb.Text = NameTb.Text.Trim();
            RoomRentTb.Text = RoomRentTb.Text.Trim();
            TotalRoomTb.Text = TotalRoomTb.Text.Trim();

            if (string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(RoomRentTb.Text) || string.IsNullOrEmpty(TotalRoomTb.Text))
            {
                StatusLabel.Text = "Please fill all fields.";
                StatusLabel.Visible = true;
                return;
            }

          
            if (int.Parse(RoomRentTb.Text) <= 0 )
            {
                StatusLabel.Text = "Please enter proper Room rent.";
                StatusLabel.Visible = true;
                return;
            }

           if (int.Parse(TotalRoomTb.Text) <= 0 )
            {
                StatusLabel.Text = "Total Room must be a number greater than 0";
                StatusLabel.Visible = true;
                return;
            }


            try
            {
                HotelsTableAdapter adp = new HotelsTableAdapter();
                adp.AddNewHotels(NameTb.Text, double.Parse(RoomRentTb.Text), int.Parse(TotalRoomTb.Text),
                                 int.Parse(TotalRoomTb.Text), int.Parse(TerminalsDdl.SelectedValue));

                StatusLabel.Text = "Hotel has been added.";
                StatusLabel.ForeColor = System.Drawing.Color.Green;
                StatusLabel.Visible = true;
                Response.Redirect("AllHotels.aspx");
                NameTb.Text = "";
                RoomRentTb.Text = "";
                TotalRoomTb.Text = "";
                TerminalsDdl.ClearSelection();
              
             
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
            Response.Redirect("AllHotels.aspx");
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            StatusLabel.ForeColor = System.Drawing.Color.Red;
            StatusLabel.Visible = false;

              NameTb.Text = "";
                RoomRentTb.Text = "";
                TotalRoomTb.Text = "";
                TerminalsDdl.ClearSelection();
        }
    }
    
}