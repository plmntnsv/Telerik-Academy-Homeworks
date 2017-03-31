function solve() {
    return function (fileContentsByName) {
        var $addButton = $(".add-btn"),
            $input = $("input"),
            $rootUlEl = $(".items").first(),
            $anchors = $(".item-name"),
            $delButtons = $(".del-btn"),
            $content = $(".file-content");

        $rootUlEl.on("click", function (event) {
            var $target = $(event.target);
            if ($target.hasClass("del-btn")) {
                var $parent = $($target.parent());
                $parent.remove();
            } else if ($target.parent().hasClass("file-item")) {
                var prop = $target.html(),
                    foundText = fileContentsByName[prop] || "";
                $content.text(foundText);
            } else if ($target.parent().hasClass("dir-item")) {
                $target.parent().toggleClass("collapsed");
            }

        });

        $addButton.on("click", function (event) {
            $input.addClass('visible');
            $addButton.removeClass('visible');
        });

        $input.on("keydown", function (event) {
            if (event.keyCode === 13) {
                var inputText = $input.val(),
                    path,
                    dir,
                    fileName,
                    i,
                    len;

                if (inputText.indexOf("/") !== -1) {
                    path = inputText.split("/");
                    dir = path[0];
                    fileName = path[1];

                    for (i = 0, len = $anchors.length; i < len; i += 1) {
                        console.log($anchors.eq(i).html());
                        if ($anchors.eq(i).html().toLowerCase() === dir.toLowerCase()) {
                            $('<li class="file-item item"><a class="item-name">' + fileName + '</a><a class="del-btn"></a></li>').appendTo($anchors.eq(i).next());
                            break;
                        }
                    }
                } else {
                    fileName = inputText;
                    $('<li class="file-item item"><a class="item-name">' + fileName + '</a><a class="del-btn"></a></li>').appendTo($rootUlEl);
                }

                $input.val("");
                $input.hide();
                $addButton.show();
            }
        });
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}