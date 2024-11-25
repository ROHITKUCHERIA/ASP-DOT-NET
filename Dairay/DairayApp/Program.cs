using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//************************************************ Custom Middleware Start *************************

// use method is used for multiple middleware with 2 parameter 
app.Use(async (context, next) => {
    await context.Response.WriteAsync("Hello world first use middleware \n");
    await next(); // Don't forget to call next to pass the request to the next middleware
});

app.Use(async (context, next) => {
    await context.Response.WriteAsync("Second Hello world use middleware \n");
    await next(); // Again, make sure to call next to continue the pipeline
});

// run method is used for single middleware with single parameter and Run is terminal, so this will be the final response 
app.Run(async (context) =>
{
    await context.Response.WriteAsync("My name is run middleware \n");
});
//************************************************ Custom Middleware End *************************

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
