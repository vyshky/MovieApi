// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// https://www.publicdomainpictures.net/pictures/280000/velka/not-found-image-15383864787lu.jpg

$("img").on("error", function () {  
    console.log("error");
    $(this).attr('src',"image/errorImg.jpg")
    console.log("error");
})

console.log("error")