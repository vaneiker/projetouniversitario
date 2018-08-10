
var app=new Vue({
    el: '#aplicacion',
    data:{
      codigo: ''
     ,descripcion: ''
     ,precio: ''
     ,articulos:
     [{
       codigo:1
       ,descripcion: 'Habichuela Negras'
       ,precio: 34
      }]
    },

    methods: {
      agregarArticulo: function() {
        this.articulos.push({
                              codigo: this.codigo,
                              descripcion: this.descripcion,
                              precio: this.precio
                            });
        this.codigo = '';
        this.descripcion = '';
        this.precio = '';
      }
    }
  })

