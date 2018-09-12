<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Foto.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm.Foto" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="fondo_blanco">
    <div class="titulos_azules"><strong><asp:Label ClientIDMode="Static" ID="lblTitulo" runat="server"></asp:Label></strong></div>
    <div style="padding: 10px; text-align: center">
        <div class="fileinput fileinput-new" data-provides="fileinput" style="width: 318px; height: 159px;">
            <a href="#" rel="prettyPhoto[pp_gal]" runat="server" id="lnkFoto">
                <div class="fileinput-preview thumbnail" style="width: 318px; height: 159px; border: 0px;" thn="thn" runat="server" id="divThumbnail">
                    <img class="img-vif" id="imgFoto1" height="159" width="318" style="height: 159px; width: 358px; display: none;" imagealign="AbsMiddle" runat="server" thn="thn" />
                </div>
            </a>
            <div>
                <span class="btn boton_wrapper azul btn-file marc" style="height: 40px;">
                    <b class="fileinput-new" runat="server" id="bSelectImage">Select image</b>
                    <b class="fileinput-exists" runat="server" id="bChange">Change</b>
                    <input class="file-upload" type="file" name="..." />
                </span>
                <asp:Label Font-Bold="true" Font-Size="12px" CssClass="errmsgvif" ID="lblMessages" runat="server" style="color: red;"></asp:Label>
            </div>
        </div>
    </div>
</div>
