var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();  // Enables MVC views
builder.Services.AddEndpointsApiExplorer();  // Add support for API endpoint discovery
builder.Services.AddSwaggerGen();  // Enable Swagger for API documentation

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Ensure Swagger is available at /swagger only, and not the default URL
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger";  // Swagger UI will only be available at /swagger
    });
}

app.UseHttpsRedirection();  // Ensure HTTPS is used
app.UseStaticFiles();  // Serve static files (e.g., CSS, JS, images)

app.UseRouting();  // Set up routing for controllers

// Enable authorization middleware if needed
app.UseAuthorization();

// Set up the default MVC route pattern (this is where the view will load by default)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MyBot}/{action=Chat}/{id?}");  // Default MVC route for the Chat action in MyBot controller

app.MapControllers();  // Map API controllers (this is for the APIs)

app.Run();  // Run the application
