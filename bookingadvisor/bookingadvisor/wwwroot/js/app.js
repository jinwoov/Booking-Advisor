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
   \\____)|_) \\_)`, "color:#febb02; background:black; font-family: monospace");
console.log("%cWelcome to the Booking Advisor web application. Goal is to exploit as much as you can!!", "color:#febb02; background:black; font-family: monospace");
const hotelList = ["Place", "House", "Hotel", "Inn", "Hostel"];



function givemehint() {
    return "All of the challenges within this website should be able to perform within the inspect tool.";
}


function findTheDeal() {
    let input_result = $("#search-box").val();
    $("#output-deal").html(`The result of ${input_result}`);
    return input_result;
}

function createDictionary() {
    var dict = {};
    dict["Korea"] = "While only 60 years ago South Korea was considered a developing country, it’s now one of Asia’s economic and cultural leaders. Super-chic Seoul combines modernism with ancient history; coastal Busan serves up rugged beach spots; and Jeju Island wows with volcanic landscapes and towering mountains.";
    dict["Japan"] = "In the Land of the Rising Sun, ancient temples sit alongside neon wonderlands and shinto shrines offer pockets of peace amid metropolises. Add tea ceremonies, snow monkeys, sushi, kimonos, and karaoke to the mix, and you’ve got one of the world’s most fascinating countries.";
    dict["Germany"] = "From the fairy-tale castles and medieval villages of Bavaria to the Rhine Valley's UNESCO-listed landscapes and the storied monuments of Berlin, Germany has many faces. Steeped in history, cities like Cologne, Frankfurt, and Hamburg are also among the coolest cultural hubs in Europe.";
    dict["England"] = "Home to ancient market towns and iconic cities, rolling green hills and dramatic coastlines, England is the place to be. Soak up the cosmopolitan vibe of Liverpool, Manchester and Bristol; be captivated by ancient legends in medieval York and the spa city of Bath; and explore England’s largest National Park (the Lake District) or Dorset’s majestic Jurassic Coast. Get up-close-and-personal with royalty in Windsor, explore the castles of Kent, or wander the hallowed halls of Oxford University.";
    dict["Mexico"] = "With 26 UNESCO-declared world heritage sites, charming colonial towns and dozens of thrilling cities, there's plenty to explore in this country of 109 million. Outside the cities, stunning Pacific beaches, stark deserts, mangrove swamps and swimming holes provide all you need for a relaxing, romantic or adventurous vacation. Captivating, cosmopolitan and chaotic Mexico City and the 32 states offer an incredible abundance of experiences, from laid-back and leisurely to upbeat to adrenalin-charging."
    dict["India"] = "From the beaches of sun-soaked Goa to the frenetic bazaars of Mumbai, India offers wealth of vastly different, yet equally enthralling, experiences. Explore the sparkling lakes and palaces of Udaipur, watch traditional Indian dance in Kochi, or buy brilliantly-colored silk saris at a market in Varanasi… no matter how much you travel in India, you’ll always find more to discover in this vibrant, fascinating country.";
    dict["Jordan"] = "Jordan, an Arab nation on the east bank of the Jordan River, is defined by ancient monuments, nature reserves and seaside resorts. It’s home to the famed archaeological site of Petra, the Nabatean capital dating to around 300 B.C. Set in a narrow valley with tombs, temples and monuments carved into the surrounding pink sandstone cliffs, Petra earns its nickname, the 'Rose City.'";
    dict["New York"] = "Luxe hotels. Gritty dive bars. Broadway magic. Side-street snack carts. Whether you’re a first-time traveler or a long-time resident, NYC is a city that loves to surprise. The unrivaled mix of iconic arts spaces, endless shopping experiences, architectural marvels, and proudly distinct neighborhoods — along with the city’s accessible 24/7 transport — means there’s always more to explore in the five boroughs.";
    dict["Philippines"] = "With more than 7,000 islands consisting of rice paddies, volcanos, mega-metropolises, world-class surf spots, and endemic wildlife, the Philippines is one of the most dazzling and diverse countries in all of Asia. Not to mention, it’s home to some of the world’s best beaches, too";

    return dict;
}

const appendInfo = () => {
    const location = $(".tour-title").text();
    $(".tour-desc").text(dictionary[location]);   
}

const searchFunc = () => {
    let output = findTheDeal();
    if (output.includes("<script>") || output.includes("<")) {
        return;
    }
    spinner();
    let searchLocation = $("#search-box").val();
    let firstL = searchLocation[0].toUpperCase();
    let restW = searchLocation.substr(1);
    searchLocation = firstL + restW;

    $("main").css("height", "100%");
    mainVisible();
    $("#table-box").empty();
    for (let i = 0; i < hotelList.length; i++) {
        $("#table-box").append(`<div class='hotel' id='hotel${i}'></div>`);
        $(`#hotel${i}`).append("<img src='/assets/hotel.png' />");
        $(`#hotel${i}`).append(`<div class='tour-content' id='tour-content${i}'></div>`);
        $(`#tour-content${i}`).append(`<h1 class='tour-title'>${searchLocation} ${hotelList[i]}</h1>`);
    }
}

const mainVisible = async () => {
    $("main").hide();
    await sleep(1000);
    $("main").show();
}

const spinner = async () => {
    $(".outer-spinner").show();
    await sleep(1000);
    $(".outer-spinner").hide();
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

$("#search-box").keypress(function (event) {
    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '13') {
        searchFunc();
    }
})



// Main
$("#find-deal").click(searchFunc);
let dictionary = createDictionary();
$("document").ready(appendInfo);

