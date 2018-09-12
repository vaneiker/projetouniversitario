<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCDocuments.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.Popups.UCDocuments" %>
<%@ Register TagPrefix="PdfViewer" Namespace="PdfViewer4AspNet" Assembly="PdfViewerAspNet, Version=3.1.0.29040, Culture=neutral, PublicKeyToken=5b5f377bc08a4d32" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:UpdatePanel runat="server" ID="upPopDocuments">
    <ContentTemplate>
        <div class="documento_pp modal pop2" id="dvPopDocument">
            <header>
                <h1>DOCUMENTO</h1>
                  <a data-modal-close="true" href="#" onclick="CloseAjaxPop(this, 'hdnShowDocuments');" popname="mpDocuments">&times;</a>
            </header>
            <!--GRID-->
            <div class="col-7 fl pdR">
                <!--GRID PRINCIPAL-->
                <div class="row_A">
                    <div class="tbl data_G">
                        <asp:GridView ID="gvPopDocuments" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ClientIDMode="Static"
                            DataKeyNames="Corp_Id,Region_Id,Country_Id,Domesticreg_Id,State_Prov_Id,City_Id,Office_Id,Case_Seq_No,Hist_Seq_No,Ammendment_Id,Is_Completed, Doc_Type_Id, Doc_Category_Id, Document_Id"
                            OnPageIndexChanging="gvPopDocuments_OnPageIndexChanging" AllowPaging="true" PageSize="3">
                            <Columns>
                                <asp:TemplateField HeaderText="Persona" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocumentName" runat="server" Text='<%# Eval("Insured_Scope_Desc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PDF" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="upPopPdf">
                                            <ContentTemplate>
                                                <asp:LinkButton runat="server" ID="btnPdf" CssClass="ico_G pdf" OnClick="btnPdf_OnClick" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnPdf" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <div class="pagination m0">
                                    <p>
                                        Página
                            <asp:Literal ID="indexPage" runat="server" />
                                        de
                            <asp:Literal ID="totalPage" runat="server" />
                                        (<asp:Literal ID="totalItems" runat="server" />
                                        elementos)
                                    </p>
                                    <asp:UpdatePanel runat="server" ID="upPopAmmendment">
                                        <ContentTemplate>
                                            <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                                            <asp:LinkButton runat="server" CssClass="prev_dis" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                                            <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                                            <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="firstButton" />
                                            <asp:AsyncPostBackTrigger ControlID="prevButton" />
                                            <asp:AsyncPostBackTrigger ControlID="nextButton" />
                                            <asp:AsyncPostBackTrigger ControlID="lastButton" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </PagerTemplate>
                            <EmptyDataTemplate>
                                No hay data para mostrar
                            </EmptyDataTemplate>
                            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" CssClass="EmptyGrid" />
                            <HeaderStyle CssClass="gradient_azul" />
                        </asp:GridView>
                    </div>
                </div>
                <!--GRID PRINCIPAL /> -->

                <!--CAMPOS EDITABLES-->
                <div class="row mB hei438 mT15">
                    <!--COL-1-->
                    <div class=" col-4 fl">
                        <div class="row_A">
                            <div class="label_plus_input mT10">
                                <span># Póliza</span>
                                <asp:TextBox runat="server" ID="txtDPPolicyNo" ReadOnly="True"></asp:TextBox>
                            </div>
                           <%-- <div class="label_plus_input">
                                <span>Fecha Vigencia</span>
                                <asp:TextBox runat="server" ID="txtDPEffectiveDate" ReadOnly="True"></asp:TextBox>
                            </div>--%>

                            <div class="label_plus_input mT10">
                                <span>Plan</span>
                                <asp:TextBox runat="server" ID="txtDBPlanName" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="label_plus_input">
                                <span>Moneda</span>
                                <asp:TextBox runat="server" ID="txtDPCurrency" ReadOnly="True"></asp:TextBox>
                            </div>
                           <%-- <div class="line2 label_plus_input mT10">
                                <span>Día Aniversario Mensual</span>
                                <asp:TextBox runat="server" ID="txtDPAnniversaryDay" ReadOnly="True"></asp:TextBox>
                            </div>--%>
                           <%-- <div class="label_plus_input">
                                <span>Fecha Expiración</span>
                                <asp:TextBox runat="server" ID="txtDPExpirationDate" ReadOnly="True"></asp:TextBox>
                            </div>--%>
                            <div class="label_plus_input mT10">
                                <span>Prima Inicial</span>
                                <asp:TextBox runat="server" ID="txtDPInitialPremium" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input">
                                <span>Prima Periódica Planificada</span>
                                <asp:TextBox runat="server" ID="txtDPPeriodicPremium" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input">
                                <span>Suma Asegurada Inicial</span>
                                <asp:TextBox runat="server" ID="txtDPInsuredInitialPremium" ReadOnly="True"></asp:TextBox>
                            </div>

                        </div>
                    </div>

                    <!--COL-2-->
                    <div class=" col-4 fl">

                        <div class="row_A">
                            <div class="label_plus_input mT10">
                                <span>Suplementos</span>
                                <asp:TextBox runat="server" ID="txtDPRider" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input">
                                <span>Seguro Muerte Accidental</span>
                                <asp:TextBox runat="server" ID="txtDPDeadRider" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input mT10">
                                <span>Seguro Temporal Adicional</span>
                                <asp:TextBox runat="server" ID="txtDPTempAditional" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input">
                                <span>Seguro Asegurado Adicional</span>
                                <asp:TextBox runat="server" ID="txtDPAdditionalIsured" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input">
                                <span>Dirección Propietario</span>
                                <asp:TextBox runat="server" ID="txtDPOwnerAddress" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="label_plus_input mT10">
                                <span>Cédula o RNC</span>
                                <asp:TextBox runat="server" ID="txtDPOwnerIdNo" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input mT10">
                                <span>Dirección Asegurado</span>
                                <asp:TextBox runat="server" ID="txtDPInsuredAddress" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="label_plus_input mT10">
                                <span>Cédula o RNC</span>
                                <asp:TextBox runat="server" ID="txtDPInsuredIdNo" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="label_plus_input">
                                <span>Beneficiarios</span>
                                <asp:TextBox runat="server" ID="txtDPBeneficiaries" ReadOnly="True"></asp:TextBox>
                            </div>

                        </div>
                    </div>

                    <!--COL-2 /> -->

                    <!--COL-3-->
                    <div class=" col-4 fl">

                        <div class="row_A fl">
                            <div class="line2 label_plus_input mT10">
                                <span>Beneficiarios Contingentes</span>
                                <asp:TextBox runat="server" ID="txtDPContingentBeneficiary" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input">
                                <span>Propietario del Plan</span>
                                <asp:TextBox runat="server" ID="txtDPPlanOwner" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="label_plus_input mT10">
                                <span>Asegurado</span>
                                <asp:TextBox runat="server" ID="txtDPInsured" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="line2 label_plus_input">
                                <span>Edad del Asegurado</span>
                                <asp:TextBox runat="server" ID="txtDPInsuredAge" ReadOnly="True"></asp:TextBox>
                            </div>

                        </div>
                        <!--division-->
                        <div class="row fl">
                            <div class="col-6 label_plus_input fl">
                                <span>Sexo</span>
                                <asp:TextBox runat="server" ID="txtDPSex" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="f col-6 label_plus_input fl">
                                <span>Fumador</span>
                                <asp:TextBox runat="server" ID="txtDPSmoker" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <!--division-->

                        <div class="row_A fl">
                            <div class="line2 label_plus_input">
                                <span>Período de Contribución</span>
                                <asp:TextBox runat="server" ID="txtDPContributionPeriod" ReadOnly="True"></asp:TextBox>
                            </div>
                         <%--   <div class="line2 label_plus_input mT10">
                                <span>Período de Duración del seguro</span>
                                <asp:TextBox runat="server" ID="txtDPPeriodDuration" ReadOnly="True"></asp:TextBox>
                            </div>--%>
                            <div class="line2 label_plus_input">
                                <span>Frecuencia de Contribución</span>
                                <asp:TextBox runat="server" ID="txtDPContributionFrequency" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="label_plus_input mT10">
                                <span>% de Devolución</span>
                                <asp:TextBox runat="server" ID="txtDPReturnRate" ReadOnly="True"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <!--COL-3 /> -->
                </div>
                <!--CAMPOS EDITABLES /> -->
            </div>
            <!--PDF-->
            <div class="col-5 fl">
                <div class=" row_box hei635">
                    <PdfViewer:PdfViewer ID="pdfDocuments" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Width="764px" Height="440px">
                    </PdfViewer:PdfViewer>
                </div>
            </div>
            <!--PDF /> -->

            <div class="col-12 fl">
                <asp:LinkButton runat="server" ID="btnGenerateDocument" ClientIDMode="Static" Text="Generar" CssClass="btn1 btn bfusia fr" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
