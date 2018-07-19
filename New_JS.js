function MandarData() {

    var name = $("#nameText").val();
    var apell = $("#apelliText").val();
    var telefono = $("#telefonoText").val();
    var sexo = $("#sexoDrop").val();

    $("#nameText").keypress(function () {
        $this = $(this);
        if ($this.val() != "") {
            DesactivarMensaje();
        }
    });

    $("#apelliText").keypress(function () {
        $this = $(this);
        if ($this.val() != "") {
            DesactivarMensaje();
        }
    });

    $("#telefonoText").keypress(function () {
        $this = $(this);
        if ($this.val() != "") {
            DesactivarMensaje();
        }
    });

    if (name == "" || name == null)
    {
        $("#oculto").show();
        return;
    }
    else if (apell == "" || apell == null)
    {
        $("#oculto").show();
        return;
    }
    else if (telefono == "" || telefono == null) {

       $("#oculto").show();
      return;
    } 

    else if (sexo == "Seleccione Sexo" || sexo == null)
    {
        $("#oculto").show();
        return;
    }
    {
        SendMail(name, apell, telefono);
    }
       
jquery   


}

function DesactivarMensaje() {
    $("#oculto").hide();
}

function SendMail(name, apell, telefono) {

    CallAjax("EnvioDeDatos", JSON.stringify({ name: name, apell: apell, telefono: telefono }), "json", function (data) { }, "POST");
}

alert("Paso todo bien" + data);   

function CallAjax(vUrl, vParameter, vDataType, vSucess, RequestType, isAsync) {


    $.ajax({
        type: RequestType,
        url: vUrl,
        data: vParameter != undefined ? vParameter : {},
        contentType: "application/json; charset=utf-8",
        dataType: vDataType,
        success: vSucess,
        async: isAsync != undefined ? isAsync : true,
        failure: function (data) {
            if (data == true) {
                alert("Se ejecuto el comando exitosamente " + data.responseText);
                Cancelar();

            } else {
                alert("No Se ejecuto el comando: " + data.responseText);
                Cancelar();
            }
        },
        error: function (data) {
            console.log(vUrl);
            if (data != undefined && data.responseText != undefined)
                alert("Error al Realizar :" + data.responseText);
        }
    });
}

function Cancelar() {
    $("#oculto").hide();
    $("#nameText").val("");
    $("#apelliText").val("");
    $("#telefonoText").val("");
    $("#nameText").focus();
}



Vista MVC 

@{
    ViewBag.Title = "Probando Jquery Ajax";
}





<br />
<div class="jumbotron">
   
</div>
<div class="panel panel-primary">
    <div class="panel-heading">Pruebas Ajax</div>
    <div>
        <div class="container">
            <br />
            <div id='oculto' style='display:none;' class="alert alert-danger" role="alert">
                <strong>Error!</strong> Favor Digitar Nombre,Apellidos y telefono.
            </div>           
            <span>Nombres:</span><input id="nameText" required="required" class="form-control" type="text" /> <span>Apellidos:</span><input id="apelliText" required="required" class="form-control" type="text" />
            <span>Telefono:</span><input id="telefonoText" required="required" class="form-control" type="text" />
            <span>Sexo:</span>
        <div class="dropdown">
        <select id="sexoDrop" class="form-control">
            <option value="0">Seleccione Sexo</option>
            <option value="1">Masculino</option>
            <option value="2">Femenino</option>
            <option value="3">Otros...</option>
        </select>

    </div>

</div>
        <div class="container">
            <br />      
            <input id="CancelButton" type="button" class="btn btn-danger"  onclick="Cancelar()" value="Cancelar" />
            <input id="submitButton" type="button" class="btn btn-primary" onclick="MandarData()" value="Enviar" />
            <br />           
        </div>
    </div>
    <ul id="errorContainer"   class="errorSection"/>
    <ul id="messageContainer" class="messageSection"/>
</div>
<script src="~/Scripts/JS/JsMantenimientos.js"></script>


Controller

  public ActionResult EnvioMensaje()
        {

            return View();
        }             
        public JsonResult EnvioDeDatos(string name, string apell,string telefono)
        {
           
            var repuesta = _metodos.GuardarPersona(name,apell,telefono);

            if(repuesta==true)
            {
                return Json(repuesta, JsonRequestBehavior.AllowGet);
            } else
            {
                return Json(repuesta, JsonRequestBehavior.AllowGet);
            }

            
        }


/******************************************************************************
<!DOCTYPE html>
<html>
<head>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

</head>
<body>

    <input  id="can1" type="text" placeholder="Digite un valor 1"/>
    <input  id="can2" type="text" placeholder="Digite un valor 2"/>
    <br/>
    <br/>
    <input  id="resultado" type="text" readonly="readonly" style="height:80px; text-align:center;"  placeholder="Resultado"/>

    <input id="btnSumar" type="button" onclick="Sumar()" style="height:50px;width:50;" value="+"/>
    <input id="btnResta" type="button" onclick="Resta()" style="height:50px;width:50;" value="-"/>
    <input id="btnMultiplicacion" type="button" onclick="Multiplicar()" style="height:50px;width:50;" value="x"/>
    <input id="btnDividir" type="button" onclick="Divicion()" style="height:50px;width:50;" value="/"/>
    <input id="btnPorciento" type="button" onclick="Porciento()" style="height:50px;width:50;"  value="%"/>
    <input type="radio" id="rbExample" ></input>


    <script>

        

function  Sumar()
{
    var x = $("#rbExample").prop("checked");  
    var cantidad1 = parseInt($("#can1").val());
    var cantidad2 =parseInt($("#can2").val());
    
    if(cantidad1==null || cantidad1=="" || cantidad2==null || cantidad2==""){
       console.log("No se puede Calcular ya que no hay cantidad");
       return;
    }
     else
    {
        var res = cantidad1+cantidad2;
        $("#resultado").val(res.toString());
       console.log(res.toString());
    }    
}  

     
function  Resta()
{
    var cantidad1 = parseInt($("#can1").val());
    var cantidad2 =parseInt($("#can2").val());
    var res = cantidad1-cantidad2;
    $("#resultado").val(res.toString());
     console.log(res.toString());
    
}  


function  Multiplicar()
{
    var cantidad1 = parseInt($("#can1").val());
    var cantidad2 =parseInt($("#can2").val());
    var res = cantidad1*cantidad2;
    $("#resultado").val(res.toString());
console.log(res.toString());
    
}  


function  Divicion()
{
    var cantidad1 = parseInt($("#can1").val());
    var cantidad2 =parseInt($("#can2").val());
    var res = cantidad1/cantidad2;
    $("#resultado").val(res.toString());
console.log(res.toString());
    
}  


function  Porciento()
{
    var cantidad1 = parseInt($("#can1").val());
    var cantidad2 =parseInt($("#can2").val());
    var res = cantidad1*cantidad2/100;

    $("#resultado").val(res.toString());
console.log(res.toString());
    
}  



</script>
</body>
</html>

*******************************************************************************/




