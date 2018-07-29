<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmRegistration.aspx.cs"
    Inherits="convert2_xbrl.frmRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">Registration</div>

    <div class="un">

        <div class="contact">

            <table style="width: 500px;" cellpadding="5" celspacing="5">
                <tr>
                    <td style="width:110px;">First Name</td>
                    <td>
                        <asp:TextBox ID="txtFname" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rvfUserName" ValidationGroup="g2" runat="server" ForeColor="Red" ControlToValidate="txtFname" ErrorMessage="Enter First Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">Last Name</td>
                    <td>
                        <asp:TextBox ID="txtLname" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rfvLname" ValidationGroup="g2" runat="server" ForeColor="Red" ControlToValidate="txtLname" ErrorMessage="Enter Last Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">User Name</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rfvUserName" ValidationGroup="g2" runat="server" ForeColor="Red" ControlToValidate="txtLname" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">E-Mail Address</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="g2" runat="server" ErrorMessage="Enter Email" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="g2" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">Phone No</td>
                    <td>
                        <asp:TextBox ID="txtPhoneNo" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rffvPhoneNO" ValidationGroup="g2" runat="server" ForeColor="Red" ControlToValidate="txtPhoneNo" ErrorMessage="Enter Phone No"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">City</td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rfvCity" ValidationGroup="g2" runat="server" ForeColor="Red" ControlToValidate="txtCity" ErrorMessage="Enter City Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">Company Name</td>
                    <td>
                        <asp:TextBox ID="txtFirm" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rfvFirm" ValidationGroup="g2" ForeColor="Red" ControlToValidate="txtFirm" runat="server" ErrorMessage="Enter Firm"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Text="" TextMode="Password" />
                        <asp:RegularExpressionValidator ID="RegExp1" Display="Dynamic" runat="server" ValidationGroup="g2"
                            ErrorMessage="Enter between 6 to 20 characters" ControlToValidate="txtPassword"
                            ForeColor="Red" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,20}$" />
                        <asp:RequiredFieldValidator ID="rfvPassword" Display="Dynamic" ValidationGroup="g2" ForeColor="Red" ControlToValidate="txtPassword" runat="server" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">Conirm-Password</td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" Text="" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" Display="Dynamic" ValidationGroup="g2" ControlToValidate="txtConfirmPassword" ForeColor="Red" runat="server" ErrorMessage="Re-Type Password"></asp:RequiredFieldValidator>
                        &nbsp;<asp:CompareValidator ID="CompareValidator1" Display="Dynamic" ValidationGroup="g2" ErrorMessage="Passwords don't match." ForeColor="Red" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnRegistration" ValidationGroup="g2" Text="Submit" CssClass="submitbutton" runat="server" OnClick="btnRegistration_Click" Height="34px" Width="76px" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
