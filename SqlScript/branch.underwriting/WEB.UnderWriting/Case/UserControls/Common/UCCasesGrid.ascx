<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCasesGrid.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Common.UCCasesGrid" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<style>
	.left {
		text-align: left;
	}
	.right {
		text-align: right;
	}
</style>


<asp:UpdatePanel runat="server" ID="udpCaseAllOpen" RenderMode="Block">
	<ContentTemplate>
		<dx:ASPxGridView ID="gvCases"
			KeyFieldName="CorpId;RegionId;CountryId;DomesticregId;StateProvId;CityId;OfficeId;CaseSeqNo;HistSeqNo;PolicyNo;ContactId;OwnerIsInsured;AddInsuredContactId;InsuredPeriod;ProductDesc;SubmitDate;BenefitAmount"
			runat="server"
			ClientIDMode="Static"
			EnableCallBacks="False"
			ClientSideEvents-RowClick="OnRowClick"
			DataSourceID="LinqServerModeDataSource"
			SettingsPager-AlwaysShowPager="true"
			OnAutoFilterCellEditorInitialize="gvCases_OnAutoFilterCellEditorInitialize" AutoGenerateColumns="False" OnHtmlDataCellPrepared="gvCases_HtmlDataCellPrepared">
			<Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />
			<ClientSideEvents RowClick="OnRowClick" />
			<Columns>
				<dx:GridViewDataColumn FieldName="CorpId" Caption="CorpId" Visible="false" />
				<dx:GridViewDataColumn FieldName="RegionId" Caption="RegionId" Visible="false" VisibleIndex="0" />
				<dx:GridViewDataColumn FieldName="CountryId" Caption="CountryId" Visible="false" VisibleIndex="1" />
				<dx:GridViewDataColumn FieldName="DomesticregId" Caption="DomesticregId" Visible="false" VisibleIndex="2" />
				<dx:GridViewDataColumn FieldName="StateProvId" Caption="StateProvId" Visible="false" VisibleIndex="3" />
				<dx:GridViewDataColumn FieldName="CityId" Caption="CityId" Visible="false" VisibleIndex="4" />
				<dx:GridViewDataColumn FieldName="OfficeId" Caption="OfficeId" Visible="false" VisibleIndex="5" />
				<dx:GridViewDataColumn FieldName="CaseSeqNo" Caption="CaseSeqNo" Visible="false" VisibleIndex="6" />
				<dx:GridViewDataColumn FieldName="HistSeqNo" Caption="HistSeqNo" Visible="false" VisibleIndex="7" />
				<dx:GridViewDataColumn FieldName="ContactId" Caption="ContactId" Visible="false" VisibleIndex="8" />
				<dx:GridViewDataColumn FieldName="ProductTypeDesc" Caption="Product Family" Settings-AutoFilterCondition="Contains" VisibleIndex="26">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="PolicyNo" Caption="Illustration" Settings-AutoFilterCondition="Contains" VisibleIndex="27">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="FullNameInsured" Caption="Insured Name" Settings-AutoFilterCondition="Contains" VisibleIndex="29">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="PolicyStatusDesc" Caption="Illustration Status" Settings-AutoFilterCondition="Contains" VisibleIndex="30">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="ProductDesc" Caption="Plan Name" Settings-AutoFilterCondition="Contains" VisibleIndex="31">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="SerieDesc" Caption="Series" Settings-AutoFilterCondition="Contains" VisibleIndex="32">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataTextColumn FieldName="BenefitAmount" Caption="Benefit Amount" Settings-AutoFilterCondition="Equals" VisibleIndex="33">
					<PropertiesTextEdit DisplayFormatString="N2" Style-CssClass="right" Style-HorizontalAlign="Right">
                        <Style CssClass="right" HorizontalAlign="Right">
                        </Style>
                    </PropertiesTextEdit>
					<Settings AutoFilterCondition="Equals" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataColumn FieldName="FirstNameAgent" Caption="Agent Name" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="9">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="GlobalCountryDesc" Caption="Country" Settings-AutoFilterCondition="Contains" VisibleIndex="34">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="OfficeDesc" Caption="Office" Settings-AutoFilterCondition="Contains" VisibleIndex="35">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataDateColumn FieldName="SubmitDate" Caption="Submitted Date" SortOrder="Descending" CellStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" VisibleIndex="36">
					<PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
					<Settings AutoFilterCondition="Equals" />
					<CellStyle HorizontalAlign="Center"></CellStyle>
				</dx:GridViewDataDateColumn>
				<dx:GridViewDataColumn FieldName="AssigedTo" Caption="Assigned to" Settings-AutoFilterCondition="Contains" VisibleIndex="37">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="CompanyDesc" Caption="Company" Settings-AutoFilterCondition="Contains" VisibleIndex="38">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="Priority" Caption="Priority" VisibleIndex="39">
					<DataItemTemplate>
						<input type='checkbox' id='chkPriority' <%# Eval("Priority") != null ? (bool)Eval("Priority") ? "checked" : "" : "" %> onclick="OnCheckBoxClick(this,<%#Container.VisibleIndex%>);" />
					</DataItemTemplate>
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="Steps" Caption="Step" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="10">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="RyderTypeDesc" Caption="Riders" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="11">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataTextColumn FieldName="ReinsuredAmount" Caption="Reinsured Amount" Visible="false" Settings-AutoFilterCondition="Equals" VisibleIndex="12">
					<PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
					<Settings AutoFilterCondition="Equals" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataColumn FieldName="Reinsurer" Caption="Reinsurer" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="13">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataDateColumn FieldName="DateSentToReinsurance" Caption="Date Sent To Reinsurance" CellStyle-HorizontalAlign="Center" Visible="false" Settings-AutoFilterCondition="Equals" VisibleIndex="14">
					<PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
					<Settings AutoFilterCondition="Equals" />
					<CellStyle HorizontalAlign="Center">
					</CellStyle>
				</dx:GridViewDataDateColumn>
				<dx:GridViewDataColumn FieldName="TimeInReinsurance" Caption="Time In Reinsurance" Visible="false" Settings-AutoFilterCondition="Equals" VisibleIndex="15">
					<Settings AutoFilterCondition="Equals" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="UserAuditTrail" Caption="User Audit Trail" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="16">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="Days" Caption="Days" Visible="false" Settings-AutoFilterCondition="Equals" VisibleIndex="17">
					<Settings AutoFilterCondition="Equals" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="ExceptionTypeDesc" Caption="Type of Exception" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="18">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataDateColumn FieldName="EffectiveDate" Caption="Effective Date" CellStyle-HorizontalAlign="Center" Visible="false" Settings-AutoFilterCondition="Equals" VisibleIndex="19">
					<PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
					<Settings AutoFilterCondition="Equals" />
					<CellStyle HorizontalAlign="Center">
					</CellStyle>
				</dx:GridViewDataDateColumn>
				<dx:GridViewDataDateColumn FieldName="RequestedDate" Caption="Requested Date" CellStyle-HorizontalAlign="Center" Visible="false" Settings-AutoFilterCondition="Equals" VisibleIndex="20">
					<PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
					<Settings AutoFilterCondition="Equals" />
					<CellStyle HorizontalAlign="Center">
					</CellStyle>
				</dx:GridViewDataDateColumn>
				<dx:GridViewDataColumn FieldName="RequestedBy" Caption="Requested By" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="21">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="StepTypeDesc" Caption="Change Type" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="22">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="StepDesc" Caption="Change Step" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="23">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="StepInAwaiting" Caption="Step in Awaiting" Visible="false" Settings-AutoFilterCondition="Contains" VisibleIndex="24">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
				<dx:GridViewDataColumn FieldName="TimeInAwaiting" Caption="Time in Awaiting" Visible="false" Settings-AutoFilterCondition="Equals" VisibleIndex="25">
					<Settings AutoFilterCondition="Equals" />
				</dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Policy_No_Temp" Caption="Illustration No" Settings-AutoFilterCondition="Contains" VisibleIndex="40">
					<Settings AutoFilterCondition="Contains" />
				</dx:GridViewDataColumn>
			</Columns>
			<SettingsBehavior AllowFocusedRow="true" AllowSelectSingleRowOnly="true" />
			<SettingsPager PageSize="22" NumericButtonCount="3" />
			<SettingsPopup>
				<HeaderFilter Height="200" />
			</SettingsPopup>
			<SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
		</dx:ASPxGridView>
		<dx:LinqServerModeDataSource OnSelecting="LinqServerModeDataSource_Selecting" ID="LinqServerModeDataSource" runat="server" />
		<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnVisiblePanels" Value="false" />
		<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnGridKey" Value="" />
		<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnFilterByIndexChanged" Value="false" />
		<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfRowIndex" Value="-1" />
		<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnSelectedKey" Value="-1" />
		<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnInsuredPeriod" Value="-1" />
		<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnProductFamily" Value="-1" />
		<asp:Button runat="server" ID="btnSelectedRow" Style="display: none;" OnClick="btnSelectedRow_OnClick" ClientIDMode="Static" />
        <%--wcastro 02-05-2017--%>
        <asp:HiddenField ID="hdTabName" ClientIDMode="Static" runat="server" />
        <asp:HiddenField ID="hdFacultativeAmount" ClientIDMode="Static" runat="server" />
        <%--fin wcastro 02-05-2017--%>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="gvCases" />
	</Triggers>
</asp:UpdatePanel>
