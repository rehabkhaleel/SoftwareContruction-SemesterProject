const text = "Code Benders";
const element = document.getElementById("codeBenders");
let index = 0;

function typewriter() {
    if (index < text.length) {
        element.textContent += text.charAt(index);
        index++;
        setTimeout(typewriter, 250); // Adjust typing speed
    } else {
        setTimeout(() => {
            element.textContent = ""; // Clear the text
            index = 0; // Reset the index
            typewriter(); // Restart the animation
        }, 1500); // Pause before restarting
    }
}

// Start the typewriter effect on page load
document.addEventListener("DOMContentLoaded", typewriter);
