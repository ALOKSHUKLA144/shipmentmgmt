using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.DataLayer;
using shipmentmgmt_WebapiCore.DataLayer.implemetationIRepository;
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



//app.UseMiddleware<ExceptionMiddleware>();;

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
