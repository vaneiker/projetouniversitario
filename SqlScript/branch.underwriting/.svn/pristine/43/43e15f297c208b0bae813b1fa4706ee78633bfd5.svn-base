<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCChangeSteps.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.ChangeSteps.UCChangeSteps" %>
<%@ Register Src="~/Case/UserControls/UnderwritingSteps/UCPopStepComments.ascx" TagPrefix="uc1" TagName="UCPopStepComments" %>

<asp:UpdatePanel ID="upUnderSteps" runat="server">
    <ContentTemplate>
        <div class="tbl">
            <asp:GridView ID="gvStepChanges" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CssClass="gvStepChanges"
                DataKeyNames="HasCall, RecordingFile, StepId, StepCaseNo, Voidable, Closable, ProcessStatus" OnRowDataBound="gvStepChanges_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="UNDERWRITING STEPS" HeaderStyle-CssClass="c1 brNone" ItemStyle-CssClass="c1">
                        <ItemTemplate>
                            <div>
                                <img align="left" src='<%# (Eval("ProcessStatus").ToString() == "1"? "../../images/alert_mamei.jpg": (Eval("ProcessStatus").ToString() == "2"? "../../images/alert_checkmark.jpg" : "../../images/ico_new/btn/x.png")) %>' class="alert_naranja">
                                <asp:LinkButton ID="lblStepDesc" Text='<%# Eval("StepDesc") %>' OnClientClick="return false;" runat="server" ClientIDMode="Static"></asp:LinkButton>
                            </div>
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
                                    Text='<%# Eval("Current") ?? "" %>'
                                    CssClass='<%# Eval("CurrentIsRed") == null? "" : (Boolean.Parse(Eval("CurrentIsRed").ToString()) ? "text_rojo" : "" ) %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="STANDARD" HeaderStyle-CssClass="c8 alignC brNone" ItemStyle-CssClass="c8 alignC">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Standard") ?? "" %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Panel runat="server" CssClass="mensaje_steps" ID="dvUSShowNotes" Style="display: none;" ClientIDMode="Static" >
                                <asp:Literal runat="server" ID="liUSNotes" Text='<%# "<p>" +  Eval("NoteDesc") + "</p>" %>'></asp:Literal>
                                <div class="btreadmore fr mB">
                                    <asp:LinkButton ID="lnkReadMore" Text="Read More" CssClass="addlink mT10" runat="server" ClientIDMode="Static" OnClick="lnkReadMore_Click"></asp:LinkButton>
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

        <asp:TextBox ID="txtUSCTotalCurrent" runat="server" Style="display: none; text-align: center;" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
        <asp:TextBox ID="txtUSCTotalStandard" runat="server" Style="display: none; text-align: center;" ClientIDMode="Static" ReadOnly="true" ></asp:TextBox>
        <asp:HiddenField ID="hdnUSCShowPopComments" runat="server" Value="false" ClientIDMode="Static" />

        <div id="dvPopUSCComments" style="display: none">
           <uc1:UCPopStepComments runat="server" ID="UCPopStepComments1" />
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvStepChanges" />
    </Triggers>
</asp:UpdatePanel>

