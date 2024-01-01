using Hangfire;
using Hangfire.Services;
using System.Net.Mail;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHangfire(config => config.UseSqlServerStorage("Data Source=DESKTOP-3QG9GTV;" +
    "Initial Catalog=UdemyHangFire;Integrated Security=True;Connect Timeout=30;Encrypt=True;" +
    "Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IEmailSender, EmailSender>();

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

//www.mysite.com/hangfire da görünür
app.UseHangfireDashboard("/hangfire");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
