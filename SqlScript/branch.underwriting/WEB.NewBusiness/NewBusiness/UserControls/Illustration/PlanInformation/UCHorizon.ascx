<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHorizon.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCHorizon" %>
<ul>
    <li>
        <div class="fondo_blanco">
            <div class="content_fondo_blanco">
                <div class="col-1-2">
                    <div class="grupos de_2">
                        <div>
                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PlanTypeLabel %></label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddlPlanType" validation="Required">
                                    <asp:ListItem Text="Horizon" />
                                    <asp:ListItem Text="Option 2" />
                                </asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
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
                        <div id="divContributionPeriod">
                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ContributionPeriodLabel %> (<%=RESOURCE.UnderWriting.NewBussiness.Resources.Years %>)</label>
                            <asp:TextBox runat="server" ID="txtContributionPeriod" validation="Required" ClientIDMode="Static" number='number' />
                        </div>
                        <div>
                            <label class="label">Retirement Period</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddlEducationRetirementPeriod" validation="Required">
                                    <asp:ListItem Text="Option 1" />
                                    <asp:ListItem Text="Option 2" />
                                </asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.DefermentPeriod %></label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddlDefermentPeriod" validation="Required">
                                    <asp:ListItem Text="Option 1" />
                                    <asp:ListItem Text="Option 2" />
                                </asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                    </div>
                    <!--grupos-->
                    <div class="break_line"></div>
                    <div class="grupos de_2">
                        <div>
                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InitialContributionLabel %></label>
                            <div class="wrap_select">
                                <%--Bmarroquin 24-03-2017 se Deshabilita dado que actualmente no se utiliza --%>
                                <asp:DropDownList runat="server" ID="ddlInitialContribution" ClientIDMode="Static" disabled="disabled">
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
                    </div>
                        <div style="display:none;">
                            <asp:CheckBox runat="server" ID="chkOtherPlanWithSTL" ClientIDMode="Static" />
                            <asp:Label runat="server" ID="lblOtherPlanWith"></asp:Label>
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
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PeriodicPremium %></label>
                                <asp:TextBox runat="server" ID="txtPeriodicPremiumAmount" ClientIDMode="Static" decimal='decimal' />
                            </div>
                            <div>
                                <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AnnualRetirementAmount %></label>
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
