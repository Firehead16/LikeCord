using LikeCordServer;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Добавляем SignalR
builder.Services.AddSignalR();

// Добавляем CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true); // Разрешаем все источники
    });
});

// Логирование
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

var app = builder.Build();

// Включаем CORS
app.UseCors("CorsPolicy");

// Маршрут для хаба SignalR
app.MapHub<ChatHub>("/chatHub");

// Запускаем приложение
app.Run();
