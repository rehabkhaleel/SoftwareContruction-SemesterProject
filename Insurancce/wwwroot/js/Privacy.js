document.getElementById('acceptButton').addEventListener('click', function () {
    // Show the popup
    document.getElementById('popupMessage').style.display = 'flex';
});

document.getElementById('closePopup').addEventListener('click', function () {
    // Close the popup
    document.getElementById('popupMessage').style.display = 'none';
});
