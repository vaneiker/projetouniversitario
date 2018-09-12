<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCFieldFooterEduplan.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products.WUCFieldFooterEduplan" %>
<asp:UpdatePanel runat="server" ID="udpFieldFooter">
    <ContentTemplate>

        <asp:Panel runat="server" ID="pnFooter" class="col-1-1" ClientIDMode="Static">
            <div class="barra_azul_celeste">
                <div class="grupos de_7 alingtoend">
                    <div>
                        <label class="label" runat="server" id="TotalStudyAmount">Total Study Amount</label>
                        <asp:TextBox ID="txtBenefitAmount" runat="server" ClientIDMode="Static" TabIndex="0" decimal="decimal" AllowEnter="false" validation="Required"></asp:TextBox>
                    </div>                    
                    <div>
                        <label class="label" runat="server" id="PeriodicPremium">Periodic Premium</label>
                        <asp:TextBox ID="txtPeriodicPremium" onchange="GetAnnualPremium('txtPeriodicPremium','ddlFrequencyofPayment')" AllowEnter="false" runat="server" ClientIDMode="Static" TabIndex="2" decimal="decimal"  validation="Required"></asp:TextBox>
                    </div>                    
                    <div>
                        <label class="label" runat="server" id="TargetAnnualPremium">Target Annual Premium</label>
                        <asp:TextBox ID="txtTargetAnnualPremium" runat="server" ClientIDMode="Static" TabIndex="3" decimal="decimal"  AllowEnter="false" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="ProspectAgeatStartofEducation">Prospect Age at Start of Education</label>
                        <asp:TextBox ID="txtProspectAgeStartRetirement" runat="server" ClientIDMode="Static" ReadOnly="true" AllowEnter="false" TabIndex="4"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="AnnualPremium">Annual Premium</label>
                        <asp:TextBox ID="txtAnnualPremium" Enabled="false"  runat="server" ClientIDMode="Static" decimal="decimal" AllowEnter="false" TabIndex="1" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="SelectiveTax">Selective Tax Insurance</label>
                        <asp:TextBox ID="txtSelectiveTax" runat="server" TabIndex="3" ClientIDMode="Static" ReadOnly="true" AllowEnter="false" decimal="decimal" ></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="AnnualPremiumWithTax">Annual Premium With Tax</label>
                        <asp:TextBox ID="txtAnnualPremiumWithTax" runat="server" TabIndex="3" ClientIDMode="Static" ReadOnly="true" AllowEnter="false" decimal="decimal" ></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hdAnnualPremium" runat="server"  ClientIDMode="Static"  />
