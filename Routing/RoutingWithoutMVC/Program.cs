var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.MapControllers();
//app.MapGet("/", () => "Hello World!");

// Middleware

// use method is used for multiple middleware with 2 parameter 
app.Use(async (context, next) => {
    await context.Response.WriteAsync("my name is Hello word second middleware \n");
    await next(context);
});
app.Use(async (context, next) => {
    await context.Response.WriteAsync("my name is Hello word first middleware \n");
    await next(context);
});

// run method is used for single middleware with single parameter
app.Run(async (context) =>
{
    await context.Response.WriteAsync("my name is run middleware \n");
});


//app.MapDefaultControllerRoute();     // call default controller and view

app.MapControllerRoute(                //OR We can use like that also for default call the controller
    name: "default",
    pattern:"{Controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "userRoute",
    pattern: "{Controller=User}/{action=Index}/{id?}"
    );

app.Run();
