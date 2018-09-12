var ObjAcordeon = "#AcordeonPersonalData,#AcordeonPolicyPlanData,#AcordeonPayments,#AcordeonRayders,#AcordeonBeneficiaries," +
                     "#AcordeonRequirements,#AcordeonMedicalInfo,#AcordeonSummary,#AcordeonExceptions,#AcordeonFinancialInfo," +
                     "#acordeon_agent_profile, #acc1, #acc2,#acc4, #acc5, #acc6, #STFCUserProfile1_acordeon_agent_profile";
var isImageClicked = false;

function pageLoad() {

    $("#STFCUserProfile1_aAgentProfile").attr('id', 'current');

    ConfigureUserProfile();
    ClearSessionTimeOuts();
    SetSessionTimeOuts();
    EntityTypeVisible();
    UCChargeOfficeDependency();
    UCChargeManagerDependency();
    UCChargeSubManagerDependency();
    $('#OfficeDDL').change();

    if (sessionNotification != null) {
        sessionNotification.close();
        sessionNotification = null;
    }

    var ShowMessage = $("#hdnShowMessage").val() == "true";

    if (ShowMessage) {
        CustomDialogMessageEx('Appointment created successfully.', 500, 150, true, 'Call Appointment');
        $("#hdnShowMessage").val("false");
    }



    /*Tab de todos los Cases*/AppendDateDiv
    if ($("#hfMenuCasesAllCases").val() != "" & $("#hfMenuCasesAllCases").val() != null) {
        ObjMenuCasesAllCases = 'lnk' + $("#hfMenuCasesAllCases").val();
        //Seleccionar el actual Tab Menu Cases all Cases
        ChangeTabMenuCasesAllCases(ObjMenuCasesAllCases);
    }

    var TabSelected = $("#hfCurrentTabSelected").val();

    $("#menu").find("a").each(function () {
        $(this).removeClass("active");
    });

    $("#" + TabSelected).addClass("active");


    if ($("#hfMenuCasesLeft").val() != "" & $("#hfMenuCasesLeft").val() != null) {
        TabLeft = $("#hfMenuCasesLeft").val().split('|')[0];
        ObjLeft = $("#hfMenuCasesLeft").val().split('|')[1];
        //Seleccionar el actual Tab Lado Izquierdo
        ChangeTabCasesLeft(TabLeft, ObjLeft);
    }

    if ($("#hfMenuCasesRight").val() != "" & $("#hfMenuCasesRight").val() != null) {
        TabRight = $("#hfMenuCasesRight").val().split('|')[0];
        ObjRight = $("#hfMenuCasesRight").val().split('|')[1];
        //Seleccionar el actual Tab Lado Derecho
        ChangeTabCasesRight(TabRight, ObjRight);
    }

    CloseGeneralPdfPopIFOpen();
    AppendDateDiv();
    $('#pnModalPopupPDFViewer').draggable();
    $('#pnTerminateExlusion').draggable();
    $(".DraggablePop").draggable({
        handle: ".HeaderHandler"
    });

    //Pop Up Team Communication
    var TabbedPanels3 = new Spry.Widget.TabbedPanels("TabbedPanels3");
    SetUnderTeamCommunicationDiv();
    openCurrentTeamCommunicationTabs();
    //Underwriting Call - Ing. José Mejía
    UCShowCurrent();
    SetUCSendAppointment();
    SetUCSendEmail();
    SetUCNextButtons();
    SetUCProtocolRadioButtons();
    UCSetAttachCallRadios();
    UCSetReadOnlyItems();
    UCDivideACGrid();
    //Underwriting Call - Ing. José Mejía

    //PolicyPlan - Ing. José Mejía
    ShowHideBtnProfile();
    //SetCompleteDropPosition();
    //PolicyPlan - Ing. José Mejía

    $("input:text").attr('onkeydown', 'return (event.keyCode!=13)');
    $("select").attr('onkeydown', 'return (event.keyCode!=8)');
    $("input:text").each(function () {
        var input = $(this);

        if (input.attr('readonly'))
            input.attr('onkeydown', 'return (event.keyCode!=8 && event.keyCode!=13)');
    });

    $("textarea").each(function () {
        var input = $(this);

        if (input.attr('readonly'))
            input.attr('onkeydown', 'return (event.keyCode!=8 && event.keyCode!=13)');
    });



    //Underwriting Steps - Ing. José Mejía
    SetUnderSteps();
    //Underwriting Steps - Ing. José Mejía

    $("body").find("a[alt='Disabled']").each(function () {
        $(this).click(function () {
            CustomDialogMessageEx($(this).html() + "tab is disabled", 250, 150, true, "Warning");
            EndRequestHandler();
            return false;
        });
    });

    SetNumericsMask();

    $("span[data='tooltip']").each(function () {

        if ($(this).attr("alt") != "") {
            $(this).mouseover(function () {
                ShowToolTips(this, 'top', true, null);
            });
        }
    });

    //$(":input").inputmask();
    $(".ReqField").each(function () {
        $(this).html($(this).html() + "<span style='color: #F00 !important;'> * </span>");
    });

    $('.dxBB').append('<span class="upload"></span>');
    $('.Browser').append('<span class="browser"></span>');
    $('.browserVD span.upload').removeClass("upload");

    $("[alphabetical='alphabetical']").each(function () {
        $(this).attr('data-inputmask-regex', "[A-Za-z\\sñÑáéíóúÁÉÍÓÚ]*");
    });

    $("[alphabetical='alphabeticalLastName']").each(function () {
        $(this).attr('data-inputmask-regex', "[A-Za-z'-\\sñÑáéíóúÁÉÍÓÚ]*");
    });

    $("[alphabetical='alphabetical']").inputmask("Regex");
    $("[alphabetical='alphabeticalLastName']").inputmask("Regex");

    $("[phone='phone']").inputmask("9 (999) 999-9999");

    $("[number='number'],[decimal='decimal'],[creditcard='creditcard']").inputmask();

    //numericMask("#txtPercentage");
    //numericMask("#txtEntityPercentage");



    /*Fin de Tab Todos Los Cases*/

    $(".datepickerDOB").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: '-66y +1d',
        maxDate: '-3m',
        defaultDate: '-3m',
        beforeShow: function () {
            AppendDatePicker(this);
        },
        onSelect: function (selectedDate) {
            CalculatePersonalDataDOB(this, selectedDate);
        },
        onClose: function (selectedDate) {
            CalculatePersonalDataDOB(this, selectedDate);
        }
    }).inputmask('mm/dd/yyyy');

    $(".HFecha").datetimepicker({
        defaultDate: null,
        minDate: 0,
        changeMonth: true,
        changeYear: true,
        timeFormat: "hh:mm tt",
        beforeShow: function () {
            AppendDatePicker(this);
        },
        onSelect: function (selectedDate) {
            UCCalculateCallingDate(this, selectedDate);
        },
        onClose: function (selectedDate) {
            UCCalculateCallingDate(this, selectedDate);
        }
    }).inputmask('datetimeMonth12');

    $(".datepicker, .datepickerPop").datepicker({
        defaultDate: null,
        changeMonth: true,
        changeYear: true,
        beforeShow: function () {
            AppendDatePicker(this);
        },
        onSelect: function (selectedDate) {
            ValidateDates(this, selectedDate);
        },
        onClose: function (selectedDate) {
            ValidateDates(this, selectedDate);
        }
    }).inputmask('mm/dd/yyyy');


    $("#txtNotificationDateTerminateExclusion").datepicker({
        defaultDate: null,
        changeMonth: true,
        changeYear: true,
        beforeShow: function () {
            AppendDatePicker(this);
        },
        onSelect: function (selectedDate) {
            ValidateDates(this, selectedDate);
        },
        onClose: function (selectedDate) {
            ValidateDates(this, selectedDate);
        }
    }).inputmask('mm/dd/yyyy');

    //if ($("#hfMenuUnderwritingCall").val() != "" & $("#hfMenuUnderwritingCall").val() != null) {
    //    TabRightUnderwritingCall = $("#hfMenuUnderwritingCall").val().split('|')[0];
    //    ObjRightUnderwritingCall = $("#hfMenuUnderwritingCall").val().split('|')[1];

    //    //Seleccionar el actual Tab Lado Derecho tab Underwriting Call
    //    ChangeTabCasesUnderwritingCall(TabRightUnderwritingCall, ObjRightUnderwritingCall);
    //}

    PDSetQuestionsRadio();
    $(".radio label").click(function () {
        if (typeof $(this).parent().attr('class') === 'undefined')
            return;

        var className = $(this).parent().attr('class').split(' ')[0];
        console.log($(this).parent().prev().children('label').siblings('span').children('input:radio'));
        console.log($(this).parent().prev().children('label'));
        console.log($(this).parent().prev().children('label').siblings('input:hidden').val());
        if (className != "li_si" && className != "li_no" && className != "li_na" && className != "RiskPThousand" && className != "RiskTRaiting")
            return;

        if (className == "RiskPThousand")
            if ($("#ddlPopNRiskPerThousand options").length < 1) return;

        if (className == "RiskTRaiting")
            if ($("#ddlPopNRiskTableRating options").length < 1) return;

        switch (className) {
            case "li_si":
                $(this).parent().next().children('label').siblings('span').children('input:radio').removeAttr('checked');
                $(this).parent().next().children('label').removeClass("radioSelect");
                $(this).parent().next().children('label').siblings('input:hidden').val('False');
                $(this).parent().next().next().children('label').siblings('span').children('input:radio').removeAttr('checked');
                $(this).parent().next().next().children('label').removeClass("radioSelect");
                $(this).parent().next().next().children('label').siblings('input:hidden').val('False');
                break;
            case "li_no":
                $(this).parent().prev().children('label').siblings('span').children('input:radio').removeAttr('checked');
                $(this).parent().prev().children('label').removeClass("radioSelect");
                $(this).parent().prev().children('label').siblings('input:hidden').val('False');
                $(this).parent().next().children('label').siblings('span').children('input:radio').removeAttr('checked');
                $(this).parent().next().children('label').removeClass("radioSelect");
                $(this).parent().next().children('label').siblings('input:hidden').val('False');
                break;
            case "li_na":
                $(this).parent().prev().children('label').siblings('span').children('input:radio').removeAttr('checked');
                $(this).parent().prev().children('label').removeClass("radioSelect");
                $(this).parent().prev().children('label').siblings('input:hidden').val('False');
                $(this).parent().prev().prev().children('label').siblings('span').children('input:radio').removeAttr('checked');
                $(this).parent().prev().prev().children('label').removeClass("radioSelect");
                $(this).parent().prev().prev().children('label').siblings('input:hidden').val('False');
                break;
        }

        $(this).siblings('span').children('input:radio').attr('checked', 'checked');
        $(this).siblings('input:hidden').val('True');

        var pClaseProtocolo = $(this).hasClass("Protocolo");

        if (pClaseProtocolo) {
            $("#dvProtocoloSi_No > div").css("display", "none");
            if ($(this).attr("for") == "si")
                $("#dvSi").css("display", "block");
            else
                if ($(this).attr("for") == "no")
                    $("#dvNo").css("display", "block");
        }

        $(this).addClass("radioSelect");



    });

    if ($('#hfCssTabbedPanelsTabSelected').val() == "") {
        $('.TabbedPanelsTabGroup li:first').children('input:submit').addClass("TabbedPanelsTabSelected");
    }

    $(".TabbedPanelsTab").click(function () {
        $(this).siblings('.TabbedPanelsTabGroup li').children().removeClass("TabbedPanelsTabSelected");
        $(this).addClass("TabbedPanelsTabSelected");
        $("#hfCssTabbedPanelsTabSelected").val($(this).attr("id"));
    });

    $("#" + $("#hfCssTabbedPanelsTabSelected").val()).addClass("TabbedPanelsTabSelected");

    if ($('#hfCssTabbedPanelsTabSelectedBig').val() == "") {
        $('#TabbedPanels2 ul li:first').addClass("TabbedPanelsTabSelected");
    }

    $('#TabbedPanels2 ul li').click(function () {
        $('#TabbedPanels2 ul li').removeClass("TabbedPanelsTabSelected");
        $(this).addClass("TabbedPanelsTabSelected");
        $("#hfCssTabbedPanelsTabSelectedBig").val($(this).children('input:submit').attr("id"));
    });

    $("#" + $("#hfCssTabbedPanelsTabSelectedBig").val()).parent('li').addClass("TabbedPanelsTabSelected");

    if ($("#hfAddNewRisk").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPopAddNewRisk",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "ADD NEW RISK",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hfAddNewRisk").val("false"); }
        });
    } else { initializatePopupsAndClose("#dvPopAddNewRisk"); }


    if ($("#hfRequestAmendments").val() == "true") {
        $("#txtFromDate").val("");
        $("#txtToDate").val("");
        $("#txtComment").val("");
        JQueryPopup({
            ElementIDorClass: "#dvRequestAmendments",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "Request Amendments",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hfRequestAmendments").val("false"); }
        });
    } else { initializatePopupsAndClose("#dvRequestAmendments"); }

    if ($("#hfRiderReason").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvRiderReason",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "DECLINED / EXCLUDED REASON",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hfRiderReason").val("false"); }
        });
    } else {
        initializatePopupsAndClose("#dvRiderReason");
    }

    if ($("#hfCommentInfo").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvCommentInfo",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "NOTES / COMMENTS",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hfCommentInfo").val("false"); $('#dvNCNewComment').show(); }
        });
    } else {
        initializatePopupsAndClose("#dvCommentInfo");
    }

    if ($("#hdnCCShowNotePop").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvCCNotePopup",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "CLIENT COMMUNICATION NOTE",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hdnCCShowNotePop").val("false"); }
        });
    } else {
        initializatePopupsAndClose("#dvCCNotePopup");
    }



    if ($("#hdnCCShowCallPop").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvCCCallPopup",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "CLIENT COMMUNICATION CALL",
            pmodal: true,
            presizable: false,
            OnCLose: function () {
                $("#hdnCCShowCallPop").val("false");
                var call = document.getElementsByClassName("audioCall");

                call.pause();

            }
        });
    } else {
        initializatePopupsAndClose("#dvCCCallPopup");
    }

    if ($("#hdnShowPopAttachCall").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPopUCAttachCall",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "ATTACH CALL",
            pmodal: true,
            presizable: false,
            OnCLose: function () {
                $("#hdnShowPopAttachCall").val("false");
            }
        });
    } else {
        initializatePopupsAndClose("#dvPopUCAttachCall");
    }



    //ADD NEW STEP AND ADD STEP COMMENTS

    if ($("#hdnUSShowPopComments").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPopUSComments",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "UNDERWRITING STEP COMMENTS",
            pmodal: true,
            presizable: false,
            OnCLose: function () {
                $("#hdnUSShowPopComments").val("false");
            }
        });
    }
    else {
        initializatePopupsAndClose("#dvPopUSComments");
    }

    if ($("#hdnNSShowPop").val() == "true")
        $find('ModalNewStepPop').show();
    else
        $find('ModalNewStepPop').hide();

    if ($("#hdnNSShowPDFPop").val() == "true")
        $find('ModalPdfPop').show();
    else
        $find('ModalPdfPop').hide();

    if ($find('mpRequirementComunication') != null) {
        if ($("#hfRequirementComunication").val() == "true")
            $find('mpRequirementComunication').show();
        else
            $find('mpRequirementComunication').hide();
    }


    //NEW

    if ($("#hfPdfPopUp").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPdfPopUpPolicyDocument",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "PDF Document Preview",
            pwidth: 1189,
            pheight: 752,
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hfPdfPopUp").val("false"); }
        });
    }

    if ($("#hfRequirementInsertForm").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvAddNewRequirement",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "Add New Requirements To Underwriting Step",
            pmodal: true,
            presizable: false,
            pwidth: 946,
            pheight: 750,
            OnCLose: function () { $("#hfRequirementInsertForm").val("false"); }
        });
    } else {
        initializatePopupsAndClose("#dvAddNewRequirement");
    }

    if ($("#hfRequirementPdfPopUp").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPdfPopUp",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "Upload PDF",
            pmodal: true,
            presizable: false,

            OnCLose: function () { $("#hfRequirementPdfPopUp").val("false"); }
        });
    }

    //if ($("#hfRequirementComunication").val() == "true") {
    //    JQueryPopup({
    //        ElementIDorClass: "#dvComunicationPopUp",
    //        pautoOpen: true,
    //        pShowTitleBar: true,
    //        pTitle: "Communication",
    //        pmodal: true,
    //        presizable: true,
    //        OnCLose: function () { $("#hfRequirementComunication").val("false"); }
    //    });
    //}


    if ($("#hdnVisiblePopProfile").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPopCustomProfile",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "PERSONALIZED PROFILE DISTRIBUTION",
            pmodal: true,
            presizable: false,
            OnCLose: function () {
                $("#hdnVisiblePopProfile").val("false");
            }
        });
    } else {
        initializatePopupsAndClose("#dvPopCustomProfile");
    }



    if ($("#hfAddNewCredit").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvNewCredit",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "ADD NEW CREDIT",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hfAddNewCredit").val("false"); }
        });
    } else { initializatePopupsAndClose("#dvNewCredit"); }


    if ($("#hfAddNewExclusion").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvNewExclusion",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "ADD NEW EXCLUSION",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hfAddNewExclusion").val("false"); }
        });
    } else { initializatePopupsAndClose("#dvNewExclusion"); }

    if ($("#hfExclusionComment").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvExclusionComment",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "EXCLUSION COMMENT",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hfExclusionComment").val("false"); }
        });
    } else { initializatePopupsAndClose("#dvExclusionComment"); }


    if ($("#hfTeamCommunicationPopUp").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvTeamCommunication",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "TEAM COMMUNICATION",
            pmodal: true,
            presizable: false,
            OnCLose: function () {
                $("#hfTeamCommunicationPopUp").val("false");
                $("#txtSubject").val("");
                $("#txtMessage").val("");
                $("#hdnIndexGvTeamCommunication").val("");
            }
        });
    } else { initializatePopupsAndClose("#dvTeamCommunication"); }


    setCurrentAccordeonForIndex("#hfPolicyPlanDataAccordeon");
    setCurrentAccordeonForIndex("#hfLeftMenuAccordeon");
    setCurrentAccordeonForIndex("#hfRightAccordeon");

    var hdnVisiblePanels = $("#hdnVisiblePanels").val() == "true" ? "block" : "none";

    $("#pnLeftControl").css("display", hdnVisiblePanels);
    $("#pnRightControl").css("display", hdnVisiblePanels);

    $("select[id$='btnDeleteEmail']:first").click(function () {
        MyjConfirm({
            autoOpen: false,
            resizable: false,
            modal: true,
            width: 550,
            height: 300,
            close: function (event, ui) { alert('closed') }
        });
    });

    $(".ReadOnly").keydown(function (event) {
        return false;
    });

    $('.p_of_p').hide();
    $('.p_of_p2').hide();

    $("#FakeBrowse").click(function () {
        $('#FileUpload1').trigger('click');
    });

    $('.Requirementchk').click(function () {
        AddRequirement();
    });

    ExposureElements();
    RelationshipElements();
    SetUploadersText();
    $('.barra-down-1').show();

    /*mavelar 3/6/2017 Validaciones Documentos Telefonos*/

    $("#IdtypeDDL").change(function () {

        //NIT
        //Licencia
        if ((eval($('#IdtypeDDL').val()) == 7) || (eval($('#IdtypeDDL').val()) == 3)) {

            var $txt = $('#idTxt').inputmask("9999-999999-999-9");
        }
            //DUI
        else if (eval($('#IdtypeDDL').val()) == 1) {

            var $txt = $('#idTxt').inputmask("99999999-9");

        }
            //Pasaporte
        else if (eval($('#IdtypeDDL').val()) == 2) {

            var $txt = $('#idTxt').inputmask("remove");

        }
            //RNC--> Registro de Compañia
            //Carnet de Residente
            //Cerificado de Nacimiento --remove
        else {
            //mavelar 18-03-2017 Cambio para dejar abierto los documentos se cambia .inputmask("integer")  por .inputmask("remove");
            var $txt = $('#idTxt').inputmask("remove");
        }
        /*mavelar 3/6/2017 Valida fecha no requerida para NIT y NRF*/



    });

    $("#DDLPhoneType").change(function () {


        var txtCountryCode = document.getElementById('CountryCodeTxt');
        if (txtCountryCode.value.length == 0) {
            //$('#CountryCodeTxt').val('503');
            //$('#AreaCodeTxt').val('0');
        }

    });

    $("#BDDLPhoneType").change(function () {


        var txtCountryCode = document.getElementById('BCountryCodeTxt');
        if (txtCountryCode.value.length == 0) {
            //$('#BCountryCodeTxt').val('503');
            //$('#BAreaCodeTxt').val('0');
        }


    });

    /*mavelar 3/6/2017 Validaciones Documentos Telefonos*/

    /*Formulario PEP*/
    if ($("#hdnNewPepRelatedShowPop").val() == "true")
        $find('ModalNewPepRelatedPop').show();
    else
        $find('ModalNewPepRelatedPop').hide();

    MostrarListaPEP = function (item) {
        if ($(item).attr('namekey') == "ISPARENTPOLITICAL") {
            ShowParentPolitical($(item).parent().find('input').val() == 'rbYes');
        }
    };

    function ShowParentPolitical(result) {

        if (result) {
            $('#ISPARENTPOLITICAL_section').removeClass('campos');
            $('#ISPARENTPOLITICAL_section').addClass('camposShow');
            $('#frmBackGroundInformation').height('0%');
        } else {
            $('#ISPARENTPOLITICAL_section').removeClass('camposShow');
            $('#ISPARENTPOLITICAL_section').addClass('campos');
        }
    }


    $(function () {
        if ($('input[id=Left_Left_UCPersonalDataContainer_UCCompliance1_WUCBackgroundInformation_repeaterQuestion_rbYes_3]:checked').val() == 'rbYes') {
            //Mostrar el panel de contacto
            ShowParentPolitical(true);
        }
    });

    validateFormCitizenContact = function (sender, form) {

        var resultado = validateForm(form);

        if (true) {

            return resultado;
        } else {

            return resultado;
        }

    };

    setPositionnPepAutoComplete = function () {
        $("#txtPositionPepRelated").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../../../SearchMethods.asmx/GetOccupation",
                    data: JSON.stringify({
                        description: $.trim($("#txtPosition").val()), _LanguageId: $("#hdnLang").val()
                    }),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    beforeSend: function () {
                        $("#txtPositionPepRelated").css("background-repeat", "no-repeat");
                        $("#txtPositionPepRelated").css("background-position", "right");
                        $("#txtPositionPepRelated").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                    },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.description,
                                id: item.value,
                                descGroup: item.OccupationGroupDesc,
                                GroupId: item.OccupationGroupId
                            };
                        }));

                        $(".ui-autocomplete").css({ "height": "200px", "overflow-y": "scroll", "overflow-x": "hidden" });
                        $("#txtPositionPepRelated").css("background-image", "");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(textStatus);
                    }
                });
            },
            minLength: 1,
            //select: function (event, ui) {
            //    $("#txtProfession").val(ui.item.descGroup);
            //    $("#hdnOccupationId").val(ui.item.id);
            //    $("#hdnOccupationGroupId").val(ui.item.GroupId);
            //},
            response: function (event, ui) {
                var len = ui.content.length;
            },
            delay: 5
        }).on('keyup', function (event) {
            //Limpiar los campos
            //if (event.which != 13 && event.which != 37 && event.which != 38 && event.which != 39 && event.which != 40) {
            //    $("#hdnOccupationId").val("");
            //    $("#hdnOccupationGroupId").val("");
            //    $("#txtProfession").val("");
            //    changeBorderColor($("#txtProfession"));
            //}
        });
    };

    setCoditionTypeAutoComplete = function () {
        $("#txtPopNRiskConditionType").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../../../SearchMethods.asmx/GetConditionType",
                    data: JSON.stringify({
                        RiskGGroup_id: $("#ddlPopNRiskCategory").val(), description: $("#txtPopNRiskConditionType").val()
                    }),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    beforeSend: function () {
                        $("#txtPopNRiskConditionType").css("background-repeat", "no-repeat");
                        $("#txtPopNRiskConditionType").css("background-position", "right");
                        $("#txtPopNRiskConditionType").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                    },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.description,
                                id: item.value,
                                descGroup: item.RiskDetDesc,
                                GroupId: item.RiskDetId
                            };
                        }));

                        $(".ui-autocomplete").css({ "height": "200px", "overflow-y": "scroll", "overflow-x": "hidden" });
                        $("#txtPopNRiskConditionType").css("background-image", "");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(textStatus);
                    }
                });
            },
            minLength: 1,
            response: function (event, ui) {
                var len = ui.content.length;
            },
            delay: 5
        }).on('keyup', function (event) {
        });
    };

    setPositionnPepAutoComplete();
    setCoditionTypeAutoComplete();

    EnablePEPInfo = function (item) {
        if ($(item).attr('namekey') == "ISPARENTPOLITICAL") {
            var statusPep = ($(item).parent().find('input').val() == 'n1');
            $('[name="ctl00$Left$Left$UCPersonalDataContainer$UCCompliance1$gvQuestions$ctl05$btnPepRelatedInfoAdd"]').attr('disabled', statusPep);
            if (statusPep)
                $("#ISPARENTPOLITICAL").addClass("view_btn_compliance_pep_disable");
            else
                $("#ISPARENTPOLITICAL").removeClass("view_btn_compliance_pep_disable");
        }
    };
} //fin pageload


validateForm = function (form) {

    /*******************Para la pagina Contact ---- mavelar 03/08/2017     *******************/
    //NIT
    //Licencia
    if ((eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 7) || (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 3)) {

        $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("999-9999999-9");

        var value = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').val();

        var num = value.replace("-", "").replace("-", "").replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "");

        if (num.length < 9) {
            CustomDialogMessageEx('El RNC debe tener 9 digitos.', null, null, true, lang == "en" ? "Warning" : "Advertencia");
            return false;
        }
    }
        //DUI
    else if (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 1) {

        var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("999-9999999-9");

        var value = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').val();

        var num = value.replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "");

        if (num.length < 11) {
            CustomDialogMessageEx('La cedula de identidad debe tener 11 digitos.', null, null, true, lang == "en" ? "Warning" : "Advertencia");
            return false;
        }
    }
        //Pasaporte
    else if (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 2) {

        var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("remove");

    }
        //RNC--> Registro de Compañia
        //Carnet de Residente
        //Cerificado de Nacimiento
    else {
        //mavelar 18-03-2017 Cambio para dejar abierto los documentos se cambia .inputmask("integer")  por .inputmask("remove");
        var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask('remove');
    }

    /*******************Para la pagina Contact ---- mavelar 03/09/2017     *******************/



    /*******************Para la pagina AddNewClient ----- mavelar 03/09/2017     *******************/
    //NIT
    //Licencia

    if ((eval($('#bodyContent_ContactsInfoContainer_WUCIdentification_cbxIDType').val()) == 7) || (eval($('#bodyContent_ContactsInfoContainer_WUCIdentification_cbxIDType').val()) == 3)) {

        var $txt = $('#bodyContent_ContactsInfoContainer_WUCIdentification_txtIDNumber').inputmask("999-9999999-9");
        var value = $('#bodyContent_ContactsInfoContainer_WUCIdentification_txtIDNumber').val();

        var num = value.replace("-", "").replace("-", "").replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "");

        if (num.length < 9) {
            CustomDialogMessageEx('El RNC debe tener 9 digitos.', null, null, true, lang == "en" ? "Warning" : "Advertencia");
            return false;
        }
    }
        //DUI
    else if (eval($('#bodyContent_ContactsInfoContainer_WUCIdentification_cbxIDType').val()) == 1) {

        var $txt = $('#bodyContent_ContactsInfoContainer_WUCIdentification_txtIDNumber').inputmask("999-9999999-9");
        var value = $('#bodyContent_ContactsInfoContainer_WUCIdentification_txtIDNumber').val();

        var num = value.replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "");

        if (num.length < 11) {
            CustomDialogMessageEx('La cedula de identidad debe tener 11 digitos.', null, null, true, lang == "en" ? "Warning" : "Advertencia");
            return false;
        }

    }
        //Pasaporte
    else if (eval($('#bodyContent_ContactsInfoContainer_WUCIdentification_cbxIDType').val()) == 2) {

        var $txt = $('#bodyContent_ContactsInfoContainer_WUCIdentification_txtIDNumber').inputmask("remove");

    }
        //RNC--> Registro de Compañia
        //Carnet de Residente
        //Cerificado de Nacimiento
    else {
        //mavelar 18-03-2017 Cambio para dejar abierto los documentos se cambia .inputmask("integer")  por .inputmask("remove");
        var $txt = $('#bodyContent_ContactsInfoContainer_WUCIdentification_txtIDNumber').inputmask("remove");
    }

    /*************Para la pagina AddNewClient -----mavelar 03/09/2017  *******************/


    //mavelar 3/29/17
    if ((eval($('#bodyContent_ContactsInfoContainer_WUCIdentificationLegal_cbxIDType_Legal').val()) == 7) || (eval($('#bodyContent_ContactsInfoContainer_WUCIdentificationLegal_cbxIDType_Legal').val()) == 3)) {
        var $txt = $('#bodyContent_ContactsInfoContainer_WUCIdentificationLegal_txtIDNumber_Legal').inputmask("999-9999999-9");
        var value = $('#bodyContent_ContactsInfoContainer_WUCIdentificationLegal_txtIDNumber_Legal').val();
        var num = value.replace("-", "").replace("-", "").replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "");
        if (num.length < 9) {
            CustomDialogMessageEx('El RNC debe tener 9 digitos.', null, null, true, lang == "en" ? "Warning" : "Advertencia");
            return false;
        }
    }
        //DUI
    else if (eval($('#bodyContent_ContactsInfoContainer_WUCIdentificationLegal_cbxIDType_Legal').val()) == 1) {
        var $txt = $('#bodyContent_ContactsInfoContainer_WUCIdentificationLegal_txtIDNumber_Legal').inputmask("999-9999999-9");
        var value = $('#bodyContent_ContactsInfoContainer_WUCIdentificationLegal_txtIDNumber_Legal').val();
        var num = value.replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "");
        if (num.length < 11) {
            CustomDialogMessageEx('La cedula de identidad debe tener 11 digitos.', null, null, true, lang == "en" ? "Warning" : "Advertencia");
            return false;
        }
    }
    else {
        var $txt = $('#bodyContent_ContactsInfoContainer_WUCIdentificationLegal_txtIDNumber_Legal').inputmask("remove");
    }
    //fin mavelar 3/29/17

    var ishighlightedFieldRequired = ($("#hdnhighlightedFieldRequired").val() == "true");
    var oMessage;
    var arrayMessage = [];

    var result = true;
    var validationSummary = "";

    if ($("#hdnValidate").val() == "true") {

        //Buscar los campos que son requeridos   
        $("#" + form).find("[validation='Required']").each(function () {
            var $this = $(this);
            var allowZero = ($this.attr("allowZero") != undefined && $this.attr("allowZero") == "true");

            //Validar los input del tipo text
            if ($this.is("input:text")) {
                //Validar si esta vacio
                if ($this.attr("alt") == "decimal-us" || $this.attr("data-inputmask") != null) {
                    if (parseFloat($.trim($this.val())) <= 0 || $.trim($this.val()) == "") {
                        result = false;
                        var Field = getLabelField($this);

                        if (ishighlightedFieldRequired) {
                            $this.css("border", "1px solid rgb(192, 61, 190)");
                            $this.keydown(function () {
                                changeBorderColor(this);
                            });
                        }

                        var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                        //Crear un nuevo objeto Message
                        oMessage = {};

                        if (!changeMessage)
                            oMessage.ErrorType = "Required";
                        else
                            oMessage.ErrorType = $this.attr("label");

                        oMessage.Field = Field;

                        arrayMessage.push(oMessage);
                        EndRequestHandler();
                    }
                } else if ((($this.attr("number") == undefined ? "" : $this.attr("number")).indexOf("number") != -1 ||
                    ($this.attr("decimal") == undefined ? "" : $this.attr("decimal")).indexOf("decimal") != -1 ||
                    $this.attr("alt") == "Numeric") && parseFloat($.trim($this.val())) <= 0) {
                    result = false;
                    var Field = getLabelField($this);
                    if (ishighlightedFieldRequired) {
                        $this.css("border", "1px solid  rgb(192, 61, 190)");
                        $this.keydown(function () {
                            changeBorderColor(this);
                        });
                    }

                    var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                    oMessage = {};

                    if (!changeMessage)
                        oMessage.ErrorType = "RequiredNumeric";
                    else
                        oMessage.ErrorType = $this.attr("label");

                    oMessage.Field = Field;

                    arrayMessage.push(oMessage);


                    EndRequestHandler();
                }
                else {

                    if ($.trim($this.val()) == "") {
                        result = false;
                        var Field = getLabelField($this);
                        if (ishighlightedFieldRequired) {
                            $this.css("border", "1px solid  rgb(192, 61, 190)");
                            $this.keydown(function () {
                                changeBorderColor(this);
                            });
                        }

                        var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                        oMessage = {};

                        if (!changeMessage) {
                            oMessage.ErrorType = "Required";
                        }
                        else
                            oMessage.ErrorType = $this.attr("label");

                        oMessage.Field = Field;

                        arrayMessage.push(oMessage);

                        EndRequestHandler();
                    }
                }

                //validar si tiene el tamaño correcto
                var Length = $this.attr("validateLength");

                if (Length != null) {
                    $this.inputmask('remove');
                    //Verificar si es un rango de valores
                    var rangeVal = Length.split(',');
                    var isRange = (rangeVal.length > 0);
                    var fieldLength = $this.val().length;

                    if (!isRange) {
                        if (fieldLength != Length) {
                            result = false;
                            var Field = getLabelField($this);
                            if (ishighlightedFieldRequired) {
                                $this.css("border", "1px solid  rgb(192, 61, 190)");
                                $this.keydown(function () {
                                    changeBorderColor(this);
                                });
                            }

                            var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";
                            oMessage = {};
                            if (!changeMessage) {
                                oMessage.ErrorType = "LengthValidation";
                                oMessage.Length = Length;
                            }
                            else
                                oMessage.ErrorType = $this.attr("label");

                            oMessage.Field = Field;

                            arrayMessage.push(oMessage);

                            $this.inputmask();

                            EndRequestHandler();
                        }
                    } else {
                        var r = $.inArray(fieldLength.toString(), rangeVal);

                        if (r < 0) {

                            result = false;
                            var Field = getLabelField($this);
                            if (ishighlightedFieldRequired) {
                                $this.css("border", "1px solid  rgb(192, 61, 190)");
                                $this.keydown(function () {
                                    changeBorderColor(this);
                                });
                            }

                            var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";
                            oMessage = {};
                            if (!changeMessage) {
                                oMessage.ErrorType = "LengthValidation";
                                oMessage.Length = Length;
                            }
                            else
                                oMessage.ErrorType = $this.attr("label");

                            oMessage.Field = Field;

                            arrayMessage.push(oMessage);

                            $this.inputmask();

                            EndRequestHandler();
                        }
                    }
                }

                //validar si es email y que sea valido
                var isEmailType = $this.attr("inputtype") == "Email";

                if (isEmailType) {
                    if (!isEmail($.trim($this.val()))) {
                        result = false;
                        var Field = getLabelField($this);
                        if (ishighlightedFieldRequired) {
                            $this.css("border", "1px solid  rgb(192, 61, 190)");
                            $this.keydown(function () {
                                changeBorderColor(this);
                            });
                        }

                        oMessage = {};

                        var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                        if (!changeMessage) {
                            oMessage.ErrorType = "InvalidEmail";
                        }
                        else
                            oMessage.ErrorType = $this.attr("label");

                        oMessage.Field = Field;
                        arrayMessage.push(oMessage);
                        EndRequestHandler();
                    }
                }

                //validar si es email y que sea valido
                var isDateType = $this.hasClass("datepicker");

                if (isDateType) {

                    if ($.trim($this.val()) != "") {
                        if (!$.trim($this.val()).IsDate('dd/mm/yyyy')) {
                            result = false;
                            var Field = getLabelField($this);
                            if (ishighlightedFieldRequired) {
                                $this.css("border", "1px solid  rgb(192, 61, 190)");
                                $this.keydown(function () {
                                    changeBorderColor(this);
                                });
                            }

                            var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                            oMessage = {};

                            if (!changeMessage) {
                                oMessage.ErrorType = "InvalidDate";
                            }
                            else
                                oMessage.ErrorType = $this.attr("label");

                            oMessage.Date = $this.val();
                            oMessage.Field = Field;
                            arrayMessage.push(oMessage);

                            EndRequestHandler();
                        }
                    }
                }

                //Validar valores minimos y maximos
                var MinValue = $this.attr("Min-Value");
                var MaxValue = $this.attr("Max-Value");

                if (MinValue != null && MinValue != "") {
                    var Value = parseInt($this.val());

                    if (Value < MinValue) {
                        result = false;
                        var Field = getLabelField($this);
                        if (ishighlightedFieldRequired) {
                            $this.css("border", "1px solid  rgb(192, 61, 190)");
                            $this.keydown(function () {
                                changeBorderColor(this);
                            });
                        }

                        var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                        oMessage = {};

                        if (!changeMessage) {
                            oMessage.ErrorType = "MinimumValidation";
                            oMessage.MinimumVal = MinValue;
                        }
                        else
                            oMessage.ErrorType = $this.attr("label");

                        oMessage.Field = Field;

                        arrayMessage.push(oMessage);

                        EndRequestHandler();
                    }
                }

                if (MaxValue != null && MaxValue != "") {
                    var Value = parseInt($this.val());

                    if (Value > MaxValue) {
                        result = false;
                        var Field = getLabelField($this);
                        if (ishighlightedFieldRequired) {
                            $this.css("border", "1px solid  rgb(192, 61, 190)");
                            $this.keydown(function () {
                                changeBorderColor(this);
                            });
                        }

                        var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                        oMessage = {};

                        if (!changeMessage) {
                            oMessage.ErrorType = "MaximumValidation";
                            oMessage.MaximumVal = MaxValue;
                        }
                        else
                            oMessage.ErrorType = $this.attr("label");

                        arrayMessage.push(oMessage);

                        EndRequestHandler();
                    }
                }

                //Validar que el textbox tenga el mismo valor que el control que tenga en el atributo
                var validateEqualControlId = $this.attr("validateEqualControlId");
                if (validateEqualControlId != null && validateEqualControlId != "") {
                    if ($("#" + validateEqualControlId).val() != $this.val()) {
                        result = false;
                        var Field1 = getLabelField($this);
                        var Field2 = $("#" + validateEqualControlId).parent().find("label:first").html();

                        if (ishighlightedFieldRequired) {
                            $this.css("border", "1px solid  rgb(192, 61, 190)");
                            $("#" + validateEqualControlId).css("border", "1px solid  rgb(192, 61, 190)");
                            $this.keydown(function () {
                                changeBorderColor(this);
                            });
                        }

                        oMessage = {};

                        var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";
                        oMessage.ErrorType = !changeMessage ? "validateEqualControlId" : $this.attr("label");
                        oMessage.Field = Field1;
                        oMessage.Field2 = Field2;

                        arrayMessage.push(oMessage);

                        EndRequestHandler();
                    }
                }
            } //Fin Validaciones de Input[Type="Text"]

            //Validar los TextArea
            if ($this.is("textarea")) {
                if ($.trim($this.val()) == "") {
                    result = false;
                    var Field = getLabelField($this);
                    if (ishighlightedFieldRequired) {
                        $this.css("border", "1px solid  rgb(192, 61, 190)");
                        $this.keydown(function () {
                            changeBorderColor(this);
                        });
                    }

                    var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                    oMessage = {};
                    oMessage.ErrorType = !changeMessage ? "Required" : $this.attr("label");
                    oMessage.Field = Field;
                    arrayMessage.push(oMessage);
                    EndRequestHandler();
                }
            }

            //Validar los select
            if ($this.is("select")) {
                if ($this.find("option").length > 0) {
                    var defaultValue = $this.attr("defaultValue");

                    if (defaultValue == undefined || defaultValue == "")
                        defaultValue = "-1";

                    if ($this.val() == defaultValue) {
                        result = false;
                        var Field = getLabelField($this);
                        if (ishighlightedFieldRequired) {
                            $this.parent().css("border", "1px solid  rgb(192, 61, 190)");
                            $this.change(function () {
                                changeBorderColor(this);
                            });
                        }

                        var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";

                        //Crear un nuevo objeto Message
                        oMessage = {};
                        oMessage.ErrorType = !changeMessage ? "Required" : $this.attr("label")
                        oMessage.Field = Field;
                        arrayMessage.push(oMessage);
                        EndRequestHandler();
                    }
                } else {
                    result = false;
                    var Field = getLabelField($this);
                    if (ishighlightedFieldRequired) {
                        $this.parent().css("border", "1px solid  rgb(192, 61, 190)");
                        $this.change(function () {
                            changeBorderColor(this);
                        });
                    }

                    var changeMessage = $this.attr("changeMessage") != null && $this.attr("changeMessage") == "true";
                    oMessage = {};
                    oMessage.ErrorType = !changeMessage ? "Required" : $this.attr("label");
                    oMessage.Field = Field;
                    arrayMessage.push(oMessage);
                    EndRequestHandler();
                }
            }

        });

        var oJsonMessage = JSON.stringify(arrayMessage);

        var Title = $("#hdnLang").val() == "en" ? "Validation Summary" : "Resumen de Validación";

        //Mostrar el summary de validaciones
        if (arrayMessage.length > 0)
            CustomDialogMessageEx(oJsonMessage, 500, null, true, Title, "jsonMessage");
    }
    return result;
};



//2016-02-12 | Marcos J. Perez
function BMI(height, weight, metric) {
    var bmi = (height.length > 0 && weight.length > 0) ? (height > 0 && weight > 0) ? (weight / Math.pow(height, 2)) : 0 : 0;
    if (bmi > 0 && !metric) { bmi *= 703; }
    return bmi == 'NaN' ? '0.00' : redondeo2decimales(bmi);
}

//2016-06-15 | RRojas
function DisplayCustomMessage(Message) {

    CustomDialogMessageEx(Message, 500, 150, true, "INFO");
}

initializatePopupsAndClose = function (Id) {
    //JQueryPopup({
    //    ElementIDorClass: Id,
    //    pautoOpen: false
    //});

    //$(Id).parent().find("[class*='ui-button']").click();
    $(Id).dialog({ autoOpen: false });
    $(Id).dialog("destroy");

    //$(Id).dialog("close");
};

function checkDate(from, to) {

    var fromDate = from.val(); // For JQuery
    var toDate = to.val();

    var monthFrom = fromDate.substring(0, 2);
    var dateFrom = fromDate.substring(3, 5);
    var yearFrom = fromDate.substring(6, 10);

    var monthTo = toDate.substring(0, 2);
    var dateTo = toDate.substring(3, 5);
    var yearTo = toDate.substring(6, 10);


    var myDateFrom = new Date(yearFrom, monthFrom - 1, dateFrom);
    var myDateTo = new Date(yearTo, monthTo - 1, dateTo);



    if (myDateFrom > myDateTo) {
        return true;
    }
    else {
        return false;
    }
}

function ProcessKeyPress(s, evt) {
    var charCode = (evt.htmlEvent.which) ? evt.htmlEvent.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        _aspxPreventEvent(evt.htmlEvent);

}

function validateTXT(sender) {

    var returnVal = true;
    //var test_date = $("#txtBirthDate").val();

    if ($("#txtFromDate").val().trim() == "") {
        $("#txtFromDate").focus();
        CustomDialogMessageEx('The field \'From Date\' is required', 500, 150, true, "Required Field");
        returnVal = false;
    }
    else if ($("#txtToDate").val().trim() == "") {
        $("#txtToDate").focus();
        CustomDialogMessageEx('The field \'To Date\' is required', 500, 150, true, "Required Field");
        returnVal = false;
    } else if (checkDate($("#txtFromDate"), $("#txtToDate"))) {
        CustomDialogMessageEx('The field \'To Date\' can\'t be less than \'From Date\'', 500, 150, true, "Invalid Value");
        returnVal = false;
    }

    if (returnVal) {
        BeginRequestHandler(sender, null);
    }

    return returnVal;

}

setCurrentAccordeonForIndex = function (hiddenfield) {
    if ($(hiddenfield).val() != "" & $(hiddenfield).val() != null) {
        var divActiveAccordeon = $(hiddenfield).val().split("|")[0];
        var ActiveAccordeonIndex = $(hiddenfield).val().split("|")[1];

        $($("#" + divActiveAccordeon + " > li").find("a[lnk='lnk']")).attr("id", "");
        $($("#" + divActiveAccordeon + " > li").find("a[lnk='lnk']")[ActiveAccordeonIndex]).addClass("shown").addClass("open").attr("id", "current");
        $(ObjAcordeon).accordion({ initShow: "#current" });
    }
};

setCurrentAccordeon = function (obj, hiddenfield) {
    var index = 0;

    var isOpen = $(obj).parent().find("ul:first").css("display") == "block";

    if (!isOpen) {
        $(obj).parent().parent().find("li").find("a[lnk='lnk']").removeAttr("alt");
        //Marcar el Objeto como abierto
        $(obj).attr("alt", "Open");

        var hrefArray = $(obj).parent().parent().find("li").find("a[lnk='lnk']");

        var divParent = $(obj).parent().parent().attr("id");

        for (var x = 0; x <= hrefArray.length - 1; x++) {
            if ($(hrefArray[x]).attr("alt") == "Open") {
                $(hiddenfield).val(divParent + "|" + x);
                break;
            }
        }
    }
};

//Seleccionar Tab Cases Lado derecho en el tab Underwriting Call
ChangeTabCasesUnderwritingCall = function (Tab, objId) {

    //Limpiar
    $("#MenuCasesUnderwritingCall li").removeClass("active");

    //Display none para todos los elementos que tengan la Css class accordion_tabulado
    //$("#contenedorTabsUnderwritingCall > div").css("display", "none");

    vTab = $('#' + Tab);
    obj = $('#' + objId);

    $(obj).parent().addClass("active");

    vTab.css("display", "block");
};

//Seleccionar Tab Cases Lado derecho
ChangeTabCasesRight = function (Tab, objId) {

    //Limpiar
    $("#MenuCasesRight li").removeClass("active");

    $("#pnRightControl .accordion_tabulado > ul > li > a").attr("id", "");

    //Display none para todos los elementos que tengan la Css class accordion_tabulado
    $("#contenedorTabs > div").css("display", "none");

    vTab = $('#' + Tab);
    obj = $('#' + objId);

    $(obj).parent().addClass("active");

    vTab.css("display", "block");

    if (Tab == "underwriting_call") {
        $("#UnderwritingCall").css({ "display": "block" });
        $("#NoUnderwritingCall").css({ "display": "none" });
    }
    else {
        $("#UnderwritingCall").css({ "display": "none" });
        $("#NoUnderwritingCall").css({ "display": "block" });

        //Poner el Primer accordeon como active
        $("#pnRightControl .accordion_tabulado > ul > li > a").attr("id", "");

        $(vTab).find("ul:first").find("li:first").find("a:first").attr("id", "current");

        $(ObjAcordeon).accordion({ initShow: "#current" });
    }
};

//Seleccionar Tab Cases del Lado Izquierdo
ChangeTabCasesLeft = function (Tab, objId) {
    //Limpiar
    $("#MenuCasesLeft li").removeClass("active");

    $("#pnLeftControl .accordion_tabulado > ul > li > a").attr("id", "");

    //Display none para todos los elementos que tengan la Css class accordion_tabulado
    $("#pnLeftControl .accordion_tabulado").css("display", "none");

    vTab = $('#' + Tab);
    obj = $('#' + objId);

    $(obj).parent().addClass("active");

    vTab.css("display", "block");

    //Poner el Primer accordeon como active
    $("#pnLeftControl .accordion_tabulado > ul > li > a").attr("id", "");

    $(vTab).find("ul:first").find("li:first").find("a:first").attr("id", "current");

    $(ObjAcordeon).accordion({ initShow: "#current" });

};

//Seleccionar Tab Cases Lado derecho en el tab Underwriting Call
ChangeTabMenuCasesAllCases = function (objId) {

    //Limpiar
    $("#MenuCasesAllCases li").removeClass("active");

    //Activar SubTab Seleccionado
    obj = $('#' + objId);
    $(obj).parent().addClass("active");

};

ViewTabs = function () {
    $('#hdnVisiblePanels').val('false');
    $('#hdnGridKey').val('');
};



function ValidateEmailAddress(Control) {
    var result = true;
    var txtEmail = $('#EmailAddressTxt').val().trim();



    var emailTypeDDL = $get('EmailTypeDDL').selectedIndex;
    if (emailTypeDDL == 0) {
        CustomDialogMessageEx('You must select an Email Type, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    if (txtEmail == '') {
        $("#EmailAddressTxt").focus();
        CustomDialogMessageEx('You must specify an Email, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if (!ValidateEmail(txtEmail)) {
        $("#EmailAddressTxt").focus();
        result = false;
    }
    return result;
}

function ValidateEmailAddress2() {

    var result = true;
    var txtEmail = $('#BEmailAddressTxt').val().trim();
    var emailTypeDDL = $get('BEmailTypeDDL').selectedIndex;
    if ($get('PrimaryBeneficiaryEmail').selectedIndex == 0) {
        $("#PrimaryBeneficiaryEmail").focus();
        //  alert($("#AddresTypeDDL").val());
        CustomDialogMessageEx('You must select a Beneficiary in order to continue, please select one and try again.', 500, 150, true, "Required Field");
        result = false;
    } else if (emailTypeDDL == 0) {
        CustomDialogMessageEx('You must select an Email Type, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if (txtEmail == '') {
        $("#BEmailAddressTxt").focus();
        CustomDialogMessageEx('You must specify an Email, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if (!ValidateEmail(txtEmail)) {
        $("#BEmailAddressTxt").focus();
        result = false;
    }
    return result;
}

function ValidatePhoneNumber() {
    var result = true;
    if ($get('DDLPhoneType').selectedIndex == 0) {
        $("#DDLPhoneType").focus();
        CustomDialogMessageEx('You must select a Phone Type, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($('#CountryCodeTxt').val().trim() == '') {
        $("#CountryCodeTxt").focus();
        CustomDialogMessageEx('You must specify a Country Code, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($('#AreaCodeTxt').val().trim() == '') {
        $("#AreaCodeTxt").focus();
        CustomDialogMessageEx('You must specify an Area Code, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($('#PhoneNumberTxt').val().trim() == '') {
        $("#PhoneNumberTxt").focus();
        CustomDialogMessageEx('You must specify a Phone Number, please try again.', 500, 150, true, "Required Field");
        result = false;
    }

    else if ($('#PhoneNumberTxt').val().trim().length < 8) {
        $("#PhoneNumberTxt").focus();
        CustomDialogMessageEx('You must provide a valid Phone Number, please try again.', 500, 150, true, "Invalid Value");
        result = false;
    }

    else if ($('#ContactTxt').val().trim() == '') {
        $("#ContactTxt").focus();
        CustomDialogMessageEx('You must specify a Contact, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    return result;
}

function ValidatePhoneNumberB() {
    var result = true;

    if ($get('PrimaryBeneficiaryEmail').selectedIndex == 0) {
        $("#PrimaryBeneficiaryEmail").focus();
        //  alert($("#AddresTypeDDL").val());
        CustomDialogMessageEx('You must select a Beneficiary in order to continue, please select one and try again.', 500, 150, true, "Required Field");
        result = false;
    } else if ($get('BDDLPhoneType').selectedIndex == 0) {
        $("#BDDLPhoneType").focus();
        CustomDialogMessageEx('You must select a Phone Type, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($('#BCountryCodeTxt').val().trim() == '') {
        $("#BCountryCodeTxt").focus();
        CustomDialogMessageEx('You must specify a Country Code, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($('#BAreaCodeTxt').val().trim() == '') {
        $("#BAreaCodeTxt").focus();
        CustomDialogMessageEx('You must specify an Area Code, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($('#BPhoneNumberTxt').val().trim() == '') {
        $("#BPhoneNumberTxt").focus();
        CustomDialogMessageEx('You must specify a Phone Number, please try again.', 500, 150, true, "Required Field");
        result = false;
    }

    else if ($('#BPhoneNumberTxt').val().trim().length < 8) {
        $("#BPhoneNumberTxt").focus();
        CustomDialogMessageEx('You must provide a valid Phone Number, please try again.', 500, 150, true, "Invalid Value");
        result = false;
    }

    else if ($('#BContactTxt').val().trim() == '') {
        $("#BContactTxt").focus();
        CustomDialogMessageEx('You must specify a Contact, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    return result;
}


function ValidateAddress() {
    var result = true;
    if ($get('AddresTypeDDL').selectedIndex == 0) {
        $("#AddresTypeDDL").focus();
        //  alert($("#AddresTypeDDL").val());
        CustomDialogMessageEx('You must select an Address Type, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($('#StreetAdressTxt').val().trim() == '') {
        $("#StreetAdressTxt").focus();
        CustomDialogMessageEx('You must specify a Street Address, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($get('CountryDDL').selectedIndex == 0) {
        $("#CountryDDL").focus();
        CustomDialogMessageEx('You must specify a Country, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($get('StateDDL').selectedIndex == 0) {
        $("#StateDDL").focus();
        CustomDialogMessageEx('You must specify a State, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($get('CityDDL').selectedIndex == 0) {
        $("#CityDDL").focus();
        CustomDialogMessageEx('You must specify a City, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    //else if ($('#PostalCodeTxt').val().trim() == '') {
    //    $("#PostalCodeTxt").focus();
    //    CustomDialogMessageEx('You must specify a Postal Code, please try again.', 500, 150, true, "Required Field");
    //    result = false;
    //}
    return result;
}

/*ROJAS: Same Validation for Beneficiaries Addresses*/
function ValidateAddressBeneficiaries() {
    var result = true;
    if ($get('PrimaryBeneficiary').selectedIndex == 0) {
        $("#PrimaryBeneficiary").focus();
        //  alert($("#AddresTypeDDL").val());
        CustomDialogMessageEx('You must select a Beneficiary in order to continue, please select one and try again.', 500, 150, true, "Required Field");
        result = false;
    } else if ($get('BAddresTypeDDL').selectedIndex == 0) {
        $("#BAddresTypeDDL").focus();
        //  alert($("#AddresTypeDDL").val());
        CustomDialogMessageEx('You must select an Address Type, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($('#BStreetAdressTxt').val().trim() == '') {
        $("#BStreetAdressTxt").focus();
        CustomDialogMessageEx('You must specify a Street Address, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($get('BCountryDDL').selectedIndex == 0) {
        $("#BCountryDDL").focus();
        CustomDialogMessageEx('You must specify a Country, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($get('BStateDDL').selectedIndex == 0) {
        $("#BStateDDL").focus();
        CustomDialogMessageEx('You must specify a State, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    else if ($get('BCityDDL').selectedIndex == 0) {
        $("#BCityDDL").focus();
        CustomDialogMessageEx('You must specify a City, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    //else if ($('#PostalCodeTxt').val().trim() == '') {
    //    $("#PostalCodeTxt").focus();
    //    CustomDialogMessageEx('You must specify a Postal Code, please try again.', 500, 150, true, "Required Field");
    //    result = false;
    //}
    return result;
}




function ExposureElements() {
    var chk = GetArrayByClassAndIdLike('ExposureChk', 'ExpChk', 'input');

    if (chk != null) {
        for (var i = 0; i < chk.length; i++) {
            var item = chk[i].attr('id').split("_")[6];
            $("[id$=ExposurePositionTxt_" + item + "]").parent().toggle(chk[i].is(':checked'));

            var checked = chk[i].is(':checked');

            if (!checked) {
                $("[id$=ExposurePositionTxt_" + item + "]").val("");
            }
        }
    }
}

function RelationshipElements() {
    var chk = GetArrayByClassAndIdLike('RelationshipChk', 'RelChk', 'input');

    if (chk != null) {
        for (var i = 0; i < chk.length; i++) {
            var item = chk[i].attr('id').split("_")[6];

            $("[id$=RelationshipNameTxt_" + item + "]").parents("li:first").toggle(chk[i].is(':checked'));

            var checked = chk[i].is(':checked');

            if (!checked) {
                $("[id$=RelationshipNameTxt_" + item + "]").val("");
            }
        }
    }
}

function ValidateExposureElements() {
    var chk = GetArrayByClassAndIdLike('ExposureChk', 'ExpChk', 'input');
    var result = true;
    if (chk != null) {
        for (var i = 0; i < chk.length; i++) {
            var item = chk[i].attr('id').split("_")[6];
            var checked = chk[i].is(':checked');

            if (checked) {
                if ($("[id$=ExposurePositionTxt_" + item + "]").val().trim() == '') {
                    result = false;
                    CustomDialogMessageEx('You must specify a \'CLIENT IS A\' text field, please try again.', 500, 150, true, "Required Field");
                }

            }

        }

    }
    return result;
}

function ValidateRelationshipElements() {
    var chk = GetArrayByClassAndIdLike('RelationshipChk', 'RelChk', 'input');
    var result = true;
    if (chk != null) {
        for (var i = 0; i < chk.length; i++) {
            var item = chk[i].attr('id').split("_")[6];
            var checked = chk[i].is(':checked');

            if (checked) {
                if ($("[id$=RelationshipNameTxt_" + item + "]").val().trim() == '') {
                    result = false;
                    CustomDialogMessageEx('You must specify a \'HAS A CLOSE RELATIONSHIP WITH A\' text field, please try again.', 500, 150, true, "Required Field");
                }
            }

        }
    }

    return result;
}

function CitizenQuestions() {
    $('.CitizenQuesChk').each(function (Index, Item) {
        if (Boolean($(Item).siblings().hasClass('radioSelect'))) {
            switch ($(Item).parents().attr('class').split(' ')[0]) {
                case "li_si":
                    $(Item).parents().siblings().find(".li_no").find('span').find("input:radio").prop('checked', false);
                    $(Item).children('input:radio:first').prop('checked', true);
                    break;
                case "li_no":
                    $(Item).parents().siblings().find(".li_si").find('span').find("input:radio").prop('checked', false);
                    $(Item).children('input:radio:first').prop('checked', true);
                    break;
            }
        };
    });
}


function SetRadioButtonGroupName() {
    var IncrementName = 0;
    //$('.radiogroup').each(function (Index, Item) {
    //    $(Item).find("input:radio").prop('name', 'si_no_' + IncrementName);
    //    //$(Item).find("label").prop('for', 'si_no_' + IncrementName);
    //    IncrementName++;
    //});
}

function ValidateRightForm() {
    var result = true;
    var Tab = $('#hfMenuCasesRight').val().split('|')[0];


    if (Tab == "notes") {

        if ($("#txtTitleNote").val().trim() == "") {
            $("#txtTitleNote").focus();
            CustomDialogMessageEx('The Title of Note is required, please try again.', 500, 150, true, "Required Field");
            result = false;
        } else if ($("#txtBodyNote").val().trim() == "") {
            $("#txtBodyNote").focus();
            CustomDialogMessageEx('The Body of Note  is required, please try again.', 500, 150, true, "Required Field");
            result = false;
        } else if ($("#ddlReference").val() == "-1" || $("#ddlReference").val() == null) {
            $("#ddlReference").focus();
            CustomDialogMessageEx('You must select a reference, please try again.', 500, 150, true, "Required Field");
            result = false;
        }

    }

    return result;
}

function ValidateLeftForm() {
    var result = true;
    var Tab = $('#hfMenuCasesLeft').val().split('|')[0];
    if (Tab == "PersonalData") {

        //Bmarroquin 12-03-2017 Correccion estaba validando los documentos en otros tab en los cuales no procedia
        //NIT
        //Licencia
        if ((eval($('#IdtypeDDL').val()) == 7) || (eval($('#IdtypeDDL').val()) == 3)) {

            var $txt = $("input[name='ctl00$Left$Left$UCPersonalDataContainer$UCPersonalData1$idTxt']").inputmask("9999-999999-999-9");

            var value = $("input[name='ctl00$Left$Left$UCPersonalDataContainer$UCPersonalData1$idTxt']").val();

            var num = value.replace("-", "").replace("-", "").replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "");

            if (num.length < 14) {
                CustomDialogMessageEx('El NIT/Licencia debe tener 14 digitos.', 500, 150, true, "Advertencia");
                return false;
            }

        }
            //DUI
        else if (eval($('#IdtypeDDL').val()) == 1) {

            var $txt = $("input[name='ctl00$Left$Left$UCPersonalDataContainer$UCPersonalData1$idTxt']").inputmask("99999999-9");

            var value = $("input[name='ctl00$Left$Left$UCPersonalDataContainer$UCPersonalData1$idTxt']").val();

            var num = value.replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "");

            if (num.length < 9) {
                CustomDialogMessageEx('El DUI debe tener 9 digitos.', 500, 150, true, "Advertencia");
                return false;
            }
        }
            //Pasaporte
        else if (eval($('#IdtypeDDL').val()) == 2) {

            var $txt = $("input[name='ctl00$Left$Left$UCPersonalDataContainer$UCPersonalData1$idTxt']").inputmask("remove");

        }
            //RNC--> Registro de Compañia
            //Carnet de Residente
            //Cerificado de Nacimiento --remove
        else {
            //mavelar 18-03-2017 Cambio para dejar abierto los documentos se cambia .inputmask("integer")  por .inputmask("remove");
            var $txt = $("input[name='ctl00$Left$Left$UCPersonalDataContainer$UCPersonalData1$idTxt']").inputmask("remove");
        }

        /*************mavelar 03/05/2017  *******************/
        //Fin Cambio Bmarroquin 12-03-2017 

        //Personal Data
        $('.validationElement').each(function (Index, Item) {
            if ($(Item).is('select')) {
                if (($get($(Item).attr('id')).selectedIndex == 0) || ($get($(Item).attr('id')).selectedIndex == -1)) {
                    switch ($(Item).attr('id').toLowerCase()) {
                        case "countryofresidenceddl":
                            CustomDialogMessageEx('You must select a Country Of Residence, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "provinceofresidenceddl":
                            CustomDialogMessageEx('You must select a Province Of Residence, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "cityofresidenceddl":
                            CustomDialogMessageEx('You must select a City Of Residence, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "maritalstatusddl":
                            CustomDialogMessageEx('You must select a Marital Status, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "genderddl":
                            CustomDialogMessageEx('You must select a Gender, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "smokerddl":
                            CustomDialogMessageEx('You must select a Smoker option, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "countryofbirthddl":
                            CustomDialogMessageEx('You must select a Country Of Birth, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "occupationddl":
                            CustomDialogMessageEx('You must select a Occupation, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "idtypeddl":
                            CustomDialogMessageEx('You must select an Id Type, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "relationshipownerddl":
                            CustomDialogMessageEx('You must select a Relationship To Owner Option, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "relationshiptoagentddl":
                            CustomDialogMessageEx('You must select a Relationship To Agent Option, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "issuedbyddl":
                            CustomDialogMessageEx('You must select an Issued By Country, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                    }
                }
            }
            else if ($(Item).is('input[type=text]')) {
                if ($(Item).val().trim() == '') {
                    $(Item).focus();
                    switch ($(Item).attr('id').toLowerCase()) {
                        case "firstnametxt":
                            CustomDialogMessageEx('You must specify a First Name, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "lastnametxt":
                            CustomDialogMessageEx('You must specify a Last Name, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "agetxt":
                            CustomDialogMessageEx('You must specify an Age, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "nearagetxt":
                            CustomDialogMessageEx('You must specify a NearAgeTxt, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                        case "dobtxt":
                            CustomDialogMessageEx('You must specify a Date Of Birth, please try again.', 500, 150, true, "Required Field");
                            result = false;
                            break;
                            //Bmarroquin 03-02-2017 cambios a raiz de tropicalizacion ESA, los campos no deben ser obligatorios
                            /*case "personalincometxt":
                                CustomDialogMessageEx('You must specify a Personal Income, please try again.', 500, 150, true, "Required Field");
                                result = false;
                                break;
                            case "yearfamilyincometxt":
                                CustomDialogMessageEx('You must specify a YearFamily Income, please try again.', 500, 150, true, "Required Field");
                                result = false;
                                break; */
                            //case "idexpirationdatetxt":
                            //	CustomDialogMessageEx('You must specify a Id ExpirationDate, please try again.', 500, 150, true, "Required Field");
                            //	result = false;
                            //	break;
                    }
                }
            }
        });

        var perIncome = parseFloat($('#PersonalIncomeTxt').val().replace(/,/g, ''));
        var famIncome = parseFloat($('#YearFamilyIncomeTxt').val().replace(/,/g, ''));

        if (result != false) {
            //Bmarroquin 03-02-2017 cambios a raiz de tropicalizacion ESA, Validar los ingresos solamente si se ha ingresado el monto en ambos campos personal y family Income
            if (perIncome > 0 && famIncome > 0) {
                if (perIncome > famIncome) {
                    CustomDialogMessageEx('Personal Income cannot exceed the Family Income, please try again.', 500, 150, true, "Invalid Value");
                    result = false;
                }
            }

        }

        if (result != false) {
            if (!$('#DOBTxt').val().trim().IsDate('MM/dd/yyyy')) {
                CustomDialogMessageEx('The Date of Birth is invalid, please try again.', 500, 150, true, "Invalid Value");
                result = false;
            }
            else if ($('#DOBTxt').val().trim().ToDate('MM/dd/yyyy') >= new Date()) {
                CustomDialogMessageEx('Date of Birth cannot exceed the Current Date, please try again.', 500, 150, true, "Invalid Value");
                result = false;
            }
        }

        if (result != false) {
            /******** mavelar 3/29/17 *********/
            if ((eval($('#IdtypeDDL').val()) == 7) || (eval($('#IdtypeDDL').val()) == 5) || (eval($('#IdtypeDDL').val()) == 9 || (eval($('#IdtypeDDL').val()) == 6))) {
                $("#IdExpirationDateTxt").removeAttr("validation");
            }
            else {
                $("#IdExpirationDateTxt").attr("validation", "Required");
                //CustomDialogMessageEx('The Expiration Date is invalid, please try again.', 500, 150, true, "Invalid Value");
                //result = false;
            }
        }

        if (result != false) {
            result = ValidateExposureElements() && ValidateRelationshipElements();
        }
    }

    return result;
}

function ValidateDateFormat(dateField) {
    var result = true;
    if (!$(dateField).val().trim().IsDate('MM/dd/yyyy')) {
        CustomDialogMessageEx('The Date is invalid, please try again.', 500, 150, true, "Invalid Value");
        result = false;
    }

    return result;

}

function ValidateCitizenshipCountry() {
    var result = true;
    if ($get('CountryOfCitizenShipDDL').selectedIndex == 0) {
        CustomDialogMessageEx('You must select a Country Of CitizenShip, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    return result;
}

function ValidateBeneficiaries(sender) {
    var clase = $(sender).attr("class").split(" ")[1];

    //Para Buscar los controles a validar, esto procedimiento es porque no se pueden 
    //buscar por nombre ya que el control se repite varias veces en la misma pagina.
    var txtFirstName = GetElementByClassAndId('txtFirstName', clase, 'input[type="text"]').val().trim();
    var txtLastName = GetElementByClassAndId('txtLastName', clase, 'input[type="text"]').val().trim();

    var ddlRelationship = GetElementByClassAndId('ddlRelationship', clase, 'select').prop("selectedIndex");

    //Para Buscar el Datepicker del Control que llamo el Evento.
    var arrayTxt = $("[name$=txtBEDateofBirth]");
    var txtBEDateofBirth = null;

    for (var x = 0; x <= arrayTxt.length; x++) {
        if ($(arrayTxt[x]).hasClass(clase)) {
            txtBEDateofBirth = $(arrayTxt[x]).val();
            break;
        }
    }

    if (ddlRelationship > 0) {
        returnVal = true;
    }
    else {
        CustomDialogMessageEx('Please select a Relationship and try again.', 500, 150, true, 'Required Field');
        return false;
    }

    if (txtFirstName != '') {
        returnVal = true;
    }
    else {
        CustomDialogMessageEx('Please specify a First Name and try again.', 500, 150, true, 'Required Field');
        return false;
    }

    if (txtLastName != '') {
        returnVal = true;
    }
    else {
        CustomDialogMessageEx('Please specify a Last Name and try again.', 500, 150, true, 'Required Field');
        return false;
    }

    if (txtBEDateofBirth != null) {
        if (txtBEDateofBirth != '') {
            returnVal = true;
        }
        else {
            CustomDialogMessageEx('Please specify a Birth Date and try again.', 500, 150, true, 'Required Field');
            return false;
        }

        if (txtBEDateofBirth.IsDate('mm/dd/yyyy')) {
            returnVal = true;
        }
        else {
            CustomDialogMessageEx('Please specify a valid Birth Date and try again.', 500, 150, true, 'Required Field');
            return false;
        }
    }

    if ($('#hdnProductFamily').val().toLowerCase() != 'funeral') {
        var txtPercentage = GetElementByClassAndId('txtPercentage', clase, 'input[type="text"]').val().trim();
        if (txtPercentage != '' && txtPercentage > 0) {
            returnVal = true;
        }
        else {
            CustomDialogMessageEx('Please specify a valid Percentage and try again.', 500, 150, true, 'Required Field');
            return false;
        }

        if (txtPercentage < 101) {
            returnVal = true;
        }
        else {
            CustomDialogMessageEx('Percentage can not exceed 100%, please specify a valid Percentage and try again.', 500, 150, true, 'Invalid Value');
            return false;
        }
    }

    return true;
}

function validateRiderFields(sender) {

    var returnVal = true;

    var id = sender.id;

    //if ((id == "btnAdd" && $("#ddlRiderType").is(':enabled')) || (id == "btnEdit" && $("#btnEdit").val() == "Save")) {
    if ((id == "btnAdd" && $("#ddlRiderType").is(':enabled')) || ($("#btnAdd").val() == "Save")) {

        returnVal = ValidateDateFormat("#txtEffectiveDate");

        if ($('#ddlRiderType option:selected').val() == "0") {
            $("#ddlRiderType").focus();
            CustomDialogMessageEx('The field Rider Type must be selected', 500, 150, true, "Required Field");
            returnVal = false;
        } else if ($('#ddlStatus option:selected').val() == "0") {
            $("#ddlStatus").focus();
            CustomDialogMessageEx('The field Status must be selected', 500, 150, true, "Required Field");
            returnVal = false;
        } else if ($("#txtNumberOfYear").val().trim() == "") {
            $("#txtNumberOfYear").focus();
            CustomDialogMessageEx('The field No. of Years is required, please try again.', 500, 150, true, "Required Field");
            returnVal = false;
        } else if ($("#txtBeneficiaryAmount").val().trim() == "") {
            $("#txtBeneficiaryAmount").focus();
            CustomDialogMessageEx('The field Benefit Amount is required, please try again.', 500, 150, true, "Required Field");
            returnVal = false;
        } else if ($("#txtBeneficiaryAmount").val() <= 0) {
            $("#txtBeneficiaryAmount").focus();
            CustomDialogMessageEx('The field Benefit Amount must be greater than zero (0), please try again.', 500, 150, true, "Invalid Value");
            returnVal = false;
        } else if ($("#txtEffectiveDate").val().trim() == "") {
            $("#txtEffectiveDate").focus();
            CustomDialogMessageEx('The field Start Date is required, please try again.', 500, 150, true, "Required Field");
            returnVal = false;
        }
    }

    if (returnVal) {
        BeginRequestHandler(sender, null);
    }

    return returnVal;
}

function ValidateBeneficiariesCompany(sender) {
    var clase = $(sender).attr("class").split(" ")[1];

    //Para Buscar los controles a validar, esto procedimiento es porque no se pueden 
    //buscar por nombre ya que el control se repite varias veces en la misma pagina.
    var txtEntityName = GetElementByClassAndId('txtEntityName', clase, 'input[type="text"]').val().trim();
    var txtEntityPercentage = GetElementByClassAndId('txtEntityPercentage', clase, 'input[type="text"]').val().trim();
    var ddlEntityType = GetElementByClassAndId('ddlEntityType', clase, 'select').val();

    //Para Buscar el Datepicker del Control que llamo el Evento.
    var arrayTxt = $("[name$=txtBEIncorporationDate]");
    var txtBEIncorporationDate = null;

    for (var x = 0; x <= arrayTxt.length; x++) {
        if ($(arrayTxt[x]).hasClass(clase)) {
            txtBEIncorporationDate = $(arrayTxt[x]).val();
            break;
        }
    }

    if (txtBEIncorporationDate != null) {
        if (txtBEIncorporationDate != '') {
            returnVal = true;
        }
        else {
            CustomDialogMessageEx('Please specify a Incorporation Date and try again.', 500, 150, true, 'Required Field');
            return false;
        }

        if (txtBEIncorporationDate.IsDate('mm/dd/yyyy')) {
            returnVal = true;
        }
        else {
            CustomDialogMessageEx('Please specify a valid Incorporation Date and try again.', 500, 150, true, 'Invalid Required Fields');
            return false;
        }
    }

    if (txtEntityName != '') {
        returnVal = true;
    }
    else {
        CustomDialogMessageEx('Please specify an Entity Name and try again.', 500, 150, true, 'Required Field');
        return false;
    }

    if (txtEntityPercentage != '' && txtEntityPercentage > 0) {
        returnVal = true;
    }
    else {
        CustomDialogMessageEx('Please specify a valid Percentage and try again.', 500, 150, true, 'Required Field');
        return false;
    }

    if (txtEntityPercentage < 101) {
        returnVal = true;
    }
    else {
        CustomDialogMessageEx('Percentage can not exceed 100%, please specify a valid Percentage and try again.', 500, 150, true, 'Invalid Value');
        return false;
    }

    if (ddlEntityType != '' && ddlEntityType != '-1') {
        returnVal = true;
    }
    else {
        CustomDialogMessageEx('Please select an Entity Type and try again.', 500, 150, true, 'Required Field');
        return false;
    }

    return true;
}

function uploadFileChange(sender, event) {
    sender.Upload();
}

function uploadFileComplete(sender, event) {
    var obj = JSON.parse(event.callbackData);
    if (obj.file == "")
        showAlert(obj.error);
    else {
        var clase = sender.mainElement.attributes.class.value.split(" ")[1];
        if (clase != null) {
            var hdnUploadedPDFPath = GetElementByClassAndId('hdnUploadedPDFPath', clase, 'input[type="text"]');

            if (hdnUploadedPDFPath != null) {
                var FileName = obj.file.split("~~")[1];
                hdnUploadedPDFPath.val(obj.file);

                FileName = "..\\TempFiles\\" + FileName;
                setIntervalFileName(FileName, clase, 0);
            }
        }
    }
}

function uploadFileCompanyComplete(sender, event) {
    var obj = JSON.parse(event.callbackData);
    if (obj.file == "")
        showAlert(obj.error);
    else {
        var clase = sender.mainElement.attributes.class.value.split(" ")[1];
        if (clase != null) {
            var hdnUploadedPDFPathCompany = GetElementByClassAndId('hdnUploadedPDFPathCompany', clase, 'input[type="text"]');

            if (hdnUploadedPDFPathCompany != null) {
                var FileName = obj.file.split("~~")[1];
                hdnUploadedPDFPathCompany.val(obj.file);

                FileName = "..\\TempFiles\\" + FileName;
                setIntervalFileName(FileName, clase, 1);
            }
        }
    }
}

//Usado para setear un intervalo, para mostrar el nombre del documento, ya que al subirlo, no se queda en el textbox.
function setIntervalFileName(fileName, className, isCompany) {
    var myVar = setInterval(function () {

        if (isCompany == 1) {
            switch (className) {
                case 'MP':
                    $('#Left_Left_UCMainBeneficiaries_fuBenediciarieFileCompany_TextBox0_FakeInput').val(fileName);
                    break;
                case 'MC':
                    $('#Left_Left_UCContingentBeneficiaries_fuBenediciarieFileCompany_TextBox0_FakeInput').val(fileName);
                    break;
                case 'AP':
                    $('#Left_Left_UCAddtionalInsuranceMainBeneficies_fuBenediciarieFileCompany_TextBox0_FakeInput').val(fileName);
                    break;
                case 'AC':
                    $('#Left_Left_UCAddtionalContingentBeneficies_fuBenediciarieFileCompany_TextBox0_FakeInput').val(fileName);
                    break;
            }
        }
        else {
            switch (className) {
                case 'MP':
                    $('#Left_Left_UCMainBeneficiaries_fuBenediciarieFile_TextBox0_FakeInput').val(fileName);
                    break;
                case 'MC':
                    $('#Left_Left_UCContingentBeneficiaries_fuBenediciarieFile_TextBox0_FakeInput').val(fileName);
                    break;
                case 'AP':
                    $('#Left_Left_UCAddtionalInsuranceMainBeneficies_fuBenediciarieFile_TextBox0_FakeInput').val(fileName);
                    break;
                case 'AC':
                    $('#Left_Left_UCAddtionalContingentBeneficies_fuBenediciarieFile_TextBox0_FakeInput').val(fileName);
                    break;
            }
        }
        clearInterval(myVar);
    }, 100);
}

function AddRequirement() {
    var Values = '';
    $('.Requirementchk').find('input:checkbox').each(function (Index, Item) {
        //var checkbox = $(Item).children('input:checkbox');
        if ($(Item).prop('checked'))
            Values += $(Item).prop('value') + ',';
    });
    $('#hfNewRequirementTable').val(Values);
}

function ValidateAddRequirement() {
    var result = true;
    if ($get('RequirementRoleDDL').selectedIndex == 0) {
        CustomDialogMessageEx('You must specify a Role, please try again.', 500, 150, true, "Required Field");
        $('#RequirementRoleDDL').focus();
        result = false;
    }
    else if ($get('ddlRequirementCategory').selectedIndex == -1) {
        CustomDialogMessageEx('You must specify a Category, please try again.', 500, 150, true, "Required Field");
        $('#ddlRequirementCategory').focus();
        result = false;
    }
    else if ($('#hfNewRequirementTable').val() == "") {
        CustomDialogMessageEx('You must Check a Requirement from the list, please try again.', 500, 150, true, "Required Field");
        result = false;
    }
    return result;
}

function ValidateSaveRequirement() {
    var result = true;
    if ($get('RequirementRoleDDL').selectedIndex == 0) {
        CustomDialogMessageEx('You must specify a Role, please try again.', 500, 150, true, "Required Field");
        $('#RequirementRoleDDL').focus();
        result = false;
    }
    return result;
}


function uploadFileRequirementComplete(sender, event) {
    if (event != '') {
        if (event.callbackData != '') {
            $('#hdnRequirementUploadedPDFPath').val(event.callbackData);
            $('#fuRequirementFile_TextBox0_FakeInput').val(event.callbackData.split('~~')[1]);
            $('#btnRequirementPreviewPDF').trigger('click');
        }
    }
}

function uploadFileTerminateExclusionComplete(sender, event) {
    if (event != '') {
        if (event.callbackData != '') {
            $('#hdnTerminateExclusionPdfPath').val(event.callbackData);
            $('#fuTerminateExclusionFile_TextBox0_FakeInput').val(event.callbackData.split('~~')[1]);
        }
    }
}

function CloseRequirementPop() {
    $('#dvAddNewRequirement').dialog('close');
    return false;
}

function CloseTerminateExclusionPop() {
    $("#txtNotificationDateTerminateExclusion").val("");
    $("#txtEndDateTerminateExclusion").val("");
    $("#txtTerminateExclusionComment").val("");
    $find("ModalPopupTerminateExclusion").hide();
    return false;
}

function CloseGeneralPdfPop() {
    $find("ModalPdfPop").hide();
    $("#hdnNSShowPDFPop").val("false");
    return false;
}

function CloseGeneralPdfPopIFOpen() {
    if ($("#hdnNSShowPDFPop").val() == "false")
        $find("ModalPdfPop").hide();
}

function CloseRequirementPDFPop() {
    $find("ModalPopupPDFViewer").hide();
    $("#hfRequirementPdfPopUp").val("false");
    return false;
}

function CloseCommunicationPDFPop() {
    $find("mpRequirementComunication").hide();
    $("#hfRequirementComunication").val("false");
    return false;
}

function CloseNotesCommentPop() {
    $('#dvCommentInfo').dialog('close');
    return false;
}

function CloseRiderPop() {
    $('#dvRiderReason').dialog('close');
    return false;
}

function CloseAmendmentsPop() {
    $('#dvRequestAmendments').dialog('close');
    return false;
}

function CloseCreditsPop() {
    $('#dvNewCredit').dialog('close');
    return false;
}

function CancelNotesCommentPop() {
    $('#txtNewComment').val("");
    $('#pnComment').toggle();
    RelocatePops();
    $('#dvNCNewComment').toggle();

    return false;
}

function TogglePanel(txt, panel) {
    $(txt).val("");
    $(panel).toggle();
    RelocatePops();
    return false;
}

function CloseNotesCommentPop() {
    $('#dvNCNewComment').show();
    $('#dvCommentInfo').dialog('close');
    return false;
}

function CloseCCNotePopup() {
    $('#dvCCNotePopup').dialog('close');
    return false;
}

function CloseCCCallPop() {
    $('#dvCCCallPopup').dialog('close');
    return false;
}

function CloseUSCommentsPop() {
    $('#dvPopUSComments').dialog('close');
    return false;
}

function CloseNSAddStepPop() {
    $("#hdnNSShowPop").val('false');
    $find('ModalNewStepPop').hide();
    return false;
}

function CloseUCAttachCall() {
    $('#dvPopUCAttachCall').dialog('close');
    return false;
}

function ClosePEPRelatedPop() {
    $("#hdnNewPepRelatedShowPop").val('false');
    $find('ModalNewPepRelatedPop').hide();
    return false;
}

function ValidateCommentNote() {
    if ($('#txtNewComment').val().trim() == "") {
        $("#txtNewComment").focus();
        CustomDialogMessageEx('The field Comment is required, please try again.', 500, 150, true, "Required Field");
        return false;
    }
    $('#dvNCNewComment').show();
    return true;
}

function SetNumericsMask() {
    //$("#txtPercentage").setMask("999");
    //$("#txtEntityPercentage").setMask("999");

    $(".DFormat").attr("alt", "decimal-us").setMask();
    $(".NFormat").attr("alt", "number").setMask();


    $(".DecimalOneDigit").inputmask("decimal", { autoGroup: true, groupSeparator: ",", groupSize: 2, digits: 2, rightAlign: true, allowMinus: false, repeat: 10 });

    $(".PPDecimalFormat").inputmask("decimal", { autoGroup: true, groupSeparator: ",", groupSize: 3, digits: 2, rightAlign: true, allowMinus: false, repeat: 10 });
    $("#txtBeneficiaryAmount").inputmask("decimal", { autoGroup: true, groupSeparator: ",", groupSize: 3, digits: 2, rightAlign: false, allowMinus: false, repeat: 10 });

    $("#ExtensionTxt").inputmask("integer", { rightAlign: false });
    $("#CountryCodeTxt").inputmask("integer", { rightAlign: false });
    $("#AreaCodeTxt").inputmask("integer", { rightAlign: false });
    $("#txtNumberOfYear").inputmask("integer", { rightAlign: false });
    $('#txtNumberOfYear').setMask("999");
    $('#PhoneNumberTxt').setMask("PhoneNumber");
    $("#txtUCPhoneCCode").inputmask("integer", { rightAlign: false });
    $("#txtUCPhoneACode").inputmask("integer", { rightAlign: false });
    $("#txtUCPhoneNummber").inputmask("integer", { rightAlign: false });
    $("#txtUCPhoneExt").inputmask("integer", { rightAlign: false });
    //Bmarroquin para los campos del Risk Class
    $(".IntegerFormat").inputmask("integer", { rightAlign: true });
    $(".DecimalFormat").inputmask("decimal", { rightAlign: true });

}

function ShowHideUnderStepNotes(dvId) {
    var dv = $("#" + dvId);

    if (dv.length > 0)
        dv.toggle();

    return false;
}

function ShowUSAddComment(sender) {
    if (sender == "close") {
        $('#txtUSCNewComment').attr("placeholder", "Add Comment Close Step...");
        if ($('#Right_Right_UCUnderwritingStep_UCPopStepComments_hdnStepId').val() === "102") {
            $('#ddlforBackgroundCheck').show();
        } else {
            $('#ddlforBackgroundCheck').hide();
        }
       
    }
    else if (sender == "void") {
        $('#txtUSCNewComment').attr("placeholder", "Add Comment Void Step...");
    }
    else {
        $('#txtUSCNewComment').attr("placeholder", "Add Comment...");
    }
    $("#txtUSCNewComment").val("");
    $("#steps_comentario").css("display", "block");
    $("#hdnSaveCommentSender").val(sender);
    RelocatePops();
    return false;
}

function HideUSAddComment() {
    $("#txtUSCNewComment").val("");
    $("#steps_comentario").css("display", "none");
    RelocatePops();
    return false;
}

function ValidateUSSaveComment() {
    if ($('#txtUSCNewComment').val().trim() == "") {
        $("#txtUSCNewComment").focus();
        CustomDialogMessageEx('The field Comment is required, please try again.', 500, 150, true, "Required Field");
        return false;
    }

    return true;
}

function validateRiderComment() {
    if ($('#txtNewCommentRiderReason').val().trim() == "") {
        $("#txtNewCommentRiderReason").focus();
        CustomDialogMessageEx('The field Comment is required, please try again.', 500, 150, true, "Required Field");
        return false;
    }

    return true;
}

function validateCommentCommunication() {
    if ($('#RequirementCommunicationNewCommentsTxt').val().trim() == "") {
        $("#RequirementCommunicationNewCommentsTxt").focus();
        CustomDialogMessageEx('The field Comment is required, please try again.', 500, 150, true, "Required Field");
        return false;
    }

    return true;
}

//Para agregar al LinkButton el evento que muestra la nota
function AddLnkUnderStepsEvents() {
    var listLnk = $('.gvUnderSteps').find("a[id='lblStepDesc']");
    var listDiv = $('.gvUnderSteps').find("div[id='dvUSShowNotes']");

    for (var i = 0; i < listLnk.length; i++) {
        $(listDiv[i]).attr("id", $(listDiv[i]).attr("id") + i);
        $(listLnk[i]).attr("onclick", "return ShowHideUnderStepNotes(\"" + $(listDiv[i]).attr("id") + "\")");
    }
}



//Para agregar los textbox de "Current" y "Standard" al Header
function SetUnderStepsTextbox() {
    var txtUSTotalCurrent = $('#txtUSTotalCurrent');
    var txtUSTotalStandard = $('#txtUSTotalStandard');

    if (txtUSTotalCurrent != null) {
        $('.gvUnderSteps').find("th[class='c7 alignC brNone']").append(txtUSTotalCurrent);
        $(txtUSTotalCurrent).show();
    }

    if (txtUSTotalStandard != null) {
        $('.gvUnderSteps').find("th[class='c8 alignC brNone']").append(txtUSTotalStandard);
        $(txtUSTotalStandard).show();
    }
}

//Para agregar el div de las notas debajo de los rows
function AddUnderStepsNotes() {
    $('.gvUnderSteps').find("tr[class='tabla_box']").each(
        function () {
            var dv = '<tr> <td colspan="8">' + $(this).find("td:last").html() + '</td> </tr>';
            $(this).after(dv);
            $(this).find("td:last").remove();
        });

    $(".c9Remove").remove();
}

function SetUnderSteps() {
    //Para agregar el div de las notas debajo de los rows
    AddUnderStepsNotes();

    //Para agregar los textbox de "Current" y "Standard" al Header
    SetUnderStepsTextbox();

    //Para agregar al LinkButton el evento que muestra la nota
    AddLnkUnderStepsEvents();
}

function ValidateSaveNewStep() {

    var ddlNewStep = $get('ddlNSSelectStep').selectedIndex;
    var txtNewStep = $.trim($get('txtNSComments').value);

    if (ddlNewStep < 1) {
        CustomDialogMessageEx('Please select a \"New Step\" and try again.', 500, 150, true, 'Required Field');
        return false;
    }
    else if (txtNewStep == '') {
        CustomDialogMessageEx('Please provide a \"Step Comment\" and try again.', 500, 150, true, 'Required Field');
        return false;
    }

    return true;
}

AppendDateDiv = function () {
    $(".datepicker").each(function () {
        var div = "<div class='dvDatePicker'></div>";
        var input = $(this);
        input.parent().append(div);
        $(input.parent().find(".dvDatePicker")).append(input);
    });

    $(".datepickerDOB").each(function () {
        var div = "<div class='dvDatePicker'></div>";
        var input = $(this);
        input.parent().append(div);
        $(input.parent().find(".dvDatePicker")).append(input);
    });

    $(".HFecha").each(function () {
        var div = "<div class='dvDatePicker'></div>";
        var input = $(this);
        input.parent().append(div);
        $(input.parent().find(".dvDatePicker")).append(input);
    });
}

function AppendDatePicker(sender) {
    $(sender).parent().append($('#ui-datepicker-div'));
}

function SetUploadersText() {
    //Person
    var FileName = "";
    var hdnUploadedPDFPathMC = GetElementByClassAndId('hdnUploadedPDFPath', 'MC', 'input[type="text"]');
    var hdnUploadedPDFPathAP = GetElementByClassAndId('hdnUploadedPDFPath', 'AP', 'input[type="text"]');
    var hdnUploadedPDFPathAC = GetElementByClassAndId('hdnUploadedPDFPath', 'AC', 'input[type="text"]');
    var hdnUploadedPDFPathMP = GetElementByClassAndId('hdnUploadedPDFPath', 'MP', 'input[type="text"]');

    if (hdnUploadedPDFPathMC != null) {
        FileName = $(hdnUploadedPDFPathMC).val();
        if (FileName.trim() != "") {
            FileName = "..\\TempFiles\\" + FileName.split("~~")[1];
            setIntervalFileName(FileName, 'MC', 0);
        }
    }

    if (hdnUploadedPDFPathAP != null) {
        FileName = $(hdnUploadedPDFPathAP).val();

        if (FileName.trim() != "") {
            FileName = "..\\TempFiles\\" + FileName.split("~~")[1];
            setIntervalFileName(FileName, 'AP', 0);
        }
    }

    if (hdnUploadedPDFPathAC != null) {
        FileName = $(hdnUploadedPDFPathAC).val();

        if (FileName.trim() != "") {
            FileName = "..\\TempFiles\\" + FileName.split("~~")[1];
            setIntervalFileName(FileName, 'AC', 0);
        }
    }

    if (hdnUploadedPDFPathMP != null) {
        FileName = $(hdnUploadedPDFPathMP).val();

        if (FileName.trim() != "") {
            FileName = "..\\TempFiles\\" + FileName.split("~~")[1];
            setIntervalFileName(FileName, 'MP', 0);
        }
    }

    //Company
    var hdnUploadedPDFPathCompanyMC = GetElementByClassAndId('hdnUploadedPDFPathCompany', 'MC', 'input[type="text"]');
    var hdnUploadedPDFPathCompanyAP = GetElementByClassAndId('hdnUploadedPDFPathCompany', 'AP', 'input[type="text"]');
    var hdnUploadedPDFPathCompanyAC = GetElementByClassAndId('hdnUploadedPDFPathCompany', 'AC', 'input[type="text"]');
    var hdnUploadedPDFPathCompanyMP = GetElementByClassAndId('hdnUploadedPDFPathCompany', 'MP', 'input[type="text"]');

    if (hdnUploadedPDFPathCompanyMC != null) {
        FileName = $(hdnUploadedPDFPathCompanyMC).val();

        if (FileName.trim() != "") {
            FileName = "..\\TempFiles\\" + FileName.split("~~")[1];
            setIntervalFileName(FileName, 'MC', 1);
        }
    }

    if (hdnUploadedPDFPathCompanyAP != null) {

        FileName = $(hdnUploadedPDFPathCompanyAP).val();

        if (FileName.trim() != "") {
            FileName = "..\\TempFiles\\" + FileName.split("~~")[1];
            setIntervalFileName(FileName, 'AP', 1);
        }
    }

    if (hdnUploadedPDFPathCompanyAC != null) {
        FileName = $(hdnUploadedPDFPathCompanyAC).val();

        if (FileName.trim() != "") {
            FileName = "..\\TempFiles\\" + FileName.split("~~")[1];
            setIntervalFileName(FileName, 'AC', 1);
        }
    }

    if (hdnUploadedPDFPathCompanyMP != null) {
        FileName = $(hdnUploadedPDFPathCompanyMP).val();

        if (FileName.trim() != "") {
            FileName = "..\\TempFiles\\" + FileName.split("~~")[1];
            setIntervalFileName(FileName, 'MP', 1);
        }
    }

}

ValidateDates = function (sender, selectedDate) {
    var fecha = new Date();
    var ReturnVal = true;

    if (selectedDate != '') {
        if (!selectedDate.IsDate('mm/dd/yyyy')) {
            $(sender).val("");
            $(sender).focus();
            CustomDialogMessageEx('This is not a valid Date, please try again.', 500, 150, true, 'Invalid Date');
            ReturnVal = false;
        }
        else if ($(sender).attr("id") == 'DOBTxt') {
            var maxDateAttr = $("#DOBTxt").datepicker("option", "maxDate");
            var pDate = $.datepicker._determineDate($("#DOBTxt").data("datepicker"), maxDateAttr, fecha);

            if (selectedDate.ToDate('mm/dd/yyyy') > pDate) {
                $(sender).val("");
                $(sender).focus();
                CustomDialogMessageEx('The age of this contact cannot be less than 3 months, please try again.', 500, 150, true, 'Invalid Date');
                ReturnVal = false;
            }
        }
        else if ($(sender).attr("alt") == 'validateFutureDate') {
            var pDate = (fecha.getMonth() + 1) + "/" + fecha.getDate() + "/" + fecha.getFullYear();

            if (selectedDate.ToDate('mm/dd/yyyy') > pDate.ToDate('mm/dd/yyyy')) {
                $(sender).val("");
                $(sender).focus();
                CustomDialogMessageEx('This date can not Exceed the Current Date, please try again.', 500, 150, true, 'Invalid Date');
                ReturnVal = false;
            }
        }
        else if ($(sender).attr("alt") == 'LimitMinDate') {
            var txtName = $(sender).attr("txtName");
            if (txtName !== '')
                $("#" + txtName).datepicker("option", "minDate", selectedDate);
        }

        return ReturnVal;
    }
}

CalculatePersonalDataDOB = function (sender, selectedDate) {
    if (ValidateDates(sender, selectedDate)) {
        //Current Date Values
        var currentDate = new Date(); //Current Date
        var cY = currentDate.getFullYear(); //Current Year
        var lastDate = new Date().setMonth(currentDate.getMonth() + 5);

        //Birthday Values
        var birthDate = selectedDate.ToDate('mm/dd/yyyy');
        var age = selectedDate.YearDiff('', 'mm/dd/yyyy'); //Age
        var bM = birthDate.getMonth() + 1; //Birthdate Month
        var bD = birthDate.getDate(); //Birthdate Day

        //Current Birthday
        var newDate = (bM + '/' + bD + '/' + cY).ToDate('mm/dd/yyyy');

        var mDiff = (newDate <= lastDate) && (newDate > currentDate);

        if (age != false && age > 0) {
            $("#AgeTxt").val(age);
            $("#NearAgeTxt").val(mDiff ? age + 1 : age);
        }
        else {
            $('datepickerDOB').val(new Date());
            $("#AgeTxt").val(0);
            $("#NearAgeTxt").val(0);
        }
    }
    else {
        $("#AgeTxt").val(0);
        $("#NearAgeTxt").val(0);
    }
}

/* UNDERWRITING CALL BEGIN - Ing. José Mejía*/
SetUCSendEmail = function () {
    var benSendEmail = $('#dvSubProtocolNo').find('[id^=btnUCProtocolSendEmail]');

    benSendEmail.bind('click', UCSendButtonClick);
}

SetUCSendAppointment = function () {
    var btnAppointment = $('#dvSubProtocolNo').find('[id^=btnUCProtocolSavePhone]');

    btnAppointment.bind('click', UCSaveButtonClick);
}

UCSaveButtonClick = function () {
    if ($('#txtUCProtocolDate').val().trim() == '') {
        CustomDialogMessageEx('You must select an Appointment Date, please try again.', 500, 150, true, 'Required Field');
        return false;
    }
    else if ($('#txtUCPhoneCCode').val().trim() == '') {
        CustomDialogMessageEx('You must insert a phone Country Code, please try again.', 500, 150, true, 'Required Field');
        return false;
    }
    else if ($('#txtUCPhoneACode').val().trim() == '') {
        CustomDialogMessageEx('You must insert a phone Area Code, please try again.', 500, 150, true, 'Required Field');
        return false;
    }
    else if ($('#txtUCPhoneNummber').val().trim() == '') {
        CustomDialogMessageEx('You must insert a Phone Number, please try again.', 500, 150, true, 'Required Field');
        return false;
    }

    var phone = $('#txtUCPhoneCCode').val().trim() + '-' + $('#txtUCPhoneACode').val().trim() + '-' + $('#txtUCPhoneNummber').val().trim();

    if ($('#txtUCPhoneExt').val().trim() != '')
        phone = phone + ' EXT:' + $('#txtUCPhoneExt').val().trim();

    $('#hdnProtocolNoDate').val($('#txtUCProtocolDate').val());
    $('#hdnProtocolNoPhone').val(phone);

    $('#BTNSaveNoUCTab').click();
}

UCSendButtonClick = function () {
    if (!ValidateEmail($('#txtUCProtocolEmail').val().trim())) {
        CustomDialogMessageEx('You must specify a valid Email Address, please try again.', 500, 150, true, 'Required Field');
        return false;
    }
    if ($('#txtUCProtocolDate').val().trim() == '') {
        CustomDialogMessageEx('You must select an Appointment Date, please try again.', 500, 150, true, 'Required Field');
        return false;
    }
    $('#hdnProtocolEmail').val($('#txtUCProtocolEmail').val());
    $('#hdnProtocolNoDate').val($('#txtUCProtocolDate').val());

    //Guardo el Comentario actual
    UCSaveComments();
    UCSetTabComments();
    $('#BTNSendUCTab').click();
}

SetUCNextButtons = function () {
    var buttons = $('.cont_underwriting_call').find('[id^=btnUCNext]');

    $(buttons).each(function () {
        $(this).bind('click', UCNextFunction);
    });

    //Setear el boton de Attach Call
    $('#btnUCAttachCall').replaceWith($('#btnUCAttachCallOrig'))
}

SetUCProtocolRadioButtons = function () {
    var radioButtons = $('#dvCallProtocol').find('input[type=radio]');

    $(radioButtons).each(function () {
        $(this).bind('click', UCProtocolYesNo);
    });
}

UCHideAllDivs = function () {
    var divs = $('.cont_underwriting_call').find('[id^=dvCall]');

    $(divs).each(function () {
        $(this).hide();
    });
}

UCUnselectMenuLinks = function () {
    var menuLinks = $('#MenuCasesUnderwritingCall').find('[id^=lnk]');

    $(menuLinks).each(function () {
        $(this).parent().removeClass('active');
    });
}

UCNextFunction = function () {
    //Div actualmente visible
    var dvCurrent = UCGetCurrentDiv();
    //Div Siguiente
    var dvNext = $(dvCurrent).next();

    //Verifico si el paso ya esta cerrado
    var isClosed = $('#hdnUCIsClosed').val().toLowerCase() == 'true';

    //Busco los RadioButtons que contenga el Div Actual
    if (dvCurrent.attr('id').toLowerCase() == 'dvcallprotocol') {
        var radioNo = $(dvCurrent).find('input[type=radio][id*="no"]');

        if ($(radioNo).is(':checked')) {
            CustomDialogMessageEx('You can not advance if the Client does not agree to continue with the call.', 500, 150, true, 'Warning');
            return false;
        }

    }

    BeginRequestHandler();

    if (!isClosed)
        if (UCSaveCallDetails() == false) {
            EndRequestHandler();
            return false;
        }

    //Deselecciono todos los "Tabs"
    UCUnselectMenuLinks();

    //Oculto el Div Actual
    $(dvCurrent).css("display", "none");
    //Muestro el Div Siguiente
    $(dvNext).css("display", "block");

    //Le pongo la clase de "Active" (Css) al "Tab" del Div visible
    var menuLinks = $('#MenuCasesUnderwritingCall').find('[alt=' + dvNext.attr('id') + ']');
    $(menuLinks).parent().attr('class', 'active');

    //Guardo el Tab actualmente seleccionado.
    $('#hfMenuUnderwritingCall').val($(menuLinks).attr('id'));

    //Mostrar el Comentario
    UCShowTabComments();

    EndRequestHandler();
}

UCMenuLinksFunction = function (obj) {
    //Div actualmente visible
    var dvCurrent = UCGetCurrentDiv();

    if (dvCurrent.length < 1)
        return false;


    //Verifico si el paso ya esta cerrado
    var isClosed = $('#hdnUCIsClosed').val().toLowerCase() == 'true';

    //Busco los RadioButtons que contenga el Div Actual
    if (dvCurrent.attr('id').toLowerCase() == 'dvcallprotocol') {
        var radioNo = $(dvCurrent).find('input[type=radio][id*="no"]');

        if ($(radioNo).is(':checked')) {
            CustomDialogMessageEx('You can not advance if the Client does not agree to continue with the call.', 500, 150, true, 'Warning');
            return false;
        }
    }

    BeginRequestHandler();

    if (!isClosed)
        if (UCSaveCallDetails() == false) {
            EndRequestHandler();
            return false;
        }

    //Deselecciono todos los "Tabs"
    UCUnselectMenuLinks();

    //Le pongo la clase de "Active" (Css) al "Tab" seleccionado
    $(obj).parent().attr('class', 'active');

    //Oculto todos los "Divs"
    UCHideAllDivs();

    //Busco y muestro el Div del Tab seleccionado
    var dvName = $('#' + $(obj).attr('alt'));
    $(dvName).css("display", "block");

    //Guardo el Tab actualmente seleccionado.
    $('#hfMenuUnderwritingCall').val($(obj).attr('id'));

    //Mostrar el Comentario
    UCShowTabComments();

    EndRequestHandler();

    return false;
}

UCProtocolYesNo = function () {
    var rbID = $(this).attr('id').toLowerCase();

    if (rbID == "no") {
        $('#dvSubProtocolNo').css("display", "block");
        $('#dvSubProtocolYes').css("display", "none");
        $('#pnlUCSave').css('display', "none");
        $('#pnlUCSend').css('display', "none");
    }
    else {
        $('#dvSubProtocolNo').css("display", "none");
        $('#dvSubProtocolYes').css("display", "block");

        //Verifico si el paso ya esta cerrado
        var isClosed = $('#hdnUCIsClosed').val().toLowerCase() == 'true';
        UCShowSaveButton(isClosed);
    }

    $('#hfUCProtocol').val(rbID);
}

HasCommentCurrentDiv = function (dvCurrent) {
    var result = true;

    //Busco los RadioButtons que contenga el Div Actual
    var radioButtons = $(dvCurrent).find('input[type=radio]');

    if (radioButtons.length > 0) {
        //Si trajo RadioButtons busco el de "Si" o "Afirmativo"
        var radioYes = null;

        if (dvCurrent.attr('id').toLowerCase() == 'dvcallinvestmentprofile')
            radioYes = $(radioButtons).parent().find('[id*="no"]');
        else
            radioYes = $(radioButtons).parent().find('[id*="si"]');

        if (radioYes != null) {
            //Verifico si el RadioButton "Si" esta seleccionado
            if ($(radioYes).is(':checked'))
                //Si el RadioButton esta seleccionado verifico que el TextBox de comentarios no este Vacio
                result = ($('#txtUCComments').val().trim() != "");
        }
    }

    return result;
}

UCGetCurrentDiv = function () {
    var currentDiv = $('#MenuCasesUnderwritingCall').find('[class=active]').find('input[type=submit]').attr('alt');

    return $('#' + currentDiv);
}

UCShowCurrent = function () {
    //Deselecciono todos los "Tabs"
    UCUnselectMenuLinks();

    //Oculto todos los "Divs"
    UCHideAllDivs();

    //Guardo el Tab actualmente seleccionado.
    var currentLnk = $('#' + $('#hfMenuUnderwritingCall').val());

    if (currentLnk.length > 0) {
        currentLnk.parent().attr('class', 'active');

        UCGetCurrentDiv().css("display", "block");

        if (currentLnk.text().toLowerCase() == "protocolo")
            UCShowCurrentProtocol();

        //Mostrar el Comentario
        UCShowTabComments();
    }
}

UCShowCurrentProtocol = function () {
    $('#dvCallProtocol').find('[id=si]').prop("checked", $('#hfUCProtocol').val().toLowerCase() != "no");
    $('#dvCallProtocol').find('[id=no]').prop("checked", $('#hfUCProtocol').val().toLowerCase() == "no");

    if ($('#hfUCProtocol').val().toLowerCase() == "no") {
        $('#dvSubProtocolNo').css("display", "block");
        $('#dvSubProtocolYes').css("display", "none");
    }
    else {
        $('#dvSubProtocolNo').css("display", "none");
        $('#dvSubProtocolYes').css("display", "block");
    }
}

UCCalculateCallingDate = function (sender, selectedDate) {

    selectedDate = selectedDate.substring(0, 10);
    ValidateDates(sender, selectedDate);

    var sDate = selectedDate.ToDate('mm/dd/yyyy');
    var cDate = ((new Date().getMonth() + 1) + "/" + new Date().getDate() + "/" + new Date().getFullYear()).ToDate('mm/dd/yyyy');

    if (sDate < cDate) {
        CustomDialogMessageEx('This date can not be lower than the Current Date, please try again.', 500, 150, true, 'Invalid Date');
        $('#txtUCProtocolDate').datetimepicker('setDate', (new Date()));
        return false;
    }
};

UCShowTabComments = function () {
    //Div actualmente visible
    var dvComment = UCGetCurrentDiv().find('[id*=dvComments]').text();

    $('#txtUCComments').val(dvComment);
}

UCSetTabComments = function () {
    //Comentario a salvar
    var comment = $('#txtUCComments').val();

    //Div actualmente visible
    UCGetCurrentDiv().find('[id*=dvComments]').text(comment);
}

UCSaveQuestions = function () {
    var stepTypeIdVal = $('#hdnUCStepTypeId').val();
    var stepIdVal = $('#hdnUCStepId').val();
    var stepCaseNoVal = $('#hdnUCStepCaseNo').val();
    var policyKey = $('#hdnPKeyJson').val();

    if ($.trim(stepTypeIdVal) != '' && $.trim(stepIdVal) != '' && $.trim(stepCaseNoVal) != '' && $.trim(policyKey) != '') {
        var chekBoxes = $('#dvCallProtocol').find('input[type=checkbox]');

        chekBoxes.each(function () {
            var questionId = $(this).parent().parent().attr('id').split('tr')[1];
            var answer = $(this).prop('checked');

            var r = JSON.stringify({ PolicyKey: policyKey, QuestionId: questionId, Answer: answer, StepTypeId: stepTypeIdVal, StepId: stepIdVal, StepCaseNo: stepCaseNoVal }, null, 2);

            $.ajax({
                type: "POST",
                url: "Case.aspx/SaveUnderCallQuestions",
                data: r,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    result = result.d;
                }
            });
        });
    }
    else {
        return false;
    }
}

UCSaveComments = function () {
    var stepTypeIdVal = $('#hdnUCStepTypeId').val();
    var stepIdVal = $('#hdnUCStepId').val();
    var stepCaseNoVal = $('#hdnUCStepCaseNo').val();

    var commentVal = $('#txtUCComments').val();
    var categoryIdVal = UCGetCurrentDiv().attr('data-categoryid');
    var policyKey = $('#hdnPKeyJson').val();

    if ($.trim(policyKey) != '' && $.trim(categoryIdVal) != '' && $.trim(commentVal) != '' && $.trim(stepTypeIdVal) != '' && $.trim(stepIdVal) != '' && $.trim(stepCaseNoVal) != '' && $.trim(policyKey) != '') {
        var r = JSON.stringify({ PolicyKey: policyKey, Comment: commentVal, CategoryId: categoryIdVal, StepTypeId: stepTypeIdVal, StepId: stepIdVal, StepCaseNo: stepCaseNoVal }, null, 2);

        $.ajax({
            type: "POST",
            url: "Case.aspx/SaveUnderCallComment",
            data: r,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                result = result.d;
            }
        });
    }
    else {
        return false;
    }
}

UCSaveChecks = function () {
    var stepTypeIdVal = $('#hdnUCStepTypeId').val();
    var stepIdVal = $('#hdnUCStepId').val();
    var stepCaseNoVal = $('#hdnUCStepCaseNo').val();
    var categoryIdVal = UCGetCurrentDiv().attr('data-categoryid');
    var policyKey = $('#hdnPKeyJson').val();

    if ($.trim(stepTypeIdVal) != '' && $.trim(stepIdVal) != '' && $.trim(stepCaseNoVal) != '' && $.trim(policyKey) != '' && $.trim(categoryIdVal) != '') {
        var chekBoxes = UCGetCurrentDiv().find('input[type=radio][id*=si]');

        if (chekBoxes.length > 0) {
            var answer = $(chekBoxes).prop('checked');

            var r = JSON.stringify({ PolicyKey: policyKey, TabId: categoryIdVal, Answer: answer, StepTypeId: stepTypeIdVal, StepId: stepIdVal, StepCaseNo: stepCaseNoVal }, null, 2);

            $.ajax({
                type: "POST",
                url: "Case.aspx/SaveUnderCallChecks",
                data: r,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    result = result.d;
                }
            });
        }
    }
    else {
        return false;
    }
}


UCChargeManagerDependency = function () {

    $('#ManagerDDL').change(function () {

        var policyKey = $('#ManagerDDL').val();

        var r = JSON.stringify({ PolicyKey: policyKey }, null, 2);
        var subManagerDllOptions = "<option value='-1'>Select</option>";

        $.ajax({
            type: "POST",
            url: "Case.aspx/ChargeSubManager",
            data: r,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                result = result.d;

                if (result != null) {
                    for (i = 0; i < result.length; ++i) {
                        subManagerDllOptions += "<option value='" + result[i].Value + "'>" + result[i].Text + "</option>"
                    }
                }
                $("#SubManagerDDL option").remove();
                $("#SubManagerDDL").append(subManagerDllOptions);
                $("#SubManagerDDL").val($("#hfSelectedSubManager").val());
            }
        });


    });

    $('#SubManagerDDL').change(function () {
        $("#hfSelectedSubManager").val($("#SubManagerDDL").val());
    });
    //hfSelectedSubManager
}



UCChargeSubManagerDependency = function () {

    $('#SubManagerDDL').change(function () {

        var policyKey = $('#SubManagerDDL').val();

        var r = JSON.stringify({ PolicyKey: policyKey }, null, 2);
        var agentDllOptions = "<option value='-1'>Select</option>";

        $.ajax({
            type: "POST",
            url: "Case.aspx/ChargeAgent",
            data: r,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                result = result.d;

                if (result != null) {
                    for (i = 0; i < result.length; ++i) {
                        subManagerDllOptions += "<option value='" + result[i].Value + "'>" + result[i].Text + "</option>"
                    }
                }
                $("#AgentDDL option").remove();
                $("#AgentDDL").append(agentDllOptions);
                $("#AgentDDL").val($("#hfSelectedAgent").val());
            }
        });


    });

    $('#AgentDDL').change(function () {
        $("#hfSelectedAgent").val($("#AgentDDL").val());
    });
}

UCChargeOfficeDependency = function () {
    $('#OfficeDDL').change(function () {

        var policyKey = $('#OfficeDDL').val();
        if (policyKey != '-1') {

            var r = JSON.stringify({ PolicyKey: policyKey }, null, 2);
            var planDllOptions = "<option value='-1'>Select</option>";
            var managerDllOptions = "<option value='-1'>Select</option>";

            $.ajax({
                type: "POST",
                url: "Case.aspx/ChargeManager",
                data: r,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    result = result.d;

                    if (result != null) {
                        for (i = 0; i < result.length; ++i) {
                            managerDllOptions += "<option value='" + result[i].Value + "'>" + result[i].Text + "</option>"
                        }
                    }
                    $("#ManagerDDL option").remove();
                    $("#ManagerDDL").append(managerDllOptions);
                    $("#ManagerDDL").val($("#hfSelectedManager").val());
                }
            });

        }
    });

    $('#ManagerDDL').change(function () {
        $("#hfSelectedManager").val($("#ManagerDDL").val());
    });

}

UCSetRadioButtons = function () {
    $('.cont_underwriting_call').find('input[type=radio]').each(function () {
        if ($(this).attr('checked') != null)
            $(this).prop('checked', true);
    });
}

UCSetAttachCallRadios = function () {
    var a = 1;

    $('#gvAttachCalls').find('input[type=radio]').each(function () {
        $(this).attr('id', $(this).attr('id') + a);

        $(this).parent().parent().prepend($(this));

        $(this).next().remove();

        $(this).next().attr('for', $(this).attr('id'));
        $(this).attr('name', 'rbtnAttachCallName')
        $(this).click(function () {
            $('#hdnUCAttachSelectedRadio').val($(this).parent().parent().index());
        });

        a++;
    });
}

UCDivideACGrid = function () {
    var trHead = $('#gvAttachCalls').find(".gradient_gris");
    $('#tblAttachCalls').append(trHead);

    $('#gvAttachCalls').find(".gradient_gris").remove();
}

UCSaveCallDetails = function () {
    var dvCurrent = UCGetCurrentDiv();

    if (dvCurrent.attr('id') != "dvCallProtocol") {
        //Valido si existe un comentario, en caso de no tener lanzo una excepción
        if (!HasCommentCurrentDiv(dvCurrent)) {
            CustomDialogMessageEx('You must write a comment before continue, please insert a comment.', 500, 150, true, 'Required Field');
            return false;
        }
    }
    else {
        var chekBoxes = UCGetCurrentDiv().find('input[type=radio][id*=si]');

        if (chekBoxes.length > 0) {
            var answer = $(chekBoxes).prop('checked');

            if (answer == true) {
                var chekBoxes = dvCurrent.find('input[type=checkbox]');

                var counter = 0;

                chekBoxes.each(function () {
                    if ($(this).prop('checked'))
                        counter++;
                });

                if (counter < 3) {
                    CustomDialogMessageEx('The client must answer at least 3 questions to continue, please try again.', 500, 150, true, 'Required Field');
                    return false;
                }
                else {
                    UCSaveQuestions();
                }
            }
        }
    }

    //Guardo el valor de los Radio
    UCSaveChecks();

    //Guardo el Comentario actual
    UCSaveComments();
    UCSetTabComments();

    return true;
}

UCSetReadOnlyItems = function () {
    //Verifico si el paso ya esta cerrado
    var isClosed = $('#hdnUCIsClosed').val().toLowerCase() == 'true';

    dvUnderCall = $('.cont_underwriting_call');

    dvUnderCall.find('input[type=checkbox]').each(function () {
        $(this).prop('disabled', isClosed);
    });

    dvUnderCall.find('input[type=radio]').each(function () {
        $(this).prop('disabled', isClosed);
    });

    $('#txtUCComments').prop("readonly", isClosed);

    UCShowSaveButton(isClosed);
}

UCShowSaveButton = function (closed) {
    if (closed) {
        $('#pnlUCSave').css("display", "none");
        $('#pnlUCSend').css('display', "none");
    }
    else {
        $('#pnlUCSave').css("display", "block");
        $('#pnlUCSend').css('display', "block");
    }
}

UCSaveButton = function () {
    var dvCurrent = UCGetCurrentDiv();

    if (dvCurrent.attr('id').toLowerCase() == 'dvcallprotocol') {
        var radioNo = $(dvCurrent).find('input[type=radio][id*="no"]');

        if ($(radioNo).is(':checked'))
            return false;
    }

    BeginRequestHandler();
    UCSaveCallDetails();
    EndRequestHandler();
    return false;
}

/* UNDERWRITING CALL END - Ing. José Mejía*/

function ClosePaymentPDFPop() {
    $find('popupBhvr').hide();
    return false;
}

PDSetQuestionsRadio = function () {
    $('#gvQuestions').find('li>label').each(function () {
        if ($(this).next().val().toLowerCase() == 'true') {
            $(this).addClass("radioSelect");
            $(this).siblings('span').children('input:radio').attr('checked', 'checked');
        }
        else {
            $(this).removeClass("radioSelect");
            $(this).siblings('span').children('input:radio').removeAttr('checked');
        }
    });
}

//var keyPriority;

function OnCheckBoxClick(sender, index) {
    isImageClicked = true;
    var key = gvCases.keys[index].split('|');

    setPriority(sender, key);
}

function setPriority(obj, key) {

    var corpId = key[0];
    var regionId = key[1];
    var countryId = key[2];
    var domesticregId = key[3];
    var stateProvId = key[4];
    var cityId = key[5];
    var officeId = key[6];
    var caseSeqNo = key[7];
    var histSeqNo = key[8];
    var priority = $(obj).is(":checked");

    var r = JSON.stringify({
        CorpId: corpId, RegionId: regionId,
        CountryId: countryId, DomesticregId: domesticregId,
        StateProvId: stateProvId, CityId: cityId,
        OfficeId: officeId, CaseSeqNo: caseSeqNo,
        HistSeqNo: histSeqNo, Priority: priority
    }, null, 2);

    $.ajax({
        type: "POST",
        url: "~/Case.aspx/SetPriority",
        data: r,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            result = result.d;
        }
    });


}

function validateRequirementPopUp() {
    var result = true;
    if ($("#txtDocumentRequirementComment").val().trim() == "") {
        CustomDialogMessageEx('You must write a comment before continue, please insert a comment.', 500, 150, true, 'Required Field');
        result = false;
    } else if ($("#hdnRequirementUploadedPDFPath").val().trim() == "") {
        CustomDialogMessageEx('Cannot insert empty document.', 500, 150, true, 'Required Document');
        result = false;
    }



    return result;
}

function OnRowClick(s, e) {
    if (isImageClicked) {
        e.cancel = true;
        isImageClicked = false;
    } else {
        $('#hdnSelectedKey').val(s.GetRowKey(e.visibleIndex));
        $('#btnSelectedRow').click();
    }
    //keyPriority = s.GetRowKey(e.visibleIndex);

}

/* POLICY PLAN- Ing. José Mejía*/
function BtnProfileVisiblility(obj) {
    var parentDiv = '#' + $(obj).attr('alt');
    var visible = 'false';

    if ($(obj).val() != "-1")
        visible = $(obj).val().split('|')[1].toLowerCase();

    var btnProfile = $(parentDiv).find('[id=dvBtnPersonalizedProfile]');

    if (visible == 'true')
        $(btnProfile).css("display", "block");
    else
        $(btnProfile).css("display", "none");

    $('#hdnBtnProfile').val(parentDiv + '|' + visible);
}

function ShowHideBtnProfile() {
    if ($('#hdnBtnProfile').val().split('|').length > 1) {
        var parentDiv = $('#hdnBtnProfile').val().split('|')[0];
        var visible = $('#hdnBtnProfile').val().split('|')[1];

        var btnProfile = $(parentDiv).find('[id=dvBtnPersonalizedProfile]');

        if (visible == 'true')
            $(btnProfile).css("display", "block");
        else
            $(btnProfile).css("display", "none");
    }
}

function ShowHideProfilePop() {
    hdnVisiblePopProfile
}

function PPCalcTotalPercent() {
    var totalPercent = 0.00;

    $('.PDPercentage').each(function () {
        totalPercent += parseFloat($(this).val());
    });

    return totalPercent.toFixed(2);
}

function SetPPTotalPercent(obj) {
    if (PPCalcTotalPercent() > 100) {
        $(obj).focus();
        $(obj).val('0.00');
        CustomDialogMessageEx('Error: Total Percentage can\'t be greater than 100%.', 500, 150, true, 'Invalid Value');
    }

    $('#txtPPTotalPercent').val(PPCalcTotalPercent() + '%');
}

function ValidatePerProfileTotal() {
    var returnVal = true;

    if (PPCalcTotalPercent() != 100) {
        returnVal = false;
        CustomDialogMessageEx('Error: Total Percentage must be 100%.', 500, 150, true, 'Invalid Value');
    }

    return returnVal;
}

SetCompleteDropPosition = function () {
    $('#ddlPopNRiskReason_DDD_PW-1').appendTo('body');
    var offset = $('#ddlPopNRiskReason').offset();

    $('#ddlPopNRiskReason_DDD_PW-1').offset({ top: offset.top + $('#ddlPopNRiskReason').height(), left: offset.left })
}

ValidateNewRisk = function () {
    var returnVal = true;
    var lStr_MsjError = '';

    //Bmarroquin 03-04-2017 Validar los campos necesarios 
    if ($('#ddlPopNRiderType option:selected').index() < 1) {
        lStr_MsjError = 'You must select a Rider Type, please try again. <br>';
        returnVal = false;
    }

    if ($('#ddlPopNRiskType option:selected').index() < 1) {
        lStr_MsjError += 'You must select a Risk Type, please try again.<br>';
        returnVal = false;
    }

    if ($('#ddlPopNRiskCategory option:selected').index() < 1) {
        lStr_MsjError += 'You must select a Risk Category, please try again.<br>';
        returnVal = false;
    }

    //Si los dos estan vacios mandar msj porq uno debe ingrarse!!
    //Bmarroquin  07-03-2017 cambio dado q ahora el text Box debe ser un DropDownList
    //($('#txtPopNRiskTableRating').val() === undefined || $('#txtPopNRiskTableRating').val().length == 0)    
    if (($('#ddlTableRatingRisk option:selected').index() < 1) && ($('#txtPopNRiskPerThousand').val() === undefined || $('#txtPopNRiskPerThousand').val().length == 0)) {
        lStr_MsjError += 'You must Enter a Per Thousand Or Table Rating value, please try again.<br>';
        returnVal = false;
    }

    if (lStr_MsjError != '')
        CustomDialogMessageEx(lStr_MsjError, 500, 170, true, 'Required Fields');

    return returnVal;
}

ValidateNewCredit = function () {

    var returnVal = true;

    if ($('#ddlCreditType').val() == "-1") {

        CustomDialogMessageEx('You must select a Credit Type.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#ddlCreditType').focus();

    }
    else if ($('#ddlCredit').val() == "-1") {

        CustomDialogMessageEx('You must select a Credit.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#ddlCredit').focus();

    } else if ($('#ddlReason').val() == "-1") {

        CustomDialogMessageEx('You must select a Reason.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#ddlReason').focus();

    } else if ($('#txtCreditComment').val().trim() == '') {

        CustomDialogMessageEx('You must specify the Credit Comment.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#txtCreditComment').focus();

    }

    return returnVal;
}

ValidateNewExclusion = function () {

    var returnVal = true;

    if ($('#ddlNEExclusionType').val() == "-1") {

        CustomDialogMessageEx('You must select a Exclusion Type.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#ddlNEExclusionType').focus();

    } else if ($('#ddlNEExclusion').val() == "-1") {

        CustomDialogMessageEx('You must select a Exclusion.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#ddlNEExclusion').focus();

    } else if ($('#ddlNERequestedBy').val() == "-1") {

        CustomDialogMessageEx('You must select a Requested By.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#ddlNERequestedBy').focus();

    }

    else if ($('#txtNEExclusionComment').val().trim() == '') {

        CustomDialogMessageEx('You must specify the Exclusion Comment.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#txtNEExclusionComment').focus();

    }

    return returnVal;
}

ValidateTerminateExclusion = function () {
    var returnVal = true;


    if ($('#txtNotificationDateTerminateExclusion').val().trim() == '') {

        CustomDialogMessageEx('You must specify the Notification Date.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#txtNotificationDateTerminateExclusion').focus();

    } else if ($('#txtEndDateTerminateExclusion').val().trim() == '') {

        CustomDialogMessageEx('You must specify the End Date.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#txtEndDateTerminateExclusion').focus();

    } else if ($('#txtTerminateExclusionComment').val().trim() == '') {

        CustomDialogMessageEx('You must specify a Comment.', 500, 150, true, 'Required Field');
        returnVal = false;
        $('#txtTerminateExclusionComment').focus();

    } else if ($('#txtEndDateTerminateExclusion').val().ToDate('mm/dd/yyyy') < $('#txtNotificationDateTerminateExclusion').val().ToDate('mm/dd/yyyy')) {

        CustomDialogMessageEx('The End Date must be greater than Notification Date.', 500, 150, true, 'Invalid Value');
        returnVal = false;
        $('#txtEndDateTerminateExclusion').focus();

    }


    return returnVal;
}

EnableRatingDDL = function (obj) {
    if (($('#ddlPopNRiskReason option:selected').index() > 0 && $('#ddlPopNRiskReason option').length > 0) || $('#gvPopNRisks').find('tr').not('.gradient_azul').length > 1) {
        var objName = '#' + $(obj).next().attr('alt');

        $(objName).prop('disabled', !$(obj).is(":checked"));

        $('.cont_risk_popup').find('input:radio').each(function () {
            if ($(this).attr('id') != $(obj).attr('id')) {
                var objName = '#' + $(this).next().attr('alt');
                $(objName).prop('disabled', true);
            }
        });
    }
    else {
        $('.cont_risk_popup').find('input:radio').each(function () {
            $(this).prop("checked", false);
        });
    }
}

ShowTeamCommunicationPopUp = function () {
    $("#hfTeamCommunicationPopUp").val("true");
}

function comentario_steps(id) {
    if (document.getElementById) { //se obtiene el id
        var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
        el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
    }
}

function changeCommunicationTeamTab() {
    var isValid = validateTeamCommunicationsCommentNew();
    if (isValid) {
        $("#liNewMessageTab").removeClass("TabbedPanelsTabSelected");
        $("#liMessageTab").addClass("TabbedPanelsTabSelected");
    }

    return isValid;
}

function SetUnderTeamCommunicationDiv() {

    //Para agregar el div debajo de los rows
    AddUnderTeamCommunications();
    //Para abrir el div cuando se haga click en el enlace 
    AddDvUnderTeamCommunicationGrid();

}

function openCurrentTeamCommunicationTabs() {

    var currentTabs = $("#hdnIndexGvTeamCommunication").val();
    if (currentTabs.trim() != "") {
        var tabs = currentTabs.split(',');

        for (var i = 0; i < tabs.length; i++)
            ShowHideUnderTeamCommunications(tabs[i]);
    }
}

function AddDvUnderTeamCommunicationGrid() {
    var listLnk = $('.gvTeamComunication').find("a[id='lnkNoteNameTeamCommunication']");
    var listDiv = $('.gvTeamComunication').find("div[id='dvMessageCommunication']");

    for (var i = 0; i < listLnk.length; i++) {
        $(listDiv[i]).attr("id", $(listDiv[i]).attr("id") + i);
        $(listLnk[i]).attr("onclick", "return ShowHideUnderTeamCommunications(\"" + $(listDiv[i]).attr("id") + "\")");
    }
}

function takeVisibleRows(obj) {

    //Crear un array
    var dvVisibles = [];

    $('.gvTeamComunication').find("div[class='cont_message']").find("[id*='dvMessageCommunication']").each(function () {

        var isVisible = $(this).css("display") == "block";

        if (isVisible) {
            dvVisibles.push($(this).attr("id"));
        }
    });

    $("#hdnIndexGvTeamCommunication").val(dvVisibles.join(","));
}

//Para agregar el div de las notas debajo de los rows
function AddUnderTeamCommunications() {
    $('.gvTeamComunication').find("tr[class='tabla_box']").each(
        function () {
            var dv = '<tr> <td class="bgBL" colspan="4">' + $(this).find("td:last").html() + '</td> </tr>';
            $(this).after(dv);
            $(this).find("td:last").remove();
        });

    $(".c9Remove").remove();
}


function CloseTeamCommunicationsPop() {

    $("#hfTeamCommunicationPopUp").val("false");
    $("#txtSubject").val("");
    $("#txtMessage").val("");
    $("#hdnIndexGvTeamCommunication").val("");
    $("#dvTeamCommunication").dialog("close");
    return false;
}

function validateTeamCommunicationsCommentNew() {

    var result = true;
    if ($("#txtTMSubject").val().trim() == "") {
        CustomDialogMessageEx('You must specify the Subject.', 500, 150, true, 'Required Field');
        $('#txtTMSubject').focus();
        result = false;
    } else if ($("#txtTMMessage").val().trim() == "") {
        CustomDialogMessageEx('You must specify a Message.', 500, 150, true, 'Required Field');
        $('#txtTMMessage').focus();
        result = false;
    }



    return result;

}

function validateTeamCommunicationsCommentThread(obj) {
    var result = true;

    var txtMessageThread = $(obj).parent().parent().parent().find("div").find("textarea");


    if (txtMessageThread.val().trim() == "") {
        CustomDialogMessageEx('You must specify a Message.', 500, 150, true, 'Required Field');
        txtMessageThread.focus();
        result = false;
    }



    return result;

}


function ShowHideUnderTeamCommunications(dvId) {
    var dv = $("#" + dvId);

    if (dv.length > 0)
        dv.toggle();


    takeVisibleRows(dv);

    return (dv.css("display") == "block");

}

ShowReplyAccordeon = function () {
    var liList = $("#pnRightControl .accordion_tabulado > ul > li > a");

    $(liList).attr("id", "");
    $(liList[1]).attr('id', 'current');

    $(ObjAcordeon).accordion({ initShow: "#current" });

    $('#hfRightAccordeon').val('acc4|1');
}

function SRUploadFileComplete(sender, event) {
    var obj = JSON.parse(event.callbackData);
    if (obj.file == "")
        showAlert(obj.error);
    else {
        var FileName = obj.file.split("~~")[1];
        $('#hdnSRUploadedFile').val(obj.file);

        FileName = "..\\TempFiles\\" + FileName;

        //Set Textbox File Name
        var myVar = setInterval(function () {
            $('#Right_Right_UCPopSentToReinsurance1_fuSRUploadFile_TextBox0_FakeInput').val(FileName);
            clearInterval(myVar);
        }, 100);
    }
}

SRAttachDocClick = function () {
    var checked = false;

    $('#gvSRPolicyDocument').find('input[type=checkbox]').each(
        function () {
            if ($(this).prop('checked')) {
                checked = true;
            }
        });

    if (!checked)
        CustomDialogMessageEx('Please select a document from the grid above.', 500, 150, true, 'No Attachment Selected');

    return checked;
}

SRSendEmailClick = function () {
    var returnVal = true;

    if ($('#txtSRSendRecipients').val().trim() == '') {
        CustomDialogMessageEx('You must specify an Email Recipient, please try again.', 500, 150, true, 'Required Field');
        returnVal = false;
    }
        /*
	else if (!ValidateEmail($('#txtSRSendRecipients').val().trim()))
	{
		CustomDialogMessageEx('You must specify a Valid Email, please try again.', 500, 150, true, 'Invalid Value');
		returnVal = false;
	}*/

    else if ($('#txtSRSendSubject').val().trim() == '') {
        CustomDialogMessageEx('You must specify an Email Subject, please try again.', 500, 150, true, 'Required Field');
        returnVal = false;
    }
    else if ($('#txtSRSendEmail').val().trim() == '') {
        CustomDialogMessageEx('Email Body cant be empty, please try again.', 500, 150, true, 'Required Field');
        returnVal = false;
    }

    //Bmarroquin 16-05-2017 mejora validar una lista de correos por separado..
    var lArrStrValues = $('#txtSRSendRecipients').val().trim().split(",");
    if (lArrStrValues.length > 0) {
        var lBool_Invalid = false;
        for (var i = 0; i <= lArrStrValues.length - 1; i++) {
            if (!ValidateEmail(lArrStrValues[i]))
                lBool_Invalid = true;
        }

        if (lBool_Invalid) {
            CustomDialogMessageEx('You must specify a Valid Email, please try again.', 500, 150, true, 'Invalid Value');
            returnVal = false;
        }
    }
    //Fin Bmarroquin 16-05-2017

    return returnVal;
}

CloseJqueryPops = function (Id) {
    $("body").find("button[class*='ui-button']").click();
};

/* POLICY PLAN- Ing. José Mejía*/

function FillManagersDropDown() {
    $("select[id$='ManagerDDL']:first").change(function () {
        $("select[id$='SubManagerDDL']:first").find('option').remove();
        $.ajax({
            url: 'Case.aspx/GetSubManagers',
            type: 'POST',
            datatype: 'json',
            contentType: "application/json; charset=utf-8",
            data: "{Id:" + $(this).val() + "}",
            success: function (data) {
                $.each(data.d, function (index, item) {
                    $("select[id$='SubManagerDDL']:first")
                        .get(0).options[$("select[id$='SubManagerDDL']:first")
                        .get(0).options.length] = new Option(item.Text, item.Value);
                });
            }
        });
    });
};

function ValidateSearchField() {

    var dateFromTxt = $('#dateFromTxt').val();
    var dateToTxt = $('#dateToTxt').val();
    var txtSearchByPolicy = $('#txtSearchByPolicy').val();
    var txtClient = $('#txtClient').val();
    var OfficeDDL = $('#OfficeDDL').val();
    var PlanNameDDL = $('#PlanNameDDL').val();
    var ManagerDDL = $('#ManagerDDL').val();
    var UnderWriterDDL = $('#UnderWriterDDL').val();
    var SubManagerDDL = $('#SubManagerDDL').val();
    var AgentDDL = $('#AgentDDL').val();

    if (dateFromTxt.trim() == "" &
        dateToTxt.trim() == "" &
        txtSearchByPolicy.trim() == "" &
        txtClient.trim() == "" &
        OfficeDDL.trim() == "-1" &
       (PlanNameDDL == null || PlanNameDDL.trim() == "-1") &
        (ManagerDDL == null || ManagerDDL.trim() == "-1") &
        (UnderWriterDDL == null || UnderWriterDDL.trim() == "-1") &
        (SubManagerDDL == null || SubManagerDDL.trim() == "-1") &
       (AgentDDL == null || AgentDDL.trim() == "-1")
        ) {


        CustomDialogMessageEx('You must specify at least one search option.', 500, 150, true, 'Required Field');
        return false;


    } else {

        return true;
    }


}

function CitiesDropDown() {
    $("select[id$='CountryDDL']:first").change(function () {
        $("select[id$='CityDDL']:first").find('option').remove();
        $.ajax({
            url: '~/Case.aspx/GetCities',
            type: 'POST',
            datatype: 'json',
            contentType: "application/json; charset=utf-8",
            data: "{ComposeId:" + $(this).val() + "}",
            success: function (data) {
                $.each(data.d, function (index, item) {
                    $("select[id$='CityDDL']:first")
                        .get(0).options[$("select[id$='CityDDL']:first")
                        .get(0).options.length] = new Option(item.Text, item.Value);
                });
            }
        });
    });
};

EntityTypeVisible = function () {
    var visible = $('#hdnProductFamily').val().toLowerCase() != 'funeral';
    var visibleAttr = visible ? 'block' : 'none';
    $('.dvBeneficiarieEntity').css('display', visibleAttr);
    $('.dvQuestions').css('display', visibleAttr);
    $('.dvRelationShip').css('display', visibleAttr);
    $('.dvPaymentEntity').css('visibility', visibleAttr);
    $('.dvEntityExtraPremium').css('display', visibleAttr);

    if (!visible)
        $('.dvEntityExtraPremiumColumn').css('display', visibleAttr);
    else
        $('.dvEntityExtraPremiumColumn').removeAttr("style");

};



CalculateMonthly = function (obj, txt) {
    var value = $(obj).val();
    var txtValue = (parseFloat(value.replace(/,/g, '')) / 12).toFixed(2);
    $(txt).val(txtValue);
    $(txt).attr("alt", "decimal-us").setMask();
}


GoOutGrids = function () {
    ViewTabs();
    BeginRequestHandler();
    var button = $("#hfMenuCasesAllCases").val();
    var lnk = $("#lnk" + button);
    var href = lnk.attr('href');
    eval(href);
}


///BackgroundCheck Link

var BackgroundCheckLink = {
    ValidateURLEntry: function () {

        if ($("#txtURL").val() == "") {
            $("#txtURL").focus();
            CustomDialogMessageEx('You must specify an URL, please try again.', 500, 150, true, "Empty URL");
            return false;
        } else
            return (ValidateURL($("#txtURL").val()));
    },
    ShowPopupSearch: function () {

        var fullname = $('#SummaryFirstNameTxt').val() + ' ' + $('#SummaryMiddleNameTxt').val() + ' ' + $('#SummaryLastNameTxt').val() + ' ' + $('#SummarySecondLastNameTxt').val();

        window.open("https://www.google.com/search?q=" + fullname);
    }
}