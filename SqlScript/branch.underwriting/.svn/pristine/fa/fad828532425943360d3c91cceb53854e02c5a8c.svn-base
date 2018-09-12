<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCompliance.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PersonalData.UCCompliance" EnableViewState="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Case/UserControls/Common/WUCGridPaginator.ascx" TagPrefix="uc1" TagName="WUCGridPaginator" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<ul class="secundario" style="display: none;">
    <li>
        <asp:UpdatePanel ID="udpPanelCompliance" runat="server">
            <ContentTemplate>
                <div class="list_addresses">
        <div class="compliance_header">
            <i class="compliance_header_img"></i><strong>Compliance Revisions:</strong>
        </div>
        <div class="tbl data_G">
            <asp:GridView ID="GridComplianceData" runat="server" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" OnPageIndexChanging="GridComplianceData_PageIndexChanging"
                    DataKeyNames="Address, ClientName, ContactId, CountryOfBirth, Dob, ID, IDType, Identificacion, Nombre_Rol, TipoIdentificacion, statusCompliance">
                <Columns>
                            <asp:TemplateField HeaderText="Role" HeaderStyle-CssClass="gradient_gris">
                                <ItemTemplate>
                                    <div runat="server" id="DVNombre_Rol"><%# Eval("Nombre_Rol") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Full Name" HeaderStyle-CssClass="gradient_gris">
                                <ItemTemplate>
                                    <div runat="server" id="DVClientName_Address"><%# Eval("ClientName") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date of Birth" HeaderStyle-CssClass="gradient_gris">
                                <ItemTemplate>
                                    <div runat="server" id="DVDob"><%# Eval("Dob") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Identification Type" HeaderStyle-CssClass="gradient_gris">
                                <ItemTemplate>
                                    <div runat="server" id="DVTipoIdentificacion"><%# Eval("TipoIdentificacion") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Compliance Status" HeaderStyle-CssClass="gradient_gris">
                                <ItemTemplate>
                                    <table class="compliance_tbl_w100"><tbody><tr><td class='compliance_td_w70 <%# (bool)Eval("IsOk") ? "td_not_match_status" : "td_match_status" %>'>
                                    <div runat="server" id="DVstatusCompliance"><%# Eval("statusCompliance") %></div>
                                    </td><td class="compliance_td_w30">
                                    <div runat="server" id="DVIsOk"><%# !(bool)Eval("IsOk") ? "<i class='decline_compliance'></i>" : "<i class='check'></i>" %></div>
                                    </td></tr></tbody></table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <PagerTemplate>
                            <div class="pagination">
                                <p>
                                    Page
                                    <asp:Literal ID="indexPage" runat="server" />
                                    of
                                        <asp:Literal ID="totalPage" runat="server" />
                                    (<asp:Literal ID="totalItems" runat="server" />
                                    items)
                                </p>
                                <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                                <asp:LinkButton runat="server" CssClass="prev" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                                <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                                <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                            </div>

                        </PagerTemplate>
                    </asp:GridView>
            <asp:HiddenField ID="hdfRowIndex" runat="server" />
        </div>
        <div class="spH15 mB22 w100 fl"></div>
        <div class="risk_header">
            <i class="risk_header_img"></i><strong>Risk Indicator:</strong>
        </div>
        <div class="tbl">
			<ul class="secundario" style="display: block;">
	            <li class="pdL-10 pdata compliance_required_override">
                    <div class="col-1-2 mT5">
					    <div class="grupo_de_cuatro">
						    <ul class="list_campos">
                                <li class=" wd100 mB20">
                                    <div id="divRiskFactor" runat="server" class="content-item" style="background-color: #ffd150;">
                                        <div class="indicator"><asp:Literal ID="ltRiskIndicator" runat="server"></asp:Literal></div>
                                        <div class="overlay"></div>  
                                        <div class="corner-overlay-content">+</div>
                                        <div class="overlay-content">
                                            <h2><asp:Literal ID="ltRiskReference" runat="server"></asp:Literal></h2>
                                            <p class="indicator_text_size">Evaluated risk is "<asp:Literal ID="ltRiskReference2" runat="server"></asp:Literal>".</p>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-1-2 mT5">
                        <div class="grupo_de_cuatro">
						    <ul class="list_campos">
                                <li class=" wd100 mB20">
                                    <label><strong class="required_data_headers">Fields Required (*)</strong></label>
					                <div class="tbl tbl-1">
						                <asp:GridView ID="gvRequiredInfoCompliance" runat="server" border="0" CellSpacing="0" CellPadding="0" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvRequiredInfoCompliance_PageIndexChanging"
					                        AutoGenerateColumns="false" DataKeyNames="Field,Required,Completed, FieldId, FieldReference">
					                        <Columns>
                                                <asp:TemplateField HeaderText="Field" HeaderStyle-CssClass="gradient_azul">
							                        <ItemTemplate>
								                        <div>
									                        <div class="compliance_c1 ml5px" runat="server" id="dvFieldReferenceRequiredCompliance"><%# Eval("FieldReference") %></div>
								                        </div>
							                        </ItemTemplate>
						                        </asp:TemplateField>
						                        <asp:TemplateField HeaderText="Required" HeaderStyle-CssClass="gradient_azul">
							                        <ItemTemplate>
								                        <div>
									                        <div class="compliance_c1 compliance_c1_mid" runat="server" id="dvIsFieldRequiredCompliance"><%# Eval("Required") %></div>
								                        </div>
							                        </ItemTemplate>
						                        </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Completed" HeaderStyle-CssClass="gradient_azul">
                                                    <ItemTemplate>
                                                        <div runat="server" id="dvIsCompletedFieldRequiredCompliance"><%# !(bool)Eval("Completed") ? "<i class='decline_compliance'></i>" : "<i class='check'></i>" %></div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="FieldId" HeaderStyle-CssClass="gradient_azul" Visible="false">
							                        <ItemTemplate>
								                        <div>
									                        <div class="compliance_c1" runat="server" id="dvFieldIdRequiredCompliance"><%# Eval("FieldId") %></div>
								                        </div>
							                        </ItemTemplate>
						                        </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Field" HeaderStyle-CssClass="gradient_azul" Visible="false">
							                        <ItemTemplate>
								                        <div class="compliance_c1" runat="server" id="dvFieldRequiredCompliance"><%# Eval("Field") %></div>
							                        </ItemTemplate>
						                        </asp:TemplateField>
					                        </Columns>
                                            <PagerTemplate>
                                                <div class="pagination">
                                                    <p>
                                                        Page
                                                        <asp:Literal ID="indexPage" runat="server" />
                                                        of
                                                            <asp:Literal ID="totalPage" runat="server" />
                                                        (<asp:Literal ID="totalItems" runat="server" />
                                                        items)
                                                    </p>
                                                    <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                                                    <asp:LinkButton runat="server" CssClass="prev" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                                                    <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                                                    <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                                                </div>

                                            </PagerTemplate>
				                        </asp:GridView>
                                        <asp:HiddenField ID="hdfRowIndexCompliance" runat="server" />
					                </div>
				                </li>
                                <li class=" wd100 mB20">
									<label><strong class="required_data_headers">Documents Required (*)</strong></label>
					                <div class="tbl tbl-1">
						                <asp:GridView ID="gvRequiredDocumentsCompliance" runat="server" border="0" CellSpacing="0" CellPadding="0" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvRequiredDocumentsCompliance_PageIndexChanging"
					                        AutoGenerateColumns="false" DataKeyNames="Field,Required,Completed, FieldId, FieldReference">
					                        <Columns>
                                                <asp:TemplateField HeaderText="Document" HeaderStyle-CssClass="gradient_azul">
							                        <ItemTemplate>
								                        <div>
									                        <div class="compliance_c1 ml5px" runat="server" id="dvDocumentReferenceRequiredCompliance"><%# Eval("FieldReference") %></div>
								                        </div>
							                        </ItemTemplate>
						                        </asp:TemplateField>
						                        <asp:TemplateField HeaderText="Required" HeaderStyle-CssClass="gradient_azul">
							                        <ItemTemplate>
								                        <div>
									                        <div class="compliance_c1 compliance_c1_mid" runat="server" id="dvIsDocumentRequiredCompliance"><%# Eval("Required") %></div>
								                        </div>
							                        </ItemTemplate>
						                        </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Completed" HeaderStyle-CssClass="gradient_azul">
                                                    <ItemTemplate>
                                                        <div runat="server" id="dvIsCompletedFieldRequiredCompliance"><%# !(bool)Eval("Completed") ? "<i class='decline_compliance'></i>" : "<i class='check'></i>" %></div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="FieldId" HeaderStyle-CssClass="gradient_azul" Visible="false">
							                        <ItemTemplate>
								                        <div>
									                        <div class="compliance_c1" runat="server" id="dvDocumentIdRequiredCompliance"><%# Eval("FieldId") %></div>
								                        </div>
							                        </ItemTemplate>
						                        </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Field" HeaderStyle-CssClass="gradient_azul" Visible="false">
							                        <ItemTemplate>
								                        <div class="compliance_c1" runat="server" id="dvDocumentRequiredCompliance"><%# Eval("Field") %></div>
							                        </ItemTemplate>
						                        </asp:TemplateField>
					                        </Columns>
                                            <PagerTemplate>
                                                <div class="pagination">
                                                    <p>
                                                        Page
                                                        <asp:Literal ID="indexPage" runat="server" />
                                                        of
                                                            <asp:Literal ID="totalPage" runat="server" />
                                                        (<asp:Literal ID="totalItems" runat="server" />
                                                        items)
                                                    </p>
                                                    <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                                                    <asp:LinkButton runat="server" CssClass="prev" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                                                    <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                                                    <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                                                </div>

                                            </PagerTemplate>
				                        </asp:GridView>
                                        <asp:HiddenField ID="hdfRowIndexComplianceDoc" runat="server" />
					                </div>
				                </li>
                            </ul>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <div class="spH15 mB22 w100 fl"></div>
        <div class="risk_header">
            <i class="pep_header_img"></i><strong>PEP Formulary:</strong>
        </div>
        <div class="tbl infoPepFormulary">
            <ul class="pep_campos grupo_de_cuatro">
                <div class="dvRelationShip">
                    <li class="titulo_list m0 client_is wd100">
                        <div class="wd49 fl">
                            <ul>
                                <li class="mB2">
                                    <label>
                                        <strong>Client Is a:</strong></label>
                                </li>
                                <asp:GridView ID="GridExposure" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-BackColor="White">
                                            <ItemTemplate>
                                                <li class="titulo_list mB">
                                                    <asp:CheckBox ID="ExposureChk" runat="server" CssClass="checkbox_data ExpChk" OnClick="ExposureElements();"
                                                        Checked='<%# !String.IsNullOrEmpty( Eval("SocialFunctionTypePosition").ToString()) %>' />
                                                    <label class="fl wd90">
                                                        <%# Eval("SocialTypeDesc") %>
                                                    </label>
                                                </li>
                                                <li class="p_of_p wd100" style="display: block;">
                                                    <label>
                                                        Position:</label>
                                                    <asp:TextBox ID="ExposurePositionTxt" runat="server" CssClass="SocialExposureTypePosition" Text='<%# Eval("SocialFunctionTypePosition") %>'
                                                        data-exposure='<%# Eval("SocialFunctionTypeId")%>'></asp:TextBox>
                                                </li>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ul>
                            <ul>
                                <li class="titulo_list mB2">
                                    <label>
                                        <strong>Has a close Relationship with a:</strong></label>
                                </li>
                                <asp:GridView ID="gvRelationship" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-BackColor="White">
                                            <ItemTemplate>

                                                <li class="titulo_list mB">
                                                    <asp:CheckBox ID="RelationshipChk" runat="server" class="checkbox_data RelChk" OnClick="RelationshipElements();" Checked='<%# !String.IsNullOrEmpty( Eval("SocFuncRelName").ToString()) || !String.IsNullOrEmpty( Eval("SocialFunctionTypePosition").ToString()) %>' />
                                                    <label class="fl wd90">
                                                        <%# Eval("SocialTypeDesc")%>
                                                    </label>
                                                </li>
                                                <li class="p_of_p2 wd100">
                                                    <div class="wd49 mR-2-p fl">
                                                        <label>
                                                            Name:</label>
                                                        <asp:TextBox ID="RelationshipNameTxt" runat="server" Text='<%# Eval("SocFuncRelName") %>'
                                                            data-relationship='<%# Eval("SocialFunctionTypeId")%>'></asp:TextBox>
                                                    </div>
                                                    <div class="wd49 fl bspTxt">
                                                        <label>
                                                            Position:</label>
                                                        <asp:TextBox ID="RelationshipTypePositionTxt" runat="server" Text='<%# Eval("SocialFunctionTypePosition") %>'></asp:TextBox>
                                                    </div>
                                                </li>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ul>
                        </div>
                        <div class="wd49 fl setPEP">
                            <!-- Tabla 2 -->
                            <div class="grupo_de_cuatro">
						    <ul class="list_campos">
						        <div class="dvQuestions tblQuestionB">
							        <li class=" wd100">
								        <div class="tbl-2">
									        <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="false" ClientIDMode="Static">
										        <Columns>
											        <asp:TemplateField>
												        <ItemTemplate>
                                                            <td align="left">
                                                                <div class="fr mT10" runat="server" Visible='<%# (Eval("NameKey")).ToString() == "ISPARENTPOLITICAL" %>'>
                                                                    <div id='<%#Eval("NameKey")%>' class='<%# bool.Parse((Eval("CitizenQuestAnswer")??"false").ToString()) ? "bdrAM txtNG-f" : "bdrAM txtNG-f view_btn_compliance_pep_disable" %>' style="text-align: center;">
                                                                        <span class="add"></span>
                                                                        <asp:Button ID="btnPepRelatedInfoAdd" runat="server" disabled='<%# bool.Parse((Eval("CitizenQuestAnswer")??"false").ToString()) %>' title="EDIT" class="view_btn_compliance_pep tooltip fr" ClientIDMode="Static" OnClick="btnPepRelatedInfoSet_Click" />
                                                                        <span class="editPepRelated"><b>ADD EDIT</b></span>
                                                                    </div>
                                                                </div>
                                                            </td>
													        <td align="left" class="">
														        <label>- <%# Eval("CitizenQuestDesc") %></label>
													        </td>
													        <td align="left" class="radiogroup">
														        <ul class="radio ">
															        <li class="li_si">
																        <asp:RadioButton
																	        ID="s1" runat="server"
																	        Checked='<%# ((bool?)Eval("CitizenQuestAnswer")).HasValue && (((bool?) Eval("CitizenQuestAnswer")).Value ? true : false) %>'
																	        data-question='<%# Eval("CitizenQuestId") %>' CssClass="CitizenQuesChk" />
																        <label for="s1" class='<%# ((bool?)Eval("CitizenQuestAnswer")).HasValue ? ((bool?)Eval("CitizenQuestAnswer")).Value ?"fr mT5 radio_in radioSelect"  : "fr mT5 radio_in" : "fr mT5 radio_in" %>' namekey='<%#Eval("NameKey")%>'  onclick="EnablePEPInfo(this);">Yes</label>
																        <asp:HiddenField ID="hdfRadio_si" runat="server" Value='<%# ((bool?)Eval("CitizenQuestAnswer")).HasValue && (((bool?)Eval("CitizenQuestAnswer")).Value ? true : false) %>' />
															        </li>
															        <li class="li_no">
																        <asp:RadioButton
																	        ID="n1" runat="server"
																	        Checked='<%# ((bool?)Eval("CitizenQuestAnswer")).HasValue && !((bool?)Eval("CitizenQuestAnswer")).Value %>'
																	        CssClass="CitizenQuesChk" />
																        <label for="n1" class='<%# ((bool?)Eval("CitizenQuestAnswer")).HasValue?((bool?)Eval("CitizenQuestAnswer")).Value ? "fr mT5 radio_in" : "fr mT5 radio_in radioSelect" : "fr mT5 radio_in" %>' namekey='<%#Eval("NameKey")%>'   onclick="EnablePEPInfo(this);">NO</label>
																        <asp:HiddenField ID="hdfRadio_no" runat="server" Value='<%# ((bool?)Eval("CitizenQuestAnswer")).HasValue && !((bool?)Eval("CitizenQuestAnswer")).Value %>' />
															        </li>
														        </ul>
													        </td>
												        </ItemTemplate>
											        </asp:TemplateField>
										        </Columns>
									        </asp:GridView>
								        </div>
							        </li>
						        </div>
                            </ul>
                        </div>
                    </li>
                </div>
                <!--//Division -->
                <ul class="ml_3pct">
                    <li class="client_is wd100 disclaimerPepDenomination">
                        <div class="fl wd100">
                            <ul>
                                <div class="tblQuestionPEP">
							        <li class=" wd100">
								        <div class="tbl-2">
									        <asp:GridView ID="gvQuetionPEPItSelf" runat="server" AutoGenerateColumns="false" ClientIDMode="Static">
										        <Columns>
											        <asp:TemplateField>
												        <ItemTemplate>
                                                            <td align="left">
                                                            </td>
													        <td align="left" class="">
														        <label><%# Eval("CitizenQuestDesc") %></label>
													        </td>
													        <td align="left" class="radiogroup">
														        <ul class="radio">
															        <li class="li_si">
																        <asp:RadioButton
																	        ID="s1" runat="server"
																	        Checked='<%# bool.Parse((Eval("CitizenQuestAnswer") ?? "false").ToString()) %>'
																	        data-question='<%# Eval("CitizenQuestId") %>' CssClass="CitizenQuesChkPep" GroupName="pepItSelf" />
																        <label for="s1" class='<%# bool.Parse((Eval("CitizenQuestAnswer") ?? "false").ToString()) ? "fr mT5 radio_in radioSelect" : "fr mT5 radio_in" %>' namekey='<%#Eval("NameKey")%>'>Designation</label>
																        <asp:HiddenField ID="hdfRadio_si" runat="server" Value='<%# bool.Parse((Eval("CitizenQuestAnswer") ?? "false").ToString()) %>' />
															        </li>
															        <li class="li_no">
																        <asp:RadioButton
																	        ID="n1" runat="server"
																	        Checked='<%# !bool.Parse((Eval("CitizenQuestAnswer") ?? "false").ToString()) && Eval("CitizenQuestAnswer") != null%>'
																	        CssClass="CitizenQuesChkPep" GroupName="pepItSelf" />
																        <label for="n1" class='<%# !bool.Parse((Eval("CitizenQuestAnswer") ?? "false").ToString()) &&  Eval("CitizenQuestAnswer") != null? "fr mT5 radio_in radioSelect" : "fr mT5 radio_in" %>' namekey='<%#Eval("NameKey")%>'>Relationship</label>
																        <asp:HiddenField ID="hdfRadio_no" runat="server" Value='<%# !bool.Parse((Eval("CitizenQuestAnswer") ?? "false").ToString()) && Eval("CitizenQuestAnswer") != null %>' />
															        </li>
                                                                    <li class="li_na">
																        <asp:RadioButton
																	        ID="na1" runat="server"
																	        Checked='<%# Eval("CitizenQuestAnswer") == null %>'
																	        CssClass="CitizenQuesChkPep" GroupName="pepItSelf" />
																        <label for="na1" class='<%# Eval("CitizenQuestAnswer") == null ? "fr mT5 radio_in radioSelect" : "fr mT5 radio_in" %>' namekey='<%#Eval("NameKey")%>'>N/A</label>
																        <asp:HiddenField ID="hdfRadio_na" runat="server" Value='<%# Eval("CitizenQuestAnswer") == null %>' />
															        </li>
														        </ul>
													        </td>
												        </ItemTemplate>
											        </asp:TemplateField>
										        </Columns>
									        </asp:GridView>
								        </div>
							        </li>
						        </div>
                            </ul>
                        </div>
                    </li>
                </ul>
            </ul>
        </div>
    </div>
            </ContentTemplate>
            <Triggers>
				<asp:AsyncPostBackTrigger ControlID="gvQuestions" />
			</Triggers>
        </asp:UpdatePanel>
    </li>
</ul>
<AJAX:ModalPopupExtender ID="ModalNewPepRelatedPop" BehaviorID="ModalNewPepRelatedPop" runat="server" Enabled="true" TargetControlID="hdnNewPepRelatedShowPop"
	PopupControlID="pnNewPepRelated" DropShadow="false" BackgroundCssClass="ui-widget-overlay" ClientIDMode="Static">
</AJAX:ModalPopupExtender>
<asp:Panel ID="pnNewPepRelated" ClientIDMode="Static" runat="server" Style="display: none; margin: 0; padding: 0; background-color:#fff;" CssClass="DraggablePop">
<asp:UpdatePanel ID="upPopAddNewStep" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="head gradient_azul HeaderHandler" style="cursor: move;">
            <span style="width: 97%;">Add PEP Related Details</span>
            <div class="close_pp_btn">
                <asp:Button ID="btnClosePdfPop" runat="server" CssClass="btnClosePopBtn" ClientIDMode="Static" OnClientClick="return ClosePEPRelatedPop();" />
            </div>
        </div>
        <div class="cont_risk_popup ">
            <div class="list_addresses">
                <div class="boxes">
                    <div class="box1 ">
                        <label id="lbFullNamePepRelated" class="label ReqField">Full Name</label>
                        <asp:TextBox ID="txtFullNamePepRelated" runat="server" AllowEnter="true" ClientIDMode="Static" validation='Required' />
                        <label id="lbRelationshipPepRelated" class="label ReqField">Relationship:</label>
                        <asp:DropDownList ID="ddlRelationshipPepRelated" runat="server" ClientIDMode="Static" validation='Required'></asp:DropDownList>
                    </div>
                    <div class="box1 ">
                        <label id="lbPositionPepRelated" class="label ReqField">Position</label>
                        <asp:TextBox ID="txtPositionPepRelated" runat="server" ClientIDMode="Static" validation='Required' AllowEnter="true" />
                        <label class="label ReqField">From:</label>
                        <asp:TextBox ID="txtFromPepRelated" runat="server" class="datepickerPop" validation="Required" ClientIDMode="Static" AllowEnter="true" />
                    </div>
                    <div class="box1 ">
                        <label class="label ReqField">To:</label>
                        <asp:TextBox ID="txtToPepRelated" runat="server" class="datepickerPop" ClientIDMode="Static" AllowEnter="true" />
                        <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f" style="margin-top: 12px;">
                            <span class="add"></span>
                            <asp:Button runat="server" ID="btnAddPepInformationRelated" Text="Add" class="boton" AllowEnter="true" OnClientClick="return validateFormCitizenContact(this,'frmBackGroundInformation')" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdatePepInformationRelated" runat="server" Text="Save" class="boton" OnClientClick="return ValidateAddress();" Visible="false" />
                        </div>
                    </div>
                </div>
            </div>
         </div>
         <div class="grid_wrap margin_t_10 gris" style="width: 96%;margin-bottom: 1%;margin-left: 2%;background: white;border: none;">
            <dx:ASPxGridView ID="gvCitizenContactPepRelated" runat="server"
                KeyFieldName="Exposure_Related_Id"
                EnableCallBacks="False"
                AutoGenerateColumns="False"
                SettingsPager-PageSize="15" OnRowCommand="gvCitizenContact_RowCommand" OnPageIndexChanged="gvCitizenContact_PageIndexChanged" ClientIDMode="Static">
                <SettingsPager PageSize="3">
                </SettingsPager>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Full Name" FieldName="FullName" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Relationship" FieldName="RelationshipDesc" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Position" FieldName="Position" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="From" FieldName="From" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="To" FieldName="To" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="" VisibleIndex="6">
                        <DataItemTemplate>
                            <asp:Button runat="server" ID="btnEditar" CommandName="Modify" CssClass="edit_file" />
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="" VisibleIndex="6">
                        <DataItemTemplate>
                            <asp:UpdatePanel ID="udpDelete" runat="server">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnDelete" CssClass="delete_file" CommandName="Delete" OnClientClick='return DlgConfirm(this)' />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" />
            </dx:ASPxGridView>
        </div> 
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
<asp:HiddenField ID="hdnNewPepRelatedShowPop" runat="server" Value="false" ClientIDMode="Static" />
