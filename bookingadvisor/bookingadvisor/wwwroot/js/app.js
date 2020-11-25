'use strict';
console.log(`%c
         __    To Mochi the best dog!
        /  \\
       / ..|\\
      (_\\  |_)
      /  \\@' 
     /     \\
_   /  ''   |
 \\\\/  \\  |_\\\\
  \\   /_ || \\\\_
   \\____)|_) \\_)`, "color:#febb02; background:black; font-family: monospace")
console.log("%cWelcome to the Booking Advisor web application. Goal is to exploit as much as you can!!", "color:#febb02; background:black; font-family: monospace");

function givemehint() {
    return "All of the challenges within this website should be able to perform within the inspect tool.";
}

$("#find-deal").click(findTheDeal);

function findTheDeal() {
    let input_result = $(this).parent().children("input").val();
    $("#output-deal").html(`The result of ${input_result}`)
}