//login form validations
$("#loginForm").on("submit", function () {

    var email = $('#email').val();
    var password = $('#password').val();

    
    if (email == "") {
        $('#errorEmail').text("Please enter email.");
        return false;
    } 

    if (password == "") {
        $('#errorPassword').text("Please enter password.");
        return false;
    }
    return true;
});

$("#email").blur(function () {
    var email = $('#email').val();
    
    if (email == "") {
        $('#errorEmail').text("Please enter email.");
    } 
});

$("#password").blur(function () {
    var password = $('#password').val();

    if (password == "") {
        $('#errorPassword').text("Please enter password.");
    }
});

$("#email").focus(function () {
    $('#errorEmail').text("");
});

$("#password").focus(function () {
    $('#errorPassword').text("");
});


//Registration form vaidation

$("#regForm").submit(function (event) {

    

    var password = $('#password').val();
    var rePassword = $('#RePassword').val();

    if (password!="" && !checkPassword(password)) {
        alert("Password must contain an UPPER CASE, a lower case, a number and a spacial charecter.");
        return false;
    }
    else if (password != rePassword) {
        alert("Password and Confirm Password does not match.");
        return false;
    }
    return true;
        
});


$("#editForm").submit(function (event) {



    var password = $('#password').val();
    var rePassword = $('#RePassword').val();

    if (password != "" && !checkPassword(password)) {
        alert("Password must contain an UPPER CASE, a lower case, a number and a spacial charecter.");
        return false;
    }
    else if (password != rePassword) {
        alert("Password and Confirm Password does not match.");
        return false;
    }
    return true;

});


function checkPassword(password) {
    var pattern = /^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%&]).*$/;
    if (pattern.test(password)) {
        return true;
    } else {
        return false;
    }
}