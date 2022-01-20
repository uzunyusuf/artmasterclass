var stokSayiLabels = [];
var stokSayiData = [];
var stokSayiColorBg = [];

$(function () {
    var currencyFunc = function (value, data) { return value + ' AUD';}
    createChartDonnutsByMorris('/Home/PriceTotalByLocation', 'priceTotalByLocation', currencyFunc);
    CreateChart('/Home/TotalOrderByLocation', 'totalOrderByLocation', null);
    CreateChart('/Home/PriceTotalByLocation', null, 'priceTotalByLocationLineChart');
});

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