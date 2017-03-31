function solve() {
  return function () {
    $.fn.listview = function (data) {
      
      var element = $(this);
      var lvTemplate = element.attr("data-template");
      var source = $('#' + lvTemplate).html();
      var template = handlebars.compile(source);
      var length = data.length;

      for (i = 0; i < length; i += 1) {
        element.append(template(data[i]));
      }

      return this;
    };
  };
}

module.exports = solve;