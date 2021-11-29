let chartOne = document.getElementById('chartOne').getContext('2d');
let chartTwo = document.getElementById('chartTwo').getContext('2d');

let studentsChart1 = new Chart(chartOne, {
    type: 'bar', // bar, bar horizontal: write indexAxis: 'y' in options{}, pie, line, doughnut, radar, polarArea
    data: {
        labels: ['29. TEMP', '30. TEMP', '1. TEMP', '2. TEMP', '3. TEMP'],
        datasets: [{
            label: 'Forsinkede Studerende Denne Uge',
            data: [
                5, 3, 1, 4, 6
            ],
            backgroundColor: '#0F5F68',
            borderColor: '#071719'
        }]
    },
    options: {}
})

let studentsChart2 = new Chart(chartTwo, {
    type: 'pie', // bar, horizontalBar, pie, line, doughnut, radar, polarArea
    data: {
        labels: ['Ma', 'Ti', 'On', 'To', 'Fr'],
        datasets: [{
            label: 'Gennemsnitlig Forsinkelse',
            data: [
                5, 3, 1, 8
            ],
            backgroundColor: [
                '#0F5F68',
                '#0D2B30',
                '#682242',
                '#FF7000'
            ]
        }]
    },
    options: {}
})

function updateCharts(piData) {
    // var filtered;
    // piData.forEach(d => {
    //     var Date = d.date;
    // });
    
    // // Set Labels to the last 5 days and set the data in the chart to the data collected
    // for (var i = 0; i < 4; i++) { 
    //     studentsChart1.data.labels[i] = piData.dateRange[i];
    //     studentsChart1.data.datasets[0].data[i] = piData.data[i];
    // }


}