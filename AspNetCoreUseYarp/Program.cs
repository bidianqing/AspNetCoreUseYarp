using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(builderContext => 
    {
        builderContext.AddResponseHeaderRemove("X-Frame-Options");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapReverseProxy();
app.MapControllers();

app.Run();
