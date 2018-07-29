<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmFinanceCart.aspx.cs" Inherits="convert2_xbrl.frmFinanceCart" %>
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
                    1. Annual Report (Revised schedule VI)		
    
                </td>
                <td>4500
                </td>
                <td>
                    <asp:TextBox ID="txtQuentity" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvfQuentity" ControlToValidate="txtQuentity" ForeColor="Red" runat="server" ErrorMessage="This field is Required"></asp:RequiredFieldValidator>
                    <%--<input type="text" name="quantity" value="<%--<?php echo $fetch_cart_data['quantity'];?>" class="validate[required,number]" size="2" />--%>
                </td>
                <td>
                    <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label></td>
                    <%--<td><?php echo $fetch_cart_data['amount'];?></td>--%>
                <td>
                    <asp:Button ID="btnDelete" runat="server" CssClass="submitbutton" Text="Delete" OnClick="btnDelete_Click" />
                    <%--<a href="delete_cart.php?id=<%--<?php echo $fetch_cart_data['id'];?>--">Delete</a>--%>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">Service Tax (14%) Amount : </td>
                <td>
                    <asp:Label ID="lblText" runat="server" Text=""></asp:Label></td>
                <%--<td><?php echo $fetch_cart_data['tax1'];?></td>--%>
                <td></td>
            </tr>
            <tr>
                <td colspan="3" align="right">Total Amount : </td>
                <%--<td><?php echo $fetch_cart_data['totalamt'];?></td>--%>
                <td>
                    <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <div style="padding-top: 10px">
            <div style="float: right; padding-top: 7px;">
                <a href="frmFinanceCheckout.aspx" class="submitbutton">Checkout</a>
            </div>
            <div style="float: left">
                <asp:Button ID="btnCartSubmit" runat="server" CssClass="submitbutton" Text="Submit Cart" OnClick="btnCartSubmit_Click" />
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
