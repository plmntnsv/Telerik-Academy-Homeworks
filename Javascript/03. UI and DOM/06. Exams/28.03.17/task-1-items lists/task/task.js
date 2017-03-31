function solve() {

	return function (selector, defaultLeft, defaultRight) {

		var element = document.querySelector(selector);
		var leftPanel = defaultLeft || [],
			rightPanel = defaultRight || [];

		// An element with class column-container
		var columnContainer = document.createElement("div");
		columnContainer.className = "column-container";
		element.appendChild(columnContainer);

		// Should contain two elements with class column; 
		var columnLeft = document.createElement("div");
		columnLeft.className = "column";
		columnContainer.appendChild(columnLeft);

		var columnRight = document.createElement("div");
		columnRight.className = "column";
		columnContainer.appendChild(columnRight);

		// Each column should contain:
		// Left Select:
		var selectElLeft = document.createElement("div");
		selectElLeft.className = "select";

		var radioInputLeft = document.createElement("input");
		radioInputLeft.type = "radio";
		radioInputLeft.checked = "checked";
		radioInputLeft.name = "column-select";
		radioInputLeft.id = "select-left-column";

		//var labelLeft = document.createElement("label");
		//labelLeft.innerHTML = "Add here";
		//labelLeft.setAttribute("for", "select-left-column");
		selectElLeft.appendChild(radioInputLeft);
		//selectElLeft.appendChild(labelLeft);
		columnLeft.appendChild(selectElLeft);

		// Right Select:
		var selectElRight = document.createElement("div");
		selectElRight.className = "select";

		var radioInputRight = document.createElement("input");
		radioInputRight.type = "radio";
		radioInputRight.checked = "";
		radioInputRight.name = "column-select";
		radioInputRight.id = "select-right-column";

		//var labelRight = document.createElement("label");
		//labelRight.innerHTML = "Add here";
		//labelRight.setAttribute("for", "select-right-column");
		selectElRight.appendChild(radioInputRight);
		//selectElRight.appendChild(labelRight);
		columnRight.appendChild(selectElRight);

		// Left OL:
		var orderedListLeft = document.createElement("ol");
		populateOrderedList(orderedListLeft, leftPanel);
		columnLeft.appendChild(orderedListLeft);

		// Right OL:
		var orderedListRight = document.createElement("ol");
		populateOrderedList(orderedListRight, rightPanel);
		columnRight.appendChild(orderedListRight);

		// Should contain An input field
		var inputEl = document.createElement("input");
		inputEl.size = "40";
		inputEl.autofocus = true;
		element.appendChild(inputEl);

		// Should contain A button		
		var buttonEl = document.createElement("button");
		buttonEl.innerHTML = "Add";
		element.appendChild(buttonEl);

		// function populateOrderedList(ol, items) {
		// 	var liEl = document.createElement("li");
		// 	liEl.className = "entry";

		// 	var imgEl = document.createElement('img');
		// 	imgEl.className = "delete";
		// 	imgEl.src = "imgs/Remove-icon.png";

		// 	var i,
		// 		len = items.length,
		// 		currLiEl,
		// 		currImgEl;

		// 	for (i = 0; i < len; i += 1) {
		// 		currLiEl = liEl.cloneNode(false);
		// 		currImgEl = imgEl.cloneNode(true);
		// 		currLiEl.innerText = items[i];
		// 		currLiEl.appendChild(currImgEl);
		// 		//currLiEl.innerHTML += items[i];
		// 		ol.appendChild(currLiEl);
		// 	}
		// }

		function populateOrderedList(ol, items) {
			var i,
				len = items.length,
				currLiEl,
				currImgEl;

			for (i = 0; i < len; i += 1) {
				var liEl = document.createElement("li");
				liEl.className = "entry";

				var imgEl = document.createElement('img');
				imgEl.className = "delete";
				imgEl.src = "imgs/Remove-icon.png";
				liEl.innerHTML += items[i];
				//liEl.innerText = items[i];
				liEl.appendChild(imgEl);
				ol.appendChild(liEl);
			}
		}

		buttonEl.addEventListener("click", function () {
			var text = inputEl.value.trim();
			if (text === "") {
				return;
			}

			var liEl = document.createElement("li");
			liEl.className = "entry";
			liEl.innerHTML += text;
			//liEl.innerText = text;

			var imgEl = document.createElement('img');
			imgEl.className = "delete";
			imgEl.src = "imgs/Remove-icon.png";
			liEl.appendChild(imgEl);


			if (radioInputLeft.checked) {
				orderedListLeft.appendChild(liEl);
			} else {
				orderedListRight.appendChild(liEl);
			}

			inputEl.value = "";
		});

		columnContainer.addEventListener("click", function (event) {
			var target = event.target;
			if (target.tagName !== "IMG") {
				return;
			}
			//var text = target.parentElement.innerText.trim();
			var text = target.parentElement.innerHTML.trim();
			inputEl.value = text;
			target.parentElement.remove();
		});
	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
	module.exports = solve;
}