function formatRows(organization, designation, fromdate, todate, hdnworkdetailsCandidateId) {
    //var i = ($(".item-list-workdetails").length) / 4;
    var i = document.getElementById('item-list-workdetails').rows.length;
    var n = '<tr><td class="col-xs-3"><label>' + organization + '<label /></td>' +
        '<td class="col-xs-3"><label>' + designation + '<label /></td>' +
        '<td class="col-xs-3"><label> ' + moment(fromdate).format('MM/DD/YYYY') + ' <label/></td>' +
        '<td class="col-xs-3"><label> ' + moment(todate).format('MM/DD/YYYY') + ' <label/></td>' +
        '<td class="col-xs-3" style = "display:none" > <input type="hidden" name="candidateWorkDetailSetModel[' + i + '].CandidateId" value="' + hdnworkdetailsCandidateId + '" asp-for="candidateWorkDetailSetModel" /></td > ' +
        '<td class="col-xs-3" style="display:none"><input type="text"  asp-for="candidateWorkDetailSetModel" value="' + organization + '" name="candidateWorkDetailSetModel[' + i + '].OrganizationName" class="form-control  items-workdetails" readonly/></td>' +
        '<td class="col-xs-3" style="display:none"><input type="text"  asp-for="candidateWorkDetailSetModel" value="' + designation + '" name="candidateWorkDetailSetModel[' + i + '].Designation" class="form-control  items-workdetails" readonly/></td>' +
        '<td class="col-xs-3" style="display:none"><input type="date" asp-for="candidateWorkDetailSetModel" value="' + fromdate + '" name="candidateWorkDetailSetModel[' + i + '].FromDate" class="form-control  items-workdetails" readonly/></td>' +
        '<td class="col-xs-3" style="display:none"><input type="date" asp-for="candidateWorkDetailSetModel" value="' + todate + '" name="candidateWorkDetailSetModel[' + i + '].ToDate" class="form-control  items-workdetails" readonly/></td>' +
        '<td class="col-xs-1" style="vertical-align:middle;"><a  onClick="deleteworkdetailroweditmode(this)">' +
        '<i class="fa fa-trash"  aria-hidden="true"></i></a></td></tr>';

    $("#item-list-workdetails").append(n);
}

function deleteworkdetailroweditmode(trash) {
    $(trash).closest('tr').remove();
    var itemIndex = 0;
    $('#item-list-workdetails tr').each(function () {
        var this_row = $(this);
        this_row.find('input[name$=".CandidateId"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].CandidateId');
        this_row.find('input[name$=".OrganizationName"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].OrganizationName');
        this_row.find('input[name$=".Designation"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].Designation');
        this_row.find('input[name$=".FromDate"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].FromDate');
        this_row.find('input[name$=".ToDate"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].ToDate');
        itemIndex++;
    });
}

function deleteworkdetailrow(row, candidateId, experienceId) {
   
    $.ajax({
        type: "GET",
        url: "/Candidate/WorkDetailDelete",
        contentType: "application/json; charset=utf-8",
        data: {
            'experienceIds': experienceId,
            'candidateIds': candidateId
        },
        dataType: "json",
        success: function (result) {
            $(row).closest('tr').remove();
            var itemIndex = 0;
            $('#item-list-workdetails tr').each(function () {
                var this_row = $(this);
                this_row.find('input[name$=".CandidateId"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].CandidateId');
                this_row.find('input[name$=".OrganizationName"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].OrganizationName');
                this_row.find('input[name$=".Designation"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].Designation');
                this_row.find('input[name$=".FromDate"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].FromDate');
                this_row.find('input[name$=".ToDate"]').attr('name', 'candidateWorkDetailSetModel[' + itemIndex + '].ToDate');
                itemIndex++;
            });
        }
    });
}

function addRow() {
    
    var organization = $('#txtorganization').val();
    var designation = $('#txtdesignation').val();
    var fromdate = $('#txtfromdate').val();
    var todate = $('#txttodate').val();
    var hdnworkdetailsCandidateId = $('#CandidateId').val();
    $('#txtorganization').val('');
    $('#txtdesignation').val('');
    $('#txtfromdate').val('');
    $('#txttodate').val('');
    if ($('#txtorganization').val('') === null) {
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


$(document).on("change", "#txtfromdate", function () {
    $('#txttodate').attr('min', $(this).val());
});

$(document).ready(function () {
    var currentDate = new Date();
    var today = moment().format('YYYY-MM-DD');

    $('.disableFuturedate').attr('max', today);
    $('#txtfromdate').attr('max', today);
    $('#txttodate').attr('max', today);
});