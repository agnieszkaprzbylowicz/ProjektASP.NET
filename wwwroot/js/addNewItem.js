(function () {
    const alertElement = document.getElementById("success-alert");
    const result = document.getElementById("result");
    const form = document.forms[0];
    const addNewItem = async () => {
        // 1. read data from the form
        const requestData = JSON.stringify({ Name: document.getElementById("Name").value, Description: document.getElementById("Description").value, IsVisible: document.getElementById("IsVisible").checked });
        // 2. call the application server using fetch method
        const url = "/api/item";
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: requestData
        });
        const responseJson = await response.json();
        if (responseJson.success) {
            alertElement.style.display = "";
            var array = responseJson.objectJson;
            let table = "<table width=\"100%\"><tr><th>ID</th><th>Name</th><th>Description</th><th>Visibility</th></tr>";
            for (var i = 0; i < array.length; i++) {
                let obj = array[i];
                table += `<tr><td>${obj.id}</td><td>${obj.name}</td><td>${obj.description}</td><td>${obj.isVisible}</td></tr>`;
            }
            table += "</table>";
            result.innerHTML = table;
            result.style.display = "";
        } 
    };
    window.addEventListener("load", () => {
        form.addEventListener("submit", event => {
            event.preventDefault();
            alertElement.style.display = "none";
            result.style.display = "none";
            addNewItem().then(() => console.log("added successfully"));
        });
    });
})();