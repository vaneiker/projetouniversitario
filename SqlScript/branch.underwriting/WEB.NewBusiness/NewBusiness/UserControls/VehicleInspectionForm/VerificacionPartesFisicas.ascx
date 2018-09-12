<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VerificacionPartesFisicas.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm.VerificacionPartesFisicas" %>

<div class="fondo_gris">
    <div class="col-1-2">
        <div class="fondo_blanco" style="height: 814px;">
            <div class="titulos_azules"><strong>EXTERIOR</strong></div>
            <div style="padding: 10px;" class="inspection_radio_table">
                <table style="width: 100%;" id="VCPPE">
                    <thead>
                        <tr>
                            <th>
                                <br />
                            </th>
                            <th class="titulo" style="padding-left: 13px; font-family: Verdana; font-size: 9pt;">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleOptionGood %></span>
                            </th>
                            <th class="titulo" style="padding-left: 13px; font-family: Verdana; font-size: 9pt;">
                                <span>R</span>
                            </th>
                            <th class="titulo" style="padding-left: 12px; font-family: Verdana; font-size: 9pt;">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleOptionBad %></span>
                            </th>
                            <th class="titulo" style="padding-left: 10px; font-family: Verdana; font-size: 9pt;">
                                <span>No</span>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label1" ItemId="1" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="B" ClassDesc="Exterior" GroupName="GuaDelDer" ID="rbGuaDelDerB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="R" ClassDesc="Exterior" GroupName="GuaDelDer" ID="rbGuaDelDerR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="M" ClassDesc="Exterior" GroupName="GuaDelDer" ID="rbGuaDelDerM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="No" ClassDesc="Exterior" GroupName="GuaDelDer" ID="rbGuaDelDerNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label22" ItemId="13" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="13" OptionDesc="B" ClassDesc="Exterior" GroupName="GuaDelIzq" ID="rbGuaDelIzqB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="13" OptionDesc="R" ClassDesc="Exterior" GroupName="GuaDelIzq" ID="rbGuaDelIzqR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="13" OptionDesc="M" ClassDesc="Exterior" GroupName="GuaDelIzq" ID="rbGuaDelIzqM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="13" OptionDesc="No" ClassDesc="Exterior" GroupName="GuaDelIzq" ID="rbGuaDelIzqNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label2" ItemId="2" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="B" ClassDesc="Exterior" GroupName="GuaTraDer" ID="rbGuaTraDerB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="R" ClassDesc="Exterior" GroupName="GuaTraDer" ID="rbGuaTraDerR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="M" ClassDesc="Exterior" GroupName="GuaTraDer" ID="rbGuaTraDerM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="No" ClassDesc="Exterior" GroupName="GuaTraDer" ID="rbGuaTraDerNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label23" ItemId="14" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="14" OptionDesc="B" ClassDesc="Exterior" GroupName="GuaTraIzq" ID="rbGuaTraIzqB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="14" OptionDesc="R" ClassDesc="Exterior" GroupName="GuaTraIzq" ID="rbGuaTraIzqR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="14" OptionDesc="M" ClassDesc="Exterior" GroupName="GuaTraIzq" ID="rbGuaTraIzqM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="14" OptionDesc="No" ClassDesc="Exterior" GroupName="GuaTraIzq" ID="rbGuaTraIzqNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label3" ItemId="3" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="B" ClassDesc="Exterior" GroupName="Bonete" ID="rbBoneteB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="R" ClassDesc="Exterior" GroupName="Bonete" ID="rbBoneteR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="M" ClassDesc="Exterior" GroupName="Bonete" ID="rbBoneteM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="No" ClassDesc="Exterior" GroupName="Bonete" ID="rbBoneteNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label4" ItemId="4" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="4" OptionDesc="B" ClassDesc="Exterior" GroupName="BumDel" ID="rbBumDelB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="4" OptionDesc="R" ClassDesc="Exterior" GroupName="BumDel" ID="rbBumDelR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="4" OptionDesc="M" ClassDesc="Exterior" GroupName="BumDel" ID="rbBumDelM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="4" OptionDesc="No" ClassDesc="Exterior" GroupName="BumDel" ID="rbBumDelNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label24" ItemId="15" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="15" OptionDesc="B" ClassDesc="Exterior" GroupName="BumTra" ID="rbBumTraB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="15" OptionDesc="R" ClassDesc="Exterior" GroupName="BumTra" ID="rbBumTraR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="15" OptionDesc="M" ClassDesc="Exterior" GroupName="BumTra" ID="rbBumTraM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="15" OptionDesc="No" ClassDesc="Exterior" GroupName="BumTra" ID="rbBumTraNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label5" ItemId="5" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="B" ClassDesc="Exterior" GroupName="LucDel" ID="rbLucDelB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="R" ClassDesc="Exterior" GroupName="LucDel" ID="rbLucDelR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="M" ClassDesc="Exterior" GroupName="LucDel" ID="rbLucDelM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="No" ClassDesc="Exterior" GroupName="LucDel" ID="rbLucDelNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label25" ItemId="16" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="16" OptionDesc="B" ClassDesc="Exterior" GroupName="LucTra" ID="rbLucTraB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="16" OptionDesc="R" ClassDesc="Exterior" GroupName="LucTra" ID="rbLucTraR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="16" OptionDesc="M" ClassDesc="Exterior" GroupName="LucTra" ID="rbLucTraM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="16" OptionDesc="No" ClassDesc="Exterior" GroupName="LucTra" ID="rbLucTraNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label6" ItemId="6" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="B" ClassDesc="Exterior" GroupName="CPPTecho" ID="rbCPPTechoB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="R" ClassDesc="Exterior" GroupName="CPPTecho" ID="rbCPPTechoR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="M" ClassDesc="Exterior" GroupName="CPPTecho" ID="rbCPPTechoM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="No" ClassDesc="Exterior" GroupName="CPPTecho" ID="rbCPPTechoNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label7" ItemId="7" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="7" OptionDesc="B" ClassDesc="Exterior" GroupName="ComBauTra" ID="rbComBauTraB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="7" OptionDesc="R" ClassDesc="Exterior" GroupName="ComBauTra" ID="rbComBauTraR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="7" OptionDesc="M" ClassDesc="Exterior" GroupName="ComBauTra" ID="rbComBauTraM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="7" OptionDesc="No" ClassDesc="Exterior" GroupName="ComBauTra" ID="rbComBauTraNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label8" ItemId="8" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="8" OptionDesc="B" ClassDesc="Exterior" GroupName="PueDerDel" ID="rbPueDerDelB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="8" OptionDesc="R" ClassDesc="Exterior" GroupName="PueDerDel" ID="rbPueDerDelR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="8" OptionDesc="M" ClassDesc="Exterior" GroupName="PueDerDel" ID="rbPueDerDelM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="8" OptionDesc="No" ClassDesc="Exterior" GroupName="PueDerDel" ID="rbPueDerDelNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label26" ItemId="17" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="17" OptionDesc="B" ClassDesc="Exterior" GroupName="PueDerTra" ID="rbPueDerTraB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="17" OptionDesc="R" ClassDesc="Exterior" GroupName="PueDerTra" ID="rbPueDerTraR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="17" OptionDesc="M" ClassDesc="Exterior" GroupName="PueDerTra" ID="rbPueDerTraM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="17" OptionDesc="No" ClassDesc="Exterior" GroupName="PueDerTra" ID="rbPueDerTraNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label27" ItemId="18" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="18" OptionDesc="B" ClassDesc="Exterior" GroupName="PueIzqDel" ID="rbPueIzqDelB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="18" OptionDesc="R" ClassDesc="Exterior" GroupName="PueIzqDel" ID="rbPueIzqDelR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="18" OptionDesc="M" ClassDesc="Exterior" GroupName="PueIzqDel" ID="rbPueIzqDelM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="18" OptionDesc="No" ClassDesc="Exterior" GroupName="PueIzqDel" ID="rbPueIzqDelNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label28" ItemId="19" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="19" OptionDesc="B" ClassDesc="Exterior" GroupName="PueIzqTra" ID="rbPueIzqTraB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="19" OptionDesc="R" ClassDesc="Exterior" GroupName="PueIzqTra" ID="rbPueIzqTraR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="19" OptionDesc="M" ClassDesc="Exterior" GroupName="PueIzqTra" ID="rbPueIzqTraM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="19" OptionDesc="No" ClassDesc="Exterior" GroupName="PueIzqTra" ID="rbPueIzqTraNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label9" ItemId="9" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="9" OptionDesc="B" ClassDesc="Exterior" GroupName="Aros" ID="rbArosB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="9" OptionDesc="R" ClassDesc="Exterior" GroupName="Aros" ID="rbArosR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="9" OptionDesc="M" ClassDesc="Exterior" GroupName="Aros" ID="rbArosM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="9" OptionDesc="No" ClassDesc="Exterior" GroupName="Aros" ID="rbArosNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label10" ItemId="20" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="20" OptionDesc="B" ClassDesc="Exterior" GroupName="Gomas" ID="rbGomasB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="20" OptionDesc="R" ClassDesc="Exterior" GroupName="Gomas" ID="rbGomasR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="20" OptionDesc="M" ClassDesc="Exterior" GroupName="Gomas" ID="rbGomasM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="20" OptionDesc="No" ClassDesc="Exterior" GroupName="Gomas" ID="rbGomasNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label11" ItemId="11" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="11" OptionDesc="B" ClassDesc="Exterior" GroupName="ParDel" ID="rbParDelB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="11" OptionDesc="R" ClassDesc="Exterior" GroupName="ParDel" ID="rbParDelR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="11" OptionDesc="M" ClassDesc="Exterior" GroupName="ParDel" ID="rbParDelM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="11" OptionDesc="No" ClassDesc="Exterior" GroupName="ParDel" ID="rbParDelNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label12" ItemId="12" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="12" OptionDesc="B" ClassDesc="Exterior" GroupName="Antena" ID="rbAntenaB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="12" OptionDesc="R" ClassDesc="Exterior" GroupName="Antena" ID="rbAntenaR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="12" OptionDesc="M" ClassDesc="Exterior" GroupName="Antena" ID="rbAntenaM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="12" OptionDesc="No" ClassDesc="Exterior" GroupName="Antena" ID="rbAntenaNo" runat="server" /></td>
                        </tr>

                        <%--Cristales--%>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label20" ItemId="21" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="21" OptionDesc="B" ClassDesc="Exterior" GroupName="CriDel" ID="rbCriDelB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="21" OptionDesc="R" ClassDesc="Exterior" GroupName="CriDel" ID="rbCriDelR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="21" OptionDesc="M" ClassDesc="Exterior" GroupName="CriDel" ID="rbCriDelM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="21" OptionDesc="No" ClassDesc="Exterior" GroupName="CriDel" ID="rbCriDelNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label32" ItemId="22" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="22" OptionDesc="B" ClassDesc="Exterior" GroupName="CriDelIzq" ID="rbCriDelIzqB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="22" OptionDesc="R" ClassDesc="Exterior" GroupName="CriDelIzq" ID="rbCriDelIzqR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="22" OptionDesc="M" ClassDesc="Exterior" GroupName="CriDelIzq" ID="rbCriDelIzqM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="22" OptionDesc="No" ClassDesc="Exterior" GroupName="CriDelIzq" ID="rbCriDelIzqNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label33" ItemId="23" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="23" OptionDesc="B" ClassDesc="Exterior" GroupName="CriDelDer" ID="rbCriDelDerB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="23" OptionDesc="R" ClassDesc="Exterior" GroupName="CriDelDer" ID="rbCriDelDerR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="23" OptionDesc="M" ClassDesc="Exterior" GroupName="CriDelDer" ID="rbCriDelDerM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="23" OptionDesc="No" ClassDesc="Exterior" GroupName="CriDelDer" ID="rbCriDelDerNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label34" ItemId="24" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="24" OptionDesc="B" ClassDesc="Exterior" GroupName="CriTra" ID="rbCriTraB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="24" OptionDesc="R" ClassDesc="Exterior" GroupName="CriTra" ID="rbCriTraR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="24" OptionDesc="M" ClassDesc="Exterior" GroupName="CriTra" ID="rbCriTraM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="24" OptionDesc="No" ClassDesc="Exterior" GroupName="CriTra" ID="rbCriTraNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label35" ItemId="25" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="25" OptionDesc="B" ClassDesc="Exterior" GroupName="CriTraIzq" ID="rbCriTraIzqB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="25" OptionDesc="R" ClassDesc="Exterior" GroupName="CriTraIzq" ID="rbCriTraIzqR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="25" OptionDesc="M" ClassDesc="Exterior" GroupName="CriTraIzq" ID="rbCriTraIzqM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="25" OptionDesc="No" ClassDesc="Exterior" GroupName="CriTraIzq" ID="rbCriTraIzqNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Exterior" Font-Bold="true" Font-Size="12px" ID="Label36" ItemId="26" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="26" OptionDesc="B" ClassDesc="Exterior" GroupName="CriTraDer" ID="rbCriTraDerB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="26" OptionDesc="R" ClassDesc="Exterior" GroupName="CriTraDer" ID="rbCriTraDerR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="26" OptionDesc="M" ClassDesc="Exterior" GroupName="CriTraDer" ID="rbCriTraDerM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="26" OptionDesc="No" ClassDesc="Exterior" GroupName="CriTraDer" ID="rbCriTraDerNo" runat="server" /></td>
                        </tr>
                        <%--Cristales--%>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class="col-1-2">
        <div class="fondo_blanco" style="height: 256px;">
            <div class="titulos_azules"><strong>INTERIOR</strong></div>
            <div style="padding: 10px;" class="inspection_radio_table">
                <table style="width: 100%;" id="VCPPI">
                    <thead>
                        <tr>
                            <th>
                                <br />
                            </th>
                            <th class="titulo" style="padding-left: 13px; font-family: Verdana; font-size: 9pt;">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleOptionGood %></span>
                            </th>
                            <th class="titulo" style="padding-left: 13px; font-family: Verdana; font-size: 9pt;">
                                <span>R</span>
                            </th>
                            <th class="titulo" style="padding-left: 12px; font-family: Verdana; font-size: 9pt;">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleOptionBad %></span>
                            </th>
                            <th class="titulo" style="padding-left: 10px; font-family: Verdana; font-size: 9pt;">
                                <span>No</span>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Interior" Font-Bold="true" Font-Size="12px" ID="Label13" ItemId="1" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="B" ClassDesc="Interior" GroupName="AsiDel" ID="rbAsiDelB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="R" ClassDesc="Interior" GroupName="AsiDel" ID="rbAsiDelR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="M" ClassDesc="Interior" GroupName="AsiDel" ID="rbAsiDelM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="No" ClassDesc="Interior" GroupName="AsiDel" ID="rbAsiDelNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Interior" Font-Bold="true" Font-Size="12px" ID="Label29" ItemId="5" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="B" ClassDesc="Interior" GroupName="AsiTra" ID="rbAsiTraB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="R" ClassDesc="Interior" GroupName="AsiTra" ID="rbAsiTraR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="M" ClassDesc="Interior" GroupName="AsiTra" ID="rbAsiTraM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="No" ClassDesc="Interior" GroupName="AsiTra" ID="rbAsiTraNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Interior" Font-Bold="true" Font-Size="12px" ID="Label14" ItemId="2" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="B" ClassDesc="Interior" GroupName="TecInt" ID="rbTecIntB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="R" ClassDesc="Interior" GroupName="TecInt" ID="rbTecIntR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="M" ClassDesc="Interior" GroupName="TecInt" ID="rbTecIntM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="No" ClassDesc="Interior" GroupName="TecInt" ID="rbTecIntNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Interior" Font-Bold="true" Font-Size="12px" ID="Label15" ItemId="3" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="B" ClassDesc="Interior" GroupName="CPPTablero" ID="rbCPPTableroB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="R" ClassDesc="Interior" GroupName="CPPTablero" ID="rbCPPTableroR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="M" ClassDesc="Interior" GroupName="CPPTablero" ID="rbCPPTableroM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="No" ClassDesc="Interior" GroupName="CPPTablero" ID="rbCPPTableroNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Interior" Font-Bold="true" Font-Size="12px" ID="Label16" ItemId="4" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="4" OptionDesc="B" ClassDesc="Interior" GroupName="Baul" ID="rbBaulB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="4" OptionDesc="R" ClassDesc="Interior" GroupName="Baul" ID="rbBaulR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="4" OptionDesc="M" ClassDesc="Interior" GroupName="Baul" ID="rbBaulM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="4" OptionDesc="No" ClassDesc="Interior" GroupName="Baul" ID="rbBaulNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Interior" Font-Bold="true" Font-Size="12px" ID="Label30" ItemId="6" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="B" ClassDesc="Interior" GroupName="GomRep" ID="rbGomRepB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="R" ClassDesc="Interior" GroupName="GomRep" ID="rbGomRepR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="M" ClassDesc="Interior" GroupName="GomRep" ID="rbGomRepM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="No" ClassDesc="Interior" GroupName="GomRep" ID="rbGomRepNo" runat="server" /></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class="col-1-2">
        <br />
    </div>

    <div class="col-1-2">
        <div class="fondo_blanco" style="height: 220px;">
            <div class="titulos_azules"><strong><%= RESOURCE.UnderWriting.NewBussiness.Resources.Others %></strong></div>
            <div style="padding: 10px;" class="inspection_radio_table">
                <table style="width: 100%;" id="VCPPO">
                    <thead style="background-color: white;">
                        <tr>
                            <th><br /></th>
                            <th class="titulo" style="padding-left: 13px; font-family: Verdana; font-size: 9pt;">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleOptionGood %></span>
                            </th>
                            <th class="titulo" style="padding-left: 13px; font-family: Verdana; font-size: 9pt;">
                                <span>R</span>
                            </th>
                            <th class="titulo" style="padding-left: 12px; font-family: Verdana; font-size: 9pt;">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleOptionBad %></span>
                            </th>
                            <th class="titulo" style="padding-left: 10px; font-family: Verdana; font-size: 9pt;">
                                <span>No</span>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Otros" Font-Bold="true" Font-Size="12px" ID="Label17" ItemId="1" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="B" ClassDesc="Otros" GroupName="GPS" ID="rbGPSB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="R" ClassDesc="Otros" GroupName="GPS" ID="rbGPSR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="M" ClassDesc="Otros" GroupName="GPS" ID="rbGPSM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="1" OptionDesc="No" ClassDesc="Otros" GroupName="GPS" ID="rbGPSNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Otros" Font-Bold="true" Font-Size="12px" ID="Label18" ItemId="2" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="B" ClassDesc="Otros" GroupName="Alarma" ID="rbAlarmaB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="R" ClassDesc="Otros" GroupName="Alarma" ID="rbAlarmaR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="M" ClassDesc="Otros" GroupName="Alarma" ID="rbAlarmaM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="2" OptionDesc="No" ClassDesc="Otros" GroupName="Alarma" ID="rbAlarmaNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Otros" Font-Bold="true" Font-Size="12px" ID="Label31" ItemId="6" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="B" ClassDesc="Otros" GroupName="OtrMecSeg" ID="rbOtrMecSegB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="R" ClassDesc="Otros" GroupName="OtrMecSeg" ID="rbOtrMecSegR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="M" ClassDesc="Otros" GroupName="OtrMecSeg" ID="rbOtrMecSegM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="6" OptionDesc="No" ClassDesc="Otros" GroupName="OtrMecSeg" ID="rbOtrMecSegNo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Otros" Font-Bold="true" Font-Size="12px" ID="Label19" ItemId="3" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="B" ClassDesc="Otros" GroupName="SisCom" ID="rbSisComB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="R" ClassDesc="Otros" GroupName="SisCom" ID="rbSisComR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="M" ClassDesc="Otros" GroupName="SisCom" ID="rbSisComM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="3" OptionDesc="No" ClassDesc="Otros" GroupName="SisCom" ID="rbSisComNo" runat="server" /></td>
                        </tr>
                        <%--<tr>
                                            <td style="height: 30px;">
                                                <asp:Label ClassDesc="Otros" Font-Bold="true" Font-Size="12px" ID="Label20" ItemId="4" runat="server" Text="?"></asp:Label>
                                            </td>
                                            <td class="center_align">
                                                <asp:RadioButton ItemId="4" OptionDesc="B" ClassDesc="Otros" GroupName="AdiEsp" ID="rbAdiEspB" runat="server" /></td>
                                            <td class="center_align">
                                                <asp:RadioButton ItemId="4" OptionDesc="R" ClassDesc="Otros" GroupName="AdiEsp" ID="rbAdiEspR" runat="server" /></td>
                                            <td class="center_align">
                                                <asp:RadioButton ItemId="4" OptionDesc="M" ClassDesc="Otros" GroupName="AdiEsp" ID="rbAdiEspM" runat="server" /></td>
                                            <td class="center_align">
                                                <asp:RadioButton ItemId="4" OptionDesc="No" ClassDesc="Otros" GroupName="AdiEsp" ID="rbAdiEspNo" runat="server" /></td>
                                        </tr>--%>
                        <tr>
                            <td style="height: 30px;">
                                <asp:Label ClassDesc="Otros" Font-Bold="true" Font-Size="12px" ID="Label21" ItemId="5" runat="server" Text="?"></asp:Label>
                            </td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="B" ClassDesc="Otros" GroupName="SisLucEsp" ID="rbSisLucEspB" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="R" ClassDesc="Otros" GroupName="SisLucEsp" ID="rbSisLucEspR" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="M" ClassDesc="Otros" GroupName="SisLucEsp" ID="rbSisLucEspM" runat="server" /></td>
                            <td class="center_align">
                                <asp:RadioButton ItemId="5" OptionDesc="No" ClassDesc="Otros" GroupName="SisLucEsp" ID="rbSisLucEspNo" runat="server" /></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
