<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUnderwritingCall.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.UnderwritingCall.UCUnderwritingCall" %>
<%@ Register Src="~/Case/UserControls/UnderwritingCall/UCAttachCall.ascx" TagPrefix="uc1" TagName="UCAttachCall" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel runat="server" ID="upUnderwritingCall">
    <ContentTemplate>
        <div class="cont_underwriting_call" id="underwritingCallProtocolo">
            <asp:Literal ID="ltlUnderwritingCall" runat="server" ClientIDMode="Static">
                
            </asp:Literal>
        </div>
        <div class="wr">
            <asp:TextBox ID="txtUCComments" runat="server" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>
            <div class="row clear">
                <div class="boton_wrapper gradient_RJ bdrRJ fl mR">
                    <span class="pdf"></span>
                    <asp:Button ID="btnUCSolicitud" runat="server" ClientIDMode="Static" OnClick="btnUCSolicitud_Click" CssClass="boton" Text="Solicitud" />
                </div>
                <div class="boton_wrapper gradient_RJ bdrRJ fl">
                    <span class="pdf"></span>
                    <asp:Button ID="btnUCCorridas" runat="server" ClientIDMode="Static" OnClick="btnUCCorridas_Click" CssClass="boton" Text="Corridas" />
                </div>

            </div>
        </div>
        <div id="dvPopUCAttachCall" style="display: none;">
            <uc1:UCAttachCall runat="server" ID="UCAttachCall" />
        </div>

        <asp:Button ID="btnUCAttachCallOrig" runat="server" ClientIDMode="Static" OnClick="btnUCAttachCallOrig_Click" Text="Adjuntar Llamada y Finalizar" CssClass="boton" OnClientClick="return UCSaveCallDetails();" />

        <asp:HiddenField ID="hdnUCIsClosed" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnUCStepId" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnUCStepTypeId" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnUCStepCaseNo" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnPKeyJson" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnShowPopAttachCall" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnProtocolNoPhone" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnProtocolNoDate" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnProtocolLanguage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnProtocolEmail" runat="server" ClientIDMode="Static" />                
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnUCAttachCallOrig" />
    </Triggers>
</asp:UpdatePanel>
