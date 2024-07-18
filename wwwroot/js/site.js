// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function searchPlayers() {
    // JavaScript code to filter players based on search query
    var input, filter, container, rows, name, i, txtValue;
    input = document.getElementById("searchBar");
    filter = input.value.toUpperCase();
    container = document.querySelector(".players-container");
    rows = container.getElementsByClassName("leader-row");

    for (i = 0; i < rows.length; i++) {
        name = rows[i].getElementsByTagName("h2")[0];
        txtValue = name.textContent || name.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            rows[i].style.display = "";
        } else {
            rows[i].style.display = "none";
        }
    }
}