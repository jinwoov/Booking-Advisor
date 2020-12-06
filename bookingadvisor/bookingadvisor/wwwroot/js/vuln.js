
$(".vulnerable-box").click(function() {
    let header = $(this).text();
    $("#cover-box").show();
    $(".vuln-title").text(header);
});

$("#exit-box").click(function () {
    $("#cover-box").hide();

});

$("#cover-box").hide();



