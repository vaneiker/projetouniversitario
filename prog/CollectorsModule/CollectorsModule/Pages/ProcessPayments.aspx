<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CM.Master" AutoEventWireup="true" CodeBehind="ProcessPayments.aspx.cs" UICulture="es" Culture="es-MX" Inherits="CollectorsModule.Pages.ProcessPayments" %>

<%@ Register Src="~/Controls/ucClientSearch.ascx" TagPrefix="uc1" TagName="ucClientSearch" %>
<%@ Register Src="~/Controls/ucSetPoliciesPayments.ascx" TagPrefix="uc1" TagName="ucSetPoliciesPayments" %>
<%@ Register Src="~/Controls/ucPaymentMethod.ascx" TagPrefix="uc1" TagName="ucPaymentMethod" %>
<%@ Register Src="~/Controls/ucPaymentConfirmation.ascx" TagPrefix="uc1" TagName="ucPaymentConfirmation" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="boxes_step">
            <div class="boxes">
                <div id="step1" runat="server" class="box_btn">
                    <asp:LinkButton runat="server" ID="lnkStep1" OnClick="lnkStep1_Click">
                        <span>Buscar cliente</span>1
                        <i class="arr_ico"></i>
                    </asp:LinkButton>
                </div>
                <div id="step2" runat="server" class="box_btn">
                    <asp:LinkButton runat="server" ID="lnkStep2" OnClick="lnkStep2_Click">
                        <span>Selección de polizas a pagar</span>2
                        <i class="arr_ico"></i>
                    </asp:LinkButton>
                </div>
                <div id="step3" runat="server" class="box_btn">
                    <asp:LinkButton runat="server" ID="lnkStep3" OnClick="lnkStep3_Click">
                        <span>Procesar pago</span>3
                    </asp:LinkButton>
                </div>
            </div>
        </div>
	<br clear="all"/>
    <asp:MultiView ID="mvContentTabs" runat="server">
        <asp:View ID="vwSearchClient" runat="server">
            <uc1:ucClientSearch runat="server" id="ucClientSearch" />
        </asp:View>
        <asp:View ID="vwPoliciesPayments" runat="server">
            <uc1:ucSetPoliciesPayments runat="server" id="ucSetPoliciesPayments" />
        </asp:View>
        <asp:View ID="vwPaymentMethod" runat="server">
            <uc1:ucPaymentMethod runat="server" ID="ucPaymentMethod" />
        </asp:View>
        <asp:View ID="vwPaymentConfirmation" runat="server">
            <uc1:ucPaymentConfirmation runat="server" id="ucPaymentConfirmation" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
