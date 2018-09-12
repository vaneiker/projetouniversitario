<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HealthDeclarationContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.HealthDeclarationContainer" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCQuentions.ascx" TagPrefix="uc1" TagName="UCQuentions" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCQuestionSelection.ascx" TagPrefix="uc1" TagName="UCQuestionSelection" %>
<asp:UpdatePanel ID="udpHealthDeclaration" runat="server">
    <ContentTemplate>
        <div class="contenedor_tabs">
            <asp:Panel runat="server" ID="PNMenuTabs">                       
                <ul id="MenuTabsH" class='<%=ObjServices.ProductLine==WEB.NewBusiness.Common.Utility.ProductLine.HealthInsurance?"tabs_ttle dvddo_in_3":"tabs_ttle dvddo_in_2"  %>'">
                    <li class="active">
                        <asp:LinkButton runat="server" ID="lnkHealthDeclarationTab" ClientIDMode="Static" OnClick="RedirectTab" OnClientClick="return validateQuestionarie();">
                            <asp:Literal runat="server" ID="ltHealtDeclaration">HEALTH DECLARATION</asp:Literal>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkAdditionalQuestionarieTab" ClientIDMode="Static" OnClick="RedirectTab" OnClientClick="return validateQuestionarie();">
                            <asp:Literal runat="server" ID="ltAdditionalQuestionarie">ADDITIONAL QUESTIONNAIRE</asp:Literal>
                        </asp:LinkButton>
                    </li>
                     <li runat="server" id="liInsuranceIformationPrevious">
                        <asp:LinkButton runat="server" ID="lnkInformacionSeguroAnteriorActual" ClientIDMode="Static" OnClick="RedirectTab" OnClientClick="return validateQuestionarie();">
                            <asp:Literal runat="server" ID="ltInformacionSeguroAnteriorActual"> INSURANCE INFORMATION PREVIOUS (OR CURRENT) </asp:Literal>
                        </asp:LinkButton>
                    </li>
                </ul>
            </asp:Panel>
        </div>
        <div class="barra1 no_padding">
            <div class="filter">
                <div class="grupos de_6">
                    <div>
                        <label class="label" runat="server" id="PolicyNo">Policy #</label>
                        <asp:TextBox ID="txtPolicyNumber" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="InsuredType">Insured Type</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlInsuredType" runat="server" OnSelectedIndexChanged="ddlInsuredType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="FirstName">First Name</label>
                        <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="MiddleName">Middle Name</label>
                        <asp:TextBox ID="txtMiddleName" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="LastName">Last Name</label>
                        <asp:TextBox ID="txtLastName" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="SecondLastName">Second Last Name</label>
                        <asp:TextBox ID="txtSecondLastName" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->
            </div>
            <!--filter-->
        </div>
        <!--barra1-->
        <asp:Panel ID="PNDetalle" runat="server" ClientIDMode="Static">
            <div class="fondo_blanco">
                <div class="content_fondo_blanco">
                    <div class="col-1-2">
                        <div class="box1">  
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
                                <label class="label" runat="server" id="Age">AGE:</label>
                                <asp:TextBox ID="txtAGE" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
                                <label class="label" runat="server" id="Gender">GENDER:</label>
                                <asp:TextBox ID="txtGENDER" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
                                <label class="label" runat="server" id="Smoker">SMOKER:</label>
                                <asp:TextBox ID="txtSMOKER" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
                                <div id="dvBloodType">
                                    <label class="label red" runat="server" id="lblBloodType">BLOOD TYPE:</label>
                                    <div class="wrap_select">
                                        <asp:DropDownList ID="ddlBloodType" runat="server" validation="Required"></asp:DropDownList>
                                    </div>
                                </div>
                            </div> 
                        </div>
                        <!--grupos-->
                        <div class="box1">

                            <div style="width: 25%;float:left; padding:0px 5px 5px;">
                                <div>
                                    <label class="label red" runat="server" id="WEIGHTTYPE">WEIGHT UNIT:</label>
                                    <div class="wrap_select">
                                        <asp:DropDownList ID="ddlWEIGHT" runat="server" validation="Required"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 25%;float:left; padding:0px 5px 5px;">
                                <div>
                                    <label class="label red" runat="server" id="WEIGHT">WEIGHT:</label>
                                    <asp:TextBox ID="txtWEIGHT" runat="server" decimal="decimal3" validation="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div style="width: 25%;float:left; padding:0px 5px 5px;">
                                <div>
                                    <label class="label red" runat="server" id="HEIGHTTYPE">HEIGHT UNIT:</label>
                                    <div class="wrap_select">
                                        <asp:DropDownList ID="ddlHEIGHT" runat="server" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlHEIGHT_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 25%;float:left; padding:0px 5px 5px;">
                                <div>
                                    <label class="label red" runat="server" id="HEIGHT">HEIGHT:</label>
                                    <asp:TextBox ID="txtHEIGHT" runat="server" decimal="decimal3" validation="Required" Style="text-align: right;"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!--grupos-->

                        <!--grupos-->
                    </div>
                    <!--col-1-2-->

                    <div class="col-1-2">
                        <div class="box1">  
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
								<div>
									<label class="label" runat="server" id="DRNAME">DR. NAME:</label>
									<asp:TextBox ID="txtNAME" runat="server"></asp:TextBox>
								</div>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
								<div>
									<label runat="server" id="lblMDCountry" class="label red">Country</label>
									<div class="wrap_select">
										<asp:DropDownList runat="server" ID="ddlMDCountry" validation="" AutoPostBack="true" OnSelectedIndexChanged="ddlMDCountry_SelectedIndexChanged"></asp:DropDownList>
									</div>
								</div>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
								<div>
									<label runat="server" id="lblMDStateProvince" class="label  red">State/Province</label>
									<div class="wrap_select">
										<asp:DropDownList runat="server" ID="ddlMDStateProvince" validation="" AutoPostBack="true" OnSelectedIndexChanged="ddlMDStateProvince_SelectedIndexChanged"></asp:DropDownList>
									</div>
								</div>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
								<div>
									<label class="label red" runat="server" id="lblMDCity">City</label>
									<div class="wrap_select">
										<asp:DropDownList runat="server" ID="ddlMDCity"  validation=""></asp:DropDownList>
									</div>
								</div>
                            </div> 
                        </div>
                        <div class="box1">  
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
								<div>
									<label class="label" runat="server" id="ADDRESS">OFFICE ADDRESS:</label>
									<asp:TextBox ID="txtADDRESSES" runat="server" ToolTipDR="ToolTipDR"></asp:TextBox>
								</div>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
								<div>
									<label class="label" runat="server" id="PHONENUMBER">PHONE NUMBER:</label>
									<table>
										<tr>
											<td style="width: 25%; padding-right: 5px">
												<asp:TextBox ID="txtPHONE1" label="Country Code" runat="server" number="number4" MaxLength="3" ToolTipDR="ToolTipDR"></asp:TextBox>
											</td>
											<td style="width: 25%; padding: 0px 5px">
												<asp:TextBox ID="txtPHONE2" label="City Code" runat="server" number="number4" MaxLength="3" ToolTipDR="ToolTipDR"></asp:TextBox>
											</td>
											<td style="width: 50%; padding-left: 5px">
												<asp:TextBox ID="txtPHONE3" label="Phone Number" runat="server" number="number4" MaxLength="4" ToolTipDR="ToolTipDR"></asp:TextBox>
											</td>
										</tr>
									</table>
								</div>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
								<div>
									<label class="label" runat="server" id="LASTMEDICALVISIT">LAST MEDICAL VISIT:</label>
									<asp:TextBox ID="txtVISIT" runat="server" class="datepicker" alt="validateFutureDate"></asp:TextBox>
								</div>
                            </div>
                            <div style="width: 25%;float:left; padding: 0px 5px 5px">
								<div>
									<label class="label" runat="server" id="RESULT">RESULT:</label>
									<asp:TextBox ID="txtRESULT" runat="server" ToolTipDR="ToolTipDR"></asp:TextBox>
								</div>
                            </div> 
                        </div>

                        <%--<div class="grupos de_3">
                            <div>
                                <label class="label" runat="server" id="DRNAME">DR. NAME:</label>
                                <asp:TextBox ID="txtNAME" runat="server"></asp:TextBox>
                            </div>
							
                            <div>
                                <label runat="server" id="lblMDCountry" class="label">Country</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlMDCountry" ClientIDMode="Static" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlMDCountry_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
							
                            <div>
                                <label runat="server" id="lblMDStateProvince" class="label">State/Province</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlMDStateProvince" ClientIDMode="Static" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlMDStateProvince_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
							
                            <div>
                                <label class="label" runat="server" id="lblMDCity">City</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlMDCity" ClientIDMode="Static" validation="Required"></asp:DropDownList>
                                </div>
                            </div>
							
                            <div>
                                <label class="label" runat="server" id="ADDRESS">OFFICE ADDRESS:</label>
                                <asp:TextBox ID="txtADDRESSES" runat="server" ToolTipDR="ToolTipDR"></asp:TextBox>
                            </div>
                            <div>
                                <label class="label" runat="server" id="PHONENUMBER">PHONE NUMBER:</label>
                                <table>
                                    <tr>
                                        <td style="width: 25%; padding-right: 5px">
                                            <asp:TextBox ID="txtPHONE1" label="Country Code" runat="server" number="number4" MaxLength="5" ToolTipDR="ToolTipDR"></asp:TextBox>
                                        </td>
                                        <td style="width: 25%; padding: 0px 5px">
                                            <asp:TextBox ID="txtPHONE2" label="City Code" runat="server" number="number4" MaxLength="5" ToolTipDR="ToolTipDR"></asp:TextBox>
                                        </td>
                                        <td style="width: 50%; padding-left: 5px">
                                            <asp:TextBox ID="txtPHONE3" label="Phone Number" runat="server" number="number4" MaxLength="10" ToolTipDR="ToolTipDR"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!--grupos-->

                        <div class="grupos de_2">
                            <div>
                                <label class="label" runat="server" id="LASTMEDICALVISIT">LAST MEDICAL VISIT:</label>
                                <asp:TextBox ID="txtVISIT" runat="server" class="datepicker" alt="validateFutureDate"></asp:TextBox>
                            </div>
                            <div>
                                <label class="label" runat="server" id="RESULT">RESULT:</label>
                                <asp:TextBox ID="txtRESULT" runat="server" ToolTipDR="ToolTipDR"></asp:TextBox>
                            </div>
                        </div>--%>
                        <!--grupos-->
                    </div>
                    <!--col-1-2-->
                </div>
                <!--content_fondo_blanco-->
            </div>
        </asp:Panel>
        <!--fondo_blanco-->
        <!--contenedor_tabs-->
        <div class="titulos_sin_accion"></div>
        <div class="fondo_gris">
            <div class="col-1-1">
                <asp:Panel runat="server" ID="pnHealthDeclaration" class="fondo_blanco fix_height" OnPreRender="pnHealthDeclaration_PreRender">
                    <div class="titulos_azules"><span class="address"></span><strong></strong></div>
                    <asp:DataList ID="gvHealthDeclaration" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal" OnItemCreated="gvHealthDeclaration_ItemCreated" OnItemDataBound="gvHealthDeclaration_ItemDataBound"
                        DataKeyField="KeyFiledName" Width="100%" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="vertical_align_top" Style="display: none" ItemStyle-Width="33.3%">
                        <ItemTemplate>
                            <div class="col-1-1 fix_height no_overflow pregunta">
                                <div class="grupos radios_list">
                                    <div>
                                        <table class="vertical_align_top">
                                            <tr>
                                                <td style="width: 10%; padding-right: 5px" class="vertical_align_top">
                                                    <input class="desplegar" type="button" />
                                                </td>
                                                <td style="width: 90%; padding: 0px 5px" class="vertical_align_top">
                                                    <label class="label" style="text-align: justify;">
                                                        <span><%# DataBinder.Eval(Container.DataItem, "RowNumber") %>-</span>
                                                        <%# DataBinder.Eval(Container.DataItem, "QuestionListDesc") %>
                                                    </label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>

                                        <table class="radio">
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="rbRespuesta" runat="server" RepeatColumns="2" HidCheck='<%# DataBinder.Eval(Container.DataItem, "RowNumber") %>'
                                                        AutoPostBack="false">
                                                        <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                        <asp:ListItem Text="NO" Value="NO" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>

                                    </div>
                                </div>
                                <div data-input="4" class="extra grupos de_1 hideContentClass no_overflow" style="padding-left: 52px" hid='<%# DataBinder.Eval(Container.DataItem, "RowNumber") %>'>
                                    <div class="grupos no_overflow" validationid='<%# DataBinder.Eval(Container.DataItem, "RowNumber") %>'>
                                        <uc1:UCQuestionSelection runat="server" ID="UCQuestionSelection" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </asp:Panel>
            </div>
        </div>
        <div class="col-1-1">
            <div class="barra_sub_menu">
                <div class="grupos de_8">
                    <div style="float: right;">
                        <div class="btn_celeste">
                            <span class="save_celeste"></span>
                            <asp:Button ID="btnSave" runat="server" Text="Save" ClientIDMode="Static" CssClass="boton" OnClick="btnSave_Click" OnClientClick="return validateQuestionarie();" />
                        </div>
                        <!--btn_celeste-->
                    </div>
                </div>
                <!--grupos-->
            </div>
            <!--barra_sub_menu-->
        </div>
        <!--col-1-1-->
        <asp:HiddenField runat="server" ID="hdnCurrentTabHealth" ClientIDMode="Static" Value="lnkHealthDeclarationTab" />
        <asp:HiddenField runat="server" ID="isViewTab" ClientIDMode="Static" Value="false" />
        <asp:Button runat="server" ID="btnResfreshHealthDeclaration" ClientIDMode="Static" />
    </ContentTemplate>
</asp:UpdatePanel>
