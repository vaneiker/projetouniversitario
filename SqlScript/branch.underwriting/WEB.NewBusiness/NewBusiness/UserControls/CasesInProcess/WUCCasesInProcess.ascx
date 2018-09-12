<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCCasesInProcess.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.CasesInProcess.WUCCasesInProcess" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/UCNotesComments.ascx" TagPrefix="uc1" TagName="UCNotesComments" %>
<asp:UpdatePanel ID="udpCasesInProcess" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <div id="scroll_2" class="st-content-inner">
            <!--extra div para emular el left side fixed-->
            <!--CONTENIDO EMPIEZA AQUI-->
            <div class="main clearfix">
                <!--CONTENIDO DERECHA-->
                <div class="management_mc">
                    <!--wrapper de las columnas-->
                    <div class="grid grid-pad">
                        <div class="col-1-1">
                            <div class="titulos_sin_accion" runat="server" id="CasesInProcess">CASES IN PROCESS</div>
                            <div class="fondo_gris">
                                <div class="col-1-1">
                                    <div class="content_fondo_gris">
                                        <div class="grid_wrap">
                                            <div class="contenedor_tabs" style="margin-bottom: 0;">
                                                <ul class="tabs_ttle dvddo_in_7 lineBussines">
                                                    <li class="liPuntoVenta">
                                                        <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkAuto" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkAuto_Click">
                                <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-auto.png" />
                                <strong>Autos</strong>                                                          
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li class="liPuntoVenta encurso">
                                                        <asp:LinkButton Style="padding: 0;" runat="server" ID="lkLife" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lkLife_Click"> 
                                <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-vida.png" />
                                <strong>Vida & Funerarios</strong>  
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li class="liPuntoVenta">
                                                        <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkHealth" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkHealth_Click"> 
                                <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-salud.png" />
                                <strong>Salud Internacional</strong>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li class="liPuntoVenta">
                                                        <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkVivienda" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkVivienda_Click">
                               <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-lcomerciales.png" />
                               <strong>Propiedad & Líneas Generales</strong>
                                                        </asp:LinkButton>
                                                    </li>
                              <%--                      <li class="liPuntoVenta">
                                                        <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkEspeciales" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkLineaAleada_Click">
                              <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-lespeciales.png" />
                              <strong>Líneas de <br>Especialidad</strong>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li class="liPuntoVenta">
                                                        <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkLineaAleada" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkLineaAleada_Click">
                                <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-lcomerciales.png" />
                                <strong>Lineas <br>Comerciales</strong>
                                                        </asp:LinkButton>
                                                    </li> 
                                       <li class="liPuntoVenta">
                                                        <asp:LinkButton Style="padding: 0;" runat="server" ID="lkFunerario" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lkLife_Click">
                              <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-servicios.png" />
                                <strong>Servicios <br>Funerarios</strong>
                                                        </asp:LinkButton>
                                                    </li>--%>
                                                </ul>
                                            </div>
                                             
                                            <dx:ASPxGridView ID="gvCasesInProcess" OnAfterPerformCallback="gvCasesInProcess_AfterPerformCallback"
                                                KeyFieldName="OwnerContactId;
                                                              CaseSeqNo;
                                                              CorpId;
                                                              RegionId;
                                                              CountryId;
                                                              DomesticregId;
                                                              StateProvId;
                                                              CityId;
                                                              OfficeId;
                                                              HistSeqNo;
                                                              PolicyNo;
                                                              AgentId;
                                                              DesignatedPensionerContactId;
                                                              InsuredContactId;
                                                              StudentNameContactId;                                                  
                                                              ProductDesc;
                                                              OwnerFullName;
                                                              InsuranceFullName;
                                                              AgentFullName;
                                                              UserFullName;
                                                              LastUpdate;
                                                              ProductNameKey;
                                                              AddInsuredContactId;
                                                              PaymentId;"
                                                runat="server" ClientIDMode="Static"
                                                EnableCallBacks="False" DataSourceID="LinqDS" Width="100%" AutoGenerateColumns="False" OnRowCommand="gvCasesInProcess_RowCommand" OnPreRender="gvCasesInProcess_PreRender">
                                                <Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />
                                                <Columns>
                                                    <dx:GridViewDataCheckColumn Caption="" VisibleIndex="0" Width="3%">
                                                        <DataItemTemplate>
                                                            <asp:CheckBox runat="server" ID="chkSelect" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataCheckColumn>
                                                    <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" Name="PolicyLabel" VisibleIndex="1" />
                                                    <dx:GridViewDataColumn Caption="BUSINESS LINE" FieldName="ProductTypeDesc" VisibleIndex="2" Name="ProductTypeLabel" />
                                                    <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" Name="PlanLabel" VisibleIndex="3" />
                                                    <dx:GridViewDataTextColumn FieldName="OwnerFullName" Caption="OWNER" Name="OwnerLabel" VisibleIndex="4" />
                                                    <dx:GridViewDataTextColumn FieldName="InsuranceFullName" Caption="INSURED" Name="INSURED" VisibleIndex="5" />
                                                    <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" Name="Office" VisibleIndex="6" />
                                                    <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="nbAGENT" Name="nbAGENT" VisibleIndex="7" />
                                                    <dx:GridViewDataTextColumn FieldName="UserFullName" Caption="USER" Name="USER" VisibleIndex="8" />
                                                    <dx:GridViewDataDateColumn FieldName="LastUpdate" Caption="LAST UPDATE" VisibleIndex="9" Name="LastUpdateLabel" SortOrder="Descending">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataColumn Caption="UPLOAD" VisibleIndex="10" Width="4%" Name="UPLOAD">
                                                        <DataItemTemplate>
                                                            <asp:Button runat="server" CssClass="upload_file" ID="btnUploadFile" CommandName="Upload" Visible='<%# Eval("CanGoRequirement") != null ?Eval("CanGoRequirement"): false %>'></asp:Button>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="COMMENT" VisibleIndex="11" Width="5%" Name="Comment">
                                                        <DataItemTemplate>
                                                            <asp:UpdatePanel runat="server" ID="udpBtncomment">
                                                                <ContentTemplate>
                                                                    <asp:Button runat="server" CssClass="coment_file" CommandName="Comment" ID="btnComment" Visible='<%# Eval("HasComment") != null ?Eval("HasComment"): false %>'></asp:Button>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="btnComment" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="VIEW" VisibleIndex="12" Visible="false" Width="4%" Name="View">
                                                        <DataItemTemplate>
                                                            <asp:Button runat="server" CssClass="view_file" ID="btnViewFile" CommandName="View"></asp:Button>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="EDIT" VisibleIndex="13" Width="4%" Name="Edit">
                                                        <DataItemTemplate>
                                                            <asp:Button runat="server" CssClass="edit_file" ID="btnEdit" CommandName="Modify"></asp:Button>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="DELETE" VisibleIndex="14" Width="4%" Name="DeleteLabel">
                                                        <DataItemTemplate>
                                                            <asp:UpdatePanel runat="server" ID="udpDelete">
                                                                <ContentTemplate>
                                                                    <asp:Button runat="server" CssClass="delete_file" CommandName="Delete" OnClientClick="return DlgConfirm(this)" ID="btnDelete"></asp:Button>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataTextColumn FieldName="AgentLegalContactId" Caption="RepresentanteLegal" Name="RepresentanteLegal" VisibleIndex="15" Width="0px" />
                                                </Columns>
                                                <Settings ShowGroupPanel="True" />
                                                <SettingsBehavior ColumnResizeMode="NextColumn" />
                                                <Settings VerticalScrollableHeight="500" VerticalScrollBarMode="Visible" />
                                                <SettingsPager PageSize="20" NumericButtonCount="3" AlwaysShowPager="true">
                                                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                                </SettingsPager>
                                                <SettingsPopup>
                                                    <HeaderFilter Height="200" />
                                                </SettingsPopup>
                                                <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                            </dx:ASPxGridView>
                                            <dx:LinqServerModeDataSource OnSelecting="LinqDS_Selecting" ID="LinqDS" runat="server" />
                                        </div>
                                        <!--grid_wrap-->
                                    </div>
                                    <!--content_fondo_gris-->
                                </div>
                                <!--col-1-1-->
                            </div>
                            <!--fondo gris-->
                        </div>
                        <!--col-1-1-->

                        <div class="col-1-1">
                            <div class="barra_sub_menu">
                                <div class="grupos de_2_b last">
                                    <div class="leyenda">
                                        <span runat="server" id="SelectionGridMessage">To select a record, click the checkbox in the corresponding row . To select the full list ,
                                                click on the top checkbox column.
                                        </span>
                                    </div>
                                    <div class="grupos de_2">
                                        <div>
                                            <div class="btn_celeste">
                                                <span class="see_ilustracion"></span>
                                                <asp:Button runat="server" CssClass="boton" Text="SEND TO REVIEW" ID="btnSendToReview" OnClick="btnSendToReview_Click" OnClientClick="return ConfirmReadyToReview(this)" />
                                            </div>
                                            <!--btn_celeste-->
                                        </div>

                                        <div>
                                            <div class="btn_celeste">
                                                <span class="add_ilustracion"></span>
                                                <asp:Button runat="server" CssClass="boton" ID="btnPrintList" Text="EXPORT TO EXCEL" OnClick="btnPrintList_Click" OnClientClick="return ConfirmPrintList(this)" />
                                            </div>
                                            <!--btn_celeste-->
                                        </div>
                                    </div>
                                    <!--grupos-->
                                </div>
                                <!--grupos-->
                            </div>
                            <!--barra_sub_menu-->
                        </div>
                        <!--col-1-1-->
                    </div>
                    <!--grid grid-pad-->
                </div>
                <!--contendio derecha-->

            </div>
            <!-- /main clearfix -->
        </div>
        <asp:HiddenField runat="server" ID="hdnSelect" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnShowPopAddCommment" ClientIDMode="Static" Value="false" />
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvFakeGridView"></dx:ASPxGridViewExporter>
        <dx:ASPxGridView ID="gvFakeGridView" runat="server" EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Visible="false">
            <Columns>
                <dx:GridViewDataColumn FieldName="PolicyNo" Caption="POLICY" VisibleIndex="0" />
                <dx:GridViewDataColumn FieldName="ProductDesc" Caption="PLAN" VisibleIndex="1" />
                <dx:GridViewDataColumn FieldName="OwnerFullName" Caption="OWNER" VisibleIndex="2" />
                <dx:GridViewDataColumn FieldName="InsuranceFullName" Caption="INSURED" VisibleIndex="3" />
                <dx:GridViewDataColumn FieldName="AgentFullName" Caption="AGENT" VisibleIndex="4" />
                <dx:GridViewDataColumn FieldName="UserFullName" Caption="USER" VisibleIndex="5" />
                <dx:GridViewDataColumn FieldName="LastUpdate" Caption="LAST UPDATE" VisibleIndex="6" />
            </Columns>
        </dx:ASPxGridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvCasesInProcess" />
        <asp:PostBackTrigger ControlID="btnPrintList" />
    </Triggers>
</asp:UpdatePanel>
<div id="dvPopAddComment" style="display: none; padding: 0">
    <uc1:UCNotesComments runat="server" ID="UCNotesComments" />
</div>
