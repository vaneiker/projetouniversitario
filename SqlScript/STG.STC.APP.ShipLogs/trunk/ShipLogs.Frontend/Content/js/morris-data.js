$(function() {

    //Morris.Bar({
//        element: 'morris-bar-chart',
//        data: [{
//            y: 'Abr-18',
//            a: 100
//        }, {
//            y: 'May-18',
//            a: 75
//        }, {
//            y: 'Jun-18',
//            a: 50
//        }, {
//            y: 'Jul-18',
//            a: 75
//        }, {
//            y: 'Ago-18',
//            a: 50
//        }, {
//            y: 'Sep-18',
//            a: 75
//        }, {
//			y: 'Oct-18',
//            a: 75
//        }, {
//			y: 'Nov-18',
//            a: 75
//        }, {
//			y: 'Dic-18',
//            a: 75
//        }, {
//			y: 'Ene-19',
//            a: 75
//        }, {
//			y: 'Feb-19',
//            a: 75
//        }, {
//			y: 'Mar-19',
//            a: 75
//        }, {
//            y: 'Abr-19',
//            a: 100
//        }],
//        xkey: 'y',
//        ykeys: ['a'],
//        labels: ['Series A'],
//        hideHover: 'auto',
//        resize: true
//    });
	
	Morris.Bar({
	  element: 'morris-bar-chart',
	  data: [
		{x: 'Abr-18', y: 0.10},
		{x: 'May-18', y: 0.10},
		{x: 'Jun-18', y: 0.10},
		{x: 'Jul-18', y: 0.10},
		{x: 'Ago-18', y: 0.10},
		{x: 'Sep-18', y: 0.10},
		{x: 'Oct-18', y: 0.10},
		{x: 'Nov-18', y: 0.10},
		{x: 'Dic-18', y: 0.10},
		{x: 'Ene-19', y: 0.10},
		{x: 'Feb-19', y: 0.10},
		{x: 'Mar-19', y: 0.10},
		{x: 'Abr-19', y: 1}
	  ],
	  xkey: 'x',
	  ykeys: ['y'],
	  labels: ['Y'],
	  xLabelMargin: 0
	});


var paper = new Raphael('graph_rect', 200, 200);
var rect = paper.rect(100, 10, 30, 150).attr({'fill':'#005588'});
rect.attr({'r': 3});

	
	
	
   // Morris.Bar({
//        element: 'morris-bar-chart',
//        data: [{
//            y: '2006',
//            a: 100,
//            b: 90
//        }, {
//            y: '2007',
//            a: 75,
//            b: 65
//        }, {
//            y: '2008',
//            a: 50,
//            b: 40
//        }, {
//            y: '2009',
//            a: 75,
//            b: 65
//        }, {
//            y: '2010',
//            a: 50,
//            b: 40
//        }, {
//            y: '2011',
//            a: 75,
//            b: 65
//        }, {
//            y: '2012',
//            a: 100,
//            b: 90
//        }],
//        xkey: 'y',
//        ykeys: ['a', 'b'],
//        labels: ['Series A', 'Series B'],
//        hideHover: 'auto',
//        resize: true
//    });
    
});

$(function() {
Morris.Bar({
	  element: 'morris-bar-chart2',
	  data: [
		{x: 'Abr-18', y: 0.10},
		{x: 'May-18', y: 0.10},
		{x: 'Jun-18', y: 0.10},
		{x: 'Jul-18', y: 0.10},
		{x: 'Ago-18', y: 0.10},
		{x: 'Sep-18', y: 0.10},
		{x: 'Oct-18', y: 0.10},
		{x: 'Nov-18', y: 0.10},
		{x: 'Dic-18', y: 0.10},
		{x: 'Ene-19', y: 0.10},
		{x: 'Feb-19', y: 0.10},
		{x: 'Mar-19', y: 0.10},
		{x: 'Abr-19', y: 1}
	  ],
	  xkey: 'x',
	  ykeys: ['y'],
	  labels: ['Y'],
	  xLabelMargin: 0
	});


var paper = new Raphael('graph_rect', 200, 200);
var rect = paper.rect(100, 10, 30, 150).attr({'fill':'#005588'});
rect.attr({'r': 3});

	
	
    
});


$(function() {
Morris.Bar({
	  element: 'morris-bar-chart3',
	  data: [
		{x: 'Abr-18', y: 0.10},
		{x: 'May-18', y: 0.10},
		{x: 'Jun-18', y: 0.10},
		{x: 'Jul-18', y: 0.10},
		{x: 'Ago-18', y: 0.10},
		{x: 'Sep-18', y: 0.10},
		{x: 'Oct-18', y: 0.10},
		{x: 'Nov-18', y: 0.10},
		{x: 'Dic-18', y: 0.10},
		{x: 'Ene-19', y: 0.10},
		{x: 'Feb-19', y: 0.10},
		{x: 'Mar-19', y: 0.10},
		{x: 'Abr-19', y: 1}
	  ],
	  xkey: 'x',
	  ykeys: ['y'],
	  labels: ['Y'],
	  xLabelMargin: 0
	});


var paper = new Raphael('graph_rect', 200, 200);
var rect = paper.rect(100, 10, 30, 150).attr({'fill':'#005588'});
rect.attr({'r': 3});

	
	
    
});
