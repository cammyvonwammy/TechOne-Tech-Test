// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
  document.getElementById("form").addEventListener("submit", handleSubmit);
});

function handleSubmit(event) {
  var inputElement = document.getElementById("numberInput");
  var messageElement = document.getElementById("message");
  var input = inputElement.value;
  // Remove leading 0s but keep a single 0 if it precedes a decimal
  input = input.replace(/^0+(?!\.)/, "");
  inputElement.value = input;

  input = input.replace(/\s+/g, "");

  // Append a '0' if there's only one digit after the decimal
  if (input.includes(".") && input.split(".")[1].length === 1) {
    input += "0";
    inputElement.value = input;
  }

  // Validate the input pattern
  if (!input.match(/^[0-9]+(\.[0-9]{1,2})?$/)) {
    event.preventDefault();
    inputElement.classList.add("input-invalid");
    messageElement.textContent = "Please enter a valid number.";
    messageElement.style.color = "red";
    return;
  }

  var parts = input.split(".");
  var digitsBeforeDecimal = parts[0].length;

  // Check digit count before the decimal
  if (digitsBeforeDecimal > 15) {
    event.preventDefault();
    messageElement.textContent =
      "Input exceeds the maximum allowed digits before the decimal.";
    messageElement.style.color = "red";
  } else {
    inputElement.classList.remove("input-invalid");
    messageElement.textContent = "";
  }
}
