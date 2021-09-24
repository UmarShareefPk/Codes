<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Routes.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.Routes" %>
<%@ Register TagPrefix="cc2" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.7.429, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <h2>Routes</h2>
   <div class="criteria" style="text-align: left;padding-left: 200px">
    Please filter routes by below criteria <br/>
      Type&nbsp; <asp:DropDownList ID="TypeDdl" style="height: 22px" CssClass="textboxWidth" runat="server">
                 <asp:ListItem Text="Normal" Value="1" ></asp:ListItem>
                 <asp:ListItem Text="VIP" Value="2" ></asp:ListItem>
                 <asp:ListItem Text="Cargo" Value="3" ></asp:ListItem>
           </asp:DropDownList> <br/>
  From <asp:DropDownList ID="TerminalADdl" style="height: 22px" CssClass="textboxWidth" runat="server"></asp:DropDownList> <br/>
   To  &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="TerminalBDdl" style="height: 22px" CssClass="textboxWidth" runat="server"></asp:DropDownList> <br/>
   Date <asp:TextBox ID="DateTb" runat="server" readonly="True"  style="width: 200px;height: 18px;"></asp:TextBox>
                 <cc2:CalendarExtender enabledonclient="True" Format="MMM dd, yyyy" defaultview="days" id="DateCalender" cssclass=""
                        runat="server" behaviorid="calendarA3" enabled="True" 
                        targetcontrolid="DateTb" >
                               </cc2:CalendarExtender> &nbsp;
    <asp:Button runat="server" CssClass="btn" Text="Refresh" ID="RefreshBtn" 
    onclick="RefreshBtn_Click"/>
    </div>
    
    <div class="tableDiv">
    <asp:GridView ID="RoutesGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
            PageSize="10" AllowPaging="True"  OnPageIndexChanging="RoutesGridView_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
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
              <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="../Pages/AddNewReservation.aspx?TypeId=<%# Eval("RouteType") %> &RouteId= <%# Eval("Id")%>">Make Reservation</a>
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
