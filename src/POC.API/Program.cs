var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
builder.AddSwagger();
builder.AddCommonServices();
builder.Services.AddCors();


var app = builder.Build();
var environment = app.Environment;
app
    .UseExceptionHandling(environment)
    .UseHttpsOnlyOnNonDevelopmentEnvironments(environment)
    .UseSwaggerEndpoints(routePrefix: string.Empty)
    .UseAppCors()
    ;

app.Run();