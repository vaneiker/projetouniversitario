<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCContactInformation.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation.WUCContactInformation" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCPhoneNumber.ascx" TagPrefix="uc1" TagName="WUCPhoneNumber" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCAddress.ascx" TagPrefix="uc1" TagName="WUCAddress" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCEmailAddress.ascx" TagPrefix="uc1" TagName="WUCEmailAddress" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCIdentification.ascx" TagPrefix="uc1" TagName="WUCIdentification" %>
<%@ Register Src="~/NewBusiness/UserControls/Contact/ContactInformation/WUCInsuredPersonalIinformation.ascx" TagPrefix="uc1" TagName="WUCInsuredPersonalIinformation" %>
<%@ Register Src="~/NewBusiness/UserControls/Contact/ContactInformation/WUCOccupationInformation.ascx" TagPrefix="uc1" TagName="WUCOccupationInformation" %>
<%@ Register Src="~/NewBusiness/UserControls/Contact/ContactInformation/WUCAdditionalInformation.ascx" TagPrefix="uc1" TagName="WUCAdditionalInformation" %>
<%@ Register Src="~/NewBusiness/UserControls/Contact/ContactInformation/WUCIllustration.ascx" TagPrefix="uc1" TagName="WUCIllustration" %>
<ul>
    <li class="barra1 overflow_hidden">
        <div class="grupos">
            <div class="float_right">
                <div class="boton_wrapper margin_0 verde">
                    <span class="save"></span>
                    <asp:Button runat="server" CssClass="boton" Text="Save" ID="btnSave" OnClick="btnSave_Click" OnClientClick="return validateForms()" />
                </div>
                <!--boton_wrapper-->
            </div>

            <div class="float_right">
                <div class="boton_wrapper margin_0 azul">
                    <span class="illustration_icon"></span>
                    <asp:Button runat="server" CssClass="boton" Text="Go to illustration" ID="btnGoToillustration" OnClick="btnGoToillustration_Click" />
                </div>
                <!--boton_wrapper-->
            </div>
        </div>
        <!--grupos-->
    </li>
    <li class="fondo_gris seis">
        <div class="row">
            <div class="col-1-3 fix_height">
                <div class="fondo_blanco fix_height">
                    <uc1:WUCInsuredPersonalIinformation runat="server" ID="WUCInsuredPersonalIinformation" />   
                </div>
            </div>
            <uc1:WUCAddress runat="server" ID="WUCAddress" />
            <div class="col-1-3 ">
                <div class="fondo_blanco fix_height">
                    <uc1:WUCOccupationInformation runat="server" ID="WUCOccupationInformation" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-1-3 fix_height">
                <div class="fondo_blanco fix_height">
                    <uc1:WUCPhoneNumber runat="server" ID="WUCPhoneNumber" />
                </div>
            </div>
            <uc1:WUCEmailAddress runat="server" ID="WUCEmailAddress" />
            <div id="dvIdentification" class="fix_height">
                <uc1:WUCIdentification runat="server" ID="WUCIdentification" />
            </div>
            <%------------%>
            <div class="col-1-3 ">
                <asp:Panel class="fondo_blanco fix_height1" Visible="false" runat="server" ID="pnIllustration">
                    <uc1:WUCIllustration runat="server" ID="WUCIllustration" />
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-1-3">
                <div class="fondo_blanco " id="dvParentAdditionalInformation">
                    <div id="dvAdditionalInformation">
                        <uc1:WUCAdditionalInformation runat="server" ID="WUCAdditionalInformation" />
                    </div>
                </div>
            </div>
        </div>
    </li>

</ul>
