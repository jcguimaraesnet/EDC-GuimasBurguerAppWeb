using GuimasBurguerAppWeb.Data;
using GuimasBurguerAppWeb.Services;
using GuimasBurguerAppWeb.Services.Data;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
                .AddNToastNotifyToastr(new ToastrOptions()
                {
                    TimeOut = 5000,
                    ProgressBar = true,
                    PositionClass = ToastPositions.BottomRight
                });

builder.Services.AddTransient<IHamburguerService, HamburguerService>();

builder.Services.AddDbContext<HamburgueriaDbContext>();


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

app.UseAuthorization();

app.MapRazorPages();

app.UseNToastNotify();

app.Run();
