<%@ Page Title="" Language="C#" MasterPageFile="~/Business.Master" AutoEventWireup="true" CodeBehind="AlliedLinesRiskInspectionForm.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.AlliedLinesRiskInspectionForm" %>

<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Inspection/UCInspectionForm.ascx" TagPrefix="uc1" TagName="UCInspectionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/AlliedLinesRiskInspectionForm/css/alertify.core.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css/alertify.default.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css/style.css" rel="stylesheet" />

    <link href="../../Content/AlliedLinesRiskInspectionForm/css/devexpressgrid.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css/grid_dv.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <!--CSS Style-->
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_clientside/dtl2.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_clientside/kickstart.min.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_clientside/reset.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_clientside/amr.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_clientside/yoh.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <!--CSS Style AdminNewAgent-->
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_NAdmin_Agent/kickstart.min.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_NAdmin_Agent/reset.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_NAdmin_Agent/dtl.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_NAdmin_Agent/amr.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_NAdmin_Agent/component.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <!--Carousel -->
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_clientside/slick.css" rel="stylesheet" />
    <link href="../../Content/AlliedLinesRiskInspectionForm/css_clientside/slick-theme.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <link href="../../Content/AlliedLinesRiskInspectionForm/css/common.css" rel="stylesheet" />
    <!--****************************************************************************************************-->

    <style>
        .modalBackgroundWhite {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.60;
        }
    </style>

    <link href="../../Scripts/timePicker/jquery.timepicker.css" rel="stylesheet" />
    <link href="../../Scripts/timePicker/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../../Scripts/prettyPhoto/css/prettyPhoto.css" rel="stylesheet" />

    <link href="../../Scripts/jasny-bootstrap/css/jasny-bootstrap.css" rel="stylesheet" />

    <style>
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

    <link href="../../Content/AlliedLinesRiskInspectionForm.css" rel="stylesheet" />

    <script src="../../Scripts/timePicker/bootstrap-datepicker.js"></script>
    <script src="../../Scripts/timePicker/jquery.timepicker.js"></script>
    <script src="../../Scripts/prettyPhoto/js/jquery.prettyPhoto.js"></script>

    <script src="../../Scripts/jasny-bootstrap/js/bootstrap.js"></script>
    <script src="../../Scripts/jasny-bootstrap/js/holder.js"></script>
    <script src="../../Scripts/jasny-bootstrap/js/jasny-bootstrap.js"></script>
    <script src="../../Scripts/JQuery/Pluggins/jquery.browser.js"></script>

     <script src="../../Scripts/JQuery/Pluggins/jSignature/src/jSignature.js"></script>
    
    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/plugins/jSignature.CompressorBase30.js"></script>
    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/plugins/jSignature.CompressorSVG.js"></script>
    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/plugins/jSignature.UndoButton.js"></script>
    <script src="../../Scripts/JQuery/Pluggins/jSignature/src/plugins/signhere/jSignature.SignHere.js"></script> 

    <script src="../../Scripts/JSPages/AlliedLinesRiskInspectionForm/ALRIF.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>

    <uc1:UCInspectionForm runat="server" id="UCInspectionForm1" />
</asp:Content>
