using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LightBucks.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                       policy =>
                       {
                           policy.WithOrigins("https://local.host:7045", "https://local.host:3000").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                       });
});

//FirebaseApp.Create(new AppOptions()
//{
   // Credential = GoogleCredential.FromFile("C:\\Users\\DavidVareba\\OneDrive - FreightWise, LLC\\Desktop\\BackEnd\\TheVadanaProperties\\VadanaProperties\\VadanaProperties\\vadanaproperties-firebase-adminsdk-dgv1e-bed8e42209.json"),
//});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.IncludeErrorDetails = true;
    options.Authority = "https://securetoken.google.com/lightbucks";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "https://securetoken.google.com/lightbucks",
        ValidateAudience = true,
        ValidAudience = "lightbucks",
        ValidateLifetime = true,
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICoffeeRepository, CoffeeRepository>();
builder.Services.AddTransient<ISnackRepository, SnackRepository>();
builder.Services.AddTransient<ITeaRepository, TeaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
