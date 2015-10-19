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
$(document).ready(function () {
    $("button").click(function () {
        $("img").animate({
            height: 'toggle'
        });
    });
});

$(document).ready(function () {
    var AvgShow = (document.getElementById("avg"));

    $("#btnAjax").click(function () {
        $.ajax({
            url: "/Animal/avg",
            success: successFunc,
            error: errorFunc
        });
        

        function successFunc(data, status) {
            AvgShow.innerText =(data.data);
        }

        function errorFunc(data, status) {
            alert('error' + data);
        }
    });
});
