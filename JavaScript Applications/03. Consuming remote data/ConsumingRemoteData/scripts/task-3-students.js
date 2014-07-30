/// <reference path="libs/jquery.min.js" />
/// <reference path="libs/q.js" />
/// <reference path="libs/require.js" />
/// <reference path="httpRequestModule.js" />
/// <reference path="libs/jquery.min.js" />
(function () {
    require.config({
        paths: {
            'q': 'libs/q',
            'httpRequest': 'httpRequestObjectCreator',
            'httpRequestModule': 'httpRequestModule',
            'jquery': 'libs/jquery.min',
        }
    })
})();

require(['httpRequestModule', 'jquery'], function (httpRequestModule, $) {
    var url = 'http://localhost:3000/students/';

    $('#addBtn').on('click', function () {
        var name = $('#name').val();
        var student = {
            name: name,
        };

        httpRequestModule.postJson(url, student);
    })




    $('#deleteBtn').on('click', function () {
        var id = $('#id').val();

        removeStudent(id)

        function removeStudent(id) {
            var def = $.Deferred();
            var studentUrl = url + id;
            $.ajax({
                url: studentUrl,
                type: 'POST',
                data: {
                    _method: 'delete'
                },
                success: function (data) {
                    onShowBtnClick();
                    def.resolve(data);
                },
                error: function (data) {
                    var div = $('#result')
                        .empty()
                        .html('Error! Could not delete student with id: ' + id + '.');
                    def.reject(data);
                }
            })
            return def.resolve();
        }
    })


    $('#showBtn').on('click', onShowBtnClick);

    function onShowBtnClick() {
        var students = httpRequestModule.getJson(url)
            .then(show);

        debugger;

        function show(data) {
            debugger;
            var fragment = document.createDocumentFragment();
            var i;
            var tempDiv = $('div')[0];

            for (i = 0; i < data.count; i++) {
                tempDiv.innerHTML = (JSON.stringify(data.students[i]));
                fragment.appendChild(tempDiv.cloneNode(true));
            }

            var div = $('#result')
                .empty()
                .append(fragment);
        };
    };

});
