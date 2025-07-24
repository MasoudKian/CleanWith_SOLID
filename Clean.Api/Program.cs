using Clean.Infrastructure;
using Clean.Persistence;
using Clean.Application;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ اینا قبل از Build باید باشه
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
//builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", b =>
        b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
});

// ✅ بعد از اینکه همه سرویس‌ها Configure شدن، Build کن
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json","Example api"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();
app.Run();
