<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCAddFollowUpComment.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.DReview.WUCAddFollowUpComment" %>
<asp:UpdatePanel runat="server" ID="udpAddFollowUp" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="width: 700px;" id="frmFollowUp">
            <div class="content_fondo_blanco">
                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="Policy">Policy</label>
                        <asp:TextBox runat="server" ID="txtPolicy" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="InitiatedDate">Initiated Date</label>
                        <asp:TextBox runat="server" ID="txtInitiatedDate" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="User">User</label>
                        <asp:TextBox runat="server" ID="txtUser" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="DocumentName">Document Name</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddlDocumentName">
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                </div>

                <div class="grupos de_1">
                    <div>
                        <label class="label red" runat="server" id="Comment">Comment</label>
                        <asp:TextBox runat="server" ID="txtComment" Style="height: 202px;" validation="Required" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper verde">
                            <span class="save"></span>
                            <asp:Button runat="server" CssClass="boton" Text="Save" ID="btnSave" OnClick="btnSave_Click" OnClientClick="return validateForm('frmFollowUp')" />
                        </div>
                        <div class="boton_wrapper rojo">
                            <span class="equis"></span>
                            <input class="boton" type="button" runat="server" id="btnCancel" value="Cancel" onclick="$('#dvAddFollowUpComment').dialog('close');">
                        </div>
                    </div>
                </div>
                <!--grupos-->

            </div>
            <!--content_fondo_blanco-->
        </div>

    </ContentTemplate>
</asp:UpdatePanel>
