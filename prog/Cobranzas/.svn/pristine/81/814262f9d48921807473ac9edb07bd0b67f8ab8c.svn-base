class Helper {

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 12/Junio/2017
     * Busca dentro de un array
     * un item cuya propiedad recibida
     * tenga el valor recibido
     */
    static GetIndex(PrmArray, PrmProperty, PrmValue) {

        var ArrayLength = PrmArray.length;
        var Result = new Array();

        if (ArrayLength > 0)
            for (var Index = 0; Index < ArrayLength; Index++)
                if (PrmArray[Index].hasOwnProperty(PrmProperty))
                    if (PrmArray[Index][PrmProperty] == PrmValue) {
                        Result.push(Index);
                    }

        return Result;
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 24/Junio/2017
     * Hace una llamada ajax a la url especificada
     */
    static DoAjax(Url, Params) {
        var Loading = $("#loading");
        return $.ajax({
            type: "POST",
            url: Url,
            data: JSON.stringify(Params),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                Loading.show();
            },
            success: function () {
                Loading.hide();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.responseText);
            }
        });
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 14/Mar/2018
     * Hace una llamada ajax a la url especificada via get
     */
    static DoGet(Url, Params) {
        var Loading = $("#loading");
        Loading.show();
        return $.get(Url, Params)
            .done(function () { Loading.hide(); });
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 06/Julio/2017
     * Devuelve el la cantidad de segundos transcurridos
     * desde 1970 a la actualidad
     */
    static GetUtcTimestamp() {
        return Math.round((new Date().getTime()) / 1000);
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 03/Marzo/2018
     * Devulve la llave de una fila seleccionada
     * de un grid de DevExpress
     */
    static GetGridViewKey(s, e) {
        return s.keys[e.visibleIndex - (s.pageIndex * s.pageRowSize)];
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 14/Marzo/2018
     * LLena un DropDownList
     * via ajax
     */
    static FillDropDownList(DropDownList, Url, Params) {
        Helper.DoAjax(Url, Params).done(function (Data) {

            DropDownList.empty();

            DropDownList.append(AppObjects.Select.Option.New("", "Seleccione"));

            $.each(Data, function (k, v) {
                DropDownList.append(AppObjects.Select.Option.New(v.Value, v.Text));
            });
        });
    };
}