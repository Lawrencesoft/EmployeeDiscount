using Lative.Discounts.API;
using Lative.Discounts.Domain;
using Lative.Discounts.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
});

//Setup Dependancy Injection
builder.Services.AddSingleton<IEmployeeDiscountsDomain, EmployeeDiscountsDomain>()
    .AddSingleton<IEmployeeDiscountsInfrastructure, EmployeeDiscountsInfrastructure>()
    .AddSingleton<IEmployeeDiscountsService, EmployeeDiscountsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1"));
}

app.MapFallback(() => Results.Redirect("/swagger"));

app.MapGet("/apply-discount", (decimal amount, int employeeId) =>
{
    //invoke the discount service
    var _dicountsService = app.Services.GetService<IEmployeeDiscountsService>();
    if (_dicountsService == null)
        return Results.NotFound("Discount Service is not available");
    var discountedAmount = _dicountsService.ApplyDiscount(amount, employeeId);
    if (discountedAmount != null)
    {
        return Results.Ok(discountedAmount);
    }
    else
    {
        return Results.NotFound("Invalid input request or exception on the Discount calculation");
    }

});

app.Run();