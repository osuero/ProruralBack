using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProRualBackEnd.Mappers;
using Repository.AuthInterfaces;
using Repository.AuthRepositories;
using Repository.EntityRepositories;
using Repository.EntityRepository;
using Repository.EtitiyInterfaces;
using Repository.GeographicalInterface;
using Repository.GeographicalRepository;
using Repository.ValidationInterface;
using Repository.ValidationRepository;
using Services.Auth;
using Services.AuthInterface;
using Services.EntityInterfaces;
using Services.EntityServices;
using Services.GeographicalInterface;
using Services.GeographicalsServices;
using Services.SettingsModels;
using Services.ValidationInterfaces;
using Services.ValidationServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["Key"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();
builder.Services.AddScoped<IBeneficiaryService, BeneficiaryService>();

builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();

builder.Services.AddScoped<IOrganizationService, OrganizationService>();

builder.Services.AddScoped<IProductionCategoryRepository, ProductionCategoryRepository>();

builder.Services.AddScoped<IProductionCategoryService, RubleService>();

builder.Services.AddScoped<IidentificaciontService, IdentificationService>();

builder.Services.AddScoped<IidentificationRepository, IdentificationRepository>();
builder.Services.AddScoped<IFundRepository, FundRepository>();
builder.Services.AddScoped<IFundService, FundService>();


builder.Services.AddScoped<IProjectStatusRepository, ProjectStatusRepository>();
builder.Services.AddScoped<IProjectTypeRepository, ProjectTypeRepository>();
builder.Services.AddScoped<IicvRepository, IcvRepository>();

builder.Services.AddScoped<IGeographicRepository, GeographicRepository>();
builder.Services.AddTransient<IGeographicalService, GeographicalService>();


builder.Services.AddScoped<IProjectStatusService, ProjectStatusService>();
builder.Services.AddScoped<IProjectTypeService, ProjectTypeService>();

builder.Services.AddScoped<IicvRepository, IcvRepository>();
builder.Services.AddScoped<IIcvService, IcvService>();
builder.Services.AddScoped<IFinancingGroupRepository, FinancingGroupRepository>();
builder.Services.AddScoped<IFinancingGroupService, FinancingGroupService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        
        builder.WithOrigins("http://localhost:4200", "http://octaviosuero-003-site4.jtempurl.com") 
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});


MappingConfigurations.RegisterMappings(builder.Services);

var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.Run();
