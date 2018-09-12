<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCCompareEdit.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.DReview.WUCCompareEdit" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" ID="udpCompareEdit">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="width: 700px;">
            <div class="titulos_azules">
                <input type="button" id="CloseCompareEdit" class="close_pop_up" onclick="$find('popupBhvr1').hide(); $('#hdnShowCompareEdit').val('false');">
                <strong runat="server" id="CompareEdit">COMPARE EDIT</strong>
            </div>
            <!--titulos_azules-->

            <div class="content_fondo_blanco">
                <div class="grupos de_3">
                    <div>
                        <label class="label" runat="server" id="PolicyNumber">Policy Number</label>
                        <asp:TextBox runat="server" ID="txtPolicyNumber" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="InsuredName">Insured Name</label>
                        <asp:TextBox runat="server" ID="txtInsuredName" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                </div>

                <div class="margin_t_15">
                    <dx:ASPxGridView ID="gvCompareEdit" runat="server"
                        ClientIDMode="Static" OnRowCommand="gvCompareEdit_RowCommand"
                        KeyFieldName="CorpId ;
                              RegionId ;
                              CountryId ;
                              DomesticregId ;
                              StateProvId ;
                              CityId ;
                              OfficeId ;
                              CaseSeqNo ;
                              HistSeqNo ;
                              ContactId ;
                              OwnerContactId ;
                              InsuredContactId ;
                              AddInsuredContactId ;
                              FunctionalitySeqNo;
                              DesignatedPensionerContactId ;
                              StudentContactId ;
                              RequirementCatId ;
                              RequirementTypeId ;
                              RequirementId ;
                              RequirementDocId ;
                              DocTypeId ;
                              DocCategoryId ;
                              DocumentId ;
                              TabDesc ;
                              LastUpdate ;
                              IsReviewed ;
                              PaymentId;
                              PaymentDetId ;
                              AgentId;
                              ProjectId ;
                              TabId ;
                              FunctionalityId ;
                              NameDesc ;
                              ProductNameKey;
                              UserId"
                        DataSourceID="LinqDS" OnAfterPerformCallback="gvCompareEdit_AfterPerformCallback" OnPreRender="gvCompareEdit_PreRender" Width="100%" AutoGenerateColumns="False">
                        <Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />
                        <ClientSideEvents EndCallback="function(){$('#gvCompareEdit_DXFREditorcol4').hide(); EndRequestHandler(); setIconDatePicker();}" />
                        <Columns>
                            <dx:GridViewDataColumn Caption="DOCUMENT" FieldName="NameDesc" VisibleIndex="0" Name="Document"/>
                            <dx:GridViewDataColumn Caption="DATA TAB" FieldName="TabDesc" VisibleIndex="1" NAME="DataTab"/>
                            <dx:GridViewDataColumn Caption="LAST UPDATE" FieldName="LastUpdate" VisibleIndex="2" Name="LastUpdate"/>
                            <dx:GridViewDataColumn Caption="COMPARE EDIT" VisibleIndex="3" Name="COMPAREEDIT">
                                <DataItemTemplate>
                                    <asp:Button runat="server" CssClass="compare_edit" CommandName="compare_edit" ID="btnCompareEdit" OnClientClick="$('#CloseCompareEdit').click();" />
                                </DataItemTemplate>
                                <Settings AllowHeaderFilter="False" AllowSort="False" />
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="REVIEWED" VisibleIndex="4" Name="REVIEWED" FieldName="IsReviewed">
                                <DataItemTemplate>
                                    <asp:Button runat="server" CssClass='<%#bool.Parse(Eval("IsReviewed").ToString())?"check_file":"" %>' ID="btnReviewed" OnClientClick="return false" />
                                </DataItemTemplate>
                                <Settings AllowHeaderFilter="False" AllowSort="True" ShowFilterRowMenu="False"/>
                            </dx:GridViewDataColumn>
                        </Columns>
                        <SettingsBehavior ColumnResizeMode="NextColumn" />
                        <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                        <SettingsPager PageSize="15" AlwaysShowPager="true">
                        </SettingsPager>
                        <SettingsPopup>
                            <HeaderFilter Height="200" />
                        </SettingsPopup>
                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                    </dx:ASPxGridView>
                    <dx:LinqServerModeDataSource OnSelecting="LinqDS_Selecting" ID="LinqDS" runat="server" DefaultSorting="TabDesc"/>
                </div>
                <!--grid_wrap--> 
                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper rojo">
                            <span class="equis"></span>
                            <input type="button" class="boton" runat="server" id="btnClose" onclick="$find('popupBhvr1').hide(); $('#hdnShowCompareEdit').val('false');" value="Close">
                        </div>
                    </div>
                </div>
                <!--grupos-->
            </div>
            <!--content_fondo_blanco-->
        </div>
        <asp:Button runat="server" ID="btnRefreshHiddenField" ClientIDMode="Static" OnClick="btnRefreshHiddenField_Click" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvCompareEdit" />
        <asp:AsyncPostBackTrigger ControlID="btnRefreshHiddenField" />
    </Triggers>
</asp:UpdatePanel>



