var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<CarTireDb>(opt => opt.UseInMemoryDatabase("TodoList"));
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// app.MapGet("/car/{carId}/{tire}", async (int carId, int tire) => {
//     return await tire.
// });

// app.MapPost("/car" );

app.Run();