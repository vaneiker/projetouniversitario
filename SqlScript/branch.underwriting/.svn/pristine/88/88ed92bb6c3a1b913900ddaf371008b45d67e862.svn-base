<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequirementContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Requirements.UCRequirementContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/Requirements/UCRequirement.ascx" TagPrefix="uc1" TagName="UCRequirement" %>
<li>
    <a href="#item4" lnk='lnk' onclick="setCurrentAccordeon(this, '#hdnLnkAccordeon')"><%=RESOURCE.UnderWriting.NewBussiness.Resources.RequirementsLabel %><span><!--icono-->
    </span></a>
    <ul>
        <li>
            <div class="fondo_blanco">
                <div class="content_fondo_blanco">
                    <div id="mySliderRequirementTabs">
                        <ul class="tabs">
                            <li class="requirementprimaryinsured"><a href="#resp-tabs-B1"><%=RESOURCE.UnderWriting.NewBussiness.Resources.RequirementsLabel %> <%=RESOURCE.UnderWriting.NewBussiness.Resources.INSURED %> No.1</a></li>
                            <li class="requirementotherinsured"><a href="#resp-tabs-B2"><%=RESOURCE.UnderWriting.NewBussiness.Resources.RequirementsLabel %> <%=RESOURCE.UnderWriting.NewBussiness.Resources.INSURED %> No.2</a></li>
                        </ul>
                        <div id="resp-tabs-B1" class="requirementprimaryinsured">
                            <uc1:UCRequirement runat="server" ID="UCRequirement" />
                            <!--grid_wrap-->
                        </div>
                        <!--tab 1-->
                        <div id="resp-tabs-B2" class="requirementotherinsured">
                            <uc1:UCRequirement runat="server" ID="UCRequirement1" />
                            <!--grid_wrap-->
                        </div>
                        <asp:HiddenField runat="server" ID="hdnHasOtherInsured" Value="false" />
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
