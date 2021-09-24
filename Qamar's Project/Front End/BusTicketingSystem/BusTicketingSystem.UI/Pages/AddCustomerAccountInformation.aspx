<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomerAccountInformation.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AddCustomerAccountInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h2> Add Bus</h2>
            <div class="">
              <label>Credit Card Number</label><br/>
                <asp:TextBox ID="CardNumberTb" runat="server"></asp:TextBox> <br/>
                 
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
