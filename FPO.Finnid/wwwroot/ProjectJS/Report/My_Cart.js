
$('body').ready(function () {
    BindCartTable();
})
function BindCartTable() {
    $('#My_cart_table').empty();
    //$.post("ajax/test.html", function (data) {
    //    $('#My_cart_table').append(
    //        `
    //    <tr>
    //    <td> 1 </td>
    //    <td>  </td>
    //    <td> 15024 </td>
    //    <td> 1245 </td>
    //    <td> Annual </td>
    //    <td> 12-1-2024 </td>
    //    </tr>
    //    `
    //    );
    //});
    $('#My_cart_table').append(
        `
        <tr>
        <td> 1 </td>
        <td>  </td>
        <td> 15024 </td>
        <td> 1245 </td>
        <td> Annual </td>
        <td> 12-1-2024 </td>
        </tr>
        `
    );
}