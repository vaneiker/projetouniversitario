<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEditNeverIssued.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.NeverIssued.Popups.UCEditNeverIssued" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<!--POP UP EDITAR-->
<div class="editar_pp modal pop1" id="dvPopEditNeverIssued">
    <header>
        <h1>EDITAR</h1>
        <a data-modal-close="true" href="#" onclick="CloseAjaxPop(this, 'hdnShowEditNeverIssued');" popname="mpEditNeverIssued">&times;</a>
    </header>
    <!--CAMPOS EDITABLES-->
    <div class="row mB">
        <!--COL-1-->
        <div class=" col-4 fl">
            <div class="row_A">
                <div class="label_plus_input mT10">
                    <span># Póliza</span>
                    <asp:TextBox runat="server" ID="txtENIPolicy" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="label_plus_input">
                    <span>Nombre Propietario</span>
                    <asp:TextBox runat="server" ID="txtENIOwnerName" ReadOnly="True"></asp:TextBox>
                </div>

                <div class="label_plus_input mT10">
                    <span>Fecha Solicitud</span>
                    <asp:TextBox runat="server" ID="txtENIApplicationDate" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
        </div>

        <!--COL-2-->
        <div class=" col-4 fl">

            <div class="row_A">
                <div class="label_plus_input mT10">
                    <span>Tipo de Producto</span>
                    <asp:TextBox runat="server" ID="txtENIProductType" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="label_plus_input mT10">
                    <span>Monto Prima Inicial</span>
                    <asp:TextBox runat="server" ID="txtENIInitialPremium" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="label_plus_input mT10">
                    <span>Razon Never Issued</span>
                    <asp:DropDownList runat="server" ID="ddlENINeverIssued" validation="Required" />
                </div>
            </div>
        </div>
        <!--COL-2 /> -->

        <!--COL-3-->
        <div class=" col-4 fl">
            <div class="row_A">
                <div class="label_plus_input mT10">
                    <span>Agente</span>
                    <asp:TextBox runat="server" ID="txtENIAgentName" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="label_plus_input mT10">
                    <span>Oficina</span>
                    <asp:TextBox runat="server" ID="txtENIOffice" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="mT20">

                    <div class="ckLabel">
                        <div class="check_lb">
                            <asp:CheckBox runat="server" ID="chkENIPenalty" ClientIDMode="Static" />
                            <label for="chkENIPenalty"></label>
                        </div>
                        <span>Penalidad</span>
                    </div>
                </div>
            </div>
        </div>
        <!--COL-3 /> -->

    </div>
    <!--CAMPOS EDITABLES /> -->

    <div class="row_A mB ">
        <asp:TextBox runat="server" ID="txtENIComment" CssClass="hei266 textarea_pink" placeholder="Comentarios"
            TextMode="MultiLine" validation="Required" label="Comentarios"></asp:TextBox>
    </div>

    <div class="col-12 fl">
        <asp:Button runat="server" ID="btnENISend" Text="Enviar" CssClass="btn1 btn bfusia fr" OnClick="btnENISend_OnClick" OnClientClick="return validateForm('dvPopEditNeverIssued');" />
    </div>
</div>
<!-- POP UP EDITAR /> -->
