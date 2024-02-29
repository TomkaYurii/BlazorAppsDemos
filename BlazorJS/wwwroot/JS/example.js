function JSAlert() {
    alert("Hello");
}

function AddTableRow(elem, firstname, lastname) {
    let row = document.createElement("tr");

    let cell1 = document.createElement("td");
    let cell2 = document.createElement("td");
    cell1.innerText = firstname;
    cell2.innerText = lastname;

    row.append(cell1);
    row.append(cell2);
    elem.append(row);
} 

function FindSum(no1, no2) {
    sum = parseInt(no1) + parseInt(no2);
    return sum;
}

function GetNumber(noIndex) {
    var result = DotNet.invokeMethodAsync("BlazorJS", 'ReturnArrayAsync', parseInt(noIndex));
    result.then(function (val) {
        document.getElementById("noIndex").innerHTML = val;
    });
} 

function SayHello(name) {
    DotNet.invokeMethodAsync("BlazorJS", "ShowHello", name);
}

function CallCalculateMultiplication(no1, no2) {
    DotNet.invokeMethodAsync("BlazorJS", "CalculateMultiplication", parseInt(no1), parseInt(no2));
}

function CallCalculateDivision(no1, no2) {
    var result = DotNet.invokeMethodAsync("BlazorJS", "CalculateDivision", parseInt(no1), parseInt(no2));
    result.then(function (val) {
        document.getElementById("mResult").innerHTML = val;
    });
}

function CallClass(obj) {
    var result = obj.invokeMethodAsync("SayHello");
    result.then(function (val) {
        alert(val);
    });
}