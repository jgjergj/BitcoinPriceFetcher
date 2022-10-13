using BitcoinPriceFetcher.Data;
using BitcoinPriceFetcher.Data.Repositories;
using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.Services;
using BitcoinPriceFetcher.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<IBitcoinPriceRepository, BitcoinPriceRepository>();
builder.Services.AddScoped<ISourcesRepository, SourcesRepository>();
builder.Services.AddScoped<IBitcoinPriceServices, BitcoinPriceServices>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
