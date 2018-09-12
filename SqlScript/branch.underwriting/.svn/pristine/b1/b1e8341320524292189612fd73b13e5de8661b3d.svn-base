<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFuneral.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCFuneral" %>
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
                                    <asp:DropDownList runat="server" ID="ddlCurrency" validation="Required">
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
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddlContributionPeriod" ClientIDMode="Static">
                                        <asp:ListItem Text="Option 1" />
                                        <asp:ListItem Text="Option 2" />
                                    </asp:DropDownList>
                                </div>
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
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PremiumAmount %></label>
                                <asp:TextBox runat="server" ID="txtInsuredBenefitRetirementAmount" ClientIDMode="Static" Visible="false" />
                                <asp:TextBox runat="server" ID="txtPeriodicPremiumAmount" ClientIDMode="Static" decimal='decimal' />
                            </div>
                        </div>
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
