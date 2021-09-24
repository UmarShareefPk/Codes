<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewCustomer.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AddNewCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2> Customer Registration </h2>
            <div class="accountInfo">
              <label>Name</label><br/>
                <asp:TextBox ID="NameTb" runat="server"></asp:TextBox> <br/>
                  <label>CNIC</label> <br/>
                <asp:TextBox ID="CnicTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                 <label>Email</label> <br/>
                <asp:TextBox ID="EmailTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                 <label>Phone</label> <br/>
                <asp:TextBox ID="PhoneTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                  <label>Username</label> <br/>
                <asp:TextBox ID="UsernameTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                  <label>Password</label> <br/>
                <asp:TextBox ID="PasswordTb" runat="server" TextMode="Password" style="height: 22px; width: 299px;"></asp:TextBox><br/>
                <label>Confirm Password</label> <br/>
                <asp:TextBox ID="ConfirmPasswordTb" runat="server" TextMode="Password" style="height: 22px; width: 299px"></asp:TextBox><br/>
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
