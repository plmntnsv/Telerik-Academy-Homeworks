function solve() {
  return function (selector) {
    if (typeof selector === 'string') {
      selector = document.getElementById(selector);

      if (selector === null) {
        throw "No such element found";
      }
    } else if (!(selector instanceof HTMLElement)) {
      throw "Invalid parameter";
    }

    var allButtons = document.getElementsByClassName("button");
    var allContents = document.getElementsByClassName("content");
    for (var i = 0, length = allButtons.length; i < length; i += 1) {
      allButtons[i].innerHTML = "hide";
    }

    selector.addEventListener("click", function (e) {
      var currentElement = e.target;
      var nextElement = currentElement.nextElementSibling;
      var nextNextElement = nextElement.nextElementSibling;

      if (currentElement.className !== "button" || nextElement === null) {
        return;
      }

      while (nextElement) {
        if (nextElement.className === "button") {
          nextElement = nextElement.nextElementSibling;
          nextNextElement = nextElement.nextElementSibling;
          continue;
        } else {
          if (nextNextElement.className === "button") {
            if (nextElement.style.display !== "none") {
              nextElement.style.display = "none";
              currentElement.innerHTML = "show";
            } else {
              nextElement.style.display = "";
              currentElement.innerHTML = "hide";
            }
          }
        }

        nextElement = nextElement.nextElementSibling;
        nextNextElement = nextElement.nextElementSibling;
      }
    }, false);
  };
}

module.exports = solve;