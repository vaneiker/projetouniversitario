<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAttachCall.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.UnderwritingCall.UCAttachCall" %>

<asp:UpdatePanel ID="upAttachCall" runat="server">
    <ContentTemplate>
        <div class="attach_call ">
            <div class="cont wd100">


                <div class="tbl radio data_G">
                    <div class="">
                        <table cellspacing="0" rules="all" border="1" id="tblAttachCalls" style="border-collapse: collapse;">
                        </table>
                    </div>
                    <div style="overflow-y: auto; height: 314px;">
                        <asp:GridView ID="gvAttachCalls" runat="server" AutoGenerateColumns="false"
                            DataKeyNames="UserId, UserName, CallLogId, StartTime, EndTime, IncomingNumber, OutgoingNumber, CallerIDName, CallerIdNumber, RecordingFile, Duration"
                            OnRowDataBound="gvAttachCalls_RowDataBound" ClientIDMode="Static">
                            <Columns>
                                <asp:TemplateField HeaderStyle-CssClass="c1" ItemStyle-CssClass="alignC c1">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbtnAttach" ClientIDMode="Static" runat="server" CssClass="mT7 radio_in" GroupName="att_call" />
                                        <label class="mT7 radio_in" for=""></label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User" HeaderStyle-CssClass="c2" ItemStyle-CssClass="alignC c2">
                                    <ItemTemplate>
                                        <div><%# Eval("UserName")%></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Call Start At" HeaderStyle-CssClass="c3" ItemStyle-CssClass="alignC c3">
                                    <ItemTemplate>
                                        <div><%# Eval("StartTime")%></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Call End At" HeaderStyle-CssClass="c4" ItemStyle-CssClass="alignC c4">
                                    <ItemTemplate>
                                        <div><%# Eval("EndTime")%></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="c5" ItemStyle-CssClass="alignC c5">
                                    <ItemTemplate>
                                        <div><%# Eval("Duration")%></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Outgoing Number" HeaderStyle-CssClass="c6" ItemStyle-CssClass="alignC c6">
                                    <ItemTemplate>
                                        <div><%# Eval("OutgoingNumber")%></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Play Recording" HeaderStyle-CssClass="c7" ItemStyle-CssClass="alignC c7">
                                    <ItemTemplate>
                                        <asp:Literal ID="liAction" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <!-- Botones -->
                <div class="wd100 fl hg35">
                    <div class="boton_wrapper gradient_RJ bdrRJ fr">
                        <span class="equis"></span>
                        <asp:Button ID="btnACCancel" runat="server" CssClass="boton" Text="Cancel" OnClientClick="return CloseUCAttachCall();" />
                    </div>
                    <div class="boton_wrapper azul fr mR">
                        <span class="attach"></span>
                        <asp:Button ID="btnACAttach" runat="server" CssClass="boton" Text="Attach" OnClick="btnACAttach_Click" />
                    </div>
                </div>
                <!--// Botones -->


                <asp:HiddenField ID="hdnUCAttachSelectedRadio" runat="server" ClientIDMode="Static" />
            </div>
            <!--// cont -->
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnACAttach" />
    </Triggers>
</asp:UpdatePanel>
