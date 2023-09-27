using CleanArchitecture.Domain.Account;
using CleanArchitecture.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configure MyInfrastructure
builder.Services.AddInfractructure(builder.Configuration);


var app = builder.Build();

var initial = app.Services.CreateScope().ServiceProvider.GetService<ISeedUserRoleInitial>();

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

initial.SeedRoles();
initial.SeedUsers();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
