<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewReservation.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AddNewReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" >

        $(document).ready(function () {

            $('#<%= Seats.ClientID %>').attr("readonly", "readonly");

            $(".seat").click(function () {

                $(this).toggleClass("SeatSelected");

                var seats = "";
                var count = 0;
                $(".SeatSelected").each(function () {
                    seats += $(this).html() + ", ";
                    count++;
                });

                $('#<%= Seats.ClientID %>').val(seats);

                if (count == 0)
                    $("#seatCount").html("No seat is selected.");
                else {
                    $("#seatCount").html(count + " seat(s) selected.");
                }

            });


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2> Make Reservation</h2>
    <br/> <br/>

    Seats in Green color are available. <br/>
    
    <asp:Literal runat="server" ID="SeatsLit"></asp:Literal>

    <br/>    <br/>
    <span id="seatCount"> No seat is selected. </span>: <asp:TextBox  runat="server" ID="Seats" ></asp:TextBox>
        <br/><br/>
        <div runat="server" id="CustomerSearch" Visible="False">
            <br/><br/>
              <label>Enter Customer CNIC</label> 
                <asp:TextBox ID="CNICSearchTb" runat="server" ></asp:TextBox>
                   <asp:Button CssClass="btn" ID="SearchBtn" runat="server" Text="Search" 
                    onclick="Search_Click" />
                    <br/> <br/> <br/>
        </div>
        <div class="accountInfo">
              <label>Name</label><br/>
                <asp:TextBox ID="NameTb" runat="server"></asp:TextBox> <br/>
                  <label>CNIC</label> <br/>
                <asp:TextBox ID="CnicTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                 <label>Email</label> <br/>
                <asp:TextBox ID="EmailTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                 <label>Phone</label> <br/>
                <asp:TextBox ID="PhoneTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                  
                <br/><br/>
                <asp:Label runat="server" ForeColor="Red" Visible="False" ID="StatusLabel" Text=""></asp:Label>
                    <br/><br/>
                <asp:Button CssClass="btn" ID="AddBtn" runat="server" Text="Save" 
                    onclick="AddBtn_Click" />
                    <asp:Button CssClass="btn" ID="CancelBtn" runat="server" Text="Cancel" 
                    onclick="CancelBtn_Click" />
                    
            </div>


     
</asp:Content>
