/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
  return function (selector) {
    if (typeof selector !== 'string') {
      throw "Invalid selector";
    }

    if ($(selector).length < 1) {
      throw "No element found";
    }

    var $buttons = $(".button");
    $buttons.html("hide");
    
    $buttons.on("click", function () {
      var $this = $(this);
      var next = $this.next();
      var nextNext = next.next();
      var foundContent = false;

      if ($this.hasClass("content") || next.length < 1) {
        return;
      }

      while (nextNext.length > 0) {
        if (next.hasClass("content") && !foundContent) {
          foundContent = true;
        } else {
          next = next.next();
          nextNext = next.next();
        }

        if (foundContent) {
          if (nextNext.hasClass("button")) {
            if (next.css("display") == "none") {
              $this.html("hide");
              next.css("display", "");
            } else {
              $this.html("show");
              next.css("display", "none");
            }
            break;
          }
          nextNext = nextNext.next();
        }
      }
    });
  };
}

module.exports = solve;