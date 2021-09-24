<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewBus.aspx.cs" Inherits="BusTicketingSystem.UI.Pages.AddNewBus" %>
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
    
       <h2> Add Bus</h2>
            <div class="">
              <label>Number</label><br/>
                <asp:TextBox ID="NumberTb" runat="server"></asp:TextBox> <br/>
                  <label>Bus Type</label> <br/>
                <asp:DropDownList ID="TypeDdl" style="height: 22px" AutoPostBack="True"
                    onselectedindexchanged="TypeDdl_SelectedIndexChanged" CssClass="textboxWidth" runat="server">
                    <asp:ListItem Text="Normal" Value="1" ></asp:ListItem>
                    <asp:ListItem Text="VIP" Value="2" ></asp:ListItem>
                     <asp:ListItem Text="Cargo" Value="3" ></asp:ListItem>
                </asp:DropDownList> <br/>
                 <label>Terminal</label> <br/>
                 <asp:DropDownList ID="TerminalsDdl" style="height: 22px" 
                    CssClass="textboxWidth" runat="server"  AutoPostBack="True"
                    onselectedindexchanged="TerminalsDdl_SelectedIndexChanged">
                 </asp:DropDownList> <br/>
                 <label>Total Seats</label> <br/>
                <asp:TextBox ID="TotalSeatsTb" runat="server" onkeyup="AllowIntegerOnly(this);" style="height: 22px"></asp:TextBox><br/>
               <label>Total Weight in KG</label> <br/>
                <asp:TextBox ID="TotalWeightTb" runat="server" onkeyup="AllowIntegerOnly(this);" style="height: 22px"></asp:TextBox><br/>
              <label>Driver</label> <br/>
                 <asp:DropDownList ID="DriverDdl" style="height: 22px" CssClass="textboxWidth" runat="server">
                 </asp:DropDownList> <br/>
                 <label>Doctor</label> <br/>
                 <asp:DropDownList ID="DoctorDdl" style="height: 22px" CssClass="textboxWidth" runat="server">
                 </asp:DropDownList> <br/>
                 <label>Security Guard</label> <br/>
                 <asp:DropDownList ID="SecurityGuardDdl" style="height: 22px" CssClass="textboxWidth" runat="server">
                 </asp:DropDownList> <br/>
                 <label>Bus Hostess</label> <br/>
                 <asp:DropDownList ID="BusHostessDdl" style="height: 22px" CssClass="textboxWidth" runat="server">
                 </asp:DropDownList> <br/>
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
