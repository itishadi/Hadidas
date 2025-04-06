using Hadidas.Data;
using Hadidas.Services.UserCRUD.Interface;
using Hadidas.Services.UserCRUD;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IAddUserService, AddUserService>();
builder.Services.AddScoped<IReadUserService, ReadUserService>();
builder.Services.AddScoped<IUpdateUserService, UpdateUserService>();
builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    Initialization.Initialize(db); 
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hadidas}/{action=Index}/{id?}");

app.Run();
