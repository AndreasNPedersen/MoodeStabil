let chartOne = document.getElementById('chartOne').getContext('2d');
let chartTwo = document.getElementById('chartTwo').getContext('2d');

let chartLabels = ["-", "-", "-", "-", "-"];
let chartData = [0, 0, 0, 0, 0];

let piDatas = [];

let dayOneData = [];
let dayTwoData = [];
let dayThreeData = [];
let dayFourData = [];
let dayFiveData = [];

let studentsChart1;
let chart1Created = false;

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
    this.piDatas = piData;
    // Push first dataset to begin process of checking against dates
    dayOneData.push(piData[0]);
    
    // Create date variables that we use to sort data
    const d = new Date(dayOneData[0].date);
    let date1 = d.getDate();
    let date2 = 0;
    let date3 = 0;
    let date4 = 0;
    let date5 = 0;
    
    // Update chart day one with initial data
    chartLabels[0] = dayOneData[0].date;
    chartData[0] = dayOneData.length;

    // This absolute chonker sorts the contents of the PiData into different days, 
    // so we can display them nicely in our charts!
    this.piDatas.forEach(p => {
        // Update data arrays
        const pDate = new Date(p.date);

        if(pDate.getDate() == date1)
        {
            dayOneData.push(p);
            console.log("Pushed to Day One Data");

            // Update chart with initial data
            chartLabels[0] = date1;
            // chartLabels[1] = date1+1;
            // chartLabels[2] = date1+2;
            // chartLabels[3] = date1+3;
            // chartLabels[4] = date1+4;

            chartData[0] = dayOneData.length;
        }

        else if (dayTwoData.length == 0 || pDate.getDate() == date2)
        {
            dayTwoData.push(p);
            tempD = new Date(dayTwoData[0].date);
            date2 = tempD.getDate();

            // Update chart with data
            chartLabels[1] = date2;
            chartData[1] = dayTwoData.length;
        }

        else if (dayThreeData.length == 0 || pDate.getDate() == date3)
        {
            dayThreeData.push(p);
            tempD = new Date(dayThreeData[0].date);
            date3 = tempD.getDate();

            // Update chart with data
            chartLabels[2] = date3;
            chartData[2] = dayThreeData.length;
        }

        else if (dayFourData.length == 0 || pDate.getDate() == date4)
        {
            dayFourData.push(p);
            tempD = new Date(dayFourData[0].date);
            date4 = tempD.getDate();

            // Update chart with data
            chartLabels[3] = date4;
            chartData[3] = dayFourData.length;
        }

        else if (dayFiveData.length == 0 || pDate.getDate() == date5)
        {
            dayFiveData.push(p);
            tempD = new Date(dayFiveData[0].date);
            date5 = tempD.getDate();

            // Update chart with data
            chartLabels[4] = date5;
            chartData[4] = dayFiveData.length;
        }
    });

    if (chart1Created == false)
    {
        chart1Created = true;

        studentsChart1 = new Chart(chartOne, {
            type: 'bar', // bar, bar horizontal: write indexAxis: 'y' in options{}, pie, line, doughnut, radar, polarArea
            data: {
                labels: [chartLabels[0], chartLabels[1], chartLabels[2], chartLabels[3], chartLabels[4]],
                datasets: [{
                    label: 'Forsinkede Studerende Denne Uge',
                    data: [
                        chartData[0], chartData[1], chartData[2], chartData[3], chartData[4]
                    ],
                    backgroundColor: '#0F5F68',
                    borderColor: '#071719'
                }]
            },
            options: {}
        })
    }
}