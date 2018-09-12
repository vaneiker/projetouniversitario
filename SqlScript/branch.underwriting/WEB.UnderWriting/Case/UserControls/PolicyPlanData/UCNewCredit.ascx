<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNewCredit.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCNewCredit" %>

<div class=" cont">
    <asp:UpdatePanel ID="upNewCredit" runat="server">
        <ContentTemplate>
            <!-- Fila 1-->
            <div class="wd100 fl clear mB15">
                <div class="wd32 fl mR-2-p">
                    <label class="row label txtBold">Credit Type:</label>
                    <asp:DropDownList ID="ddlCreditType" AutoPostBack="true" runat="server" CssClass="row clVD-osc" ClientIDMode="Static" OnSelectedIndexChanged="ddlCreditType_SelectedIndexChanged"/>
                </div>
                <div class="wd32 fl mR-2-p">
                    <label class="row label txtBold">Credit:</label>
                    <asp:DropDownList ID="ddlCredit" runat="server" CssClass="row clVD-osc" ClientIDMode="Static"  />
                </div>
                <div class="wd32 fl">
                    <label class="row label txtBold">Reason:</label>
                    <asp:DropDownList ID="ddlReason" runat="server" CssClass="row clVD-osc" ClientIDMode="Static" />
                </div>
            </div>
            <!--// Fila 1 -->


            <div class="row mB">
                <label class="fl label txtBold wd28 mT10">Add Comment:</label>
                <asp:TextBox runat="server" ID="txtCreditComment" TextMode="MultiLine" placeholder="Comments..." ClientIDMode="Static" CssClass="wd100 fl hg134" />
            </div>

            <!-- Botones -->
            <div class="wd100 fl hg35 mT10">

                <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR">
                    <span class="save"></span>
                    <asp:Button runat="server" ID="btnSave" CssClass="boton" Text="Save" OnClick="btnSave_Click" OnClientClick="return ValidateNewCredit();" />
                </div>
            </div>
            <!--// Botones -->


            <asp:HiddenField ID="hdnTotalTRating" Value="false" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnTotalPThousand" Value="false" runat="server" ClientIDMode="Static" />

            <asp:HiddenField ID="hdnNCIsAditional" Value="false" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnNCContactId" runat="server" ClientIDMode="Static" Value="false" />
            <asp:HiddenField ID="hdnNCContactRoleTypeId" runat="server" ClientIDMode="Static" Value="false" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCreditType" />
        </Triggers>
    </asp:UpdatePanel>
</div>
