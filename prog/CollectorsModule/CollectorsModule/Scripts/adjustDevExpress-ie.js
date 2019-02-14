$('.dxgvCommandColumn.dxgv').closest('td').find('input').each(function() {
   $("<input type='check' />").attr({ id: this.id, style: "opacity:0;width:1px;height:1px;position:relative;background-color:transparent;display:block;margin:0;padding:0;border-width:0;font-size:0pt;", readonly: "readonly" }).insertBefore(this);
}).remove();