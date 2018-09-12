<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCReject.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.Popups.UCReject" %>
<asp:UpdatePanel runat="server" ID="upPopReject">
    <ContentTemplate>
        <div class="rechazar_pp modal pop3" id="dvPopReject">
            <header>
                <h1>RECHAZAR</h1>
                <a data-modal-close="true" href="#" onclick="CloseAjaxPop(this, 'hdnShowReject');" popname="mpReject">&times;</a>
            </header>
            <!--CAMPOS EDITABLES-->
            <div class="row mB">
                <!--COL-1-->
                <div class=" col-4 fl">
                    <div class="row_A">
                        <div class="label_plus_input mT10">
                            <span># Póliza</span>
                            <asp:TextBox runat="server" ID="txtRPPolicy" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="label_plus_input">
                            <span>Nombre Propietario</span>
                            <asp:TextBox runat="server" ID="txtRPOwnerName" ReadOnly="True"></asp:TextBox>
                        </div>

                    </div>
                </div>

                <!--COL-2-->
                <div class=" col-4 fl">

                    <div class="row_A">
                        <div class="label_plus_input mT10">
                            <span>Tipo de Producto</span>
                            <asp:TextBox runat="server" ID="txtRPProductType" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="label_plus_input mT10">
                            <span>Monto Prima Inicial</span>
                            <asp:TextBox runat="server" ID="txtRPInitialPremium" ReadOnly="True"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <!--COL-2 /> -->

                <!--COL-3-->
                <div class=" col-4 fl">
                    <div class="row_A">
                        <div class="label_plus_input mT10">
                            <span>Agente</span>
                             <asp:TextBox runat="server" ID="txtRPAgentName" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="label_plus_input mT10">
                            <span>Oficina</span>
                            <asp:TextBox runat="server" ID="txtRPOffice" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <!--COL-3 /> -->

            </div>
            <!--CAMPOS EDITABLES /> -->

            <div class="row_A mB ">
                 <asp:TextBox runat="server" ID="txtRPComment" CssClass="hei266 textarea_pink" placeholder="Comentarios" 
                     TextMode="MultiLine" validation="Required"  label="Comentarios"></asp:TextBox>
            </div>

            <div class="col-12 fl">
                <asp:Button runat="server" ID="btnPRRechazar" Text="Rechazar" CssClass="btn1 btn bfusia fr" OnClick="btnPRRechazar_OnClick" OnClientClick="return ValidateAndConfirm(this, 'dvPopReject');"/>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
