async function loadProducts() {
    try {
        const response = await fetch("https://asp-dot-net-core-web-api-minimal-apis.onrender.com/products");
        const products = await response.json();

        const listContainer = document.getElementById("productList");
        listContainer.innerHTML = "";

        products.forEach(product => {
            const listItem = document.createElement("div");
            listItem.textContent = `${product.name} - $${product.price}`;
            listContainer.appendChild(listItem);
        });

    } catch (err) {
        console.error("Error loading products:", err);
    }
}

document.addEventListener("DOMContentLoaded", loadProducts);