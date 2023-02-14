using Microsoft.EntityFrameworkCore;

using Delivery.Data;
using Delivery.Entity;
using Delivery.Repositories.Interfaces;
using Delivery.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MyDbPgsql ");
builder.Services.AddDbContext<DeliveryDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
/*app.MapPost("/Customer/", async (Customer e, DeliveryDbContext db) =>
{
    db.Customers.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/Customer/{e.Id}", e);
});

app.MapGet("/Customer/{id:int}", async (int id, DeliveryDbContext db) =>
{
    return await db.Customers.FindAsync(id)
    is Customer e
    ? Results.Ok(e)
    :Results.NotFound();
}
);

app.MapGet("/Customer", async (DeliveryDbContext db) =>await db.Customers.ToListAsync());

app.MapPut("/Customer/{id:int}", async (int id, Customer e, DeliveryDbContext db) =>
{
    if (e.Id != id)  return Results.BadRequest();

        var Customer = await db.Customers.FindAsync(id);

        if (Customer is null) return Results.NotFound();

        Customer.Name = e.Name;
        Customer.Email = e.Email;
        Customer.PhoneNumber = e.PhoneNumber;
        Customer.Address = e.Address;
        Customer.Status = e.Status;


        await db.SaveChangesAsync();


        return Results.Ok(Customer);
    
});

app.MapDelete("/Customer/{id:int}", async (int id, DeliveryDbContext db) =>
{
        var Customer = await db.Customers.FindAsync(id);
        if (Customer is null) { return Results.NotFound(); }

        db.Customers.Remove(Customer);
        await db.SaveChangesAsync();
        return Results.NoContent();
    
}
);*/

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}