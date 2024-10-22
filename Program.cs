var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var pizzas = builder.Configuration.GetSection("Pizzas").Get<List<Lr6.Models.ProductModel>>();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddSingleton(pizzas);
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PizzaOrder}/{action=Register}/{id?}");


app.Run();
