/**
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * vbarrera | 12/Abr/2018
 * Utilice este objeto para generar elementos html dinamicamente
 */
var AppObjects = {
    Select: {
        Option: {
            New: function (Value, Text) {
                var Option = "";
                Option = "<option value='";
                Option += Value;
                Option += "'>";
                Option += Text
                Option += "</option>";
                return $(Option);
            }
        }
    }
}

/**
 * // -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * vbarrera | 12/Abr/2018
 * Utilice este objeto para definir delegados 
 */
var AppDelegates = {
    /**
     * vbarrera | 12/Abr/2018
     * Delegado que se invoca al momento que el CrudDataItemsFramework
     * rellena un DropDownList en cascada
     */
    OnChangeCrudDropDownList: function (DropDownListParent, DropDownListChildren) { },
    /**
     * vbarrera | 12/Abr/2018
     * Delegado que se invoca cuando el CrudDataItemsFramework
     * hace PostBack para guardar los DataItems
     */
    OnPostBackPartialCrud: function () { },
    /**
     * vbarrera | 16/Abr/2018
     * Delegado que se invoca cuando el visor de documentos es cerrado
     */
    OnCloseDocumentViewer: function () { }
}