<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFormsContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.EForm.UCFormsContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/EForm/UCFormsEvailable.ascx" TagPrefix="uc1" TagName="UCFormsEvailable" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/EForm/UCFormView.ascx" TagPrefix="uc1" TagName="UCFormView" %>


<div class="fondo_gris">
    <uc1:UCFormsEvailable runat="server" id="UCFormsEvailable" />
    <uc1:UCFormView runat="server" id="UCFormView" />
</div>
<div class="col-1-1">


    <div class="barra_sub_menu">
        <div class="grupos de_8">
            <div style="float: right;">
                <div class="btn_celeste">
                    <span class="back_celeste"></span>
                    <asp:Button ID="btnBack" runat="server" Text="BACK TO PLAN INFO"  CssClass="boton" OnClick="btnBack_Click"/>
                </div>
                <!--btn_celeste-->
            </div>

            <div style="float: right;">
                <div class="btn_celeste">
                    <span class="save_celeste"></span>
                    <asp:Button ID="btnSaveForms" runat="server" Text="SAVE"  CssClass="boton" OnClick="btnSaveForms_Click"/>
                </div>
                <!--btn_celeste-->
            </div>

            <div style="float: right;">
                <div class="btn_celeste">
                    <span class="add_ilustracion"></span>
                    <asp:Button ID="btnSaveFormPDF" runat="server" Text="PDF"  CssClass="boton" OnClick="btnSaveFormPDF_Click"/>
                </div>
                <!--btn_celeste-->
            </div>

            <div style="float: right;">
                <div class="btn_celeste">
                    <span class="see_ilustracion"></span>
                    <asp:Button ID="btnFormSing" runat="server" Text="SIGN"  CssClass="boton"/>
                </div>
                <!--btn_celeste-->
            </div>
        </div>
        <!--grupos-->
    </div>
    <!--barra_sub_menu-->
</div>
<!--col-1-1-->
