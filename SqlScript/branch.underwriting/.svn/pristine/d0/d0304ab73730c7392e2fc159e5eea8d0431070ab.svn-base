<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPocicyPlanInformation.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCPocicyPlanInformation" %>
<%@ Register Src="ProductControls/VIDA.ascx" TagName="VIDA" TagPrefix="uc2" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/ProductControls/TERMINO.ascx" TagPrefix="uc1" TagName="TERMINO" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/ProductControls/EDUCACION.ascx" TagPrefix="uc1" TagName="EDUCACION" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/ProductControls/RETIRO.ascx" TagPrefix="uc1" TagName="RETIRO" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCPopPerzonalizedProfile.ascx" TagPrefix="uc1" TagName="UCPopPerzonalizedProfile" %>

<asp:MultiView ID="MVProducts" runat="server">
    <asp:View ID="VTermino" runat="server">
        <uc1:TERMINO runat="server" ID="TERMINO" />
    </asp:View>

    <asp:View ID="VVida" runat="server">
        <uc2:VIDA ID="VIDA1" runat="server" />
    </asp:View>

    <asp:View ID="VEducacion" runat="server">
        <uc1:EDUCACION runat="server" ID="EDUCACION" />
    </asp:View>

    <asp:View ID="VRetiro" runat="server">
        <uc1:RETIRO runat="server" ID="RETIRO" />
    </asp:View>
</asp:MultiView>
<div id="dvPopCustomProfile" style="display: none;">
    <uc1:UCPopPerzonalizedProfile runat="server" ID="UCPopPerzonalizedProfile1" />
</div>
<asp:HiddenField ID="hdnBtnProfile" ClientIDMode="Static" runat="server" />
<asp:HiddenField ID="hdnVisiblePopProfile" ClientIDMode="Static" runat="server" />




