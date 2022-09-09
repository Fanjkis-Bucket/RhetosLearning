using Microsoft.OpenApi.Models;
using Rhetos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

void ConfigureRhetosHostBuilder(IServiceProvider serviceProvider, IRhetosHostBuilder rhetosHostBuilder)
{
    rhetosHostBuilder
        .ConfigureRhetosAppDefaults()
        .UseBuilderLogProviderFromHost(serviceProvider)
        .ConfigureConfiguration(cfg => cfg.MapNetCoreConfiguration(builder.Configuration));
}
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o => o.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
    {
         o.CustomSchemaIds(type => type.ToString());
         o.SwaggerDoc("rhetos", new OpenApiInfo { Title = "Rhetos REST API", Version = "v1" });
         o.SwaggerDoc("Common", new OpenApiInfo { Title = "Common REST API", Version = "v1" });
    });
builder.Services.AddRhetosHost(ConfigureRhetosHostBuilder)
    .AddAspNetCoreIdentityUser()
    .AddHostLogging()
    .AddRestApi(o => 
    {
        o.BaseRoute = "rest";
        o.GroupNameMapper = (conceptInfo, controller, oldName) => "rhetos";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/rhetos/swagger.json", "Rhetos REST API");
        c.SwaggerEndpoint("/swagger/Common/swagger.json", "Common REST API");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
