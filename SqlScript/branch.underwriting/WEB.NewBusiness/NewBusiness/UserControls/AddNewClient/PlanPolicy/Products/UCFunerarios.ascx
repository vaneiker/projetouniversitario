<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFunerarios.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products.UCFunerarios" %>
<div class="col-1-4-c">
    <div class="fondo_blanco fix_height">
        <div class="titulos_azules">
            <span class="insured"></span><strong>
                <asp:Literal runat="server" ID="planinformation">PLAN INFORMATION</asp:Literal></strong>
        </div>
        <asp:Panel runat="server" ClientIDMode="Static" class="content_fondo_blanco" ID="frmPlan">
            <fieldset class="margin_t_10">
                <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.Caracteristics %> & <%=RESOURCE.UnderWriting.NewBussiness.Resources.Others %></legend>
                <div class="grupos de_1">
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
                            <asp:DropDownList ID="ddlProductName" runat="server" validation="Required" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label red" runat="server" id="Currency">Currency</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlCurrency" runat="server" validation="Required" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label red" runat="server" id="FrequencyofPayment">Frequency of Payment</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlFrequencyofPayment" ClientIDMode="Static" onchange="GetAnnualPremium('txtPeriodicPremium','ddlFrequencyofPayment')" runat="server" validation="Required"></asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
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
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlContributionPeriod" runat="server" validation="Required">
                                <asp:ListItem Selected="True" Value="-1">----</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>

                    <%-- <div>
                        <label class="label red" runat="server" id="Years">Years</label>
                        <asp:TextBox ID="txtContributionPeriod" runat="server" number="number2" validation="Required"></asp:TextBox>
                    </div>--%>
                </div>
                <!--grupos-->

            
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
            </fieldset>
            <!--grupos-->

            <fieldset class="margin_t_10">
                <legend>
                    <asp:Literal runat="server" ID="ltRidersLabel">RIDERS</asp:Literal>
                </legend>
                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="OthersInsureds">Family plan</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddlOtherInsured" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="Repatriation">Repatriation</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddlRepatriation" OnPreRender="TranslateDrop_PreRender">
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                </div>
                <asp:Panel runat="server" class="grupos de_2" ID="pnLote" Visible="false">
                    <div>
                        <label class="label" runat="server" id="Lote">Lote</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddlLote" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="LoteType">Lote Type</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddlLoteType">
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                </asp:Panel>
                <!--grupos-->
            </fieldset>
        </asp:Panel>
        <!--content_fondo_blanco-->
        <!--fondo_blanco-->
    </div>
</div>
