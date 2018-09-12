<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCPersonalInformationLegal.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.WUCPersonalInformationLegal" %>
<asp:UpdatePanel runat="server" ID="udpPersonalInformationLegal" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel runat="server" class="col-1-3" ID="frmPersonalInformationLegal" ClientIDMode="Static">
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules">
                    <span class="insured"></span>
                    <strong>
                        <asp:Literal runat="server" ID="ltPersonalInformation">PERSONAL INFORMATION</asp:Literal></strong>
                       <asp:Panel runat="server" ID="pnOwerIsSameInsured" CssClass="alert_y" Visible="false" ClientIDMode="Static">
                        <%=RESOURCE.UnderWriting.NewBussiness.Resources.OwnerIsSameAsInsured.ToUpper() %>
                    </asp:Panel>
                </div>
                <div class="content_fondo_blanco">
                    <div class="grupos de_2">
                        <div>
                            <label runat="server" id="FirstName" class="label red">First Name</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_FirstName_Legal" validation="Required" alphabetical='alphabetical' ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div>
                            <label runat="server" id="MiddleName" class="label">Middle Name</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_MiddleName_Legal"></asp:TextBox>

                        </div>
                        <div>
                            <label runat="server" id="LastName" class="label red">Last Name</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_FirstLastName_Legal" validation="Required" alphabetical='alphabetical' ClientIDMode="Static"></asp:TextBox>

                        </div>
                        <div>
                            <label runat="server" id="SecondLastName" class="label">2nd Last Name</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_SecondLastName_Legal" alphabetical='alphabetical' ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <!--grupos-->
                    <div class="grupos de_3">
                        <div>
                            <label runat="server" id="Gender" class="label red">Gender</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_Gender_Legal" validation="Required" ClientIDMode="Static" ></asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="Smoker" class="label red">Smoker </label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_Smoker_Legal" validation="Required" ClientIDMode="Static" ></asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="CountryOfBirth" class="label red">Country of Birth</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_CountryBirth_Legal" validation="Required" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="CountryOfCitizenship" class="label red">Country of Citizenship</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_CountryCitizenship_Legal" validation="Required" ClientIDMode="Static"></asp:DropDownList>

                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="DateOfBirth" class="label red">Date of Birth</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_DateBirth_Legal" class="datepicker_03" validation="Required" ClientIDMode="Static" ></asp:TextBox>
                        </div>
                        <div>
                            <label runat="server" id="Age" class="label red">Age</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_Age_Legal" ClientIDMode="Static" validation="Required" ReadOnly="true" disabled></asp:TextBox>
                        </div>
                    </div>
                    <div class="grupos de_2">
                        <div>
                            <label class="label red" runat="server" id="CountryofResidence">Country of Residence</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddlCountryOfResidence_Legal" validation="Required">
                                </asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="MaritalStatus" class="label red">Marital Status</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_MaritalStatus_Legal" ClientIDMode="Static" validation="Required"></asp:DropDownList>

                            </div>
                            <!--wrap_select-->
                        </div>
                    </div>
                    <div class="grupos de_2">
                        <div>
                            <label runat="server" id="YearlyPersonalIncome" class="label red">Yearly Personal Income</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_PersonalIncome_Legal" decimal="decimal" ClientIDMode="Static" validation="Required"></asp:TextBox>
                        </div>
                        <div>
                            <label runat="server" id="YearlyFamilyIncome" class="label">Yearly Family Income</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_YearLyFamilyIncome_Legal" decimal="decimal" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <!--grupos-->
                    <div class="grupos de_2">
                        <div>
                            <label runat="server" id="Occupation" class="label red">Occupation</label>
                            <asp:TextBox runat="server" ID="txtOccupation_Legal" ClientIDMode="Static" validation="Required"></asp:TextBox>

                        </div>
                        <div>
                            <label class="label red" runat="server" id="OccupationType">Occupation Type</label>

                            <asp:TextBox runat="server" ID="txtProfession_Legal" ClientIDMode="Static" ReadOnly="true" validation="Required" disabled></asp:TextBox>

                            <!--wrap_select-->
                        </div>
                    </div>
                <!--grupos-->
                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="CompanyName">Company Name</label>
                        <asp:TextBox runat="server" ID="tb_WUC_PI_CompanyName_Legal"></asp:TextBox>
                    </div>
                                  
                    <div>
                        <label class="label" runat="server" id="TaskPerformed">Task Performed</label>
                        <asp:TextBox runat="server" ID="tb_WUC_PI_TaskPerformed_Legal"></asp:TextBox>
                    </div>
                </div>

                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="LineOfBusiness1">Line of Business 1</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_BusinessLine2_Legal" ClientIDMode="Static" AutoPostBack="true"   OnSelectedIndexChanged="ddl_BusinessLine2_SelectedIndexChanged_Legal" ></asp:DropDownList>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_SecondLineBusiness_Legal" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label runat="server" id="LineOfBusiness2" class="label">Line of Business 2</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_BusinessLine1_Legal" ClientIDMode="Static" AutoPostBack="false"></asp:DropDownList>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_FirstLineBusinnes_Legal" Visible="false"></asp:TextBox>
                        </div>
                    </div>      
                </div>

                <div class="grupos de_2">     
                    <div>
                        <label class="label" runat="server" id="YearsatWork">Years at Work</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_WUC_PI_LengthWorkFrom_Legal"></asp:DropDownList>

                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="Months">Months</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_WUC_PI_LengthWorkTo_Legal"></asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                </div>
                <!--grupos-->
            </div>
            <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </asp:Panel>
        <!--col-1-3-->
        <asp:HiddenField runat="server" ID="hdnDateOfBirthBefore_Legal" Value="0" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnAge_Legal" Value="0" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCurrentSession_Legal" runat="server" Value="" />
        <asp:HiddenField ID="hdnOccupationId_Legal" runat="server" Value="" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnOccupationGroupId_Legal" runat="server" Value="" ClientIDMode="Static" />

    </ContentTemplate>
</asp:UpdatePanel>