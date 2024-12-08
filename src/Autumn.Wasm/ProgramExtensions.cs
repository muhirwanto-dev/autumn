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
            builder.Services.AddHttpClient(Constants.HttpClientNames.OfflineClient, client =>
            {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                client.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue { NoCache = true };
            });

            builder.Services.AddHttpClient(Constants.HttpClientNames.OnlineClient, client =>
            {
                client.BaseAddress = new Uri(AppSettings.AssetsSource);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AppSettings.AccessToken);
            });

            return builder;
        }
    }
}
