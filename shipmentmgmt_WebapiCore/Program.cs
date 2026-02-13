using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.DataLayer;
using shipmentmgmt_WebapiCore.DataLayer.implemetationIRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

//using shipmentmgmt_WebapiCore.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Iuser, implementationUser>();
builder.Services.AddScoped<Iaddress, ImplementatioinAddress>();
builder.Services.AddScoped<Ishipment, implementationshipment>();
builder.Services.AddScoped<Ishipmentitem, implementaionShipmentitem>();
builder.Services.AddScoped<dataaccess>();

//jwt 
builder.Services.AddScoped<ITokenService, TokenService>();
// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
// Create default error endpoint
app.Map("/error", (HttpContext httpContext) =>
{
    return Results.Problem("An unexpected error occurred.");
});

// thsi line from feature 

//app.UseMiddleware<ExceptionMiddleware>();;

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
