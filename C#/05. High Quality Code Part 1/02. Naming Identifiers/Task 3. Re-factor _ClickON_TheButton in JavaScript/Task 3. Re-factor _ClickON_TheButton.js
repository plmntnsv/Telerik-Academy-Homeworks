function clickTheButton(event, args) {
  var currentWindow = window,
    currentBrowser = currentWindow.navigator.appCodeName,
    isMozzila = currentBrowser == "Mozilla";
  if (isMozzila) {
    alert("Yes");
  } else {
    alert("No");
  }
}