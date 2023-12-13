$('body').on('click','#submit', function(){
get_data();
console.log("anonymous submit button function called");
});
confirm(message)
function get_data(){
    console.log("get_data function called");
    var _Name = $("#name").val();
    var _mobile = $("#mobile").val();
    var _email = $("#email").val();
    //radio button
    var _isMale;
    var _isFemale;
    //check box
    var _python;
    var _c_sharp;
    var _java;
    var _javascript;
    var _dropdown_selected_option = $("#dropdown").val();

    //checking if radio button is checked or not
    if ($("#isMale").is(":checked")){
        _isMale=1;
        
    }
    if($("#isFemale").is(":checked")){
        _isFemale=1;
    }

    //checking is checkbox is checked or not
    if($("#python").is(":checked")){
        _python=1;
    }
    if($("#c_sharp").is(":checked")){
        _c_sharp=1;
    }
    if($("#java").is(":checked")){
        _java=1;
    }
    if($("#javascript").is(":checked")){
        _javascript=1;
    }

    //creating object of data that we got from the html input form
    var data_object = new Object();
    data_object.Name = _Name;
    data_object.Email = _email;
    data_object.Mobile = _mobile;
    data_object.isMale = _isMale;
    data_object.isFemale = _isFemale;
    data_object.python = _python;
    data_object.c_sharp = _c_sharp;
    data_object.java = _java;
    data_object.javascript = _javascript;
    data_object.dropdown_select_option = _dropdown_selected_option;
    console.log(data_object);
}

$('body').on('click','#cancel',function(){
    reset_form()
    console.log("reset cancel button anonymous function called");
})
function reset_form(){
    //reseting input text fields
    if (confirm("Press a button!") == true) {
        text = "You pressed OK!";
        console.log("reset function called");
        $("#name").val('');
        $("#mobile").val('');
        $("#email").val('');
        //reseting gender radio checkboxes
        $("#isMale").prop('checked', false);
        $("#isFemale").prop('checked', false);
        //reseting checkboxes
        $("#python").prop('checked', false);
        $("#c_sharp").prop('checked', false);
        $("#java").prop('checked', false);
        $("#javascript").prop('checked', false);
        //reseting the dropdown menu
        $("#dropdown").val(0);
      } else {
        text = "You canceled!";
      }
}