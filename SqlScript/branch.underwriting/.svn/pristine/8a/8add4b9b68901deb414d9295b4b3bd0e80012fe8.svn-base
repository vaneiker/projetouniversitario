<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSentinel.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products.UCSentinel" %>
<div class="col-1-4-c">
    <div class="fondo_blanco fix_height">
         <div class="titulos_azules"><span class="insured"></span><strong><asp:Literal runat="server" ID="planinformation">PLAN INFORMATION</asp:Literal></strong></div>
        <asp:Panel runat="server" ClientIDMode="Static" class="content_fondo_blanco" ID="frmPlan">
            <fieldset class="margin_t_10">
                <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.Caracteristics %> & <%=RESOURCE.UnderWriting.NewBussiness.Resources.Others %></legend>
                    <div class="grupos de_3">
                        <div>
                            <label class="label red" runat="server" id="FamilyProduct">Family Product</label>
                            <div class="wrap_select">
                                <asp:DropDownList ID="ddlFamilyProduct" runat="server" AutoPostBack="true"  validation="Required"></asp:DropDownList>
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
                                <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="true" validation="Required"></asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label class="label red" runat="server" id="FrequencyOfPayment">Frequency of Payment</label>
                            <div class="wrap_select">
                                <asp:DropDownList ID="ddlFrequencyofPayment" onchange="GetAnnualPremium('txtPeriodicPremium','ddlFrequencyofPayment')" ClientIDMode="Static"  runat="server" validation="Required"></asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <asp:panel runat="server" ID="pnInvestmentProfile" ClientIDMode="Static" style="display:none">
                            <label class="label red" runat="server" id="InvestmentProfile">Investment Profile</label>
                            <div class="wrap_select wd77">
                                <asp:DropDownList ID="ddlInvestmentProfile" runat="server" ClientIDMode="Static" AutoPostBack="true">
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
                            <%--<asp:TextBox ID="txtContributionPeriod" runat="server" number="number2" validation="Required" ClientIDMode="Static"></asp:TextBox>--%>
                            <div class="wrap_select">
                                <asp:DropDownList ID="ddlContributionPeriod" runat="server" validation="Required">
                                </asp:DropDownList>
                            </div>
                        </div> 
                    </div>
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
                            <asp:TextBox ID="txtAmount" runat="server" decimal="decimal" onkeydown="if (event.keyCode == 13) return false;"></asp:TextBox>
                        </div>
                    </div>
                </fieldset>
            <div class="grupos de_1" style="display:none">
                <%--<div>
                    <label class="label" runat="server" id="FinancialGoal">Financial Goal</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlFinancialGlobal" runat="server" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>--%>
                <div>
                    <label class="label" runat="server" id="Amount2">Amount Goal</label>
                    <asp:TextBox ID="txtAmount2" runat="server" decimal="decimal" onkeydown="if (event.keyCode == 13) return false;" ></asp:TextBox>
                </div>
                <div>
                    <label class="label" runat="server" id="AtAgeGoal" >At Age Goal</label>
                    <asp:TextBox ID="txtAtAge" runat="server" number="number2" onkeydown="if (event.keyCode == 13) return false;" ></asp:TextBox>
                </div>
            </div>
            <!--grupos-->
            <fieldset class="margin_t_10">
              <legend><asp:Literal runat="server" ID="ltRidersLabel">RIDERS</asp:Literal> </legend>

                <div class="grupos de_2 alingtoend">
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
                        <asp:TextBox ID="txtAccidentalDeathInsuredAmount" runat="server" decimal="decimal" onkeydown="if (event.keyCode == 13) return false;" ></asp:TextBox>
                    </div>   
                </div>

                <div class="grupos de_1 alingtoend">
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
                        <asp:TextBox ID="txtSpouseOtherInsured" runat="server" decimal="decimal" onkeydown="if (event.keyCode == 13) return false;"></asp:TextBox>
                    </div>

                    <div>
                        <label class="label" runat="server" id="YearsspouseOther">Years</label>
                        <asp:TextBox ID="txtYearsSpouseOther" runat="server" number="number2" onkeydown="if (event.keyCode == 13) return false;"></asp:TextBox>
                    </div>
                </div>

                <div class="grupos de_2 alingtoend">
                      <div>
                        <label class="label" runat="server" id="CriticalIllness">Critical Illness</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlCritialIllness" runat="server" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender" Enabled="false">
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem> 
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="CritialIllnessInsuredAmount">Insured Amount</label>
                        <asp:TextBox ID="txtCritialIllnessInsuredAmount" runat="server" decimal="decimal" Enabled="false" onkeydown="if (event.keyCode == 13) return false;"></asp:TextBox>
                    </div>
                </div>

                <div class="grupos de_2 alingtoend">                  
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
                        <asp:TextBox ID="txtAdditionalTermInsuranceInsuredAmount" runat="server" decimal="decimal"  onkeydown="if (event.keyCode == 13) return false;"></asp:TextBox>
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