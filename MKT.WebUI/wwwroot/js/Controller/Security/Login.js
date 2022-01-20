$(function () {
    particlesJS.load('particles-js', '/js/Controller/Security/particles-config.json', function () {
        
    });
});

var success = false;
var score = 0;
/*
grecaptcha.ready(function () {
    grecaptcha.execute('6LdYz_UUAAAAADfBRh-98uZm7Jp8d-CV6Cm5WJHA', { action: 'submit' })
        .then(function (token) {
            $.getJSON("/Admin/Security/RecaptchaV3Verify?token=" + token,
                function (data) {
                    success = data.success;
                    score = data.score;
                    if (data.success && data.score >= 0.6) {
                        $('#loginButton').prop('disabled', false);
                    } else {
                        // do nothing
                    }
                });
        });
});
*/