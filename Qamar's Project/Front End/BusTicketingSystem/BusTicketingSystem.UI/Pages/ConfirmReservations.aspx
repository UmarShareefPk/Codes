<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmReservations.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.ConfirmReservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
                   <a href="PerformActions.aspx?Action=ConfirmReservation&Id= <%# Eval("Id") %>">Confirm Reservation</a>
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
        
        <EmptyDataTemplate> No Reservation </EmptyDataTemplate>

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
                   <a href="PerformActions.aspx?Action=ConfirmCargoReservation&Id= <%# Eval("Id") %>">Confirm Reservation</a>
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
        
        <EmptyDataTemplate> No Cargo Reservation. </EmptyDataTemplate>

        </asp:GridView>

    </div>

</asp:Content>
