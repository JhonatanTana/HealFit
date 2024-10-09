using HealFit.Service;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace HealFit;
public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });


        builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
        builder.Services.AddSingleton<IDadosService, DadosService>();
        builder.Services.AddSingleton<CepService>();
        builder.Services.AddSingleton<BaseUrlProvider>();

        builder.Services.AddScoped(sp => {
            var baseUrlProvider = sp.GetRequiredService<BaseUrlProvider>();
            return new HttpClient { BaseAddress = new Uri(baseUrlProvider.BaseUrl) };
        });

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://viacep.com.br/ws/") });
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://192.168.1.11") });
        builder.Services.AddHttpClient<FatSecretService>();


        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}