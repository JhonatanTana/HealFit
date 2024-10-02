using HealFit.DTO.Mapping;
using HealFit.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HealFit; 
public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://viacep.com.br/ws/") });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddAutoMapper(typeof(MappingProfile)); // Use a classe que contém seu perfil de mapeamento

        builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
        builder.Services.AddSingleton<IDadosService, DadosService>();
        builder.Services.AddSingleton<CepService>(); // Adicione esta linha

        return builder.Build();
    }
}
