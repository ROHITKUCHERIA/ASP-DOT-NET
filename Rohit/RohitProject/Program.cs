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

// run method is used for single middleware with single parameter
app.Run(async (context) => {
    await context.Response.WriteAsync("my name is run middleware \n");
    
});

// use method is used for multiple middleware with 2 parameter 
app.Use(async (context, next) => {  
    await context.Response.WriteAsync("my name is Hello word second middleware \n");
    await next(context);
});
app.Use(async (context, next) => {
    await context.Response.WriteAsync("my name is Hello word first middleware \n");
    await next(context);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
