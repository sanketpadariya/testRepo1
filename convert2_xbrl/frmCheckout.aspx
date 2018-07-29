<%@ Page Title="" Language="C#" MasterPageFile="~/convert2_xbrl.Master" AutoEventWireup="true" CodeBehind="frmCheckout.aspx.cs" Inherits="convert2_xbrl.frmCheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div class="dt">Checkout</div>
            <div class="privacy">

                <table width="480" cellpadding="2" cellspacing="2" border="0">
                    <tr>
                        <th colspan="2"><span class="style2">Billing Address</span></th>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtBillingName" runat="server" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvBillingName" ForeColor="Red" ControlToValidate="txtBillingName" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>Address</td>
                        <td align="left">
                            <asp:TextBox ID="txtBillingAddress" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAddress" ForeColor="Red" ControlToValidate="txtBillingAddress" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>City</td>
                        <td align="left">
                            <asp:TextBox ID="txtBillingCity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCity" ForeColor="Red" ControlToValidate="txtBillingCity" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>State/Province</td>
                        <td align="left">
                            <asp:TextBox ID="txtBilligState" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvBillingState" ForeColor="Red" ControlToValidate="txtBilligState" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>ZIP/Postal Code</td>
                        <td align="left">
                            <asp:TextBox ID="txtBillingPostalCode" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPostalCode" ForeColor="Red" ControlToValidate="txtBillingPostalCode" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="fieldName"><span class="error">*</span>Country</td>
                        <td align="left">

                            <asp:RequiredFieldValidator ID="rfvSelectCountry" runat="server" ErrorMessage="Enter Email" ForeColor="Red" ControlToValidate="BillingCountry"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>Email</td>
                        <td align="left">
                            <asp:TextBox ID="txtEmail" runat="server" Width="170px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>Telephone</td>
                        <td align="left">
                            <asp:TextBox ID="txtBillingPhone" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvBillingPhone" ForeColor="Red" ControlToValidate="txtBillingPhone" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkCopy" runat="server" Checked="false" AutoPostBack="true" OnCheckedChanged="chkCopy_CheckedChanged" Text="Copy" TextAlign="Right" />
                        </td>
                    </tr>
                    <tr>
                        <th colspan="2"><span class="style2">Shipping Address </span></th>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span> Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtShipName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvShipName" ForeColor="Red" ControlToValidate="txtShipName" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>Address</td>
                        <td align="left">
                            <asp:TextBox ID="txtShipAddress" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvShipAddress" ForeColor="Red" ControlToValidate="txtShipAddress" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>City</td>
                        <td align="left">
                            <asp:TextBox ID="txtShipCity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvShipCity" ForeColor="Red" ControlToValidate="txtShipCity" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>State/Province</td>
                        <td align="left">
                            <asp:TextBox ID="txtShipState" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="efvShipState" ForeColor="Red" ControlToValidate="txtShipState" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>ZIP/Postal Code</td>
                        <td align="left">
                            <asp:TextBox ID="txtShipPostalCode" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvShipPostalCode" ForeColor="Red" ControlToValidate="txtShipPostalCode" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="fieldName"><span class="error">*</span>Country</td>
                        <td align="left">

                            <asp:DropDownList ID="ShipingCountry" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="ABW">Aruba</asp:ListItem>
                                <asp:ListItem Value="AFG">Afghanistan</asp:ListItem>
                                <asp:ListItem Value="AGO">Angola</asp:ListItem>
                                <asp:ListItem Value="AIA">Anguilla</asp:ListItem>
                                <asp:ListItem Value="ALA">Åland Islands</asp:ListItem>
                                <asp:ListItem Value="ALB">Albania</asp:ListItem>
                                <asp:ListItem Value="AND">Andorra</asp:ListItem>
                                <asp:ListItem Value="ANT">Netherlands Antilles</asp:ListItem>
                                <asp:ListItem Value="ARE">United Arab Emirates</asp:ListItem>
                                <asp:ListItem Value="ARG">Argentina</asp:ListItem>
                                <asp:ListItem Value="ARM">Armenia</asp:ListItem>
                                <asp:ListItem Value="ASM">American Samoa</asp:ListItem>
                                <asp:ListItem Value="ATA">Antarctica</asp:ListItem>
                                <asp:ListItem Value="ATF">French Southern Territories</asp:ListItem>
                                <asp:ListItem Value="ATG">Antigua and Barbuda</asp:ListItem>
                                <asp:ListItem Value="AUS">Australia</asp:ListItem>
                                <asp:ListItem Value="AUT">Austria</asp:ListItem>
                                <asp:ListItem Value="AZE">Azerbaijan</asp:ListItem>
                                <asp:ListItem Value="BDI">Burundi</asp:ListItem>
                                <asp:ListItem Value="BEL">Belgium</asp:ListItem>
                                <asp:ListItem Value="BEN">Benin</asp:ListItem>
                                <asp:ListItem Value="BFA">Burkina Faso</asp:ListItem>
                                <asp:ListItem Value="BGD">Bangladesh</asp:ListItem>
                                <asp:ListItem Value="BGR">Bulgaria</asp:ListItem>
                                <asp:ListItem Value="BHR">Bahrain</asp:ListItem>
                                <asp:ListItem Value="BHS">Bahamas</asp:ListItem>
                                <asp:ListItem Value="BIH">Bosnia and Herzegovina</asp:ListItem>
                                <asp:ListItem Value="BLM">Saint Barthélemy</asp:ListItem>
                                <asp:ListItem Value="BLR">Belarus</asp:ListItem>
                                <asp:ListItem Value="BLZ">Belize</asp:ListItem>
                                <asp:ListItem Value="BMU">Bermuda</asp:ListItem>
                                <asp:ListItem Value="BOL">Bolivia</asp:ListItem>
                                <asp:ListItem Value="BRA">Brazil</asp:ListItem>
                                <asp:ListItem Value="BRB">Barbados</asp:ListItem>
                                <asp:ListItem Value="BRN">Brunei Darussalam</asp:ListItem>
                                <asp:ListItem Value="BTN">Bhutan</asp:ListItem>
                                <asp:ListItem Value="BVT">Bouvet Island</asp:ListItem>
                                <asp:ListItem Value="BWA">Botswana</asp:ListItem>
                                <asp:ListItem Value="CAF">Central African Republic</asp:ListItem>
                                <asp:ListItem Value="CAN">Canada</asp:ListItem>
                                <asp:ListItem Value="CCK">Cocos (Keeling) Islands</asp:ListItem>
                                <asp:ListItem Value="CHE">Switzerland</asp:ListItem>
                                <asp:ListItem Value="CHL">Chile</asp:ListItem>
                                <asp:ListItem Value="CHN">China</asp:ListItem>
                                <asp:ListItem Value="CIV">Côte d`Ivoire</asp:ListItem>
                                <asp:ListItem Value="CMR">Cameroon</asp:ListItem>
                                <asp:ListItem Value="COD">Congo, the Democratic Republic of the</asp:ListItem>
                                <asp:ListItem Value="COG">Congo</asp:ListItem>
                                <asp:ListItem Value="COK">Cook Islands</asp:ListItem>
                                <asp:ListItem Value="COL">Colombia</asp:ListItem>
                                <asp:ListItem Value="COM">Comoros</asp:ListItem>
                                <asp:ListItem Value="CPV">Cape Verde</asp:ListItem>
                                <asp:ListItem Value="CRI">Costa Rica</asp:ListItem>
                                <asp:ListItem Value="CUB">Cuba</asp:ListItem>
                                <asp:ListItem Value="CXR">Christmas Island</asp:ListItem>
                                <asp:ListItem Value="CYM">Cayman Islands</asp:ListItem>
                                <asp:ListItem Value="CYP">Cyprus</asp:ListItem>
                                <asp:ListItem Value="CZE">Czech Republic</asp:ListItem>
                                <asp:ListItem Value="DEU">Germany</asp:ListItem>
                                <asp:ListItem Value="DJI">Djibouti</asp:ListItem>
                                <asp:ListItem Value="DMA">Dominica</asp:ListItem>
                                <asp:ListItem Value="DNK">Denmark</asp:ListItem>
                                <asp:ListItem Value="DOM">Dominican Republic</asp:ListItem>
                                <asp:ListItem Value="DZA">Algeria</asp:ListItem>
                                <asp:ListItem Value="ECU">Ecuador</asp:ListItem>
                                <asp:ListItem Value="EGY">Egypt</asp:ListItem>
                                <asp:ListItem Value="ERI">Eritrea</asp:ListItem>
                                <asp:ListItem Value="ESH">Western Sahara</asp:ListItem>
                                <asp:ListItem Value="ESP">Spain</asp:ListItem>
                                <asp:ListItem Value="EST">Estonia</asp:ListItem>
                                <asp:ListItem Value="ETH">Ethiopia</asp:ListItem>
                                <asp:ListItem Value="FIN">Finland</asp:ListItem>
                                <asp:ListItem Value="FJI">Fiji</asp:ListItem>
                                <asp:ListItem Value="FLK">Falkland Islands (Malvinas)</asp:ListItem>
                                <asp:ListItem Value="FRA">France</asp:ListItem>
                                <asp:ListItem Value="FRO">Faroe Islands</asp:ListItem>
                                <asp:ListItem Value="FSM">Micronesia, Federated States of</asp:ListItem>
                                <asp:ListItem Value="GAB">Gabon</asp:ListItem>
                                <asp:ListItem Value="GBR">United Kingdom</asp:ListItem>
                                <asp:ListItem Value="GEO">Georgia</asp:ListItem>
                                <asp:ListItem Value="GGY">Guernsey</asp:ListItem>
                                <asp:ListItem Value="GHA">Ghana</asp:ListItem>
                                <asp:ListItem Value="GI">N Guinea</asp:ListItem>
                                <asp:ListItem Value="GIB">Gibraltar</asp:ListItem>
                                <asp:ListItem Value="GLP">Guadeloupe</asp:ListItem>
                                <asp:ListItem Value="GMB">Gambia</asp:ListItem>
                                <asp:ListItem Value="GNB">Guinea-Bissau</asp:ListItem>
                                <asp:ListItem Value="GNQ">Equatorial Guinea</asp:ListItem>
                                <asp:ListItem Value="GRC">Greece</asp:ListItem>
                                <asp:ListItem Value="GRD">Grenada</asp:ListItem>
                                <asp:ListItem Value="GRL">Greenland</asp:ListItem>
                                <asp:ListItem Value="GTM">Guatemala</asp:ListItem>
                                <asp:ListItem Value="GUF">French Guiana</asp:ListItem>
                                <asp:ListItem Value="GUM">Guam</asp:ListItem>
                                <asp:ListItem Value="GUY">Guyana</asp:ListItem>
                                <asp:ListItem Value="HKG">Hong Kong</asp:ListItem>
                                <asp:ListItem Value="HMD">Heard Island and McDonald Islands</asp:ListItem>
                                <asp:ListItem Value="HND">Honduras</asp:ListItem>
                                <asp:ListItem Value="HRV">Croatia</asp:ListItem>
                                <asp:ListItem Value="HTI">Haiti</asp:ListItem>
                                <asp:ListItem Value="HUN">Hungary</asp:ListItem>
                                <asp:ListItem Value="IDN">Indonesia</asp:ListItem>
                                <asp:ListItem Value="IMN">Isle of Man</asp:ListItem>
                                <asp:ListItem Value="IND" Selected="selected">India</asp:ListItem>
                                <asp:ListItem Value="IOT">British Indian Ocean Territory</asp:ListItem>
                                <asp:ListItem Value="IRL">Ireland</asp:ListItem>
                                <asp:ListItem Value="IRN">Iran, Islamic Republic of</asp:ListItem>
                                <asp:ListItem Value="IRQ">Iraq</asp:ListItem>
                                <asp:ListItem Value="ISL">Iceland</asp:ListItem>
                                <asp:ListItem Value="ISR">Israel</asp:ListItem>
                                <asp:ListItem Value="ITA">Italy</asp:ListItem>
                                <asp:ListItem Value="JAM">Jamaica</asp:ListItem>
                                <asp:ListItem Value="JEY">Jersey</asp:ListItem>
                                <asp:ListItem Value="JOR">Jordan</asp:ListItem>
                                <asp:ListItem Value="JPN">Japan</asp:ListItem>
                                <asp:ListItem Value="KAZ">Kazakhstan</asp:ListItem>
                                <asp:ListItem Value="KEN">Kenya</asp:ListItem>
                                <asp:ListItem Value="KGZ">Kyrgyzstan</asp:ListItem>
                                <asp:ListItem Value="KHM">Cambodia</asp:ListItem>
                                <asp:ListItem Value="KIR">Kiribati</asp:ListItem>
                                <asp:ListItem Value="KNA">Saint Kitts and Nevis</asp:ListItem>
                                <asp:ListItem Value="KOR">Korea, Republic of</asp:ListItem>
                                <asp:ListItem Value="KWT">Kuwait</asp:ListItem>
                                <asp:ListItem Value="LAO">Lao People`s Democratic Republic</asp:ListItem>
                                <asp:ListItem Value="LBN">Lebanon</asp:ListItem>
                                <asp:ListItem Value="LBR">Liberia</asp:ListItem>
                                <asp:ListItem Value="LBY">Libyan Arab Jamahiriya</asp:ListItem>
                                <asp:ListItem Value="LCA">Saint Lucia</asp:ListItem>
                                <asp:ListItem Value="LIE">Liechtenstein</asp:ListItem>
                                <asp:ListItem Value="LKA">Sri Lanka</asp:ListItem>
                                <asp:ListItem Value="LSO">Lesotho</asp:ListItem>
                                <asp:ListItem Value="LTU">Lithuania</asp:ListItem>
                                <asp:ListItem Value="LUX">Luxembourg</asp:ListItem>
                                <asp:ListItem Value="LVA">Latvia</asp:ListItem>
                                <asp:ListItem Value="MAC">Macao</asp:ListItem>
                                <asp:ListItem Value="MAF">Saint Martin (French part)</asp:ListItem>
                                <asp:ListItem Value="MAR">Morocco</asp:ListItem>
                                <asp:ListItem Value="MCO">Monaco</asp:ListItem>
                                <asp:ListItem Value="MDA">Moldova</asp:ListItem>
                                <asp:ListItem Value="MDG">Madagascar</asp:ListItem>
                                <asp:ListItem Value="MDV">Maldives</asp:ListItem>
                                <asp:ListItem Value="MEX">Mexico</asp:ListItem>
                                <asp:ListItem Value="MHL">Marshall Islands</asp:ListItem>
                                <asp:ListItem Value="MKD">Macedonia, the former Yugoslav Republic of</asp:ListItem>
                                <asp:ListItem Value="MLI">Mali</asp:ListItem>
                                <asp:ListItem Value="MLT">Malta</asp:ListItem>
                                <asp:ListItem Value="MMR">Myanmar</asp:ListItem>
                                <asp:ListItem Value="MNE">Montenegro</asp:ListItem>
                                <asp:ListItem Value="MNG">Mongolia</asp:ListItem>
                                <asp:ListItem Value="MNP">Northern Mariana Islands</asp:ListItem>
                                <asp:ListItem Value="MOZ">Mozambique</asp:ListItem>
                                <asp:ListItem Value="MRT">Mauritania</asp:ListItem>
                                <asp:ListItem Value="MSR">Montserrat</asp:ListItem>
                                <asp:ListItem Value="MTQ">Martinique</asp:ListItem>
                                <asp:ListItem Value="MUS">Mauritius</asp:ListItem>
                                <asp:ListItem Value="MWI">Malawi</asp:ListItem>
                                <asp:ListItem Value="MYS">Malaysia</asp:ListItem>
                                <asp:ListItem Value="MYT">Mayotte</asp:ListItem>
                                <asp:ListItem Value="NAM">Namibia</asp:ListItem>
                                <asp:ListItem Value="NCL">New Caledonia</asp:ListItem>
                                <asp:ListItem Value="NER">Niger</asp:ListItem>
                                <asp:ListItem Value="NFK">Norfolk Island</asp:ListItem>
                                <asp:ListItem Value="NGA">Nigeria</asp:ListItem>
                                <asp:ListItem Value="NIC">Nicaragua</asp:ListItem>
                                <asp:ListItem Value="NO">R Norway</asp:ListItem>
                                <asp:ListItem Value="NIU">Niue</asp:ListItem>
                                <asp:ListItem Value="NLD">Netherlands</asp:ListItem>
                                <asp:ListItem Value="NPL">Nepal</asp:ListItem>
                                <asp:ListItem Value="NRU">Nauru</asp:ListItem>
                                <asp:ListItem Value="NZL">New Zealand</asp:ListItem>
                                <asp:ListItem Value="OMN">Oman</asp:ListItem>
                                <asp:ListItem Value="PAK">Pakistan</asp:ListItem>
                                <asp:ListItem Value="PAN">Panama</asp:ListItem>
                                <asp:ListItem Value="PCN">Pitcairn</asp:ListItem>
                                <asp:ListItem Value="PER">Peru</asp:ListItem>
                                <asp:ListItem Value="PHL">Philippines</asp:ListItem>
                                <asp:ListItem Value="PLW">Palau</asp:ListItem>
                                <asp:ListItem Value="PNG">Papua New Guinea</asp:ListItem>
                                <asp:ListItem Value="POL">Poland</asp:ListItem>
                                <asp:ListItem Value="PRI">Puerto Rico</asp:ListItem>
                                <asp:ListItem Value="PRK">Korea, Democratic People`s Republic of</asp:ListItem>
                                <asp:ListItem Value="PRT">Portugal</asp:ListItem>
                                <asp:ListItem Value="PRY">Paraguay</asp:ListItem>
                                <asp:ListItem Value="PSE">Palestinian Territory, Occupied</asp:ListItem>
                                <asp:ListItem Value="PYF">French Polynesia</asp:ListItem>
                                <asp:ListItem Value="QAT">Qatar</asp:ListItem>
                                <asp:ListItem Value="REU">Réunion</asp:ListItem>
                                <asp:ListItem Value="ROU">Romania</asp:ListItem>
                                <asp:ListItem Value="RUS">Russian Federation</asp:ListItem>
                                <asp:ListItem Value="RWA">Rwanda</asp:ListItem>
                                <asp:ListItem Value="SAU">Saudi Arabia</asp:ListItem>
                                <asp:ListItem Value="SDN">Sudan</asp:ListItem>
                                <asp:ListItem Value="SEN">Senegal</asp:ListItem>
                                <asp:ListItem Value="SGP">Singapore</asp:ListItem>
                                <asp:ListItem Value="SGS">South Georgia and the South Sandwich Islands</asp:ListItem>
                                <asp:ListItem Value="SHN">Saint Helena</asp:ListItem>
                                <asp:ListItem Value="SJM">Svalbard and Jan Mayen</asp:ListItem>
                                <asp:ListItem Value="SLB">Solomon Islands</asp:ListItem>
                                <asp:ListItem Value="SLE">Sierra Leone</asp:ListItem>
                                <asp:ListItem Value="SLV">El Salvador</asp:ListItem>
                                <asp:ListItem Value="SMR">San Marino</asp:ListItem>
                                <asp:ListItem Value="SOM">Somalia</asp:ListItem>
                                <asp:ListItem Value="SPM">Saint Pierre and Miquelon</asp:ListItem>
                                <asp:ListItem Value="SRB">Serbia</asp:ListItem>
                                <asp:ListItem Value="STP">Sao Tome and Principe</asp:ListItem>
                                <asp:ListItem Value="SUR">Suriname</asp:ListItem>
                                <asp:ListItem Value="SVK">Slovakia</asp:ListItem>
                                <asp:ListItem Value="SVN">Slovenia</asp:ListItem>
                                <asp:ListItem Value="SWE">Sweden</asp:ListItem>
                                <asp:ListItem Value="SWZ">Swaziland</asp:ListItem>
                                <asp:ListItem Value="SYC">Seychelles</asp:ListItem>
                                <asp:ListItem Value="SYR">Syrian Arab Republic</asp:ListItem>
                                <asp:ListItem Value="TCA">Turks and Caicos Islands</asp:ListItem>
                                <asp:ListItem Value="TCD">Chad</asp:ListItem>
                                <asp:ListItem Value="TGO">Togo</asp:ListItem>
                                <asp:ListItem Value="THA">Thailand</asp:ListItem>
                                <asp:ListItem Value="TJK">Tajikistan</asp:ListItem>
                                <asp:ListItem Value="TKL">Tokelau</asp:ListItem>
                                <asp:ListItem Value="TKM">Turkmenistan</asp:ListItem>
                                <asp:ListItem Value="TLS">Timor-Leste</asp:ListItem>
                                <asp:ListItem Value="TON">Tonga</asp:ListItem>
                                <asp:ListItem Value="TTO">Trinidad and Tobago</asp:ListItem>
                                <asp:ListItem Value="TUN">Tunisia</asp:ListItem>
                                <asp:ListItem Value="TUR">Turkey</asp:ListItem>
                                <asp:ListItem Value="TUV">Tuvalu</asp:ListItem>
                                <asp:ListItem Value="TWN">Taiwan, Province of China</asp:ListItem>
                                <asp:ListItem Value="TZA">Tanzania, United Republic of</asp:ListItem>
                                <asp:ListItem Value="UGA">Uganda</asp:ListItem>
                                <asp:ListItem Value="UKR">Ukraine</asp:ListItem>
                                <asp:ListItem Value="UMI">United States Minor Outlying Islands</asp:ListItem>
                                <asp:ListItem Value="URY">Uruguay</asp:ListItem>
                                <asp:ListItem Value="USA">United States</asp:ListItem>
                                <asp:ListItem Value="UZB">Uzbekistan</asp:ListItem>
                                <asp:ListItem Value="VAT">Holy See (Vatican City State)</asp:ListItem>
                                <asp:ListItem Value="VCT">Saint Vincent and the Grenadines</asp:ListItem>
                                <asp:ListItem Value="VEN">Venezuela</asp:ListItem>
                                <asp:ListItem Value="VGB">Virgin Islands, British</asp:ListItem>
                                <asp:ListItem Value="VIR">Virgin Islands, U.S.</asp:ListItem>
                                <asp:ListItem Value="VNM">Viet Nam</asp:ListItem>
                                <asp:ListItem Value="VUT">Vanuatu</asp:ListItem>
                                <asp:ListItem Value="WLF">Wallis and Futuna</asp:ListItem>
                                <asp:ListItem Value="WSM">Samoa</asp:ListItem>
                                <asp:ListItem Value="YEM">Yemen</asp:ListItem>
                                <asp:ListItem Value="ZAF">South Africa</asp:ListItem>
                                <asp:ListItem Value="ZMB">Zambia</asp:ListItem>
                                <asp:ListItem Value="ZWE">Zimbabwe</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCountry" ForeColor="Red" ControlToValidate="ShipingCountry" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="fieldName"><span class="error">*</span>Telephone</td>
                        <td align="left">
                            <asp:TextBox ID="txtShipPhone" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvShipPhone" ForeColor="Red" ControlToValidate="txtShipPhone" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="">
                        <td>Referred By
                        </td>
                        <td>
                            <asp:TextBox ID="txtReferedBy" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvReferedBy" ForeColor="Red" ControlToValidate="txtReferedBy" runat="server" ErrorMessage=" This field is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="TandC" runat="server" TextAlign="Right" Checked="false" />
                            <a href="frmTermsAndCondition.aspx" target="_blank" style="text-decoration: underline">Accept Terms and Condition</a>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top" align="center" colspan="2">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="submitbutton" />
                            &nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="submitbutton" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                    <tr>
                        <th height="30" colspan="2"><span class="style2">*DENOTES </span><a href="https://support.ebs.in/index.php?_m=knowledgebase&_a=viewarticle&kbarticleid=183&nav=0,5,2" target="_blank" class="style2"><em>mandatory fields</em></a></th>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
