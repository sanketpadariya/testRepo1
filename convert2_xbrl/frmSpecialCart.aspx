<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmSpecialCart.aspx.cs" Inherits="convert2_xbrl.frmSpecialCart" %>
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
                <td>4000
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
            <tr>
                <td colspan="3">Service Tax (14%) Amount : </td>
                <td>
                    <asp:Label ID="lblTax" runat="server" Text=""></asp:Label>
                    <%--<?php echo $fetch_cart_data['tax1'];?>--%></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">Total Amount : </td>
                <td>
                    <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label>
                    <%--<?php echo $fetch_cart_data['totalamt'];?>--%></td>
                <td></td>
            </tr>
        </table>
        <div style="padding-top: 10px">
            <div style="float: right; padding-top: 7px;">
                <a href="frmSpecialCheckout.aspx" class="submitbutton">Checkout</a>
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
                    <td>&nbsp;&nbsp;= Rs. 4000</td>
                </tr>
            </table>
        </div>        
    </div>
</asp:Content>
