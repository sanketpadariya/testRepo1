<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmSubmitTicket.aspx.cs" Inherits="convert2_xbrl.frmSubmitTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">Submit Ticket</div>

    <div class="cont">
        <div class="contact">
            <table style="width: 480px;" cellpadding="5" celspacing="5">
                <tr>
                    <td>Name :</td>
                    <td>
                        <asp:TextBox ID="txtName" Text="" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" ForeColor="Red" ControlToValidate="txtName" runat="server" ErrorMessage="This field is Required"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>E-Mail Address :</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="g2" runat="server" ErrorMessage="Enter Email" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="g2" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                    </td>
                </tr>
                <tr>
                    <td>Phone No :</td>
                    <td>
                        <asp:TextBox ID="txtPhoneNo" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>Query Title :</td>
                    <td>
                        <asp:TextBox ID="txtQueryTitle" Text="" runat="server"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="rfvQueryTitle" ValidationGroup="g2" runat="server" ForeColor="Red" ControlToValidate="txtQueryTitle" ErrorMessage="This field is Required"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="txtDescription" Text="" TextMode="MultiLine" runat="server"></asp:TextBox>                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" CssClass="submitbutton" />
                    </td>
                </tr>
           </table>           
        </div>
    </div>
</asp:Content>
