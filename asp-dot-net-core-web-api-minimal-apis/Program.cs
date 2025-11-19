using asp_dot_net_core_web_api_minimal_apis.Data;
using asp_dot_net_core_web_api_minimal_apis.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();

var port = Environment.GetEnvironmentVariable("PORT") ?? "7076";
app.Urls.Add($"http://*:{port}");

// CREATE
app.MapPost("/products", (int id, string name, decimal price) =>
{
    try
    {
        Product product = new Product(id, name, price);

        Database.Products.Add(product);

        return Results.Created($"/products/?id={id}", product);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// READ
app.MapGet("/products/{id?}", (int? id) =>
{

    try
    {
        HashSet<Product> products = Database.Products;

        if (products.Count == 0 || products == null)
        {
            return Results.NoContent();
        }

        if (id != null)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return Results.NotFound(product);
            }

            return Results.Ok(product);
        }

        return Results.Ok(products);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// UPDATE
app.MapPut("/products/edit/{id}", (int? id, string? name, decimal? price) =>
{
    try
    {
        Product product = Database.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return Results.NotFound(product);
        }

        if (name != null)
        {
            product.Name = name;
        }

        if (price != null)
        {
            product.Price = (decimal)price;
        }

        return Results.Ok(product);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// DELETE
app.MapDelete("/products/{id}", (int? id) =>
{
    try
    {
        Product product = Database.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return Results.NotFound(product);
        }

        Database.Products.Remove(product);
        return Results.Ok($"Product deleted: {product.Name}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();
