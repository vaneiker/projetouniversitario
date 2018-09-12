<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeaderHistorico.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.Common.UCHeaderHistorico" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<div class="col-1-1">
    <div class="accordion_tabulado">
        <ul class="principal" id="acc1">
            <!--principal-->
            <li><a href="#item1"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.QuickSearch.ToUpper() %><span><!--icono--></span></a>
                <!--secundario / contendio-->
                <ul>
                    <li>
                        
                        <div class="fondo_gris">
                            <div class="grupos de_5">
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.NoPolicy%>:</label>
                                    <asp:TextBox runat="server" ID="txtPolicy"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(RESOURCE.UnderWriting.ConfirmationCall.Resources.CaseStatus.ToLower()) %>:</label>
                                    <asp:DropDownList runat="server" ID="ddlEstatus">
                                 
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.DateFrom %>:</label>
                                    <asp:TextBox runat="server" ID="txtDateFrom" CssClass="datepicker"></asp:TextBox>
                                </div>
                                <div>
                                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.DateTo %>:</label>
                                    <asp:TextBox runat="server" ID="txtDateTo" CssClass="datepicker"></asp:TextBox>
                                </div>
                                <div>
                                    <div class=" float_right">
                                        <div class="boton_wrapper verde">
                                            <span class=" search"></span>
                                            <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="boton" OnClick="btnSearch_Click" />
                                        </div>
                                        <div class="boton_wrapper gris">
                                            <span class="reset"></span>
                                            <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="boton" OnClick="btnReset_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--grupos-->
                        </div>
                        <!--fondo gris-->
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</div>
<!--col-1-1-->
<div class="col-1-1">
    <div id="contenedor_tabshistory" runat="server" class="contenedor_tabs Display">
        <ul class="tabs_ttle dvddo_in_4" id="MenuHeader">
            <li class="active">
                <asp:LinkButton ID="btnAll" runat="server" OnClick="btnSelectTAB_Click" OnClientClick="javascript:__doPostBack('ctl00$bodyContent$UCHeaderHistorico$btnAll','')" CommandName="btnAll" ClientIDMode="Static"> <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ALL.ToUpper() %></asp:LinkButton>
                <i class="punt" id="iliAll" runat="server">34</i>

            </li>
            <li>
                <asp:LinkButton ID="btnPending" runat="server" OnClick="btnSelectTAB_Click" OnClientClick="javascript:__doPostBack('ctl00$bodyContent$UCHeaderHistorico$btnPending','')" CommandName="btnPending" ClientIDMode="Static"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Pending.ToUpper() %></asp:LinkButton>
                <i class="punt" id="iliPending" runat="server">04</i></li>
            <li>
                <asp:LinkButton ID="btnMedical" runat="server" OnClick="btnSelectTAB_Click" OnClientClick="javascript:__doPostBack('ctl00$bodyContent$UCHeaderHistorico$btnMedical','')" CommandName="btnMedical" ClientIDMode="Static"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Medical.ToUpper() %></asp:LinkButton>
                <i class="punt" id="iliMedical" runat="server">12</i></li>
            <li>
                <asp:LinkButton ID="btnComplete" runat="server" OnClick="btnSelectTAB_Click" OnClientClick="javascript:__doPostBack('ctl00$bodyContent$UCHeaderHistorico$btnComplete','')" CommandName="btnComplete" ClientIDMode="Static"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Complete.ToUpper() %></asp:LinkButton>
                <i class="punt" id="iliComplete" runat="server">10</i></li>
            <li>
                <asp:LinkButton ID="btnWarning" runat="server" OnClick="btnSelectTAB_Click" OnClientClick="javascript:__doPostBack('ctl00$bodyContent$UCHeaderHistorico$btnWarning','')" CommandName="btnWarning" ClientIDMode="Static"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Warning.ToUpper() %></asp:LinkButton>
                <i class="punt" id="iliWarning" runat="server">08</i></li>
        </ul>
    </div>
    <!--contenedor_tabs-->
    <div class="grid_wrap">

        <dx:ASPxPopupControl ID="popup" ClientInstanceName="popup" runat="server" AllowDragging="true"
            PopupHorizontalAlign="OutsideRight" HeaderText="OBSERVATIONS" Width="200px" MaxWidth="200px" Height="200px" 
            MinHeight="200px" AllowResize="True" ResizingMode="Postponed">
           <ContentCollection>
                <dx:PopupControlContentControl     runat="server">
                    <dx:ASPxCallbackPanel ID="callbackPanel"  ClientInstanceName="callbackPanel" 
                         OnCallback="callbackPanel_Callback" runat="server"
                         RenderMode="Div" SettingsLoadingPanel-Enabled="false" ScrollBars="None">
                        <PanelCollection >
                            <dx:PanelContent runat="server"  >
                                <table class="InfoTable"  >
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblObservacion" style="white-space: pre-wrap;" runat="server" Text="" ClientIDMode="Static"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <ClientSideEvents Shown="popup_Shown" />
        </dx:ASPxPopupControl>

        <dx:ASPxGridView EnablePagingGestures="False" ID="grdConfirmationCall"  runat="server" ClientIDMode="Static" Width="100%"
            DataSourceID="dsConfirmationCall"
            optionsloadingpanel-enabled="false"
            SettingsLoadingPanel-Mode="Disabled"
            AutoGenerateColumns="False" CssClass="gvResult"
            KeyFieldName="CorpId;
            RegionId;
            CountryId;
            DomesticregId;
            StateProvId;
            CityId;
            OfficeId;
            CaseSeqNo;
            HistSeqNo;
            InsuredContactId;
            AddContactId;
            OwnerContactId;
            PolicyNo;
            PlanType;
            CaseStatus;
            StepTypeId;
            StepId;
            StepCaseNo"
            OnPreRender="grdConfirmationCall_PreRender"
            OnPageIndexChanged="grdConfirmationCall_PageIndexChanged"
            OnBeforeColumnSortingGrouping="grdConfirmationCall_BeforeColumnSortingGrouping"
            OnHtmlDataCellPrepared="grdConfirmationCall_HtmlDataCellPrepared">            
            <Settings ShowHeaderFilterButton="true"/>
            <ClientSideEvents BeginCallback="function(){ $('#loading').show(); }"
                EndCallback="function(){ $('#loading').hide(); CountryTimeConfig(); }" RowClick="selectRow"></ClientSideEvents>
            <Columns>
      <%--          <dx:GridViewDataTextColumn Caption="INITIAL DATE" FieldName="InitialDate" UnboundType="DateTime" PropertiesTextEdit-DisplayFormatString="g">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c2"></HeaderStyle>
                </dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataTextColumn Caption="INITIAL DATE" FieldName="InitialDate" UnboundType="DateTime" PropertiesTextEdit-DisplayFormatString="MM/dd/yyyy HH:mm">
            <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" FilterMode="DisplayText" />
            <HeaderStyle CssClass="c2"></HeaderStyle>
            </dx:GridViewDataTextColumn>


                <dx:GridViewDataColumn Caption="NUMBER OF CALLS" FieldName="NumberOfCalls">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c3"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="DAYS" FieldName="Days">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c4"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="POLICY" FieldName="PolicyNo">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c5"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="PLAN NAME" FieldName="PlanName">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c6"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="TYPE" FieldName="PlanType">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c7"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="OWNER NAME" FieldName="OwnerName">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c8"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="MAIN INSURED" FieldName="InsuredName">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c9"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="ADDITIONAL INSURED" FieldName="AddInsuredName">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c10"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="WORKED BY" FieldName="WorkedBy" ToolTip="text">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c11"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn  Caption="OBSERVATIONS" FieldName="Observations" ReadOnly="False">
                    <Settings AutoFilterCondition="Contains"  HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c12" ></HeaderStyle>
                    <DataItemTemplate  >
                        <a href="javascript:void(0);" style="text-decoration: none !important; font-family: Arial, Helvetica, sans-serif; font-size: 11px !important; color: #111 !important;"
                            onmouseover="OnMoreInfoClick(this, '<%# Eval("Observations") %>')" onmouseout="popup_Hide()"><%# Eval("Observations") %></a>
                    </DataItemTemplate>
                      <CellStyle CssClass="ObservationTruncatedCell"></CellStyle>     
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Caption="WORKED ON" FieldName="WorkedOn" UnboundType="DateTime" PropertiesTextEdit-DisplayFormatString="g">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c13"></HeaderStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="AGENT" FieldName="Agent">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c14"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="OFFICE" FieldName="OfficeDesc">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c15"></HeaderStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="STATUS" FieldName="CaseStatus" Visible="false">
                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                    <HeaderStyle CssClass="c15"></HeaderStyle>
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="true" AllowFocusedRow="True" />
            <SettingsPager AlwaysShowPager="true" PageSize="10" NumericButtonCount="3" />
            <Settings ShowFilterRow="true" ShowFilterBar="Auto" />
            <SettingsBehavior ColumnResizeMode="NextColumn" />
            <SettingsLoadingPanel Mode="Disabled" />
            <SettingsPopup>
                <HeaderFilter Height="200" />
            </SettingsPopup>
        </dx:ASPxGridView>
        <asp:HiddenField ID="hdnGridIndexRow" runat="server" ClientIDMode="Static" Value="-1" />
        <asp:Button runat="server" ID="btnSelectRow" ClientIDMode="Static" Style="display: none;" OnClick="btnSelectRow_Click" />
        <asp:ObjectDataSource ID="dsConfirmationCall" runat="server" SelectMethod="GetConfirmationCall"
            TypeName="WEB.ConfirmationCall.UserControls.Common.UCHeaderHistorico" OnSelecting="dsConfirmationCall_Selecting"></asp:ObjectDataSource>
    </div>
    <!--grid_wrap-->
</div>
<!--col-1-1-->
<asp:HiddenField ID="hfSelectHeaderTAB" runat ="server" ClientIDMode="Static" Value="btnPending" />
<asp:HiddenField ID="hfObservations"    runat ="server" ClientIDMode="Static" />

<script>

    var MessageFromValidator  = '<%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MessageFromValidator.ToUpper() %>';
    var MessageToValidator    =  '<%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MessageToValidator.ToUpper() %>';
    var MessageDateValidator  = '<%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MessageDateValidator.ToUpper() %>';

    $(document).ready(function () {

        var $dateFrom = $('#bodyContent_UCHeader_txtDateFrom');
        var $dateTo = $('#bodyContent_UCHeader_txtDateTo');


        $dateFrom.change(function () {
            if ($dateTo.val() != "" && ($dateFrom.val() > $dateTo.val())) {
                alertify.alert(MessageFromValidator);
                $dateFrom.val("");
                $dateFrom.text("");
                return false;
            }
            var now = new Date();
            var strNow = (("0" + (now.getMonth() + 1)).slice(-2)) + "/" + now.getDate() + "/" + now.getFullYear();

            if ($dateFrom.val() > strNow) {
                alertify.alert(MessageDateValidator);
                $dateFrom.val("");
                $dateFrom.text("");
                return false;
            }

        });


        $dateTo.change(function () {
            if ($dateFrom.val() != "" && ($dateTo.val() < $dateFrom.val())) {
                alertify.alert(MessageToValidator);
                $dateTo.val("");
                $dateTo.text("");
                return false;
            }
            var now = new Date();
            var strNow = (("0" + (now.getMonth() + 1)).slice(-2)) + "/" + now.getDate() + "/" + now.getFullYear();

            if ($dateTo.val() > strNow) {
                alertify.alert(MessageDateValidator);
                $dateTo.val("");
                $dateTo.text("");
                return false;

            }

        });

    });

</script>

