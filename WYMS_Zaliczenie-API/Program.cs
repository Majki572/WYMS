var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WYMS_Zaliczenie_API.Data.DataContext>();


var app = builder.Build();
app.UseCors(builder => builder
    .WithOrigins(
        "http://localhost:50535",
        "https://localhost:44394",
        "http://localhost:5151",
        "https://localhost:7291"
    )
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
