/*Todo JavaScript*/

/*=================================================
script que detecta el browser para actualizacion
===================================================*/
        $(document).ready(function () {

            var $buoop = { vs: { i: 10, f: 25, o: 17, s: 6, n: 9} };
            $buoop.ol = window.onload;
            window.onload = function () {
                try { if ($buoop.ol) $buoop.ol(); } catch (e) { }
                var e = document.createElement("script");
                e.setAttribute("type", "text/javascript");
                e.setAttribute("src", "../../Js/update.js");
                document.body.appendChild(e);
            }
        });

	
	
/*===================================
		FUNCION MOSTRAR Y OCULTAR
===================================*/

        function muestra_oculta(id) {
            if (document.getElementById) { //se obtiene el id
                var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
                el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
            }
        }
        function communication_message(id) {
            if (document.getElementById) { //se obtiene el id
                var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
                el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
            }
        }
        function new_comments(id) {
            if (document.getElementById) { //se obtiene el id
                var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
                el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
            }
        }
        function comentario_steps(id) {
            if (document.getElementById) { //se obtiene el id
                var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
                el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
            }
        }
        function box_email(id) {
            if (document.getElementById) { //se obtiene el id
                var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
                el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
            }
        }
        function box_number(id) {
            if (document.getElementById) { //se obtiene el id
                var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
                el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
            }
        }
        function addresses_contenido(id) {
            if (document.getElementById) { //se obtiene el id
                var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
                el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
            }
        }
        window.onload = function () {/*hace que se cargue la función lo que predetermina que div estará oculto hasta llamar a la función nuevamente*/
            muestra_oculta('p_of_p'); /* "contenido_a_mostrar" es el nombre que le dimos al DIV */
            muestra_oculta('m_office');
            muestra_oculta('gov_f');
            tabla_mostrar('mostrar_tabla'); /* "contenido_a_mostrar" es el nombre que le dimos al DIV */
            communication_message('message_communication'); /* "contenido_a_mostrar" es el nombre que le dimos al DIV */
            new_comments('comments_new'); /* "contenido_a_mostrar" es el nombre que le dimos al DIV */
            comentario_steps('steps_comentario'); /* "contenido_a_mostrar" es el nombre que le dimos al DIV */
            box_email('email_box'); /* "contenido_a_mostrar" es el nombre que le dimos al DIV */
            box_number('number_box'); /* "contenido_a_mostrar" es el nombre que le dimos al DIV */
            addresses_contenido('contenido_addresses'); /* "contenido_a_mostrar" es el nombre que le dimos al DIV */
        }

        function tabla_mostrar(id) {
            if (document.getElementById) { //se obtiene el id
                var el = document.getElementById(id); //se define la variable "el" igual a nuestro div
                el.style.display = (el.style.display == 'none') ? 'block' : 'none'; //damos un atributo display:none que oculta el div
            }
        }


        function showProcessing() {
            document.getElementById('processing').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
        }

        function hideProcessing() {
            document.getElementById('processing').style.display = 'none';
            document.getElementById('fade').style.display = 'none';
        }

        function showMessage_steps() {
            document.getElementById('message_steps').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
        }

        function hideMessage_steps() {
            document.getElementById('message_steps').style.display = 'none';
            document.getElementById('fade').style.display = 'none';
        }

    //<!--FIN MOSTRAR Y OCULTAR-->
	
	//  The function to change the class
        var changeClass = function (r, className1, className2) {
            var regex = new RegExp("(?:^|\\s+)" + className1 + "(?:\\s+|$)");
            if (regex.test(r.className)) {
                r.className = r.className.replace(regex, ' ' + className2 + ' ');
            }
            else {
                r.className = r.className.replace(new RegExp("(?:^|\\s+)" + className2 + "(?:\\s+|$)"), ' ' + className1 + ' ');
            }
            return r.className;
        };

       
        