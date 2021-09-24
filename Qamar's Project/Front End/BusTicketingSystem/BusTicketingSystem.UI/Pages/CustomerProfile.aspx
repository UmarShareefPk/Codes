<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.CustomerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script type="text/javascript">

        function CancelReservation(id) {

            if (confirm("Are you sure you want to cancel the reservation?")) {
                window.location = "PerformActions.aspx?action=CancelReservation&Id=" + id;
            }
        }

        function CancelCargoReservation(id) {

            if (confirm("Are you sure you want to cancel the Cargo reservation?")) {
                window.location = "PerformActions.aspx?action=CancelCargoReservation&Id=" + id;
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Customer Profile</h2>
    
    <div style="text-align: left;padding-left: 250px;">
    <span style="font-size:16px;color: black;text-align: left;"> Name : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>  <span style="font-size: 16px;color: Green;text-align: right;"> <%= customer.Name %> </span> <br/>
    <span style="font-size:16px;color: black;text-align: left;"> CNIC : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>  <span style="font-size: 16px;color: Green;text-align: right;"> <%= customer.CNIC %> </span> <br/>
    <span style="font-size:16px;color: black;text-align: left;"> Phone : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>  <span style="font-size: 16px;color: Green;text-align: right;"> <%= customer.Phone %> </span> <br/>
    <span style="font-size:16px;color: black;text-align: left;"> Email : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>  <span style="font-size: 16px;color: Green;text-align: right;"> <%= customer.Email %> </span> <br/>
    <span style="font-size:16px;color: black;text-align: left;"> Customer Since : </span>  <span style="font-size: 16px;color: Green;text-align: right;"> <%= customer.CustomerSince.ToString("MMM dd, yyyy") %> </span> <br/>
    <span style="padding-left: 150px;"><a class="btn"  href="EditCustomer.aspx?Id=<%= customer.Id %>">Edit </a></span>
    </div>
    
    <br/>
    
      <h2>Account Information</h2>
      <% if (accountInfo == null || accountInfo.Rows.Count == 0)
         {%>
         <span>No account exists. Please <a class="btn" href="AddCustomerAccountInformation.aspx?Id=<%= customer.Id %>">Add</a>. </span>
      
      <% }
         else
         { %>
       <span style="font-size:16px;color: black;text-align: left;"> Credit Card Number : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>  <span style="font-size: 16px;color: Green;text-align: right;"> <%= accountInfo.Rows[0]["CreditCardNumber"] %> </span> <br/>
        <span style="font-size:16px;color: black;text-align: left;"> Balance : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>  <span style="font-size: 16px;color: Green;text-align: right;"> <%= accountInfo.Rows[0]["Amount"] %> </span> <br/>

    <% } %>
    <h2>Reservations</h2>
    
      <div class="tableDiv">
    <asp:GridView ID="reservationsGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
            PageSize="10" AllowPaging="True"  OnPageIndexChanging="reservationsGridView_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ReservationCode" HeaderText="Code" ReadOnly="True" />
           
            <asp:BoundField DataField="Type" HeaderText="Route Type" ReadOnly="True" />
            <asp:TemplateField HeaderText="From">
                <ItemTemplate>
                    <%# Eval("LocationA") + ", " + Eval("CityA") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To">
                <ItemTemplate>
                    <%# Eval("LocationB") + ", " + Eval("CityB") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DepartureTime" HeaderText="Departure"  DataFormatString="{0:MMM dd, yyyy HH:mm}" />
            <asp:BoundField DataField="ArrivalTime" HeaderText="Arrival"  DataFormatString="{0:MMM dd, yyyy HH:mm}" />
                <asp:TemplateField HeaderText="Seats">
                <ItemTemplate>
                    <%# Eval("BusSeat_Ids").ToString().Replace("," , "  ") %>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:BoundField DataField="Fare" HeaderText="Fare" ReadOnly="True" />
            <asp:BoundField DataField="ConfirmReservation" HeaderText="Confirm" ReadOnly="True" />
                         
       <asp:TemplateField HeaderText="">
                <ItemTemplate>
                   <a style="color: skyblue;cursor: pointer;" onclick="CancelReservation(<%# Eval("Id") %>);"  >Cancel Reservation</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle ForeColor="White" BackColor="DeepSkyBlue" HorizontalAlign="Center" VerticalAlign="Top"></PagerStyle>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        
        <EmptyDataTemplate> No Reservations </EmptyDataTemplate>

        </asp:GridView>

    </div>
    
     <h2>Cargo Reservations</h2>
    
      <div class="tableDiv">
    <asp:GridView ID="CargoGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
            PageSize="10" AllowPaging="True"  OnPageIndexChanging="CargoGridView_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Code" HeaderText="Code" ReadOnly="True" />
           
            
            <asp:TemplateField HeaderText="From">
                <ItemTemplate>
                    <%# Eval("LocationA") + ", " + Eval("CityA") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To">
                <ItemTemplate>
                    <%# Eval("LocationB") + ", " + Eval("CityB") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DepartureTime" HeaderText="Departure"  DataFormatString="{0:MMM dd, yyyy HH:mm}" />
            <asp:BoundField DataField="ArrivalTime" HeaderText="Arrival"  DataFormatString="{0:MMM dd, yyyy HH:mm}" />
           
            <asp:BoundField DataField="maxWeight" HeaderText="Weight" ReadOnly="True" />
           <asp:BoundField DataField="Charges" HeaderText="Charges" ReadOnly="True" />
             <asp:BoundField DataField="ConfirmReservation" HeaderText="Confirm" ReadOnly="True" />
             <asp:TemplateField HeaderText="">
                <ItemTemplate>
                   <a style="color: skyblue;cursor: pointer;" onclick="CancelCargoReservation(<%# Eval("Id") %>);"  >Cancel Cargo</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle ForeColor="White" BackColor="DeepSkyBlue" HorizontalAlign="Center" VerticalAlign="Top"></PagerStyle>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        
        <EmptyDataTemplate> No Cargo Reservations. </EmptyDataTemplate>

        </asp:GridView>

    </div>

</asp:Content>
