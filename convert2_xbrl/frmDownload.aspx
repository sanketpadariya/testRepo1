<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmDownload.aspx.cs" Inherits="convert2_xbrl.frmDownload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="privacy">
        <p style="float: right; padding-top: 10px;">            
            <asp:Button ID="btnFinanceCart" runat="server" OnClick="btnFinanceCart_Click" CssClass="submitbutton" Text="Finance Cart" />
            <asp:Button ID="btnCostingCart" runat="server" OnClick="btnCostingCart_Click" CssClass="submitbutton" Text="Buy Costing Now" /></p>                    
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p style="float: left;">
            We welcome any queries related to XBRL you may wish to ask as well as any feedback you may have on this Please <a href="frmContact.aspx">contact us</a>.
        </p>
        <p class="title">Download</p>
        <hr />
        <div class="title">Annual Report (Revised schedule VI)</div>

        <p>
            Annual Report  XBRL- Template + Manual(Help&nbsp;File)<br />
            <a href="excelsoftware/Annual_Report_2014.zip" class="lk">Download</a>
            ( MS Excel 2007, 2010 and 2013) 
        </p>
        <div class="title">Compliance Report</div>
        <p>
            Compliance Report  XBRL- Template + Manual(Help&nbsp;File)
							<a href="excelsoftware/C2X  Compliance Report Ver 3.0.zip" class="lk">Download</a>
            ( MS Excel 2007, 2010 and 2013) 
        </p>
        <div class="title">Cost Audit Report</div>
        <p>
            Cost Audit Report  XBRL - Template + Manual(Help&nbsp;File)
							<a href="excelsoftware/C2X  Cost Audit Report Ver 3.0.zip" class="lk">Download</a>
            ( MS Excel 2007, 2010 and 2013) 
        </p>
      
        <hr />
        <br />
    </div>
</asp:Content>
