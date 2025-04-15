using System.Net.Security;

var builder = WebApplication.CreateBuilder(args);

// Return an instance of WebApplication
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    if (path == "/" || path == "/Home")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("In Homepage");
    }
    else if (path == "/Contact")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("In Contact page");
    }
    else if (method == "GET" && path == "/Product")
    {
        context.Response.StatusCode = 200;
        if (context.Request.Query.ContainsKey("id") && context.Request.Query.ContainsKey("name"))
        {
            string id = context.Request.Query["id"];
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync($"Product {name} with Id: {id}");
            return;
        }

        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("In Product page");
    }
    else if (method == "POST" && path == "/Product")
    {
        StreamReader reader = new StreamReader(context.Request.Body);
        string data = await reader.ReadToEndAsync();
        await context.Response.WriteAsync("Request body contains: " +data);
    }
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("NOT FOUND");
    }
});

app.Run();
