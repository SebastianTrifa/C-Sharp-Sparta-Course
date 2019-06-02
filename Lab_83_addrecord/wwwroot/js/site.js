// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


function Input() {
    var c = document.getElementById("page").value;
    console.log(c);
    window.location = "?page=" + c;
};