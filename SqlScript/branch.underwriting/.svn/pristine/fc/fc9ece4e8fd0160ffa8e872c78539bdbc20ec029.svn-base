<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCDesignatedPensionerInformation.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.PlanPolicy.WUCDesignatedPensionerInformation" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCPhoneNumber.ascx" TagPrefix="uc1" TagName="WUCPhoneNumber" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCEmailAddress.ascx" TagPrefix="uc2" TagName="WUCEmailAddress" %>
<asp:UpdatePanel runat="server" ID="udpDesignatedPensioner" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <div class="col-3-4-c">
            <asp:Panel runat="server" ID="pnDesignatedPensionerOrAddicionalInsured" ClientIDMode="Static" class="fondo_blanco fix_height">
                <div class="titulos_azules">
                    <span class="address"></span><strong>
                        <asp:Literal runat="server" ID="ltTitleDesignatedPensionerOrAdditionalInsured">DESIGNATED PENSIONER INFORMATION</asp:Literal>
                    </strong>
                </div>
                <asp:MultiView runat="server" ID="MPrincipal" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vDesigantedPensionerOrAdditionalInsured">
                        <div class="content_fondo_blanco">
                            <div class="float_right" style="display: none">
                                <div class="boton_wrapper verde float_right">
                                    <span class="search"></span>
                                    <asp:Button runat="server" ID="btnSearch" CssClass="boton" Text="Search Contact" OnClick="btnSearch_Click" />
                                </div>
                                <!--boton_wrapper-->
                            </div>
                            <div class="col-1-1">
                                <div class="grupos de_4" id="frmDesignatedPensioner" runat="server" clientidmode="Static">
                                    <div>
                                        <label class="label red" runat="server" id="FirstName">First Name</label>
                                        <asp:TextBox runat="server" ID="txtFirstName" alphabetical="alphabetical" validation="Required" />
                                    </div>
                                    <div>
                                        <label class="label" runat="server" id="MiddleName">Middle Name</label>
                                        <asp:TextBox runat="server" ID="txtMidleName" alphabetical="alphabetical" />
                                    </div>
                                    <div>
                                        <label class="label red" runat="server" id="LastName">Last Name</label>
                                        <asp:TextBox runat="server" ID="txtLastName" alphabetical="alphabetical" validation="Required" />
                                    </div>
                                    <div>
                                        <label class="label" runat="server" id="SecondLastName">2nd Last Name</label>
                                        <asp:TextBox runat="server" ID="txt2ndLastName" alphabetical="alphabetical" />
                                    </div>
                                    <div>
                                        <label class="label red" runat="server" id="Gender">Gender</label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlGender" validation="Required">
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label red" runat="server" id="DateOfBirth">Date of Birth</label>
                                        <asp:TextBox runat="server" CssClass="datepicker" ClientIDMode="Static" ID="txtDateOfBirthDesignatedPensioner" alt="validateFutureDate" validation="Required" />
                                    </div>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="label" runat="server" id="Age">Age</label>
                                                    <asp:TextBox runat="server" ID="txtAge" ClientIDMode="Static" ReadOnly="true" disabled alt="Numeric" Style="text-align: right" />
                                                </td>
                                                <td style="width: 55%">
                                                    <label class="label red" runat="server" id="Smoker">Smoker </label>
                                                    <div class="wrap_select">
                                                        <asp:DropDownList runat="server" ID="ddlSmoker" validation="Required">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!--wrap_select-->
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <label class="label red" runat="server" id="MaritalStatus">Marital Status</label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlMaritalStatus" validation="Required">
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                </div>
                                <!--grupos-->
                            </div>

                            <!--col-1-1  col-1-2-->
                            <div id="DReviewConainerBI"></div>
                            <div>
                                <fieldset>
                                    <legend>
                                        <asp:Literal runat="server" ID="ltBackgroundInformation"> BACKGROUND INFORMATION</asp:Literal></legend>
                                    <asp:Panel runat="server" ID="pnDrops" class="grupos de_1">
                                        <div>
                                            <label class="label red" runat="server" id="RealationshipWithInsured">Relationship with insured</label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="cbxRelationshipwithinsured" OnPreRender="cbxRelationshipwithinsured_PreRender" validation="Required" OnSelectedIndexChanged="cbxRelationshipwithinsured_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <asp:Panel ID="pnStudentStatus" runat="server">
                                            <label class="label red" runat="server" id="lblStudentStatus">Student Status</label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="ddlStudentStatus" validation="Required">
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </asp:Panel>
                                    </asp:Panel>
                                    <!--grupos-->
                                    <div class="grupos radios_list margin_t_10">
                                        <asp:Repeater runat="server" ID="repeaterQuestion" OnItemDataBound="repeaterQuestion_ItemDataBound">
                                            <ItemTemplate>
                                                <div>
                                                    <label runat="server" id="lblQuestion" class="label" data-question='<%#Eval("CitizenQuestId")%>' namekey='<%#Eval("NameKey")%>' style="text-align: justify;"></label>
                                                </div>
                                                <div>
                                                    <table class="radio" id='<%#Eval("NameKey")+ "_id"%>'>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton runat="server" ID="rbYes" GroupName="Citizen" />
                                                                <label id="lblYes" runat="server" namekey='<%#Eval("NameKey")%>' sectionid='<%#Eval("NameKey") + "_Designated"%>' onclick="MostrarListaPEP(this);"><%# RESOURCE.UnderWriting.NewBussiness.Resources.YesLabel %></label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton runat="server" ID="rbNo" GroupName="Citizen" />
                                                                <label runat="server" id="lblNo" namekey='<%#Eval("NameKey")%>' sectionid='<%#Eval("NameKey") + "_Designated"%>' onclick="MostrarListaPEP(this);"><%# RESOURCE.UnderWriting.NewBussiness.Resources.NoLabel %></label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                          <br />    
                                         
                            <span id="ISPARENTPOLITICAL_Designated" class="content_fondo_blanco campos">
                                <div class="grupos">
                                    <div class="float_right">
                                        <div class="boton_wrapper amarillo float_right" id="dvAddBtn" runat="server">
                                            <span class="add"></span>
                                            <asp:UpdatePanel ID="udpAdd" runat="server">
                                                <ContentTemplate>
                                                        <asp:Button runat="server" ID="BtnAddPolitical" Text="Add" CssClass="boton" AllowEnter="true" OnClientClick="return validateFormCitizenContact(this,'ISPARENTPOLITICAL_Designated')" OnClick="BtnAddPolitical_Click" />                                               
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="BtnAddPolitical" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="grupos de_4 small">
                                    <div>
                                        <label class="label red" runat="server" id="lbFullName">Full Name</label>
                                        <asp:TextBox ID="txtFullName_Designated" runat="server" AllowEnter="true" ClientIDMode="Static" validation='Required' />
                                    </div>
                                    <div style="width=0;">
                                        <label class="label red" runat="server" id="lbRelationship">Relationship</label>
                                         <div class="wrap_select">
                                        <asp:DropDownList ID="ddlRelationship_Designated" runat="server" ClientIDMode="Static" validation='Required'></asp:DropDownList>
                                                </div>
                                    </div>
                                    <div>
                                        <label class="label red" runat="server" id="lbPosition">Position</label> 
                                        <asp:TextBox ID="txtPosition_Designated" runat="server" ClientIDMode="Static" validation='Required' AllowEnter="true" />
                                         
                                    </div>
                                    <div>
                                        <label class="label red" runat="server" id="lbFrom">From</label>
                                        <asp:TextBox ID="txtFrom_Designated" runat="server" CssClass="datepicker" alt="validateFutureDate" validation="Required" ClientIDMode="Static" AllowEnter="true" />
                                    </div>
                                    <div>
                                        <label class="label" runat="server" id="lbTo">To</label>
                                        <asp:TextBox ID="txtTo_Designated" runat="server" CssClass="datepicker" alt="validateFutureDate" ClientIDMode="Static" AllowEnter="true" />
                                    </div>
                                </div>
                                <div class="grid_wrap margin_t_10 gris">
                                    <dx:ASPxGridView ID="gvCitizenContact_Designated" runat="server"
                                        KeyFieldName="Exposure_Related_Id"
                                        EnableCallBacks="False"
                                        AutoGenerateColumns="False"
                                        SettingsPager-PageSize="15" OnRowCommand="gvCitizenContact_Designated_RowCommand" OnPageIndexChanged="gvCitizenContact_Designated_PageIndexChanged" ClientIDMode="Static">
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
                                            <dx:GridViewDataTextColumn FieldName="EDIT" VisibleIndex="6">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnEditar_Designated" CommandName="Modify" CssClass="edit_file" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DELETE" VisibleIndex="6">
                                                <DataItemTemplate>
                                                    <asp:UpdatePanel ID="udpDelete_Designated" runat="server" OnUnload="udpDelete_Designated_Unload">
                                                        <ContentTemplate>
                                                            <asp:Button runat="server" ID="btnDelete_Designated" CssClass="delete_file" CommandName="Delete" OnClientClick='return DlgConfirm(this)' />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnDelete_Designated" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>

                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" />
                                    </dx:ASPxGridView>
                                </div>
                            </span>  
                                         
                                    </div>
                            </div>
                            </fieldset>
                    <!--col-1-2-->
                            <div>
                                <dx:ASPxPageControl ID="tbDesignatedPensionerInfo" CssClass="tbDesignatedPensionerInfo" runat="server" ActiveTabIndex="3" EnableCallbackAnimation="True" OnTabClick="ASPxPageControl1_TabClick" ViewStateMode="Enabled" EnableTabScrolling="True" Width="100%" OnPreRender="tbDesignatedPensionerInfo_PreRender" Theme="DevEx">
                                    <TabPages>
                                        <dx:TabPage Text="Phone Numbers">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <uc1:WUCPhoneNumber runat="server" ID="WUCPhoneNumber" />
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                        <dx:TabPage Text="Address">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <asp:UpdatePanel runat="server" ID="udpAddress" UpdateMode="Always" OnUnload="UpdatePanel_Unload">
                                                        <ContentTemplate>
                                                            <div class="accordion_tabulado">
                                                                <ul class="principal" id="accAddress">
                                                                    <li><a href="#item1" id="current" lnk="lnk" onclick="setCurrentAccordeon(this,'#hfMenuAccordeon');">
                                                                        <asp:Literal runat="server" ID="lthomeaddress">HOME ADDRESS</asp:Literal><span><!--icono--></span></a><ul>
                                                                            <li>
                                                                                <div id="dvHomeaddress">
                                                                                    <!--grupos-->
                                                                                    <div class="grupos de_1">
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="address">Address</label>
                                                                                            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtHomeAddress" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <!--grupos-->
                                                                                    <div class="grupos de_2">
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="country">Country</label>
                                                                                            <div class="wrap_select">
                                                                                                <asp:DropDownList runat="server" ID="ddlHomeCountry" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </div>
                                                                                            <!--wrap_select-->
                                                                                        </div>
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="StateProvince">State / Province</label>
                                                                                            <div class="wrap_select">
                                                                                                <asp:DropDownList runat="server" ID="ddlHomeState" AutoPostBack="true" OnSelectedIndexChanged="ddlStateProvince_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </div>
                                                                                            <!--wrap_select-->
                                                                                        </div>
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="city">City</label>
                                                                                            <div class="wrap_select">
                                                                                                <asp:DropDownList runat="server" ID="ddlHomeCity"></asp:DropDownList>
                                                                                            </div>
                                                                                            <!--wrap_select-->
                                                                                        </div>
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="postalcode">Postal Code</label>
                                                                                            <asp:TextBox runat="server" ID="txtHomePostalCode" />
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="background: none;border: none;" id="dvCopyHomeAddress">
                                                                                        <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkCopyHomeAddress" AutoPostBack="true" OnCheckedChanged="chkCopyHomeAddress_CheckedChanged" onclick="BeginRequestHandler()" />
                                                                                        <label class="label" runat="server" id="copyHomeAddress">Copy Home Address</label>
                                                                                    </div>
                                                                                </div>
                                                                            </li>
                                                                        </ul>
                                                                    </li>
                                                                    <!--principal-->
                                                                    <li><a href="#item2" id="lnkBusinessAddress" lnk="lnk" onclick="setCurrentAccordeon(this,'#hfMenuAccordeon');">
                                                                        <asp:Literal runat="server" ID="ltbusinessAddress">BUSINESS ADDRESS</asp:Literal><span><!--icono--></span></a><ul>
                                                                            <li>
                                                                                <div id="dvBusinessAddress">
                                                                                    <!--grupos-->
                                                                                    <div class="grupos de_1">
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="address2">Address</label>
                                                                                            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtBusinessAddress" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <!--grupos-->
                                                                                    <div class="grupos de_2">
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="country2">Country</label>
                                                                                            <div class="wrap_select">
                                                                                                <asp:DropDownList runat="server" ID="ddlBusinessCountry" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </div>
                                                                                            <!--wrap_select-->
                                                                                        </div>
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="stateProvince2">State/Province</label>
                                                                                            <div class="wrap_select">
                                                                                                <asp:DropDownList runat="server" ID="ddlBusinessState" AutoPostBack="true" OnSelectedIndexChanged="ddlStateProvince_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </div>
                                                                                            <!--wrap_select-->
                                                                                        </div>
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="City2">City</label>
                                                                                            <div class="wrap_select">
                                                                                                <asp:DropDownList runat="server" ID="ddlBusinessCity"></asp:DropDownList>
                                                                                            </div>
                                                                                            <!--wrap_select-->
                                                                                        </div>
                                                                                        <div>
                                                                                            <label class="label" runat="server" id="postalcode2">Postal Code</label>
                                                                                            <asp:TextBox runat="server" ID="txtBusinessPostalCode" />
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </li>
                                                                        </ul>
                                                                    </li>
                                                                    <!--principal-->
                                                                </ul>
                                                            </div>
                                                            <!-- Accordeon de address -->
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                        <dx:TabPage Text="Email Address">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <div id="fEmailAddress">
                                                        <uc2:WUCEmailAddress runat="server" ID="WUCEmailAddress" />                                                         
                                                    </div>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                        <dx:TabPage Text="ID / Occupation">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <div id="frmIDOccupation">
                                                        <asp:Panel runat="server" ID="pnIncomeInformation" class="grupos de_2" Visible="false">
                                                            <div>
                                                                <label runat="server" id="YearlyPersonalIncome" class="label red">Yearly Personal Income</label>
                                                                <asp:TextBox runat="server" ID="tb_WUC_PI_PersonalIncome" decimal="decimal" validation="Required" ClientIDMode="Static"></asp:TextBox>
                                                            </div>
                                                            <div>
                                                                <label runat="server" id="YearlyFamilyIncome" class="label">Yearly Family Income</label>
                                                                <asp:TextBox runat="server" ID="tb_WUC_PI_YearLyFamilyIncome" decimal="decimal" ClientIDMode="Static"></asp:TextBox>
                                                            </div>
                                                        </asp:Panel>
                                                        <div class="grupos de_2">
                                                            <div>
                                                                <label class="label red" runat="server" id="Occupation">Occupation</label>
                                                                <div>
                                                                    <asp:TextBox runat="server" ID="txtOccupation" ClientIDMode="Static" validation="Required"></asp:TextBox>
                                                                </div>
                                                                <div class="wrap_select" style="display: none">
                                                                    <asp:DropDownList runat="server" ID="ddl_WUC_PI_Occupation" ClientIDMode="Static"></asp:DropDownList>
                                                                </div>
                                                                <!--wrap_select-->
                                                            </div>
                                                            <div>
                                                                <label class="label red" runat="server" id="OccupationType">Occupation Type</label>
                                                                <div>
                                                                    <asp:TextBox runat="server" ID="txtProfession" ClientIDMode="Static" ReadOnly="true" validation="Required" disabled>></asp:TextBox>
                                                                </div>
                                                                <!--wrap_select-->
                                                            </div>
                                                        </div>
                                                        <div class="grupos de_6 alingtoend">
                                                            <div>
                                                                <label class="label" runat="server" id="CompanyName">ID TypeCompany Name</label>
                                                                <asp:TextBox runat="server" ID="txtCompanyName" />
                                                            </div>
                                                            <div>
                                                                <label id="LineOfBusiness1" runat="server" class="label">Line of Business 1</label>
                                                                <asp:TextBox ID="txtFirstLineOfBusiness" runat="server" />
                                                            </div>
                                                            <div>
                                                                <label id="LineOfBusiness2" runat="server" class="label">Line of Business 2</label>
                                                                <asp:TextBox ID="txtSecondLineOfBusiness" runat="server" />
                                                            </div>
                                                            <div>
                                                                <label class="label" runat="server" id="TaskPerformed">Issued byTask Performed</label>
                                                                <asp:TextBox runat="server" ID="txtTaskPerformed" />
                                                            </div>
                                                            <div>
                                                                <label class="label" runat="server" id="LengthAtWork">Length at Work</label>
                                                                <div class="wrap_select">
                                                                    <asp:DropDownList runat="server" ID="ddlLengthWorkFrom"></asp:DropDownList>
                                                                </div>
                                                                <!--wrap_select-->
                                                            </div>
                                                            <div>
                                                                <label class="label" runat="server" id="Months">Months</label>
                                                                <div class="wrap_select">
                                                                    <asp:DropDownList runat="server" ID="ddlLengthWorkTo"></asp:DropDownList>
                                                                </div>
                                                                <!--wrap_select-->
                                                            </div>
                                                        </div>
                                                        <!--grupos-->
                                                        <div class="grupos de_4 small">
                                                            <div>
                                                                <label class="label red" runat="server" id="IDType"></label>
                                                                <div class="wrap_select">
                                                                    <asp:DropDownList runat="server" ID="cbxIDType" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="cbxIDType_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                                <!--wrap_select-->
                                                            </div>
                                                            <div>
                                                                <label class="label red" runat="server" id="IDNumber">ID Number</label>
                                                                <asp:TextBox runat="server" ID="txtIDNumber" validation="Required" ClientIDMode="Static" />
                                                            </div>
                                                            <div>
                                                                <label class="label red" runat="server" id="ExpirationDate">Expiration Date</label>
                                                                <asp:TextBox runat="server" ID="txtExpirationDate" ClientIDMode="Static" CssClass="datepicker" validation="Required" />
                                                            </div>
                                                            <div>
                                                                <label class="label red" runat="server" id="IssuedBy"></label>
                                                                <div class="wrap_select">
                                                                    <asp:DropDownList runat="server" ID="cbxIssuedBy" validation="Required"></asp:DropDownList>
                                                                </div>
                                                                <!--wrap_select-->
                                                            </div>
                                                        </div>
                                                    </div>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                    </TabPages>
                                </dx:ASPxPageControl>
                            </div>
                            <!--col-1-2-->
                            <!--En esta seccion se va a desplegar el grid de los dependientes  -->
                            <asp:Panel runat="server" ID="pnDependents" class="grid_wrap margin_t_10 gris">
                                <!--boton_wrapper-->
                                <div class="float_right">
                                    <div class="boton_wrapper amarillo float_right">
                                        <span class="add"></span>
                                        <asp:Button runat="server" ID="btnAddDependent" CssClass="boton" Text="Add" OnClick="btnAddDependent_Click" OnClientClick="return validateDesignatedPensionerOrAdditionalInsured()" />
                                    </div>
                                    <!--boton_wrapper-->
                                </div>
                                <div class="boton_wrapper gris float_right" style="display: block; margin-right: 10px;">
                                    <span class="borrar"></span>
                                    <asp:Button runat="server" ID="btnCancel" CssClass="boton" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                                <div style="margin-top: 62px;">
                                </div>
                                <asp:Panel runat="server" ID="pngvDependents">
                                    <dx:ASPxGridView ID="gvDependents" runat="server"
                                        EnableCallBacks="False"
                                        KeyFieldName="ContactId"
                                        AutoGenerateColumns="False"
                                        Width="100%" ClientIDMode="Static" OnRowCommand="gvAdditionalInsured_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="FIRST NAME" FieldName="FirstName" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="MIDDLE NAME" FieldName="MiddleName" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="LAST NAME" FieldName="FirstLastName" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="2ND LAST NAME" FieldName="SecondLastName" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="GENDER" FieldName="GenderDesc" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="DATE OF BIRTH" FieldName="Dob" VisibleIndex="5">
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="MARITAL STATUS" FieldName="MaritalStatusDesc" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="IDENTIFICATION" FieldName="Identification" VisibleIndex="7"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Family relationship" FieldName="RelationshiptoOwnerDesc" VisibleIndex="8"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EDIT" VisibleIndex="9" Width="1%">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnEditarDependent" CommandName="Modify" CssClass="edit_file" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DELETE" VisibleIndex="10" Width="1%">
                                                <DataItemTemplate>
                                                    <asp:UpdatePanel runat="server" ID="udpDelete">
                                                        <ContentTemplate>
                                                            <asp:Button runat="server" ID="btnDeleteDependent" CssClass="delete_file" CommandName="Delete" OnClientClick="return DlgConfirm(this)" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnDeleteDependent" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" />
                                    </dx:ASPxGridView>
                                </asp:Panel>

                            </asp:Panel>
                        </div>
                        <!--content_fondo_blanco-->


                    </asp:View>
                    <asp:View runat="server" ID="vAdditionalInsured">
                        <asp:Panel runat="server" ID="pnAdditionalInsured">
                            <div class="content_fondo_blanco" style="display: none" id="dvAdditionalsInsured">
                                <asp:Panel runat="server" ID="pnBtnSearchContact" class="float_right">
                                    <div class="boton_wrapper verde float_right">
                                        <span class="search"></span>
                                        <asp:Button runat="server" ID="btnSearchContact" CssClass="boton" Text="Search Contact" OnClick="btnSearch_Click" />
                                    </div>
                                    <!--boton_wrapper-->
                                </asp:Panel>
                                <div class="col-1-1">
                                    <asp:Panel runat="server" class="grupos de_4" ID="frmAdditionalsIndured" ClientIDMode="Static">
                                        <div>
                                            <label class="label red" runat="server" id="FirstName2">First Name</label>
                                            <asp:TextBox runat="server" ID="TFirstName" validation="Required" />
                                        </div>
                                        <div>
                                            <label class="label" runat="server" id="MiddleName2">Middle Name</label>
                                            <asp:TextBox runat="server" ID="TMiddleName" />
                                        </div>
                                        <div>
                                            <label class="label red" runat="server" id="LastName2">Last Name</label>
                                            <asp:TextBox runat="server" ID="TFirstLastName" validation="Required" />
                                        </div>
                                        <div>
                                            <label class="label" runat="server" id="SecondLastName2">2nd Last Name</label>
                                            <asp:TextBox runat="server" ID="TSecondLastName" />
                                        </div>
                                        <div style="width: 12.5%">
                                            <label class="label red" runat="server" id="Gender2">Gender</label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="cbxGender" validation="Required">
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <div style="width: 12.5%">
                                            <label class="label red" runat="server" id="DateOfBirth2">Date of Birth</label>
                                            <asp:TextBox runat="server" ClientIDMode="Static" ID="TDateOfBirth" CssClass="datepicker" alt="validateFutureDate" validation="Required" />
                                        </div>

                                        <div>
                                            <label class="label red" runat="server" id="MaritalStatus2">Marital Status</label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_MaritalStatus" ClientIDMode="Static" validation="Required"></asp:DropDownList>

                                            </div>
                                            <!--wrap_select-->
                                        </div>

                                        <div>
                                            <label class="label red" runat="server" id="Relationship">Relationship</label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="cbxRelationship" validation="Required">
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <div>
                                            <label class="label red" runat="server" id="Identification">Identification</label>
                                            <asp:TextBox runat="server" ClientIDMode="Static" ID="TIdentification" validation="Required"> </asp:TextBox>
                                        </div>

                                        <div class="float_right">
                                            <div class="boton_wrapper amarillo float_right">
                                                <span class="add"></span>
                                                <asp:Button runat="server" ID="btnAdd" CssClass="boton" Text="Add" OnClick="btnAdd_Click" OnClientClick="return validateForm('frmAdditionalsIndured')" />
                                            </div>
                                            <!--boton_wrapper-->
                                        </div>
                                    </asp:Panel>
                                    <!--grupos-->
                                    <asp:Panel runat="server" ID="pngvAdditionalInsured" class="grid_wrap margin_t_10 gris">
                                        <dx:ASPxGridView ID="gvAdditionalInsured" runat="server"
                                            EnableCallBacks="False"
                                            KeyFieldName="ContactId"
                                            AutoGenerateColumns="False"
                                            Width="100%" ClientIDMode="Static" OnRowCommand="gvAdditionalInsured_RowCommand">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="FIRST NAME" FieldName="FirstName" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="MIDDLE NAME" FieldName="MiddleName" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="LAST NAME" FieldName="FirstLastName" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="2ND LAST NAME" FieldName="SecondLastName" VisibleIndex="3"></dx:GridViewDataTextColumn>

                                                <dx:GridViewDataTextColumn Caption="GENDER" FieldName="GenderDesc" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="DATE OF BIRTH" FieldName="Dob" VisibleIndex="5">
                                                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>

                                                <dx:GridViewDataTextColumn Caption="MARITAL STATUS" FieldName="MaritalStatusDesc" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="IDENTIFICATION" FieldName="Identification" VisibleIndex="7"></dx:GridViewDataTextColumn>


                                                <dx:GridViewDataTextColumn Caption="Family relationship" FieldName="RelationshiptoOwnerDesc" VisibleIndex="8"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="EDIT" VisibleIndex="9" Width="1%">
                                                    <DataItemTemplate>
                                                        <asp:Button runat="server" ID="btnEditar" CommandName="Modify" CssClass="edit_file" />
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DELETE" VisibleIndex="10" Width="1%">
                                                    <DataItemTemplate>
                                                        <asp:UpdatePanel runat="server" ID="udpDelete">
                                                            <ContentTemplate>
                                                                <asp:Button runat="server" ID="btnDelete" CssClass="delete_file" CommandName="Delete" OnClientClick="return DlgConfirm(this)" />
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
                                    </asp:Panel>
                                    <!--grid_wrap-->
                                </div>
                                <!--col-1-1-->
                            </div>
                            <!--content_fondo_blanco-->
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </asp:Panel>
            <!--fondo_blanco-->
        </div>
        <asp:Button runat="server" ID="btnRefreshView" ClientIDMode="Static" Text="RefreshView" OnClick="btnRefreshView_Click" Style="display: none" />
        <asp:HiddenField runat="server" ID="isRefesh" Value="true" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnAge" Value="" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="mySliderTabSelected" ClientIDMode="Static" Value="tabs-a1" />
        <asp:HiddenField runat="server" ID="hdnContactRoleTypeID" ClientIDMode="Static" Value="5" />
        <asp:HiddenField runat="server" ID="hdnValidateFormDesignatedPensionerOrAddicionalInsured" Value="false" ClientIDMode="Static" />
        <asp:HiddenField ID="hfMenuAccordeon" runat="server" ClientIDMode="Static" Value="" />
        <asp:HiddenField ID="hdnCountAdditionalsInsured" runat="server" ClientIDMode="Static" Value="0" />
        <asp:HiddenField ID="hdnContactIdGrid" runat="server" ClientIDMode="Static" Value="-1" />
        <asp:HiddenField ID="hdnCurrentView" runat="server" ClientIDMode="Static" Value="" />
        <asp:HiddenField ID="hdnOccupationId" runat="server" Value="" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnOccupationGroupId" runat="server" Value="" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnClickBussinessAddress" runat="server" Value="false" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCurrentSession" runat="server" Value="" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnRefreshView" />
    </Triggers>
</asp:UpdatePanel>
