<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCompareCases.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Compare.UCCompareCases" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<div class="fondo_gris">
    <div class="col-2-5 compare">
        <div class="fondo_blanco fix_height">
            <div class="titulos_azules"><strong><%=RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationAvailable %></strong></div>
            <div class="content_fondo_blanco overflow_hidden">
                <div class="grid_wrap">
                    <dx:ASPxGridView ID="gvIllustrationAvailable" runat="server" KeyFieldName="CustomerPlanNo" ClientIDMode="Static" DataSourceID="dsIllustrationAvailable"
                        ClientSideEvents-EndCallback="function(){configurationCompareIllustrationCheckbox();}">
                        <Columns>
                            <dx:GridViewDataCheckColumn Caption="#" VisibleIndex="0" Width="3%">
                                <DataItemTemplate>
                                    <input type="checkbox" id="chkSelect_<%# Eval("CustomerPlanNo") %>" onchange="compareIllustrationCheckedChange(this,'<%# Eval("CustomerPlanNo") %>','hdnCheckedAvailableIllustrations');" />
                                </DataItemTemplate>
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataColumn Caption="Illustration Number" Name="ILLUSTRATIONNUMBERLabel" FieldName="DispIllustrationNo" HeaderStyle-CssClass="c2" CellStyle-CssClass="c2" />
                            <dx:GridViewDataColumn Caption="Plan Name" Name="PlanName" FieldName="Product" HeaderStyle-CssClass="c3" CellStyle-CssClass="c3" />
                            <dx:GridViewDataColumn Caption="Periodic Premium" Name="PeriodicPremium" FieldName="PremiumAmount" HeaderStyle-CssClass="c4" CellStyle-CssClass="c4" />
                            <dx:GridViewDataColumn Caption="Benefit Amount" Name="BenefitAmount" FieldName="BenefitAmount" HeaderStyle-CssClass="c5" CellStyle-CssClass="c5" />
                        </Columns>
                        <SettingsPager PageSize="4" NumericButtonCount="3" />
                        <SettingsPopup>
                            <HeaderFilter Height="200" />
                        </SettingsPopup>
                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                        <Settings ShowFilterBar="Hidden" />
                    </dx:ASPxGridView>
                    <asp:ObjectDataSource ID="dsIllustrationAvailable" runat="server" SelectMethod="GetIllustration"
                        TypeName="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Compare.UCCompareCases" OnSelecting="dsIllustrationAvailable_Selecting"></asp:ObjectDataSource>
                </div>
                <!--grid_wrap-->
            </div>
            <!--content_fondo_blanco-->
        </div>
        <!--fondo_blanco-->
    </div>
    <!--col-2-5-->
    <div class="col-1-5 compare">
        <div class="fondo_blanco botones_compare fix_height">
            <div class="row">
                <div class="cell bottom">
                    <asp:Button runat="server" ID="btnAddToCompare" OnClick="btnAddToCompare_Click" CssClass="compare_green_arrow" />
                </div>
            </div>
            <div class="row">
                <div class="cell top">
                    <asp:Button runat="server" ID="btnRemoveToCompare" OnClick="btnRemoveToCompare_Click" CssClass="compare_red_arrow" />
                </div>
            </div>
        </div>
    </div>
    <!--col-1-5-->
    
    <div class="col-2-5 compare">
        <div class="fondo_blanco fix_height">
            <div class="titulos_azules"><strong><%=RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationToCompare %></strong></div>
            <div class="content_fondo_blanco overflow_hidden">
                <div class="grid_wrap">
                    <dx:ASPxGridView ID="gvIllustrationCompare" runat="server" KeyFieldName="CustomerPlanNo" ClientIDMode="Static" DataSourceID="dsIllustrationCompare"
                        ClientSideEvents-EndCallback="function(){configurationCompareIllustrationCheckbox();}">
                        <Columns>
                            <dx:GridViewDataCheckColumn Caption="#" VisibleIndex="0" Width="3%">
                                <DataItemTemplate>
                                    <input type="checkbox" id="chkSelect_<%# Eval("CustomerPlanNo") %>" onchange="compareIllustrationCheckedChange(this,'<%# Eval("CustomerPlanNo") %>','hdnCheckedCompareIllustrations');" />
                                </DataItemTemplate>
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataColumn Caption="Illustration Number" Name="ILLUSTRATIONNUMBERLabel" FieldName="DispIllustrationNo" HeaderStyle-CssClass="c2" CellStyle-CssClass="c2" />
                            <dx:GridViewDataColumn Caption="Plan Name" Name="PlanName" FieldName="Product" HeaderStyle-CssClass="c3" CellStyle-CssClass="c3" />
                            <dx:GridViewDataColumn Caption="Periodic Premium" Name="PeriodicPremium" FieldName="PremiumAmount" HeaderStyle-CssClass="c4" CellStyle-CssClass="c4" />
                            <dx:GridViewDataColumn Caption="Benefit Amount" Name="BenefitAmount" FieldName="BenefitAmount" HeaderStyle-CssClass="c5" CellStyle-CssClass="c5" />
                        </Columns>
                        <SettingsPager PageSize="4" NumericButtonCount="3" />
                        <SettingsPopup>
                            <HeaderFilter Height="200" />
                        </SettingsPopup>
                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                        <Settings ShowFilterBar="Hidden" />
                    </dx:ASPxGridView>
                    <asp:ObjectDataSource ID="dsIllustrationCompare" runat="server" SelectMethod="GetIllustration"
                        TypeName="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Compare.UCCompareCases" OnSelecting="dsIllustrationCompare_Selecting"></asp:ObjectDataSource>
                </div>
                <!--grid_wrap-->
            </div>
            <!--content_fondo_blanco-->
        </div>
        <!--fondo_blanco-->
    </div>
    <!--col-2-5-->
</div>
<!--fondo_gris-->

    <asp:HiddenField runat="server" ID="hdnCheckedAvailableIllustrations" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnCheckedCompareIllustrations" ClientIDMode="Static" />