<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFormView.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.EForm.UCFormView" %>
   
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<div class="col-1-2-1-b">
    <div class="titulos_sin_accion">FORM VIEW</div>
    <div class="fondo_blanco fix_height">
        <!--<div class="titulos_azules"><span class="address"></span><strong>DESIGNATED PENSIONER INFORMATION</strong></div>-->
        <div class="barra3 no_padding">
            <div class="filter">
                <div class="grupos de_2">

                    <div class="grupos de_2">
                        <div>
                            <label class="label">Form Name</label>
                            <input type="text">
                        </div>
                        <div>
                            <label class="label">Illustration #</label>
                            <input type="text">
                        </div>
                    </div>
                    <!--grupos-->

                    <div class="grupos de_1">
                        <div>
                            <label class="label">Form Description</label>
                            <input type="text">
                        </div>
                    </div>
                    <!--grupos-->
                </div>
                <!--grupos-->
            </div>
            <!--filter-->

        </div>
        <!--barra1-->

        <div class="content_fondo_blanco">
            <asp:MultiView ID="mvSelectView" runat="server">
                <asp:View ID="vHTML" runat="server">
                    <asp:Literal ID="lForms" runat="server"></asp:Literal>
                </asp:View>
                <asp:View ID="VPDF" runat="server">
                    <PdfViewer:PdfViewer ID="pdfViewerPdfPopUp" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show"  Width="900px" Height="800px" >
        </PdfViewer:PdfViewer>
                </asp:View>
            </asp:MultiView>

        </div>
        <!--content_fondo_blanco-->
    </div>
    <!--fondo_blanco-->
</div>
<!--col-3-4-c-->
