<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bottom.ascx.cs" Inherits="WEB.UnderWriting.Dashboard.UserControls.Common.Bottom" %>

<%--<div class="compensation_grid">

      <div style="background-color: #bfbebd; padding: 10px; margin-bottom: 10px; border: 1px #555453 solid;">
        <p>
            <a class="tooltips" href="javascript:ExpandCollapseGrid()" data-tooltip="Hide Other Reports.">
                <img src="../../images/ampliar.png" class="iconleftop" border="0" /></a>
        </p>
        <h2 style="padding-bottom: 0px !important; margin-top: -14px;"><asp:Literal runat="server" ID="Literal15" Text="POLICIES SUMMARY"/></h2>
    </div>

    <div class="limpiador_dos"></div>

    <div>
        <div id="tabespecial">
            <div class="titnewtabla"><asp:Literal runat="server" ID="Literal14" Text="Policy Status:"/></div>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="selectnewtabla">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Pending Policies</asp:ListItem>
                <asp:ListItem>Processing Policies</asp:ListItem>
                <asp:ListItem>Issued Policies</asp:ListItem>
                <asp:ListItem>Pending Changes</asp:ListItem>
                <asp:ListItem>Completed Changes</asp:ListItem>
                <asp:ListItem>Pending Claims</asp:ListItem>
                <asp:ListItem>Pending Requisitions</asp:ListItem>
                <asp:ListItem>For Never Issued</asp:ListItem>
                <asp:ListItem>For Issuance</asp:ListItem>
            </asp:DropDownList>
           <div class="titnewtabla"><asp:Literal runat="server" ID="Literal13" Text="Group By:"/></div>
             <asp:DropDownList ID="DropDownList2" runat="server" CssClass="selectnewtabla">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Country</asp:ListItem>
                <asp:ListItem>Product</asp:ListItem>
                <asp:ListItem>Office</asp:ListItem>
            </asp:DropDownList>

           
            <div class="titnewtabla"><asp:Literal runat="server" ID="Literal12" Text="View By:"/></div>
              <asp:DropDownList ID="DropDownList3" runat="server" CssClass="selectnewtabla">
                <asp:ListItem Value="dashboard.html">Quantity</asp:ListItem>
                <asp:ListItem Value="dashboard_premium.html">Premium</asp:ListItem>
                <asp:ListItem Value="dashboard_premium.html">Insured Amount</asp:ListItem>
            </asp:DropDownList>

         

            <div id="alineacion_select">
                <div class="titnewtabla" ><asp:Literal runat="server" ID="Literal11" Text="Report Type:"/></div>
                  <asp:DropDownList ID="DropDownList4" runat="server" CssClass="selectnewtabla_tres">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Graph</asp:ListItem>
                <asp:ListItem>Table</asp:ListItem>
            </asp:DropDownList>


                <div class="titnewtabla"><asp:Literal runat="server" ID="Literal10" Text="Period:"/></div>
            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="selectnewtabla_tres">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Current Month</asp:ListItem>
                <asp:ListItem>Last 30 days</asp:ListItem>
                 <asp:ListItem>Last 13 Months</asp:ListItem>
                <asp:ListItem>Last 13 Quarters</asp:ListItem>
                <asp:ListItem>Last 5 Years</asp:ListItem>
                <asp:ListItem>Last 10 Years</asp:ListItem>
                <asp:ListItem>Last N Period</asp:ListItem>
                <asp:ListItem>Seasonal Months</asp:ListItem>
                <asp:ListItem>Seasonal Quarters</asp:ListItem>
                <asp:ListItem>All</asp:ListItem>
            </asp:DropDownList>
            </div>
        </div>
    </div>

    <table class="by_last_months">
        <tr class="cabecera_grid_cinco">
            <th colspan="21" style="padding: 0px;">
                <div class="limpiador_dos"></div>

                <div class="titnewtabla"><asp:Literal runat="server" ID="Literal1" Text="Continent:"/></div>

               <asp:DropDownList ID="DropDownList6" runat="server" CssClass="selectnewtabla_dos" Style="margin-top: 5px; Width: 6.9%;" >
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Africa</asp:ListItem>
                <asp:ListItem>America</asp:ListItem>
                 <asp:ListItem>Asia</asp:ListItem>
                <asp:ListItem>Europe</asp:ListItem>
                <asp:ListItem>Oceania</asp:ListItem>
            </asp:DropDownList>

    

                <div class="titnewtabla"> <asp:Literal runat="server" ID="ltRegion" Text="Region:"/></div>
                               <asp:DropDownList ID="DropDownList7" runat="server" CssClass="selectnewtabla_dos" Style="margin-top: 5px; Width: 6.9%;" >
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>North America</asp:ListItem>
                <asp:ListItem>Central America</asp:ListItem>
                 <asp:ListItem>South America</asp:ListItem>
            </asp:DropDownList>


            
                <div class="titnewtabla"><asp:Literal runat="server" ID="Literal2" Text="Country:"/></div>
                 <asp:DropDownList ID="DropDownList8" runat="server" CssClass="selectnewtabla_dos" Style="margin-top: 5px; Width: 6.9%;" >
                <asp:ListItem Value="dashboard.html">Quantity</asp:ListItem>
                <asp:ListItem Value="dashboard_premium.html">Premium</asp:ListItem>
                     <asp:ListItem Value="dashboard_premium.html">Insured Amount</asp:ListItem>
               
            </asp:DropDownList>


                <div class="lineanueve">
                    <img src="../../images/lineadivisorianew.png" />
                </div>

                <div class="titnewtabla" style="margin-top: 13px;"><asp:Literal runat="server" ID="Literal3" Text="Zone:"/></div>
            <asp:DropDownList ID="DropDownList9" runat="server" CssClass="selectnewtabla" Style="width: 6.9%; margin-top: 5px !important;" >
                <asp:ListItem >Select</asp:ListItem>
            </asp:DropDownList>


                <div class="titnewtabla" style="margin-top: 13px;"><asp:Literal runat="server" ID="Literal4" Text="City:"/></div>
                     <asp:DropDownList ID="DropDownList10" runat="server" CssClass="selectnewtabla" Style="width: 6.9%; margin-top: 5px !important;" >
                <asp:ListItem >Select</asp:ListItem>
            </asp:DropDownList>
               

                <div class="lineanueve">
                    <img src="../../images/lineadivisorianew.png" />
                </div>
                <div class="titnewtabla" style="margin-top: 13px;"><asp:Literal runat="server" ID="Literal5" Text="Office:"/></div>
                     <asp:DropDownList ID="DropDownList11" runat="server" CssClass="selectnewtabla" Style="width: 6.9%; margin-top: 5px !important;" >
                <asp:ListItem >Select</asp:ListItem>
            </asp:DropDownList>
         
                <div class="titnewtabla" style="margin-top: 13px;"><asp:Literal runat="server" ID="Literal6" Text="Manager:"/></div>
                     <asp:DropDownList ID="DropDownList12" runat="server" CssClass="selectnewtabla" Style="width: 6.9%; margin-top: 5px !important;" >
                <asp:ListItem >Select</asp:ListItem>
            </asp:DropDownList>
      
                <div class="titnewtabla" style="margin-top: 13px;"><asp:Literal runat="server" ID="Literal7" Text="Sub-GA:"/></div>
                     <asp:DropDownList ID="DropDownList13" runat="server" CssClass="selectnewtabla" Style="width: 6.9%; margin-top: 5px !important;" >
                <asp:ListItem >Select</asp:ListItem>
            </asp:DropDownList>
          
                <div class="titnewtabla" style="margin-top: 13px;"><asp:Literal runat="server" ID="Literal8" Text="Agent:"/></div>
                     <asp:DropDownList ID="DropDownList14" runat="server" CssClass="selectnewtabla" Style="width: 6.9%; margin-top: 5px !important;" >
                <asp:ListItem >Select</asp:ListItem>
            </asp:DropDownList>
            </th>
        </tr>
        <tr class="cabecera_grid_dos" style="border: none; width: 229px;">
            <th style="width: 229px;">
                <div style="float: left; margin-left: 38px;"><strong><asp:Literal runat="server" ID="Literal9" Text="COUNTRY"/></strong></div>
            </th>
            <td>
                <div>
                    <strong>MAY<br>
                        20<strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br>
                        19<strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br>
                        18<strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br>
                        17<strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br>
                        16<strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br>
                        15<strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        14</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        13</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        12</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        11</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        10</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        9</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        8</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        7</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        6</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        5</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        4</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        3</strong>
                </div>
            </td>
            <td>
                <div>
                    <strong>MAY<br />
                        2</strong>
                </div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div><strong>TOTAL</strong></div>
            </td>
        </tr>
        <tr class="cabecera_grid_tres">
            <th>
                <div>
                    <strong>
                        <img src="../../../images/cuadritotdblanco.png" width="14" height="12" class="cuadritoespsmall" />
                    </strong>
                    <span style="padding-left: 14px; float: left;">ECUADOR</span>
                </div>
            </th>
            <td>
                <div>1,132</div>
            </td>
            <td>
                <div>2,500</div>
            </td>
            <td>
                <div>630</div>
            </td>
            <td>
                <div>304</div>
            </td>
            <td>
                <div>1,888</div>
            </td>
            <td>
                <div>1,706</div>
            </td>
            <td>
                <div>1,406</div>
            </td>
            <td>
                <div>1,406</div>
            </td>
            <td>
                <div>562</div>
            </td>
            <td>
                <div>1,434</div>
            </td>
            <td>
                <div>720</div>
            </td>
            <td>
                <div>200</div>
            </td>
            <td>
                <div>504</div>
            </td>
            <td>
                <div>450</div>
            </td>
            <td>
                <div>950</div>
            </td>
            <td>
                <div>1,400</div>
            </td>
            <td>
                <div>2,068</div>
            </td>
            <td>
                <div>1,602</div>
            </td>
            <td>
                <div>1,126</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div>110,000</div>
            </td>
        </tr>
        <tr>
            <th>
                <input name="" type="checkbox" value="" class="checkbox_summary" />
                <div style="text-align: left; margin-left: 35px;">
                    <a href="dashboard_office.html">QUITO 01</a>

                </div>
            </th>
            <td>
                <div>566</div>
            </td>
            <td>
                <div>1,250</div>
            </td>
            <td>
                <div>300</div>
            </td>
            <td>
                <div>315</div>
            </td>
            <td>
                <div>152</div>
            </td>
            <td>
                <div>944</div>
            </td>
            <td>
                <div>853</div>
            </td>
            <td>
                <div>703</div>
            </td>
            <td>
                <div>281</div>
            </td>
            <td>
                <div>171</div>
            </td>
            <td>
                <div>360</div>
            </td>
            <td>
                <div>100</div>
            </td>
            <td>
                <div>252</div>
            </td>
            <td>
                <div>255</div>
            </td>
            <td>
                <div>475</div>
            </td>
            <td>
                <div>700</div>
            </td>
            <td>
                <div>1,034</div>
            </td>
            <td>
                <div>801</div>
            </td>
            <td>
                <div>563</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div>55,000</div>
            </td>
        </tr>
        <tr>
            <th>
                <input name="" type="checkbox" value="" class="checkbox_summary" /><div style="text-align: left; margin-left: 35px;">QUITO 03</div>
            </th>
            <td>
                <div>566</div>
            </td>
            <td>
                <div>1,250</div>
            </td>
            <td>
                <div>300</div>
            </td>
            <td>
                <div>315</div>
            </td>
            <td>
                <div>152</div>
            </td>
            <td>
                <div>944</div>
            </td>
            <td>
                <div>853</div>
            </td>
            <td>
                <div>703</div>
            </td>
            <td>
                <div>281</div>
            </td>
            <td>
                <div>171</div>
            </td>
            <td>
                <div>360</div>
            </td>
            <td>
                <div>100</div>
            </td>
            <td>
                <div>252</div>
            </td>
            <td>
                <div>255</div>
            </td>
            <td>
                <div>475</div>
            </td>
            <td>
                <div>700</div>
            </td>
            <td>
                <div>1,034</div>
            </td>
            <td>
                <div>801</div>
            </td>
            <td>
                <div>563</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div>55,000</div>
            </td>
        </tr>
        <tr>
            <th>
                <input name="" type="checkbox" value="" class="checkbox_summary" /><div style="text-align: left; margin-left: 35px;">GUAYAQUIL 01</div>
            </th>
            <td>
                <div>566</div>
            </td>
            <td>
                <div>1,250</div>
            </td>
            <td>
                <div>300</div>
            </td>
            <td>
                <div>315</div>
            </td>
            <td>
                <div>152</div>
            </td>
            <td>
                <div>944</div>
            </td>
            <td>
                <div>853</div>
            </td>
            <td>
                <div>703</div>
            </td>
            <td>
                <div>281</div>
            </td>
            <td>
                <div>171</div>
            </td>
            <td>
                <div>360</div>
            </td>
            <td>
                <div>100</div>
            </td>
            <td>
                <div>252</div>
            </td>
            <td>
                <div>255</div>
            </td>
            <td>
                <div>475</div>
            </td>
            <td>
                <div>700</div>
            </td>
            <td>
                <div>1,034</div>
            </td>
            <td>
                <div>801</div>
            </td>
            <td>
                <div>563</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div>55,000</div>
            </td>
        </tr>
        <tr>
            <th>
                <input name="" type="checkbox" value="" class="checkbox_summary"><div style="text-align: left; margin-left: 35px;">GUAYAQUIL 02</div>
            </th>
            <td>
                <div>566</div>
            </td>
            <td>
                <div>1,250</div>
            </td>
            <td>
                <div>300</div>
            </td>
            <td>
                <div>315</div>
            </td>
            <td>
                <div>152</div>
            </td>
            <td>
                <div>944</div>
            </td>
            <td>
                <div>853</div>
            </td>
            <td>
                <div>703</div>
            </td>
            <td>
                <div>281</div>
            </td>
            <td>
                <div>171</div>
            </td>
            <td>
                <div>360</div>
            </td>
            <td>
                <div>100</div>
            </td>
            <td>
                <div>252</div>
            </td>
            <td>
                <div>255</div>
            </td>
            <td>
                <div>475</div>
            </td>
            <td>
                <div>700</div>
            </td>
            <td>
                <div>1,034</div>
            </td>
            <td>
                <div>801</div>
            </td>
            <td>
                <div>563</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div>55,000</div>
            </td>
        </tr>
        <tr>
            <th>
                <input name="" type="checkbox" value="" class="checkbox_summary" /><div style="text-align: left; margin-left: 35px;">GUAYAQUIL 03</div>
            </th>
            <td>
                <div>566</div>
            </td>
            <td>
                <div>1,250</div>
            </td>
            <td>
                <div>300</div>
            </td>
            <td>
                <div>315</div>
            </td>
            <td>
                <div>152</div>
            </td>
            <td>
                <div>944</div>
            </td>
            <td>
                <div>853</div>
            </td>
            <td>
                <div>703</div>
            </td>
            <td>
                <div>281</div>
            </td>
            <td>
                <div>171</div>
            </td>
            <td>
                <div>360</div>
            </td>
            <td>
                <div>100</div>
            </td>
            <td>
                <div>252</div>
            </td>
            <td>
                <div>255</div>
            </td>
            <td>
                <div>475</div>
            </td>
            <td>
                <div>700</div>
            </td>
            <td>
                <div>1,034</div>
            </td>
            <td>
                <div>801</div>
            </td>
            <td>
                <div>563</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div>55,000</div>
            </td>
        </tr>
        <tr class="cabecera_grid_dos" style="border: none;">
            <th>
                <img src="../../images/cuadritotd.png" width="14" height="12" class="cuadritoespsmall" style="margin-right: 13px;" /><div style="text-align: left;"><strong>NICARAGUA</strong></div>
            </th>
            <td>
                <div>1,132</div>
            </td>
            <td>
                <div>2,500</div>
            </td>
            <td>
                <div>600</div>
            </td>
            <td>
                <div>630</div>
            </td>
            <td>
                <div>304</div>
            </td>
            <td>
                <div>1,888</div>
            </td>
            <td>
                <div>1,706</div>
            </td>
            <td>
                <div>1,406</div>
            </td>
            <td>
                <div>562</div>
            </td>
            <td>
                <div>1,434</div>
            </td>
            <td>
                <div>720</div>
            </td>
            <td>
                <div>200</div>
            </td>
            <td>
                <div>504</div>
            </td>
            <td>
                <div>450</div>
            </td>
            <td>
                <div>950</div>
            </td>
            <td>
                <div>1,400</div>
            </td>
            <td>
                <div>2,068</div>
            </td>
            <td>
                <div>1,602</div>
            </td>
            <td>
                <div>1,602</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div>110,00</div>
            </td>
        </tr>
        <tr class="cabecera_grid_dos" style="border: none;">
            <th>
                <img src="../../images/cuadritotd.png" width="14" height="12" class="cuadritoespsmall" style="margin-right: 13px;" /><div style="text-align: left;"><strong>VENEZUELA</strong></div>
            </th>
            <td>
                <div>1,132</div>
            </td>
            <td>
                <div>2,500</div>
            </td>
            <td>
                <div>600</div>
            </td>
            <td>
                <div>630</div>
            </td>
            <td>
                <div>304</div>
            </td>
            <td>
                <div>1,888</div>
            </td>
            <td>
                <div>1,706</div>
            </td>
            <td>
                <div>1,406</div>
            </td>
            <td>
                <div>562</div>
            </td>

            <td>
                <div>1,434</div>
            </td>
            <td>
                <div>720</div>
            </td>
            <td>
                <div>200</div>
            </td>
            <td>
                <div>504</div>
            </td>
            <td>
                <div>450</div>
            </td>
            <td>
                <div>950</div>
            </td>
            <td>
                <div>1,400</div>
            </td>
            <td>
                <div>2,068</div>
            </td>
            <td>
                <div>1,602</div>
            </td>
            <td>
                <div>1,602</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div>110,00</div>
            </td>
        </tr>
        <tr class="totals">
            <th>
                <div style="padding-top: 6px; float: left; margin-left: 36px;"><strong>Total</strong></div>
            </th>
            <td>
                <div>3,396</div>
            </td>
            <td>
                <div>7,500</div>
            </td>
            <td>
                <div>900</div>
            </td>
            <td>
                <div>1,890</div>
            </td>
            <td>
                <div>912</div>
            </td>
            <td>
                <div>5,664</div>
            </td>
            <td>
                <div>5,118</div>
            </td>
            <td>
                <div>4,218</div>
            </td>
            <td>
                <div>1,686</div>
            </td>
            <td>
                <div>2,868</div>
            </td>
            <td>
                <div>2,160</div>
            </td>
            <td>
                <div>600</div>
            </td>
            <td>
                <div>1,512</div>
            </td>
            <td>
                <div>1,350</div>
            </td>
            <td>
                <div>2,850</div>
            </td>
            <td>
                <div>4,000</div>
            </td>
            <td>
                <div>6,204</div>
            </td>
            <td>
                <div>4,806</div>
            </td>
            <td>
                <div>2,252</div>
            </td>
            <td style="border-right: 1px #bebdab solid;">
                <div><strong style="text-decoration: underline;">330,000</strong></div>
            </td>
        </tr>
    </table>

</div>--%>
