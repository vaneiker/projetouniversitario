<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCPersonalInformation.ascx.cs"
    Inherits="WEB.NewBusiness.NewBusiness.UserControls.WUCPersonalInformation" %>
<asp:UpdatePanel runat="server" ID="udpPersonalInformation" UpdateMode="Conditional">
    <ContentTemplate>
         
        <asp:Panel runat="server" CssClass="col-1-3" ID="frmPersonalInformation" ClientIDMode="Static">
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
                            <asp:TextBox runat="server" ID="tb_WUC_PI_FirstName" validation="Required" alphabetical='alphabetical' ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div>
                            <label runat="server" id="MiddleName" class="label">Middle Name</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_MiddleName"></asp:TextBox>

                        </div>
                        <div>
                            <label runat="server" id="LastName" class="label red">Last Name</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_FirstLastName" validation="Required" alphabetical='alphabetical' ClientIDMode="Static"></asp:TextBox>

                        </div>
                        <div>
                            <label runat="server" id="SecondLastName" class="label">2nd Last Name</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_SecondLastName" alphabetical='alphabetical' ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <!--grupos-->
                    <div class="grupos de_3">
                        <div>
                            <label runat="server" id="Gender" class="label red">Gender</label>
                            <div class="wrap_select">
                                <%-- Bmarroquin 14-01-2017 se deshabilita el campo xq al cambiarlo afecta el calculo original de primas... cabmio forma parte de la tropicalizacion de ESA --%>
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_Gender" validation="Required" ClientIDMode="Static" ></asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="Smoker" class="label red">Smoker </label>
                            <div class="wrap_select">
                                <%-- Bmarroquin 14-01-2017 se deshabilita el campo xq al cambiarlo afecta el calculo original de primas... cabmio forma parte de la tropicalizacion de ESA --%>
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_Smoker" validation="Required" ClientIDMode="Static" ></asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="CountryOfBirth" class="label red">Country of Birth</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_CountryBirth" validation="Required" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="CountryOfCitizenship" class="label red">Country of Citizenship</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_CountryCitizenship" validation="Required" ClientIDMode="Static"></asp:DropDownList>

                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="DateOfBirth" class="label red">Date of Birth</label>
                            <%-- Bmarroquin 14-01-2017 se deshabilita el campo xq al cambiarlo afecta el calculo original de primas... cabmio forma parte de la tropicalizacion de ESA --%>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_DateBirth" class="datepicker_03" validation="Required" ClientIDMode="Static" ></asp:TextBox>
                        </div>
                        <div>
                            <label runat="server" id="Age" class="label red">Age</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_Age" ClientIDMode="Static" validation="Required" ReadOnly="true" disabled></asp:TextBox>
                        </div>
                    </div>
                    <div class="grupos de_2">
                        <div>
                            <label class="label red" runat="server" id="CountryofResidence">Country of Residence</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddlCountryOfResidence" validation="Required">
                                </asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label runat="server" id="MaritalStatus" class="label red">Marital Status</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddl_WUC_PI_MaritalStatus" ClientIDMode="Static" validation="Required"></asp:DropDownList>

                            </div>
                            <!--wrap_select-->
                        </div>
                    </div>
                    <div class="grupos de_2">
                        <div>
                            <label runat="server" id="YearlyPersonalIncome" class="label red">Yearly Personal Income</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_PersonalIncome" decimal="decimal" ClientIDMode="Static" validation="Required"></asp:TextBox>
                        </div>
                        <div>
                            <label runat="server" id="YearlyFamilyIncome" class="label">Yearly Family Income</label>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_YearLyFamilyIncome" decimal="decimal" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <!--grupos-->
                    <div class="grupos de_2">
                        <div id="divOccupation">
                            <label runat="server" id="Occupation" class="label red">Occupation</label>
                            <asp:TextBox runat="server" ID="txtOccupation" ClientIDMode="Static" validation="Required"></asp:TextBox>

                        </div>
                        <div>
                            <label class="label" runat="server" id="OccupationType">Occupation Type</label>

                            <asp:TextBox runat="server" ID="txtProfession" ClientIDMode="Static" ReadOnly="true" validation="Required" disabled></asp:TextBox>

                            <!--wrap_select-->
                        </div>
                    </div>
                <!--grupos-->
                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="CompanyName">Company Name</label>
                        <asp:TextBox runat="server" ID="tb_WUC_PI_CompanyName"></asp:TextBox>
                    </div>
                                                       
                    <div>
                        <label class="label" runat="server" id="TaskPerformed">Task Performed</label>
                        <asp:TextBox runat="server" ID="tb_WUC_PI_TaskPerformed"></asp:TextBox>
                    </div>
                </div>
                <div class="grupos de_2">                      
                    <div>
                        <label class="label" runat="server" id="LineOfBusiness1">Line of Business 1</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_BusinessLine2" ClientIDMode="Static" AutoPostBack="true"   OnSelectedIndexChanged="ddl_BusinessLine2_SelectedIndexChanged" ></asp:DropDownList>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_SecondLineBusiness" Visible="false"></asp:TextBox>
                        </div>
                    </div>                    
                    <div>
                        <label runat="server" id="LineOfBusiness2" class="label">Line of Business 2</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_BusinessLine1" ClientIDMode="Static" AutoPostBack="false"></asp:DropDownList>
                            <asp:TextBox runat="server" ID="tb_WUC_PI_FirstLineBusinnes" Visible="false"></asp:TextBox>
                        </div>
                    </div>  
                </div>
                <div class="grupos de_2">    
                    <div>
                        <label class="label" runat="server" id="YearsatWork">Years at Work</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_WUC_PI_LengthWorkFrom"></asp:DropDownList>

                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="Months">Months</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_WUC_PI_LengthWorkTo"></asp:DropDownList>
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
        <asp:HiddenField runat="server" ID="hdnDateOfBirthBefore" Value="0" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnAge" Value="0" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCurrentSession" runat="server" Value="" />
        <asp:HiddenField ID="hdnOccupationId" runat="server" Value="" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnOccupationGroupId" runat="server" Value="" ClientIDMode="Static" />
    </ContentTemplate>
</asp:UpdatePanel>
