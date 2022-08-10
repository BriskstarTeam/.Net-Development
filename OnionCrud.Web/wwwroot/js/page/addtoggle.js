function formatRows(organization, designation, fromdate, todate, hdnworkdetailsCandidateId) {

    //var i = ($(".items-workdetails").length) / 4;
    //var n = '<tr><td class="col-xs-3"><input type="text"  asp-for="candidateWorkDetailSetModel" value="' + organization + '" name="candidateWorkDetailSetModel[' + i + '].OrganizationName" class="form-control  items-workdetails" readonly/></td>' +
    //    '<td class="col-xs-3"><input type="text"  asp-for="candidateWorkDetailSetModel" value="' + designation + '" name="candidateWorkDetailSetModel[' + i + '].Designation" class="form-control  items-workdetails" readonly/></td>' +
    //    '<td class="col-xs-3"><input type="date" asp-for="candidateWorkDetailSetModel" value="' + fromdate + '" name="candidateWorkDetailSetModel[' + i + '].FromDate" class="form-control  items-workdetails" readonly/></td>' +
    //    '<td class="col-xs-3"><input type="date" asp-for="candidateWorkDetailSetModel" value="' + todate + '" name="candidateWorkDetailSetModel[' + i + '].ToDate" class="form-control  items-workdetails" readonly/></td>' +
    //    '<td class="col-xs-1 text-center" style="vertical-align:middle;"><a title="Delete" onClick="deleteRow(this,"' + hdnworkdetailsCandidateId + '")">' +
    //    '<i class="fa fa-trash" title="Delete" aria-hidden="true"></i></a></td></tr>';
    var i = document.getElementById('item-list-workdetails').rows.length;
    var n = '<tr><td class="col-xs-3"><label>' + organization + '<label /></td>' +
        '<td class="col-xs-3"><label>' + designation + '<label /></td>' +
        '<td class="col-xs-3"><label> ' + moment(fromdate).format('MM/DD/YYYY') + ' <label/></td>' +
        '<td class="col-xs-3"><label> ' + moment(todate).format('MM/DD/YYYY') + ' <label/></td>' +
        '<td class="col-xs-3" style="display:none"><input type = "text" asp-for= "candidateWorkDetailSetModel" value = "' + organization + '" name = "candidateWorkDetailSetModel[' + i + '].OrganizationName" class="form-control  items-workdetails" readonly /></td > ' +
        '<td class="col-xs-3" style="display:none"><input type="text"  asp-for="candidateWorkDetailSetModel" value="' + designation + '" name="candidateWorkDetailSetModel[' + i + '].Designation" class="form-control  items-workdetails" readonly/></td>' +
        '<td class="col-xs-3" style="display:none"><input type="date" asp-for="candidateWorkDetailSetModel" value="' + fromdate + '" name="candidateWorkDetailSetModel[' + i + '].FromDate"  class="form-control  items-workdetails" readonly/></td>' +
        '<td class="col-xs-3" style="display:none"><input type="date" asp-for="candidateWorkDetailSetModel" value="' + todate + '" name="candidateWorkDetailSetModel[' + i + '].ToDate" class="form-control  items-workdetails" readonly/></td>' +
        '<td class="col-xs-1" style="vertical-align:middle;"><a onClick="deleteRowAddMode(this)">' +
        '<i class="fa fa-trash" title="Delete" aria-hidden="true"></i></a></td></tr>';

    $("#item-list-workdetails").append(n);
}

function deleteRowAddMode(trash) {

    $(trash).closest('tr').remove();
    var itemIndex = 0;
    $('#item-list-workdetails tr').each(function () {
        var this_row = $(this);
        this_row.find('input[name$=".OrganizationName"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].OrganizationName');
        this_row.find('input[name$=".Designation"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].Designation');
        this_row.find('input[name$=".FromDate"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].FromDate');
        this_row.find('input[name$=".ToDate"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].ToDate');
        itemIndex++;
    });
}

function addRow() {
    var organization = $('.organization').val();
    var designation = $('.designation').val();
    var fromdate = $('.fromdate').val();
    var todate = $('.todate').val();
    var hdnworkdetailsCandidateId = $('#hdnworkdetailsCandidateId').val();
    $('.organization').val('');
    $('.designation').val('');
    $('.fromdate').val('');
    $('.todate').val('');
    if ($('.organization').val('') === null) {
        alert('Please Enter Proper Details');
        return false;
    }
    $(formatRows(organization, designation, fromdate, todate, hdnworkdetailsCandidateId)).insertAfter('#addworkdetails');

}

$('.addBtn').click(function () {
    if ($('.organization').val() === '') {
        alert('Please enter organization');
        return false;
    }
    if ($('.designation').val() === '') {
        alert('Please enter designation');
        return false;
    }
    if ($('.fromdate').val() === '') {
        alert('Please enter from date');
        return false;
    }
    if ($('.todate').val() === '') {
        alert('Please enter to date');
        return false;
    }
    addRow();
});



$(document).on("change", "#fromDate", function () {
    $('#toDate').attr('min', $(this).val());
});

$(document).ready(function () {
    var currentDate = new Date();
    var today = moment().format('YYYY-MM-DD');
    
    $('.disableFuturedate').attr('max', today);
    $('#fromDate').attr('max', today);
    $('#toDate').attr('max', today);
});