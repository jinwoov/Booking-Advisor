const dictionary = {
    XSS: "Cross Site Scripting"
}


$(".vulnerable-box").click(function () {
    let headerText = $(this).text();
    $("main").css("height", "150vh");
    $("#cover-box").show();
    $(".vuln-title").text(dictionary[headerText]);
    $("#first-ss").attr("src", `../assets/Vulnerability/${headerText}.jpg`);
    $("#vuln-desc").text(`Screenshot of ${headerText} on Booking Advisor website.`)
});

$("#exit-box").click(function () {
    $("main").css("height", "90vh");
    $("#cover-box").hide();

});

$("#cover-box").hide();



