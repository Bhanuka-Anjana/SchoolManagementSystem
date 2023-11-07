

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//01
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("ocelotConfig.json", optional:false,reloadOnChange:true);

// Add services to the container.
builder.Services.AddControllers();

//02
builder.Services.AddOcelot();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//03
app.UseOcelot().Wait();

app.Run();
