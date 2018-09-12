<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Common.Left" %>
<%@ Register Src="~/Case/UserControls/Payments/UCPaymentInformation.ascx" TagPrefix="uc1" TagName="UCPaymentInformation" %>
<%@ Register Src="~/Case/UserControls/Payments/UCPaymentHistory.ascx" TagPrefix="uc1" TagName="UCPaymentHistory" %>
<%@ Register Src="~/Case/UserControls/Payments/UCPaymentCurrentPremium.ascx" TagPrefix="uc1" TagName="UCPaymentCurrentPremium" %>
<%@ Register Src="~/Case/UserControls/Payments/UCPaymentPremiumHistory.ascx" TagPrefix="uc1" TagName="UCPaymentPremiumHistory" %>
<%@ Register Src="~/Case/UserControls/Riders/UCRiderInformation.ascx" TagPrefix="uc1" TagName="UCRiderInformation" %>
<%@ Register Src="~/Case/UserControls/Beneficiaries/UCBeneficiaries.ascx" TagPrefix="uc1" TagName="UCBeneficiaries" %>
<%@ Register Src="~/Case/UserControls/Beneficiaries/UCBAddresses.ascx" TagPrefix="uc1" TagName="UCBAddresses" %>
<%@ Register Src="~/Case/UserControls/Beneficiaries/UCBEmailPhone.ascx" TagPrefix="uc1" TagName="UCBEmailPhone" %>
<%@ Register Src="~/Case/UserControls/Requirements/UCRequimentInformation.ascx" TagPrefix="uc1" TagName="UCRequimentInformation" %>
<%@ Register Src="~/Case/UserControls/MedicalInfo/UCHealtDeclaration.ascx" TagPrefix="uc1" TagName="UCHealtDeclaration" %>
<%@ Register Src="~/Case/UserControls/MedicalInfo/UCMedicalExams.ascx" TagPrefix="uc1" TagName="UCMedicalExams" %>
<%@ Register Src="~/Case/UserControls/Summary/UCSummary.ascx" TagPrefix="uc1" TagName="UCSummary" %>
<%@ Register Src="~/Case/UserControls/Summary/UCUnderwritingComments.ascx" TagPrefix="uc1" TagName="UCUnderwritingComments" %>
<%@ Register Src="~/Case/UserControls/Exceptions/UCExceptions.ascx" TagPrefix="uc1" TagName="UCExceptions" %>
<%@ Register Src="~/Case/UserControls/Exceptions/UCOtherExceptions.ascx" TagPrefix="uc1" TagName="UCOtherExceptions" %>
<%@ Register Src="~/Case/UserControls/FinancialInfo/UCFinancialInfo.ascx" TagPrefix="uc1" TagName="UCFinancialInfo" %>
<%@ Register Src="~/Case/UserControls/FinancialInfo/UCAllFinancialInformationReceived.ascx" TagPrefix="uc1" TagName="UCAllFinancialInformationReceived" %>
<%@ Register Src="~/Case/UserControls/FinancialInfo/UCActivities.ascx" TagPrefix="uc1" TagName="UCActivities" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCPersonalDataContainer.ascx" TagPrefix="uc1" TagName="UCPersonalDataContainer" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCPolicyPlanDataContainer.ascx" TagPrefix="uc1" TagName="UCPolicyPlanDataContainer" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<%@ Register Src="~/Case/UserControls/Common/UCPopTeamCommunication.ascx" TagPrefix="uc1" TagName="UCPopTeamCommunication" %>




<asp:UpdatePanel ID="udpLeft" runat="server" RenderMode="Block">
	<ContentTemplate>
		<div class="contenedor_tabs">
			<ul class="tabs_ttle dvddo_in_5" id="MenuCasesLeft">
				<li class="active">
					<asp:LinkButton ID="lnkPersonalData" ClientIDMode="Static" runat="server" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> PERSONAL DATA </asp:LinkButton>
					<span class="flechita"></span>
				</li>
				<li class="">
					<asp:LinkButton ID="lnkPolicyPlanData" ClientIDMode="Static" runat="server" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> POLICY/PLAN DATA </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton ID="lnkPayments" runat="server" ClientIDMode="Static" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> PAYMENTS </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton ID="lnkRayders" runat="server" ClientIDMode="Static" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> RIDERS </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton ID="lnkBeneficiaries" runat="server" ClientIDMode="Static" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> BENEFICIARIES </asp:LinkButton>
				</li>
			</ul>

			<ul class="tabs_ttle dvddo_in_5">
				<li class="">
					<asp:LinkButton ID="lnkRequirements" ClientIDMode="Static" runat="server" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> REQUIREMENTS </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton ID="lnkMedicalInfo" ClientIDMode="Static" runat="server" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> MEDICAL INFO </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton ID="lnkActivitiesFinancial" ClientIDMode="Static" runat="server" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> ACTIVITIES / FINANCIAL </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton ID="lnkSummary" ClientIDMode="Static" runat="server" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();">SUMMARY </asp:LinkButton>
				</li>
				<li class="disableTab">
					<asp:LinkButton ID="lnkExceptions" ClientIDMode="Static" runat="server" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();" alt='Disabled'>EXCEPTIONS </asp:LinkButton>
				</li>
			</ul>

		</div>
		<!--|=============== ID DATA=================|-->
		<div class="data_id">
			<div class="tab-img rds4 ">
				<div id="TabbedPanels1" class="TabbedPanels ">

					<div class=" tab-img-btn">
						<div class="row mB con_previewBTN">
							<asp:Button ID="UCLeftbtnPreviewId" CssClass="previewBTN" runat="server" Text="Preview" OnClick="UCLeftbtnPreviewId_Click" />
						</div>
						<ul class="TabbedPanelsTabGroup">
							<asp:Repeater runat="server" ID="PdfRepeater">
								<ItemTemplate>
									<li class="btn_num" tabindex="0" style="padding: 0;">
										<asp:Button ID="Index" CssClass="TabbedPanelsTab" runat="server" Text='<%# Container.ItemIndex + 1  %>' Style="padding: 4px 10px;"
											OnClick="LoadPdf_Click" data-PdfKey='<%# Eval("DocumentCategoryId") +"|"+ Eval("DocumentTypeId") +"|"+ Eval("DocumentId")%>' />
									</li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
					<div class="TabbedPanelsContentGroup image_id">
						<div class="TabbedPanelsContent" style="margin-top: 0px;">
							<PdfViewer:PdfViewer CssClass="imgid" ID="pdfViewerSummary" runat="server" ClientIDMode="Static" ShowScrollbars="true"
								ShowToolbarMode="Show" ShowNavigationPanel="false" Width="224px" Height="170px">
							</PdfViewer:PdfViewer>
							<%-- <asp:Image runat="server" ID="imgCedulaFront" ImageUrl="~/images/cedula.jpg" CssClass="imgid" />--%>
						</div>
					</div>
					<div class="tab-zoom-cont">
					</div>
				</div>
			</div>
			<div class="box-cont">
				<div class="boxes wd38 mR-2-p">
					<div class="">
						<label>
							ROLE:</label>
						<asp:DropDownList ID="SummaryRoleDDL" runat="server" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="SummaryRoleDDL_SelectedIndexChanged" DataTextField="Text" DataValueField="Value"></asp:DropDownList>
					</div>
					<div class="">
						<label class="txtBold">
							FIRST NAME / COMPANY NAME:</label>
						<asp:TextBox ID="SummaryFirstNameTxt" runat="server" class="bgAM ReadOnly" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
					</div>
					<div class="">
						<label class="txtBold">
							LAST NAME:</label>
						<asp:TextBox ID="SummaryLastNameTxt" runat="server" class="bgAM ReadOnly" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
					</div>
				</div>
				<div class="boxes wd38 mR-2-p">
					<div class="">
						<label>
							TYPE:</label>
						<asp:TextBox ID="SummaryType" runat="server" ClientIDMode="Static" class="ReadOnly" ReadOnly="true"></asp:TextBox>
					</div>
					<div class="">
						<label class="txtBold">
							MIDDLE NAME:</label>
						<asp:TextBox ID="SummaryMiddleNameTxt" runat="server" class="bgAM ReadOnly" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
					</div>
					<div class="">
						<label class="txtBold">
							2ND LAST NAME:</label>
						<asp:TextBox ID="SummarySecondLastNameTxt" runat="server" class="bgAM ReadOnly" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
					</div>
				</div>
				<div class="boxes wd20">
					<div class="">
						<label>
							DATE OF BIRTH:</label>
						<asp:TextBox ID="SummaryDOBTxt" runat="server" class=" ReadOnly" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
					</div>
					<div class="">
						<label class="">
							AGE:</label>
						<asp:TextBox ID="SummaryAgeTxt" runat="server" class="ReadOnly" ReadOnly="true"></asp:TextBox>

					</div>
					<div class="">
						<label class="">
							NEAR AGE:</label>
						<asp:TextBox ID="SummaryNearAgeTxt" runat="server" ClientIDMode="Static" class="ReadOnly" ReadOnly="true"></asp:TextBox>
					</div>
				</div>
			</div>
		</div>
		<!--|=============== // ID =================|-->
		<!--acordeon tabulado Personal Data -->
		<uc1:UCPersonalDataContainer runat="server" ID="UCPersonalDataContainer" />
		<!--End accordion Personal Data -->

		<!--acordeon tabulado Policy Plan Data -->
		<uc1:UCPolicyPlanDataContainer runat="server" ID="UCPolicyPlanDataContainer" />
		<!--End accordion Policy Plan Data-->

		<!--acordeon tabulado Payments -->
		<div class="accordion_tabulado" id="Payments" style="display: none;">
			<ul class="principal" id="AcordeonPayments">
				<!--PAYMENT INFORMATION-->
				<li><a href="#" id="" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					PAYMENT INFORMATION<span></span> </a>
					<uc1:UCPaymentInformation runat="server" ID="UCPaymentInformation" />
					<!--secundario-->
					<div class="limpiador"></div>
				</li>
				<!--principal 1-->

				<!-- PAYMENT HISTORY -->
				<li id="liPaymentHistory">
					<a href="#" id="AcordeonPaymentHistory" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					PAYMENT HISTORY<span></span> </a>
					<uc1:UCPaymentHistory runat="server" ID="UCPaymentHistory" />
				</li>
				<!--// PAYMENT HISTORY -->

				<!-- CURRENT PREMIUM -->
				<li id="liCurrentPremium">
					<a href="#" id="AcordeonCurrentPremium" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					CURRENT PREMIUM<span></span> </a>
					<uc1:UCPaymentCurrentPremium runat="server" ID="UCPaymentCurrentPremium" />
				</li>
				<!--// CURRENT PREMIUM -->

				<!-- PREMIUM HISTORY -->
				<li id="liPremiumHistory">
					<a href="#" id="AcordeonPremiumHistory" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					Premium History<span></span> </a>
					<uc1:UCPaymentPremiumHistory runat="server" ID="UCPaymentPremiumHistory" />
				</li>
				<!--// PREMIUM HISTORY -->

				<!--principal 1-->
			</ul>
			<!--principal-->
		</div>
		<!--End accordion Payments-->

		<!--acordeon tabulado Rayders -->
		<div class="accordion_tabulado" id="Rayders" style="display: none;">
			<ul class="principal" id="AcordeonRayders">
				<!-- RIDERS INFORMATION-->
				<li><a href="#" id="" class="trigger shown open" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect">
					</div>
					RIDERS INFORMATION<span></span> </a>
					<uc1:UCRiderInformation runat="server" ID="UCRiderInformation" />
					<!--secundario-->
					<div class="limpiador">
					</div>
				</li>
				<!--// RIDERS-->
			</ul>
			<!--principal-->
		</div>
		<!--End accordion Rayders-->

		<!--acordeon tabulado Beneficiaries -->
		<div class="accordion_tabulado" id="Beneficiaries">
			<ul class="principal" id="AcordeonBeneficiaries">
				<!-- INSURED MAIN BENEFICIARIES-->
				<li id="liAddInsuredMain" runat="server">
					<a href="#" id="" onclick="setCurrentAccordeon(this, '#hfPolicyPlanDataAccordeon');" lnk="lnk">
						<div class="rect">
						</div>
						<asp:Literal runat="server" ID="lblMainBenef" Text="INSURED MAIN BENEFICIARIES"></asp:Literal>


						<span></span></a>
					<uc1:UCBeneficiaries runat="server" ID="UCMainBeneficiaries" />
					<!--secundario-->
					<div class="limpiador">
					</div>
				</li>
				<!-- // INSURED MAIN BENEFICIARIES -->

				<!-- INSURED CONTINGENT BENEFICIARIES -->
				<li id="liAddInsuredContingent" runat="server">
					<a href="#" onclick="setCurrentAccordeon(this, '#hfPolicyPlanDataAccordeon');" lnk="lnk">
						<div class="rect"></div>
                        <asp:Literal runat="server" ID="InsContBenef" Text="INSURED CONTINGENT BENEFICIARIES"></asp:Literal>
                                                	<span></span>
					</a>
					<uc1:UCBeneficiaries runat="server" ID="UCContingentBeneficiaries" />

				</li>
				<!-- // INSURED CONTINGENT BENEFICIARIES -->
				<!-- ADDITIONAL INSURED MAIN BENEFICIARIES-->
				<li id="liAddBInsuredMain" runat="server"><a href="#" onclick="setCurrentAccordeon(this, '#hfPolicyPlanDataAccordeon');" lnk="lnk">
					<div class="rect">
					</div>
                     <asp:Literal runat="server" ID="AddMainBenef" Text="ADDITIONAL INSURED MAIN BENEFICIARIES"></asp:Literal>
                    <span></span> </a>
					<uc1:UCBeneficiaries runat="server" ID="UCAddtionalInsuranceMainBeneficies" />
					<!--secundario-->
					<div class="limpiador">
					</div>
				</li>
				<!-- // ADDITIONAL INSURED MAIN BENEFICIARIES -->

				<!-- ADDITIONAL INSURED CONTINGENT BENEFICIARIES -->
				<li id="liAddBInsuredContingent" runat="server">
					<a href="#" onclick="setCurrentAccordeon(this, '#hfPolicyPlanDataAccordeon');" lnk="lnk">
						<div class="rect"></div>
                         <asp:Literal runat="server" ID="AddContBenefi" Text="ADDITIONAL INSURED CONTINGENT BENEFICIARIES"></asp:Literal>
                        <span></span>
					</a>
					<uc1:UCBeneficiaries runat="server" ID="UCAddtionalContingentBeneficies" />

				</li>
				<!-- // ADDITIONAL INSURED CONTINGENT BENEFICIARIES -->
                <li id="liAddBEmailPhone" runat="server">
                   <!-- //agregar tab para phone email -->
                    <a href="#" onclick="setCurrentAccordeon(this, '#hfPolicyPlanDataAccordeon');" lnk="lnk">
						<div class="rect"></div>
                        <asp:Literal runat="server" ID="EmailsPhones" Text="EMAIL AND PHONES FOR BENEFICIARIES"></asp:Literal>
                        <span></span>
					</a>
					<uc1:UCBEmailPhone runat="server" ID="UCBEmailPhone" />
                </li>
                    <!-- //agregar tab para address -->
              <li id="liAddBAddress" runat="server">
                   <!-- //agregar tab para phone email -->
                    <a href="#" onclick="setCurrentAccordeon(this, '#hfPolicyPlanDataAccordeon');" lnk="lnk">
						<div class="rect"></div>
                        <asp:Literal runat="server" ID="AddressesBenef" Text="ADDRESSES FOR BENEFICIARIES"></asp:Literal>
                        <span></span>
					</a>
					<uc1:UCBAddresses runat="server" ID="UCBAddresses" />
                </li>
			</ul>
			<!--// FIN UL Principal-->
		</div>
		<!--End accordion Beneficiaries-->

		<!--acordeon tabulado Requirements -->
		<div class="accordion_tabulado" id="Requirements">
			<ul class="principal" id="AcordeonRequirements">
				<!--PAYMENT INFORMATION-->
				<li><a href="#" id="" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					REQUIREMENTS<span></span> </a>
					<uc1:UCRequimentInformation runat="server" ID="UCRequimentInformation" />
					<!--secundario-->
					<div class="limpiador">
					</div>
				</li>
				<!--principal 1-->
			</ul>
			<!--principal-->
		</div>
		<!--End acordeon tabulado Requirements-->

		<!--acordeon tabulado Medical Info -->
		<div class="accordion_tabulado" id="MedicalInfo">
			<ul class="principal" id="AcordeonMedicalInfo">
				<!--MEDICAL INFO-->
				<li><a href="#" id="" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					HEALTH DECLARATION<span></span> </a>
					<uc1:UCHealtDeclaration runat="server" ID="UCHealtDeclaration" />
					<!--secundario-->
				</li>
				<!--principal 1-->

				<li><a href="#" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					MEDICAL EXAMS<span></span> </a>
					<uc1:UCMedicalExams runat="server" ID="UCMedicalExams" />
				</li>

			</ul>
			<!--principal-->
		</div>
		<!--acordeon tabulado Medical Info-->

		<!--accordeon tabulado Summary-->
		<div class="accordion_tabulado" id="Summary">
			<ul class="principal" id="AcordeonSummary">
				<!-- SUMMARY -->
				<li><a href="#financial_info" id="">
					<div class="rect"></div>
					SUMMARY<span></span> </a>
					<uc1:UCSummary runat="server" ID="UCSummary" />
				</li>
				<!--// SUMMARY-->
				<!-- UNDERWRITING COMMENTS-->
				<asp:Repeater ID="rptComments" runat="server" OnItemDataBound="rptComments_ItemDataBound">
					<ItemTemplate>
						<li>
							<a href="#" class="trigger" onclick="setCurrentAccordeon(this);" lnk="lnk">
								<div class="rect"></div>
								<%# Eval("TypeDesc").ToString().ToUpper() %>
								<span></span>
							</a>
							<uc1:UCUnderwritingComments runat="server" ID="UCUnderwritingComments" />
						</li>
					</ItemTemplate>

				</asp:Repeater>

			</ul>
			<!--principal-->
		</div>
		<!--end accordeon tabulado Summary-->

		<!--accordeon tabulado Exceptions-->
		<div class="accordion_tabulado" id="Exceptions">
			<ul class="principal" id="AcordeonExceptions">
				<!-- EXCEPTIONS -->
				<li><a href="#" id="" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					EXCEPTIONS<span></span> </a>
					<uc1:UCExceptions runat="server" ID="UCExceptions" />
				</li>
				<!--// EXCEPTIONS-->

				<!-- OTHER EXCEPTIONS -->
				<li><a href="#" onclick="setCurrentAccordeon(this);" lnk="lnk">
					<div class="rect"></div>
					OTHER EXCEPTIONS<span></span> </a>
					<uc1:UCOtherExceptions runat="server" ID="UCOtherExceptions" />
				</li>
				<!--// OTHER EXCEPTIONS-->

			</ul>
			<!--principal-->
		</div>
		<!--accordeon tabulado Exceptions-->

		<!--accordeon tabulado Finanacial Info-->
		<!--acordeon tabulado-->
		<div class="accordion_tabulado" id="ActivitiesFinancial">
			<ul class="principal" id="AcordeonFinancialInfo">
				<!--FINANCIAL INFO-->
				<li><a href="#" id="" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
					<div class="rect">
					</div>
					FINANCIAL INFO<span></span> </a>
					<uc1:UCFinancialInfo runat="server" ID="UCFinancialInfo" />
				</li>
				<!--// FINANCIAL INFO-->


				<!-- ALL FINANCIAL INFORMATION RECEIVED-->
				<li><a href="#" id="AcordeonFinancialDocs" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
					<div class="rect"></div>
					ALL FINANCIAL INFORMATION RECEIVED 
                    <span></span></a>
					<uc1:UCAllFinancialInformationReceived runat="server" ID="UCAllFinancialInformationReceived" />


				</li>
				<!--// ALL FINANCIAL INFORMATION RECEIVED-->

				<!-- ACTIVITIES-->
				<li><a href="#" id="AcordeonFinancialActivities" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
					<div class="rect"></div>
					ACTIVITIES
                    <span></span>
				</a>
					<uc1:UCActivities runat="server" ID="UCActivities" />
				</li>
				<!--// ACTIVITIES-->


			</ul>
			<!--principal-->
		</div>
		<!--accordion-->

		<!--end accordeon tabulado Financial Info-->

		<!--// FIN Accordion-->

		<div class="barra-down">
			<div class="boton_wrapper gradient_AM_btn bdrAM mR fl mT10">
				<span class="note"></span>
				<%--      <input class="boton txtNG-f" type="submit" value="Add New Note">--%>
				<asp:LinkButton runat="server" ID="lnkAddNewNote" OnClick="lnkAddNewNote_Click" Text="Add New Note" CssClass="boton txtNG-f" />
			</div>
			<div class="boton_wrapper gradient_AM_btn bdrAM mR fl mT10" style="display: none;">
				<span class="funtion"></span>
				<input class="boton txtNG-f" type="submit" value="History Of Changes">
			</div>
			<div class="boton_wrapper gradient_AM_btn bdrAM mR fl mT10">
				<span class="team_com"></span>
				<%--            <input class="boton txtNG-f" value="Team Communication" type="submit" onclick="ShowTeamCommunicationPopUp();">--%>
				<asp:Button CssClass="boton txtNG-f" Text="Team Communication" ID="btnTeamCommunicationPop" runat="server" OnClientClick="ShowTeamCommunicationPopUp();" OnClick="btnTeamCommunicationPop_Click" />
			</div>
			<div class="boton_wrapper gradient_vd2 bdrVd2 fr mT10" runat="server" id="pnBtnSave">
				<span class="save"></span>
				<asp:Button ID="BTNSaveTabs" runat="server" Text="Save" class="boton" OnClick="BTNSaveTabs_Click" OnClientClick="CitizenQuestions(); return ValidateLeftForm();" />
			</div>
		</div>
		<asp:HiddenField ID="hfTeamCommunicationPopUp" runat="server" ClientIDMode="Static" Value="false" />
		<asp:HiddenField ID="hfMenuCasesLeft" runat="server" ClientIDMode="Static" Value="PersonalData|lnkPersonalData" />
		<asp:HiddenField ID="hfPolicyPlanDataAccordeon" runat="server" ClientIDMode="Static" Value="" />
		<asp:HiddenField ID="hfCssTabbedPanelsTabSelected" runat="server" ClientIDMode="Static" Value="" />
		<asp:HiddenField ID="hfCssTabbedPanelsTabSelectedBig" runat="server" ClientIDMode="Static" Value="" />
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="lnkPersonalData" />
		<asp:AsyncPostBackTrigger ControlID="lnkPolicyPlanData" />
		<asp:AsyncPostBackTrigger ControlID="lnkPayments" />
		<asp:AsyncPostBackTrigger ControlID="lnkRayders" />
		<asp:AsyncPostBackTrigger ControlID="lnkBeneficiaries" />
		<asp:AsyncPostBackTrigger ControlID="lnkRequirements" />
		<asp:AsyncPostBackTrigger ControlID="lnkMedicalInfo" />
		<asp:AsyncPostBackTrigger ControlID="lnkActivitiesFinancial" />
		<asp:AsyncPostBackTrigger ControlID="lnkSummary" />
		<asp:AsyncPostBackTrigger ControlID="lnkExceptions" />
		<asp:AsyncPostBackTrigger ControlID="SummaryRoleDDL" />

	</Triggers>
</asp:UpdatePanel>


<div id="dvTeamCommunication" style="display: none">
	<uc1:UCPopTeamCommunication runat="server" ID="UCPopTeamCommunication" />
</div>

<script type="text/javascript">
	//var mySessionVar = '<%=Session["productFamilyHealthInsurance"]%>';
	//alert('session: ' + mySessionVar);
</script>
