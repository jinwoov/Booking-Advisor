$(".outer-spinner").hide();

const redirectToLogin = () => {
    window.location = "/Account/login";
}

$("#login-button").click(redirectToLogin);
$("#register-button").click((e) => {
    window.location = "/Account/Register";
});
