<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewCargoReservation.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AddNewCargoReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <h2> Make Cargo Reservation</h2>
    <br/> <br/>

  
    <label> Select Weight </label> <br/>
                 <asp:DropDownList ID="WeightsDdl" AutoPostBack="True" 
          style="height: 22px" CssClass="textboxWidth" runat="server" 
          onselectedindexchanged="WeightsDdl_SelectedIndexChanged">
                 </asp:DropDownList><br/>
                 
                 <label> Charges </label> <br/>
                 <asp:TextBox runat="server" ReadOnly="True" ID="ChargesTB"></asp:TextBox>
   

    <br/>    <br/>
   
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
