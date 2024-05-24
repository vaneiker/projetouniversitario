// Obtener el contexto del lienzo
var ctx = document.getElementById('myChart').getContext('2d');

// Configurar el gráfico inicial
var chart = new Chart(ctx, {
  type: 'line',
  data: {
    labels: [],
    datasets: [{
      label: 'Voltage',
      data: [],
      backgroundColor: 'rgba(54, 162, 235, 0.2)',
      borderColor: 'rgba(54, 162, 235, 1)',
      borderWidth: 1
    },
    {
      label: 'Temperature',
      data: [],
      backgroundColor: 'rgba(255, 99, 132, 0.2)',
      borderColor: 'rgba(255, 99, 132, 1)',
      borderWidth: 1
    }]
  },
  options: {
    scales: {
      y: {
        beginAtZero: true
      }
    }
  }
});

// Función para actualizar el gráfico con nuevos datos
function updateChart(data) {
  // Limpiar datos anteriores
  chart.data.labels = [];
  chart.data.datasets[0].data = [];
  chart.data.datasets[1].data = [];

  // Iterar sobre los nuevos datos y agregarlos al gráfico
  for (const key in data) {
    const element = data[key];
    // Combinar fecha y hora
    const dateTime = new Date(element.date + 'T' + element.time);
    // Formatear la fecha (por ejemplo, 'DD/MM/YYYY')
    const formattedDate = dateTime.toLocaleDateString();
    // Formatear la hora (por ejemplo, 'HH:MM:SS')
    const formattedTime = dateTime.toLocaleTimeString('en-US', {hour12: false});
    // Agregar fecha y hora como etiquetas
    chart.data.labels.push(formattedDate + ' ' + formattedTime);
    // Agregar el voltaje como dato
    chart.data.datasets[0].data.push(element.voltage);
    // Agregar la temperatura como dato
    chart.data.datasets[1].data.push(element.temperature);
  }

  // Actualizar el gráfico
  chart.update();
}

// Función para obtener los datos de la base de datos y actualizar el gráfico
function fetchDataAndRefreshChart(interval) {
  fetch('https://mikrotikadministrator-default-rtdb.firebaseio.com/systemhealth.json')
    .then(response => response.json())
    .then(data => {
      // Actualizar el gráfico con los nuevos datos
      updateChart(data);
    })
    .catch(error => {
      console.error('Error:', error);
    });
    
  // Llamar recursivamente a la función después del intervalo especificado
  setTimeout(fetchDataAndRefreshChart, interval * 5000, interval);
}

// Función para iniciar la actualización del gráfico con el intervalo ingresado por el usuario
function startChartUpdate() {   
  fetchDataAndRefreshChart(1);
}

// Al cargar la página, iniciar la actualización del gráfico automáticamente
window.onload = function() {
  startChartUpdate();
};