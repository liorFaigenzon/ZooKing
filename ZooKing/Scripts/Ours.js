//--------------
$('#s1').cycle({
    fx: 'scrollDown',
    speed: 3000,
    timeout: 2000,
    pause: 1,
    random: 1
});
$('#s2').cycle({
    fx: 'scrollDown',
    speed: 2500,
    timeout: 2000,
    pause: 1,
    random: 1
});
$('#s3').cycle({
    fx: 'scrollDown',
    speed: 2000,
    timeout: 2000,
    pause: 1,
    random: 1
});
$('#s4').cycle({
    fx: 'scrollDown',
    speed: 3000,
    timeout: 2000,
    pause: 1,
    random: 1
});
//--------------
//function checkCookies() {
//var userRole = '@User.IsInRole("Admins")';
//if (userRole == "True") {
//    $('.Extra').css({ display: "normal" });
//}
//else {
//    $('.Extra').css({ display: "none" });
//}};
//--------------
$(document).ready(function () {
    $("button").click(function () {
        $("img").animate({
            height: 'toggle'
        });
    });
});