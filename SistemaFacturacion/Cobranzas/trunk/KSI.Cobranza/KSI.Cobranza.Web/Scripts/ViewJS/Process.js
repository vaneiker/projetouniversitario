$(document).ready(function () {
    HideHeaderGrid();
    $('.myrow').click(function () {
        var datos = $(this).attr('data-json');
        if (datos.length <= 0) {
            return;
        }
        var row = JSON.parse(datos);

        $('#PolicyType').val(row.policyTypeName);
        $('#Aseguradora').val(row.FullName);
        $('#PolicyNo').val(row.policyNo);
        $('#PolicyAmount').val(number_format(row.endorseAmount, 2));

        $('#PolicyDescripcion').val(row.policyCollateralName);
        $('#PolicyEstado').val(row.isActive == 1 ? 'Activo' : 'Inactivo');

        var dFormat = "dd/mm/yyyy";
        var PolicyDate = new Date(row.Date);
        $('#PolicyDate').val(PolicyDate.format(dFormat));

        var EffectiveDate = new Date(row.EffectiveDate);
        $('#EffectiveDate').val(EffectiveDate.format(dFormat));
    });

    $(document).on('click', '#ApplyFilters', function () {
        var filters = [];
        var $dvReceipOfPayment = $('#dvReceipOfPayment');
        var controls = $dvReceipOfPayment.find('input[type="checkbox"]:checked');

        controls.each(function () {
            var $this = $(this);

            filters.push($this.val());

        })

        if (filters.length > 0) {
            GetQuotaInformationGrid(filters, $('#hdnAccountId').val());
            //GetDataFilterReceipOfPayment(filters, $('#hdnAccountId').val());
        }
    });


    $(document).on('change', '#ProjectedFilterBy', function () {
        var $this = $(this);
        if ($this.val() != null && ($this.val() == 4 || $this.val() == 5)) {
            $('#ProjectedAmountToPay').removeAttr('disabled');
        } else {
            $('#ProjectedAmountToPay').prop('disabled', 'disabled');
            $('#ProjectedAmountToPay').val('');
        }
    });

    $(document).on('click', '#ProjectedApplyFilters', function () {
        var ProjectedAmountToPay = parseFloat($('#ProjectedAmountToPay').val() == '' ? 0 : $('#ProjectedAmountToPay').val());
        var ProjectedFilterBy = $('#ProjectedFilterBy').val();
        var $hdnAccountId = $('#hdnAccountId');
        var FilterDateProjected = $('#FilterDateProjected').val();
        var totalAmount = parseFloat($('#OutStandingBalance').val().replace(',', ''));//saldo total

        if (ProjectedFilterBy == '') {
            ShowMessageBS("Debe seleccionar el tipo de filtro", "Filtrar datos");
            return false;
        }
        else if (FilterDateProjected == '') {
            ShowMessageBS("Debe indicar la fecha a la que desea visualizar los datos", "Filtrar datos");
            return false;
        }
        else if ((ProjectedFilterBy == 4 || ProjectedFilterBy == 5) && (ProjectedAmountToPay == '' || ProjectedAmountToPay <= 0)) {
            ShowMessageBS("Debe indicar el monto a pagar antes de aplicar los filtros", "Filtrar datos");
            return false;
        }
        else if ((ProjectedFilterBy == 4 || ProjectedFilterBy == 5) && ProjectedAmountToPay > totalAmount) {
            ShowMessageBS("El monto a pagar no puede ser mayor que el saldo actual", "Filtrar datos");
            return false;
        }
        else {
            GetProjectedGridStatement($hdnAccountId.val(), FilterDateProjected, ProjectedFilterBy, ProjectedAmountToPay);
        }
    });

    SetDatePicker();
});

function GetProjectStatement(accountId, dateStatement, idTipo, montoPago, CallBack) {
    CallAjax('/Process/GetProjectStatement', JSON.stringify({ accountId: accountId, dateStatement: dateStatement, idTipo: idTipo, montoPago: montoPago }), "json", function (data) {
        CallBack(data);
    }, "POST", true);
}

function MailInformationSection() {
    var $dvMailInformation = $("#dvMailInformation");
    $dvMailInformation.find("input:checkbox").click(function () {
        var $this = $(this);
        var $txt = $($this.parents().eq(1)).find("input:text");
        if ($this.prop("checked"))
            $txt.removeAttr("disabled");
        else {
            $txt.attr("disabled", "disabled");
            $txt.removeClass("input-validation-error");
        }
    });
}

function UploadFile() {
    var templateId = $("#SelectedTemplateId").val();
    var accountId = $("#accountId").val();
    var templateSentId = $("#templateSentId").val();

    var result = (templateId != "" && accountId != "" && templateSentId != "") ? CanUploadFile(templateId, accountId, templateSentId) : true;

    if (result)
        $('#frmLoadFile').submit();

    return result;
}

function CanUploadFile(templateId, accountId, templateSentId) {

    var result = true;
    var QuantityFiles = 5;
    var messages = [];
    CallAjax("/Process/CanUploadFile", JSON.stringify({ templateId: templateId, accountId: accountId, templateSentId: templateSentId }), "json", function (data) {
        result = data.CanUpload;
        QuantityFiles = data.TotalFilesUpload;
        messages = data.Messages;
    }, "POST", false);

    if (!result) {
        var Messages = "";
        for (var i = 0; i < messages.length; i++) {
            Messages += (i + 1) + ".-" + messages[i] + "<br>";
        }
        ShowMessageBS(Messages);
    }

    return result;
}

function HideHeaderGrid() {
    var $GridDetail = $("#gvGuaranteesVehiclesDetail");
    $GridDetail.find("thead").remove();
}

function InitVehicles() {
    var $Grid = $("#gvGuaranteesVehicles");
    var $rows = $Grid.find("tbody").find("tr");

    $rows.on({
        click: function () {
            var $row = $(this);
            var $hidden = $row.find("input:hidden");
            GetGuaranteeVehicleDetail($hidden.val());
        },
        mouseover: function () {
            var $row = $(this);
            $row.css("cursor", "pointer");
        }
    });

    HideHeaderGrid();

}

function GetPhones(CustId) {
    GetPartialView("/Process/_ContactPhone", JSON.stringify({ CustomerId: CustId }), function (data) {
        var $Container = $("#dvPhones");
        $Container.html(data);
        var lnkBase = $("#hdnURLBase").val();
        $("#gvPhones tfoot a").each(function () {
            var $this = $(this);
            $this.attr("href", lnkBase + $this.text())
        });
    }, true);
}

function GetProjectedStatement(accountId) {
    GetPartialView("/Process/_ProjectedStatement", JSON.stringify({ accountId: accountId }), function (data) {
        var $Container = $("#dvProjectedStatement");
        $Container.html(data);
        SetDatePicker();
    }, true);
}

function GetProjectedGridStatement(accountId, dateStatement, idTipo, pMontoPago) {
    GetPartialView("/Process/_GridProjectedStatement", JSON.stringify({ accountId: accountId, dateStatement: dateStatement, idTipo: idTipo, montoPago: pMontoPago }), function (data) {
        var $Container = $("#dvGridProjectedStatement");
        $Container.html(data);
        $('#OutStandingBalance').val($('#hdnTotalCalculate').val());
    }, true);

}

function GetEmails(CustId) {
    GetPartialView("/Process/_ContactEmailAddress", JSON.stringify({ CustomerId: CustId }), function (data) {
        var $Container = $("#dvEmails")
        $Container.html(data);
        var lnkBase = $("#hdnURLBase").val();

        $("#gvEmails tfoot a").each(function () {
            var $this = $(this);
            $this.attr("href", lnkBase + $this.text())
        });
    }, true);
}

function CheckPrimary(CustId, Id) {
    CallAjax("/Process/CheckPrimaryPhone", { CustomerId: CustId, Id: Id }, "", function (data) {
        GetPhones(CustId);
    }, "GET", true);
}

function CheckPrimaryEmail(CustId, Id) {
    CallAjax("/Process/CheckPrimaryEmail", { CustomerId: CustId, Id: Id }, "", function (data) {
        GetEmails(CustId);
    }, "GET", true);
}

function GetGuarantee(AccountId, ViewName) {
    GetPartialView("/Process/" + ViewName, JSON.stringify({ AccountId: AccountId }), function (data) {
        var ContainerId = ViewName == "_GuaranteeList" ? "#dvGuarantee" : "#dvVehicles";
        var $Container = $(ContainerId);
        $Container.html(data);

        if (ViewName == "_VehicleInformation") {
            InitVehicles();
            var $RowClick = $("#gvGuaranteesVehicles tbody tr:first");
            try {
                $($RowClick).click();
            } catch (e) {

            }
        }
    }, true);
}

function GetGuaranteeVehicleDetail(CollateralId) {
    GetPartialView("/Process/_VehicleDetail", JSON.stringify({ CollateralId: CollateralId }), function (data) {
        var ContainerId = "#dvVehicleDetail";
        var $Container = $(ContainerId);
        $Container.html(data);
        HideHeaderGrid();
    }, true);
}

function GetLoanDetail(quotationId, loanNumber, accountId) {
    GetPartialView("/Process/_LoanInformation", JSON.stringify({ quotationId: quotationId, loanNumber: loanNumber, accountId: accountId }), function (data) {
        var $Container = $("#dvLoanInformation")
        $Container.html(data);
    }, true);
}

function CancelSentTemplate(AccountId, CustomerId) {
    ModalConfirm(null, function () {
        GetCorrespondencesView(AccountId, CustomerId)
    }, null);
}

function doSubmitTemplate() {
    ModalConfirm(null, function () {
        $('#frmCorrenpondences').submit();
    }, null);
    return false;
}

function GetCodeudor(AccountId) {
    GetPartialView("/Process/_CodeudorInformation", JSON.stringify({ AccountId: AccountId }), function (data) {
        var $Container = $("#dvCodeudorInformation")
        $Container.html(data);
    }, true);
}

function GetPaymentPlan(AccountId) {
    GetPartialView("/Process/_PaymentPlan", JSON.stringify({ AccountId: AccountId }), function (data) {
        var $Container = $("#dvPaymentPlan")
        $Container.html(data);
        InitGridPlanPago();
    }, true);
}

function GetPolicyInformation(AccountId) {
    GetPartialView("/Process/_PolicyInformation", JSON.stringify({ AccountId: AccountId }), function (data) {
        var $Container = $("#dvPolicyInformation")
        $Container.html(data);
    }, true);
}

function InitGridPlanPago() {
    var $grid = $("#gvPaymentPlan");
    var $foot = $grid.find("tfoot");
    var accountId = $("#hdnAccountId").val();
    $foot.find("a").each(function () {
        var $this = $(this);
        var Originalhref = $this.attr("href");
        var Targethref = Originalhref + "&AccountId=" + accountId;
        $this.attr("href", Targethref);
    });

    InitializeGrid($grid);
}

function GetCodeudorPersonalInformation(Id) {
    GetPartialView("/Process/GetCodeudorPersonalInformation", JSON.stringify({ Id: Id }), function (data) {
        ShowPopupBS(data, "Codeudor", null);
    }, true);
}

function GetPhoneView(Id) {
    GetPartialView("/Process/_frmPhone", JSON.stringify({ Id: Id }), function (data) {
        ShowPopupBS(data, "AGREGAR TELEFONO", null);
        SetMask();
        $.validator.unobtrusive.parse($("#dvContainerPhone"));
        $('#IsActive').prop('checked', true);
    }, true);
}

function GetPaymentProcessView(Id, Account) {
    GetPartialView("/Process/_PaymentProcess", JSON.stringify({ AccountId: Id, Account: Account }), function (data) {
        ShowPopupBS(data, "PROCESAR PAGO", null);
        SetMask();
        $.validator.unobtrusive.parse($("#dvContainerPaymentProcess"));
        SetCboEventHandlerYears();
    }, true);
}

function GetTemplateView(dataTemplate) {
    var $dvTemplates = $("#dvTemplates");
    $dvTemplates.find("#SelectedTemplateId").val(dataTemplate.TemplateId);
    $("#templateId").val(dataTemplate.TemplateId);
    GetPartialView("/Process/_GetPartialTemplate", JSON.stringify({ PartialViewName: dataTemplate.PartialViewName }), function (data) {
        var $Container = $("#dvTemplateContainer");
        $Container.html(data);
        SetMask();
        RemoveInputAutoComplete();
        SetDatePicker();
        if (dataTemplate.PartialViewName == "STMPROJECTADO") {
            $Container.find("#ProjectedFilterBy").change(function () {
                var $this = $(this);
                var $hdnThTemplateSelected = $dvTemplates.find("#hdnThTemplateSelected");

                switch ($this.val()) {
                    case "1":
                        $hdnThTemplateSelected.val('COBCartaDeSaldoCuotas');
                        break;
                    case "3":
                        $hdnThTemplateSelected.val('COBCartaDeSaldoCuotas');
                        break;
                    case "4":
                        ShowMessageBS("Esta funcion aun no esta activa", "Aviso", function () {
                            $this.val("");
                        });
                        return false;
                        break;
                }

                if ($this.val() == "4") {
                    $("#txtMontoAPagar").removeAttr("disabled");
                } else {
                    var $txtMontoAPagar = $("#txtMontoAPagar");
                    $txtMontoAPagar.attr("disabled", "disabled");
                    $txtMontoAPagar.val("");
                }
            });
        }
    }, true);
}

function validateGenerateTemplate() {
    return false;
}

function GetEmailView(Id) {
    GetPartialView("/Process/_frmEmail", JSON.stringify({ Id: Id }), function (data) {
        ShowPopupBS(data, "AGREGAR CORREO", null);
        SetMask();
        $.validator.unobtrusive.parse($("#dvContainerEmail"));
        $('#IsActive').prop('checked', true);
    }, true);
}

function GetQuotaInformation(AccountId) {
    GetPartialView("/Process/_ReceipOfPayment", JSON.stringify({ AccountId: AccountId }), function (data) {
        var $Container = $("#dvReceipOfPayment")
        $Container.html(data);
        RemoveInputAutoComplete();
        InitQuotaInformation();
        InitGridReceiptOfPayment();
    }, true);
}

function GetQuotaInformationGrid(pFilters, AccountId) {
    GetPartialView("/Process/_GridReceipOfPayment", JSON.stringify({ AccountId: AccountId, filters: pFilters }), function (data) {
        var $Container = $("#dvReceipOfPayment");
        $Container.html(data);
        RemoveInputAutoComplete();
        InitQuotaInformation();
        InitGridReceiptOfPayment();
        if (pFilters == null)
            $('#filterAll').prop('checked', true);

    }, true);
}

function InitGridReceiptOfPayment() {
    var $grid = $("#gvReceipOfPayment");
    var $foot = $grid.find("tfoot");
    var accountId = $("#hdnAccountId").val();
    $foot.find("a").each(function () {
        var $this = $(this);
        var Originalhref = $this.attr("href");
        var Targethref = Originalhref + "&AccountId=" + accountId;
        $this.attr("href", Targethref);
    });

    InitializeGrid($grid);
}

function InitQuotaInformation() {
    var $Grid = $("#gvReceipOfPayment");
    var $rows = $Grid.find("tbody").find("tr");

    $rows.on({
        click: function () {
            BeginRequestHandler();
            var $row = $(this);
            var $hidden = $row.find("input:hidden");
            var row = JSON.parse($hidden.val());

            ////Header
            //$('#NoCuenta').val(row.accountId);
            //$('#loanNumber').val(row.loanNumber);
            //$('#LoanStatusName').val(row.LoanStatusName);
            //$('#AccountName').val(row.fullName);

            //Columna Monto
            $('#CapitalMonto').html(number_format(row.capitalAmount, 2));
            $('#MontoInteres').html(number_format(row.interestAmoint, 2));
            $('#MontoComision').html(number_format(row.commissionAmount, 2));
            $('#MontoGastos').html(number_format(row.expenseAmount, 2));
            $('#MontoMora').html(number_format(row.rateLateAmount, 2));
            $('#MontoCargo').html(number_format(row.chargesPrepayment, 2));

            //Columna Saldo
            $('#CapitalSaldo').html(number_format(row.capitalBalance, 2));
            $('#SaldoInteres').html(number_format(row.interestBalance, 2));
            $('#SaldoComision').html(number_format(row.commissionBalance, 2));
            $('#GastosSaldo').html(number_format(row.expenseBalance, 2));
            $('#MoraSaldo').html(number_format(row.rateLateBalance, 2));
            $('#CargoSaldo').html(number_format(row.chargesPrepaymentBalance, 2));

            //Columna Señal
            $('#SenalCapital').html(row.transactionReasonName);
            $('#SenalInteres').html(row.transactionReasonName);
            $('#SenalComision').html(row.transactionReasonName);
            $('#SenalGastos').html(row.transactionReasonName);
            $('#SenalMora').html(row.transactionReasonName);
            $('#SenalCargo').html(row.transactionReasonName);


            //Columna Fecha Ult. Pago
            var dFormat = "dd/mm/yyyy";
            if (row.dCapital != null) {
                var dCapital = new Date(row.dCapital);

                $('#FechaUltPagoCapital').html(dCapital.format(dFormat));
            } else
                $('#FechaUltPagoCapital').html('');

            if (row.dInterestAmoint != null) {
                var dInterestAmoint = new Date(row.dInterestAmoint);
                $('#UltFechaPagoInteres').html(dInterestAmoint.format(dFormat));
            } else
                $('#UltFechaPagoInteres').html('');

            if (row.dCommissionAmoun != null) {
                var dCommissionAmoun = new Date(row.dCommissionAmoun);
                $('#FechaUltPagoComision').html(dCommissionAmoun.format(dFormat));
            } else
                $('#FechaUltPagoComision').html('');

            if (row.dExpenseAmount != null) {
                var dExpenseAmount = new Date(row.dExpenseAmount);
                $('#dExpenseAmount').html(dExpenseAmount.format(dFormat));
            } else
                $('#dExpenseAmount').html('');

            if (row.dRateLateAmount != null) {
                var dRateLateAmount = new Date(row.dRateLateAmount);
                $('#dRateLateAmount').html(dRateLateAmount.format(dFormat));
            } else
                $('#dRateLateAmount').html('');

            if (row.dChargeAmount != null) {
                var dChargeAmount = new Date(row.dChargeAmount);
                $('#dChargeAmount').html(dChargeAmount.format(dFormat));
            } else
                $('#dChargeAmount').html('');

            EndRequestHandler();

        },
        mouseover: function () {
            var $row = $(this);
            $row.css("cursor", "pointer");
        }
    });
}

function GetDataFilterReceipOfPayment(pFilters, AccountId) {
    GetPartialView("/Process/_ReceipOfPayment", JSON.stringify({ AccountId: AccountId, filters: pFilters }), function (data) {
        var $Container = $("#dvReceipOfPayment")
        $Container.html(data);
        RemoveInputAutoComplete();
        InitQuotaInformation();
        InitGridReceiptOfPayment();
    }, true);
}

function ValidaSelectTemplate() {
    var hasViewLoaded = $.trim($("#dvTemplateContainer").html()) != "";
    return hasViewLoaded;
}

function ShowPDF(PathFile) {
    GetPartialView("/Process/ShowPDF", JSON.stringify({ PathFile: PathFile }), function (data) {
        ShowPopupBS(data, "VISOR DE PDF", function () {
            RemoveInputAutoComplete();
        });
    });
}

function DeleteRelatedDocument(templateSentId, Id, accountId) {
    ModalConfirm(null, function () {
        CallAjax("/Process/DeleteFile", JSON.stringify({ templateSentId: templateSentId, Id: Id }), "json", function (data) {
            var SelectedTemplateId = $("#dvTemplates").find("#SelectedTemplateId").val();
            GetdvAttachedFilesView(SelectedTemplateId, accountId, templateSentId);
        }, "POST", false);
    }, function () { })
}

function GetCorrespondencesView(AccountId, CustomerId) {
    //Abrir el tab  y trear la data
    GetPartialView("/Process/_Correspondences", JSON.stringify({ AccountId: AccountId, CustomerId: CustomerId }), function (data) {
        var $Container = $("#dvCorrespondence");
        $Container.html(data);
        RemoveInputAutoComplete();
        var $chkEmails = $("#dvMailInformation").find("input:checkbox");
        $chkEmails.click(function () {
            var selectedChk = 0;
            $chkEmails.each(function () {
                var $this = $(this);
                if ($this.prop("checked")) {
                    selectedChk++;
                }
            });

            $("#HasSelectedAnyEmail").prop("checked", (selectedChk > 0) ? "True" : "False");
        });
        var $rbPrincipalSelect = $("#dvRadios").find("input:checkbox");
        $rbPrincipalSelect.click(function () {
            var selectedrb = 0;
            var $RbSelected = $(this);
            $rbPrincipalSelect.prop("checked", false);
            $RbSelected.prop("checked", true);
            $("#HasSelectPrincipal").prop("checked", "True");
        });
        $.validator.unobtrusive.parse($("#dvCorrespondence"));
        SetDatePicker();
        SetProgressBar("#frmLoadFile", function () {
            $("#cbxDocumentGroupId").val("");
            $("#cbxDocumentTypesId").val("");
            var $Svalidation = $("#dvValidationSummaryLoadFile");
            var $UL = $Svalidation.find("ul");
            $UL.find("li").remove();
            $UL.append("<li style='display:none'/>");
            $Svalidation.removeAttr("class");
            $Svalidation.attr("class", "validation-summary-valid alert alert-danger");
            $("#hdnHasLoadedFile").val('');
            $("#btnReset").click();
            var SelectedTemplateId = $("#dvTemplates").find("#SelectedTemplateId").val();
            var templateSentId = $("#templateSentId").val();
            GetdvAttachedFilesView(SelectedTemplateId, AccountId, templateSentId);
        });
        var $trgvDocument = $("#gvDocument tbody tr");
        $trgvDocument.each(function () {
            var $this = $(this);
            $this.click(function () {
                var $iframePDFViewer = $("#iframePDFViewer");
                $iframePDFViewer.attr("src", "");
                var PartialViewName = $this.find("td").eq(1).find("#hdnPartialViewName").val();
                var TemplateId = $this.find("td").eq(2).find("#hdnTemplateId").val();
                var dataTemplate = { PartialViewName: PartialViewName, TemplateId: TemplateId };
                GetTemplateView(dataTemplate);
            });
        });
        MailInformationSection();
    }, true);
}

function GetdvAttachedFilesView(templateId, accountId, templateSentId) {
    GetPartialView("/Process/_AttachedFiles", JSON.stringify({ templateId: templateId, accountId: accountId, templateSentId: templateSentId }), function (data) {
        var $Container = $("#dvAttachedFiles");
        $Container.html(data);
        RemoveInputAutoComplete();
    }, true);
}

function GetTemplate(accountId) {
    var TemplateType = $("#dvTemplates").find("#hdnThTemplateSelected").val();
    var params = { TemplateType: TemplateType };
    //Validar que se haya cargado el view de los parametros
    var hasViewLoaded = ValidaSelectTemplate();
    if (!hasViewLoaded) {
        ShowMessageBS("Debes seleccionar un template a generar");
        return false;
    }

    $("#hdnHasGenereateTemplate").val(hasViewLoaded);
    $("#HasGenerateTemplateBySent").prop("checked", hasViewLoaded);
    var $dvTemplateContainer = $("#dvTemplateContainer");
    var $dvTemplates = $("#dvTemplates");
    var templateLoad = $dvTemplateContainer.find("input:hidden").eq(0).val();
    switch (templateLoad) {
        case "STMPROJECTADO":
            //Validar campos
            var ProjectedFilterByValue = $dvTemplateContainer.find("#ProjectedFilterBy").val();
            if (ProjectedFilterByValue == "") {
                ShowMessageBS("Debes seleccionar el campo proyección por");
                return false;
            } else {
                if (ProjectedFilterByValue == "4") {
                    var MontoAPagar = $dvTemplateContainer.find("#txtMontoAPagar").val();
                    if (MontoAPagar == "") {
                        ShowMessageBS("Debes suministrar al sistema el monto a pagar");
                        return false;
                    }
                }
            }

            if ($dvTemplateContainer.find("#txtSaldoAlDia").val() == "") {
                ShowMessageBS("Debes seleccionar el campo Saldo al Dia");
                return false;
            }

            var dateStatement = $dvTemplateContainer.find("#txtSaldoAlDia").val();
            var idTipo = ProjectedFilterByValue;
            var montoPago = $dvTemplateContainer.find("#txtMontoAPagar").val();
            //Buscar los datos nombre del cliente, numero de prestamo, fecha, monto en numeros y en letras
            GetProjectStatement(accountId, dateStatement, idTipo, montoPago, function (dataJson) {
                var LoanType = null;
                var record = dataJson;
                var index = record.length - 1;
                var KeyNameFindMontoAPagar = "";

                if (ProjectedFilterByValue == "1") {
                    LoanType = "2";
                    KeyNameFindMontoAPagar = "TotCuo";
                }

                if (ProjectedFilterByValue == "3") {
                    LoanType = "1";
                    KeyNameFindMontoAPagar = "TotSal";
                }

                var dataCantCuo = record.filter(function (item) {
                    return item.NameKey == "CantCuo"
                });

                var dataTotQuo = record.filter(function (item) {
                    return item.NameKey == KeyNameFindMontoAPagar;
                });

                params.MontoApagar = dataTotQuo[0].Value;
                params.AccountId = accountId;
                params.dateStatement = dateStatement;
                params.LoanType = LoanType;
                params.NumeroCuota = LoanType == "2" ? dataCantCuo[0].Value : null;
                $("#NumeroCuota").val(params.NumeroCuota);
                $("#LoanType").val(LoanType);
                $("#MontoApagar").val(params.MontoApagar);
                $("#StartDate").val(dateStatement);

                GetPartialView("/Process/_PdfViewer", JSON.stringify(params), function (data) {
                    var $Container = $("#dvPdfViewerCorrespondence");
                    $Container.html(data);
                    RemoveInputAutoComplete();
                    var templateId = $dvTemplates.find("#SelectedTemplateId").val();
                    var templateSentId = $("#templateSentId").val() != "" ? $("#templateSentId").val() : null;
                    //Salvar el header del template a enviar 
                    var params = {
                        templateSentId: templateSentId,
                        templateId: templateId,
                        accountId: accountId,
                        sendDate: null,
                        documentPath: null,
                        documentName: null,
                        emails: null,
                        comments: null,
                        isActive: true,
                        isSendToClient: null,
                        isSendToOffice: null,
                        isSendToAgent: null,
                        caseDepartmentID: null,
                        caseDate: null,
                        caseHour: null,
                        caseComment: null,
                        caseNo: null,
                        EntityId: $("#hdnClientId").val()
                    };

                    CallAjax("/process/SetTemplateHeader", JSON.stringify(params), "json", function (data) {
                        $("#templateSentId").val(data.TemplateSentId);
                        $("#RooTemplateSentId").val(data.TemplateSentId);

                    }, "POST", false);

                }, true);
            });

            break;
    }
}

function LoadCasesDetail(accountId) {
    var $GridTr = $("#gvCases tbody tr");
    $GridTr.dblclick(function () {
        var $Row = $(this);
        var $Td = $Row.find("td").eq(12);
        var Value = $Td.find('input:hidden').eq(0).val();
        var dataJsn = JSON.parse(Value);
        var relatedContactId = dataJsn.relatedContactId;
        var meetingTypeId = dataJsn.meetingTypeId;
        var meetingSubTypeId = dataJsn.meetingSubTypeId;
        var meetingCaseId = dataJsn.meetingCaseId;
        GetCasesDetailView(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, null, accountId);
    });
}

function GetViewNotes(accountId, relatedContactId, CustomerName, LoanNumber) {
    GetPartialView("/Process/_Notes", JSON.stringify({ relatedContactId: relatedContactId, accountId: accountId, CustomerName: CustomerName, LoanNumber: LoanNumber }), function (data) {
        var $Container = $("#dvNotes");
        $Container.html(data);
        var $gvCases = $("#gvCases");
        InitializeGrid($gvCases);
        $gvCases.find("input:checkbox").click(function () {
            var $thisChk = $(this);
            var Cck = CountCheckEx($gvCases, 'checkbox');
            if (Cck > 1) {
                $gvCases.find("input:checkbox").prop("checked", false);
                $thisChk.prop('checked', true);
            }
        });

        LoadCasesDetail(accountId);
    }, true);
}

function DownloadFile(url)
{
    window.open(url, '_blank');
}

function CloseAndRefresh(obj) {
    ClearFields(obj);
    $("#ChannelServiceId").trigger("change");
    $('#btnRefresh').click();
}

function GetCasesDetailView(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId, accountId) {
    var params = { relatedContactId: relatedContactId, meetingTypeId: meetingTypeId, meetingSubTypeId: meetingSubTypeId, meetingCaseId: meetingCaseId, meetingCaseNoteId: meetingCaseNoteId, LoanNumber: accountId };
    GetPartialView("/Process/_CasesDetail", JSON.stringify(params), function (data) {
        var $Container = $("#dvCasesDetail");
        $Container.html(data);
        $("#gvAttachedFiles tfoot a").each(function () {
            var $this = $(this);
            var urlRedirect = $this.attr("href") + "&relatedContactId=" + relatedContactId +
                                                   "&meetingTypeId=" + meetingTypeId +
                                                   "&meetingSubTypeId=" + meetingSubTypeId +
                                                   "&meetingCaseId=" + meetingCaseId +
                                                   "&meetingCaseNoteId=" + meetingCaseNoteId +
                                                   "&LoanNumber=" + accountId;
            $this.attr("href", urlRedirect);
        });

        $("#gvAttachedCalls tfoot a").each(function () {
            var $this = $(this);
            var urlRedirect = $this.attr("href") + "&relatedContactId=" + relatedContactId +
                                                   "&meetingTypeId=" + meetingTypeId +
                                                   "&meetingSubTypeId=" + meetingSubTypeId +
                                                   "&meetingCaseId=" + meetingCaseId +
                                                   "&meetingCaseNoteId=" + meetingCaseNoteId+
                                                   "&LoanNumber=" + accountId;;
            $this.attr("href", urlRedirect);
        });

    }, true);
}

function RefreshGridCases(accountId, relatedContactId, CustomerName, LoanNumber) {
    GetPartialView("/Process/_GridCases", JSON.stringify({ relatedContactId: relatedContactId, accountId: accountId, CustomerName: CustomerName, LoanNumber: LoanNumber }), function (data) {
        var $Container = $("#dvGridCases");
        $Container.html(data);
        InitializeGrid($("#gvCases"));
        LoadCasesDetail(LoanNumber);
    }, true);
}

function validateLoadedFileNote(obj) {
    var hasFile = obj.files.length != 0;
    $("#hdnHasLoadedFileNotes").val(hasFile);
}

function ShowPopMakeNote(CustomerId, CustomerName, LoanNumber, AccountId) {
    var ActionName = "";
    var CaseNumber = null;
    //Verificar si hay un caso seleccionado
    var $gvCases = $("#gvCases");
    var $inputChk = $gvCases.find("input[type='checkbox']:checked");
    if ($inputChk.length > 0)
        CaseNumber = $inputChk.attr('data');

    GetPartialView("/Process/_MakeNote", JSON.stringify({ CustomerId: CustomerId, CustomerName: CustomerName, LoanNumber: LoanNumber, accountId: AccountId }), function (data) {
        ShowPopupBS(data, "Crear Nota", null, false);
        var $ServiceId = $("#ServiceId");
        var $SubServiceId = $("#SubServiceId");
        var $meetingCaseId = $("#hdnmeetingCaseId");
        var $CasesStatusId = $("#CasesStatusId");
        var $hdnrelatedContactId = $("#hdnrelatedContactId");
        var $hdnaccountId = $("#hdnaccountId");
        $ServiceId.change(function () {
            var $this = $(this);
            if ($this.val() != "") {
                CallAjax("/Process/GetSubServiceType", JSON.stringify({ ServiceId: parseInt($this.val()) }), "json", function (data) {
                    var options = "";
                    var $SubServiceId = $("#SubServiceId");
                    $SubServiceId.find("option").remove();
                    var FirstOption = "<option value=''>Seleccionar</option>";
                    $SubServiceId.append(FirstOption);
                    $.each(data, function (i, v) {
                        var option = "<option value='" + v.Key + "'>" + v.Value + "</option>";
                        options += option;
                    });
                    $SubServiceId.append(options);
                    $SubServiceId.removeAttr("disabled");
                }, "POST", false);
            }
        });
        $CaseId = $("#CaseId");
        $CaseId.change(function () {
            var $this = $(this);
            if ($this.val() != "") {
                var CaseNumber = $this.val();
                CallAjax("/Process/GetDataCase", JSON.stringify({ CaseNumber: CaseNumber }), "json", function (data) {
                    var RecordCase = data.Cases[0];
                    var d = JSON.parse(RecordCase.CaseKey);

                    $ServiceId.val(d.meetingTypeId);
                    $("#hdnServiceId").val(d.meetingTypeId)
                    $ServiceId.trigger("change");
                    $ServiceId.attr("disabled", "disabled");

                    $SubServiceId.val(d.meetingSubTypeId);
                    $("#hdnSubServiceId").val(d.meetingSubTypeId);
                    $SubServiceId.attr("disabled", "disabled");

                    $meetingCaseId.val(d.meetingCaseId);
                    $hdnrelatedContactId.val(d.relatedContactId);
                    $hdnaccountId.val(AccountId);
                    $CasesStatusId.val(RecordCase.CaseStatusId);
                }, "POST", false);
            }
        });

        $("#ChannelServiceId").change(function () {
            var $this = $(this);
            var OptionSelected = $this.val();
            var $chkApplyToAttachedFiles = $("#ApplyToAttachedFiles");
            var $chkApplyToAttachedCall = $("#ApplyToAttachedCall");
            switch (OptionSelected) {
                case "2":
                    ActionName = "_PhoneCall";
                    $chkApplyToAttachedFiles.prop('checked', false);
                    $chkApplyToAttachedCall.prop('checked', true);
                    break;
                case "1":
                case "3":
                case "4":
                case "5":
                case "6":
                    ActionName = "_Email";
                    $chkApplyToAttachedFiles.prop('checked', true);
                    $chkApplyToAttachedCall.prop('checked', false);
                    break;
                default:
                    ActionName = "";
                    break
            }

            GetViewMeeting(ActionName, AccountId);
        });

        $.validator.unobtrusive.parse($("#dvMakeNote"));
        if (CaseNumber != "") {
            $CaseId.val(CaseNumber);
            $CaseId.trigger("change");
        }

        SetDatePicker();
    });
}

function GetViewMeeting(ActionName, AccountId) {
    var divContainer = (ActionName == "_PhoneCall") ? "#dvPhoneCall" : "#dvEmail";
    $("#dvPhoneCall").html("");
    $("#dvEmail").html("");
    if (ActionName != "") {
        var url = "/Process/" + ActionName;
        GetPartialView(url, null, function (data) {
            var $Container = $(divContainer);
            $Container.html(data);
            $.validator.unobtrusive.parse($Container);
            SetDatePicker();
            if (ActionName == "_Email") {
                $("#hdnLoanNumber").val(AccountId);
                $("#cbxDocumentGroupId").change(function () {
                    var $this = $(this);
                    var SelectedText = $this.find("option:selected").text();
                    $("#hdndocumentGroupName").val(SelectedText);
                });

                $("#cbxDocumentTypesId").change(function () {
                    var $this = $(this);
                    var SelectedText = $this.find("option:selected").text();
                    $("#hdnDocumentTypeDesc").val(SelectedText);
                });

                var $frm = $("#dvEmail").find("form:first");
                SetProgressBar($frm, function () {
                    $Container.find("#hdnHasLoadedFileNotes").val('false');
                    $Container.find("#btnReset").click();
                    GeAttechedNoteFiles();
                });
            } else
                if (ActionName == "_PhoneCall") {
                    var $gvPhoneCalls = $Container.find("#gvPhoneCalls");
                    $gvPhoneCalls.find("input:checkbox").click(function () {
                        var CounterChecked = 0;
                        var Calls = [];
                        var $this = $(this);
                        $gvPhoneCalls.find("input:checkbox").each(function () {
                            var $thisChk = $(this);
                            if ($thisChk.prop('checked')) {
                                var KeyItem = JSON.parse($thisChk.attr("data"));
                                Calls.push(KeyItem);
                                CounterChecked++;
                            }
                        });

                        $("#txtHasAttachedCall").val(CounterChecked > 0 ? CounterChecked : "");
                        $("#hdnCallsSelected").val(JSON.stringify(Calls));
                    });
                }
        }, true);
    }
}

function GeAttechedNoteFiles() {
    GetPartialView("/Process/GeAttechedNoteFiles", null, function (data) {
        var $Container = $("#dvNoteAttachedFiles");
        $Container.html(data);
        $txtHasAttachedFiles = $("#txtHasAttachedFiles");
        var RowCount = $("#gvAttachedFiles tbody tr").length;
        InitializeGrid($("#gvAttachedFiles"));
        $txtHasAttachedFiles.val((RowCount > 0) ? RowCount : "");
    }, true);
}

/*Cobranza*/
function GetCollections(accountId, account) {
    var account = $("#hdnAccount").val();
    var PaidF = $("#txtPagoDesteCollect").val();
    var PaidT = $("#txtPagoHastaCollect").val();
    var DebtF = $("#txtDeudaDesdeCollect").val();
    var DebtT = $("#txtDeudaHastaCollect").val();
    $("#accountId").val(accountId);
    var parameters = JSON.stringify({ AccountId: accountId, PaidF: PaidF, PaidT: PaidT, DebtF: DebtF, DebtT: DebtT, account: account });
    GetPartialView("/Process/_Collections", parameters, function (data) {
        var $Container = $("#divCollectionsAll");
        $Container.html(data);
        SetDatePicker();
        InitCardList();
    }, true);
}

function GetCollectionHistoryPayment(accountId) {

    var PaidF = $("#txtPagoDesteCollect").val();
    var PaidT = $("#txtPagoHastaCollect").val();
    var DebtF = $("#txtDeudaDesdeCollect").val();
    var DebtT = $("#txtDeudaHastaCollect").val();
    var parameters = JSON.stringify({ accountId: accountId, PaidF: PaidF, PaidT: PaidT, DebtF: DebtF, DebtT: DebtT });

    GetPartialView("/Process/_CollectionsHistoryPaymentGrid", parameters, function (data) {
        var $Container = $("#divCollectionHistoryPaymentGrid");
        $Container.html(data);
        RemoveInputAutoComplete();
        SetDatePicker();
    }, true);
}

/*CARD DOMICILIACION*/
function GetCardDomitiliation(accountId) {
    $("#myModal").modal("hide");
    GetPartialView("/Process/_CollectionsDomiciliationGrid", JSON.stringify({ accountId: accountId }), function (data) {
        var $Container = $("#divCollectionsDomiciliationGrid");
        $Container.html(data);
        RemoveInputAutoComplete();
        SetDatePicker();
        InitCardList();
    }, true);
}

function GetCollectionPayment(accountId) {

    $("#myModal").modal("hide");
    GetPartialView("/Process/_CollectionsPayments", JSON.stringify({ accountId: accountId }), function (data) {
        var $Container = $("#divCollectionsPayments");
        $Container.html(data);
        RemoveInputAutoComplete();
        SetDatePicker();
        InitCardList();
    }, true);
}

function EditCard(dataRequest) {
    BeginRequestHandler();
    GetEditDomiciliationView(dataRequest);
}

function GetMonths(Year) {
    $.post("/Process/GetMotnhs", { Year: Year }, function (data) {
        var $cboMonths = $("#cboMonths");
        $cboMonths.find("option").remove();
        console.log(data);
        $.each(data, function (index, value) {
            var NewOption = "<option value={0}> {1} </option>";
            NewOption = NewOption.replace("{0}", value.Value);
            NewOption = NewOption.replace("{1}", value.Key);
            $cboMonths.append(NewOption);
        });

        if (data.length > 0) {
            $cboMonths.removeAttr("disabled");
            var MonthSelected = $("#hdnMotnSelected").val();
            if (MonthSelected != "0")
                $("#cboMonths").val(MonthSelected);
        }
    });
}

function InitCardList() {

    var $grid = $("#gvAffiliateCards");
    var $rows = $grid.find("tbody tr");

    $rows.on({
        dblclick: function () {
            var $row = $(this);
            var $hidden = $row.find("input:hidden");
            EditCard($hidden.val());
        },
        mouseover: function () {
            var $row = $(this);
            $row.css("cursor", "pointer");
        }
    });

    InitializeGridCardList($grid);
    SetCboEventHandlerYears();
}

function SetCboEventHandlerYears() {

    $("#cboYears").change(function () {
        var $this = $(this);
        var $cboMonths = $("#cboMonths");

        if ($this.val() != "")
            GetMonths($this.val());
        else
            $cboMonths.attr("disabled", "disabled");
    });
}

function InitializeGridCardList($grid) {
    $grid.find("tbody tr").click(function () {
        var $thisRow = $(this);
        $grid.find("tbody tr").removeClass("rowActive");
        $thisRow.addClass("rowActive");
    });
}

function GetDomiciliationView(dataRequest) {
    GetPartialView("/Process/_CardDomiciliation", JSON.stringify({ dataRequest: dataRequest }), function (data) {
        $("#myModal").find("div.modal-dialog").eq(0).css("width", "800px")
        ShowPopupBS(data, "DOMICILIACIÓN DE TARJETA", function () {
            RemoveInputAutoComplete();
        });
        InitCardList();
        //SetMask();
        $.validator.unobtrusive.parse($("#dvCardDomitiliation"));
    }, true);

}

function GetEditDomiciliationView(dataRequest) {
    GetPartialView("/Process/_EditCardDomiciliation", JSON.stringify({ dataRequest: dataRequest }), function (data) {
        $("#myModal").find("div.modal-dialog").eq(0).css("width", "800px")
        ShowPopupBS(data, "DOMICILIACIÓN DE TARJETA", function () {
            RemoveInputAutoComplete();
        });
        InitCardList();
        //SetMask();
        $.validator.unobtrusive.parse($("#dvCardDomitiliation"));
    }, true);
}

function CloseModalProcessPayment(accountId) {
    var hasError = $("#hdnHasError").val().toLowerCase() == "true";
    if (!hasError) {
        var receiptNumberEasybank = $("#hdnreceiptNumberEasybank").val();
        var authorizationNumber = $("#hdnauthorizationNumber").val();
        var msg = "";
        msg += "Pago procesado con exito";
        msg += "Numero de autorización del procesador de pago : " + authorizationNumber;
        msg += "Numero de recibo de Kredisi : " + receiptNumberEasybank;

        ShowMessageBS(msg, "Info", function () {
            $('#btnCancel').click();
            GetCollectionHistoryPayment(accountId);
            GetCollectionPayment(accountId);
        });
    } else {
        //Darle salida al mensaje de error
        var datamsgError = JSON.parse($("#hdnErrorJson").val());
        var msgError = "";
        for (var i = 0; i < datamsgError.length; i++) {
            msgError += (i + 1) + ".-" + datamsgError[i] + "<br>";
        }

        ShowMessageBS(msgError, "Algunas observaciones", function () { }, true);
        var Year = $("#cboYears").val();
        GetMonths(Year);
    }
}

/*CARD DOMICILIACION*/
/*Cobranza*/

function PlayCall(obj) {
    var NewStatus = "";
    var $button = $(obj);
    var Status = $button.data("Status");

    if (Status !== null) {
        var Status = "Playing";
        $button.data("Status", Status);
    }

    switch (Status) {
        case "Playing":
            NewStatus = "Pause";
            $button.val("Pausar");
            break;

        case "Pause":
            NewStatus = "Playing";
            $button.val("Reproducir");
            break;
    }

    $button.data("Status", NewStatus);
    var x = document.getElementById("myAudio");
    ManageAudio(x, NewStatus);
}

function ClearPanels(dvParentId, CallBack, obj) {
    var $thisOption = $(obj);
    var isOpen = $thisOption.attr("aria-expanded") == "true";
    var $accordeons = $("#" + dvParentId).find(".accordion-body");
    $accordeons.each(function () {
        var $this = $(this);
        $this.html('');
    });

    if (!isOpen) {
        if (CallBack != undefined) {
            CallBack();
        }
    }
}

function DeleteFile(Id) {
    ModalConfirm(null, function () {
        CallAjax("/Process/DeleteFileNote", JSON.stringify({ Id: Id }), "json", function (data) {
            var result = data;
            if (result.HasError) {
                ShowMessageBS(result.Message, "Error")
            } else {
                GeAttechedNoteFiles();
            }
        }, "POST", false);
    }, null, false);
}