<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCTransunion.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.WUCTransunion" %>
<asp:UpdatePanel runat="server" style="padding: 8px; height: 711px;" UpdateMode="Conditional" ID="udpTransunion">
    <ContentTemplate>         
            <section>
                <div class="ttl_small">
                    <span>Historia de Cr&eacute;dito de Individuo</span>
                    <span>
                        <asp:Literal runat="server" ID="ltStatusPerfil"></asp:Literal>
                    </span>
                    <span>Score de Cr&eacute;dito: <b>
                        <asp:Literal runat="server" ID="ltScore"></asp:Literal></b>
                    </span>
                </div>
                <div>
                    <h2>Datos personales</h2>
                    <div class="cont_tbl">
                        <strong class="ced">C&eacute;dula #<asp:Literal runat="server" ID="ltcedula"></asp:Literal>
                        </strong>
                        <div class="top1">
                            <table>
                                <tr>
                                    <td class="bold">Nombres</td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltNombres"></asp:Literal>
                                    </td>
                                    <td class="bold">Apellidos</td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltApellidos"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bold">Fecha de Nacimiento</td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltFechaNac"></asp:Literal>
                                    </td>
                                    <td class="bold">Edad</td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltEdad"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bold">Nacionalidad</td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltNacionalidad"></asp:Literal>
                                    </td>
                                    <td class="bold">Ocupaci&oacute;n</td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltocupacion"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bold">Pasaporte</td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltPassaporte"></asp:Literal></td>
                                    <td class="bold">Estado Civil</td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltEstadoCivil"></asp:Literal>
                                    </td>
                                </tr>
                                <tr id="trTelefonos" runat="server">
                                    <td class="bold">Tel&eacute;fonos</td>
                                    <td>Casa: 
                                <asp:Literal runat="server" ID="ltTelCasa"></asp:Literal>
                                    </td>
                                    <td>Trabajo:<asp:Literal runat="server" ID="ltTrabajo"></asp:Literal>
                                    </td>
                                    <td>Celular:<asp:Literal runat="server" ID="ltCelular"></asp:Literal>
                                    </td>
                                </tr>
                                <tr id="trDirecciones" runat="server">
                                    <td class="bold">Direcciones</td>
                                    <td colspan="3">
                                        <asp:Literal runat="server" ID="ltDireccion"></asp:Literal></td>
                                </tr>
                            </table>
                        </div>
                        <div class="top2">
                            <asp:Image runat="server" ID="imgPhoto" ImageUrl="" />
                        </div>
                    </div>
                </div>
            </section>
            <section>
                <div>
                    <h2>Sentencias Penales, civiles y/o comerciales</h2>
                    <div class="spcc">
                        <asp:Literal runat="server" ID="lblNotaSentencia">A la fecha no se reporta que sobre esta persona existe algun tipo de sentencia</asp:Literal>
                    </div>
                    <asp:Panel runat="server" ID="pnSentencias" class="cont_tbl tbl_sr" Visible="false">
                        <table>
                            <tr class="head bold flColor">
                                <th scope="col">Numero </th>
                                <th scope="col">Tipo Sentencia</th>
                                <th scope="col">Demandantes</th>
                                <th scope="col">Abogado Demandante</th>
                                <th scope="col">Monto</th>
                            </tr>
                            <tbody runat="server" id="TblSentencias">
                            </tbody>
                        </table>
                    </asp:Panel>
                </div>
            </section>
            <section>
                <div>
                    <h2>Resumen de cuentas activas / vigentes</h2>
                    <div class="cont_tbl tbl_sr">
                        <table cellspacing="2">
                            <tbody runat="server" id="TblResumen">
                            </tbody>
                        </table>
                    </div>
                </div>
            </section>
            <section>
                <div class="ttl_small lch">
                    <span>Leyenda comportamiento historico</span>
                    <span></span>
                    <span></span>
                </div>
                <div class="lect">
                    <table>
                        <tr>
                            <td align="center" class="bold numb">0</td>
                            <td>Al d&iacute;a</td>
                            <td align="center" class="bold numb">1</td>
                            <td>30 d&iacute;as</td>
                            <td align="center" class="bold numb">2</td>
                            <td>60 d&iacute;as</td>
                            <td align="center" class="bold numb">3</td>
                            <td>90 d&iacute;as</td>
                            <td align="center" class="bold numb">4</td>
                            <td>120 d&iacute;as</td>
                            <td align="center" class="bold numb">5</td>
                            <td>150 d&iacute;as</td>
                            <td align="center" class="bold numb">6</td>
                            <td>180 d&iacute;as</td>
                            <td align="center" class="bold numb">7</td>
                            <td>181+ d&iacute;as o m&acute;s</td>
                            <td align="center" class="bold numb">-</td>
                            <td>Historial no disponible</td>
                        </tr>
                    </table>
                </div>
                <div>
                    <h2>Detalle de cuentas activas / vigentes</h2>
                    <div class="cont_tbl dca_tbl tbl_sr">
                        <table>
                            <tr class="head">
                                <th scope="col">Tipo Cta. Suscriptor Status</th>
                                <th scope="col">Fecha Actualizada</th>
                                <th scope="col">Fecha Apertura</th>
                                <th scope="col">Fecha Vencimiento</th>
                                <th scope="col">Moneda</th>
                                <th scope="col">Limite Cr&eacute;dito</th>
                                <th scope="col">Balance Actual</th>
                                <th scope="col">Balance en Mora</th>
                                <th scope="col">Pago minimo/Cuota</th>
                                <th scope="col">No. Cuotas/Modalidad</th>
                                <th scope="col">Vector Comportamiento Ult. 12 Meses<br>
                                    ‹-------------------</th>
                            </tr>
                            <tbody runat="server" id="TblCuentasActivas">
                            </tbody>
                        </table>
                    </div>
                </div>
            </section>
            <section>
                <div>
                    <h2>Detalle de cuentas Cerradas / Inactivas</h2>
                    <div class="cont_tbl dca_tbl tbl_sr">
                        <table>
                            <tr class="head">
                                <th scope="col">Tipo Cta. / Ultimo Estatus / Suscriptor</th>
                                <th scope="col">Fecha Apertura</th>
                                <th scope="col">Fecha Transacción/Ult. Balance</th>
                                <th scope="col">Moneda</th>
                                <th scope="col">Limite Cr&eacute;dito</th>
                                <th scope="col">Vector Comportamiento Ult. 12 Meses<br>
                                    ‹-------------------</th>
                            </tr>
                            <tbody runat="server" id="tblCuentasInactivas">
                            </tbody>

                        </table>
                    </div>
                </div>
            </section>         
    </ContentTemplate>
</asp:UpdatePanel>
