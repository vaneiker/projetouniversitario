<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCPopRejectToReadyReview.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.DReview.WUCPopRejectToReadyReview" %>
<asp:UpdatePanel runat="server" ID="udpRejectToReadyReview" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="width: 700px;">
            <div class="content_fondo_blanco" id="frmFormRejectToReadyToReview">
                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="PolicyNumber">Policy Number</label>
                        <asp:TextBox runat="server" ID="txtPolicyNumber" ReadOnly="True" disabled />
                    </div>
                    <div>
                        <label class="label" runat="server" id="User">User</label>
                        <asp:TextBox runat="server" ID="txtUser" ReadOnly="True" disabled />
                    </div>
                    <div>
                        <label class="label" runat="server" id="InsuredName">Insured Name</label>
                        <asp:TextBox runat="server" ID="txtInsuredName" ReadOnly="True" disabled />
                    </div>
                    <div>
                        <label class="label" runat="server" id="PlanName">Plan Name</label>
                        <asp:TextBox runat="server" ID="txtPlanName" ReadOnly="True" disabled />
                    </div>
                </div>

                <div class="grupos de_1">
                    <div>
                        <label class="label  red" runat="server" id="RejectReason">Reject Reason</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddlRejectReason" validation="Required">                                
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                </div>

                <div class="grupos de_1">
                    <div>
                        <label class="label  red" runat="server" id="Comment">Comment</label>
                        <asp:TextBox runat="server" ID="txtComment" Style="height: 202px;" TextMode="MultiLine" validation="Required" />
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper verde">
                            <span class="save"></span>
                            <asp:Button runat="server" CssClass="boton" Text="Save" ID="btnReject" OnClick="btnReject_Click" OnClientClick="return validateForm('frmFormRejectToReadyToReview')" />
                        </div>
                        <div class="boton_wrapper rojo">
                            <span class="equis"></span>
                            <input type="button" class="boton" value="Cancel" runat="server" id="btnCancel" onclick="$('#dvCommentReject').dialog('close')" />
                        </div>
                    </div>
                </div>
                <!--grupos-->

            </div>
            <!--content_fondo_blanco-->
        </div>

    </ContentTemplate>
</asp:UpdatePanel>
