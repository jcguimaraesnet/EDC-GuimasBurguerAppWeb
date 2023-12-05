using GuimasBurguerAppWeb.Data;
using GuimasBurguerAppWeb.Services;
using GuimasBurguerAppWeb.Services.Data;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => {
    options.Conventions.AuthorizeFolder("/Marcas");
    options.Conventions.AuthorizeFolder("/Categorias");
}).AddNToastNotifyToastr(new ToastrOptions()
                {
                    TimeOut = 5000,
                    ProgressBar = true,
                    PositionClass = ToastPositions.BottomRight
                });

builder.Services.AddTransient<IHamburguerService, HamburguerService>();

builder.Services.AddDbContext<HamburgueriaDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<HamburgueriaDbContext>();

builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

    // Lockout settings
    options.Lockout.MaxFailedAccessAttempts = 30;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.RequireUniqueEmail = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var context = new HamburgueriaDbContext();
context.Database.Migrate();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.UseNToastNotify();

app.Run();
