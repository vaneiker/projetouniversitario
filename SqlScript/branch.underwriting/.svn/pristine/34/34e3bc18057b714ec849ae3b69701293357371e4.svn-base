<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPopupVehicleTagConditioned.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCPopupVehicleTagConditioned" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxPopupControl ID="ppcVehicleTagConditioned" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="header" ClientInstanceName="ppcVehicleTagConditioned" AllowDragging="True"
    PopupAnimationType="None" ClientSideEvents-Closing="ClosePopup">
<ClientSideEvents Closing="ClosePopup"></ClientSideEvents>
    <ContentCollection>
        <dx:PopupControlContentControl runat="server" Width="1000px" Height="530px">
            <asp:UpdatePanel runat="server" ID="UpdatePanel3" OnUnload="UpdatePanel3_Unload">
                <ContentTemplate>
                    <div id="frmVehicleTagConditioned">
                        <article id="tbs3">
                            <div class="btn_funcion">
                                <ul class="Doc_Actions padd0">
                                    <li>
                                        <asp:LinkButton runat="server" ID="lnkPrint" CssClass="print_icon2" OnClientClick="CallPrint($('#frmVehicleTagConditioned iframe')[0]); return false;"></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton runat="server" ID="lnkSave" CssClass="save_icon2" OnClientClick="document.getElementById('btnDownloadPdf').click(); return false;"></asp:LinkButton></li>
                                </ul>
                            </div>
                            <div class="frontal">
                                <iframe id="IframeMarbete" runat="server" style="margin: 0;"></iframe>
                            </div>
                        </article>
                    </div>                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>
<asp:Button ID="btnDownloadPdf" runat="server" OnClick="btnDownloadPdf_Click" ClientIDMode="Static" Style="display: none;" />