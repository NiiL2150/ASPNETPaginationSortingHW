using ASPNETPaginationSortingHW.Repositories.Classes;
using ASPNETPaginationSortingHW.Repositories.Interfaces;
using ASPNETPaginationSortingHW.Services;
using ASPNETPaginationSortingHW.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IAppData, AppData>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
