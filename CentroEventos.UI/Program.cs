using CentroEventos.UI.Components;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Repositorios;

CentroEventosSqlite.Inicializar();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddTransient<UsuarioAltaUseCase>();
builder.Services.AddTransient<UsuarioBajaUseCase>();
builder.Services.AddTransient<UsuarioModificacionUseCase>();
builder.Services.AddTransient<ListarUsuariosUseCase>();

builder.Services.AddTransient<EventoDeportivoAltaUseCase>();
builder.Services.AddTransient<EventoDeportivoBajaUseCase>();
builder.Services.AddTransient<EventoDeportivoModificacionUseCase>();
builder.Services.AddTransient<ListarEventosDeportivosUseCase>();

builder.Services.AddTransient<ReservaAltaUseCase>();
builder.Services.AddTransient<ReservaBajaUseCase>();
builder.Services.AddTransient<ReservaModificacionUseCase>();
builder.Services.AddTransient<ListarReservasUseCase>();

builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();
builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddTransient<ServicioAutorizacionUseCase>();

builder.Services.AddTransient<EventoDeportivoValidador>();
builder.Services.AddTransient<ReservaValidador>();
builder.Services.AddTransient<UsuarioValidador>();

builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IServicioAutorizacion, ImplementacionServicioAutorizacion>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
