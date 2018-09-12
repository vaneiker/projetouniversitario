<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPolicyDetails.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.History.UCPolicyDetails" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="accordion_tabulado">
    <ul class="principal" id="acc2">
        <li>
            <a href="#item1" id="current">
                <div class="rect">
                </div>
                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.GeneralInformation.ToUpper() %><span><!--icono--></span>
            </a>
            <ul>
                <li>
                    <div class="fondo_blanco">
                        <div class="content_fondo_blanco bg_verde">
                            <div class="g_information">
                                <div style="max-width: 213px; height: 213px; background-color: #FFF; border: #b0b0b0 solid 1px; margin: 0 auto;">
                                    <%--<div class="foto_id"></div>--%>
                                    <div id="TabbedPanels2" class="TabbedPanels">
                                        <ul class="TabbedPanelsTabGroup bdr0">
                                            <div class="con_previewBTN2">
                                                <asp:Button ID="UCPersonalDataPreviewBtn" CssClass="previewBTN" runat="server" Text="Preview" OnClick="UCPersonalDataPreviewBtn_Click" />
                                            </div>
                                        </ul>
                                        <div class="TabbedPanelsContentGroup">
                                            <div class="TabbedPanelsContent TabbedPanelsContentVisible" style="display: block;">
                                                <PdfViewer:PdfViewer CssClass="imgid" ID="pdfViewerPersonalData" runat="server" ClientIDMode="Static" ShowScrollbars="true" Width="212" Height="150"
                                                    ShowToolbarMode="Show" ShowNavigationPanel="false">
                                                    <PdfViewerPreferences />
                                                </PdfViewer:PdfViewer>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <div class="grupos de_2">
                                        <div>
                                            <label class="label"><%= System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(RESOURCE.UnderWriting.ConfirmationCall.Resources.OwnerName.ToLower()) %></label>
                                            <asp:TextBox ID="tbOwner" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Policy  %> #</label>
                                            <asp:TextBox ID="tbPolicy" runat="server" ReadOnly="True" ViewStateMode="Enabled"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label class="label"><%= System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(RESOURCE.UnderWriting.ConfirmationCall.Resources.InsuredName.ToLower())  %></label>
                                            <asp:TextBox ID="tbInsuredNade" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label class="label"><%= System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(RESOURCE.UnderWriting.ConfirmationCall.Resources.PlanName.ToLower())  %></label>
                                            <asp:TextBox ID="tbPlanName" runat="server" ReadOnly="True" Style="margin-right: 0px"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AdditionalInsured2  %></label>
                                            <asp:TextBox ID="tbAdditionalIInsured" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.InvestmentProfile  %></label>
                                            <asp:TextBox ID="tbInvesment" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PensionerName  %> </label>
                                            <asp:TextBox ID="tbPensioner" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div>
                                            <table>
                                                <td width="50%">
                                                    <div>
                                                        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PolicyStatust  %></label>
                                                        <asp:TextBox ID="tbPolicyStatus" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div>
                                                        <label class="label"><%= System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(RESOURCE.UnderWriting.ConfirmationCall.Resources.PlanType.ToLower())  %></label>
                                                        <asp:TextBox ID="tbPlanType" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </table>
                                        </div>
                                    </div>
                                    <!--grupos-->
                                </div>
                            </div>
                            <!--g_information-->
                             <div class="grupos de_4 no_overflow">
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.OwnerAge  %></label>
                                    <asp:TextBox ID="tbOwnerAge" runat="server" ReadOnly="True" Style="width: 94% !important;"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.InsuredAge  %></label>
                                    <asp:TextBox ID="tbAgeInsure" runat="server" ReadOnly="True" Style="width: 90% !important;"></asp:TextBox>
                                </div>

                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AgeAditionalInsured  %></label>
                                    <asp:TextBox ID="tbAgeInsureAdd" runat="server" ReadOnly="True" Style="width: 90% !important;"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"></label>
                                    <asp:TextBox ID="txtMessageAgeInsure" Visible="True" Style="color: red; width: 96% !important; margin-left: 5px !important;" runat="server" ReadOnly="True" Text=""></asp:TextBox>
                                </div>

                            </div>

                            <br clear="all" />

                            <div class="grupos de_3 no_overflow">
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Office  %></label>
                                    <asp:TextBox ID="tbOffice" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AgentName  %></label>
                                    <asp:TextBox ID="tbAgents" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Country  %></label>
                                    <asp:TextBox ID="tbCountry" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <!--grupos-->

                        </div>
                        <!--content_fondo_blanco-->
                    </div>
                    <!--fondo_blanco-->
                </li>
            </ul>
        </li>
        <!--principal-->

        <li>
            <a href="#item2" id="">
                <div class="rect">
                </div>
                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PaymentDetails.ToUpper()   %> <span>
                    <!--icono-->
                </span>
            </a>
            <ul>
                <li>
                    <div class="fondo_blanco">
                        <div class="content_fondo_blanco bg_verde">

                            <div class="grupos de_3">
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Annual   %></label>
                                    <asp:TextBox ID="tbAbual" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Minimum   %></label>
                                    <asp:TextBox ID="tbMinimum" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Target   %></label>
                                    <asp:TextBox ID="tbTrget" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.InitialContribution %></label>
                                    <asp:TextBox ID="tbInitialContribution" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.FuturePayment   %></label>
                                    <asp:TextBox ID="tbFuturePayment" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Frecuency   %></label>
                                    <asp:TextBox ID="tbFrecuncy" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ModalPremium   %></label>
                                    <asp:TextBox ID="tbModalPremium" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Currency  %></label>
                                    <asp:TextBox ID="tbCurrecny" runat="server" ReadOnly="True"></asp:TextBox>

                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MethodPayment  %></label>
                                    <asp:TextBox ID="tbMethodPayment" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MethodDetail  %></label>
                                    <asp:TextBox ID="tbMethoDetail" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ExpirationDate  %></label>
                                    <asp:TextBox ID="tbExpiration" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PaymentsStatus  %></label>
                                    <asp:TextBox ID="tbPaymentEstatus" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <!--grupos-->

                        </div>
                        <!--content_fondo_blanco-->
                    </div>
                    <!--fondo_blanco-->
                </li>
            </ul>
        </li>
        <!--principal-->

        <li>
            <a href="#item3" id="">
                <div class="rect">
                </div>
                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AmountPeriods.ToUpper()  %><span><!--icono--></span>
            </a>
            <ul>
                <li>
                    <div class="fondo_blanco">
                        <div class="content_fondo_blanco bg_gris">

                            <dx:ASPxGridView EnablePagingGestures="False" ID="GrdAmountsAndPeriods" runat="server" ClientIDMode="Static"
                                DataSourceID="dsAmountsAndPeriods"
                                optionsloadingpanel-enabled="false"
                                SettingsLoadingPanel-Mode="Disabled"
                                AutoGenerateColumns="False"
                                class="datagrid">
                                <Settings ShowHeaderFilterButton="false" />
                                <ClientSideEvents BeginCallback="BeginRequestHandler" EndCallback="EndRequestHandler"></ClientSideEvents>
                                <Columns>
                                    <dx:GridViewDataColumn Caption="Insured Period" FieldName="InsuredPeriod" PropertiesEditType="TextBox">
                                        <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Sum Assured" FieldName="InsuredAmount" PropertiesEditType="TextBox">
                                        <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Differral Period" FieldName="DefermentPeriod" PropertiesEditType="TextBox">
                                        <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Contribution Period" FieldName="ContributionPeriod" PropertiesEditType="TextBox">
                                        <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Ret./Educ Period" FieldName="RetirementPeriod" PropertiesEditType="TextBox">
                                        <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Ret./Educ Amount" FieldName="RetirementAmount" PropertiesEditType="TextBox">
                                        <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="ROP Amount" FieldName="RopAmount" PropertiesEditType="TextBox">
                                        <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <SettingsPager AlwaysShowPager="true" PageSize="4" NumericButtonCount="3" />
                                <SettingsLoadingPanel Mode="Disabled" />
                                <SettingsPopup>
                                    <HeaderFilter Height="200" />
                                </SettingsPopup>
                            </dx:ASPxGridView>
                            <asp:ObjectDataSource ID="dsAmountsAndPeriods" runat="server" SelectMethod="GetAmountsAndPeriods"
                                TypeName="WEB.ConfirmationCall.UserControls.History.UCPolicyDetails" OnSelecting="dsAmountsAndPeriods_Selecting"></asp:ObjectDataSource>
                            <!--grid_wrap-->

                        </div>
                        <!--content_fondo_blanco-->
                    </div>
                    <!--fondo_blanco-->
                </li>
            </ul>
        </li>
        <!--principal-->

        <li>
            <a href="#item4" id="">
                <div class="rect">
                </div>
                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Riders.ToUpper()  %> <span>
                    <!--icono-->
                </span>
            </a>
            <ul>
                <li>
                    <div class="fondo_blanco">
                        <div class="content_fondo_blanco bg_gris">

                            <div class="grid_wrap">
                                <table>
                                    <thead class="headgrid azules">
                                        <tr>
                                            <td class="c1 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.RiderType  %></div>
                                            </td>
                                            <td class="c2 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.BenefitAmount  %></div>
                                            </td>
                                            <td class="c3 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.StartDate  %></div>
                                            </td>
                                            <td class="c4 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ExpireDate  %></div>
                                            </td>
                                            <td class="c5 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.NoYears  %></div>
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody class="datagrid">
                                        <asp:Repeater runat="server" ID="gvRiders">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="c1">
                                                        <div><%#Eval("RyderTypeDesc")%></div>
                                                    </td>
                                                    <td class="c2">
                                                        <div><%#Eval("BeneficiaryAmount", "{0:c}")%></div>
                                                    </td>
                                                    <td class="c3">
                                                        <div><%#Eval("EffectiveDate", "{0:dd/MM/yyyy}")%></div>
                                                    </td>
                                                    <td class="c4">
                                                        <div><%#Eval("ExpireDate", "{0:dd/MM/yyyy}")%></div>
                                                    </td>
                                                    <td class="c51">
                                                        <div><%#Eval("NumberOfYear")%></div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            <!--grid_wrap-->

                        </div>
                        <!--content_fondo_blanco-->
                    </div>
                    <!--fondo_blanco-->
                </li>
            </ul>
        </li>
        <!--principal-->
        <li>
            <a href="#item5" id="">
                <div class="rect">
                </div>
                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AdditionalFamilyInsurance.ToUpper()  %> <span>
                    <!--icono-->
                </span>
            </a>
            <ul>
                <li>
                    <div class="fondo_blanco">
                        <div class="content_fondo_blanco bg_gris">

                            <div class="grid_wrap">
                                <table>
                                    <thead class="headgrid azules">
                                        <tr>
                                            <td class="c1 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.FirstName  %></div>
                                            </td>
                                            <td class="c2 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MiddleName  %></div>
                                            </td>
                                            <td class="c3 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.FirstLastName  %></div>
                                            </td>
                                            <td class="c4 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.SecondLastName   %></div>
                                            </td>
                                            <td class="c5 padding-right">
                                                <div><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.DateofBirth   %></div>
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody class="datagrid">
                                        <asp:Repeater runat="server" ID="rptAdditionalFamilyInsurance">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="c1">
                                                        <div><%#Eval("FirstName")%></div>
                                                    </td>
                                                    <td class="c2">
                                                        <div><%#Eval("MiddleName")%></div>
                                                    </td>
                                                    <td class="c3">
                                                        <div><%#Eval("FirstLastName")%></div>
                                                    </td>
                                                    <td class="c4">
                                                        <div><%#Eval("SecondLastName")%></div>
                                                    </td>
                                                    <td class="c5">
                                                        <div><%# string.Format("{0:d}", Eval("Dob"))%></div>

                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            <!--grid_wrap-->

                        </div>
                        <!--content_fondo_blanco-->
                    </div>
                    <!--fondo_blanco-->
                </li>
            </ul>
        </li>
        <!--principal-->

        <li>
            <a href="#item5" id="">
                <div class="rect">
                </div>
                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Beneficiaries.ToUpper()  %><span><!--icono--></span>
            </a>
            <ul>
                <li>
                    <div class="fondo_blanco">
                        <div class="content_fondo_blanco bg_gris">
                            <dx:ASPxGridView runat="server" ID="gvBeneficiaries">
                                <Columns>
                                    <dx:GridViewDataColumn Caption="TYPE BENEFICIARY" FieldName="BeneficiaryTypeDesc"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="BENEFICIARY NAME" FieldName="FirstName"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="BENEFICIARY LASTNAME" FieldName="FirstLastName"></dx:GridViewDataColumn>
                                    <dx:GridViewDataTextColumn Caption="BENEFIT PERCENTAGE" FieldName="BenefitsPercent">
                                        <PropertiesTextEdit DisplayFormatString="{0:0}%" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Caption="RELATION" FieldName="RelationshipDesc"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="BIRTHDATE" FieldName="Dob">
                                        <DataItemTemplate>
                                             <div><%# string.Format("{0:d}", Eval("Dob"))%></div>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </div>
                    </div>
                    <!--fondo_blanco-->
                </li>
            </ul>
        </li>
        <!--principal-->

        <li>
            <a href="#item6" id="">
                <div class="rect">
                </div>
                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.OtherProducts.ToUpper()  %> <span>
                    <!--icono-->
                </span>
            </a>
            <ul>
                <li>
                    <div class="fondo_blanco">
                        <div class="content_fondo_blanco bg_gris">

                            <div class="grid_wrap">
                                <dx:ASPxGridView EnablePagingGestures="False" ID="grdOtherProduct" runat="server" ClientIDMode="Static"
                                    DataSourceID="dsOtherProduct"
                                    optionsloadingpanel-enabled="false"
                                    SettingsLoadingPanel-Mode="Disabled"
                                    AutoGenerateColumns="False" CssClass="gvResult">
                                    <Settings ShowHeaderFilterButton="false" />
                                    <ClientSideEvents BeginCallback="BeginRequestHandler" EndCallback="EndRequestHandler"></ClientSideEvents>
                                    <Columns>
                                        <dx:GridViewDataColumn Caption="Date" FieldName="ProductDate">
                                            <HeaderStyle CssClass="c2"></HeaderStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Product" FieldName="PolicyNo">
                                            <HeaderStyle CssClass="c3"></HeaderStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Product Type" FieldName="ProductDesc">
                                            <HeaderStyle CssClass="c4"></HeaderStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Status" FieldName="PolicyStatusDesc">
                                            <HeaderStyle CssClass="c5"></HeaderStyle>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <SettingsPager AlwaysShowPager="true" PageSize="4" NumericButtonCount="3" />
                                    <SettingsLoadingPanel Mode="Disabled" />
                                    <SettingsPopup>
                                        <HeaderFilter Height="200" />
                                    </SettingsPopup>
                                </dx:ASPxGridView>
                                <asp:ObjectDataSource ID="dsOtherProduct" runat="server" SelectMethod="GetOtherProduct"
                                    TypeName="WEB.ConfirmationCall.UserControls.History.UCPolicyDetails" OnSelecting="dsOtherProduct_Selecting"></asp:ObjectDataSource>
                            </div>
                            <!--grid_wrap-->

                        </div>
                        <!--content_fondo_blanco-->
                    </div>
                    <!--fondo_blanco-->
                </li>
            </ul>
        </li>
        <!--principal-->
    </ul>
</div>
<!--acordeon_tabulado-->
