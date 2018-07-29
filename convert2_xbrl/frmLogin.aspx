<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="convert2_xbrl.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">Login</div>

    <div class="un">
        <span class="error"></span>
        <div class="contact">

            <div class="row">
                <div class="login_row1">
                    <div class="row3">Username / Email :</div>
                    <div class="row3">Password :</div>

                    <div class="row3"></div>
                </div>

                <div class="row2">
                    <div class="row4">
                        <label for="username"></label>
                        <asp:TextBox ID="txtUserName" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="rfvUserName" ValidationGroup="g1" ControlToValidate="txtUserName" runat="server" ErrorMessage="Enter User Name" ForeColor="Red"></asp:RequiredFieldValidator>

                        <%--<input name="username" type="text" id="username" value="" size="30" class="validate[required]" />--%>
                    </div>

                    <div class="row4">
                        <label for="password"></label>
                        <asp:TextBox ID="txtPWD" runat="server" Text="" TextMode="Password" />                        
                        <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtPWD" ValidationGroup="g1" ForeColor="Red" runat="server" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                        <%--<input name="password" type="password" id="password" value="" size="30" class="validate[required]" />--%>
                    </div>
                    
                    <div class="register_row7">
                        <asp:Button ID="btnSubmit" runat="server" Text="Log In" CssClass="submitbutton" ValidationGroup="g1" OnClick="btnSubmit_Click" />
                        <%--<input name="submit1" type="submit" value="Login" class="submitbutton" />--%>
                    </div>
                </div>

                <div style="width: 300px; float: left; margin-top: 10px;">
                    <a id="a1" href="frmRegistration.aspx" runat="server">Registration</a> &nbsp;&nbsp;<a id="anc" href="frmForgotPassword.aspx" runat="server">Forgott Password</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
