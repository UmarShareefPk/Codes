<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="CustomersAccounts.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.CustomersAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2> Customers Account Information</h2>
    
          <div class="tableDiv">
    <asp:GridView ID="accountsGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
            PageSize="10" AllowPaging="True"  OnPageIndexChanging="accountsGridView_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Customer_Id" HeaderText="Customer Id" ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
            <asp:BoundField DataField="CNIC" HeaderText="CNIC" ReadOnly="True" />
            <asp:BoundField DataField="CreditCardNumber" HeaderText="Credit Card Number" ReadOnly="True" />
               <asp:BoundField DataField="Amount" HeaderText="Balance" ReadOnly="True" />
              
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
        
        <EmptyDataTemplate> No Users </EmptyDataTemplate>

        </asp:GridView>

    </div>
</asp:Content>
