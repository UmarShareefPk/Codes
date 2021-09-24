<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewRoute.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AddNewRoute" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
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
     
    <h2> Add Route</h2>
            <div class="">
                
                   <label>Route Type</label> <br/>
                <asp:DropDownList ID="RouteTypeDdl" onselectedindexchanged="TerminalADdl_SelectedIndexChanged" AutoPostBack="True" style="height: 22px"  CssClass="textboxWidth" runat="server">
                       <asp:ListItem Text="Normal" Value="1" ></asp:ListItem>
                    <asp:ListItem Text="VIP" Value="2" ></asp:ListItem>
                     <asp:ListItem Text="Cargo" Value="3" ></asp:ListItem>
                </asp:DropDownList> <br/>

                <label>Terminal A</label> <br/>
                 <asp:DropDownList ID="TerminalADdl" AutoPostBack="True" style="height: 22px" 
                     CssClass="textboxWidth" runat="server" 
                     onselectedindexchanged="TerminalADdl_SelectedIndexChanged">
                 </asp:DropDownList> <br/>

                    <label>Terminal B</label> <br/>
                 <asp:DropDownList ID="TerminalBDdl" style="height: 22px;" CssClass="textboxWidth" runat="server">
                 </asp:DropDownList> <br/>
                  <label>Departure Time</label> <br/>
                <asp:TextBox ID="DepartureDateTb" runat="server" readonly="True" style="height: 22px;width:130px"></asp:TextBox>
                 <cc2:calendarextender enabledonclient="True" Format="MMM dd, yyyy" defaultview="days" id="Calendarextender1" cssclass=""
                        runat="server" behaviorid="calendarA3" enabled="True" 
                        targetcontrolid="DepartureDateTb" >
                               </cc2:calendarextender>
                Hours <asp:TextBox runat="server" MaxLength="2" style="height: 22px;width:20px" onkeyup="AllowIntegerOnly(this);" ID="dHourTb"></asp:TextBox> Minutes <asp:TextBox runat="server" MaxLength="2" style="height: 22px;width:20px" onkeyup="AllowIntegerOnly(this);" ID="dMinTb"></asp:TextBox> 
                <br/>
                 <label>Arrival Time</label> <br/>
                <asp:TextBox ID="ArrivalDateTb" runat="server" style="height: 22px;width:130px" readonly="True" ></asp:TextBox>
                 <cc3:calendarextender enabledonclient="True" Format="MMM dd, yyyy" defaultview="days" id="Calendarextender2" cssclass=""
                        runat="server" behaviorid="calendarA4" enabled="True" 
                        targetcontrolid="ArrivalDateTb" >
                               </cc3:calendarextender>
                Hours : <asp:TextBox runat="server" MaxLength="2" onkeyup="AllowIntegerOnly(this);" style="height: 22px;width:20px" ID="aHourTb"></asp:TextBox> Minutes <asp:TextBox runat="server" MaxLength="2" style="height: 22px;width:20px" onkeyup="AllowIntegerOnly(this);" ID="aMinTb"></asp:TextBox> 
                <br/>
                 
                 <label>Bus</label> <br/>
                 <asp:DropDownList ID="busDdl" style="height: 22px" AutoPostBack="True" 
                       CssClass="textboxWidth" runat="server" 
                       onselectedindexchanged="busDdl_SelectedIndexChanged">
                 </asp:DropDownList> <br/>
                 
                    <label>Fare</label> <br/>
                <asp:TextBox ID="FareTb" runat="server" onkeyup="AllowIntegerOnly(this);" style="height: 22px"></asp:TextBox><br/>

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
            
            <h5>Selected Bus has been booked for below routes. Please Add new route accordingly.</h5>
            
 <div class="tableDiv">
    <asp:GridView ID="RoutesGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" AutoGenerateColumns="False" GridLines="None"
            PageSize="5" AllowPaging="True"  OnPageIndexChanging="RoutesGridView_SelectedIndexChanged">
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
