<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUploadDocumentOfPayments.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCUploadDocumentOfPayments" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCUploadPaymentDocumentPopUp.ascx" TagPrefix="uc1" TagName="UCUploadPaymentDocumentPopUp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="content_fondo_blanco">
    <div class="grid_wrap margin_t_10 gris">
        <asp:UpdatePanel runat="server" ID="udpForOfPayment" UpdateMode="Conditional">
            <ContentTemplate>
                <dx:ASPxGridView ID="gvFormOfPayment" runat="server"
                    KeyFieldName="PaymentDetId;PaymentId;DocumentId;DocumentTypeId;DocumentCategoryId;PaymentStatusId"
                    EnableCallBacks="False"
                    AutoGenerateColumns="False"
                    SettingsPager-PageSize="3"
                    Width="100%" OnRowCommand="gvFormOfPayment_RowCommand" OnPageIndexChanged="gvFormOfPayment_PageIndexChanged" ClientIDMode="Static" OnPreRender="gvFormOfPayment_PreRender">
                    <SettingsPager PageSize="3">
                    </SettingsPager>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Payment Documentation" FieldName="PaymentDocumentation" VisibleIndex="0" Name="PaymentDocumentation">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataColumn Caption="Preview" VisibleIndex="10" Name="Preview">
                            <DataItemTemplate>
                                <asp:UpdatePanel ID="udpUpload" runat="server" RenderMode="Inline">
                                    <ContentTemplate>
                                        <asp:LinkButton runat="server" CssClass='<%# ((((int?)Eval("DocumentId"))!=null) ? "pulse pdf_ico": "pulse upload_file") %>' ID="btnUploadFile" CommandName="Upload"></asp:LinkButton>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnUploadFile" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>

                        <%--Bmarroquin 13-03-2017 Nuevo campo para orientar a usuario con las tarjetas alternativas que puedan ingresar--%>
                        <dx:GridViewDataColumn Caption="DESCRIPCION" VisibleIndex="9" Name="DESCRIPCION">
                            <DataItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<%#  Eval("OtherDescription") %>'></asp:Label>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>

                        <dx:GridViewDataColumn Caption="Edit" VisibleIndex="13" Name="Edit">
                            <DataItemTemplate>
                                <asp:UpdatePanel ID="udpEditView" runat="server" RenderMode="Inline">
                                    <ContentTemplate>
                                        <%--Bmarroquin 09-03-2017 Cambio dado que el icono Edit no estaba visualizandose--%>
                                        <%--<asp:LinkButton runat="server" ID="lnkEditView" CssClass='<%# ((((int?)Eval("PaymentStatusId"))==1) ? "view_file": "edit_file") %>' CommandName="Modify"></asp:LinkButton>--%>
                                        <asp:LinkButton runat="server" ID="lnkEditView" CssClass="edit_file" CommandName="Modify"></asp:LinkButton>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="lnkEditView" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Delete" VisibleIndex="14" Name="DELETE">
                            <DataItemTemplate>
                                <asp:UpdatePanel ID="udpDelete" runat="server" RenderMode="Inline">
                                    <ContentTemplate>
                                       <%--Bmarroquin 09-03-2017 Cambio dado que el boton borrar no estaba funcionando--%>
                                       <%--<asp:Button ID="btnDelete" runat="server"
                                            CssClass='<%# ((((int?)Eval("PaymentStatusId"))==1) ? "delete_grids_gris": "delete_file") %>'
                                            CommandName='<%# ((((int?)Eval("PaymentStatusId"))==1) ? "": "Delete") %>'
                                            alt='<%# ((((int?)Eval("PaymentStatusId"))==1) ? ObjServices.Language == WEB.NewBusiness.Common.Utility.Language.en?"Delete payment is disabled":"La opción de borrar pago esta deshabilitada": ObjServices.Language == WEB.NewBusiness.Common.Utility.Language.en?"Delete Payment":"Borrar Pago") %>'
                                            OnClientClick='<%# ((((int?)Eval("PaymentStatusId"))==1) ? "return false;": "return DlgConfirm(this)") %>' />--%>
                                        <asp:Button ID="btnDelete" runat="server"
                                            CssClass = "delete_file"
                                            CommandName = "Delete"
                                            alt='<%# (ObjServices.Language == WEB.NewBusiness.Common.Utility.Language.en?"Delete Payment Information":"Borrar Informacion de Pago") %>'
                                            OnClientClick= "return DlgConfirm(this)" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                    </Columns>
                    <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" AllowFocusedRow="true" />
                </dx:ASPxGridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvFormOfPayment" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>

<asp:Button ID="btnShowPopup" Style="display: none" runat="server" Text="ShowPopup" />
<asp:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="pdfUploadPanel" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="btnShowPopup" BehaviorID="popupBhvr" runat="server"></asp:ModalPopupExtender>
<asp:Panel runat="server" ID="pdfUploadPanel" CssClass="modalPopup" ClientIDMode="Static">
    <uc1:UCUploadPaymentDocumentPopUp runat="server" ID="UCUploadPaymentDocumentPopUp" />
</asp:Panel>

<asp:HiddenField ID="hdfUploadPaymentPopUp" Value="false" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdfPaymentDetailId" runat="server" ClientIDMode="Static" />


