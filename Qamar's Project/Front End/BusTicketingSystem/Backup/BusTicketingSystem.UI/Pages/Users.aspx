<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2> users</h2>
    
          <div class="tableDiv">
    <asp:GridView ID="UsersGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
            PageSize="10" AllowPaging="True"  OnPageIndexChanging="UsersGridView_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" />
            <asp:BoundField DataField="Password" HeaderText="Password" ReadOnly="True" />
            <asp:BoundField DataField="Customer" HeaderText="Customer Id" ReadOnly="True" />
            <asp:BoundField DataField="Employee" HeaderText="Employee Id" ReadOnly="True" />

                <asp:TemplateField HeaderText="">
                <ItemTemplate>
                   <a href="PerformActions.aspx?Action=ResetPassword&Id=<%# Eval("Id") %>">Reset Password</a> 
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
        
        <EmptyDataTemplate> No Users </EmptyDataTemplate>

        </asp:GridView>

    </div>
    

</asp:Content>
