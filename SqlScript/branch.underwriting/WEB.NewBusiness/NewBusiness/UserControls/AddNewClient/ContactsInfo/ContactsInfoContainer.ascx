<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactsInfoContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.ContactsInfo.ContactsInfoContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCBackgroundInformation.ascx" TagPrefix="uc1" TagName="WUCBackgroundInformation" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCEmailAddress.ascx" TagPrefix="uc1" TagName="WUCEmailAddress" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCAddress.ascx" TagPrefix="uc1" TagName="WUCAddress" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCPhoneNumber.ascx" TagPrefix="uc1" TagName="WUCPhoneNumber" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCIdentification.ascx" TagPrefix="uc1" TagName="WUCIdentification" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCPersonalInformation.ascx" TagPrefix="uc1" TagName="WUCPersonalInformation" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/ContactsInfo/WUCCompanyInfo.ascx" TagPrefix="uc1" TagName="WUCCompanyInfo" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCPersonalInformationLegal.ascx" TagPrefix="uc1" TagName="WUCPersonalInformationRepLegal" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCIdentificationLegal.ascx" TagPrefix="uc1" TagName="WUCIdentificationLegal" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCEmailAddressLegal.ascx" TagPrefix="uc1" TagName="WUCEmailAddressLegal" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCBackgroundInformationLegal.ascx" TagPrefix="uc1" TagName="WUCBackgroundInformationLegal" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCPhoneNumberLegal.ascx" TagPrefix="uc1" TagName="WUCPhoneNumberLegal" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCAddressLegal.ascx" TagPrefix="uc1" TagName="WUCAddressLegal" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCSaveTab.ascx" TagPrefix="uc1" TagName="WUCSaveTab" %>

<asp:UpdatePanel runat="server" ID="udpOwnerInfoContainer" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:MultiView runat="server" ID="mtvInfoContainer" ActiveViewIndex="0">
            <asp:View runat="server" ID="vOwnerInfo">
                <uc1:WUCPersonalInformation ID="WUCPersonalInformation" runat="server" />
                <uc1:WUCAddress ID="WUCAddress" runat="server" />
                <uc1:WUCBackgroundInformation ID="WUCBackgroundInformation" runat="server" />
                <uc1:WUCPhoneNumber ID="WUCPhoneNumber" runat="server" />
                <uc1:WUCEmailAddress ID="WUCEmailAddress" runat="server" />
                <uc1:WUCIdentification ID="WUCIdentification" runat="server" />
            </asp:View>
            <asp:View runat="server" ID="vCompnayInfo">
                <div id="dvOwnerInformation" style="display: none">
                    <uc1:WUCCompanyInfo runat="server" ID="WUCCompanyInfo" />
                    <div class="titulos_sin_accion" style="width: 100%">
                        <div>
                            <asp:Literal runat="server" ID="Rep_Legal">REPRESENTANTE LEGAL</asp:Literal>
                            <span style="float: right;">
                                <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkAgentLegalIsSameAsInsured" AutoPostBack="true" onclick="BeginRequestHandler()" OnCheckedChanged="chkAgentLegalIsSameAsInsured_CheckedChanged" />
                                <label runat="server" id="AgentLegalisSameAsInsured" class="label">Agent Legal is same as Insured</label>
                            </span>
                        </div>
                    </div>    
                    <uc1:WUCPersonalInformationRepLegal runat="server" ID="WUCPersonalInformationRepLegal" />
                    <uc1:WUCAddressLegal runat="server" ID="WUCAddressLegal" />
                    <uc1:WUCBackgroundInformationLegal ID="WUCBackgroundInformationLegal" runat="server" />
                    <uc1:WUCPhoneNumberLegal runat="server" ID="WUCPhoneNumberRepLegal" />
                    <uc1:WUCEmailAddressLegal runat="server" ID="WUCEmailAddressLegal" />
                    <uc1:WUCIdentificationLegal runat="server" ID="WUCIdentificationLegal" />
                </div>
            </asp:View>
        </asp:MultiView>
        <uc1:WUCSaveTab runat="server" ID="WUCSaveTab" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="chkAgentLegalIsSameAsInsured" />
    </Triggers>
</asp:UpdatePanel>
