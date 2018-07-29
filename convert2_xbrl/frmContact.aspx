<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmContact.aspx.cs" Inherits="convert2_xbrl.frmContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">Contact Us</div>

    <div class="cont">

        <div class="infor">
            403, Ashirwad Complex,<br />

            B/h Sardar Patel Seva Samaj,<br />

            Nr Mithakhali Six Road,<br />

            Ahmedabad 380 006

							<p>ph: 079-26460445</p>
            <p>ph: 1800 233 0445</p>
            <p>e-mail: support@microvistatech.com</p>
        </div>

        <table style="width: 500px;" cellpadding="5" celspacing="5">
            <tr>
                <td style="width: 100px;">Frist Name :</td>
                <td>
                    <asp:TextBox ID="txtFName" Text="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFname" ControlToValidate="txtFName" ForeColor="Red" runat="server" ErrorMessage="This Field is Required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Last Name :</td>
                <td>
                    <asp:TextBox ID="txtLName" Text="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLName" ControlToValidate="txtLName" ForeColor="Red" runat="server" ErrorMessage="This Field is Required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>e-Mail Address :</td>
                <td>
                    <asp:TextBox ID="txtEmail" Text="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" ForeColor="Red" runat="server" ErrorMessage="This Field is Required"></asp:RequiredFieldValidator>&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="g2" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                </td>
            </tr>
            <tr>
                <td>Phone Number :</td>
                <td>
                    <asp:TextBox ID="txtPhoneNo" Text="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPhoneNo" ControlToValidate="txtPhoneNo" ForeColor="Red" runat="server" ErrorMessage="This Field is Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Comment :</td>
                <td>
                    <asp:TextBox ID="txtComment" Text="" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <img id="imgCaptcha" src="frmCaptcha.aspx" alt="" title="captcha" /></td>
                <td>
                    <asp:TextBox ID="txtCapcha" Text="" runat="server"></asp:TextBox></td>
            </tr>            
            <tr>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="submitbutton" Text="Submit" OnClick="btnSubmit_Click" /></td>
            </tr>
        </table>

    </div>
</asp:Content>
