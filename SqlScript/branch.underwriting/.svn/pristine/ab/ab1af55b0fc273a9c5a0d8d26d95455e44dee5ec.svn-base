<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCommentInfo.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.NotesComments.NoteComments" %>
<asp:UpdatePanel runat="server" ID="upNoteComments">
    <ContentTemplate>

        <div class="ejem_note ">
            <div class="cont">
                <div class=" wd49 fl mR-2-p mB">
                    <label class="label">Date Started:</label>
                    <asp:TextBox ID="txtDateStarted" runat="server" CssClass="mB15" ReadOnly="true" />
                    <label class="label">Date Modified:</label>
                    <asp:TextBox ID="txtDateModified" runat="server" ReadOnly="true" />
                </div>
                <div class=" wd49 fl mB15">
                    <label class="label">STARTED BY:</label>
                    <asp:TextBox ID="txtStarted" runat="server" CssClass="mB15" ReadOnly="true" />
                    <label class="label">LAST MODIFIED BY:</label>
                    <asp:TextBox ID="txtLastModified" runat="server" ReadOnly="true" />
                </div>
                <div class="wd100 fl">
                    <asp:TextBox ID="txtComments" runat="server" CssClass="hg200 mB" TextMode="MultiLine" ReadOnly="true" />
                </div>
                <!-- Botones -->
                <div class="wd100 fl hg35 mB">

                    <div id="dvNCNewComment" class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fl">
                        <span class="add"></span>
                        <input  class="boton" type="button" onclick="CancelNotesCommentPop();" value="Add Comment">
                    </div>

                    <div class="boton_wrapper gradient_RJ bdrRJ fr">
                        <span class="equis"></span>
                        <asp:Button runat="server" ID="btnClose" CssClass="boton" OnClientClick="return CloseNotesCommentPop();" Text="Close" />
                    </div>


                </div>
                <!--// Botones -->

                <asp:Panel runat="server" ID="pnComment" Style="display: none;" ClientIDMode="Static" CssClass="row">
                    <asp:TextBox ID="txtNewComment" ClientIDMode="Static" runat="server" placeholder="Add Comment..." CssClass="row hg180 mB" TextMode="MultiLine" />
                    <div class="wd100 fl hg35 m0">
                        <div class="boton_wrapper gradient_vd2 bdrVd2 fl mR">
                            <span class="save"></span>
                            <asp:Button runat="server" ID="btnSave" CssClass="boton" OnClick="btnSave_Click" Text="Save" OnClientClick="return ValidateCommentNote();" />
                        </div>

                        <div class="boton_wrapper gradient_RJ bdrRJ fl">
                            <span class="equis"></span>
                            <asp:Button runat="server" ID="btnCancel" CssClass="boton" OnClientClick="return CancelNotesCommentPop();" Text="Cancel" />
                        </div>
                    </div>

                </asp:Panel>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<asp:HiddenField ID="hdnNoteId" runat="server" />
