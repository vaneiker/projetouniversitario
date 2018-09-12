<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VIDA.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.ProductControls.VIDA" %>
<ul class="secundario">
    <li class="ppinfo">
        <div id="dvPlPnVida">


            <div class="wd100 fl mB">
                <div class=" boxes mR-2-p">
                    <label class="label">
                        POLICY #:</label>
                    <asp:TextBox ID="txtPolicy" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Insured Name:</label>
                    <asp:TextBox ID="txtInsuredName" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Insured Amount:</label>
                    <asp:TextBox ID="txtInsuredAmount" runat="server" class="" Enabled="true"></asp:TextBox>
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
                        Total Insured Amount:</label>
                    <asp:TextBox ID="txtTotalInsuredAmount" runat="server" class="" Enabled="false"></asp:TextBox>
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Plan Type:</label>
                    <asp:DropDownList ID="ddlPlanType" runat="server" Enabled="false">
                    </asp:DropDownList>
                    <label class="label">
                        Additional Insured Name:</label>
                    <asp:TextBox ID="txtAdditionalInsuredName" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Rider Type:</label>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <div>
                                    Term Insurance
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    ADB
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    Aditional Insured
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class=" boxes">
                    <label class="label">
                        Currency:</label>
                    <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="" Enabled="false">
                    </asp:DropDownList>
                    <label class="label">
                        Policy Status:</label>
                    <asp:TextBox ID="txtPolicyStatus" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Rider Benefit Amount:</label>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <div>
                                    100,000
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    100,000
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    50,000
                                </div>
                            </td>
                        </tr>
                    </table>
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
                        Target Premium:</label>
                    <asp:TextBox ID="txtTargetPremium" runat="server" class="" Enabled="true"></asp:TextBox>
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
                </div>
                <div class=" boxes mR-2-p">
                    <label class="label">
                        Total Reins Amount:</label>
                    <asp:TextBox ID="txtTotalREINSURANCEAmount" runat="server" class="" Enabled="false"></asp:TextBox>
                    <label class="label">
                        Investment Profile:</label>
                    <asp:DropDownList ID="ddlInvestmentProfile" runat="server" alt="dvPlPnVida" onChange="BtnProfileVisiblility(this);">
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
                    <asp:TextBox ID="txtMinAnnualPremium" runat="server" class="" Enabled="true"></asp:TextBox>
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
            <!-- //Bloque 3     -->
        </div>
    </li>
</ul>
