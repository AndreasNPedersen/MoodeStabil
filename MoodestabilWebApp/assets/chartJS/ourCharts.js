let chartOne = document.getElementById('chartOne').getContext('2d');
let chartTwo = document.getElementById('chartTwo').getContext('2d');

let studentsChart1 = new Chart(chartOne, {
    type: 'bar', // bar, bar horizontal: write indexAxis: 'y' in options{}, pie, line, doughnut, radar, polarArea
    data: {
        labels: ['29. Nov', '30. Nov', '1. Dec', '2. Dec'],
        datasets: [{
            label: 'Forsinkede Studerende',
            data: [
                5, 3, 1, 8
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
        labels: ['Ma', 'Ti', 'On', 'To'],
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