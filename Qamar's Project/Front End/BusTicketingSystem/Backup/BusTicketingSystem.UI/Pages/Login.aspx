<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <h2>
        Log In
    </h2>
    <p>
        <a href="AddNewCustomer.aspx"> Register</a> as a customer
    </p>
            
            <div class="accountInfo">
              <label>Username</label><br/>
                <asp:TextBox ID="usernameTB" runat="server"></asp:TextBox> <br/>
                  <label>Password</label> <br/>
                <asp:TextBox ID="passwordTB" TextMode="Password" runat="server"  style="height: 22px;width: 299px;"></asp:TextBox>
                <br/><br/>
                  <asp:Label runat="server" ForeColor="Red" Visible="False"  ID="StatusLabel" Text=""></asp:Label>
                  <br/>
                <asp:Button CssClass="btn" ID="LoginBtn" runat="server" Text="Login" 
                    onclick="LoginBtn_Click" />
            </div>
   <a href="ChangePassword.aspx">Change Password</a> &nbsp;&nbsp;&nbsp;&nbsp;
   <a href="ForgotPassword.aspx">Forgot Password</a>

</asp:Content>
