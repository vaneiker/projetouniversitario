<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLegacy.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products.UCLegacy" %>
<div class="col-1-4-c">
    <div class="fondo_blanco fix_height">
          <div class="titulos_azules"><span class="insured"></span><strong><asp:Literal runat="server" ID="planinformation">PLAN INFORMATION</asp:Literal></strong></div>
        <asp:Panel runat="server" ClientIDMode="Static" class="content_fondo_blanco" ID="frmPlan">
            <div class="grupos de_3">
                <div>
                    <label class="label red" runat="server" id="FamilyProduct">Family Product</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlFamilyProduct" runat="server" AutoPostBack="true" validation="Required"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label red" runat="server" id="PlanName">Plan Name</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlProductName" runat="server" AutoPostBack="true"  validation="Required">
                        </asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <asp:panel runat="server" ID="pnPlanType">
                    <label class="label red" runat="server" id="PlanType">Plan Type</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlPlanType" runat="server"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </asp:panel>
                <div>
                    <label class="label red" runat="server" id="Currency">Currency</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlCurrency" runat="server" validation="Required" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label red" runat="server" id="FrequencyOfPayment">Frequency of Payment</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlFrequencyofPayment" ClientIDMode="Static" onchange="GetAnnualPremium('txtPeriodicPremium','ddlFrequencyofPayment')" runat="server" validation="Required"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
               <asp:panel runat="server" ID="pnInvestmentProfile" ClientIDMode="Static">
                    <label class="label red" runat="server" id="InvestmentProfile">Investment Profile</label>
                    <div class="wrap_select wd77">
                        <asp:DropDownList ID="ddlInvestmentProfile" runat="server" validation="Required" ClientIDMode="Static" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                    <asp:Button runat="server" ID="btnPprofile" CssClass="pprofile fr mT5 buttonDisabled" alt="Customize investment profile" ClientIDMode="Static" Enabled="false"/>
                </asp:panel>
                <div>
                    <label class="label red" runat="server" id="ContributionType">Contribution Type</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlContributionType" runat="server" AutoPostBack="true" validation="Required">
                        </asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label red" runat="server" id="Years">Years</label>
                    <asp:TextBox ID="txtContributionPeriod" runat="server" number="number2" validation="Required"></asp:TextBox>
                </div>
            </div>
            <div class="break_line"></div>

            <div class="grupos de_2">
                <div>
                    <label class="label" runat="server" id="InitialContribution">Initial Contribution</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlInitialContribution" runat="server" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label" runat="server" id="Amount">Amount</label>
                    <asp:TextBox ID="txtAmount" runat="server" decimal="decimal"></asp:TextBox>
                </div>
            </div>

            <div class="grupos de_1" style="display:none">
                <div>
                    <label class="label" runat="server" id="AmountGoal">Amount Goal</label>
                    <asp:TextBox ID="txtAmount2" runat="server" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div>
                    <label class="label" runat="server" id="AtAgeGoal">At Age Goal</label>
                    <asp:TextBox ID="txtAtAge" runat="server" ClientIDMode="Static" number="number2"></asp:TextBox>
                </div>
            </div>
            <!--grupos-->
            <fieldset class="margin_t_10">
                <legend><asp:Literal runat="server" ID="ltRidersLabel">RIDERS</asp:Literal> </legend>
                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="AccidentalDeathBenefits">Accidental Death Benefits</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlAccidentalDeathBenefits" runat="server" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="InsuredAmount">Insured Amount</label>
                        <asp:TextBox ID="txtAccidentalDeathInsuredAmount" decimal="decimal" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="grupos de_1">
                    <div>
                        <label class="label" runat="server" id="SpouseOtherInsured">Spouse/Other Insured</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlSpouseOtherInsured" runat="server" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="InsuredSpouseOtherInsuredAmount">Insured Amount</label>
                        <asp:TextBox ID="txtSpouseOtherInsured" decimal="decimal" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="YearsspouseOther">Years</label>
                        <asp:TextBox ID="txtYearsSpouseOther" runat="server" number="number2" validation="Required"></asp:TextBox>
                    </div>
                </div>

                <div class="grupos de_2">
                    <%-- <div>
                        <label class="label">Critical Illness</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlCritialIllness" runat="server" Enabled="false" Visible="false">
                                <asp:ListItem Text="NO" Value="2" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label">Insured Amount</label>
                        <asp:TextBox ID="txtCritialIllnessInsuredAmount" Enabled="false" runat="server" decimal="decimal" Visible="false"></asp:TextBox>
                    </div>--%>
                    <div>
                        <label class="label" runat="server" id="AdditionalTermInsurance">Additional Term Insurance</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlAdditionalTermInsurance" runat="server" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="AdditonalTermInsuredAmount">Insured Amount</label>
                        <asp:TextBox ID="txtAdditionalTermInsuranceInsuredAmount" runat="server" decimal="decimal"></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->
            </fieldset>

        </asp:Panel>
        <!--content_fondo_blanco-->
    </div>
    <!--fondo_blanco-->
</div>
<!--col-1-4-c-->
