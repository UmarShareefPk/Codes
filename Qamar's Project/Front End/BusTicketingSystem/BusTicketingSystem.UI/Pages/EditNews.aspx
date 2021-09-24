<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.EditNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <h2> Edit News and Event</h2>
            <div class="">
              <label>Description</label><br/>
                <asp:TextBox ID="NewsTb" runat="server" TextMode="MultiLine" Height="186px" 
                    Width="461px" ></asp:TextBox> <br/>
              <br/><br/>
                <asp:Label runat="server" ForeColor="Red" Visible="False" ID="StatusLabel" Text=""></asp:Label>
                    <br/><br/>
                <asp:Button CssClass="btn" ID="AddBtn" runat="server" Text="Edit" 
                    onclick="AddBtn_Click" />
                    <asp:Button CssClass="btn" ID="CancelBtn" runat="server" Text="Cancel" 
                    onclick="CancelBtn_Click" />
                  
            </div>
</asp:Content>
