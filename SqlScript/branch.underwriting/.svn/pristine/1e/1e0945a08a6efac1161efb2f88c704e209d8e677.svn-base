<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="ConfirmationCall.aspx.cs" Inherits="WEB.ConfirmationCall.Pages.ConfirmationCall" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Src="~/UserControls/Common/UCHeader.ascx" TagPrefix="uc1" TagName="UCHeader" %>
<%@ Register Src="~/UserControls/Common/UCLeftMenu.ascx" TagPrefix="uc1" TagName="UCLeftMenu" %>
<%@ Register Src="~/UserControls/ConfirmationCall/UCGreetings.ascx" TagPrefix="uc1" TagName="UCGreetings" %>
<%@ Register Src="~/UserControls/ConfirmationCall/UCNotes.ascx" TagPrefix="uc1" TagName="UCNotes" %>
<%@ Register Src="~/UserControls/ConfirmationCall/UCAddress.ascx" TagPrefix="uc1" TagName="UCAddress" %>
<%@ Register Src="~/UserControls/ConfirmationCall/UCEmailAndPhones.ascx" TagPrefix="uc1" TagName="UCEmailAndPhones" %>
<%@ Register Src="~/UserControls/ConfirmationCall/UCPolicyDetails.ascx" TagPrefix="uc1" TagName="UCPolicyDetails" %>
<%@ Register Src="~/UserControls/ConfirmationCall/UCSecurityQuestions.ascx" TagPrefix="uc1" TagName="UCSecurityQuestions" %>
<%@ Register Src="~/UserControls/ConfirmationCall/UCAttachment.ascx" TagPrefix="uc1" TagName="UCAttachment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script src="../Scripts/JSPages/ConfirmationCall/ConfirmationCall.js"></script>
    <script src="../Scripts/Utilities/JSTools.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:UpdatePanel runat="server" ID="upNoteComments">
        <ContentTemplate>
            <div class="contenido_derecha forms_mc">
                <!--wrapper de las columnas-->
                <div class="grid grid-pad">
                    <uc1:UCHeader runat="server" ID="UCHeader" />

                    <div class="col-1-2">

                        <div class="contenedor_tabs orange">
                            <ul class="tabs_ttle dvddo_in_2" id="MenuTabsLeft">
                                <li class="active">
                                    <asp:Button ID="btnGreetings" runat="server" OnClick="btnGreetings_Click" ClientIDMode="Static" Width="100%"></asp:Button>
                                </li>
                                <li>
                                    <asp:Button ID="btnEmailTelephones" runat="server" OnClick="btnEmailTelephones_Click" ClientIDMode="Static" Width="100%"></asp:Button>
                                </li>
                            </ul>
                            <ul class="tabs_ttle dvddo_in_2">
                                <li>
                                    <asp:Button ID="btnAddress" runat="server" OnClick="btnAddress_Click" ClientIDMode="Static" Width="100%"></asp:Button>
                                </li>
                                <li>
                                    <asp:Button ID="btnPolicyDetails" runat="server" OnClick="btnPolicyDetails_Click" ClientIDMode="Static" Width="100%"></asp:Button>
                                </li>
                            </ul>
                        </div>
                        <!--contenedor_tabs-->
                        <div class="titulos_sin_accion02 text_center"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ChangesAndSecurityQuestions.ToUpper() %></div>

                        <div class="fondo_blanco fix_height">
                            <div class="content_fondo_blanco fix_height" style="min-height: 620px;">

                                <asp:MultiView ID="MVLeft" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="VGreetings" runat="server">
                                        <uc1:UCGreetings runat="server" ID="UCGreetings" />
                                    </asp:View>
                                    <asp:View ID="VEmailAndPhones" runat="server">
                                        <uc1:UCEmailAndPhones runat="server" ID="UCEmailAndPhones" />
                                    </asp:View>
                                    <asp:View ID="VAddress" runat="server">
                                        <uc1:UCAddress runat="server" ID="UCAddress" />
                                    </asp:View>
                                    <asp:View ID="VPolicyDetails" runat="server">
                                        <uc1:UCPolicyDetails runat="server" ID="UCPolicyDetails" />
                                    </asp:View>
                                </asp:MultiView>

                                <div class="grupos">
                                    <div class="float_right">
                                        <div class="boton_wrapper azul">
                                            <span class="next_icon2"></span>
                                            <asp:Button ID="btnNextLeft" runat="server" CssClass="boton" Text="" OnClick="btnNextLeft_Click" />
                                        </div>
                                    </div>
                                </div>
                                <!--grupos-->
                            </div>
                            <!--content_fondo_blanco-->
                        </div>
                        <!--fondo_blanco-->
                    </div>
                    <!--col-1-2  Inicio-->

                    <div class="col-1-2">
                        <div class="contenedor_tabs_02 margin_0">
                            <ul class="tabs_ttle dvddo_in_3">
                                <li id="liOwnerInformation" runat="server">
                                    <asp:LinkButton runat="server" data-contacttype="1" ID="lnkOwnerInformation" OnClick="lnkContactInformation_Click" OnClientClick="javascript:__doPostBack('ctl00$bodyContent$lnkOwnerInformation','')" CssClass="orange-g">
                                        <div class="oma">
                                            <div id="ownericon" class="owner_icon" runat="server"></div>
                                        </div>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Owner.ToUpper() %>
                                    </asp:LinkButton>
                                </li>
                                <li id="liInsuredInformation" runat="server">
                                    <asp:LinkButton runat="server" data-contacttype="2" ID="lnkInsuredInformation" Enabled="false" OnClick="lnkContactInformation_Click" OnClientClick="javascript:__doPostBack('ctl00$bodyContent$lnkInsuredInformation','')" CssClass="orange-g">
                                        <div class="oma">
                                            <div id="maininsuredicon" class="owner_icon" runat="server"></div>
                                        </div>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MainInsured.ToUpper() %>
                                    </asp:LinkButton>
                                </li>
                                <li id="liAdditionalInformation" runat="server">
                                    <asp:LinkButton runat="server" data-contacttype="3" ID="lnkAdditionalInformation" Enabled="false" OnClick="lnkContactInformation_Click" OnClientClick="javascript:__doPostBack('ctl00$bodyContent$lnkAdditionalInformation','')" CssClass="orange-g">
                                        <div class="oma">
                                            <div id="addinsuredicon" class="owner_icon" runat="server"></div>
                                        </div>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AdditionalInsured.ToUpper() %>
                                    </asp:LinkButton>
                                </li>
                            </ul>
                            <!--grupos-->
                        </div>
                        <!--barra_azul_celeste-->

                        <div class="contenedor_tabs margin_0">
                            <ul class="tabs_ttle dvddo_in_3" id="MenuTabsRight">
                                <li>
                                    <asp:Button ID="btnSecurityQuestions" runat="server" OnClick="btnSecurityQuestions_Click" ClientIDMode="Static" Width="100%"></asp:Button>
                                </li>
                                <li class="active">
                                    <asp:Button ID="btnNotes" runat="server" OnClick="btnNotes_Click" ClientIDMode="Static" Width="100%"></asp:Button>
                                </li>
                                <li>
                                    <asp:Button ID="btnAttachments" runat="server" OnClick="btnAttachments_Click" ClientIDMode="Static" Width="100%"></asp:Button>
                                </li>
                            </ul>
                        </div>
                        <!--contenedor_tabs-->
                        <div class="titulos_sin_accion02 text_center"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.DetailsAndComments.ToUpper() %></div>

                        <div id="divDetailsAndComments" runat="server" class="fondo_blanco fix_height">
                            <div class="content_fondo_blanco fix_height heightDetailsAndComments">
                                <asp:MultiView ID="MVRigth" runat="server" ActiveViewIndex="1">
                                    <asp:View ID="VNotes" runat="server">
                                        <uc1:UCNotes runat="server" ID="UCNotes" />
                                    </asp:View>
                                    <asp:View ID="VSecurityQuestions" runat="server">
                                        <uc1:UCSecurityQuestions runat="server" ID="UCSecurityQuestions" />
                                    </asp:View>
                                    <asp:View ID="VAttachment" runat="server">
                                        <uc1:UCAttachment runat="server" ID="UCAttachment" />
                                    </asp:View>
                                </asp:MultiView>
                            </div>
                            <!--content_fondo_blanco-->
                        </div>
                        <!--fondo_blanco-->

                        <!---pop warnig -->
                        <div id="dialog-form" title="" style="display: none;">
                            <div id="dialog-form-content">
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PopupProvideReason %></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Reason %>:</label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="TxtReason" ClientIDMode="Static" Style="border: solid 1px #c6c6c6 !important;" runat="server" TextMode="MultiLine" Height="90"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="float_right">
                                                <div class="boton_wrapper verde float_right">
                                                    <span class="save"></span>
                                                    <asp:Button class="boton" ID="BtnOK" runat="server" Text="OK" OnClick="BtnOK_Click" OnClientClick="return onBtnOK_Click();" />
                                                </div>
                                            </div>
                                            <div class="float_right">
                                                <div class="boton_wrapper gris float_right">
                                                    <span class="borrar"></span>
                                                    <asp:Button class="boton" ID="BtnCancel" runat="server" Text="Cancel" OnClientClick="return btnCancel_Click();" />
                                                </div>
                                            </div>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!---pop warnig -->

                        <!---pop faild -->
                        <div id="dialog-form-faild" title="" style="display: none;">
                            <div id="dialog-form-faild-content">
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <label class="label" id="lblFailComunication"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="float_right">
                                                <div class="boton_wrapper verde float_right">
                                                    <span class="save"></span>
                                                    <asp:Button class="boton" ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" OnClientClick="return onBtnYes_Click();" />
                                                </div>
                                            </div>
                                            <div class="float_right">
                                                <div class="boton_wrapper gris float_right">
                                                    <span class="borrar"></span>
                                                    <asp:Button class="boton" ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" OnClientClick="return btnNo_Click();" />
                                                </div>
                                            </div>
                                            <asp:HiddenField ID="hfYesOrNo" ClientIDMode="Static" runat="server" Value="Yes" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!---pop faild -->

                        <!---pop dialog file -->
                        <%--<div id="dialog-file" title="<%= RESOURCE.UnderWriting.ConfirmationCall.Resources.UploadedDocuments.ToUpper() %>" style="display: none; width: 900px; height: 500px;">
                            <div id="dialog-file-content" title="" style="width: 900px; height: 500px;">
                                <iframe id="iframeShowDocument" runat="server" width="900" height="500" class="FrameClass"></iframe>
                            </div>
                        </div>--%>
                        <!---pop dialog file -->

                        <div class="barra_azul_celeste margin_t_15">
                            <div class="grupos de_2">
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Action %>:</label>
                                    <div class="wrap_select">
                                        <asp:DropDownList ID="drpAction" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="drpAction_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div>
                                    <table>
                                        <tr>
                                            <td>
                                                <label id="lblPolicyCountryTime">02:45PM</label>
                                            </td>
                                            <td rowspan="2">
                                                <a class="phone_icon" target="_blank" href="http://www.howtocallabroad.com/"></a>
                                            </td>
                                            <td rowspan="2">
                                                <a class="agenda_icon" target="_blank" href="http://www.atlantica.do/"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPolicyCountryName" runat="server">Republica Dominicana</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <!--grupos-->
                        </div>
                        <!--barra_azul_celeste-->
                        <div class="barra_sub_menu margin_t_5">
                            <div class="grupos de_3">
                                <div class="float_right">
                                    <div class="btn_celeste">
                                        <span class="save_celeste"></span>
                                        <asp:Button ID="btnSubmit" ClientIDMode="Static" class="boton" runat="server" OnClick="btnSubmit_Click" OnClientClick="return onSubmit_Click();" />
                                    </div>
                                    <!--btn_celeste-->
                                </div>
                            </div>
                            <!--grupos-->
                        </div>
                        <!--barra_sub_menu-->
                    </div>
                    <!--col-1-2-->
                </div>
                <!--grid grid-pad-->
            </div>

            <%--<dx:ASPxPopupControl ID="ppcShowDocument" ClientInstanceName="ppcShowDocument" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="True"
                PopupAnimationType="None" Width="900px" Height="800px" HeaderText="">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server" Width="800px" Height="500px">
                        <%--<iframe id="iframeShowDocument" width="900" height="500" class="FrameClass"></iframe>
                    </dx:PopupControlContentControl>
                </ContentCollection> 
            </dx:ASPxPopupControl>--%>
            <asp:HiddenField ID="hfApplyStatus" ClientIDMode="Static" runat="server" Value="" />
            <asp:HiddenField ID="hfSendEmailClient" ClientIDMode="Static" runat="server" Value="" />
            <asp:HiddenField ID="hfMensaje" ClientIDMode="Static" runat="server" Value="" />
            <asp:HiddenField ID="hdnPlanType" runat="server" Value="" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnCurrentAction" runat="server" Value="" ClientIDMode="Static" />
            <asp:HiddenField ID="HDFItbis" runat="server" Value="" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnCurrentCountryTime" runat="server" Value="" ClientIDMode="Static" />
            <asp:HiddenField ID="hfSelectTABLeft" runat="server" Value="btnGreetings" ClientIDMode="Static" />
            <asp:HiddenField ID="hfSelectTABRight" runat="server" Value="btnSecurityQuestions" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <!---pop dialog file -->
    <div id="dialog-file" title="<%= RESOURCE.UnderWriting.ConfirmationCall.Resources.UploadedDocuments.ToUpper() %>" style="display: none; width: 900px; height: 500px;">
        <div id="dialog-file-content" title="" style="width: 900px; height: 500px;">
            <%--<iframe id="iframeShowDocument" runat="server" width="900" height="500" class="FrameClass"></iframe>--%>         
        </div>
    </div>
    <!---pop dialog file -->

</asp:Content>
