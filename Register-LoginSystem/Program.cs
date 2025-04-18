using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Register_LoginSystem.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddSession();
builder.Services.AddDbContext<myDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));

var app = builder.Build();
app.MapControllerRoute(
    
    name: "default",
    pattern: "{controller=User}/{action=Register}"
    
    );

app.UseStaticFiles();
app.UseSession();

app.Run();
