<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2> Change Password</h2>
            <div class="accountInfo">
                <label>Username</label> <br/>
                <asp:TextBox ID="UsernameTb" runat="server" style="height: 22px"></asp:TextBox><br/>
                  <label>Password</label> <br/>
                <asp:TextBox ID="PasswordTb" runat="server" TextMode="Password" style="height: 22px; width: 299px;"></asp:TextBox><br/>
                 <label>New Password</label> <br/>
                <asp:TextBox ID="NewPasswordTb" runat="server" TextMode="Password" style="height: 22px; width: 299px;"></asp:TextBox><br/>
                <label>Confirm Password</label> <br/>
                <asp:TextBox ID="ConfirmPasswordTb" runat="server" TextMode="Password" style="height: 22px; width: 299px"></asp:TextBox><br/>
                <br/><br/>
                <asp:Label runat="server" ForeColor="Red" Visible="False" ID="StatusLabel" Text=""></asp:Label>
                    <br/><br/>
                <asp:Button CssClass="btn" ID="AddBtn" runat="server" Text="Save" 
                    onclick="AddBtn_Click" />
                    <asp:Button CssClass="btn" ID="CancelBtn" runat="server" Text="Cancel" 
                    onclick="CancelBtn_Click" />
                 
            </div>
</asp:Content>
