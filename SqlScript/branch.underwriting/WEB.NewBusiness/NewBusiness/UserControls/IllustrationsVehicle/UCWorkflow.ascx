<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCWorkflow.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCWorkflow" %>
<asp:UpdatePanel runat="server" ID="UpdatePanelWorkflow">
    <ContentTemplate>
        <div class="cont_gnl tab_pane_container rcomp mT25">
            <div id="divHeader" class="row_A head2 cotizacion workflow">
                <div class="boxes_step col-9 fl" style="width: 100%;">
                    <div class="boxes">
                        <asp:Panel ID="pnlIncompleteIllustration" runat="server" CssClass="box_btn inactive cursorpointer">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.IncompleteIllustration %><i class="arr_ico"></i>
                        </asp:Panel>
                        <div class="box_btn_group">
                            <asp:Panel ID="pnlCompleteIllustration" runat="server" CssClass="box_btn inactive cursorpointer box_btn_head">
                                <%=RESOURCE.UnderWriting.NewBussiness.Resources.CompleteIllustration %><i class="arr_ico"></i>
                            </asp:Panel>
                            <asp:Panel ID="pnlDeclinedByClient" runat="server" CssClass="box_btn inactive cursorpointer box_down">
                                <%=RESOURCE.UnderWriting.NewBussiness.Resources.DeclinedByClient %><i class="arr_ico"></i>
                            </asp:Panel>
                        </div>
                        <asp:Panel ID="pnlApprovedByClient" runat="server" CssClass="box_btn inactive cursorpointer">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.ApprovedByClientIllustration %><i class="arr_ico"></i>
                        </asp:Panel>
                        <div id="dvSubscriptionWorkflow" class="box_btn_group">
                            <asp:Panel ID="pnlSubscription" runat="server" CssClass="box_btn inactive cursorpointer box_btn_head"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Subscription %><i class="arr_ico"></i></asp:Panel>
                            <asp:Panel ID="pnlDocumens" runat="server" CssClass="box_btn inactive cursorpointer box_down">
                                <%=RESOURCE.UnderWriting.NewBussiness.Resources.Documents %><i class="arr_ico"></i>
                            </asp:Panel>
                            <asp:Panel ID="pnlInspection" runat="server" CssClass="box_btn inactive cursorpointer box_down">
                                <%=RESOURCE.UnderWriting.NewBussiness.Resources.Inspection %><i class="arr_ico"></i>
                            </asp:Panel>
                            <asp:Panel ID="pnlDeclinedBySubcription" runat="server" CssClass="box_btn inactive cursorpointer box_down">
                                <%=RESOURCE.UnderWriting.NewBussiness.Resources.Declined %><i class="arr_ico"></i>
                            </asp:Panel>
                        </div>
                        <div class="box_btn_group">
                            <asp:Panel ID="pnlApprovedBySubscription" runat="server" CssClass="box_btn inactive cursorpointer box_btn_head">
                                <%=RESOURCE.UnderWriting.NewBussiness.Resources.Approved %>
                            </asp:Panel>
                            <asp:Panel ID="pnlExpired" runat="server" CssClass="box_btn inactive cursorpointer box_down">
                                <%=RESOURCE.UnderWriting.NewBussiness.Resources.Expired %>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
