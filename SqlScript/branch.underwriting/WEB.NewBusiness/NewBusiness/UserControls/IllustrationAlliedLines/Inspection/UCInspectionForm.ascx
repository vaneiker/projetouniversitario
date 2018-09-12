<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCInspectionForm.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.InspectionForm.UCInspectionForm" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Inspection/UCProperty.ascx" TagPrefix="uc1" TagName="UCProperty" %>

<%--<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Inspection/UCProperty.ascx" TagPrefix="uc1" TagName="UCProperty" %>--%>

<div id="scroll_2" class="st-content-inner noOverflow">
    <!--extra div para emular el left side fixed-->
    <div id="main" style="display: block;">
        <!--CONTENIDO EMPIEZA AQUI-->
        <div class="main clearfix">
            <!--CONTENIDO DERECHA-->
            <div class="contenido_derecha details_mc">
                <!--wrapper de las columnas-->
                <div class="grid grid-pad">
                    <div class="col-1-1">
                        <div class="contenedor_tabs">
                            <ul class="tabs_ttle dvddo_in_3">
                                <li class="active dos_lineas" style="width: 100%; top: 10px;">
                                    <label><%= RESOURCE.UnderWriting.NewBussiness.Resources.AlliedLinesRiskInspectionForm %></label>
                                </li>
                            </ul>
                        </div>
                        <!--contenedor_tabs-->
                        <asp:MultiView ActiveViewIndex="0" ClientIDMode="Static" ID="mvAlliedLines" runat="server">
                            <asp:View ClientIDMode="Static" ID="vwProperty" runat="server">
                                <uc1:UCProperty runat="server" ID="UCProperty1" />
                            </asp:View>
                        </asp:MultiView>
                    </div>
                    <!--col-1-1-->
                    <!--grid grid-pad-->
                </div>
                <!--contendio derecha-->
            </div>
            <!-- /main clearfix -->
        </div>
    </div>
</div>
