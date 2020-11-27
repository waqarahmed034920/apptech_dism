function addOptions() {

    var ddlOptionTypeId = document.getElementById('OptionTypeId');
    var type = ddlOptionTypeId.options[ddlOptionTypeId.selectedIndex].text;
    var howmany = document.getElementById('NoOfOptions').value;

    console.log(type, howmany);

    if (type !== "Please select" && howmany > 0) {
        for (var i = 1; i <= howmany; i++) {
            var lbl = '<div class="form-group">'
            lbl += '<label class="control-label col-md-2" for= "option_' + i + '" > Option ' + i + '</label>'
            var field = '<div class="col-md-10">'
            field += '<input type="text" id="option_' + i + '" name="option_' + i + '"  class="form-control text-box single-line" />';
            field += '</div><div>'
            var div = document.createElement("DIV");
            div.className = "form-group";
            div.innerHTML = lbl + field;

            var f = document.getElementsByTagName('form');
            console.log(f[0].lastChild);
            f[0].insertBefore(div, f[0].lastChild);
        }
    }
}

function ConfirmDelete() {
    var conf = confirm("This would delete the record. Are you sure?");
    if (conf) {
        console.log(1);
        return true;
    } else {
        console.log(2);
        return false;
    }
}