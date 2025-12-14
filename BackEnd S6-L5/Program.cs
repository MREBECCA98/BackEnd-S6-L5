using BackEnd_S6_L5.Models.Entities;
using BackEnd_S6_L5.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = string.Empty;
try
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new Exception("Stringa di connessione non trovata");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}


builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString)
    );

builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<ICameraServices, CameraServices>();
builder.Services.AddScoped<IPrenotazioneServices, PrenotazioneServices>();

//IDENTITY CONFIGURATION


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.SignIn.RequireConfirmedPhoneNumber = false; //disapilitata la conferma per telefono 
    option.SignIn.RequireConfirmedEmail = false; //disabilitata la conferma via email
    option.SignIn.RequireConfirmedAccount = false; //disabilito la conferma dell'account per il login 
    option.Password.RequiredLength = 10; //almeno 10 caratteri
    option.Password.RequireDigit = false; //non è obbligatorio un numero nella password
    option.Password.RequireLowercase = true; //è obbligatoria la lettera minuscola nella pw
    option.Password.RequireUppercase = true; //è obbligatoria una lettera maiuscla nella pw
    option.Password.RequireNonAlphanumeric = false; //non è obbligatorio un carattere speciale nella pw
                                                    //option.User.RequireUniqueEmail = true; //ogni utente deve avere un unica email
}
  ).AddEntityFrameworkStores<ApplicationDbContext>(). //configuro l'identity per usare ef core
  AddDefaultTokenProviders(); //aggiungo il provider per la generazione dei token

//configurazione di user manager signin manager e role manager
builder.Services.AddScoped<UserManager<ApplicationUser>>(); //gestione utenti fornito dal framework
builder.Services.AddScoped<SignInManager<ApplicationUser>>(); //gestione log in
builder.Services.AddScoped<RoleManager<IdentityRole>>(); //gestione ruoli

//COOKIE 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/User/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

});








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//rispettare l'ordine verticale per il funzionamento (UseAuthentication)
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
