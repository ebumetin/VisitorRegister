// När sidan har laddats
document.addEventListener("DOMContentLoaded", () => {

    const button = document.getElementById("reg-button");
    const functionUrl = "https://app-register-visitor-cxgwcvfeb7hcb7f2.swedencentral-01.azurewebsites.net/api/RegistrationTrigger?code=ar2I7jrDO-NGv2SD9iKdKfAPfiaO7s6TqdET37P-xeVLAzFuDjzFow==";

    button.addEventListener("click",  () => {
        console.log("clicked!");

        // Hämta namnet från inputfältet
        const name = document.getElementById("user-input").value;

        // Kontrollera att fältet inte är tomt
        if (name === "") {
            alert("Namnet får inte vara tomt");
        } else {
            // Skicka POST-request till Azure Function
            fetch(functionUrl, {
                method: "POST",
                headers: {
                    "Content-Type": "text/plain"
                },
                body: name
            })
            .then(data => {
                if (data.status === 200) {
                    alert(name + " har registrerats! 🎉"); // Bekräftelse
                } else  {
                    alert("Det gick inte att registrera namnet.")
                }
                document.getElementById("user-input").value = ""; // Töm fältet
            })
            .catch(error => {
                console.error("Fel vid anropet:", error);
                alert("Kunde inte registrera, se konsolen för fel.");
            });
        }
    });
});