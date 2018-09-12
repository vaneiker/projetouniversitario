<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OtrasInformaciones.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm.OtrasInformaciones" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCDigitalSign.ascx" TagPrefix="uc1" TagName="WUCDigitalSign" %>


<div class="fondo_blanco" style="padding-top: 2em;">
    <div class="col-3 ">
                <div class="label_plus_input par">
                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Branch %>:</span>
                    <asp:TextBox Enabled="false" ID="txtSucursal" runat="server"></asp:TextBox>
                </div>
    </div>
    <div class="col-3 ">
                <div class="label_plus_input par">
                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.CompletionTime %>:</span>
                    <asp:TextBox CssClass="timePicker" ID="txtHoraCulminacion" runat="server"></asp:TextBox>
                </div>
    </div>
    <div class="col-3 ">
                <div class="label_plus_input par">
            <span style="font-size: 13px; padding-top: 3px;min-width: 260px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleInspectorSuggestsAcceptRisk %></span>
            <div class="fl inspection_radio">
                        <div style="padding-top: 6px;">
                            <table>
                                <tr>
                                    <td><strong><%= RESOURCE.UnderWriting.NewBussiness.Resources.YesLabel %></strong></td>
                                    <td>
                                        <asp:RadioButton GroupName="VehicleInspectorSuggestsAcceptRisk" ID="rbSi" runat="server" />
                                    </td>
                                    <td>
                                        <br />
                                    </td>
                                    <td><strong><%= RESOURCE.UnderWriting.NewBussiness.Resources.NoLabel %></strong></td>
                                    <td>
                                        <asp:RadioButton GroupName="VehicleInspectorSuggestsAcceptRisk" ID="rbNo" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
    </div>
    <div class="col-3 ">
                <div class="label_plus_input par">
                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.UsuarioInspeccion %>:</span>
            <asp:TextBox ID="txtUsuarioInspeccion"  ClientIDMode="Static" validation="Required" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-6 "  style="padding-top: 1em;">
        <div class="label_plus_input">
            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleOpinionDamage %>:</span>
            <div class="wd100 fl textInfo">
                <asp:TextBox Columns="20" ID="txtDictamenDanos" Rows="15" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
                </div>
    <div class="col-6 "  style="padding-top: 1em;">
        <div class="label_plus_input">
            <span style="font-size: 13px; padding-top: 3px;width: 100% !important;" class="alignC">Firma del cliente</span>
            <div class="wd100 fl textInfo">
                <uc1:WUCDigitalSign runat="server" ID="WUCDigitalSign" />
                <asp:Image runat="server" style="display:none" ID="imgSignatureImage" ClientIDMode="Static" />
            </div>
        </div>
    </div>

</div>

