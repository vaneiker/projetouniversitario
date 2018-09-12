<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCIllustratorPreview.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.UCIllustratorPreview" %>

<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
<div class="col-1-1">
    <div class="accordion_tabulado">
        <ul class="principal" id="acc2">
            <li>
                <a href="#" id="current"><%=RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationPreview %><span><!--icono--></span></a>
                <ul>
                    <li>
                        <div class="fondo_blanco">
                            <div class="content_fondo_blanco">
                                <iframe style="height: 580px" runat="server" id="iframeReport" frameborder="0" src="autorizaciondepagos.PDF"></iframe>
                            </div>
                            <!--content_fondo_blanco-->
                        </div>
                        <!--fondo_blanco-->

                    </li>
                </ul>
            </li>
            <!--principal-->
        </ul>
    </div>
    <!--acordeon_tabulado-->
</div>
<!--col-1-1-->

<div class="col-1-1">
    <div class="barra_sub_menu">
        <div class="grupos de_6">
            <div>
                <div class="btn_celeste">
                    <span class="sign_celeste"></span>
                    <asp:Button runat="server" ID="btnSign" CssClass="boton" OnClick="btnSign_Click" Text="Sign"/>
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="refresh_celeste"></span>
                    <asp:Button runat="server" ID="btnRefresh" CssClass="boton" OnClick="btnRefresh_Click" Text="Refresh"/>
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="customize_celeste"></span>
                    <asp:Button runat="server" ID="btnCostumize" CssClass="boton" OnClick="btnCostumize_Click" Text="Costumize"/>
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="pdf_celeste"></span>
                    <asp:Button runat="server" ID="btnDownloadPdf" CssClass="boton" OnClick="btnDownloadPdf_Click" Text="Download Pdf"/>
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="email_ilustracion"></span>
                    <asp:Button runat="server" ID="btnEmailIllustration" CssClass="boton" OnClick="btnEmailIllustration_Click" Text="E-mail Illustration"/>
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="back_celeste"></span>
                    <asp:Button runat="server" ID="btnBackToPlanInfo" CssClass="boton" OnClick="btnBackToPlanInfo_Click" Text="Back to plan info"/>
                </div>
                <!--btn_celeste-->
            </div>
        </div>
        <!--grupos-->
    </div>
    <!--barra_sub_menu-->
</div>
<!--col-1-1-->
        </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnDownloadPdf" />
    </Triggers>
</asp:UpdatePanel>