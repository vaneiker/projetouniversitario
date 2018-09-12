<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRiderReason.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Riders.UCRiderReason" %>

<asp:UpdatePanel ID="upRiderReason" ClientIDMode="Static" runat="server">
    <ContentTemplate>

        <div class="cont_risk_popup ">


            <div class="wd100 fl mB15">
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtComment" CssClass="wd100 hg350 txtNG mB" ReadOnly="true" />

                <label class="label txtBold">New Comment</label>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtNewCommentRiderReason" ClientIDMode="Static" CssClass="wd100 hg190 txtNG" />
            </div>

            <div class="row mT20">
                <div class="boton_wrapper gradient_RJ bdrRJ fr">
                    <span class="equis"></span>
                    <asp:Button ID="btnCancel" CssClass="boton" runat="server" Text="CLOSE" OnClientClick="return CloseRiderPop();" />
                </div>

                <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR">
                    <span class="save"></span>
                    <asp:Button ID="btnSave" CssClass="boton" runat="server" Text="SAVE" OnClick="btnSave_Click" OnClientClick="return validateRiderComment();" />
                </div>
            
            </div>
            <asp:HiddenField ID="hdnRiderId" runat="server" />
            <asp:HiddenField ID="hdnRiderTypeId" runat="server" />
        </div>

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>

