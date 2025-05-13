using Microsoft.EntityFrameworkCore;
using TreeTalk.Settings;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using TreeTalkModel.Model.Data;
using TreeTalk.Controllers;

var builder = WebApplication.CreateBuilder(args);
// configurations
var constr = builder.Configuration.GetSection("constr").Value;
var jwtSettings = builder.Configuration.GetSection("AppSettings:Jwt").Get<JwtSettings>();
var googleSettings = builder.Configuration.GetSection("Authentication:Google").Get<GoogleSettings>();

if (jwtSettings is null)
{
  throw new InvalidOperationException("jwt settings not found in configuration.");
}
if (googleSettings is null)
{
    throw new InvalidOperationException("Google settings not found in configuration.");
}

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TreeTalkDbContext>(options => 
  options.UseNpgsql(constr)
);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("AppSettings:Jwt"));

builder.Services.AddSingleton<JwtService>();
builder.Services.AddSingleton<ILogger , Logger<AuthController>>();

builder.Services
  .AddAuthentication(
    options => {
      options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    }
  )
  .AddCookie(
    options => {
      options.LoginPath = "/Auth/Login";
      options.AccessDeniedPath = "/Auth/AccessDenied";
      options.ExpireTimeSpan = TimeSpan.FromHours(1);
      options.SlidingExpiration = true;
      options.Cookie.HttpOnly = true;
      options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    }
  )
  .AddGoogle(
    options => {
      options.ClientId = googleSettings!.ClientId!;
      options.ClientSecret = googleSettings.ClientSecret!;
      options.CallbackPath = googleSettings.ClientCallback!;
      options.Scope.Add("https://www.googleapis.com/auth/user.birthday.read");
      options.Scope.Add("https://www.googleapis.com/auth/user.gender.read");
    }
  );

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Auth}/{action=Register}");

app.Run();
