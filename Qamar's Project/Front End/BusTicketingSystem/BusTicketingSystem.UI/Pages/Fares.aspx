<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Fares.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.Fares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Bus Seat Fares</h2>
    <div class="tableDiv">
    
    <asp:GridView ID="FaresGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
          >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
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
          <asp:BoundField DataField="Fare" HeaderText="Fare" ReadOnly="True" />
            <asp:BoundField DataField="Type" HeaderText="Bus Type" ReadOnly="True" />
              <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="../Pages/UpdateFare.aspx?Id= <%# Eval("Id")%>">Edit</a>
                   
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
    <h2>Cargo Fares</h2>
        
    <div class="tableDiv">
    
    <asp:GridView ID="CargoGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="minWeight" HeaderText="Minimum Weight" ReadOnly="True" />

         <asp:BoundField DataField="maxWeight" HeaderText="Maximum Weight" ReadOnly="True" />
                      <asp:BoundField DataField="Charges" HeaderText="Fare" ReadOnly="True" />
              <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="../Pages/UpdateFare.aspx?cargo=1&Id= <%# Eval("Id")%>">Edit</a>
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
