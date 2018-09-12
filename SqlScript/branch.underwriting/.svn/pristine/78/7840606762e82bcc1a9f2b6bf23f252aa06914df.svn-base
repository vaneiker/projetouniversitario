<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequirementComunication.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Requirements.UCRequirementComunication" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<asp:UpdatePanel ID="upRequementComunication" runat="server">
    <ContentTemplate>
                    <div class="titulos_azules head_contengridproxi PreviewPDF HeaderHandler" style="width: 100%;">
                <ul>
                    <li style="position: absolute; left: 0%; top: 31%;">
                        <asp:Literal ID="ltTypeDoc" Text="Communication" ClientIDMode="Static" runat="server"></asp:Literal>
                    </li>
                    <li style="top: 13%;">
                        <input type="button" id="close_pop_up" class="cls_pup" onclick="CloseCommunicationPDFPop();" />
                    </li>
                </ul>
            </div>
        <div class="cont_popup_com ">

            <!-- Fila 1-->
            <div class="box1">
                <label class="label comment_lb">Comments:</label>
                <div class="comment_cont ">
                    <asp:Repeater ID="CommentsRepeater" runat="server">
                        <ItemTemplate>
                            <div class="comment_box rds5 user">
                                <span class="name gradient_azul rds5"><%# Eval("CommentByUserName") %></span>
                                <span class="fecha"><%#Convert.ToDateTime(Eval("CommentDate")).ToString("MM/dd/yyyy") %></span>
                                <p class="comment"><%# Eval("Comment") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <label class="label wd100">SUBMITTED FILES</label>
                <div class="tbl-req wd100 mB">

                    <asp:GridView ID="gvComunicationPopUp" runat="server" AutoGenerateColumns="false" border="0" CellSpacing="0" CellPadding="0"
                        DataKeyNames="ContactId,RequirementCatId,RequirementTypeId,RequirementId,RequirementDocId,DocumentStatusId">
                        <Columns>
                            <asp:TemplateField HeaderText="File Name" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c1">
                                <ItemTemplate>
                                    <div><%# Eval("DocumentName") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View PDF" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="pdf_ico" OnClick="ComunicationLoadPdfBtn_Click"></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div><%# Eval("DocumentStatusDesc") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:TextBox ID="RequirementCommunicationNewCommentsTxt" runat="server" ClientIDMode="Static" placeholder="Add New Comments" TextMode="MultiLine"></asp:TextBox>
                <div class="wd100 fl hg35">

                    <asp:Panel class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr" runat="server" ID="pnAddCommentBtn">
                        <span class="add"></span>
                        <asp:Button ID="AddCommentBtn" runat="server" CssClass="boton" Text="Add Comment" OnClick="ComunicationAddComment_Click" OnClientClick="return validateCommentCommunication();" />
                    </asp:Panel>
                </div>
            </div>

            <div class="box2">
                <label class="label wd100">PDF FILES</label>
                <PdfViewer:PdfViewer ID="pdfViewerComunication" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Width="840" Height="640px">
                </PdfViewer:PdfViewer>
                <asp:Panel ID="pnStatusButtons" runat="server" CssClass="wd100 fl hg35 mT20">


                    <div class="boton_wrapper gradient_RJ bdrRJ fr">
                        <span class="decline"></span>
                        <asp:Button ID="DeclineBtn" OnClick="DeclineBtn_Click" runat="server" CssClass="boton" Text="Decline" />
                    </div>

                    <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR">
                        <span class="save"></span>
                        <asp:Button ID="AcceptBtn" OnClick="AcceptBtn_Click" runat="server" CssClass="boton" Text="Accept" />
                    </div>


                </asp:Panel>
            </div>


        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="AddCommentBtn" />
    </Triggers>
</asp:UpdatePanel>
<asp:HiddenField runat="server" ID="hfRequirementDocumentKey" ClientIDMode="Static" Value="" />
