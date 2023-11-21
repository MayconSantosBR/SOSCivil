import { Grid } from "ag-grid-community";

const columnDefs = [
    { field: "make" },
    { field: "model" },
    { field: "price" }
];

const rowData = [
    { make: "Toyota", model: "Celica", price: 35000 },
    { make: "Ford", model: "Mondeo", price: 32000 },
    { make: "Porsche", model: "Boxster", price: 72000 }
];

const gridOptions = {
    columnDefs: columnDefs,
    rowData: rowData
};

document.addEventListener('DOMContentLoaded', () => {
    const gridDiv: HTMLElement | null = document.querySelector('#myGrid');

    if (gridDiv) {
        new Grid(gridDiv, gridOptions);
    } else {
        console.error('Element with id "myGrid" not found.');
    }
});

