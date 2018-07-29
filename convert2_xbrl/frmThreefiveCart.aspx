<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmThreefiveCart.aspx.cs" Inherits="convert2_xbrl.frmThreefiveCart" %>
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
                <td>3500
                </td>
                <td>
                    <asp:TextBox ID="txtQuentity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuentity" ForeColor="Red" ControlToValidate="txtQuentity" runat="server" ErrorMessage="This field is Required"></asp:RequiredFieldValidator>
                    <%--<input type="text" name="quantity" value="<?php echo $fetch_cart_data['quantity'];?>" class="validate[required,number]" size="2" /></td>--%>
                </td>
                <td>
                    <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                    <%--<?php echo $fetch_cart_data['amount'];?>--%>    	
                </td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" CssClass="submitbutton" />
                    <%--<a href="delete_cart.php?id=<?php echo $fetch_cart_data['id'];?>">Delete</a>--%>
                </td>
            </tr>

        </table>
        <div style="padding-top: 10px">
            <div style="float: right; padding-top: 7px;">
                <a href="frmThreeFiveCheckout.aspx" class="submitbutton">Checkout</a>
            </div>
            <div style="float: left">
                <asp:Button ID="btnUpdateCart" runat="server" Text="Update Cart" OnClick="btnUpdateCart_Click" CssClass="submitbutton" />
                <%--<input id="cart_submit" type="submit" name="cart_submit" value="Update Cart" class="submitbutton" />--%>
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
                    <td>&nbsp;&nbsp;= Rs. 3500</td>
                </tr>

            </table>
        </div>
</asp:Content>
