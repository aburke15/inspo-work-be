using InspoWork.Data;
using InspoWork.Services.Posts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var env = builder.Configuration.GetValue<string>("env");
var mongoUri = builder.Configuration.GetValue<string>("MONGO_URI");
var dbName = builder.Configuration.GetValue<string>("DatabaseName");

if (string.IsNullOrWhiteSpace(env) || string.IsNullOrWhiteSpace(mongoUri) || string.IsNullOrWhiteSpace(dbName))
{
    Environment.Exit(1);
}

dbName += env.ToLower() switch
{
    "local" => env,
    "development" => env,
    "production" => env,
    _ => throw new NotSupportedException($"Env value not supported: {env}")
};

builder.Services.AddDbContext<InspoWorkDbContext>(options =>
    options.UseMongoDB(mongoUri, dbName));

builder.Services.AddTransient<IPostService, PostService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// wrap this in an if statement and only show in dev env
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();