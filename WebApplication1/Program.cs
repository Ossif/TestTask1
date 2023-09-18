using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string connection = builder.Configuration.GetConnectionString("DbTestTask"); 
builder.Services.AddDbContext<CRUDContext>(options => options.UseSqlServer(connection));

builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo { 
		Title = "My API",
		Version = "v1",
	});
	c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c => { 

	c.SwaggerEndpoint("./v1/swagger.json", "My API V1");	
});

app.MapRazorPages();
app.MapControllers();

app.UseDeveloperExceptionPage();

app.Run();
