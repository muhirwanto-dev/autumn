using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Autumn.Wasm.Models.GitHub;
using Autumn.Wasm.Interfaces;

namespace Autumn.Wasm.Services
{
    public class DataSourceService : IDataSourceService
    {
        private readonly HttpClient _onlineClient;
        private readonly HttpClient _offlineClient;

        public DataSourceService(IHttpClientFactory clientFactory)
        {
            _onlineClient = clientFactory.CreateClient(Constants.HttpClientNames.OnlineClient);
            _offlineClient = clientFactory.CreateClient(Constants.HttpClientNames.OfflineClient);
        }

        public async Task<TModel?> DownloadDataSourceAsync<TModel>(string content)
        {
            try
            {
                var onlineContent = await GetGithubContentAsync<TModel>(content);
                if (onlineContent != null)
                {
                    return onlineContent;
                }
            }
            catch
            {
            }

            return await _offlineClient.GetFromJsonAsync<TModel>($"data/{content}");
        }

        private async Task<T?> GetGithubContentAsync<T>(string path)
        {
            var asset = await _onlineClient.GetFromJsonAsync<GithubAsset>(path);
            if (asset == null || asset.Content == null)
            {
                return default;
            }

            var buffer = Convert.FromBase64String(asset.Content);
            var decoded = Encoding.UTF8.GetString(buffer);

            return JsonSerializer.Deserialize<T>(decoded);
        }
    }
}
