/* globals $ */

/* 

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/

function solve() {
  return function (selector, count) {
    var selected = $(selector);
    if (selected < 1) {
      return;
    }

    if (typeof selector !== 'string') {
      throw "Invalid selector";
    }

    if ((typeof count === 'number' && count < 1) || count === undefined || isNaN(count) || typeof count !== 'number') {
      throw "Invalid count number";
    }

    var $ulEl = $("<ul />");
    $ulEl.addClass("items-list");

    for (var i = 0; i < +count; i += 1) {
      var $liEl = $("<li />");
      $liEl.addClass("list-item");
      $liEl.html("List item #" + i);
      $ulEl.append($liEl);
    }

    $(selector).append($ulEl);
  };
}

module.exports = solve;