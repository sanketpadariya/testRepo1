<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmThreeCart.aspx.cs" Inherits="convert2_xbrl.frmThreeCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dt">Cart</div>
    <div class="un">

        <table width="100%" style="border: 1px solid #AAAAAA;" class="payment_table">
            <thead>
                <tr>
                    <td align="left" width="200px">Name
                    </td>
                    <td align="left" width="">Rate
                    </td>
                    <td align="left" width="">Quantity
                    </td>
                    <td align="left" width="">Amount
                    </td>
                    <td align="left" width="">Action
                    </td>
                </tr>
            </thead>
            <tr>
                <td>Xbrl Software<br />
                    1. Cost Audit Report<br />
                    2. Compliance Report	
    
                </td>
                <td>3000
                </td>
                <td>
                    <asp:TextBox ID="txtQuentity" runat="server" Width="200px">
                    </asp:TextBox><asp:RequiredFieldValidator ID="rvfQuentity" ControlToValidate="txtQuentity" ForeColor="Red" runat="server" ErrorMessage="This field is Required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3" align="right">Service Tax (14%) Amount : </td>
                <td>
                    <asp:Label ID="lblText" runat="server" Text=""></asp:Label></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3" align="right">Total Amount : </td>
                <td>
                    <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label></td>
                <td></td>
            </tr>
        </table>
        <div style="padding-top: 10px">
            <div style="float: right; padding-top: 7px;">
                <a href="frmThreeCheckout.aspx" class="submitbutton">Checkout</a>
            </div>
            <div style="float: left">
                <asp:Button ID="btnCartSubmit" runat="server" CssClass="submitbutton" Text="Update Cart" OnClick="btnCartSubmit_Click" />
            </div>
        </div>
        <div style="clear: both"></div>
        <div style="padding-top: 10px">
        </div>
    </div>
</asp:Content>
