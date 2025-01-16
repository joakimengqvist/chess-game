using ChessGameService.Enums;
using ChessGameService;
using ChessGameService.ChessGame;
using ChessGameService.ChessPieces;
using ChessGameService.Controllers;

var builder = WebApplication.CreateBuilder(args);

const string allowedOriginsName = "_AllowedOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowedOriginsName,
        policyBuilder =>
        {
            policyBuilder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new ChessGame(Color.White, null));

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(allowedOriginsName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


app.Run();