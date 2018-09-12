<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Right.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Common.Right" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Case/UserControls/UnderwritingSteps/UCUnderwritingStep.ascx" TagPrefix="uc1" TagName="UCUnderwritingStep" %>
<%@ Register Src="~/Case/UserControls/NotesComments/UCNotesComments.ascx" TagPrefix="uc1" TagName="UCNotesComments" %>
<%@ Register Src="~/Case/UserControls/OfficeAgent/UCOfficeAgent.ascx" TagPrefix="uc1" TagName="UCOfficeAgent" %>
<%@ Register Src="~/Case/UserControls/Workflow/UCWorkFlow.ascx" TagPrefix="uc1" TagName="UCWorkFlow" %>
<%@ Register Src="~/Case/UserControls/CustomerCommunication/UCCustomerCommunication.ascx" TagPrefix="uc1" TagName="UCCustomerCommunication" %>
<%@ Register Src="~/Case/UserControls/ChangeSteps/UCChangeSteps.ascx" TagPrefix="uc1" TagName="UCChangeSteps" %>


<%@ Register Src="~/Case/UserControls/Common/UCPdfViewer.ascx" TagPrefix="uc1" TagName="UCPdfViewer" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanDocument/UCPolicyPlanDocument.ascx" TagPrefix="uc1" TagName="UCPolicyPlanDocument" %>
<%@ Register Src="~/Case/UserControls/Common/UCPopNewStep.ascx" TagPrefix="uc1" TagName="UCPopNewStep" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Src="~/Case/UserControls/UnderwritingCall/UCUnderwritingCall.ascx" TagPrefix="uc1" TagName="UCUnderwritingCall" %>
<%@ Register Src="~/Case/UserControls/Common/UCPopSentToReinsurance.ascx" TagPrefix="uc1" TagName="UCPopSentToReinsurance" %>

<asp:UpdatePanel ID="udpRight" runat="server" RenderMode="Block">
	<ContentTemplate>
		<div class="contenedor_tabs orange">
			<ul class="tabs_ttle dvddo_in_5" id="MenuCasesRight">
				<li class="active">
					<asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkUnderWritingSteps" OnClick="SelectCurrentTab" Text="UNDERWRITING STEPS" OnClientClick="BeginRequestHandler();">  </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkNoteComments" OnClick="SelectCurrentTab" Text="NOTES" OnClientClick="BeginRequestHandler();">  </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkOfficeAgent" OnClick="SelectCurrentTab" Text="OFFICE/AGENT" OnClientClick="BeginRequestHandler();">  </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkWorkFlow" OnClick="SelectCurrentTab" Text="WORKFLOW" OnClientClick="BeginRequestHandler();">  </asp:LinkButton>
				</li>
			</ul>
			<ul class="tabs_ttle dvddo_in_5">
				<li class="">
					<asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkClientCommunications" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> CLIENT COMMUNICATIONS </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkPolicyPlanChangeSteps" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> POLICY/PLAN CHANGE STEPS </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkPolicyPlanDocuments" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> POLICY/PLAN DOCUMENTS </asp:LinkButton>
				</li>
				<li class="">
					<asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkUnderWritingCall" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();"> UNDERWRITING CALL </asp:LinkButton>
				</li>
			</ul>
		</div>
		<div class="limpiador">
		</div>
		<!--tabla alertas-->
		<div class="compensation_grid">
			<div class="box_steps_point">
				<%--     <div class="line"></div>--%>
				<ul>
					<%--                    <asp:Repeater runat="server" ID="rptStepsPoint">
                        <ItemTemplate>

                            <li>
                                <a href="#" class="tooltip2 point <%# getColorState((int?)Eval("ProcessStatus"))%>"><%=getCounter()%>
                                    <span>
                                        <b></b>
                                        <asp:Literal runat="server" Text='<%# Eval("StepDesc") %>' />
                                    </span>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>--%>


					<li>
						<a href="#" runat="server" id="lnkApproval" onclick="return false;">1
                            <span class="first">
								<b></b>
								<asp:Label runat="server" ID="ltrApproval" Text="Approval" />
							</span>
						</a>
					</li>

					<li>
						<a href="#" runat="server" id="lnkPaymentReview" onclick="return false;">2
                            <span>
								<b></b>
								<asp:Label runat="server" ID="ltrPaymentReview" Text="Payment Review" />
							</span>
						</a>
					</li>

					<li>
						<a href="#" runat="server" id="lnkBackgroundCheck" onclick="return false;">3
                            <span>
								<b></b>
								<asp:Label runat="server" ID="ltrBackgroundCheck" Text="BackgroundCheck" />
							</span>
						</a>
					</li>

					<li>
						<a href="#" runat="server" id="lnkConfirmationCall" onclick="return false;">4
                            <span>
								<b></b>
								<asp:Label runat="server" ID="ltrConfirmationCall" Text="Confirmation Call" />
							</span>
						</a>
					</li>

					<li>
						<a href="#" runat="server" id="lnkWaitingForMedicalInfo" onclick="return false;">5
                            <span>
								<b></b>
								<asp:Label runat="server" ID="ltrWaitingForMedicalInfo" Text="Waiting For Medical Info" />
							</span>
						</a>
					</li>

					<li>
						<a href="#" runat="server" id="lnkEvaluation" onclick="return false;">6
                            <span>
								<b></b>
								<asp:Label runat="server" ID="ltrEvaluation" Text="Evaluation" />
							</span>
						</a>
					</li>

					<li>
						<a href="#" runat="server" id="lnkWaitingForClientInformation" onclick="return false;">7
                            <span>
								<b></b>
								<asp:Label runat="server" ID="ltrWaitingForClientInformation" Text="Waiting For Client Information" />
							</span>
						</a>
					</li>

					<li>
						<a href="#" runat="server" id="lnkReinsurance" onclick="return false;">8
                            <span class="last">
								<b></b>
								<asp:Label runat="server" ID="ltrReinsurance" Text="Reinsurance" />
							</span>
						</a>
					</li>

					<li>
						<a href="#" runat="server" id="lnkFinalReview" onclick="return false;">9
                            <span>
								<b></b>
								<asp:Label runat="server" ID="ltrFinalReview" Text="Final Review" />
							</span>
						</a>
					</li>


					<li>
						<a href="#" runat="server" id="lnkNeverIssued" onclick="return false;">10
                            <span class="last">
								<b></b>
								<asp:Label runat="server" ID="ltrNeverIssued" Text="Never Issued" />
							</span>
						</a>
					</li>

					<li class="mR0">
						<a href="#" runat="server" id="lnkIssuance" onclick="return false;">11
                            <span class="last">
								<b></b>
								<asp:Label runat="server" ID="ltrIssuance" Text="Issuance" />
							</span>
						</a>
					</li>

				</ul>
			</div>
			<div class="box_titulos_steps" id="NoUnderwritingCall" style="display: block">
				<!--331.75px-->
				<ul>
					<li>
						<asp:Panel runat="server" ID="pnText">
							<asp:Image runat="server" class="bombillo" ImageUrl="~/images/bombillo.png" ID="imgSentToReinsurance" />
							<asp:Label ID="lblSendToReinsurance" Text="SEND TO REINSURANCE" runat="server"></asp:Label>
							<asp:Image runat="server" ImageUrl="~/images/imgHidden.png" ID="imgHidden" Width="1" Height="37" />
						</asp:Panel>

						<asp:Panel runat="server" ID="pnReference">
							<label class="fl mR-2-p ReqField">REFERENCE:</label>
							<asp:DropDownList runat="server" ID="ddlReference" CssClass="fl wd54" ClientIDMode="Static"></asp:DropDownList>
						</asp:Panel>
					</li>

					<li>
						<asp:Literal runat="server" ID="ltTitle">UNDERWRITING PROCESS</asp:Literal>
					</li>

					<li>ALERT</li>
				</ul>
			</div>

			<div class="box_titulos_steps" id="UnderwritingCall" style="display: none">
				<ul>
					<li>
						<b class="fl mL block mR">SCRIPT LANGUAGE </b>
						<div class="UCDdlLanguages">
							<dx:ASPxComboBox ID="ddlUCLanguages" runat="server" ValueType="System.String" ItemStyle-CssClass="DDLaguagesImage"
								DropDownStyle="DropDownList" EnableIncrementalFiltering="false" ShowImageInEditBox="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlUCLanguages_SelectedIndexChanged" AutoPostBack="true">
							</dx:ASPxComboBox>
						</div>
					</li>
					<li>
						<asp:Literal runat="server" ID="Literal1">UNDERWRITING PROCESS</asp:Literal>
					</li>
					<li>ALERT</li>
				</ul>
			</div>

			<div id="contenedorTabs">
				<div class="cont_underwriting_steps" id="underwriting_steps" style="display: block">
					<uc1:UCUnderwritingStep runat="server" ID="UCUnderwritingStep" />
				</div>

				<div class="cont_notes" id="notes" style="display: none">
					<uc1:UCNotesComments runat="server" ID="UCNotesComments" />
				</div>

				<div class="cont_officeAgent" id="OfficeAgent" style="display: none">
					<uc1:UCOfficeAgent runat="server" ID="UCOfficeAgent" />
				</div>

				<div class="cont_wflow" id="workflow" style="display: none">
					<uc1:UCWorkFlow runat="server" ID="UCWorkFlow" />
				</div>

				<div class="cont_ccomuni" id="clientComunication" style="display: none">
					<uc1:UCCustomerCommunication runat="server" ID="UCCustomerCommunication" />
				</div>

				<div class="cont_underwriting_steps" id="changeStep" style="display: none">
					<uc1:UCUnderwritingStep runat="server" ID="UCChangeSteps" Visible="false" />
				</div>
				<div id="pdfViewer" style="display: none">
					<uc1:UCPdfViewer runat="server" ID="UCPdfViewer" />
				</div>

				<div id="underwriting_call" style="display: none">
					<div class=" tabs_2 contenedor_tabs orange">
						<ul class="tabs_ttle dvddo_in_6" id="MenuCasesUnderwritingCall">
							<li class="active">
								<%--<a id="lnkProtocolo" runat="server" href="#" onclick="UCMenuLinksFunction(this);" alt="dvCallProtocol">PROTOCOLO</a>--%>
								<asp:Button runat="server" ClientIDMode="Static" ID="lnkProtocolo" OnClientClick="return UCMenuLinksFunction(this);"
									alt="dvCallProtocol" Text="PROTOCOLO" CssClass="wd100 hgp100"></asp:Button>
							</li>
							<li class="">
								<%--<a id="lnkSaludo" runat="server" href="#" onclick="UCMenuLinksFunction(this);" alt="dvCallGreeting">SALUDO</a>--%>
								<asp:Button runat="server" ClientIDMode="Static" ID="lnkSaludo" OnClientClick="return UCMenuLinksFunction(this);"
									alt="dvCallGreeting" Text="SALUDO" CssClass="wd100 hgp100"></asp:Button>
							</li>
							<li class="">
								<%--<a id="lnkPolizaPlan" runat="server" href="#" onclick="UCMenuLinksFunction(this);" alt="dvCallPolicyPlan">P&Oacute;LIZA/PLAN</a>--%>
								<asp:Button runat="server" ClientIDMode="Static" ID="lnkPolizaPlan" OnClientClick="return UCMenuLinksFunction(this);"
									alt="dvCallPolicyPlan" Text="P&Oacute;LIZA/PLAN" CssClass="wd100 hgp100"></asp:Button>
							</li>
							<li class="">
								<%--<a id="lnkValoresDelPlan" runat="server" href="#" onclick="UCMenuLinksFunction(this);" alt="dvCallPlanValues">VALORES DEL PLAN</a>--%>
								<asp:Button runat="server" ClientIDMode="Static" ID="lnkValoresDelPlan" OnClientClick="return UCMenuLinksFunction(this);"
									alt="dvCallPlanValues" Text="VALORES DEL PLAN" CssClass="wd100 hgp100"></asp:Button>
							</li>
							<li class="">
								<%--<a id="lnkInversionPerfil" runat="server" href="#" onclick="UCMenuLinksFunction(this);" alt="dvCallInvestmentProfile">INVERSI&Oacute;N PERFIL</a>--%>
								<asp:Button runat="server" ClientIDMode="Static" ID="lnkInversionPerfil" OnClientClick="return UCMenuLinksFunction(this);"
									alt="dvCallInvestmentProfile" Text="INVERSI&Oacute;N PERFIL" CssClass="wd100 hgp100"></asp:Button>
							</li>
							<li class="">
								<%--<a id="lnkDespedida" runat="server" href="#" onclick="UCMenuLinksFunction(this);" alt="dvCallGoodBye">DESPEDIDA</a>--%>
								<asp:Button runat="server" ClientIDMode="Static" ID="lnkDespedida" OnClientClick="return UCMenuLinksFunction(this);"
									alt="dvCallGoodBye" Text="DESPEDIDA" CssClass="wd100 hgp100"></asp:Button>
							</li>
						</ul>
					</div>
					<div id="contenedorTabsUnderwritingCall">
						<uc1:UCUnderwritingCall runat="server" ID="UCUnderwritingCall" />
					</div>
				</div>

				<div id="PolicyPlandataDocuments" style="display: none">
					<uc1:UCPolicyPlanDocument runat="server" ID="UCPolicyPlanDocument" />
				</div>
				<div id="dvSendToReinsurance" style="display: none">
					<uc1:UCPopSentToReinsurance runat="server" ID="UCPopSentToReinsurance1" />
				</div>

			</div>



			<div class="barra-down-1">
				<div class="boton_wrapper gradient_AM_btn bdrAM mR fl mT10">
					<span class="new_step"></span>
					<asp:Button ID="btnOpenPopNewStep" ClientIDMode="Static" CssClass="boton txtNG-f" Text="New Step" runat="server" OnClick="btnOpenPopNewStep_Click" />
				</div>
				<div class="boton_wrapper gradient_AM_btn bdrAM mR fl mT10">
					<span class="req_info"></span>
					<asp:LinkButton runat="server" ID="lnkRequesInformation" OnClick="lnkRequesInformation_Click" Text="Request Information" CssClass="boton txtNG-f" />
				</div>
				<div class="boton_wrapper gradient_AM_btn bdrAM mR fl mT10">
					<span class="under_man"></span>
					<a href="https://solemamericas.scor.com/" target="_blank" class="boton txtNG-f">Underwriting Manuals</a>
				</div>
				<div class="boton_wrapper gradient_AM_btn bdrAM mR fl mT10">
					<span class="send_reinsurance"></span>
					<asp:LinkButton ID="btnSendToReinsurance" ClientIDMode="Static" CssClass="boton txtNG-f" Text="Send to Reinsurance" runat="server" OnClick="SelectCurrentTab" OnClientClick="BeginRequestHandler();" />
				</div>




				<div style="display: none">
					<asp:Button ID="BTNSaveNoUCTab" runat="server" Text="Save" class="boton" ClientIDMode="Static" OnClick="BTNSaveUCTab_Click" />
				</div>

				<asp:Panel runat="server" ID="pnlUCSave" CssClass="boton_wrapper gradient_vd2 bdrVd2 fr mT10" ClientIDMode="Static">
					<span class="save"></span>
					<asp:Button ID="BTNSaveUCTab" runat="server" Text="Save" class="boton" ClientIDMode="Static" OnClientClick="return UCSaveButton();" />
				</asp:Panel>

				<div style="display: none">
					<asp:Button ID="BTNSendUCTab" runat="server" Text="Send Email" class="boton" ClientIDMode="Static" OnClick="BTNSendUCTab_Click" />
				</div>
			</div>
		</div>
		<AJAX:ModalPopupExtender ID="ModalNewStepPop" BehaviorID="ModalNewStepPop" runat="server" Enabled="true" TargetControlID="hdnNSShowPop"
			PopupControlID="pnNewStepPop" DropShadow="false" BackgroundCssClass="ui-widget-overlay" ClientIDMode="Static">
		</AJAX:ModalPopupExtender>
		<asp:Panel ID="pnNewStepPop" ClientIDMode="Static" runat="server" Style="display: none; margin: 0; padding: 0;" CssClass="DraggablePop">
			<uc1:UCPopNewStep runat="server" ID="UCPopNewStep" />
		</asp:Panel>

		<!--tabla alertas-->
		<asp:HiddenField ID="hfMenuCasesRight" runat="server" ClientIDMode="Static" Value="underwriting_steps|lnkUnderWritingSteps" />
		<asp:HiddenField ID="hfMenuUnderwritingCall" runat="server" ClientIDMode="Static" />
		<asp:HiddenField ID="hfUCProtocol" runat="server" ClientIDMode="Static" />
		<asp:HiddenField ID="hdnNSShowPop" runat="server" Value="false" ClientIDMode="Static" />
		<asp:HiddenField ID="hfRightAccordeon" runat="server" ClientIDMode="Static" Value="" />
		<asp:HiddenField ID="hdnNoteFromLeft" runat="server" ClientIDMode="Static" />
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="lnkOfficeAgent" />
		<asp:AsyncPostBackTrigger ControlID="lnkUnderWritingSteps" />
		<asp:AsyncPostBackTrigger ControlID="lnkNoteComments" />
		<asp:AsyncPostBackTrigger ControlID="lnkWorkFlow" />
		<asp:AsyncPostBackTrigger ControlID="lnkClientCommunications" />
		<asp:AsyncPostBackTrigger ControlID="lnkPolicyPlanChangeSteps" />
		<asp:AsyncPostBackTrigger ControlID="lnkPolicyPlanDocuments" />
		<asp:AsyncPostBackTrigger ControlID="lnkUnderWritingCall" />
		<asp:AsyncPostBackTrigger ControlID="btnOpenPopNewStep" />
		<asp:AsyncPostBackTrigger ControlID="btnSendToReinsurance" />
		<asp:AsyncPostBackTrigger ControlID="ddlUCLanguages" />
	</Triggers>
</asp:UpdatePanel>
