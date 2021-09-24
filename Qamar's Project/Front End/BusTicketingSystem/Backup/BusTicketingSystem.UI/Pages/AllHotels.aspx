<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AllHotels.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AllHotels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2>Hotels</h2>
        <div><a href="AddNewHotel.aspx" class="btn"> Add Hotel </a></div>
    <div class="tableDiv">
    
    <asp:GridView ID="HotelsGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
            PageSize="10" AllowPaging="True"  OnPageIndexChanging="HotelsGridView_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
            <asp:BoundField DataField="RoomRent" HeaderText="Room Rent" />
            <asp:BoundField DataField="TotalRooms" HeaderText="Total Rooms" />
            <asp:BoundField DataField="AvailableRooms" HeaderText="Available Rooms" />
            
            <asp:TemplateField HeaderText="Terminal">
                <ItemTemplate>
                    <%# Eval("Location") + ", " + Eval("City") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
              <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <a href="../Pages/EditHotel.aspx?Id= <%# Eval("Id")%>">Edit</a>
                   
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
