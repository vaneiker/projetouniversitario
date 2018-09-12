<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCAddComment.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.WUCAddComment" %>
<asp:UpdatePanel runat="server" ID="udpAddComment" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel runat="server" CssClass="pop_up_wrapper" Style="width: 700px;" ID="pnForm">
            <div class="content_fondo_blanco">
                <div class="grupos de_1">
                    <div>
                        <label class="label" runat="server" id="Comment">Comment</label>
                        <asp:TextBox ID="CommentTxt" ClientIDMode="Static" runat="server" TextMode="MultiLine" Style="border: solid 1px; border-color: #CFD0D1"></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper verde">
                            <span class="save"></span>
                            <asp:Button runat="server" CssClass="boton" type="submit" ID="btnSave" ClientIDMode="Static" Text="Save" OnClick="btnSaveComment_Click"
                                OnClientClick="return validaReject(this)" />
                        </div>
                        <div class="boton_wrapper rojo">
                            <span class="equis"></span>
                            <input class="boton" id="btnCancel" runat="server" type="button" value="Cancel" onclick="popRejectComment.Close()">
                        </div>
                    </div>
                </div>
                <!--grupos-->
            </div>
            <!--content_fondo_blanco-->
        </asp:Panel>
        <!--pop_up_wrapper-->
    </ContentTemplate>
</asp:UpdatePanel>
