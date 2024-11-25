var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Map("/Home", () => "Hello World! .. Map");
//app.MapGet("/Home", () => "Hello World! .. GEt");
//app.MapPost("/Home", () => "Hello World!.. Post");
//app.MapPut("/Home", () => "Hello World!.. Put");
//app.MapDelete("/Home", () => "Hello World!..Delete");

app.UseRouting();  // Set up routing middleware

// Define the routes
app.MapGet("/Home", async (context) =>
{
    await context.Response.WriteAsync("This is Home page...!");
});

app.MapPost("/Home", async (context) =>
{
    await context.Response.WriteAsync("This is Home page... Post!");
});

app.MapPut("/Home", async (context) =>
{
    await context.Response.WriteAsync("This is Home page... Put!");
});

app.MapDelete("/Home", async (context) =>
{
    await context.Response.WriteAsync("This is Home page... Delete!");
});
app.Map("", () => "Hello World!");

//// Catch-all for unmatched requests
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Page Not Found");
//});

app.Run();
