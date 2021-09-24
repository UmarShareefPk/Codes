<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AllEmployees.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AllEmployees" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <h2>Employees</h2>
        <div><a href="AddNewEmployee.aspx" class="btn"> Add Employee </a></div>
    <div class="tableDiv">
    
    <asp:GridView ID="EmployeesGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
            PageSize="10" AllowPaging="True"  OnPageIndexChanging="EmployeesGridView_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
            <asp:BoundField DataField="Designation" HeaderText="Designation" />
            <asp:TemplateField HeaderText="Terminal">
                <ItemTemplate>
                    <%# Eval("Location") + ", " + Eval("City") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
            <asp:BoundField DataField="Salary" HeaderText="Salary" />
            <asp:BoundField DataField="CNIC" HeaderText="CNIC" />
             <asp:BoundField DataField="Active" HeaderText="Active" />
                <asp:BoundField DataField="HireDate" HeaderText="Hire Date"  DataFormatString="{0:MMM dd, yyyy}" />
              <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <a href="../Pages/EditEmployee.aspx?Id= <%# Eval("Id")%>">Edit</a>
                   
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

        </asp:GridView>

    </div>

</asp:Content>
