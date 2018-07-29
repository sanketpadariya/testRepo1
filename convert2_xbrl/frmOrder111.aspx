<%@ Page Title="Order" Language="C#" AutoEventWireup="true" CodeBehind="frmOrder111.aspx.cs" Inherits="convert2_xbrl.frmOrder" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head" runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
    <link href="css/style1" rel="stylesheet" type="text/css" media="screen" />
    <link href="css/style2" rel="stylesheet" type="text/css" media="screen" />


    <script type="text/javascript" src="js/jquery-1.7.2.js"></script>
    <script type="text/javascript" lang="javascript" src="js/languages/jquery.validationEngine-en.js"></script>
    <script type="text/javascript" src="js/jquery.validationEngine.js"></script>
    <script type="text/javascript" src="fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="fancybox/jquery.fancybox-1.3.4.pack.js"></script>

    <script type="text/javascript">
        function PrintElem(elem) {
            Popup($(elem).html());
        }
        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=400,width=800');
            mywindow.document.write('<html><head><title>my div</title>');
            /*optional stylesheet*/ //mywindow.document.write('<link rel="stylesheet" href="main.css" type="text/css" />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');
            mywindow.document.close();
            mywindow.print();
            return true;
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="wrapper">
            <div class="main">
                <div class="header">
                    <div class="top">
                        <div class="xbt">Microvista Technologies</div>
                        <div class="member">
                            <asp:Label ID="lblWelcome" runat="server" Text="Welcome" Visible="false"></asp:Label>&nbsp;
                            <span class="style2">
                                <asp:Label ID="lblWelcomeUser" runat="server" Visible="false"></asp:Label></span>

                            <a id="aRegistration" runat="server" title="Registration" href="frmRegistration.aspx">Registration</a>&nbsp;&nbsp;
                            <a id="aCahangePSW" runat="server" title="Change Password" style="display: none;" href="frmChangePassword.aspx">Change Password</a>&nbsp;&nbsp;
                            <a id="aLogin" runat="server" title="Member Login" href="frmLogin.aspx">Member Login</a>&nbsp;&nbsp;
                            <a id="aLogout" runat="server" title="Logout" style="display: none;" href="frmLogout.aspx">Logout</a>

                        </div>
                    </div>
                    <div class="logo">
                        <a href="default.aspx" title="XBRL">
                            <img src="images/logo.png" alt="logo" /></a>
                    </div>
                    <div class="banner">
                        <img src="images/bannar.jpg" alt="banner" title="banner" />
                    </div>
                </div>
                <div class="menu">
                    <ul>
                        <li><a href="frmAbout.aspx" title="About Us">About Us</a></li>
                        <li><a href="#" title="Solution Offerd">Solution Offered</a>
                            <ul>
                                <li><a href="frmSoftware.aspx" title="Software">Software</a></li>
                                <li><a href="frmOutsourcing.aspx" title="Outsourcing">Outsourcing</a></li>
                                <li><a href="frmTraining.aspx" title="Training">Training</a></li>
                            </ul>
                        </li>
                        <li><a href="frmXbrl.aspx" title="Xbrl">Xbrl</a></li>
                        <li><a href="#" title="Resouces">Resouces</a>
                            <ul>
                                <li><a href="frmMandate.aspx" title="Mandate">Mandate</a></li>
                                <li><a href="frmResouces.aspx" title="Circulars">Circulars</a></li>
                                <li><a href="http://70.38.40.185/AA_v3.5.exe" title="Validation Tools Links">Validation Tools Links</a></li>
                                <li><a href="frmForms.aspx" title="XBRL Forms">XBRL Forms</a></li>
                            </ul>
                        </li>
                        <li><a href="frmDownload.aspx" title="Download">Download</a></li>
                        <li style="border: none;"><a href="frmContact.aspx" title="Contact Us" class="last">Contact Us</a></li>
                    </ul>
                </div>

                <div style="padding-left: 20px;">
                    <a onclick="PrintElem('#print_content')" class="lk">
                        <img src="images/print.png" /><span style="width: 750px; padding-left: 2px; float: left; margin-bottom: 10px;">Print</span></a>
                </div>

                <div class="content" id="print_content">
                    <table width="760" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-left: 10px; margin-right: 10px;">
                        <tbody>
                            <tr>
                                <td colspan="3" align="center" valign="top"></td>
                            </tr>


                            <tr>
                                <td colspan="3" align="left" valign="middle" height="40">
                                    <span style="font-size: 18px; color: #002f75; font-family: Arial, Helvetica; font-weight: bold;">Order receipt</span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" height="10"></td>
                            </tr>
                            <tr>
                                <td width="760" align="center">
                                    <table border="0" width="760">
                                        <tbody>
                                            <tr>
                                                <td nowrap="nowrap" valign="top" width="247">
                                                    <span><strong>
                                                        <asp:Label ID="lblAddedDate" runat="server"></asp:Label></strong></span>
                                                </td>
                                                <td valign="top" width="21%"></td>
                                                <td nowrap="nowrap" valign="top" width="197">
                                                    <span><strong>Payment Id #:<asp:Label ID="lblOrderID" runat="server"></asp:Label></strong></span>
                                                    <br />
                                                    <span><strong>Service Tax No.: AASFM9405HSD001</strong></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" height="10"></td>
                                            </tr>
                                            <tr>
                                                <td nowrap="nowrap" valign="top" width="247"></td>
                                                <td valign="top" width="197"></td>
                                                <td nowrap="nowrap" valign="top" width="310">
                                                    <span><strong>Billing Information</strong></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="130" valign="top" nowrap="nowrap" width="247"></td>
                                                <td valign="top" width="197"></td>
                                                <td valign="top" width="310">
                                                    <span>
                                                        <asp:Label ID="lblName" runat="server"></asp:Label></span>
                                                    <br />
                                                    <span>
                                                        <asp:Label ID="lblAddress" runat="server"></asp:Label></span>
                                                    <br />
                                                    <span>
                                                        <asp:Label ID="lblCity" runat="server"></asp:Label></span><br />
                                                    <span>
                                                        <asp:Label ID="lblState" runat="server"></asp:Label></span><br />
                                                    <span>
                                                        <asp:Label ID="lblZip" runat="server"></asp:Label></span><br />
                                                    <span><b>INDIA</b></span><br />
                                                    <span>
                                                        <asp:Label ID="lblPhone" runat="server"></asp:Label></span><br />
                                                    <span>
                                                        <asp:Label ID="lblEmail" runat="server"></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top"></td>
                                                <td valign="top"></td>
                                                <td valign="top"></td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </td>
                                <td width="76"></td>
                            </tr>
                        </tbody>
                    </table>
                    <table cellpadding="0" cellspacing="3" align="center" border="0" width="760">
                        <tbody>
                            <tr>
                                <td colspan="9" align="center">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td width="80" align="left" valign="bottom">
                                    <span style="font-size: 10px; text-decoration: underline; font-style: italic;">Sr</span>
                                </td>
                                <td width="300" align="left" valign="bottom">
                                    <span style="font-size: 10px; text-decoration: underline; font-style: italic;">Name</span>    </td>

                                <td width="200" align="right" valign="bottom">
                                    <span style="font-size: 10px; text-decoration: underline; padding-left: 3px; font-style: italic;">Unit Price</span>
                                </td>
                                <td width="100" align="right" valign="bottom">
                                    <span style="font-size: 10px; text-decoration: underline; padding-left: 3px; font-style: italic;">Qty</span>    </td>

                                <td width="100" align="right" valign="bottom">
                                    <span style="font-size: 10px; text-decoration: underline; padding-left: 3px; font-style: italic;">Total Price</span>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">1
                                </td>
                                <td valign="top">Xbrl Software<br />

                                    1. Cost Audit Report<br />
                                    2. Compliance Report	
                                </td>
                                <td align="right" valign="top">4500
                                </td>
                                <td align="right" valign="top">
                                    <asp:Label ID="lblQuentity" runat="server"></asp:Label>
                                </td>
                                <td align="right" valign="top">
                                    <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                    Rs
                                </td>

                            </tr>
                            <tr>
                                <td colspan="4" align="right" valign="top">Service Tax (12.36%) Amount : </td>
                                <td align="right" valign="top">
                                    <asp:Label ID="lblTax" runat="server"></asp:Label>
                                    Rs
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="right" valign="top">Total Amount : </td>
                                <td align="right" valign="top">
                                    <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                    Rs
                                </td>
                            </tr>
                            <tr>
                                <td colspan="9">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" align="center"></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="footer">
                    <ul>
                        <li><a href="frmDesclaimer.aspx" target="_blank" title="Desclaimer">Desclaimer</a></li>
                        <li><a href="frmPrivacyPolicy.aspx" target="_blank" title="Privacy policy">Privacy policy</a></li>
                        <li><a href="frmCancellation.aspx" target="_blank" title="Cancellation &amp; Refund Policy">Cancellation &amp; Refund Policy</a></li>
                        <li><a href="frmShippingPolicy.aspx" target="_blank" title="Shipping Policy">Shipping Policy </a></li>
                        <li><a href="frmTermsAndCondition.aspx" target="_blank" title="Terms &amp; condition">Terms &amp; condition</a></li>
                    </ul>

                    <a href="http://www.microvistatech.com/" class="m" target="_blank" title="www.microvistatech.com">www.microvistatech.com</a>- All rights reserved &copy; 2012
                </div>
            </div>

            <div style="float: right; margin-top: 11px">
                <a href="http://www.copyscape.com/original-content/">
                    <img src="http://banners.copyscape.com/images/cs-gy-88x31.gif" alt="Protected by Copyscape Original Content Check" title="Protected by Copyscape Plagiarism Checker - Do not copy content from this page." width="88" height="31" border="0" /></a>
            </div>
            <div style="float: right">
                <p>
                    <a href="http://validator.w3.org/check?uri=referer">
                        <img src="http://www.w3.org/Icons/valid-xhtml10" alt="Valid XHTML 1.0 Transitional" height="31" width="88" /></a>
                </p>
            </div>
        </div>
    </form>
</body>
</html>

