<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="History.aspx.cs" Inherits="WEB.ConfirmationCall.Pages.History" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Src="~/UserControls/Common/UCHeaderHistorico.ascx" TagPrefix="uc1" TagName="UCHeaderHistorico" %>
<%@ Register Src="~/UserControls/Common/UCLeftMenu.ascx" TagPrefix="uc1" TagName="UCLeftMenu" %>
<%@ Register Src="~/UserControls/History/UCGreetings.ascx" TagPrefix="uc1" TagName="UCGreetings" %>
<%@ Register Src="~/UserControls/History/UCNotes.ascx" TagPrefix="uc1" TagName="UCNotes" %>
<%@ Register Src="~/UserControls/History/UCAddress.ascx" TagPrefix="uc1" TagName="UCAddress" %>
<%@ Register Src="~/UserControls/History/UCEmailAndPhones.ascx" TagPrefix="uc1" TagName="UCEmailAndPhones" %>
<%@ Register Src="~/UserControls/History/UCPolicyDetails.ascx" TagPrefix="uc1" TagName="UCPolicyDetails" %>
<%@ Register Src="~/UserControls/History/UCSecurityQuestions.ascx" TagPrefix="uc1" TagName="UCSecurityQuestions" %>
<%@ Register Src="~/UserControls/History/UCAttachment.ascx" TagPrefix="uc1" TagName="UCAttachment" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
 <script src="../Scripts/JSPages/History/History.js"></script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:UpdatePanel runat="server" ID="upNoteComments">
        <ContentTemplate>
            <div class="contenido_derecha forms_mc">
                <!--wrapper de las columnas-->
                <div class="grid grid-pad">
                    <uc1:UCHeaderHistorico runat="server" ID="UCHeaderHistorico" />

                    <div class="col-1-2">

                      <div class="contenedor_tabs orange">
                            <ul class="tabs_ttle dvddo_in_2" id="MenuTabsLeft">
                                <li class="active">
                                    <asp:Button ID="btnGreetings" runat="server" OnClick="btnGreetings_Click" ClientIDMode="Static" Text="GREETINGS" Width="100%"></asp:Button>
                                </li>
                                <li>
                                    <asp:Button ID="btnEmailTelephones" runat="server" OnClick="btnEmailTelephones_Click" ClientIDMode="Static" Text="EMAILS & TELEPHONES" Width="100%"></asp:Button>
                                </li>
                            </ul>
                            <ul class="tabs_ttle dvddo_in_2">
                                <li>
                                    <asp:Button ID="btnAddress" runat="server" OnClick="btnAddress_Click" ClientIDMode="Static" Text="ADDRESS" Width="100%"></asp:Button>
                                </li>
                                <li>
                                    <asp:Button ID="btnPolicyData" runat="server" OnClick="btnPolicyData_Click" ClientIDMode="Static" Text="POLICY DETAILS" Width="100%"></asp:Button>
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
                                            <asp:Button ID="btnNextLeft" runat="server" CssClass="boton" Text="Next" OnClick="btnNextLeft_Click" />
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
                                    <asp:LinkButton runat="server" data-contacttype="1" ID="lnkOwnerInformation" OnClick="lnkContactInformation_Click" CssClass="orange-g">
                                       <div class="oma">
                                            <div class="owner_icon"></div>
                                        </div>
                                         <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Owner.ToUpper() %>
                                    </asp:LinkButton>
                                </li>
                                <li id="liInsuredInformation" runat="server">
                                    <asp:LinkButton runat="server" data-contacttype="2" ID="lnkInsuredInformation" Enabled="false" OnClick="lnkContactInformation_Click" CssClass="blue-g">
                                        <div class="oma">
                                            <div class="main_insured_icon"></div>
                                        </div>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MainInsured.ToUpper() %>
                                    </asp:LinkButton>
                                </li>
                                <li id="liAdditionalInformation" runat="server">
                                    <asp:LinkButton runat="server" data-contacttype="3" ID="lnkAdditionalInformation" Enabled="false" OnClick="lnkContactInformation_Click" CssClass="green-g">
                                        <div class="oma">
                                            <div class="medical_icon_b"></div>
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
                                    <asp:Button ID="btnSecurityQuestions" runat="server" OnClick="btnSecurityQuestions_Click" ClientIDMode="Static" Text="SECURITY QUESTIONS" Width="100%"></asp:Button>
                                </li>
                                <li class="active">
                                    <asp:Button ID="btnNotes" runat="server" OnClick="btnNotes_Click" ClientIDMode="Static" Text="NOTES" Width="100%"></asp:Button>
                                </li>
                                <li>
                                    <asp:Button ID="btnAttachments" runat="server" OnClick="btnAttachments_Click" ClientIDMode="Static" Text="ATTACHMENTS" Width="100%"></asp:Button>
                                </li>
                            </ul>
                        </div>
                        <!--contenedor_tabs-->
                        <div class="titulos_sin_accion02 text_center"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.DetailsAndComments.ToUpper() %></div>

                        <div id="divDetailsAndComments" runat="server" class="fondo_blanco fix_height">
                            <div class="content_fondo_blanco fix_height heightDetailsAndCommentsHistory">


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

                        <div class="barra_azul_celeste margin_t_15">
                            <div class="grupos">
                                <div>
                                    <table>
                                        <tr>
                                            <td><label ID="lblPolicyCountryTime">02:45PM</label></td>
                                            <td rowspan="2">
                                                <a class="phone_icon" target="_blank" href="http://www.howtocallabroad.com/"></a>
                                            </td>
                                            <td rowspan="2">
                                                <a class="agenda_icon" target="_blank" href="http://www.statetrustlife.com/?page_id=3026"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><asp:Label ID="lblPolicyCountryName" runat="server">Republica Dominicana</asp:Label></td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                            <!--grupos-->
                        </div>
                        <!--barra_azul_celeste-->
                    </div>
                    <!--col-1-2-->
                </div>
                <!--grid grid-pad-->
            </div>
            <asp:HiddenField ID="hdnCurrentCountryTime" runat="server" Value="" ClientIDMode="Static" />
            <asp:HiddenField ID="hfSelectTABLeft" runat="server" Value="btnGreetings" ClientIDMode="Static" />
            <asp:HiddenField ID="hfSelectTABRight" runat="server" Value="btnSecurityQuestions" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

