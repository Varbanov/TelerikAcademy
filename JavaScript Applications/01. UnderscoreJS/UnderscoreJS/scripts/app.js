/// <reference path="libs/jquery.min.js" />
(function () {
    require.config({
        paths: {
            'underscore': 'libs/underscore',
            'jquery': 'libs/jquery.min',
            'handlebars': 'libs/handlebars-v1.3.0',
            'one': '01-find-by-name',
            'two': '02-find-between-age',
            'three': '03-find-best-by-marks',
            'four': '04-group-by-species',
            'five': '05-count-all-legs',
            'six': '06-books',
            'seven': '07-find-by-most-common-names',
        }
    })
})();

require(['underscore', 'handlebars', 'jquery', 'data/students', 'data/animals', 'data/books', 'one', 'two', 'three', 'four', 'five', 'six', 'seven'],
    function (_, handlebars, $, students, animals, books, one, two, three, four, five, six, seven) {
        var tasks = [one, two, three, four, five, six, seven];

        function fillPeopleTemplate(template, data, container) {

            var template = document.getElementById(template).innerHTML;
            var compiledTemplate = Handlebars.compile(template);

            var container = document.getElementById(container);
            container.innerHTML = compiledTemplate(data);
        }

        fillPeopleTemplate('studentTemplate', students, "all");
        fillPeopleTemplate('studentTemplate', one, 'result');

        //student events
        $('#studentChoice').on('change', function () {
            var selectedTask = $(this).find(':selected').val();
            fillPeopleTemplate('studentTemplate', students, "all");
            fillPeopleTemplate('studentTemplate', tasks[selectedTask], 'result');
        });

        //animal events
        $('#animalChoice').on('change', function () {
            var selectedTask = $(this).find(':selected').val();
            fillPeopleTemplate('animalTemplate', animals, 'all');
            fillPeopleTemplate('animalTemplate', tasks[selectedTask], 'result');
        });

        //book events
        $('#bookChoice').on('change', function () {
            var selectedTask = $(this).find(':selected').val();
            fillPeopleTemplate('bookTemplate', books, 'all');
            debugger;
            fillPeopleTemplate('bookTemplate', tasks[selectedTask], 'result');
        });
    });