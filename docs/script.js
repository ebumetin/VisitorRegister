document.addEventListener("DOMContentLoaded", () => {

    const button = document.getElementById("reg-button");

    button.addEventListener("click", () => {
        const name = document.getElementById("user-input").value;
        alert(name + " har registrerats! 🎉");
    });
});