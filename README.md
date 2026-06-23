# ASP.NET CORE WEB API USING RENDER PLATFORM - MINIMAL APIS

This is a simple ASP.NET Core Web API using minimal APIs to handle CRUD
operations. The app can be deployed on Render with the help of Dockerfile and
can return JSON responses.

You can access the deployed API at: [minimal-apis](https://asp-dot-net-core-web-api-minimal-apis.onrender.com/products)

## CRUD Endpoints

### `POST /products`
- Create a new product
- **Parameters:** id (int), name (string), price (decimal),
    - i.e.:
        1. in query string:
        ```
            /products/?id=1&name=product&price=1.99
        ```
        2. in JSON body:
        ```
        {
            id = 1,
            name = "new product",
            price = 1.99
        }
        ```
- Response: JSON object of the created product

### `GET /products`
- Retrieve all products
- **Parameters:** None
- Response: JSON array of products


### `GET /products/{id}`
- Retrieve a product by ID
- **Parameters:** id (int)
    - i.e.: `/products/1`
- Response: JSON object of the product with the specified ID

### `PUT /products/{id}`
- Update an existing product by ID
- **Parameters:** id (int), name (string, optional), price (decimal, optional)
    - i.e.:
        1. in query string:
        ```
            /products/1/?name=updated product&price=2.99
        ```
        2. in JSON body:
        ```
        {
            name = "updated product",
            price = 2.99
        }
        ```
- Response: JSON object of the updated product

### `DELETE /products/{id}`
- Delete a product by ID
- **Parameters:** id (int)
    - i.e.: `/products/1`
- Response: JSON object of the deleted product

## Notes
- The API uses an in-memory list to store products, which means data will be lost when the application restarts.
- Make sure to test the endpoints using tools like Postman.
- Base URL: `https://asp-dot-net-core-web-api-minimal-apis.onrender.com`.
- Localhost URL: `https://localhost:7076`.