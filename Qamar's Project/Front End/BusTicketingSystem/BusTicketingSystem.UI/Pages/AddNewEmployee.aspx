<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewEmployee.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AddNewEmployee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2> Add Employee</h2>
            <div class="">
              <label>Name</label><br/>
                <asp:TextBox ID="NameTb" runat="server"></asp:TextBox> <br/>
                  <label>CNIC</label> <br/>
                <asp:TextBox ID="CnicTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                  <label>Designation</label> <br/>
                <asp:DropDownList ID="DesignationDdl" style="height: 22px"  CssClass="textboxWidth" runat="server">
                    <asp:ListItem Text="Manager" Value="Manager" ></asp:ListItem>
                    <asp:ListItem Text="Driver" Value="Driver" ></asp:ListItem>
                    <asp:ListItem Text="Security Guard" Value="Security Guard" ></asp:ListItem>
                    <asp:ListItem Text="Doctor" Value="Doctor" ></asp:ListItem>
                    <asp:ListItem Text="Bus Hostess" Value="Bus Hostess" ></asp:ListItem>
                    <asp:ListItem Text="Call Operator" Value="Call Operator" ></asp:ListItem>
                </asp:DropDownList> <br/>
                 <label>Terminal</label> <br/>
                 <asp:DropDownList ID="TerminalsDdl" style="height: 22px" CssClass="textboxWidth" runat="server">
                 </asp:DropDownList> <br/>
                 <label>Phone</label> <br/>
                <asp:TextBox ID="PhoneTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                  <label>Salary</label> <br/>
                <asp:TextBox ID="SalaryTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                 <label>Hiring Date</label> <br/>
                <asp:TextBox ID="HireDateTb" runat="server" readonly="True" style="height: 22px;"></asp:TextBox>
                 <cc2:calendarextender enabledonclient="True" Format="MMM dd, yyyy" defaultview="days" id="HireDateCalender" cssclass=""
                        runat="server" behaviorid="calendarA3" enabled="True" 
                        targetcontrolid="HireDateTb" >
                               </cc2:calendarextender>
                <br/>
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

</asp:Content>
