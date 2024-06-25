using Microsoft.EntityFrameworkCore;
using Repositories.IRepository;
using Repositories.Repository;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IEntityRepo, EntityRepo>();
builder.Services.AddTransient<IEntityRepo, EntityRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICategoryRepo,CategoryRepo>();
builder.Services.AddTransient<ITransactionRepo, TransactionRepo>();
builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Repositories.Repository.DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NoCashDB")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
//builder.serviceaddscopedaswell
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
