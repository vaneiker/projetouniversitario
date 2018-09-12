<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPopupChangeStatusSaveNotes.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.UCPopupChangeStatusSaveNotes" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" ID="UpdatePanel2" OnUnload="UpdatePanel_Unload">
    <ContentTemplate>
        <dx:ASPxPopupControl ID="ppcChangeStatusIllustrations" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="ppcChangeStatusIllustrations" AllowDragging="True"
            PopupAnimationType="None" ClientSideEvents-Closing="ClosePopup">
            <ClientSideEvents Closing="ClosePopup" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="pccStatus" runat="server" Width="600px" Height="620px">
                    <div id="frmStatusToSubmit" class="barra_sub_menu divStatusNotes" style="overflow: auto !important; height: auto">
                        <div class="grupos">
                            <span id="lblStatusMessage" class="label backgroundtransparent"></span>

                            <asp:Label runat="server" ID="lblStatus" ClientIDMode="Static" CssClass="label backgroundtransparent"></asp:Label>

                            <asp:UpdatePanel runat="server" ID="UpdatePanel100" OnUnload="UpdatePanel_Unload" style="width: 100%">
                                <ContentTemplate>
                                    <div id="divStatus" class="wrap_select">
                                        <asp:DropDownList
                                            AutoPostBack="true"
                                            ClientIDMode="Static"
                                            ID="drpStatusQuotation"
                                            OnSelectedIndexChanged="drpStatusQuotation_SelectedIndexChanged"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="drpStatusQuotation" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div id="divVehiclesToInspection" style="display: none">
                                <asp:Repeater ID="rptVehicles" runat="server" Visible="false">
                                    <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <th class="dxgvHeader_DevEx" style="min-width: 150px !important;"><span style="color: #fff"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Vehicle %></span></th>
                                                <th class="dxgvHeader_DevEx" style="min-width: 135px !important;"><span style="color: #fff"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Select %></span></th>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><span><%# Eval("Vehicle") %></span>
                                                <asp:TextBox ID="txtVehicleUniqueId" Visible="false" Text='<%# Eval("VehicleUniqueId") %>' runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbVehicle" CssClass="cbkVehicle" Checked='<%# Eval("Inspection") %>' runat="server" />
                                            </td>

                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>

                                <div id="divInspectors" style="margin-left: -5px; width: 590px;">
                                    <asp:Label runat="server" ID="lblInspector" ClientIDMode="Static" CssClass="label backgroundtransparent"> Inspector </asp:Label>
                                    <div class="wrap_select">
                                        <asp:DropDownList runat="server" ID="drpInspectors" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div id="divDocumentos" style="margin-left: -5px; width: 600px; display: none;">
                                <asp:Label runat="server" ID="lblDocumentos" ClientIDMode="Static" CssClass="label backgroundtransparent"> Documento: </asp:Label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="drpDocumentos" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                            </div>

                            <asp:Panel ID="divReason" runat="server" Style="margin-left: -5px; width: 600px; display: none" ClientIDMode="Static">
                                <asp:Label runat="server" ID="lblReason" ClientIDMode="Static" CssClass="label backgroundtransparent"></asp:Label>
                                <div id="divReasonDeclined" class="wrap_select">
                                    <asp:DropDownList runat="server" ID="drpReasonDeclined" style="width: 568px;" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                            </asp:Panel>

                            <div id="divListPolicies" style="height: auto !important; margin-top: 10px;">
                                <table>
                                    <thead>
                                        <tr>
                                            <th class="dxgvHeader_DevEx"></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>

                            <div id="divNoteReason">
                                <asp:Label runat="server" ID="lblNoteReason" ClientIDMode="Static" CssClass="label backgroundtransparent"></asp:Label>
                            </div>

                            <asp:TextBox runat="server" ID="txtReasonPending" TextMode="MultiLine" Rows="6" ClientIDMode="Static"></asp:TextBox>

                            <div class="btn_celeste">
                                <span class="submit_celeste"></span>
                                <asp:Button runat="server" ID="btnChangeStatus" ClientIDMode="Static" CssClass="boton" OnClick="btnChangeStatus_Click" OnClientClick="return ChangeIllustrationStatusClick();" Text="Change Status" />
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField runat="server" ID="hdnButtonSelected" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hdnListDeniedReasonOther" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hdnListDeniedReasonVehicle" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hdnIllustrationStatus" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hdnTab" ClientIDMode="Static" />
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
       <asp:HiddenField runat="server" ID="hdnMissingInspection" Value="false" />
        <asp:Button runat="server" ID="btnExceuteStatusQuotationChanged" OnClick="drpStatusQuotation_SelectedIndexChanged" ClientIDMode="Static" style="display:none"/>
        <dx:ASPxPopupControl ID="ppcNotes" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="ppcNotes" AllowDragging="True"
            PopupAnimationType="None" ClientSideEvents-Closing="ClosePopup">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server" Width="500px" Height="500px">
                    <div id="frmNotes" class="barra_sub_menu">
                        <div id="divLstNotes" style="border: 1px solid #4472C4; border-radius: 5px; padding-top: 10px;">
                            <asp:Repeater runat="server" ID="rpNotes">
                                <ItemTemplate>
                                    <div>-<%#Eval("Note") %></div>
                                    <br>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="grupos">
                            <label id="lblNote" class="label" runat="server"></label>
                            <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                            <div class="btn_celeste">
                                <span class="submit_celeste"></span>
                                <asp:Button runat="server" ID="btnSaveNotes" ClientIDMode="Static" CssClass="boton" OnClick="btnSaveNotes_Click" OnClientClick="return validateForm('frmNotes');" Text="Save Notes" />
                            </div>
                        </div>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </ContentTemplate>
</asp:UpdatePanel>
