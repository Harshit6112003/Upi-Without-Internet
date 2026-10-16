using Upi_Without_Internet.Models;
using Microsoft.EntityFrameworkCore;
using Upi_Without_Internet;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContextcs>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OfflineBankDb"))); 
var app = builder.Build();

var payment_list = new List<Payment>();

app.MapPost("/payment", (Payment x) => {
    if(x.Amount < 0)
    {
        return Results.NotFound("the amount is less than zero");
    }
    x.Id = payment_list.Count + 1;
    payment_list.Add(x);
    return Results.Created("", x);
});

app.MapGet("/payments", () =>
{
    return Results.Ok(payment_list);
});
app.MapGet("/payments/{id}", (int id) =>
{
    var pay = payment_list.FirstOrDefault(x => x.Id == id);
    if(pay == null)
    {
        return Results.NotFound("the id is not present");
    }
    return Results.Ok(pay);
});

app.UseHttpsRedirection();



app.Run();

