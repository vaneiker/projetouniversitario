<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IssueContainer.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.IssueContainer" %>
<%@ Register Src="~/Life/UserControls/Issue/Printing.ascx" TagPrefix="uc1" TagName="Printing" %>
<%@ Register Src="~/Life/UserControls/Issue/Issue.ascx" TagPrefix="uc1" TagName="Issue" %>
<%@ Register Src="~/Life/UserControls/Processing/Processing.ascx" TagPrefix="uc1" TagName="Processing" %>
<%@ Register Src="~/Life/UserControls/Issue/PolicyDetail/PolicyDetail.ascx" TagPrefix="uc1" TagName="PolicyDetail" %>
<%@ Register Src="~/Life/UserControls/Issue/PolicyDetail/Riders.ascx" TagPrefix="uc1" TagName="Riders" %>

<!--PASOS-->
<asp:UpdatePanel runat="server" ID="upIssueContainer">
    <ContentTemplate>
        <div class="row_box">
            <div class=" row_A head2">
                <div class="boxes_step col-12 fl">
                    <div class="boxes">
                        <asp:LinkButton runat="server" ID="lnkIssue" Text="" OnClick="lnkIssue_OnClick" CssClass="box_btn activo" ClientIDMode="Static">
                              <b class="numbPS">1</b>
                            Emisión
                            <i class="arr_ico"></i>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lnkProcessing" Text="" OnClick="lnkProcessing_Click" CssClass="box_btn" ClientIDMode="Static">
                              <b class="numbPS">2</b>
                            En Proceso
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <asp:MultiView runat="server" ID="mvIssueContainer" ActiveViewIndex="0">
                <asp:View runat="server" ID="vIssue">
                    <uc1:Issue runat="server" ID="UCIssue" />
                </asp:View>
                <asp:View runat="server" ID="vPrinting">
                    <uc1:Printing runat="server" ID="UCPrinting" />
                </asp:View>
                <asp:View runat="server" ID="vProcessing">
                   <uc1:Processing runat="server" ID="UCProcessing" />
                </asp:View>
            </asp:MultiView>
        </div>
        <asp:Panel runat="server" ID="pnlIssuePlyDetail" CssClass="row mT15" Visible="True">
            <ul class="tabs" id="status" data-ks-tabs="">
                <li class="tab-item open" runat="server" id="liPolicyDetail">
                    <asp:LinkButton runat="server" ID="lnkPolicyDetail" OnClick="lnkPolicyDetail_OnClick" ClientIDMode="Static">
                        Datos de la Póliza - 0000000
                    </asp:LinkButton>

                </li>
                <li class="tab-item" runat="server" id="liPolicyRiders">
                    <asp:LinkButton runat="server" ID="lnkPolicyRiders" Text="Riders" OnClick="lnkPolicyRiders_OnClick" ClientIDMode="Static" />
                </li>
            </ul>
            <div class="cont_gnl tab_pane_container riders_info_L">
                <asp:MultiView runat="server" ID="mvPolicyDetail" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vPolicyDetail">
                        <uc1:PolicyDetail runat="server" ID="UCPolicyDetail" />
                    </asp:View>
                    <asp:View runat="server" ID="vPolicyRiders">
                        <uc1:Riders runat="server" ID="UCRiders" />
                    </asp:View>
                </asp:MultiView>
            </div>
        </asp:Panel>
        
     

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lnkIssue" />
        <%--<asp:AsyncPostBackTrigger ControlID="lnkPrinting" />--%>
        <asp:AsyncPostBackTrigger ControlID="lnkProcessing" />
        <asp:AsyncPostBackTrigger ControlID="lnkPolicyRiders" />
        <asp:AsyncPostBackTrigger ControlID="lnkPolicyDetail" />
    </Triggers>
</asp:UpdatePanel>
