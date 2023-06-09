using api_versioning_demo.Middlewares;
using api_versioning_demo.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
// Adding the configuration of API versioning
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
    
    //x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

//builder.Services.AddTransient<IConfigurationOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware();
app.UseCustom2Middleware();

/*// Middleware - A
app.Use(async(context,next) =>{
    await context.Response.WriteAsync("Middleware A (before)\n");
    await next();
    await context.Response.WriteAsync("Middleware A (after)\n");
});

// Middleware - B
app.Use(async (context, next) => {
    await context.Response.WriteAsync("Middleware B (before)\n");
    await next();
    await context.Response.WriteAsync("Middleware B (after)\n");
});*/

// Middleware - C
app.Run(async context => {
    await context.Response.WriteAsync("Middleware C (executed)\n");
});
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            description.ApiVersion.ToString()
            );
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
