<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAlliedLinesDetail.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.UCAlliedLinesDetail" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Products/UCProperty.ascx" TagPrefix="uc1" TagName="UCProperty" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Products/UCNavy.ascx" TagPrefix="uc1" TagName="UCNavy" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Products/UCTransport.ascx" TagPrefix="uc1" TagName="UCTransport" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Products/UCAirPlane.ascx" TagPrefix="uc1" TagName="UCAirPlane" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Products/UCBail.ascx" TagPrefix="uc1" TagName="UCBail" %>

<div class="cont_gnl tab_pane_container rcomp mT25">
    <div class="round_blue "><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredRiskAlliedLines %></div>
    <div class="reqVehiculo">
        <asp:MultiView runat="server" ID="mtControl">
            <asp:View runat="server" ID="vPropertyDetail">
                <div class="tbl data_Gpl gvVehiculos rasegu">
                    <uc1:UCProperty runat="server" id="UCProperty" />
                </div>
            </asp:View>
            <asp:View runat="server" ID="vNavyDetail">
                <div class="tbl data_Gpl gvVehiculos rasegu">
                    <uc1:UCNavy runat="server" id="UCNavy" />
                </div>
            </asp:View>
            <asp:View runat="server" ID="vTransportDetail">
                <div class="tbl data_Gpl gvVehiculos rasegu">
                    <uc1:UCTransport runat="server" id="UCTransport" />
                </div>
            </asp:View>
            <asp:View runat="server" ID="vAirPlaneDetail">
                <div class="tbl data_Gpl gvVehiculos rasegu">
                    <uc1:UCAirPlane runat="server" id="UCAirPlane" />
                </div>
            </asp:View>
            <asp:View runat="server" ID="vBailDetail">
                <div class="tbl data_Gpl gvVehiculos rasegu">
                    <uc1:UCBail runat="server" id="UCBail" />
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</div>

