<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCAddNewNotePopup.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.DReview.WUCAddNewNotePopup" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" ID="udpAddNewNotePopup" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="width: 700px;">
            <div class="content_fondo_blanco" id="dvDRAddNewNote">

                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="PolicyNumber">Policy Number</label>
                        <asp:TextBox runat="server" ID="txtPolicyNumber" ReadOnly="True" disabled/>
                    </div>
                    <div>
                        <label class="label" runat="server" id="User">User</label>
                        <asp:TextBox runat="server" ID="txtUser" ReadOnly="True" disabled/>
                    </div>
                    <div>
                        <label class="label" runat="server" id="InsuredName">Insured Name</label>
                        <asp:TextBox runat="server" ID="txtInsuredName" ReadOnly="True" disabled/>
                    </div>
                    <div>
                        <label class="label" runat="server" id="PlanName">Plan Name</label>
                        <asp:TextBox runat="server" ID="txtPlanName" ReadOnly="True" disabled/>
                    </div>
                </div>

                <div class="grupos de_1">
                    <div>
                        <label class="label" runat="server" id="SendTo">Send To</label>
                        <div>
                            <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" CssClass="selectDX" ID="ddlCheckComboBox" runat="server" Width="678px" AnimationType="None" ReadOnly="true" Style="z-index: 12000;">
                                <DropDownWindowStyle BackColor="#EDEDED" />
                                <DropDownWindowTemplate>
                                    <dx:ASPxListBox Width="667" ID="ddlSendTo" ClientInstanceName="checkListBox" SelectionMode="CheckColumn"
                                        runat="server" Style="z-index: 12000;" TextField="NoteReferenceTypeDesc" ValueField="NoteReferenceTypeId">
                                        <Border BorderStyle="None" />
                                        <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                        <ClientSideEvents SelectedIndexChanged="OnListBoxSelectionChanged" />
                                    </dx:ASPxListBox>
                                </DropDownWindowTemplate>
                                <ClientSideEvents TextChanged="SynchronizeListBoxValues" DropDown="SynchronizeListBoxValues" />
                            </dx:ASPxDropDownEdit>
                        </div>
                        <!--wrap_select-->
                    </div>
                </div>
                <div class="grupos de_1">
                    <div>
                        <label class="label  red" runat="server" id="Note">Note</label>
                        <asp:TextBox runat="server" ID="txtNote" TextMode="MultiLine" Style="height: 202px;" validation="Required"></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper azul">
                            <span class="send"></span>
                            <asp:Button CssClass="boton" Text="Send" runat="server" ID="btnSend" OnClick="btnSend_Click" OnClientClick="return validateForm('dvDRAddNewNote')" />
                        </div>
                        <div class="boton_wrapper rojo">
                            <span class="equis"></span>
                            <input type="button" class="boton" runat="server" value="Cancel" id="btnCancel" onclick="$('#dvAddNote').dialog('close')" />
                        </div>
                    </div>
                </div>
                <!--grupos-->

            </div>
            <!--content_fondo_blanco-->
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

