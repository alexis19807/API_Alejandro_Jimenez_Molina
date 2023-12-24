using API_Alejandro_Jimenez_Molina;
using API_Alejandro_Jimenez_Molina.Extensions;
using Application;
using Application.Sportman.Create;
using Application.Validators;
using FluentValidation;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
				.AddInfrastructure(builder.Configuration)
				.AddApplication();

builder.Services.AddScoped<IValidator<CreateSportmanCommand>, CreateSportManValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
