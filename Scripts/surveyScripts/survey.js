function addQuestion() {
    document.getElementById('divQuestion').style.display = 'block';
}

function onTypeBlur() {

    var type = document.getElementById('ddlType').value;

    if (document.getElementById('txtQuestion').value !== '') {
        if (type === 'radio') {
            var options = input("how many options required", 2);
            if (options > 0) {}
        }
    }
}
