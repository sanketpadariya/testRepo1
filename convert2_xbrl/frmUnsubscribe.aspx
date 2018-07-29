<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmUnsubscribe.aspx.cs" Inherits="convert2_xbrl.frmUnsubscribe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">Unsubscribe</div>

    <div class="un">

        <p>
            If you do not wish to receive any more emails from us,please enter your email ID here:<br />
            <br />            
            <asp:TextBox ID="txtEmail" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="g2" runat="server" ErrorMessage="This field is Required" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="g2" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
        </p>
        <p>
            <br />
            We are sorry to find you are not any longer interested in our newsletter. To help us improve our services, we would be grateful if you could tell us why:
        </p>
        <p>
            <br />
                <asp:TextBox ID="txtMessage" Text="" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhoneNo" ControlToValidate="txtMessage" ForeColor="Red" runat="server" ErrorMessage="This Field is Required"></asp:RequiredFieldValidator>
        </p>
        <p>
            <br />
            <asp:Button ID="btnSubmit" runat="server" CssClass="submitbutton" Text="Unsubscribe" OnClick="btnSubmit_Click" />            
        </p>
    </div>
</asp:Content>
