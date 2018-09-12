<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PolicyDetail.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.PolicyDetail.PolicyDetail" %>

<div class=" col-3 fl">
    <div class="row_A"><span class="head_rosa hei35 mB">Propietario</span></div>
    <div class="row_A">
        <div class="label_plus_input mT10">
            <span>Nombre Completo</span>
            <asp:TextBox runat="server" ID="txtOName" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input">
            <span>País de Residencia</span>
            <asp:TextBox runat="server" ID="txtOCountryResidence" ReadOnly="True"></asp:TextBox>
        </div>

        <div class="label_plus_input mT10">
            <span>País de Nacimiento</span>
            <asp:TextBox runat="server" ID="txtOCountryBirh" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input">
            <span>Ingreso Anual</span>
            <asp:TextBox runat="server" ID="txtOAnnualIncome" ReadOnly="True"></asp:TextBox>
        </div>
</div>
</div>

<!--COL-2-->
<div class=" col-3 fl">
    <div class="row_A"><span class="head_rosa hei35 mB">Asegurado</span></div>
    <div class="row_A">
        <div class="label_plus_input mT10">
            <span>Nombre Completo</span>
            <asp:TextBox runat="server" ID="txtIName" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input">
            <span>País de Residencia</span>
            <asp:TextBox runat="server" ID="txtICountryResidence" ReadOnly="True"></asp:TextBox>
        </div>

        <div class="label_plus_input mT10">
            <span>Background Check</span>
            <asp:TextBox runat="server" ID="txtIBgck" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input">
            <span>Fumador</span>
            <asp:TextBox runat="server" ID="txtISmoker" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
</div>

<!--COL-3-->
<div class=" col-6 fl">
    <div class="row_A"><span class="head_rosa hei35 mB">Póliza</span></div>
    <!--Bloq 1-->
    <div class="col-6 fl">
        <div class="label_plus_input mT10">
            <span>Tipo de Producto</span>
            <asp:TextBox runat="server" ID="txtPProductType" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input">
            <span>Suma Asegurada</span>
            <asp:TextBox runat="server" ID="txtPInsuredAmount" ReadOnly="True"></asp:TextBox>
        </div>

        <div class="label_plus_input mT10">
            <span>Fecha de Sometida</span>
            <asp:TextBox runat="server" ID="txtPApplicationDate" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input">
            <span>Prima Periódica</span>
            <asp:TextBox runat="server" ID="txtPPeriodicPremium" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <!--Bloq 2-->
    <div class="col-6 fl">
        <div class="label_plus_input mT10">
            <span>Prima Inicial</span>
            <asp:TextBox runat="server" ID="txtPInitialPremium" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input">
            <span>Prima Anual</span>
            <asp:TextBox runat="server" ID="txtPAnnualPremium" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input mT10">
            <span>Años de Contribución</span>
            <asp:TextBox runat="server" ID="txtPYearsConstribution" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="label_plus_input">
            <span>Suscriptor</span>
            <asp:TextBox runat="server" ID="txtPUnderwriter" ReadOnly="True"></asp:TextBox>
        </div>

    </div>

</div>
<!--COL-3 /> -->
