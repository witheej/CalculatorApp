// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var isResultState = true;

var connection = new signalR.HubConnectionBuilder().withUrl("/calculatorHub").build(); 

connection.start();

connection.on("ReceiveMessage", function (calculationResult) { 
    $('.calculator-screen').text(calculationResult);
    isResultState = true;
}); 





function isNumber(x) {
    return /^[0-9]$/.test(x);
}

function isOperator(x) {
    return /^[-*/+]$/.test(x);
}

function isDecimal(x) {
    return /^\.$/.test(x);
}

function handleNumberPress(x) {
    let s = $('.calculator-screen');
    s.text(s.text() + x);
}

function handleOperatorPress(x) {
    let s = $('.calculator-screen');

    if (s.text().length > 0) {
        if (!/[-\/+*]/.test(s.text())) {
            if (isNumber(s.text().substr(-1))) {
                s.text(s.text() + x);
            }
        }
    }
}

function handleDecimalPress(x) {
    let s = $('.calculator-screen');

    if (s.text().length > 0) {
        if (!/\.[0-9]+$/.test(s.text())) {
            if (isNumber(s.text().substr(-1))) {
                s.text(s.text() + x);
            }
        }
    }
}

$(document).ready(function () {
    var $screen = $('.calculator-screen');

    $('.calculator-btn:not(.equals-btn)').on('click', function () {
        if (isResultState) {
            $screen.text("");
            isResultState = false;
        }

        var btnSymbol = $(this).text();

        if (isNumber(btnSymbol)) {
            handleNumberPress(btnSymbol);
        } else if (isOperator(btnSymbol)) {
            handleOperatorPress(btnSymbol);
        } else if (isDecimal(btnSymbol)) {
            handleDecimalPress(btnSymbol);
        }
    });

    $('.equals-btn').on('click', function () {
        connection.invoke("SubmitExpression", $screen.text());
    });
});



