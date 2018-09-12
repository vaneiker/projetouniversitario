<%@ Page Title="Contactos" Language="C#" MasterPageFile="~/Business.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.Contact" %>

<%@ Register Src="~/NewBusiness/UserControls/Contact/ContactInformation/ContactContainer.ascx" TagPrefix="uc1" TagName="ContactContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Contact/ContactInformation/WUCContactList.ascx" TagPrefix="uc1" TagName="WUCContactList" %>
<%@ Register Src="~/NewBusiness/UserControls/Contact/ContactInformation/WUCSurvey.ascx" TagPrefix="uc1" TagName="WUCSurvey" %>
<%@ Register Src="~/NewBusiness/UserControls/Contact/CallAndVisits/WUCCallAndVisits.ascx" TagPrefix="uc1" TagName="WUCCallAndVisits" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCIllustrationContainer.ascx" TagPrefix="uc1" TagName="UCIllustrationContainer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/JSPages/Contact/Contact.js"></script>
    <script src="../../Scripts/JSPages/Illustration/Illustration.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>
    <div id="scroll_2" class="st-content-inner">
        <!--CONTENIDO EMPIEZA AQUI-->
        <div class="main clearfix">
            <!--CONTENIDO DERECHA-->
            <div class="management_mc">
                <!--wrapper de las columnas-->
                <div class="grid grid-pad">  
                    <div class="col-1-1">
                        <div class="contenedor_tabs">
                            <ul class="tabs_ttle dvddo_in_3" id="MenuTabs">
                                <li class="active dos_lineas">
                                    <asp:LinkButton runat="server" ID="lnkContactInformation" OnClick="ManageTabs" OnClientClick="return validaTab(this)" ClientIDMode="Static">
                                        <%=RESOURCE.UnderWriting.NewBussiness.Resources.ContactInformationLabel %> 
                                    </asp:LinkButton>
                                </li>
                                <li style="display: none">
                                    <asp:LinkButton runat="server" ID="lnkCallAndVisits" OnClick="ManageTabs" OnClientClick="return validaTab(this)" ClientIDMode="Static"> 
                                        CALLS AND VISITS
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" ID="lnkIllustrations" OnClick="ManageTabs" OnClientClick="return validaTab(this)" ClientIDMode="Static">
                                        <%=RESOURCE.UnderWriting.NewBussiness.Resources.Illustrations %>
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate> 
                                <asp:MultiView runat="server" ID="mtMasterView" ActiveViewIndex="0">
                                    <asp:View runat="server" ID="vContactInfo">
                                        <div class="accordion_tabulado">
                                            <ul class="principal" id="acc1">
                                                <li>
                                                    <a href="#" id="lnkContactList" lnk="lnk" onclick="setCurrentAccordeon(this,'#hfMenuAccordeonContact');">
                                                        <%=RESOURCE.UnderWriting.NewBussiness.Resources.CONTACTS %><span><!--icono--></span></a>
                                                    <ul>
                                                        <li>
                                                            <uc1:WUCContactList runat="server" ID="WUCContactList" />
                                                        </li>
                                                    </ul>
                                                </li>
                                                <!--principal-->

                                                <li id="liContactInformation">
                                                    <a id="lnkcontactinfo" href="#" lnk="lnk" onclick="setCurrentAccordeon(this,'#hfMenuAccordeonContact');">
                                                        <%=RESOURCE.UnderWriting.NewBussiness.Resources.ContactInformationLabel %><span><!--icono--></span></a>
                                                    <uc1:ContactContainer runat="server" ID="ContactContainer" />
                                                </li>
                                                <%--<li id="liSurvey" style="display:none">
                                                    <a href="#item2">SURVEY<span><!--icono--></span></a>
                                                    <uc1:WUCSurvey runat="server" ID="WUCSurvey" />
                                                </li>--%>
                                                <!--principal-->
                                            </ul>
                                        </div>
                                        <!--acordeon_tabulado-->
                                    </asp:View>

                                    <asp:View runat="server" ID="vCallsAndVisits">
                                        <uc1:WUCCallAndVisits runat="server" ID="WUCCallAndVisits" />
                                    </asp:View>

                                    <asp:View runat="server" ID="vIllustration">
                                        <div id="divIllustration">
                                            <uc1:UCIllustrationContainer runat="server" ID="UCIllustrationContainer" />
                                        </div>
                                    </asp:View>

                                </asp:MultiView>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <!--contenedor_tabs-->
                    </div>
                    <!--col-1-1-->
                </div>
                <!--grid grid-pad-->
            </div>
            <!--contendio derecha-->
        </div>
        <!-- /main clearfix -->
    </div>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="udpHiddenFields">
        <ContentTemplate>
            <asp:HiddenField runat="server" ClientIDMode="Static" Value="false" ID="isEdit" />
            <asp:HiddenField runat="server" ClientIDMode="Static" Value="false" ID="hdnShowFormAddNewContact" />
            <asp:HiddenField runat="server" ClientIDMode="Static" Value="lnkContactInformation" ID="hdnCurrentTabContact" />
            <asp:HiddenField runat="server" ID="hdnValidate" Value="true" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hfMenuAccordeonContact" Value="acc1|0" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hdnDateOfBirthBefore" Value="" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

