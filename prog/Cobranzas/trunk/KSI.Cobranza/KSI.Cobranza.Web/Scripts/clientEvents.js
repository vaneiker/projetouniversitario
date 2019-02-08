$(document).ready(function () {

    //CAMBIANDO EL IDIOMA CUANDO CARGA LA PAGINA
    //if ($("#hdnLang").val() == "en") {
    //    stfChangeLanguageMVC($("#hdnLang").val());
    //}

    //<!--Show Avaible Apps-->
    var hdnavaibleapps = document.getElementById("hdnavaibleapps");
    if (hdnavaibleapps !== null) {
        if (hdnavaibleapps.value == "True") {
            $("#SecMenu").show();
            avaibleAppsDashboard();
        }
    } else {
        $("#SecMenu").hide();
    }

    //Asignando evento click
    $(document).on("click", ".AppButton", function () {
        var button = $(this).attr("id");

        $.ajax({
            url: STFUserProfileRoutes.AppButtonClick,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ buttonID: button }),
            dataType: "json",
            success: function (data) {

                if (data === "NO") {
                    return false;
                }

                location.href = data;
            }
        });

    });
    //<!--Show Avaible Apps-->


    //<!--Fill Company-->
    $.ajax({
        url: STFUserProfileRoutes.FillCompanyAndUpdateCompanyLogo,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //data: JSON.stringify({ countryId: UserProfileViewModel.userModel.currentAddress().CountryId }),
        data: {},
        dataType: "json",
        success: function (data) {

            var jsonNew = JSON.parse(data);

            var showLogo = "";
            var changeLogo = "";
            var companid = "";
            var selected = "";

            $.each(jsonNew, function (i, item) {

                if (showLogo == "") {

                    if (jsonNew[i].ShowLogo === "S") {
                        $("#profile_menu_logo").show();
                        showLogo = jsonNew[i].ShowLogo;
                    } else {
                        $("#profile_menu_logo").hide();
                        showLogo = jsonNew[i].ShowLogo;
                    }
                }

                if (changeLogo == "") {

                    if (jsonNew[i].changeLogo === "S") {

                        if (jsonNew[i].companyId === 1) {

                            $("#profile_menu_logo").removeAttr("class");
                            $("#profile_menu_logo").attr("class", "logo");

                            changeLogo = jsonNew[i].changeLogo;

                        } else {

                            $("#profile_menu_logo").removeAttr("class");
                            $("#profile_menu_logo").attr("class", "logo_atl");

                            changeLogo = jsonNew[i].changeLogo;
                        }

                    } else {

                        if (jsonNew[i].companyId === 1) {

                            $("#profile_menu_logo").removeAttr("class");
                            $("#profile_menu_logo").attr("class", "logo");

                            changeLogo = jsonNew[i].changeLogo;

                        } else {

                            $("#profile_menu_logo").removeAttr("class");
                            $("#profile_menu_logo").attr("class", "logo_atl");

                            changeLogo = jsonNew[i].changeLogo;
                        }
                    }
                }


                //creando los options de companias
                if (jsonNew[i].valueSelected == jsonNew[i].Value) {
                    selected = "selected=\"selected\"";
                }

                $("#drpCompanyProfile").append("<option value=\"" + jsonNew[i].Value + "\" " + selected + ">" + jsonNew[i].Text + "</option>");
                selected = "";
            });
        }
    });


    //Asignando evento change
    $(document).on("change", "#drpCompanyProfile", function () {
        var drpValue = $(this).val();

        $.ajax({
            url: STFUserProfileRoutes.FillCompanyAndUpdateCompanyLogoChange,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ selectedValue: drpValue }),
            dataType: "json",
            success: function (data) {
                if (data === "OK") {
                    location.reload();
                }
            }
        });

    });
    //<!--Fill Company-->


    stfSetLanguage();



    $(document).on("click", "#btnLogout", function () {

        $.ajax({
            url: STFUserProfileRoutes.LogOut,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: {},
            //dataType: "json",
            success: function (data) {
                if (data !== null) {
                    location.href = data;
                }
            }
        });
    });


    $(document).on("click", "#btnillustration", function () {

        $.ajax({
            url: STFUserProfileRoutes.RedirectModule,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: {},
            //dataType: "json",
            success: function (data) {
                if (data !== null) {
                    location.href = data;
                }
            }
        });

    });


    createForm();


    $(document).on("submit", "form#frmUploadPhotoUserProfile22", function (event) {
        var data = new FormData();
        data.append('file', $('#fldUploadUserImage')[0].files[0]);
        console.log(data);
        $.ajax({
            type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
            url: STFUserProfileRoutes.STFConvertImageBase64, // the url where we want to POST
            data: data, // our data object
            processData: false,
            contentType: false,
            //success: function (responseText, statusText, xhr, $form) {
            success: function (data, responseText, statusText, xhr) {
                //UserProfileViewModel.userModel.Photo(responseText);
                UserProfileViewModel.userModel.Photo(data);
                UserProfileViewModel.userModel.UpdatePhoto = true;
                $(".foto_perfil").prepend($("#fldUploadUserImage"));
            }
        });

        event.preventDefault();
    });




    //si existe un objeto con una clase llamada dynamicli lo agrego al ul del perfil
    if ($("li.dynamicli").length > 0) {

        $("li.dynamicli").each(function () {
            var liActual = $(this);

            console.log(liActual);

            $(liActual).appendTo('ul#acordeon_agent_profile');

        });
    }


});


function avaibleAppsDashboard() {
    $.ajax({
        url: STFUserProfileRoutes.FillAvailableDashboards,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //data: JSON.stringify({ countryId: UserProfileViewModel.userModel.currentAddress().CountryId }),
        data: {},
        dataType: "json",
        success: function (data) {

            var jsonNew = JSON.parse(data);

            $.each(jsonNew, function (i, item) {
                if (jsonNew[i].h2Title !== null) {
                    $("#liSecurityMenu").append("<h2 class=\"sub_div_menu\">" + jsonNew[i].h2Title + "</h2>");
                }

                if (jsonNew[i].ID !== null) {
                    $("#liSecurityMenu").append("<input type=\"submit\" name=\"" + jsonNew[i].ID + "\" value=\"" + jsonNew[i].Text + "\" id=\"" + jsonNew[i].ID + "\" class=\"" + jsonNew[i].CssClass + "\">");
                }
                // console.log(jsonNew[i].h2Title);
            });
        }
    });
}

function stfChangeLanguageMVC(lang) {

    try {
        $("#hdnLang").val(lang);
        changeLanguajeMVC(lang);
        return;
    } catch (e) {
        console.error(e.message);
    }
    //$("#hdnLang").val(lang);
    //setTimeout(function () { location.reload(); }, 100);
}


function changeLanguajeMVC(lang) {
    $.ajax({
        url: STFUserProfileRoutes.ChangeLanguage,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ lang: lang }),
        dataType: "json",
        success: function (data) {

            if (data === "OK") {
                stfSetLanguage();
                location.reload();
            }
            /*else if (data === "NO") {
                stfSetLanguage();
            }*/
        }
    });
}

function stfSetLanguage() {

    var dvIdiomas = $("#divLanguage");
    var idioma = $("#hdnLang").val();
    dvIdiomas.removeAttr("class").addClass("idiomas").addClass(idioma);
    var text = dvIdiomas.find("ul > li[class~='" + (idioma) + "']").html();
    var label = dvIdiomas.find("label")[0];
    $(label).html(text).removeAttr("class");
    $(label).addClass(idioma);

    if (idioma === "es") {
        $("#btnLoadProfile").attr("class", "show_profile show_profile_es");
    } else {
        $("#btnLoadProfile").removeAttr("class");
        $("#btnLoadProfile").attr("class", "show_profile");
    }
};

function fillDepartment() {
    $.ajax({
        url: STFUserProfileRoutes.fillDepartment,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            if (data != null) {

                var jsonNew = JSON.parse(data);

                $.each(jsonNew, function (i, item) {
                    if (jsonNew[i].Id !== null) {
                        //$("#liSecurityMenu").append("<h2 class=\"sub_div_menu\">" + jsonNew[i].h2Title + "</h2>");

                        $("#drpEmailTo").append("<option value=\"" + jsonNew[i].Id + "\" >" + jsonNew[i].Description + "</option>");
                    }
                });
            }
        }
    });
}


function SendEmail() {
    var subject = document.getElementById("txtSubject").value;
    var lstMsg = [];

    if (subject == "") {
        lstMsg.push(new itemMessage("Required", "Subject"));
        alertTranslateValues(lstMsg);
        return false;
    }
    var message = document.getElementById("txtMessage1").value;
    if (message == "") {
        lstMsg.push(new itemMessage("Required", "Message"));
        alertTranslateValues(lstMsg);
        return false;
    }
    var departmentId = document.getElementById("drpEmailTo").value;

    alertTranslateValues("MessageWillBeSend");
    //try {
    //    showCommonLoading();
    //} catch (e) {
    //    console.error(e.message);
    //}

    $.ajax({
        url: STFUserProfileRoutes.SendingEmail,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ subject: subject, departmentId: departmentId, message: message }),
        dataType: "json",
        success: function (data) {
            if (data == "") return;
            //try {
            //    hideCommonLoading();
            //} catch (e) {
            //    console.error(e.message);
            //}
            //try {
            //    commonAlert(data);
            //    return;
            //} catch (e) {
            //    console.error(e.message);
            //}
            STFShowAlertMVC(data);
        }
    });

    ClearSendEmail();
}

function ClearSendEmail() {
    document.getElementById("txtSubject").value = "";
    document.getElementById("txtMessage1").value = "";
    return false;
}





//Knockout FUNCTIONS
function GetUserProfileDataMVC(loadNewModel) {
    //$.post(serverPath + "/Dashboard/GetCurrentUserData", function (data) {//Trae el objeto para la información del usere
    //    $.getJSON(serverPath + "/api/common/country", function (countries) {//Trae la lista de paises.
    var bind = document.getElementById("divPerfil");//Usado para bindearlo solo aqui.
    ko.cleanNode(bind); //Se limpia el bindeo.

    $("#divPerfil").prepend('<div id="divSTFPerfilLoadingPanel">' +
                                '<div id="divSTFPerfilLoadingBar">' +
                                    '<div id="divSTFPerfilLoadingFill"></div>' +
                                    '<span id="spanTextLoadingPanel">Loading Panel</span>' +
                                '</div>' +
                            '</div>')

    $("#divSTFPerfilLoadingPanel #spanTextLoadingPanel").text(document.getElementById("hdnLang") == undefined || document.getElementById("hdnLang").value == "en" ? "Loading Profile" : "Cargando Perfil");
    $("#upSTFLeftMenu #fldUploadUserImage").val(null);
    if (loadNewModel)
        $.ajax({
            //url: pagePath + '/GetUserProfileConfigurationAllData',
            url: STFUserProfileRoutes.GetUserProfileConfigurationAllData,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //console.log(data);

                //if (data.d != null && data.d.UserInfo != "") {
                if (data.UserInfo != null) {

                    UserProfileViewModel =
                        new UserProfileController(JSON.parse(data.UserInfo),
                        JSON.parse(data.ListCountry),
                        JSON.parse(data.ListStateProv),
                        JSON.parse(data.ListCity));
                    ko.applyBindings(UserProfileViewModel, bind); //Aquí se aplica el bindeo.


                    fillDepartment();

                }
                $("#divSTFPerfilLoadingPanel").remove();
            }
        });
    return;
}


function LoadState(regionStateProvId) {

    $.ajax({
        //url: pagePath + '/GetStateProvByCountry',
        url: STFUserProfileRoutes.GetStateProvByCountry,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ countryId: UserProfileViewModel.userModel.currentAddress().CountryId }),
        dataType: "json",
        success: function (data) {

            UserProfileViewModel.ListState(data);

            regionStateProvId = regionStateProvId == undefined ? UserProfileViewModel.userModel.currentAddress().RegionStateProvId : regionStateProvId;

            LoadCity(regionStateProvId);
        }
    });
}

function LoadCity(regionStateProvId) {
    regionStateProvId = regionStateProvId == undefined ? UserProfileViewModel.userModel.currentAddress().RegionStateProvId : regionStateProvId;

    $.ajax({
        //url: pagePath + '/GetCityByStateProv',
        url: STFUserProfileRoutes.GetCityByStateProv,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ countryId: UserProfileViewModel.userModel.currentAddress().CountryId, regionStateProvId: regionStateProvId }),
        dataType: "json",
        success: function (data) {

            UserProfileViewModel.ListCity(data);
            isChanging = false;
            if (isChangingListAddress) {
                ExecWhenChangeListAddress();
                isChangingListAddress = false;
            }
        }
    });
}

function ChangeListAddress() {
    var data = Enumerable.From(UserProfileViewModel.userModel.ModelData.ListAddress).Where("$.TypeDisplay == '" + UserProfileViewModel.userModel.currentAddress().TypeDisplay + "'").FirstOrDefault();
    if (data != undefined) {
        LoadState(data.RegionStateProvId);
    } else LoadState();
}


function SaveChangesUserProfile() {
    STFShowLoading();
    UserProfileViewModel.userModel.ModelData.ListEmail = [];
    UserProfileViewModel.userModel.ModelData.ListPhone = [];
    UserProfileViewModel.userModel.ModelData.ListAddress = [];
    var lstMsg = [];

    for (var i = 0; i < UserProfileViewModel.userModel.ModelData.ListObservableEmail().length - 1; i++) {
        var email = UserProfileViewModel.userModel.ModelData.ListObservableEmail()[i];
        if (email.Email == "" || email.Email == null || isEmail(email.Email)) continue;

        lstMsg.push(new itemMessage("FieldIsInvalid", "Email " + email.TypeDisplay));
        alertTranslateValues(lstMsg);

        STFHideLoading();
        return false;
    }

    //Inserta los objetos eliminados en la lista de objetos.
    if (UserProfileViewModel.userModel.ModelData.ListDeletedEmail.length > 0)
        ko.utils.arrayPushAll(UserProfileViewModel.userModel.ModelData.ListEmail, UserProfileViewModel.userModel.ModelData.ListDeletedEmail);
    if (UserProfileViewModel.userModel.ModelData.ListDeletedPhone.length > 0)
        ko.utils.arrayPushAll(UserProfileViewModel.userModel.ModelData.ListPhone, UserProfileViewModel.userModel.ModelData.ListDeletedPhone);
    if (UserProfileViewModel.userModel.ModelData.ListDeletedAddress.length > 0)
        ko.utils.arrayPushAll(UserProfileViewModel.userModel.ModelData.ListAddress, UserProfileViewModel.userModel.ModelData.ListDeletedAddress);
    //Inserta los objetos insertados y modificados en la lista de objetos.
    if (UserProfileViewModel.userModel.ModelData.ListObservableEmail().length > 0)
        ko.utils.arrayPushAll(UserProfileViewModel.userModel.ModelData.ListEmail, UserProfileViewModel.userModel.ModelData.ListObservableEmail());
    if (UserProfileViewModel.userModel.ModelData.ListObservablePhone().length > 0)
        ko.utils.arrayPushAll(UserProfileViewModel.userModel.ModelData.ListPhone, UserProfileViewModel.userModel.ModelData.ListObservablePhone());
    if (UserProfileViewModel.userModel.ModelData.ListObservableAddress().length > 0)
        ko.utils.arrayPushAll(UserProfileViewModel.userModel.ModelData.ListAddress, UserProfileViewModel.userModel.ModelData.ListObservableAddress());

    //Filtra los objetos que fueron insertados, modificados o eliminados.
    UserProfileViewModel.userModel.ModelData.ListEmail = Enumerable.From(UserProfileViewModel.userModel.ModelData.ListEmail)
        .Where("$.Command != null").ToArray();
    UserProfileViewModel.userModel.ModelData.ListPhone = Enumerable.From(UserProfileViewModel.userModel.ModelData.ListPhone)
        .Where("$.Command != null").ToArray();
    UserProfileViewModel.userModel.ModelData.ListAddress = Enumerable.From(UserProfileViewModel.userModel.ModelData.ListAddress)
        .Where("$.Command != null").ToArray();

    //Si la foto fue modificada, se enviará al servidor.
    if (UserProfileViewModel.userModel.UpdatePhoto)
        UserProfileViewModel.userModel.ModelData.Photo = UserProfileViewModel.userModel.Photo();

    var userInfo = JSON.stringify(UserProfileViewModel.userModel.ModelData);
    $.ajax({
        url: STFUserProfileRoutes.SetUserProfileData,
        type: "POST",
        data: JSON.stringify({ userInfo: userInfo }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            ValidateSuccessChangesMVC(data);
        }
    });
    return false;
}

function ValidateSuccessChangesMVC(msg) {
    UserProfileViewModel.userModel.ModelData.ListEmail = [];
    UserProfileViewModel.userModel.ModelData.ListPhone = [];
    UserProfileViewModel.userModel.ModelData.ListAddress = [];
    if (msg == "") {
        UserProfileViewModel.userModel.ModelData.ListDeletedEmail = [];
        UserProfileViewModel.userModel.ModelData.ListDeletedPhone = [];
        UserProfileViewModel.userModel.ModelData.ListDeletedAddress = [];
        CancelChangesUserProfile();
        alertTranslateValuesMVC("ProfileChangedSucessfully");
    } else
        STFShowAlertMVC(msg);

    STFHideLoading();
}

function alertTranslateValuesMVC(lstMsg) {
    $.ajax({
        //url: pagePath + '/GetTranslate',
        url: STFUserProfileRoutes.GetTranslate,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ key: (typeof lstMsg === "string") ? lstMsg : JSON.stringify(lstMsg) }),
        dataType: "json",
        success: function (data) {
            STFShowAlertMVC(data);
        }
    });
}

function ChangePhoto() {

    //$("#frmUploadPhotoUserProfile22").html($("#fldUploadUserImage")).submit();

    $("form#frmUploadPhotoUserProfile22").submit();
    //function (event) {
    //    
    //    var data = new FormData(this);

    //    console.log(data);

    //    $.ajax({
    //        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
    //        url: STFUserProfileRoutes.STFConvertImageBase64, // the url where we want to POST
    //        data: data, // our data object
    //        dataType: 'json', // what type of data do we expect back from the server
    //        encode: true,
    //        success: function (responseText, statusText, xhr, $form) {

    //            
    //            UserProfileViewModel.userModel.Photo(responseText);
    //            UserProfileViewModel.userModel.UpdatePhoto = true;
    //            $(".foto_perfil").prepend($("#fldUploadUserImage"));


    //            event.preventDefault();
    //        }



    //    });
    //});

}


function createForm() {

    var action = STFUserProfileRoutes.STFConvertImageBase64;
    console.log(action);

    var frm = $("form#frmUploadPhotoUserProfile22").attr("action", action).attr("method", "post");

    //var frm = $("<form/>").attr("id", "frmUploadPhotoUserProfile").attr("action", action).attr("method", "post");

    console.log(frm)

    //$("form").parent().append(frm);

    //$(frm).ajaxForm({
    //    success: function (responseText, statusText, xhr, $form) {
    //        alert(responseText);
    //        
    //        UserProfileViewModel.userModel.Photo(responseText);
    //        UserProfileViewModel.userModel.UpdatePhoto = true;
    //        $(".foto_perfil").prepend($("#fldUploadUserImage"));
    //    }
    //});
}


function STFShowAlertMVC(message) {
    alert(message);
}

function CancelChangesUserProfile() {    
    GetUserProfileDataMVC(true);        
    return false;
}