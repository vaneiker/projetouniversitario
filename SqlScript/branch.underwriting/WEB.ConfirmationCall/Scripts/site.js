function ConfigureLanguage() {
    var lbl = $("#divLanguage label")[0];
    var hdn = document.getElementById("hdnLang");
    if (lbl != undefined && hdn != undefined) {
        lbl.className = hdn.value;
        lbl.textContent = $("#divLanguage li." + lbl.className).text();
    }
}

function changeLanguage(lang) {
    document.getElementById("hdnLang").value = lang;
    document.getElementById("btnChangeLang").click();
    //$.post(window.location.href, { language: this.getAttribute("lang") }, function (html) {
    //    $("body").html(html);
    //});
    //return false;
}
