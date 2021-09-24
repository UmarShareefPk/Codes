<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="UpdateFare.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.UpdateFare" %>
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
       <h2> Update Fare</h2>
            <div class="">
              <label>Add New Charges</label><br/>
             <asp:TextBox ID="FareTb" runat="server" onkeyup="AllowIntegerOnly(this);" style="height: 22px"></asp:TextBox><br/>
              <br/><br/>
                <asp:Label runat="server" ForeColor="Red" Visible="False" ID="StatusLabel" Text=""></asp:Label>
                    <br/><br/>
                <asp:Button CssClass="btn" ID="AddBtn" runat="server" Text="Update" 
                    onclick="AddBtn_Click" />
                    <asp:Button CssClass="btn" ID="CancelBtn" runat="server" Text="Cancel" 
                    onclick="CancelBtn_Click" />
                  
            </div>
</asp:Content>
