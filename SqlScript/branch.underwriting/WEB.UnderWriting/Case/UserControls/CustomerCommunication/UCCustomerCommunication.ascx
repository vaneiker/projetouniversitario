<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCustomerCommunication.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.CustomerCommunication.UCCustomerCommunication" %>
<%@ Register Src="~/Case/UserControls/CustomerCommunication/UCCommNotes.ascx" TagPrefix="uc1" TagName="UCCommNotes" %>
<%@ Register Src="~/Case/UserControls/CustomerCommunication/UCCommCalls.ascx" TagPrefix="uc1" TagName="UCCommCalls" %>
<asp:UpdatePanel ID="upCustomerComm" runat="server">
    <ContentTemplate>
        <div class="tbl data_G">
            <asp:GridView ID="gvClientComunication" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="CallNoteId">
                <Columns>
                    <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDocumentIcon" runat="server" CssClass='<%# Eval("NoteTypeId") == null? "sobre_ico": ( int.Parse(Eval("NoteTypeId").ToString()) == 3? "audio_ico" : "sobre_ico") %>'
                                OnClick="lnkDocumentIcon_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Communication Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c">
                        <ItemTemplate>
                            <asp:Label ID="lblCommunicationName" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Sent" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c">
                        <ItemTemplate>
                            <asp:Label ID="lblDateSent" runat="server" Text='<%# Eval("DateSent", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
            </asp:GridView>
        </div>
        <div id="dvCCNotePopup" style="display: none">
            <uc1:UCCommNotes runat="server" ID="UCCommNotes" />
        </div>

        <div id="dvCCCallPopup" style="display: none">
            <uc1:UCCommCalls runat="server" ID="UCCommCalls" />
        </div>

        <asp:HiddenField ID="hdnCCShowNotePop" runat="server" Value="false" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCCShowCallPop" runat="server" Value="false" ClientIDMode="Static" />
    </ContentTemplate>
</asp:UpdatePanel>
