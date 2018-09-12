<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TERMINO.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.ProductControls.TERMINO" %>


<ul class="secundario">
    <li class="ppinfo">
        <div class=" wd100 fl mB">
            <div class=" boxes mR-2-p">
                <label class="label">
                    ILLUSTRATION #:</label>
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

                <%--<select onchange="location.href=this.options[this.selectedIndex].value" class="bgAM txtNG">
                    <option selected value="policy_plandata_sentinel.html">Sentinel</option>
                    <option value="policy_plandata_legacy.html">Legacy</option>
                    <option value="policy_plandata_compas.html">Compass</option>
                    <option value="policy_plandata_compas-index.html">Compass Index</option>
                    <option value="policy_plandata_lighthouse.html">Lighthouse</option>
                    <option value="policy_plandata_axys.html">Axys</option>
                    <option value="policy_plandata_axys.html">Horizon Growth</option>
                    <option value="policy_plandata_horizon.html">Horizon</option>
                    <option value="policy_plandata_scholar.html">Scholar</option>
                    <option value="policy_plandata_scholar.html">Eduplan Growth</option>
                    <option value="policy_plandata_eduplan.html">Eduplan</option>
                </select>--%>
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
                <asp:GridView ID="gvRiderType" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
                    SelectedRowStyle-CssClass="selected_row" ShowHeaderWhenEmpty="False" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                            <ItemTemplate>
                                <asp:Label ID="lblRyderTypeDesc" runat="server" Text='<%# Eval("RyderTypeDesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No data to display
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </div>
            <div class=" boxes">
                <label class="label">
                    Currency:</label>
                <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="" Enabled="false">
                </asp:DropDownList>


                <label class="label">
                    ILLUSTRATION Status:</label>
                <asp:TextBox ID="txtPolicyStatus" runat="server" class="" Enabled="false"></asp:TextBox>
                <label class="label">
                    Rider Benefit Amount:</label>
                <asp:GridView ID="gvRiderBenefitAmount" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
                    SelectedRowStyle-CssClass="selected_row" ShowHeaderWhenEmpty="False" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                            <ItemTemplate>
                               <asp:Label ID="lblBeneficiaryAmount" runat="server" Text='<%# Eval("BeneficiaryAmount")==null ? "": Decimal.Parse(Eval("BeneficiaryAmount").ToString()).ToString("N2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No data to display
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
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
                    Periodic Premium:</label>
                 <!-- ROJAS:PERIODIC PREMIUM ENABLED-->
                <asp:TextBox ID="txtPeriodicPremium" runat="server" class="" Enabled="true"></asp:TextBox>

                <label class="label">
                  Initial Contribution:</label>
                <asp:TextBox ID="txtInitialContribution" runat="server" class="" Enabled="false"></asp:TextBox>
                <label class="label" runat="server" id="TargetAnnualPremium">
                    Target Premium:</label>

                <div style="display:none;"> <%--Bmarroquin a solicitud de la SSF se oculta la prima Target--%>
                  <label class="label">Target Premium:</label>
                  <asp:TextBox ID="txtTargetPremium" runat="server" class="" Enabled="true"></asp:TextBox>
                </div>
            </div>
            <div class=" boxes mR-2-p">
                <label class="label">
                    REINSURANCE AMOUNT:</label>
                <asp:TextBox ID="txtREINSURANCEAMOUNT" runat="server" class="" Enabled="false"></asp:TextBox>
                <label class="label">
                    Total Retention:</label>
                <asp:TextBox ID="txtTotalRetention" runat="server" class="" Enabled="false"></asp:TextBox>

                <%--Bmarroquin a solicitud de la SSF se crea new campo--%>
                <label class="label">Annual Net Premium:</label>
                <asp:TextBox ID="txtPrimaComercial" runat="server" class="" Enabled="false"></asp:TextBox>

                <label class="label">
                    Payment Frecuency:</label>
                <!-- ROJAS:PAYMENT FRECUENCY ENABLED-->
                  <asp:DropDownList ID="ddlPaymentFrecuency" runat="server" Enabled="true"></asp:DropDownList>
            </div>
            <div class=" boxes mR-2-p">
                <label class="label">
                    Total REINSURANCE Amount:</label>
                <asp:TextBox ID="txtTotalREINSURANCEAmount" runat="server" class="" Enabled="false"></asp:TextBox>

                <label class="label">
                    <!-- ROJAS: ROP AMOUNT ENABLE-->
                    Rop Amount:</label>
                <asp:TextBox ID="txtRopAmount" runat="server" class="" Enabled="true"></asp:TextBox>

                 <%--mavelar 4/27/17--%>
                <label class="label">Fraction Surcharge:</label>
                <asp:TextBox ID="txtFraccionamiento" runat="server" class="" Enabled="false" Text="0.00"></asp:TextBox>                
                <label class="label">
                    Contribution Period:</label>
                <!-- ROJAS:CONTRIBUTION PERIOD ENABLED-->
                <asp:TextBox ID="txtContributionPeriod" runat="server" class="" Enabled="true"></asp:TextBox>
                <label class="label" id="lblFinancialInstitution" runat="server" visible="false">
                    Financial Institution:</label>
                <!-- ROJAS:PAYMENT FRECUENCY ENABLED-->
                <asp:DropDownList ID="ddlFinancialInstitution" runat="server"  Visible="false" Enabled="true"></asp:DropDownList>
            </div>
            <div class=" boxes">
                <div class="spH54">
                </div>
                <div class="spH54">
                </div>

                <label class="label">Annual Premium:</label>
                <!-- ROJAS:ANNUAL PREMIUM ENABLED-->
                <asp:TextBox ID="txtAnnualPremium" runat="server" class="" Enabled="true"></asp:TextBox>
                <label class="label"> Min Annual Premium:</label>
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
            </div>
            <div class=" boxes mR-2-p">
                <label class="label">
                    Efective Date:</label>
                <asp:TextBox ID="txtEfectiveDate" runat="server" class="" Enabled="false"></asp:TextBox>
                <label class="label">
                    Termination Date:</label>
                <asp:TextBox ID="txtTerminationDate" runat="server" class="" Enabled="false"></asp:TextBox>


            </div>
            <div class=" boxes mR-2-p">
                <label class="label">
                    Client Acknowledgment Date:</label>

                <asp:TextBox ID="txtClientAcknowledgmentDate" runat="server" class="" Enabled="false"></asp:TextBox>


                <label class="label">Planned Expiration Date:</label>
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
    </li>
</ul>
