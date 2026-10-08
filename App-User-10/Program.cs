using APP_BUS_L_10.Profiles;
using APP_BUS_L_10.Services.Attachment;
using APP_BUS_L_10.Services.Departments;
using APP_DATA_A_10.Date.Contexts;
using APP_DATA_A_10.Models.Auth_User;
using APP_DATA_A_10.Repositories.Depatment;
using APP_DATA_A_10.Repositories.Employees;
using APP_DATA_A_10.Repositories.UOW;
using APP_DATA_A_10.Services.Employees;
using APP_DATA_A_10.Services.Employees.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews((o) =>
{
    o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

});


builder.Services.AddDbContext<APPDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseLazyLoadingProxies();
});

builder.Services.AddScoped<IDepartmentRepositorie,DepartmentRepositorie>();
builder.Services.AddScoped<IEmployeeRepositry,EmployeeRepositry>();
builder.Services.AddScoped<IDepartmentServices,DepartmentServices>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();
builder.Services.AddScoped<IUnitOfWork ,UnitOfWork>();
builder.Services.AddScoped<IEmployeeFactory, EmployeeFactory>();
builder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfile()));

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<APPDbContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{

    options.AccessDeniedPath = "/Auth/AccessDenied";
    options.LoginPath = "/Auth/LogIn";
    options.LogoutPath = "/Auth/LogOut";
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=LogIn}/{id?}");

app.Run();
