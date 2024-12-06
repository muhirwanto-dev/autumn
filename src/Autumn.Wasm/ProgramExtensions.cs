using Autumn.Wasm.ViewModel;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace Autumn.Wasm
{
    public static class ProgramExtensions
    {
        public static WebAssemblyHostBuilder AddServices(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMudServices();

            builder.Services.AddTransient<HomeViewModel>();

            return builder;
        }

        public static WebAssemblyHostBuilder AddHttpClient(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient 
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            });

            return builder;
        }
    }
}
