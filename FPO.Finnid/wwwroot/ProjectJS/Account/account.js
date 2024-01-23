let signUp = () => {
    if (!valiadteInputs()) {
        return false;
    }
    let obj = {
        Name: $('#txtname').val(),
        Email: $('#txtemail').val(),
        Mobile: $('#txtmobile').val(),
        Password: $('#txtpassword').val(),
        StateId: $('#ddlState').val(),
        CityId: $('#ddlCity').val(),
    }
    if (obj.Password != $('#txtcrmpassword').val()) {
        alert('Password and confirm password did not match.');
        return false;
    }
    $.post('/Account/SignUp', obj).done((response) => {
        alert(response.responseMessage);
        $('input').val('');
    }).fail((xhr) => {
        alert('Server Error.');
        console.log(xhr.responseText);
    });
}
let Login = () => {
    if (!valiadteInputs()) {
        return false;
    }
    let obj = {
        Email: $('#txtemail').val(),
        Password: $('#txtpassword').val()
    };

    if (obj.Password === "" || obj.Email === "") {
        alert('Password or Email field is Empty');
        return false;
    }

    $.post('/Account/Login', obj)
        .done((response) => {
            if (response.responseCode == 200) {
                window.location.href = '/Dashboard';
            }
            else {
                alert(response.responseMessage);
            }
        })
        .fail((xhr) => {
            alert('Server Error');
            console.log(xhr.responseText);
        });
};
let bindCity = () => {
    $.post('/Account/GetCity', { StateId: $('#ddlState').val() })
        .done((response) => {
            let _option = response.map((v, i) => {
                return `<option value="${v.id}">${v.name}</option>`;
            });
            $('#ddlCity').empty().append(_option);
        })
        .fail((xhr) => {
            alert('Server Error');
            console.log(xhr.responseText);
        });
}
$('body').on('click', '#eye', function () {
    console.log("eye button clicked");
    if ($(this).hasClass('fa-eye-slash')) {

        $(this).removeClass('fa-eye-slash');

        $(this).addClass('fa-eye');

        $('#txtpassword').attr('type', 'text');

    } else {

        $(this).removeClass('fa-eye');

        $(this).addClass('fa-eye-slash');

        $('#txtpassword').attr('type', 'password');
    }
})
$('body').on('click', '#eye2', function () {
    console.log("eye button clicked");
    if ($(this).hasClass('fa-eye-slash')) {

        $(this).removeClass('fa-eye-slash');

        $(this).addClass('fa-eye');

        $('#txtcrmpassword').attr('type', 'text');

    } else {

        $(this).removeClass('fa-eye');

        $(this).addClass('fa-eye-slash');

        $('#txtcrmpassword').attr('type', 'password');
    }
})
$('body').ready(function () {
    const element = $('#card-body');
    console.log("Width: " + element.offsetWidth + "px");
})