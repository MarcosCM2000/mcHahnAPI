using mcHahn.Application;
using mcHahn.Infrastructure;
using mcHahnAPI.Filters;
using mcHahnAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

//  CORS
var myAllowSpecificOrigins = "_myAllowSpecificOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy => {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
// FILTERS
//  builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();