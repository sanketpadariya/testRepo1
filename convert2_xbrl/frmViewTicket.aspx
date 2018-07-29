<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmViewTicket.aspx.cs" Inherits="convert2_xbrl.frmViewTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">Submit Ticket</div>

    <div class="soft">       
        <table cellspacing="0" width="380" border="1px">
            <tr>
                <td>Name</td>
                <td>Number</td>
                <td>Query Title</td>
                <td>Status</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:Label ID="lblNumber" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:Label ID="lblQueryTitle" runat="server" Text=""></asp:Label></td>
                <td class="td-header-left" style="color: blue">Open</td>
            </tr>
        </table>
    </div>
</asp:Content>
