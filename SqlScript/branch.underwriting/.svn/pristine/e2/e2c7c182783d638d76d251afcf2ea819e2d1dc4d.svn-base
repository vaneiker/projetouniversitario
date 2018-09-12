<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUnderwritingStep.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.UnderwritingSteps.UCUnderwritingStep" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Case/UserControls/UnderwritingSteps/UCPopStepComments.ascx" TagPrefix="uc1" TagName="UCPopStepComments" %>
<asp:UpdatePanel ID="upUnderSteps" runat="server">
    <ContentTemplate>
        <div class="tbl">
            <asp:GridView ID="gvUnderSteps" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CssClass="gvUnderSteps"
                DataKeyNames="HasCall, RecordingFile, StepId, StepCaseNo, Voidable, Closable, ProcessStatus" OnRowDataBound="gvUnderSteps_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="STEPS NAME" HeaderStyle-CssClass="c1 brNone" ItemStyle-CssClass="c1">
                        <ItemTemplate>
                            <div>
                                <img align="left" src='<%# (Eval("ProcessStatus").ToString() == "1"? "../../../images/alert_mamei.jpg": (Eval("ProcessStatus").ToString() == "2"? "../../../images/alert_checkmark.jpg" : "../../../images/ico_new/btn/x.png")) %>' class="alert_naranja">
                                <asp:LinkButton ID="lblStepDesc" Text='<%# Eval("StepDesc") %>' OnClientClick="return false;" runat="server" ClientIDMode="Static"></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ACTION" HeaderStyle-CssClass="c2 brNone" ItemStyle-CssClass="c2">
                        <ItemTemplate>
                            <asp:Literal ID="liAction" runat="server" Text='<%# (Eval("ProcessStatus").ToString() == "3" ? "<span class=\"void_box off\">VOIDED STEP</span>" : "")%>'></asp:Literal>
							<%--<asp:Literal ID="liAction" runat="server" Text='<%# (Eval("ProcessStatus").ToString() == "3" ? "<span class=\"void_box off\">VOIDED STEP</span>" : (bool)Eval("HasCall") ? "" : Eval("StatusCatalogDesc"))%>'></asp:Literal>--%>
                            <asp:Button ID="btnPlayCall" CssClass="void_box on tcall" runat="server" Text="PLAY CALL"  Visible='<%#Eval("HasCall")%>' OnClick="btnPlayCall_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="INITIATED" HeaderStyle-CssClass="c3 brNone" ItemStyle-CssClass="c3 alignC">
                        <ItemTemplate>
                            <asp:Label ID="lblDateSent" runat="server" Text='<%#  Eval("Initiated") == null? "": DateTime.Parse( Eval("Initiated").ToString()).ToString("MM/dd/yyyy")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="COMPLETED" HeaderStyle-CssClass="c4 brNone" ItemStyle-CssClass="c4 alignC">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#  Eval("Completed") == null? "": DateTime.Parse( Eval("Completed").ToString()).ToString("MM/dd/yyyy")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="USERS" HeaderStyle-CssClass="c5 alignL brNone" ItemStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="TOTAL DAYS PROCESSING" HeaderStyle-CssClass="c6 brNone" ItemStyle-CssClass="c6">
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CURRENT" HeaderStyle-CssClass="c7 alignC brNone" ItemStyle-CssClass="c7 alignC">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="Label1" runat="server"
                                    Text='<%# Eval("Current") == null? "" : Eval("Current") %>'
                                    CssClass='<%# Eval("CurrentIsRed") == null? "" : (Boolean.Parse(Eval("CurrentIsRed").ToString()) ? "text_rojo" : "" ) %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="STANDARD" HeaderStyle-CssClass="c8 alignC brNone" ItemStyle-CssClass="c8 alignC">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Standard") == null? "" : Eval("Standard") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-CssClass="c9Remove">
                        <ItemTemplate>
                            <asp:Panel runat="server" CssClass="mensaje_steps" ID="dvUSShowNotes" Style="display: none;" ClientIDMode="Static">
                                <asp:Literal runat="server" ID="liUSNotes" Text='<%# "<p>" + (Eval("NoteDesc")==null?"": (Eval("NoteDesc").ToString().Length >= 600 ? Eval("NoteDesc").ToString().Substring(0,600)+" ..." : Eval("NoteDesc"))) + "</p>" %>'></asp:Literal>
                                <div class="btreadmore">
                                    <asp:LinkButton ID="lnkReadMore" Text="Read More" CssClass="addlink mT10" runat="server" OnClick="lnkReadMore_Click" ClientIDMode="Static"></asp:LinkButton>
                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="box_steps" />
            </asp:GridView>
        </div>

        <asp:TextBox ID="txtUSTotalCurrent" runat="server" Style="display: none; text-align: center;" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
        <asp:TextBox ID="txtUSTotalStandard" runat="server" Style="display: none; text-align: center;" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
        <asp:HiddenField ID="hdnUSShowPopComments" runat="server" Value="false" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnFromChange" runat="server" ClientIDMode="Static" />

        <div id="dvPopUSComments" style="display: none">
            <uc1:UCPopStepComments runat="server" ID="UCPopStepComments" />
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvUnderSteps" />
    </Triggers>
</asp:UpdatePanel>
