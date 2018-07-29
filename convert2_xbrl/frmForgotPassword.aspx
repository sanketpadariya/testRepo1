<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmForgotPassword.aspx.cs" Inherits="convert2_xbrl.frmForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">Forgot Password</div>

    <div class="un">

        <div class="contact">
            <table>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td align="right">Enter Email-ID</td>
                    <td>
                        <asp:TextBox ID="txtEmailID" Text="" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmailID" ControlToValidate="txtEmailID" ValidationGroup="g1" ForeColor="Red" runat="server" ErrorMessage="Enter EmailID"></asp:RequiredFieldValidator>&nbsp;
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="g1" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmailID" ForeColor="Red" ErrorMessage="Invalid email address." /></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submitbutton" OnClick="btnSubmit_Click" ValidationGroup="g1" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="submitbutton" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
