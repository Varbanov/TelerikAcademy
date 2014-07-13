/// <reference path="require.js" />
/// <reference path="jquery-2.1.1.min.js" />
/// <reference path="handlebars-v1.3.0.js" />

define(['handlebars', 'jquery'], function () {

    var ComboBox = (function () {
        function ComboBox(people) {
            this.people = people;
            return this;
        }

        ComboBox.prototype.render = function (template) {
            var compiledTemplate = Handlebars.compile(template);
            var $container = $('<div></div>');

            for (var i = 0, len = this.people.length; i < len; i++) {
                $container.append(compiledTemplate(this.people[i]));
            }

            $container.children().first().addClass('selected');
            $container.addClass('collapsed');

            $container.on('click', '.person-item', function () {
                var $this = $(this);
                if ($container.hasClass('collapsed')) {
                    $container.children().addClass('visible');
                    $container.removeClass('collapsed');
                } else {
                    $container.addClass('collapsed');
                    $container.children().removeClass('visible');
                    $container.find('.selected').removeClass('selected');
                    $this.addClass('selected');
                }
            })

            return $container;
        }

        return ComboBox;
    })();

    return {
        ComboBox: ComboBox,
    }
});

