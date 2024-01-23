console.log("Prices Aditya !!");
var DDL_plan_value = 0;
var DDL_facilities_plan_value = 0;
var DDL_Tenuer_value = 0;
var Fprice = 0;
var CGST = 0;
var BasePrice = 0;
$('body').on('change', '#DDL_plan', function () {

    select_DDL_Plan();

})

function select_DDL_Plan() {
    var DDL_plan = $('#DDL_plan').val();
    var selected_value = Number(DDL_plan);
    DDL_plan_value = selected_value;
    console.log(`DDL_plan = ${selected_value}`)
    $('#DDL_Features_Container').empty();
    //console.log(DDL_plan);
    if (selected_value == 0) {
        //hide the child DDLs
        $('#DDL_Features_Container').empty();
        $('#DDL_plan_Tenuer').empty();
    }
    else if (selected_value == 1) {
        //show DDL with the options pure erp plan
        //Just Smart Dude Pro Pro+
        $('#DDL_Features_Container').append(`
        
            <select class="form-group" id="DDL_facilities_plan">
                <option value="0">--SELECT--</option>
                <option value="1">Just</option>
                <option value="2">Smart</option>
                <option value="3">Dude</option>
                <option value="4">Pro</option>
                <option value="5">Pro+</option>
            </select>
        
        `)
    }
    else if (selected_value == 2) {
        //show DDL with the options Comprehensive Plans
        //Just Smart Dude Pro
        $('#DDL_Features_Container').append(`
        
            <select class="form-group" id="DDL_facilities_plan">
                <option value="0">--SELECT--</option>
                <option value="1">Just</option>
                <option value="2">Smart</option>
                <option value="3">Dude</option>
                <option value="4">Pro</option>
            </select>
        
        `)
    }
    else if (selected_value == 3) {
        //show DDL with the options Government Supported FPO Plans
        //Just Smart
        $('#DDL_plan_Tenuer').empty();
        $('#DDL_Features_Container').append(`
        
            <select class="form-group" id="DDL_facilities_plan">
                <option value="0">--SELECT--</option>
                <option value="1">Just</option>
                <option value="2">Smart</option>
            </select>
        
        `)
    }
    else {
        console.log("DDL error");
    }
}
$('body').on('change', '#DDL_facilities_plan', function () {
    facilities_plan();
    calculate_price();
})
function facilities_plan() {
    var facilities_plan = $('#DDL_facilities_plan').val();
    var selected_value = Number(facilities_plan);
    DDL_facilities_plan_value = selected_value;
    console.log(`DDL_facilities_plan = ${selected_value}`)
    $('#DDL_plan_Tenuer').empty();
    if (selected_value == 0) {
        //hide the DDL
        $('#DDL_plan_Tenuer').empty();
    }
    else {
        var plan_val = $(`#DDL_plan`).val();
        plan_selected = Number(plan_val);
        if (plan_selected == 3) {
            $('#DDL_plan_Tenuer').empty();
        }
        else {
            $('#DDL_plan_Tenuer').append(
                `
            <select class="form-group" id="DDL_Tenuer">
                <option value="0">--SELECT--</option>
                <option value="1">Monthly</option>
                <option value="2">Annual</option>
            </select>
            `
            );
        }
    }
}

$('body').on('change', '#DDL_Tenuer', function () {
    get_DDL_Tenuer();
})
function get_DDL_Tenuer() {
    var DDL_Tenuer = $('#DDL_Tenuer').val();
    var selected_value = Number(DDL_Tenuer);
    DDL_Tenuer_value = selected_value;
    console.log(`DDL_Tenuer = ${selected_value}`);
    calculate_price();
}
//TODO Create the table using js populate calculate prices
function create_table(BasePrice, CGST, Fprice){
    $(`#Base_Price`).empty();
    $(`#Base_Price`).append(
        `${BasePrice}`
    );
    $(`#GST`).empty();
    $(`#GST`).append(
        `${CGST}`
    );
    $(`#Total_Price`).empty();
    $(`#Total_Price`).append(
        `${Fprice}`
    );
}
function calculate_price() {
    var selected_plan = DDL_plan_value;
    var selected_feature = DDL_facilities_plan_value;
    var tenure = DDL_Tenuer_value;
    var GST = 0.18;//Add this to the final cost
    $(`#GST`).empty();
    $(`#Total_Price`).empty();
    $(`#Base_Price`).empty();
    if (selected_plan == 1) {
        if (selected_feature == 1) {
            if (tenure == 1) {
                console.log(400);
                BasePrice = 400;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(4000);
                BasePrice = 4000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else if (selected_feature == 2) {
            if (tenure == 1) {
                console.log(500);
                BasePrice = 500;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(5000);
                BasePrice = 5000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else if (selected_feature == 3) {
            if (tenure == 1) {
                console.log(600);
                BasePrice = 600;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(6000);
                BasePrice = 6000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else if (selected_feature == 4) {
            if (tenure == 1) {
                console.log(800);
                BasePrice = 800;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(8000);
                BasePrice = 8000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else if (selected_feature == 5) {
            if (tenure == 1) {
                console.log(1000);
                BasePrice = 1000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(10000);
                BasePrice = 10000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else {
            //nothing
        }
    }
    else if (selected_plan == 2) {
        if (selected_feature == 1) {
            if (tenure == 1) {
                console.log(1500);
                BasePrice = 1500;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(15000);
                BasePrice = 15000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else if (selected_feature == 2) {
            if (tenure == 1) {
                console.log(2000);
                BasePrice = 2000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(20000);
                BasePrice = 20000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else if (selected_feature == 3) {
            if (tenure == 1) {
                console.log(3000);
                BasePrice = 3000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(30000);
                BasePrice = 30000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else if (selected_feature == 4) {
            if (tenure == 1) {
                console.log(4000);
                BasePrice = 4000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else if (tenure == 2) {
                console.log(40000);
                BasePrice = 40000;
                CGST = BasePrice * GST;
                Fprice = BasePrice + CGST;
                create_table(BasePrice, CGST, Fprice);
            }
            else {
                //nothing
            }
        }
        else {
            //nothing
        }
    }
    else if (selected_plan == 3) {
        if (selected_feature == 1) {
            console.log(24000);
            BasePrice = 24000;
            CGST = BasePrice * GST;
            Fprice = BasePrice + CGST;
            create_table(BasePrice, CGST, Fprice);
        }
        else if (selected_feature == 2) {
            console.log(36000);
            BasePrice = 36000;
            CGST = BasePrice * GST;
            Fprice = BasePrice + CGST;
            create_table(BasePrice, CGST, Fprice);
        }
        else {
            //nothing
        }
    }
}

let checkout = () => {
    if (!valiadteInputs()) {
        return false;
    }
    $.post('/CheckOut').done((response) => {
        console.log(response);
    }).fail((xhr) => {
        console.error(xhr.responseText);
        console.log(xhr.status);
        if (xhr.status == '401') {
            window.location.href = '/account/login';
        }
    });
}