var flag = '';
$('body').on('click', '#btn_sendEnquery', function (e) {
    e.preventDefault();
    flag = $('#btn_sendEnquery').data('name');
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    
    if ($('#txt_name').val() == '') {
        alert("Enter Name ");
        return false;
    }
    if ($('#txt_email').val() == '') {
        alert("Enter Email");
        return false;
    }
    else if (reg.test($('#txt_email').val()) == false) {
        alert('ENTER CORRECT EMAIL ADDRESS!');
        $('#email').focus();
        return;
    }
    if ($('#txt_contactno').val() == '') {
        alert("Enter Message")
        return false;
    }

    var Obj = new Object();
    Obj.Name = $('#txt_name').val();
    Obj.Email = $('#txt_email').val();
    Obj.ContactNo = $('#txt_contactno').val();
    Obj.Title = flag;

    window.location.href = "/Thankyou";

    $.ajax({
        url: '/Home/RegistrationEnquery',
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(Obj),
        contentType: 'application/json;charset=utf-8',
        success: function (data) {
            if (data.statusCode == 200) {
                $('#txt_name').val('');
                $('#txt_email').val('');
                $('#txt_contactno').val('');
            }
            else {                
                $('#txt_name').val('');
                $('#txt_email').val('');
                $('#txt_contactno').val('');
            }
        },
        error: function (xhr) {
            console.log(xhr);
        }
    })
})