using OneReview.Services;

var builder = WebApplication.CreateBuilder(args);
{
    // configure services (DI)
    builder.Services.AddScoped<ProductsService>();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // configure request pipeline
    app.MapControllers();
}

app.Run();
