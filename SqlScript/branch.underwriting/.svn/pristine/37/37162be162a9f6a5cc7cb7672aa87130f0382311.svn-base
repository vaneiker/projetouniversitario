<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BackgroundCheckLink.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PersonalData.BackgroundCheckLink" %>

<div class="BackgroundcheckLink content_fondo_blanco">
    <asp:UpdatePanel ID="upResultDetail" runat="server" ClientIDMode="Static">
        <ContentTemplate>
            <fieldset>
                <legend>Internet Search by Role</legend>
                <asp:Panel ID="pn_url_document_blanco" runat="server" CssClass="content_fieldset">

                    <asp:Panel ID="pn_upload_document" runat="server" DefaultButton="btnSave">
                        <table class="min_w_500">
                            <tr>
                                <td>
                                    <label class="label">URL:</label>
                                    <asp:TextBox ID="txtURL" ClientIDMode="Static" runat="server" Style="margin-bottom: 0;"></asp:TextBox>
                                </td>
                                <td style="width: 130px;text-align: center;">
                                    <asp:Panel runat="server" CssClass="boton_wrapper verde" ID="pn_save">
                                        <span class="save"></span>
                                        <asp:Button ID="btnSave" CssClass="boton" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return BackgroundCheckLink.ValidateURLEntry()" />
                                    </asp:Panel>
                                </td>
                                <td style="text-align: right; width: 160px">

                                    <asp:Panel runat="server" CssClass="boton_wrapper morado" ID="pn_internet_search">
                                        <span class="internet_search"></span>
                                        <asp:Button ID="btn_internetSearch" runat="server" CssClass="boton" Text="Internet Search" OnClientClick="BackgroundCheckLink.ShowPopupSearch()" ClientIDMode="Static" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>


                    <div class="grid_wrap insternet_search" style="padding-top: 10px; border: 0;">
                        <asp:GridView ID="gv_InternetImages" DataKeyNames="
                        cORP_ID,
                        rEGION_ID,
                        cOUNTRY_ID,
                        dOMESTICREG_ID,
                        sTATE_PROV_ID,
                        cITY_ID,
                        oFFICE_ID,
                        cASE_SEQ_NO,
                        hIST_SEQ_NO,
                        cONTACT_ID,
                        lINK_ID,
                        Matched,
                        lINK_URL"
                            CssClass="tbody datagrid" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="DATE">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Create_Date","{0:d}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="c1 headgridnew" />
                                    <ItemStyle CssClass="c1" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="USER NAME">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="c2 headgridnew" />
                                    <ItemStyle CssClass="c2" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="URL">
                                    <ItemTemplate>
                                        <div>
                                            <a onclick="window.open('<%# Eval("Link_Url") %>', '_blank')"><%# Eval("Link_Url") %> </a>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="c3 headgridnew" />
                                    <ItemStyle CssClass="c3" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STATUS">
                                    <ItemTemplate>
                                        <div>
                                            <asp:LinkButton ID="imgStatus" runat="server" CssClass='<%# Bind("Match_Status_Img") %>' OnClick="imgStatus_Click"></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="c4 headgridnew" />
                                    <ItemStyle CssClass="c4" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DELETE">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Button ID="btnDeImage" runat="server" CssClass="delete_file" OnClick="lnk_DelDoc_Click" OnClientClick="return DlgConfirm(this)" />
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="c5 headgridnew" />
                                    <ItemStyle CssClass="c5" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="headgrid azules" />
                        </asp:GridView>
                        <tfoot>
                            <tr>
                                <td colspan="6">
                                    <div class="pagination" runat="server" id="div_pag">
                                        <p>
                                            Page
                                        <asp:Literal ID="lt_FirstPage" runat="server" Text="1"></asp:Literal>
                                            of
                                        <asp:Literal ID="lt_lastPage" runat="server" Text="1"></asp:Literal>
                                            (<asp:Literal ID="lt_items" runat="server" Text="1"></asp:Literal>
                                            items)
                                        </p>

                                        <%-- **todas las posibilidades** ----%>
                                        <asp:LinkButton ID="lnk_GoFirst" CssClass="rewd_dis" OnClick="lnk_GoFirst_Click" runat="server"></asp:LinkButton>
                                        <asp:LinkButton ID="lnk_prev" CssClass="prev_dis" OnClick="lnk_prev_Click" runat="server"></asp:LinkButton>
                                        <asp:LinkButton ID="lnk_next" CssClass="next" OnClick="lnk_next_Click" runat="server"></asp:LinkButton>
                                        <asp:LinkButton ID="lnk_GoLast" CssClass="fwrd" OnClick="lnk_GoLast_Click" runat="server"></asp:LinkButton>
                                    </div>
                                    <!--pagination-->
                                </td>
                            </tr>
                        </tfoot>
                        </table>
                    </div>
                </asp:Panel>
            </fieldset>
            <!--grid_wrap--> 
            <asp:HiddenField ID="hdnPreviewImage" runat="server" ClientIDMode="Static" Value="false" />
            <asp:HiddenField ID="hdnKey" runat="server" ClientIDMode="Static" Value="false" />

        </ContentTemplate>
        <Triggers>            
            <asp:AsyncPostBackTrigger ControlID="gv_InternetImages" />
        </Triggers>
    </asp:UpdatePanel>
</div>
