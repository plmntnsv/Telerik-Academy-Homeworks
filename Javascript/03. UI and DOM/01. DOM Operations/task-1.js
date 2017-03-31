/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function () {

  return function (element, contents) {
    if (element === undefined || contents === undefined || arguments < 2) {
      throw "Missing parameter";
    }

    if (typeof element !== 'string' && !(element instanceof HTMLElement)) {
      throw "Invalid element provided";
    }

    if (!Array.isArray(contents)) {
      throw "Invalid contents array";
    }

    var el;
    var df = document.createDocumentFragment();

    if (typeof element === 'string') {
      el = document.getElementById(element);

      if (el === null) {
        throw "No element with such ID provided";
      }
    } else {
      el = element;
    }

    contents.forEach(function(e) {
      if (typeof e !== 'string' && typeof e !== 'number') {
        throw "Invalid content";
      }

      var divEl = document.createElement("div");
      divEl.innerHTML = e;
      df.appendChild(divEl);
    });

    el.innerHTML = "";
    el.appendChild(df);
  };
};