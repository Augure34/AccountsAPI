using Account.API.Models;
using Account.API.Repositories;
using Account.API.Repositories.Interfaces;
using Account.API.Services;
using Account.API.Services.Interfaces;
using Account.API.Specifications;
using Account.API.Specifications.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    // Specification layer
    .AddScoped<ICustomerAccountSpecification, CustomerAccountSpecification>()
    .AddScoped<ICustomerSpecification, CustomerSpecification>()

    // Service layer
    .AddScoped<ITransactionService, TransactionService>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<ICustomerAccountService, CustomerAccountService>()

    // Data access layer
    .AddScoped<ICustomerAccountRepository, CustomerAccountRepository>()
    .AddScoped<ICustomerRepository, CustomerRepository>()

    .AddSingleton<IDataStorage>(new FakeInMemoryStorage());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();