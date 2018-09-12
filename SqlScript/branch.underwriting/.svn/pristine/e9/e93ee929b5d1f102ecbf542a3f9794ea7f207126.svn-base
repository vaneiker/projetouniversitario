<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAsistenciaalViajeroAnual-60díascontinuos.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products.UCAsistenciaalViajeroAnual_60díascontinuos" %>
<div class="col-1-4-c">
    <div class="fondo_blanco fix_height">
        <div class="titulos_azules">
            <span class="insured"></span><strong>
                <asp:Literal runat="server" ID="planinformation">PLAN INFORMATION</asp:Literal></strong>
        </div>
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
                        <asp:DropDownList ID="ddlProductName" runat="server" AutoPostBack="true" validation="Required">
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
                    <label class="label red" runat="server" id="lblDeducible">Deducible</label>
                    <div class="wrap_select">
                       <asp:DropDownList ID="ddlDeducible" ClientIDMode="Static" runat="server" validation="Required">
                        </asp:DropDownList>
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

                <div>
                    <label class="label red" runat="server" id="lblEffectiveDate">Effective Date</label>
                    <asp:TextBox ID="txtEffectiveDate" ClientIDMode="Static" CssClass="datepicker" runat="server" validation="Required"></asp:TextBox>
                </div>
            </div>
            <div class="break_line"></div>
            <div class="grupos de_2">
                <div>
                    <label class="label" runat="server" id="DepositAmount">Deposit Amount</label>
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
            <!--grupos-->
            <fieldset class="margin_t_10">
                <legend>
                    <asp:Literal runat="server" ID="ltRidersLabel">RIDERS</asp:Literal>
                </legend>
                <div class="grupos de_2">
                    <div>
                        <label class="label" runat="server" id="lblDependents">Dependents</label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlDependents" runat="server" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>                      
                </div>
            </fieldset>
        </asp:Panel>
        <!--content_fondo_blanco-->
    </div>
    <!--fondo_blanco-->
</div>
<asp:HiddenField runat="server" ID="hdnDeductibleTypeID" Value="-1" />
<!--col-1-4-c-->
