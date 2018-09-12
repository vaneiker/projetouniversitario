<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCFieldFooterElite.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products.WUCFieldFooterElite" %>
<asp:UpdatePanel runat="server" ID="udpFieldFooter">
    <ContentTemplate>

        <asp:Panel runat="server" ID="pnFooter" class="col-1-1" ClientIDMode="Static">
            <div class="barra_azul_celeste">
                <div class='<%= "grupos de_6 alingtoend alingTopFun" + ObjServices.Language.ToString() %>'>
                    <div>
                        <label class="label" runat="server" id="PeriodicPremium">Periodic Premium</label>
                        <asp:TextBox ID="txtPeriodicPremium" onchange="GetAnnualPremium('txtPeriodicPremium','ddlFrequencyofPayment')" runat="server" AllowEnter="false" ClientIDMode="Static" TabIndex="2" decimal="decimal" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="AnnualPremium">Annual Premium</label>
                        <asp:TextBox ID="txtAnnualPremium" Enabled="false" runat="server" ClientIDMode="Static" decimal="decimal" TabIndex="1" AllowEnter="false" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="SelectiveTax">Selective Tax Insurance</label>
                        <asp:TextBox ID="txtSelectiveTax" runat="server" TabIndex="3" ClientIDMode="Static" ReadOnly="true" AllowEnter="false" decimal="decimal"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="AnnualPremiumWithTax">Annual Premium With Tax</label>
                        <asp:TextBox ID="txtAnnualPremiumWithTax" runat="server" TabIndex="3" ClientIDMode="Static" ReadOnly="true" AllowEnter="false" decimal="decimal"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="TotalInsuredAmount">Total Insured Amount</label>
                        <asp:TextBox ID="txtInsuredAmount" ClientIDMode="Static" runat="server" TabIndex="0" ReadOnly="true" decimal="decimal" AllowEnter="false" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="TargetAnnualPremium">Target Annual Premium</label>
                        <asp:TextBox ID="txtTargetAnnualPremium" runat="server" ClientIDMode="Static" TabIndex="3" decimal="decimal" AllowEnter="false" validation="Required"></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hdAnnualPremium" runat="server"  ClientIDMode="Static"  />
