$(".Number").keypress(function (e) {
    //if the letter is not digit then display error and don't type anything
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message
        jQuery(".errmsg").html("Digits Only").show().fadeOut("slow");
        return false;
    }
});

$(".txtOnly").keypress(function (e) {
    if (e.shiftKey || e.ctrlKey || e.altKey) {
        e.preventDefault();
    } else {
        var key = e.keyCode;
        if (!((key == 8) || (key == 32) || (key == 190) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
            e.preventDefault();
        }
    }
});

$('body').on('click', '#btnSave', function (e) {
    e.preventDefault();
    var Name = $('#name').val();
    var Contact = $('#cont').val();
    var Email = $('#email').val();
    var Message = $('#msg').val();
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (Name == '') {
        alert('Enter Name.');
        $('#name').focus();
        return;
    }
    if (Email == '') {
        alert('Enter Email.');
        $('#email').focus();
        return;
    }
    else if (reg.test(Email) == false) {
        alert('ENTER CORRECT EMAIL ADDRESS!');
        $('#email').focus();
        return;
    }

    if (Contact == '') {
        alert('Enter Contact.');
        $('#cont').focus();
        return;
    }
    if (Contact.length !== 10) {
        alert('ENTER 10 DIGIT MOBILE NO.!');
        $('#cont').focus();
        return;
    }

    if (Message == '') {
        alert('Enter Message.');
        $('#msg').focus();
        return;
    }
    var Obj = new Object();
    Obj.Name = $('#name').val();
    Obj.Contact = $('#cont').val();
    Obj.Email = $('#email').val();
    Obj.Message = $('#msg').val();
    //$('#loaderText').show();

   

    $(this).attr('disabled', 'disabled');
    $.ajax({
        url: '/Home/ContactMailInquiry',
        type: 'post',
        data: JSON.stringify(Obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            
           // $('#loaderText').hide();
            $('#btnSave').removeAttr('disabled');
            if (data.statusCode === 200) {
                window.location.href = "/Thankyou";
               
                $('#name').val('');
                $('#cont').val('');
                $('#email').val('');
                $('#msg').val('');
            }
            else {
                console.log(data);
            }
        },
        error: function (xhr) {
            $('#loaderText').hide();
            $('#btnSave').removeAttr('disabled');
            StopLoading();
            console.log(xhr);
        }
    });
})



