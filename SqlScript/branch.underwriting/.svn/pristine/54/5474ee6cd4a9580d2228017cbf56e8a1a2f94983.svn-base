<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequestAmendments.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCRequestAmendments" %>
<asp:UpdatePanel runat="server" ID="udpCaseAddAcase">
    <ContentTemplate>
        <div class="tcommunication ">
            <div class="cont wd100">
                <div class=" wd30 fl mR-2-p">
                    <label class=" label txtBold row">Document Type:</label>
                    <asp:DropDownList ID="ddlDocumentType" runat="server" DataValueField="Value" DataTextField="Text" />

                    <label class=" label txtBold row">Person:</label>
                    <asp:DropDownList ID="ddlPerson" runat="server" DataValueField="Value" DataTextField="Text" />

                    <label class=" label txtBold row">Period</label>
                    <label class="fl mR-2-p mT10">From:</label>

                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtFromDate" CssClass="datepickerPop mB wd81 fr" />

                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtToDate" CssClass="datepickerPop wd81 fr" />
                    <label class="fr mR-2-p mT10">To:</label>
                </div>
                <div class="wd68 fl">
                    <div class=" pd10 alignL gradient_gris lh8">
                        <label>COMMENTS:</label>
                    </div>
                    <asp:TextBox CssClass="mT0 hg190" TextMode="multiline" runat="server" ID="txtComment" ClientIDMode="Static" />
                    <%-- <textarea class="mT0 hg190"></textarea>--%>
                </div>
                <!-- Botones -->
                <div class="wd100 fl hg35 mT10">
                    <div class="boton_wrapper gradient_RJ bdrRJ fr">
                        <span class="equis"></span>
                        <asp:Button ID="btnCancel" CssClass="boton" runat="server" Text="Cancel" OnClientClick="return CloseAmendmentsPop();" />
                    </div>
                    <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR">
                        <span class="save"></span>
                        <asp:Button ID="btnSave" CssClass="boton" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return validateTXT(this);" />

                    </div>
                </div>
                <!--// Botones -->

            </div>
            <!--// cont -->
        </div>
    </ContentTemplate>

    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnCancel" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
