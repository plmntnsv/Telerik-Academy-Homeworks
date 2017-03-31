function solve(){
  return function(selector){
    var $mainDivEl = $("<div/>").addClass("dropdown-list");
    var $selector = $(selector);
     $selector.appendTo($mainDivEl)
              .hide()
    var clickedOption;
    var optionsContainer = $("<div/>")
                                .addClass("options-container")
                                .css("position", "absolute")
                                .hide()
                                .on("click", ".dropdown-item", function () {
                                 clickedOption = $(this);
                                 current.html(clickedOption.html());
                                 $selector.val(clickedOption.attr("data-value"));
                                 optionsContainer.hide();
                                  })
                                .appendTo($mainDivEl);

    var current = $("<div/>")
                        .addClass("current")
                        .attr("data-value", "")
                        .html("Select a value")
                        .appendTo($mainDivEl)
                        .on("click", function () {
                          optionsContainer.show();
                        });

    var $opt = $selector.find("option")
    for (var i = 0; i < 5; i+=1) {
      var ind = i+1;
      var option = $("<div/>")
                        .addClass("dropdown-item")
                        .attr("data-value", $($opt[i]).val())
                        .attr("data-index", i)
                        .html("Option " + ind)
                        .appendTo(optionsContainer);
    }

    $mainDivEl.appendTo("body");
  };
}

module.exports = solve;