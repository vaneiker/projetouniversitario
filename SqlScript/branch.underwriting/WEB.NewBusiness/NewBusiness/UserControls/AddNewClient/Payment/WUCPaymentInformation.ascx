<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCPaymentInformation.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Payment.WUCPaymentInformation" %>
<asp:UpdatePanel runat="server" ID="udpPaymentInformation" UpdateMode="Conditional" RenderMode="Block">
    <ContentTemplate>
        <div class="fix_height">
            <!--nivela los altos importante-->
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules"><span class="payment"></span><strong runat="server" id="PaymentInformation">PAYMENT INFORMATION</strong></div>
                <div class="content_fondo_blanco">
                    <asp:MultiView runat="server" ID="MtvPaymentInformation" ActiveViewIndex="0">
                        <asp:View runat="server" ID="VDefatul">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.Cash %>
                        </asp:View>
                        <asp:View runat="server" ID="vwACHDomicile">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.ACHDomicile %>
                        </asp:View>
                        <asp:View runat="server" ID="vwACHOneTime">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.ACHOneTime %>
                        </asp:View>
                        <asp:View runat="server" ID="vwACHStb">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.ACHStb %>
                        </asp:View>
                        <asp:View runat="server" ID="vwACHSTBDomicile">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.ACHSTBDomicile %>
                        </asp:View>
                        <asp:View ID="vwCCDomicile" runat="server">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.CCDomicile %>
                        </asp:View>
                        <asp:View ID="vwCCOneTime" runat="server">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.OneTime %>
                        </asp:View>
                        <asp:View ID="vwCheck" runat="server">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.Check %>
                        </asp:View>
                        <asp:View ID="vwWire" runat="server">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.Wire %>
                        </asp:View>
                        <asp:View ID="vwWirePromise" runat="server">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.WirePromise %>
                        </asp:View>
                        <asp:View ID="vwCash" runat="server">
                            <%=RESOURCE.UnderWriting.NewBussiness.Resources.Cash %>
                        </asp:View>
                    </asp:MultiView>
                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--end fix height para nivelar los altos importante-->
    </ContentTemplate>
</asp:UpdatePanel>



