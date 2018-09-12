<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNotesComments.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.UCNotesComments" %>

<asp:UpdatePanel runat="server" ID="upNoteComments" ClientIDMode="Static">
    <ContentTemplate>
        <div class="ejem_note">
            <div class="cont" style="width: 100%;">
                <div class=" wd49 fl mR-2-p mB" style="display: none">
                    <label class="label">Date Started:</label>
                    <asp:TextBox ID="txtDateStarted" runat="server" CssClass="mB15" ReadOnly="true" />
                    <label class="label">Date Modified:</label>
                    <asp:TextBox ID="txtDateModified" runat="server" ReadOnly="true" />
                </div>
                <div class=" wd49 fl mB15" style="display: none">
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
                    <asp:panel runat="server" ID="pnButtonAdd" class="boton_wrapper amarillo fl">
                        <span class="add"></span>                        
                        <input class="boton" runat="server"  id="CancelNotes" type="button" ClientIDMode="Static" onclick="CancelNotesCommentPop();" value="Add Comment">
                    </asp:panel>

                    <div class="boton_wrapper rojo fr">
                        <span class="equis"></span>
                        <input type="button" id="btnClose" runat="server" ClientIDMode="Static" class="boton" onclick="return CloseNotesCommentPop();" value="Close" />
                    </div>
                </div>
                <!--// Botones -->

                <asp:Panel runat="server" ID="pnComment" Style="display: none;" ClientIDMode="Static" CssClass="row">
                    <asp:TextBox ID="txtNewComment" ClientIDMode="Static" runat="server" CssClass="hg200 mB" TextMode="MultiLine" />
                    <div class="wd100 fl hg35 m0">
                        <div class="boton_wrapper verde fl">
                            <span class="save"></span>
                            <asp:Button runat="server" ID="btnSave"  CssClass="boton" Text="Save" OnClientClick="return ValidateCommentNote();" OnClick="btnSave_Click" />
                        </div>

                        <div class="boton_wrapper rojo fl">
                            <span class="equis"></span>
                            <input type="button" id="btnCancel" ClientIDMode="Static" runat="server" class="boton" onclick="return CancelNotesCommentPop();" value="Cancel" />
                        </div>
                    </div>

                </asp:Panel>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<asp:HiddenField ID="hdnNoteId" runat="server" />
