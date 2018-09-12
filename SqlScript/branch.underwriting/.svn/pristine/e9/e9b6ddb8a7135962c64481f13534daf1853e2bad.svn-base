<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCFieldFooterScholar.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products.WUCFieldFooterScholar" %>
<asp:UpdatePanel runat="server" ID="udpFieldFooter">
    <ContentTemplate>

        <asp:Panel runat="server" ID="pnFooter" class="col-1-1" ClientIDMode="Static">
            <div class="barra_azul_celeste">
                <div class="grupos de_8 alingtoend">
                    <div>
                        <label class="label" runat="server" id="TotalStudyAmount">Total Study Amount</label>
                        <asp:TextBox ID="txtBenefitAmount" runat="server" ClientIDMode="Static" TabIndex="0" decimal="decimal"  AllowEnter="false" validation="Required"></asp:TextBox>
                    </div>                   
                    <div>
                        <label class="label" runat="server" id="PeriodicPremium">Periodic Premium</label>
                        <asp:TextBox ID="txtPeriodicPremium" onchange="GetAnnualPremium('txtPeriodicPremium','ddlFrequencyofPayment')" runat="server" AllowEnter="false" ClientIDMode="Static" TabIndex="2" decimal="decimal"  validation="Required"></asp:TextBox>
                    </div>                   
                    <div>
                        <label class="label" runat="server" id="TargetAnnualPremium">Target Annual Premium</label>
                        <asp:TextBox ID="txtTargetAnnualPremium" runat="server" ClientIDMode="Static" decimal="decimal" TabIndex="3"  AllowEnter="false" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="MinimumAnnualPremium">Minimum Annual Premium</label>
                        <asp:TextBox ID="txtMinimumAnnualPremium" runat="server" ClientIDMode="Static" decimal="decimal" TabIndex="4"  AllowEnter="false" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="ProspectAgeatStartofRetirement">Prospect Age at Start of Retirement</label>
                        <asp:TextBox ID="txtProspectAgeStartRetirement" runat="server" ClientIDMode="Static" data-inputmask="'alias': 'integer', 'groupSeparator': ',', 'autoGroup': true" ReadOnly="true" TabIndex="5" AllowEnter="false"></asp:TextBox>
                    </div>
                     <div>
                        <label class="label" runat="server" id="AnnualPremium">Annual Premium</label>
                        <asp:TextBox ID="txtAnnualPremium" Enabled="false"  runat="server" ClientIDMode="Static" decimal="decimal" TabIndex="1"  validation="Required" AllowEnter="false"></asp:TextBox>
                    </div>
                     <div>
                        <label class="label" runat="server" id="SelectiveTax">Selective Tax Insurance</label>
                        <asp:TextBox ID="txtSelectiveTax" runat="server" TabIndex="3" ClientIDMode="Static" ReadOnly="true" decimal="decimal" AllowEnter="false"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="AnnualPremiumWithTax">Annual Premium With Tax</label>
                        <asp:TextBox ID="txtAnnualPremiumWithTax" runat="server" TabIndex="3" ClientIDMode="Static" ReadOnly="true" decimal="decimal" AllowEnter="false" ></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hdAnnualPremium" runat="server"  ClientIDMode="Static"  />