<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPopNewStep.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Common.UCPopNewStep" %>

<asp:UpdatePanel ID="upPopAddNewStep" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="head gradient_azul HeaderHandler" style="cursor: move;">
            <span style="width: 97%;">Add New Step</span>
            <div class="close_pp_btn">
                <asp:Button ID="btnClosePdfPop" runat="server" CssClass="btnClosePopBtn" ClientIDMode="Static" OnClientClick="return CloseNSAddStepPop();" />
            </div>
        </div>
        <div class="cont_risk_popup ">
            <div class="wd100 fl clear">
                <div class=" row mR-2-p lh30">
                    <label class="fl mB mR " for="rt">SELECT NEW STEP:</label>
                    <asp:DropDownList ID="ddlNSSelectStep" runat="server" ClientIDMode="Static" CssClass="fl m0 wd30" DataTextField="Text" DataValueField="Value"></asp:DropDownList>
                </div>
            </div>

            <div class="row mB15">
                <label class="wd100 fl alignL mB">COMMENTS:</label>
                <asp:TextBox ID="txtNSComments" CssClass="wd100 hg300" runat="server" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="row hg35 clear">
                <div class="boton_wrapper gradient_RJ bdrRJ fr">
                    <span class="equis"></span>
                    <input class="boton" type="button" value="Cancel" onclick="CloseNSAddStepPop();">
                </div>
                <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr mR">
                    <span class="add"></span>
                    <asp:Button ID="btnNSAdd" ClientIDMode="Static" runat="server" Text="Add" CssClass="boton" OnClick="btnNSAdd_Click" OnClientClick="return ValidateSaveNewStep();" />
                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
    </Triggers>
</asp:UpdatePanel>
