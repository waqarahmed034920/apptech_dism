    index = 0;

function setModel(data) {
    model = data;
    getNextQuestion(model)
}

function getNextQuestion(model) {
    var question = model['Questions'][index];

    if (question !== undefined) {
        document.getElementById('questionDiv').innerHTML = (index + 1) + ". " + question['Question'];

        var options = question['Options'];
        var Items = options.split('!');
        str = "";

        Items.forEach(function (item) {
            if (question['OptionTypeId'] == 1) {
                str += "<div style=\"padding: 5px;\"><input type=\"radio\" name=\"radio-group\" value=\"" + item + " \"><span style=\"padding: 5px; \">" + item + "</span></div>";
            }
            else if (question.OptionTypeId == 2) {
                str += "<div style=\"padding: 5px;\"><input type=\"checkbox\" value=\"" + item + " \"><span style=\"padding: 5px; \">" + item + "</span></div>";
            }
        });
        document.getElementById('optionDiv').innerHTML = str;
    }
}

function next() {
    if (index < model['Questions'].length) {
        index++;
        getNextQuestion(model);
    } else {
        index = model['Questions'].length - 1;
    }
}

function previous() {
    if (index > 0) {
        index--;
        getNextQuestion(model);
    } else {
        index = 0;
    }
}
