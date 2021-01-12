function addOptions(options = '') {

    var ddlOptionTypeId = document.getElementById('OptionTypeId');
    var type = ddlOptionTypeId.options[ddlOptionTypeId.selectedIndex].text;
    var howmany = document.getElementById('NoOfOptions').value;
    var arr = options.split('!');

    if (type !== "Please select" && howmany > 0) {
        document.getElementById("appdiv").innerHTML = '';
        for (var i = 1; i <= howmany; i++) {
            var value = arr[i - 1] ? arr[i - 1] : '';
            var lbl = '<div class="form-group"><label class="control-label col-md-2" for= "option_' + i + '" > Option ' + i + '</label>';
            var field = '<div class="col-md-10">';
            field += '<input type="text" value="' + value + '" id="option_' + i + '" name="option_' + i + '"  class="form-control text-box single-line" />';
            field += '</div><div>'
            var div = document.createElement("DIV");
            div.className = "form-group";
            div.innerHTML = lbl + field;

            document.getElementById("appdiv").innerHTML += lbl + field
        }
    }
}
