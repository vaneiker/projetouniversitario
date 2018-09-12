<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCompareContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Compare.UCCompareContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/Compare/UCCompareCases.ascx" TagPrefix="uc1" TagName="UCCompareCases" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/Compare/UCComparePreview.ascx" TagPrefix="uc1" TagName="UCComparePreview" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCHeaderIllustrationInformation.ascx" TagPrefix="uc1" TagName="UCHeaderIllustrationInformation" %>
<div class="titulos_sin_accion">COMPARE ILLUSTRATION</div>
<div class="barra1">
    <div class="grupos de_4">
        <div>
            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.FirstNameLabel %></label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        </div>
        <div>
            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MiddleNameLabel %></label>
            <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
        </div>
        <div>
            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.LastNameLabel %></label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        </div>
        <div>
            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.SecondLastNameLabel %></label>
            <asp:TextBox ID="txtScndLastName" runat="server"></asp:TextBox>
        </div>
    </div>
    <!--grupos-->
</div>
<!--barra1-->
<asp:MultiView runat="server" ID="mvComparer" ActiveViewIndex="0">
    <asp:View runat="server" ID="vCompare">
        <uc1:UCCompareCases runat="server" ID="UCCompareCases" />
        <div class="titulos_sin_accion"><%=RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationPreview %></div>
        <div class="fondo_gris">
            <asp:Repeater runat="server" ID="rpIllustrationPreview" OnItemDataBound="rpIllustrationPreview_ItemDataBound">
                <ItemTemplate>
                    <uc1:UCComparePreview runat="server" ID="UCComparePreview1" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <uc1:UCComparePreview runat="server" ID="UCComparePreview1" />
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </asp:View>
    <asp:View runat="server" ID="vPreview">

        <div class="col-1-1">
            <div class="accordion_tabulado">
                <ul class="principal" id="acc2">
                    <li>
                        <a href="" id="current"><%=RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationPreview %><span><!--icono--></span></a>
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
        <!--fondo_gris-->
    </asp:View>
</asp:MultiView>

<div class="col-1-1">
    <div class="barra_sub_menu">
        <div class="grupos de_3">
            <div>
                <div class="btn_celeste">
                    <span class="pdf_celeste"></span>
                    <asp:Button runat="server" ID="btnCompare" OnClick="btnCompare_Click" CssClass="boton" />
                    <asp:Button runat="server" ID="btnViewPdf" OnClick="btnViewPdf_Click" CssClass="boton" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="email_ilustracion"></span>
                    <asp:Button runat="server" ID="btnEmailIllustration" OnClick="btnEmailIllustration_Click" CssClass="boton" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="back_celeste"></span>
                    <asp:Button runat="server" ID="btnBackToPlanInfo" OnClick="btnBackToPlanInfo_Click" Text="Back to plan info" CssClass="boton" />
                </div>
                <!--btn_celeste-->
            </div>
        </div>
        <!--grupos-->
    </div>
    <!--barra_sub_menu-->
</div>
<!--col-1-1-->
