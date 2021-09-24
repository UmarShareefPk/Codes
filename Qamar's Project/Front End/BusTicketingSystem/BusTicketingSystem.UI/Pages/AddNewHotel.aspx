<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewHotel.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AddNewHotel" %>
<%@ Register TagPrefix="cc2" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.7.429, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <script type="text/javascript">

          function AllowIntegerOnly(source) {
              var regExp = /\d+/g;
              var value = regExp.exec($(source).val());
              $(source).val(value);

          }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <h2> Add Hotel</h2>
            <div class="">
              <label>Hotel Name</label><br/>
                <asp:TextBox ID="NameTb" runat="server"></asp:TextBox> <br/>
                <label>Terminal</label> <br/>
                 <asp:DropDownList ID="TerminalsDdl" style="height: 22px" CssClass="textboxWidth" runat="server">
                 </asp:DropDownList> <br/>
                  <label>Room Rent in Rs</label> <br/>
                <asp:TextBox ID="RoomRentTb" runat="server" onkeyup="AllowIntegerOnly(this);" style="height: 22px"></asp:TextBox><br/>
                     <label>Total Rooms</label> <br/>
                <asp:TextBox ID="TotalRoomTb" runat="server" onkeyup="AllowIntegerOnly(this);" style="height: 22px"></asp:TextBox><br/>
             
              <br/><br/>
                <asp:Label runat="server" ForeColor="Red" Visible="False" ID="StatusLabel" Text=""></asp:Label>
                    <br/><br/>
                <asp:Button CssClass="btn" ID="AddBtn" runat="server" Text="Save" 
                    onclick="AddBtn_Click" />
                    <asp:Button CssClass="btn" ID="CancelBtn" runat="server" Text="Cancel" 
                    onclick="CancelBtn_Click" />
                    <asp:Button CssClass="btn" ID="Reset" runat="server" Text="Reset" 
                    onclick="ResetBtn_Click" />
            </div>

</asp:Content>
