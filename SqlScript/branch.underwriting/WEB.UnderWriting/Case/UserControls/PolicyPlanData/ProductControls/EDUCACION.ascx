<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EDUCACION.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.ProductControls.EDUCACION" %>
<ul class="secundario">
    <li class="ppinfo">
        <div id="dvPlPnEducacion">
            <div class=" wd100 fl mB">
                <div class=" boxes mR-2-p">
                    <label class="label">
                        POLICY #:</label>
                    <asp:TextBox ID="txtPolicy" runat="server" class="" Enabled="false" CssClass="bgAM txtNG"></asp:TextBox>
                    <label class="label">
                        Retire/Insured Name:</label>
                    <asp:TextBox ID="txtInsuredName" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        <!-- ROJAS: ENABLE BENEFIT AMOUNT -->
                        Total Benefit Amount:</label>
                    <asp:TextBox ID="txtTotalBenefitAmount" runat="server" class="" Enabled="true"></asp:TextBox>
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Plan Name:</label>
                    <asp:DropDownList ID="ddlPlanName" runat="server" Enabled="false">
                    </asp:DropDownList>
                    <label class="label">
                        Owner Name:</label>
                    <asp:TextBox ID="txtOwnerName" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Annual Benefit Amount:</label>
                    <asp:TextBox ID="txtAnnualBenefitAmount" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Plan Type:</label>
                    <asp:DropDownList ID="ddlPlanType" runat="server" Enabled="false">
                    </asp:DropDownList>
                    <label class="label">
                        Student Designated Name:</label>
                    <asp:TextBox ID="txtStudentDesignatedName" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
                <div class=" boxes">
                    <label class="label">
                        Currency:</label>
                    <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="" Enabled="false">
                    </asp:DropDownList>
                    <label class="label">
                        Policy Status:</label>
                    <asp:TextBox ID="txtPolicyStatus" runat="server" class="" Enabled="false" CssClass="bgAM txtNG"></asp:TextBox>
                </div>
            </div>
            <!--Bloque 2 -->
            <div class=" wd100 fl mB">
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Cumulative Risk:</label>
                    <asp:TextBox ID="txtCumulativeRisk" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Retention:</label>
                    <asp:TextBox ID="txtRetention" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Initial Contribution:</label>
                    <asp:TextBox ID="txtInitialContribution" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                         <!-- ROJAS:TARGET PREMIUN ENABLED-->
                        Target Premium:</label>
                    <asp:TextBox ID="txtTargetPremium" runat="server" class="" Enabled="true"></asp:TextBox>
                    <label class="label">
                        Education Period:</label>
                    <asp:TextBox ID="txtEducationPeriod" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        REINSURANCE AMOUNT:</label>

                    <asp:TextBox ID="txtREINSURANCEAMOUNT" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Total Retention:</label>
                    <asp:TextBox ID="txtTotalRetention" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Periodic Premium:</label>
                     <!-- ROJAS:PERIODIC PREMIUM ENABLED-->
                    <asp:TextBox ID="txtPeriodicPremium" runat="server" class="" Enabled="true"></asp:TextBox>
                    <label class="label">
                        Payment Frecuency:</label>
                    <!-- ROJAS:PAYMENT FRECUENCY ENABLED-->
                      <asp:DropDownList ID="ddlPaymentFrecuency" runat="server" Enabled="true"></asp:DropDownList>
                    <label class="label">
                        Student Age:</label>
                    <asp:TextBox ID="txtStudentAge" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Total REINSURANCE Amount:</label>
                    <asp:TextBox ID="txtTotalREINSURANCEAmount" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Investment Profile:</label>
                    <asp:DropDownList ID="ddlInvestmentProfile" runat="server" alt="dvPlPnEducacion" onChange="BtnProfileVisiblility(this);">
                    </asp:DropDownList>
                    <label class="label">
                        Annual Premium:</label>
                    <!-- ROJAS:ANNUAL PREMIUM ENABLED-->
                    <asp:TextBox ID="txtAnnualPremium" runat="server" class="" Enabled="true"></asp:TextBox>
                    <label class="label">
                        Contribution Period:</label>
                    <!-- ROJAS:CONTRIBUTION PERIOD ENABLED-->
                    <asp:TextBox ID="txtContributionPeriod" runat="server" class="" Enabled="true"></asp:TextBox>
                </div>
                <div class=" boxes">
                    <div class="spH73">
                    </div>
                    <asp:Panel ID="dvBtnPersonalizedProfile" ClientIDMode="Static" runat="server" CssClass="wd100 hg35" Style="display: none;">
                        <div class="boton_wrapper gradient_vd2 bdrVd2 fl">
                            <span class="pprofile"></span>
                            <asp:Button ID="btnPersonalizedProfile" CssClass="boton" runat="server" Text="Personalized Profile" OnClick="btnPersonalizedProfile_Click" />
                        </div>
                    </asp:Panel>
                    <label class="label">
                        Min Annual Premium:</label>
                    <!-- ROJAS:MINIMUN ANNUAL PREMIUM ENABLED-->
                    <asp:TextBox ID="txtMinAnnualPremium" runat="server" class="" Enabled="true"></asp:TextBox>
                    <label class="label">
                        Deferral Period:</label>
                    <asp:TextBox ID="txtDefferalPeriod" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <!--Bloque 3   -->
            <div class="resalto_AM">
                <div class=" wd100 fl">
                    <label class="label txtBold em1-3">
                        Dates And Periods</label>
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Submitted Date:</label>
                    <asp:TextBox ID="txtSubmittedDate" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Last Payment Date:</label>
                    <asp:TextBox ID="txtLastPaymentDate" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        INSURANCE INCLUSION DATE:</label>
                    <asp:TextBox ID="txtInsuranceInclusionDate" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Efective Date:</label>
                    <asp:TextBox ID="txtEfectiveDate" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Termination Date:</label>
                    <asp:TextBox ID="txtTerminationDate" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        INSURANCE EXCLUSION DATE:</label>
                    <asp:TextBox ID="txtInsuranceInclusionDateEnd" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Client Acknowledgment Date:</label>
                    <asp:TextBox ID="txtClientAcknowledgmentDate" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Planned Expiration Date:</label>
                    <asp:TextBox ID="txtPlannedExpirationDate" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
                <div class=" boxes">
                    <label class="label">
                        Insured Period:</label>
                    <asp:TextBox ID="txtInsuredPeriod" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Expired Date:</label>
                    <asp:TextBox ID="txtExpiredDate" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>
        <!-- //Bloque 3     -->
    </li>
</ul>
