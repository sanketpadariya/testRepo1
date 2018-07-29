<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmCart.aspx.cs" Inherits="convert2_xbrl.frmCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dt">Cart</div>
    <div class="un">

        <table width="100%" style="border: 1px solid #AAAAAA;" class="payment_table">
            <thead>
                <tr>
                    <th align="left" width="800">Name
                    </th>
                    <th align="left" width="100">Rate
                    </th>
                    <th align="left" width="10">Quantity
                    </th>
                    <th align="left" width="100">Amount
                    </th>
                    <th align="left" width="100">Action
                    </th>
                </tr>
            </thead>
            <tr>
                <td>Xbrl Software<br />
                    1. Cost Audit Report<br />
                    2. Compliance Report	    
                </td>
                <td>4500
                </td>
                <td>
                    <asp:TextBox ID="txtQuentity" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuentity" ForeColor="Red" ControlToValidate="txtQuentity" runat="server" ErrorMessage="This Field is Required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnDeleteCart" runat="server" CssClass="submitbutton" Text="Delete" OnClick="btnDeleteCart_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">Service Tax (14%) Amount : </td>
                <td>
                    <asp:Label ID="lblTax" runat="server" Text=""></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3" align="right">Total Amount : </td>
                <td>
                    <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label>
                </td>
                <td></td>
            </tr>
        </table>
        <div style="padding-top: 10px">
            <div style="float: right; padding-top: 7px;">
                <a href="frmCheckout.aspx" class="submitbutton">Checkout</a>
            </div>
            <div style="float: left">
                <asp:Button ID="btnUpdateCart" runat="server" Text="Update Cart" CssClass="submitbutton" OnClick="btnUpdateCart_Click" />
            </div>

        </div>
        <div style="clear: both"></div>
        <div style="padding-top: 10px">
            <table>
                <tr>
                    <td colspan="2">
                        <h4>Product Pricing</h4>
                    </td>
                </tr>
                <tr>
                    <td>1. Quantity 1</td>
                    <td>&nbsp;&nbsp;= Rs. 4500</td>
                </tr>
                <tr>
                    <td>2. Quantity 2</td>
                    <td>&nbsp;&nbsp;= Rs. 7500</td>
                </tr>
                <tr>
                    <td>3. Quantity 3 or more </td>
                    <td>&nbsp;&nbsp;= Rs. 3000(per qty.)</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
