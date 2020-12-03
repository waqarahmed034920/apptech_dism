function survey() {
    _index = 0;
    var model = [];
    function _getNextQuestion() {
        var question = model['Questions'][index];

        if (question !== undefined) {
            document.getElementById('questionDiv').innerHTML = (_index + 1) + ". " + question['Question'];

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

    function _next() {
        if (_index < model['Questions'].length) {
            _index++;
            _getNextQuestion();
        } else {
            _index = model['Questions'].length - 1;
        }
    }

    function _previous() {
        if (_index > 0) {
            _index--;
            _getNextQuestion();
        } else {
            _index = 0;
        }
    }

    return {
        Model: model,
        next: _next,
        previous: _previous,
    }
}
