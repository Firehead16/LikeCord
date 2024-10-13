using LikeCordServer;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// ��������� SignalR
builder.Services.AddSignalR();

// ��������� CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true); // ��������� ��� ���������
    });
});

// �����������
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

var app = builder.Build();

// �������� CORS
app.UseCors("CorsPolicy");

// ������� ��� ���� SignalR
app.MapHub<ChatHub>("/chatHub");

// ��������� ����������
app.Run();
