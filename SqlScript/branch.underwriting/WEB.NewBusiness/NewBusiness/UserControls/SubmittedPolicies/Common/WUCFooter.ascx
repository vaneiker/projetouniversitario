<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCFooter.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies.Common.WUCFooter" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div class="col-1-1">
    <div class="barra_sub_menu">
        <div class="grupos de_2_b last">
            <div class="leyenda">
                <span runat="server" id="SelectionGridMessage">To select a record, click the checkbox in the corresponding row . To select the full list , click on the top checkbox column.
                </span>
            </div>
            <div class="grupos de_2">
                <div>
                    <div class="btn_celeste">
                        <span class="print_list_celeste"></span>
                        <asp:Button runat="server" ID="btnExport" CssClass="boton" Text="EXPORT TO EXCEL" OnClick="btnExport_Click" OnClientClick="return ConfirmPrintList(this)"/>
                    </div>
                    <!--btn_celeste-->
                </div>
            </div>
        </div>
        <!--grupos-->
    </div>
    <!--barra_sub_menu-->
</div>
