<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCIllustration.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation.WUCIllustration" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Panel runat="server" ID="frmIllustration" ClientIDMode="Static">
    <div class="fondo_blanco fix_height">
        <div class="titulos_azules"><span class="additional_info"></span><strong runat="server" id="Illustrations">ILLUSTRATIONS</strong></div>
        <div class="content_fondo_blanco">
            <!--grupos-->
            <div class="grid_wrap margin_t_10 gris" style="margin-top: 0px !important;">
                <dx:ASPxGridView ID="gvIllustration" runat="server"
                    EnableCallBacks="False"
                    AutoGenerateColumns="False" Width="100%" OnPreRender="gvIllustration_PreRender" 
                    OnPageIndexChanged="gvIllustration_PageIndexChanged"
                    OnPageSizeChanged="gvIllustration_PageSizeChanged"
                    OnFocusedRowChanged="gvIllustration_FocusedRowChanged"
                    KeyFieldName="CustomerPlanNo">                    
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ILLUSTRATION NUMBER" FieldName="DispIllustrationNo" VisibleIndex="0" Name="ILLUSTRATIONNUMBERLabel">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="PLAN NAME" FieldName="Product" VisibleIndex="1" Name="PlanNameLabel">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="PERIODIC PREMIUM" FieldName="PremiumAmount" VisibleIndex="2" Name="PeriodicPremium">                           
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="INSURED AMOUNT" FieldName="InsuredAmount" VisibleIndex="3" Name="InsuredAmount">                        
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior ColumnResizeMode="NextColumn" AllowFocusedRow="True" ProcessFocusedRowChangedOnServer="True" />
                    <Settings VerticalScrollableHeight="120" VerticalScrollBarMode="Visible" />
                    <SettingsPager PageSize="5" AlwaysShowPager="true">
                        <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                    </SettingsPager>
                    <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" />
                </dx:ASPxGridView>
            </div>
            <!--grid_wrap-->
        </div>
    </div>
    <!--content_fondo_blanco-->
    <!--fondo_blanco-->
</asp:Panel>
