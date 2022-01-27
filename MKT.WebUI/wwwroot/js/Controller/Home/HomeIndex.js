var stokSayiLabels = [];
var stokSayiData = [];
var stokSayiColorBg = [];

$(function () {
    let currencyFunc = function (value, data) { return value + ' AUD';}
    createChartDonnutsByMorris('/Home/PriceTotalByLocation', 'priceTotalByLocation', currencyFunc);
    CreateChart('/Home/TotalOrderByLocation', 'totalOrderByLocation', null);
    CreateChart('/Home/PriceTotalByLocation', null, 'priceTotalByLocationLineChart');

    let apexDailyFunc = function(value) { return value + " $"; }
    apexLinechart("/Home/DailyTotalEarning", "dailyEarningChart",apexDailyFunc);
});

function apexLinechart(url, elemId, formatFunc = null) {
    $.get(url, function(data, status) {
        let dataArray = [];
        let labelArray = [];
        $.each(data, function(index, value) {
            dataArray.push(value.value);
            labelArray.push(value.label);
        });
        let options = {
            series: [
                {
                    name: "Daily Income",
                    data: dataArray
                }
            ],
            chart: {
                type: 'line',
                height: 350,
                zoom: { enabled: false }
            },
            dataLabes: { enabled: false },
            stroke: { curve: 'smooth' },
            grid: {
                row: {
                    colors: ['#f3f3f3', 'transparent'], // takes an array which will be repeated on columns
                    opacity: 0.5
                },
            },
            xaxis: { categories: labelArray }
        };

        if (formatFunc != null) {
            options.yaxis = { labels: { formatter: formatFunc } };
        }

        let chart = new ApexCharts(document.querySelector('#'+elemId), options);
        chart.render();
    });
}

function createChartDonnutsByMorris(url, elemId, formatFunc = null) {
    $.get(url, function (data, status) {
        let dataArray = [];
        let colorPoolbg = [];
        $.each(data, function (index, value) {
            dataArray.push({
                label: value.label,
                value: value.value,
            });
        });
        Morris.Donut({
            element: elemId,
            data: dataArray,
            formatter: formatFunc == null ? function (value, data) { return value } : formatFunc,
            colors: colorPool
        });
    });
}

function CreateChart(url, pieCanvasElemId, barCanvasElemId) {
    $.get(url, function (data, status) {
        let pieCanvas = pieCanvasElemId !== '' && pieCanvasElemId !== null ? document.getElementById(pieCanvasElemId).getContext('2d') : null;
        let barCanvas = barCanvasElemId !== '' && barCanvasElemId !== null ? document.getElementById(barCanvasElemId).getContext('2d') : null;
        let labelArray = [];
        let dataArray = [];
        let colorPoolbg = [];
        $.each(data, function (index, value) {
            labelArray.push(value.label);
            dataArray.push(value.value);
            colorPoolbg.push(index >= colorPool.length ? colorPool[Math.floor(Math.random() * colorPool.length)] : colorPool[index]);
        });
        displayCharts(pieCanvas, barCanvas, labelArray, dataArray, colorPoolbg);
    });
}


function displayCharts(piectx, barctx, labels, data, colors) {
    let showLegend = labels.length <= 20;
    let config = {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [
                {
                    'data': data,
                    "backgroundColor": colors
                }]
        },
        options: {
            responsive: true,
            tooltips: {
                callbacks: {
                    label: function (tooltipItem, d) {
                        debugger;
                        return data.labels[tooltipItem.index] + ' - ' + tooltipItem.yLabel + ' - my text';
                    }
                }
            },
            legend: {
                display: showLegend,
                labels: {
                    fontColor: 'rgb(255, 99, 132)'
                }
            }
        }
        
    }
    if (piectx != null) {
        let pieChart = new Chart(piectx, config);
        var a = 3;
    }

    let minValue = Math.min.apply(Math, data);
    if (barctx != null) {
        let datasets = [];
        $.each(data, function(index, item) {
            datasets.push({
                label: labels[index],
                backgroundColor: colors[index],
                data: [data[index]]
            });
        });
        new Chart(barctx,
            {
                type: 'bar',
                data: {
                    labels: ['Price By Location'],
                    datasets: datasets
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'bottom',
                        },
                        title: {
                            display: true,
                            text: 'Price by Location'
                        }
                    }
                }

            });
    }

}