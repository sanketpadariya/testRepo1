<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmFeedback.aspx.cs" Inherits="convert2_xbrl.frmFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: #fff; float: left;">
        <div class="ht" style="line-height: 20px;">Feedback</div>
        <div class="feed">
            <div class="feedinfor">Please use this form to provide feedback about our services </div>
            <div class="feedback">
                <div class="feedrow">
                    <table style="width: 500px;" cellpadding="5" celspacing="5">
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td style="width: 250px;">Your Email Address</td>
                            <td>Membership #</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEmailID" runat="server" Text="" Width="300px" /></td>
                            <td>
                                <asp:TextBox ID="txtMemberShip" runat="server" Text="" Width="150px" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RadioButtonList ID="rbtSubject" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                                    <asp:ListItem Text="Complain" Value="Complain"></asp:ListItem>
                                    <asp:ListItem Text="Compliment" Value="Compliment"></asp:ListItem>
                                    <asp:ListItem Text="Suggestion" Value="Suggestion"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>Phone No</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPhoneNo" runat="server" Width="150px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Comment</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtComment" Width="300px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submitbutton" OnClick="btnSubmit_Click" /></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
