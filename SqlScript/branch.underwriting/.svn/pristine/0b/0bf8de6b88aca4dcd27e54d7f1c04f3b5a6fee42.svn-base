<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTermInsurance.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCTermInsurance" %>
<script type="text/javascript">
    function ChangeContributionType() {
        var ddlContType = document.getElementById('ddlContributionType');
    }
</script>
<ul>
    <li>
        <div class="fondo_blanco">
            <div class="content_fondo_blanco">
                <div class="col-1-2">
                    <fieldset>
                        <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.Caracteristics %></legend>
                        <div class="grupos de_2">
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Currency %></label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlCurrency" validation="Required" onchange="ChangeContributionType()">
                                        <asp:ListItem Text="Option 1" />
                                        <asp:ListItem Text="Option 2" />
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.FrequencyofPaymentLabel %></label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlFrequencyPayment" validation="Required">
                                        <asp:ListItem Text="Option 1" />
                                        <asp:ListItem Text="Option 2" />
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div id="divSpecialPayment" runat="server"  visible="false" >
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.SpecialPaymentLabel %></label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlSpecialPayment" validation="Required" AutoPostBack="true" OnPreRender="ddlSpecialPayment_PreRender">
                                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ContributionTypeLabel %></label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlContributionType" validation="Required">
                                        <asp:ListItem Text="Option 1" />
                                        <asp:ListItem Text="Option 2" />
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div id="divContributionPeriod">
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ContributionPeriodLabel %> (<%=RESOURCE.UnderWriting.NewBussiness.Resources.Years %>)</label>
                                <asp:TextBox runat="server" ID="txtContributionPeriod" validation="Required" ClientIDMode="Static" number='number2' />
                            </div>
                            <div id="divContributionPeriodMonth" style="display:none;">
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ContributionPeriodLabel %> (<%=RESOURCE.UnderWriting.NewBussiness.Resources.MonthsLabel %>)</label>
                                <asp:TextBox runat="server" ID="txtContributionPeriodMonth" validation="Required" Text="0" ClientIDMode="Static" number='number2' />
                            </div>
                            <div>
                                <label runat="server" id="lblEffectiveDate" class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.EffectiveFromDate %></label>
                                <asp:TextBox runat="server" ID="txtEffectiveDate" class="datepicker_03" ClientIDMode="Static" validation="Required" Visible="true" AutoPostBack="false"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                    <!--grupos-->
                    <fieldset>
                        <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.Others %></legend>
                        <div class="grupos de_2">
                            <div id ="divPaymentSpecial" runat="server"  visible="false">
                                <label class="label" id="lblPaymentSpecial"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PaymentSpecialLabel %></label>
                                <asp:TextBox ID="txtSpecialPayment" runat="server" decimal="decimal" onkeydown="if (event.keyCode == 13) return false;"></asp:TextBox>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InitialContributionLabel %></label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlInitialContribution" ClientIDMode="Static">
                                        <asp:ListItem Text="Option 1" />
                                        <asp:ListItem Text="Option 2" />
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div id="divInitialContribution">
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AmountLabel %></label>
                                <asp:TextBox runat="server" ID="txtInitialContributionAmount" ClientIDMode="Static" decimal='decimal' />
                            </div>
                            <div id="divFinancialInstitution" runat="server"  visible="false">
                                <label class="label" runat="server" id="lblFinancialIntitution"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InstitutionFinancialLabel%></label>
                                <div class="wrap_select">
                                    <asp:DropDownList ID="ddlFinancialInstitution" runat="server" OnPreRender="ddlFinancialInstitution_PreRender">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="otherWithATL">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="chkOtherPlanWithSTL" ClientIDMode="Static" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblOtherPlanWith"><%=RESOURCE.UnderWriting.NewBussiness.Resources.lblOtherPlansWithATL %></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </fieldset>
                    <div class="grupos de_2" id="divFinancigRateAndDestiny" runat="server"  visible="false">
                        <div >
                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.FinancingRateLabel %></label>

                            <asp:TextBox ID="txtFinancingRate" runat="server" decimal="decimal" onkeydown="if (event.keyCode == 13) return false;"></asp:TextBox>

                            <!--wrap_select-->
                        </div>
                        <div>
                            <label class="label" runat="server" id="lblDestinyFund"><%=RESOURCE.UnderWriting.NewBussiness.Resources.DestinyFund %></label>
                            <div class="wrap_select">
                                <asp:DropDownList ID="ddlDestinyFund" runat="server" AutoPostBack="true">
                                    <asp:ListItem Text="Inmueble" Value="Inmueble"></asp:ListItem>
                                    <asp:ListItem Text="Automovil" Value="Automovil"></asp:ListItem>
                                    <asp:ListItem Text="Personal" Value="Personal"></asp:ListItem>
                                    <asp:ListItem Text="Otros" Value="Otros"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <!--grupos-->

                </div>

                <!--col-1-2-->

                <div class="col-1-2">
                    <fieldset class="important2">
                        <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.Calculate %></legend>
                        <div class="grupos de_2">
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Calculate %></label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlCalculate" ClientIDMode="Static">
                                        <asp:ListItem Text="Option 1" />
                                        <asp:ListItem Text="Option 2" />
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                        </div>
                        <!--grupos-->
                        <div class="grupos de_2">

                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PremiumAmount %></label>
                                <asp:TextBox runat="server" ID="txtPeriodicPremiumAmount" ClientIDMode="Static" decimal='decimal' />
                            </div>
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmountLabel %></label>
                                <asp:TextBox runat="server" ID="txtInsuredBenefitRetirementAmount" ClientIDMode="Static" decimal='decimal' />
                            </div>
                        </div>
                        <!--grupos-->
                    </fieldset>

                    <fieldset class="margin_t_10">
                        <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.RiskRating %></legend>
                        <div class="grupos de_2">
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Risk %></label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlRisk" validation="Required">
                                        <asp:ListItem Text="Option 1" />
                                        <asp:ListItem Text="Option 2" />
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PerThousand %></label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlPerThousand" validation="Required">
                                        <asp:ListItem Text="Option 1" />
                                        <asp:ListItem Text="Option 2" />
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                        </div>
                        <!--grupos-->
                    </fieldset>
                </div>
                <!--col-1-2-->
            </div>
            <!--content_fondo_blanco-->
        </div>
        <!--fondo_blanco-->

    </li>
</ul>
