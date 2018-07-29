<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmXbrl.aspx.cs" Inherits="convert2_xbrl.frmXbrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht">XBRL</div>

    <div class="xbrl">

        <strong>1)</strong> <a href="#what_is_xbrl">What is XBRL? / Overview of XBRL Concept</a><br />
        <strong>2)</strong> <a href="#how_it_works">How does it work?</a><br />
        <strong>3)</strong> <a href="#why_xbrl">Why XBRL</a><br />
        <strong>4)</strong> <a href="#advantage_of_xbrl">Advantages of XBRL</a><br />
        <strong>5)</strong> <a href="#facts_xbrl">Mythes and facts about XBRL</a><br />

        <a id="what_is_xbrl" name="what_is_xbrl"></a>
        <p><strong>What is XBRL</strong></p>

        <p>XBRL (Extensible Business Reporting Language) is an electronic format for Preparing, Analyzing and communicating, the financial data and other information, using XML technology.</p>

        <a id="how_it_works" name="how_it_works"></a>
        <p><strong>How does it work?</strong></p>

        <p>Simply put, XBRL uses latest technology to simplify business reporting and enhance its utility by defining a standard for presentation of financial statements. XBRL tags, known as taxonomy, is nothing but a mechanism for describing, naming and classifying items of business information in a specified document. In technical parlance, XBRL taxonomies are tag-lists which represent data structures and their internal relationships.</p>

        <p>Using the taxonomy prescribed by the regulators, companies need to map their reports, and generate a valid XBRL instance document. The process of mapping means matching the concepts as reported by the company to the corresponding element in the taxonomy. In addition to assigning XBRL tag from taxonomy, information like unit of measurement, period of data, scale of reporting etc., needs to be included in the instance document, which is the final document of the report.</p>
        <a href="#">Top of Page</a>
        <a id="why_xbrl" name="why_xbrl"></a>
        <p><strong>Why XBRL</strong></p>

        <p>XBRL is an application of XML to business information and uses tags or structure to describe the data, making it immediately reusable, interactive and intelligent. It is also “extensible” so it can be customized for unique situations and reporting concepts.</p>

        <p>XBRL uses tags to describe and identify each item of data in an electronic document. The tags allow computer programs to sort through data and analyze relationships quickly and generate output in various formats. Because the tags are standardized, analysis can be conducted across multiple documents from multiple sources, even if the text in the documents is written in different languages. XBRL data is more robust, accurate, and transparent than data in financial statements that appears in legacy electronic and paper reports.</p>

        <p><strong>For example:</strong> in an XBRL financial report, each piece of data (both numbers and text) is given a unique ID, based on standardized lists of accounting terms, or taxonomies. For example, a data point might be linked to the accounting terms "INR", "Net Profit", "2nd Quarter" "2010-11", means, Net Profile in Indian Rupees for the 2nd quarter of Assessment Year 2010-11. Thus the data entered by all companies in this particular tag will have the same meaning and will have the same denominator.</p>

        <p>Once data is tagged, it is computer-readable. It can be identified, verified, extracted, and reused. The tags remains connected to the data, so even when the data is used in other XBRL software, it can still be understood in its original context.</p>

        <p>XBRL tags both numbers and textual information, which means not only balance statements, but information such as statement of principals and even footprints, appendices, and updates, is accounted for, to aid in internal audits and external research and analysis.</p>

        <a href="#">Top of Page</a>
        <a id="advantage_of_xbrl" name="advantage_of_xbrl"></a>
        <p><strong>Advantages of XBRL</strong></p>

        <p>
            -XBRL benefits comparability by helping to identify data which is genuinely alike and distinguishing information which is not comparable.<br />

            -Improve effectiveness and efficiency of key business reporting process<br />
            -Improve quality and accuracy of data obtained from companies<br />
            -No Rekeying :Accelerate the analysis of financial data<br />
            -Instant User Access
        </p>

        <a href="#">Top of Page</a>
        <a id="facts_xbrl" name="facts_xbrl"></a>
        <p><strong>Mythes and facts about XBRL</strong></p>

        <p>XBRL is NOT an accounting standard, nor does it alter the same, although it can be used to represent reporting concepts and provide an explicit link from a reported concept to the relevant accounting standard.</p>
        <p>XBRL is NOT a software program although it can be used to enable the seamless exchange of information between disparate software applications.</p>

        <a href="#">Top of Page</a>

    </div>
</asp:Content>
