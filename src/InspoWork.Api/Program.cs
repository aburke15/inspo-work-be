using InspoWork.Data;
using InspoWork.Services.Posts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string dbName = "inspo_work";
var myConnectionString = builder.Configuration.GetConnectionString(dbName);

builder.Services.AddDbContext<InspoWorkDbContext>(options =>
    options.UseNpgsql(myConnectionString));

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