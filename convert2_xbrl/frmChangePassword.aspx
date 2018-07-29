<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmChangePassword.aspx.cs" Inherits="convert2_xbrl.frmChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">Change Password</div>

    <div class="un">       
        <div class="contact">

            <div class="row">
                <table style="width:500px;" cellpadding="5" celspacing="5">
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width:150px;">Current Password :</td>
                        <td>
                            <asp:TextBox ID="txtCurrentPSW" runat="server" Text="" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="g1" ForeColor="Red" ControlToValidate="txtCurrentPSW" runat="server" ErrorMessage="Enter Password"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width:150px;">New Password :</td>
                        <td>
                            <asp:TextBox ID="txtNewPSW" runat="server" Text="" TextMode="Password" />
                            <asp:RegularExpressionValidator ID="RegExp1" Display="Dynamic" runat="server" ValidationGroup="g1"
                            ErrorMessage="Enter 6 to 20 characters" ControlToValidate="txtNewPSW"
                            ForeColor="Red" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,20}$" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ValidationGroup="g1" ForeColor="Red" ControlToValidate="txtNewPSW" runat="server" ErrorMessage="Enter Password"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width:135px;">Confirm New Password :</td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" Text="" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ValidationGroup="g1" ControlToValidate="txtConfirmPassword" ForeColor="Red" runat="server" ErrorMessage="Re-Type Password"></asp:RequiredFieldValidator>
                            &nbsp;<asp:CompareValidator ID="CompareValidator2" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Passwords don't match." ForeColor="Red" ControlToCompare="txtNewPSW"
                                ControlToValidate="txtConfirmPassword" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left:120px;"><asp:Button ID="btnSubmit" runat="server" ValidationGroup="g1" Text="Submit" OnClick="btnSubmit_Click" /></td>
                    </tr>
                </table>              
            </div>
        </div>
    </div>
</asp:Content>
