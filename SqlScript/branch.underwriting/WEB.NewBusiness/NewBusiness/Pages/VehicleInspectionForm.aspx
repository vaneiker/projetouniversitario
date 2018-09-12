<%@ Page Title="Inspeccion" Language="C#" MasterPageFile="~/Business.Master" MaintainScrollPositionOnPostback="true" EnableEventValidation="true" AutoEventWireup="true" CodeBehind="VehicleInspectionForm.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.VehicleInspectionForm" %>

<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/InspectionForm.ascx" TagPrefix="uc1" TagName="InspectionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/vehicle/css/alertify.core.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css/alertify.default.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css/style.css" rel="stylesheet" />    

    <link href="../../Content/vehicle/css/devexpressgrid.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css/grid_dv.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <!--CSS Style-->
    <link href="../../Content/vehicle/css_clientside/dtl2.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_clientside/kickstart.min.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_clientside/reset.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_clientside/amr.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_clientside/yoh.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <!--CSS Style AdminNewAgent-->
    <link href="../../Content/vehicle/css_NAdmin_Agent/kickstart.min.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_NAdmin_Agent/reset.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_NAdmin_Agent/dtl.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_NAdmin_Agent/amr.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_NAdmin_Agent/component.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <!--Carousel -->
    <link href="../../Content/vehicle/css_clientside/slick.css" rel="stylesheet" />
    <link href="../../Content/vehicle/css_clientside/slick-theme.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <link href="../../Content/vehicle/css/common.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <link href="../../Scripts/timePicker/jquery.timepicker.css" rel="stylesheet" />
    <link href="../../Scripts/timePicker/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../../Scripts/prettyPhoto/css/prettyPhoto.css" rel="stylesheet" />

    <link href="../../Scripts/jasny-bootstrap/css/jasny-bootstrap.css" rel="stylesheet" />

    <style>
        .modalBackgroundWhite {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.60;
        }

        tr:nth-child(odd) {
            background-color: #ffffff;
        }

        tr:nth-child(even) {
            background-color: #ffffff;
        }

        thead {
            background-color: white;
            border-bottom: solid 1px #c6c6c6;
        }

        .input_disabled {
            background-color: #ECECEC;
            color: #888 !important;
        }
    </style>

    <link href="../../Content/illustrationvehicle.css" rel="stylesheet" />

    <script src="../../Scripts/timePicker/bootstrap-datepicker.js"></script>
    <script src="../../Scripts/timePicker/jquery.timepicker.js"></script>
    <script src="../../Scripts/prettyPhoto/js/jquery.prettyPhoto.js"></script>

    <script src="../../Scripts/jasny-bootstrap/js/bootstrap.js"></script>
    <script src="../../Scripts/jasny-bootstrap/js/holder.js"></script>
    <script src="../../Scripts/jasny-bootstrap/js/jasny-bootstrap.js"></script>    
    <script src="../../Scripts/JQuery/Pluggins/jquery.browser.js"></script>
    <script src="../../Scripts/scripts.js"></script>
    <script src="../../Scripts/JSPages/VehicleInspectionForm/VIF.js"></script>



    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/jSignature.js"></script>
    
    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/plugins/jSignature.CompressorBase30.js"></script>
    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/plugins/jSignature.CompressorSVG.js"></script>
    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/plugins/jSignature.UndoButton.js"></script>
    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/plugins/signhere/jSignature.SignHere.js"></script>    
    
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>

    <uc1:InspectionForm runat="server" ID="InspectionForm" />
    <asp:HiddenField runat="server" ID="hdnInspeccion" ClientIDMode="Static" Value="" />
</asp:Content>
