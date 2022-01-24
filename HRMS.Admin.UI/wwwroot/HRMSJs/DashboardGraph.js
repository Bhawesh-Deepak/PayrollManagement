﻿ 
    var blue = "#348fe2",
    blueLight = "#5da5e8",
    blueDark = "#1993E4",
    aqua = "#49b6d6",
    aquaLight = "#6dc5de",
    aquaDark = "#3a92ab",
    green = "#00acac",
    greenLight = "#33bdbd",
    greenDark = "#008a8a",
    orange = "#f59c1a",
    orangeLight = "#f7b048",
    orangeDark = "#c47d15",
    dark = "#2d353c",
    grey = "#b6c2c9",
    purple = "#727cb6",
    purpleLight = "#8e96c5",
    purpleDark = "#5b6392",
    red = "#ff5b57";
    var white = "rgba(255,255,255,1.0)",
    fillBlack = "rgba(45, 53, 60, 0.6)",
    fillBlackLight = "rgba(45, 53, 60, 0.2)",
    strokeBlack = "rgba(45, 53, 60, 0.8)",
    highlightFillBlack = "rgba(45, 53, 60, 0.8)",
    highlightStrokeBlack = "rgba(45, 53, 60, 1)",
    fillBlue = "rgba(52, 143, 226, 0.6)",
    fillBlueLight = "rgba(52, 143, 226, 0.2)",
    strokeBlue = "rgba(52, 143, 226, 0.8)",
    highlightFillBlue = "rgba(52, 143, 226, 0.8)",
    highlightStrokeBlue = "rgba(52, 143, 226, 1)",
    fillGrey = "rgba(182, 194, 201, 0.6)",
    fillGreyLight = "rgba(182, 194, 201, 0.2)",
    strokeGrey = "rgba(182, 194, 201, 0.8)",
    highlightFillGrey = "rgba(182, 194, 201, 0.8)",
    highlightStrokeGrey = "rgba(182, 194, 201, 1)",
    fillGreen = "rgba(0, 172, 172, 0.6)",
    fillGreenLight = "rgba(0, 172, 172, 0.2)",
    strokeGreen = "rgba(0, 172, 172, 0.8)",
    highlightFillGreen = "rgba(0, 172, 172, 0.8)",
    highlightStrokeGreen = "rgba(0, 172, 172, 1)",
    fillPurple = "rgba(114, 124, 182, 0.6)",
    fillPurpleLight = "rgba(114, 124, 182, 0.2)",
    strokePurple = "rgba(114, 124, 182, 0.8)",
    highlightFillPurple = "rgba(114, 124, 182, 0.8)",
    highlightStrokePurple = "rgba(114, 124, 182, 1)",
        randomScalingFactor = function () { return Math.round(100 * Math.random()) };
    $(document).ready(function () {
        BindMonthlyAttendanceGraph();
        MonthlyGrossSalaryIncentive();
        NoofEmployeeSalaryPaid();
        NoofEmployeeIncentivePaid();
    });
    $("#AssesmentYear1").change(function () {
        BindMonthlyAttendanceGraph($("#AssesmentYear1").val());
    });
    $("#AssesmentYear2").change(function () {
        MonthlyGrossSalaryIncentive($("#AssesmentYear2").val());
    });
    $("#AssesmentYear3").change(function () {
        NoofEmployeeSalaryPaid($("#AssesmentYear3").val());
    });
    $("#AssesmentYear4").change(function () {
        NoofEmployeeIncentivePaid($("#AssesmentYear4").val());
    });
    function BindMonthlyAttendanceGraph(event) {
        debugger;
        var ctx = document.getElementById("myChart-4").getContext("2d");
        var data = {
        labels: ["Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Jan", "Feb", "Mar"],
            datasets: [{
        label: "Total Present",
                backgroundColor: fillBlue,
                data: [50000, 72000, 40000, 20000, 30000, 45000, 52000, 66000, 41000, 23000, 34000, 47000]
            }, {
        label: "Total Absent",
                backgroundColor: strokePurple,
                data: [5000, 7000, 4000, 2000, 3000, 4500, 5000, 7000, 4000, 2000, 3000, 4500]
            }, {
        label: "Total Employees",
                backgroundColor: orangeLight,
                data: [54000, 71000, 44000, 23000, 37000, 45400, 56000, 67000, 42000, 23000, 38000, 49000]
            }]
        };
        var myBarChart = new Chart(ctx, {
        type: 'bar',
            data: data,
            options: {
        barValueSpacing: 10,
                scales: {
        yAxes: [{
        ticks: {
        min: 0,
                        }
                    }]
                }
            }
        });
    }
    function MonthlyGrossSalaryIncentive(event) {
        var ctx = document.getElementById("myChart-5").getContext("2d");
        var data = {
        labels: ["Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Jan", "Feb", "Mar"],
            datasets: [{
        label: "Gross Salary",
                backgroundColor: "#99ccff",
                data: [50000, 71000, 40000, 20000, 30000, 45000, 52000, 66000, 41000, 23000, 34000, 47000]
            }, {
        label: "Performance Incentives",
                backgroundColor: "#b3d9ff",
                data: [5000, 7000, 4000, 2000, 3000, 4500, 5000, 7000, 4000, 2000, 3000, 4500]
            }]
        };

        var myBarChart = new Chart(ctx, {
        type: 'bar',
            data: data,
            options: {
        barValueSpacing: 10,
                scales: {
        yAxes: [{
        ticks: {
        min: 0,
                        }
                    }]
                }
            }
        });
    }
    function NoofEmployeeSalaryPaid(event) {
    var xValues = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    var yValues = [0, 5000, 8000, 10000, 4000, 3600, 4400, 5700, 0, 1400, 1700, 3300];
    var barColors = [
        "#b91d47",
        "#EEE9E9",
        "#E2CFCF",
        "#EABCBC",
        "#F08080",
        "#E8BDBA",
        "#E7DDDC",
        "#FFE7E4",
        "#F9EDEC",
        "#C66957",
        "#DBD0CC",
        "#FFD3B5"
    ];
    new Chart("myChart-2", {
        type: "doughnut",
        data: {
        labels: xValues,
            datasets: [{
        backgroundColor: barColors,
                data: yValues
            }]
        },
        options: {
        title: {
        display: false,
                text: "World Wide Wine Production 2018"
            }
        }
    });
    }
    function NoofEmployeeIncentivePaid(event) {
        var xValues = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var yValues = [0, 5000, 8000, 10000, 4000, 3600, 4400, 5700, 0, 1400, 1700, 3300];
        var barColors = [
            "#b91d47",
            "#EEE9E9",
            "#E2CFCF",
            "#EABCBC",
            "#F08080",
            "#E8BDBA",
            "#E7DDDC",
            "#FFE7E4",
            "#F9EDEC",
            "#C66957",
            "#DBD0CC",
            "#FFD3B5"
        ];
        new Chart("myChart-3", {
        type: "doughnut",
            data: {
        labels: xValues,
                datasets: [{
        backgroundColor: barColors,
                    data: yValues
                }]
            },
            options: {
        title: {
        display: false,
                    text: "World Wide Wine Production 2018"
                }
            }
        });
    }

 