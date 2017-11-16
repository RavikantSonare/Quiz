
$(function () {
    $('.summernote').summernote({
        height: 50,
    });
    var dt = $('#ContentPlaceHolder1_hftxtquestion').val();
    $('#ContentPlaceHolder1_txtQuestion').summernote('code', dt);

    var hdexplanation = $('#ContentPlaceHolder1_hftxtExplanation').val();
    $('#ContentPlaceHolder1_txtExplanation').summernote('code', hdexplanation);

    var numberofanswerget = $('#ContentPlaceHolder1_prevVaile').val();
    var valanswerget = [numberofanswerget];
    for (i = 1; i <= numberofanswerget; i++) {
        valanswerget[i] = $('#ContentPlaceHolder1_hf' + i).val();
        $('#ContentPlaceHolder1_tb' + i).summernote('code', valanswerget[i]);
    }


});

$(document).ready(function () {
    $('[id$=btnAdd], [id$=btnMultiAdd], [id$=btnVacantAdd], [id$=btnHotspotAdd], [id$=btnDragdropAdd], [id$=btnScenarioAdd]').click(function () {
        var val = $('#ContentPlaceHolder1_txtQuestion').summernote('code');
        $('#ContentPlaceHolder1_hftxtquestion').val(val);

        var valexplanation = $('#ContentPlaceHolder1_txtExplanation').summernote('code');
        $('#ContentPlaceHolder1_hftxtExplanation').val(valexplanation);

        var numberofanswer = $('#ContentPlaceHolder1_prevVaile').val();
        var valanswer = [numberofanswer];
        for (i = 1; i <= numberofanswer; i++) {
            valanswer[i] = $('#ContentPlaceHolder1_tb' + i).summernote('code');
            $('#ContentPlaceHolder1_hf' + i).val(valanswer[i]);
        }
    });

});