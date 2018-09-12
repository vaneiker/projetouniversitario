<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBeneficiariesContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Beneficiaries.UCBeneficiariesContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/Beneficiaries/UCBeneficiaries.ascx" TagPrefix="uc1" TagName="UCBeneficiaries" %>
<li>
    <a href="#item3" lnk='lnk' onclick="setCurrentAccordeon(this, '#hdnLnkAccordeon')"><%=RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiariesLabel.ToUpper() %><span><!--icono--></span></a>
    <ul>
        <li>
            <div class="fondo_blanco">
                <div class="content_fondo_blanco">

                    <div id="mySliderBeneficiariesTabs">
                        <ul id="ulBeneficiariesTabs" class="tabs">
                            <li><a lnk="lnk" href="#resp-tabs-1" onclick="setCurrentAccordeon(this, '#hdnLnkBeneficiariesTab')"><asp:Literal runat="server" ID="ltMainBeneficiaries"></asp:Literal></a></li>
                            <li runat="server" id="liBeneficiaries2"><a lnk="lnk" href="#resp-tabs-2" onclick="setCurrentAccordeon(this, '#hdnLnkBeneficiariesTab')"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ContingentBeneficiaries.ToUpper() %></a></li>
                            <li runat="server" id="liBeneficiaries3"><a lnk="lnk" href="#resp-tabs-3" onclick="setCurrentAccordeon(this, '#hdnLnkBeneficiariesTab')"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AdditionalInsured.ToUpper() %> <%=RESOURCE.UnderWriting.NewBussiness.Resources.MainBenficiariesLabel %></a></li>
                            <li runat="server" id="liBeneficiaries4"><a lnk="lnk" href="#resp-tabs-4" onclick="setCurrentAccordeon(this, '#hdnLnkBeneficiariesTab')"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AdditionalInsured.ToUpper() %> <%=RESOURCE.UnderWriting.NewBussiness.Resources.ContingentBeneficiaries.ToUpper() %></a></li>
                        </ul>
                        <div id="resp-tabs-1">
                            <uc1:UCBeneficiaries runat="server" ID="UCBeneficiaries" />
                            <!--grid_wrap-->
                        </div>
                        <!--tab 1-->
                        <div id="resp-tabs-2">
                            <uc1:UCBeneficiaries runat="server" ID="UCBeneficiaries1" />
                            <!--grid_wrap-->
                        </div>
                        <!--tab2-->
                        <div id="resp-tabs-3">
                            <uc1:UCBeneficiaries runat="server" ID="UCBeneficiaries2" />
                            <!--grid_wrap-->
                        </div>
                        <!--tab2-->
                        <div id="resp-tabs-4">
                            <uc1:UCBeneficiaries runat="server" ID="UCBeneficiaries3" />
                            <!--grid_wrap-->
                        </div>
                        <!--tab2-->
                    </div>
                    <!--resp-tabs-->

                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </li>
    </ul>
</li>
<asp:HiddenField runat="server" ID="hdnLnkBeneficiariesTab" ClientIDMode="Static" />