var builder = WebApplication.CreateBuilder(args);
{
    // configure services (DI)
}

var app = builder.Build();
{
    // configure request pipeline
}

app.Run();