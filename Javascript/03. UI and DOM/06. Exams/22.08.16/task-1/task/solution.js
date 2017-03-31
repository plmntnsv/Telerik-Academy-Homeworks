function solve() {
    return function (selector, tabs) {
        var $selector = $(selector);
        var $ulNavEl = $("<ul />").addClass("tabs-nav");
        var $ulContentEl = $("<ul />").addClass("tabs-content");

        tabs.forEach(function (el, index) {
            $("<li><a href=\"#\" class=\"tab-link\" tab-index=\"" + index + "\">" + el.title + "</a></li>").appendTo($ulNavEl);
            $("<li class=\"tab-content\"><p>" + el.content + "</p><button class=\"btn-edit\">Edit</button></li>").appendTo($ulContentEl);
        });

        $ulContentEl.find("li").first().addClass("visible");

        $ulNavEl.appendTo($selector);
        $ulContentEl.appendTo($selector);

        var $allContents = $(".tab-content");
        var contentTabs = [].slice.call($allContents);

        $ulNavEl.on("click", function (event) {
            var indexOfClicked = $(event.target).attr('tab-index');

            for (var i = 0; i < contentTabs.length; i += 1) {
                var $currTabEl = $(contentTabs[i]);
                if (+indexOfClicked !== i) {
                    if ($currTabEl.hasClass("visible")) {
                        $currTabEl.removeClass("visible");
                    }
                } else {
                    $currTabEl.addClass("visible");
                }
            }
        });

        var buttons = $(".btn-edit").on("click", function (event) {
            var $clicked = $(event.target);

            if ($clicked.html() === "Edit") {
                $clicked.html("Save");

                $("<textarea />").addClass("edit-content")
                                .html($clicked.prev().html())
                                .appendTo($clicked.parent());
            } else {
                var $textArea = $("textarea");
                $clicked.prev().html($textArea.val());
                $textArea.remove();
                $clicked.html("Edit");
            }

        });
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}