<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAddNewRequirement.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Requirements.UCAddNewRequirement" %>
<asp:UpdatePanel ID="upAddNewRequirement" runat="server">
    <ContentTemplate>
        <div class="cont_popup ">
            <div>
                <!-- Fila 1-->
                <div class="wd100 fl clear mB15">

                    <div class="wd58 fl mR-2-p">
                        <label class="fl label txtBold txtNormal wd13 mT10 ReqField">Role:</label>
                        <asp:DropDownList ID="RequirementRoleDDL" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="RequirementRoleDDL_SelectedIndexChanged" AutoPostBack="true" class="wd87 fr clVD-osc"></asp:DropDownList>
                    </div>

                    <div class="wd40 fl">
                        <label class="fl label txtBold txtNormal wd50 mT10 ReqField">Requirement Category:</label>
                        <asp:DropDownList ID="ddlRequirementCategory" ClientIDMode="Static" OnSelectedIndexChanged="ddlRequirementCategory_SelectedIndexChanged1" runat="server" class="fr wd50 clVD-osc" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <!--// Fila 1 -->

                <!-- Fila 2 -->
                <div class="wd100 fl fl2">
                    <div class="boxs" style="overflow: scroll;">

                        <ul class="fl wd100  mR-2-p" id="RequirementtypeList">
                            <asp:CheckBoxList ID="chkReqTypeList" runat="server" DataTextField="Text" DataValueField="Value" RepeatDirection="Vertical"
                                RepeatColumns="3" CssClass="Requirementchk" CellSpacing="10">
                            </asp:CheckBoxList>
                        </ul>
                    </div>

                    <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr mT10 mB">
                        <span class="add"></span>
                        <asp:Button ID="btnAddRequirement" runat="server" Text="Add Requirements" CssClass="boton" OnClick="btnAddRequirement_Click" OnClientClick="return ValidateAddRequirement();" />
                    </div>
                </div>
                <!--// Fila 2 -->

                <div class="row mB">
                    <div class="tbl-body tbl-body-1">
                        <asp:GridView ID="gvRequirementSelectionTable" ClientIDMode="Static" runat="server" border="0" CellSpacing="0" CellPadding="0" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                            DataKeyNames="RequirementCatID, RequirementTypeID, ContactRoleID">
                            <Columns>

                                <asp:TemplateField HeaderText="Role" HeaderStyle-CssClass="c1 alignL" ItemStyle-CssClass="c1">
                                    <ItemTemplate>
                                        <%# Eval("ContactRoleDesc") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Requirement Category" HeaderStyle-CssClass="c2 alignL" ItemStyle-CssClass="c2">
                                    <ItemTemplate>
                                        <%# Eval("RequirementCatDesc") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Requirement" HeaderStyle-CssClass="c3 alignL" ItemStyle-CssClass="c3">
                                    <ItemTemplate>
                                        <%# Eval("RequirementTypeDesc") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="c4" ItemStyle-CssClass="c4">
                                    <ItemTemplate>
                                        <%--<div>--%>
                                        <asp:UpdatePanel runat="server" ID="upDRequeriment">
                                            <ContentTemplate>
                                                <asp:Button ID="lnkDeleteRequirement" ClientIDMode="Static" OnClientClick="return DlgConfirm(this);" runat="server" class="delete_file" OnClick="lnkDeleteRequirement_Click"></asp:Button>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnkDeleteRequirement" /> 
                                            </Triggers>
                                        </asp:UpdatePanel>

                                        <%--</div>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="gradient_azul  tbl-head" />
                            <EmptyDataTemplate>
                                No data to display
                            </EmptyDataTemplate>
                            <EmptyDataRowStyle CssClass="footer" />
                        </asp:GridView>
                    </div>
                </div>


                <div class="row mB">
                    <label class="fl label txtBold txtNormal wd22 mT10">Requirement Will Be Send To:</label>

                </div>
                <div class="wd48 fl mR-2-p">
                    <div class="tbl-body-1 tbl-body">
                        <asp:GridView ID="gvSentToRequirement" runat="server" DataKeyNames="AgentId"
                            border="0" CellSpacing="0" CellPadding="0" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                            <Columns>

                                <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="c1 alignL" ItemStyle-CssClass="c1">
                                    <ItemTemplate>
                                        <%# Eval("AgentName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Office" HeaderStyle-CssClass="c2 alignL" ItemStyle-CssClass="c2">
                                    <ItemTemplate>
                                        <%# Eval("OfficeDesc") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="c3" ItemStyle-CssClass="c3">
                                    <ItemTemplate>
                                        <%--<div>--%>
                                        <asp:Button ID="lnkDeleteSenTo" ClientIDMode="Static" OnClientClick="return DlgConfirm(this);" runat="server" class="delete_file" OnClick="lnkDeleteSenTo_Click"></asp:Button>
                                        <%--</div>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="gradient_azul  tbl-head" />
                            <EmptyDataTemplate>
                                No data to display
                            </EmptyDataTemplate>
                            <EmptyDataRowStyle CssClass="footer" />
                        </asp:GridView>

                    </div>
                </div>


                <div class="wd50 fl">
                    <asp:TextBox ID="txtReqComment" runat="server" CssClass="wd100 hg134" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>
                </div>

                <!-- Botones -->
                <div class="wd100 fl hg35 mT10">
                    <div class="boton_wrapper gradient_RJ bdrRJ fr">
                        <span class="equis"></span>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="boton" OnClientClick="return CloseRequirementPop();" />
                    </div>
                    <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR">
                        <span class="save"></span>
                        <asp:Button ID="btnSave" runat="server" Text="Save" class="boton" OnClick="btnSave_Click" OnClientClick="return ValidateSaveRequirement();" />
                    </div>

                </div>
                <!--// Botones -->
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hfNewRequirementTable" ClientIDMode="Static" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlRequirementCategory" />
        <asp:AsyncPostBackTrigger ControlID="RequirementRoleDDL" />
    </Triggers>
</asp:UpdatePanel>
