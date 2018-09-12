<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNotesComments.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.NotesComments.UCNotesComments" %>
<%@ Register Src="~/Case/UserControls/NotesComments/UCCommentInfo.ascx" TagPrefix="uc1" TagName="UCCommentInfo" %>

<div class="wd100 fl">
    <asp:Panel ID="pnAddNoteButton" CssClass="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr mB" runat="server">
        <span class="add"></span>
        <%--        <input onclick="location.href = 'note_comments_new.html'" class="boton" type="submit" value="Add New">--%>
        <asp:Button ID="btnAddNote" runat="server" OnClick="btnAddNote_Click" Text="Add New" CssClass="boton" />
    </asp:Panel>
</div>


<asp:Panel runat="server" class="tbl data_G" ID="pnGridView">

    <asp:GridView ID="gvNoteComments" CssClass="tbl-NoteComments"
        runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="9"
        OnRowDataBound="gvNoteComments_RowDataBound" DataKeyNames="NoteId"
        OnPageIndexChanging="gvNoteComments_PageIndexChanging">
        <Columns>

            <asp:TemplateField HeaderText="Reference" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                <ItemTemplate>
                    <asp:Label ID="lblReference" runat="server" Text='<%# Eval("NoteReferenceTypeDesc") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Note Name" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c2">
                <ItemTemplate>
                    <asp:Label ID="lblNoteName" runat="server" Text='<%# Eval("NoteName") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date Added" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                <ItemTemplate>
                    <asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateAdded") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date Modified" HeaderStyle-CssClass="c4" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                <ItemTemplate>
                    <asp:Label ID="lblDateModified" runat="server" Text='<%# Eval("DateModified") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Originated By" HeaderStyle-CssClass="c5" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c5">
                <ItemTemplate>
                    <asp:Label ID="lblOriginatedBy" runat="server" Text='<%# Eval("OriginatedByName") %>' />
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Comments" HeaderStyle-CssClass="c6" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkComments" CssClass="comment_add_icon" runat="server" OnClick="lnkReference_Click" />
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>

        <PagerTemplate>

            <div class="pagination">
                <p>
                    Page
                            <asp:Literal ID="indexPage" runat="server" />
                    of
                            <asp:Literal ID="totalPage" runat="server" />
                    (<asp:Literal ID="totalItems" runat="server" />
                    items)
                </p>
                <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                <asp:LinkButton runat="server" CssClass="prev" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
            </div>

        </PagerTemplate>

        <EmptyDataTemplate>
            No data to display
        </EmptyDataTemplate>
        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
        <HeaderStyle CssClass="gradient_azul" />
    </asp:GridView>
</asp:Panel>


<asp:Panel runat="server" class="tbl" ID="pnAddNote" Visible="false">
    <asp:TextBox ID="txtTitleNote" ClientIDMode="Static" runat="server" CssClass="mB" placeholder="Type in here the title of the note" />
    <asp:TextBox ID="txtBodyNote" ClientIDMode="Static" runat="server" CssClass="wd100 hg350" placeholder="Type in here the body of the note" TextMode="MultiLine" />



                    <asp:Panel CssClass="boton_wrapper gradient_RJ bdrRJ fr mL mT10" runat="server" ID="pnlUCCancel"  ClientIDMode="Static">
                    <span class="equis"></span>
                    <asp:Button runat="server" ID="btnCancel" CssClass="boton" Text="Cancel" OnClick="btnCancel_Click" />
                </asp:Panel>

                <asp:Panel runat="server" ID="pnlRSaveBtn" CssClass="boton_wrapper gradient_vd2 bdrVd2 fr mT10">
                    <span class="save"></span>
                    <asp:Button ID="BTNSaveTabs" runat="server" Text="Save" class="boton" ClientIDMode="Static" OnClick="BTNSaveTabs_Click" OnClientClick="return ValidateRightForm();" />
                </asp:Panel>

</asp:Panel>


<div id="dvCommentInfo" style="display: none; padding: 0">
    <uc1:UCCommentInfo runat="server" ID="UCCommentInfo" />
</div>

<asp:HiddenField runat="server" ID="hfCommentInfo" ClientIDMode="Static" Value="false" />
