/* globals document, window, console */

function solve() {
    return function (selector, initialSuggestions) {
        "use strict";
        var element = document.querySelector(selector);
        var inputField = document.getElementsByClassName("tb-pattern")[0];
        var addButton = document.getElementsByClassName("btn-add")[0];
        var suggestionList = document.getElementsByClassName("suggestions-list")[0];

        var suggestions = initialSuggestions || [];

        var uniqueSuggestionsChecker = [];

        if (suggestions.length !== 0) {
            suggestions.forEach(function (sugg) {
                if (uniqueSuggestionsChecker.indexOf(sugg.toLowerCase()) === -1) {
                    var liEl = document.createElement("li");
                    liEl.className = "suggestion";
                    liEl.style.display = "none";
                    var anchorEl = document.createElement("a");
                    anchorEl.className = "suggestion-link";
                    anchorEl.innerHTML = sugg;
                    anchorEl.href = "#";
                    liEl.appendChild(anchorEl);
                    suggestionList.appendChild(liEl);
                    uniqueSuggestionsChecker.push(sugg.toLowerCase());
                }
            });
            var suggestionLinks = document.getElementsByClassName("suggestion-link");
            var suggestionLi = document.getElementsByClassName("suggestion");

            inputField.addEventListener("input", function () {
                var text = this.value,
                    i,
                    len;

                if (text === "") {
                    for (i = 0, len = suggestionLi.length; i < len; i += 1) {
                        suggestionLi[i].style.display = "none";
                    }
                } else {
                    for (i = 0, len = suggestionLinks.length; i < len; i += 1) {
                        var currentLinkEl = suggestionLinks[i];
                        var currentLinkElText = suggestionLinks[i].innerHTML.toLowerCase();
                        if (currentLinkElText.indexOf(text.toLowerCase()) >= 0) {
                            currentLinkEl.parentElement.style.display = "";
                        } else if (currentLinkEl.style.display !== "none") {
                            currentLinkEl.parentElement.style.display = "none";
                        }
                    }
                }
            });

            addButton.addEventListener("click", function () {
                var text;
                if (inputField.value !== "") {
                    text = inputField.value;

                    if (uniqueSuggestionsChecker.indexOf(text.toLowerCase()) === -1) {
                        var liEl = document.createElement("li");
                        liEl.className = "suggestion";
                        liEl.style.display = "none";
                        var anchorEl = document.createElement("a");
                        anchorEl.className = "suggestion-link";
                        anchorEl.innerHTML = text;
                        anchorEl.href = "#";
                        liEl.appendChild(anchorEl);
                        suggestionList.appendChild(liEl);
                        uniqueSuggestionsChecker.push(text.toLowerCase());
                    }
                }
            });

            suggestionList.addEventListener("click", function (event){
                var target = event.target;
                if (target.tagName === "A") {
                    inputField.value = target.innerHTML;
                }
            });

        }
    };
}

module.exports = solve;