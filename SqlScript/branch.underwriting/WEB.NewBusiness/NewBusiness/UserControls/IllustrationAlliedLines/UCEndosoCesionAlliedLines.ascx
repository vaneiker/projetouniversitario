<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEndosoCesionAlliedLines.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.UCEndosoCesionAlliedLines" %>
<asp:UpdatePanel runat="server" ID="udpEndoso">
    <ContentTemplate>
        <div id="dvEndosoCesion">
            <div style="height: 15px;"></div>
            <div class="">
                <div class="label_plus_input par sl" id="dvAutoCompleteEndorsementBen">
                    <span>Seleccione Beneficiario</span>
                    <asp:TextBox runat="server" ID="txtSelectBenficiary" placeholder="Escriba el nombre del beneficiario que desea buscar" ClientIDMode="Static" validation="Required"></asp:TextBox>                                      
                </div>
                <div class="label_plus_input par">
                    <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.EndosoBeneficiario %></span>
                    <asp:TextBox runat="server" ID="txtBeneficiario" ClientIDMode="Static" Style="text-align: left;" Enabled="false" validation="Required"></asp:TextBox>
                </div>
                <div class="label_plus_input par">
                    <span><%= WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.RNC) %></span>
                    <asp:TextBox runat="server" ID="txtRNC" ClientIDMode="Static" Style="text-align: left;" RncNumber="RncNumber" Enabled="false" validateLength="9,11" validation="Required"></asp:TextBox>
                </div>
                <div class="label_plus_input par">
                    <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.AmountLabel %></span>
                    <asp:TextBox runat="server" ID="txtMonto" ClientIDMode="Static" decimal="decimal" validation="Required"></asp:TextBox>
                </div>
            </div>
            <div style="height: 6px;"></div>

            <div>
                <fieldset>
                    <legend>Informacion de contacto</legend>
                    <div class="label_plus_input par">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Name %></span>
                        <asp:TextBox runat="server" ID="txtContactName" ClientIDMode="Static" Style="text-align: left;"  Enabled="false" validation="Required"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.PhoneNumberLabel %></span>
                        <asp:TextBox runat="server" ID="txtPhoneNumber" ClientIDMode="Static" Style="text-align: left;" Enabled="false" data-inputmask="'mask': '(999)999-9999','clearMaskOnLostFocus': true,'showTooltip': true" validation="Required"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.EmailAddressLabel %></span>
                        <asp:TextBox runat="server" ID="txtEmailAddress" ClientIDMode="Static" Style="text-align: left;" Enabled="false" inputType="Email" validation="Required"></asp:TextBox>
                    </div>
                    </span>
                </fieldset>
            </div>
            <div style="height: 6px;"></div>
            <div style="float: right;">
                <div class="fl" style="margin-left: 10px;">
                    <asp:LinkButton runat="server" CssClass="button button-green alignC embossed" ID="btnEndosoCesionGuardar" OnClientClick="return validateForm('dvEndosoCesion')" OnClick="btnEndosoCesionGuardar_Click">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save %></span>
                    </asp:LinkButton>
                </div>

                <div class="fl" style="margin-left: 10px;">
                    <input type="button" class="button button-red alignC embossed" onclick="ClosePopEndoso();" value="<%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel %>" />
                </div>
            </div>
            <div style="height: 43px;"></div>
            <div>
                <div class="fl">
                    <asp:LinkButton runat="server" CssClass="button button-blue alignC embossed" ID="lnkDescargarHojaEndoso" OnClick="lnkDescargarHojaEndoso_Click">
            <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.EndorstmenNotification %></span>
                    </asp:LinkButton>
                </div>
                <asp:Panel runat="server" ID="pnAnularEndoso" class="fl" Style="margin-left: 10px;">
                    <asp:LinkButton runat="server" CssClass="button button-orange alignC embossed" ID="lnkAnularEndoso" OnClientClick="return DlgConfirm(this);" OnClick="lnkAnularEndoso_Click">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.EndorstmenNullation %></span>
                    </asp:LinkButton>
                </asp:Panel>
            </div>
        </div>

        <asp:HiddenField runat="server" ID="hdnInsuredVehicleId" Value="0" />
        <asp:HiddenField runat="server" ID="hdnEndorsementAmount" Value="0" />
        <asp:HiddenField runat="server" ID="hdnEndorsementBeneficiary" Value="0" />
        <asp:HiddenField runat="server" ID="hdnEndorsementBeneficiaryRnc" Value="0" />

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnEndosoCesionGuardar" EventName="Click" />
        <asp:PostBackTrigger ControlID="lnkDescargarHojaEndoso" />
        <asp:AsyncPostBackTrigger ControlID="lnkAnularEndoso" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>

