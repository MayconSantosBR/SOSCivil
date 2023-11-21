"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ag_grid_community_1 = require("ag-grid-community");
var columnDefs = [
    { field: "make" },
    { field: "model" },
    { field: "price" }
];
var rowData = [
    { make: "Toyota", model: "Celica", price: 35000 },
    { make: "Ford", model: "Mondeo", price: 32000 },
    { make: "Porsche", model: "Boxster", price: 72000 }
];
var gridOptions = {
    columnDefs: columnDefs,
    rowData: rowData
};
document.addEventListener('DOMContentLoaded', function () {
    var gridDiv = document.querySelector('#myGrid');
    if (gridDiv) {
        new ag_grid_community_1.Grid(gridDiv, gridOptions);
    }
    else {
        console.error('Element with id "myGrid" not found.');
    }
});
