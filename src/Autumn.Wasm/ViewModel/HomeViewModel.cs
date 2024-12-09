using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Autumn.Contract.Entities;
using Autumn.Contract.GitHub;
using Blazing.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MudBlazor;

namespace Autumn.Wasm.ViewModel
{
    public partial class HomeViewModel : ViewModelBase
    {
        private readonly HttpClient _onlineClient;
        private readonly HttpClient _offlineClient;
        private readonly IDialogService _dialogService;

        [ObservableProperty]
        private ProfileEntity? _profile;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TopThreeSkills))]
        private SkillEntity[] _skills = [];

        [ObservableProperty]
        private ExperienceEntity[] _experiences = [];

        [ObservableProperty]
        private ProjectEntity[] _projects = [];

        public SkillEntity[] TopThreeSkills => Skills.Length > 3
            ? Skills.Take(3).ToArray() : Skills;

        public HomeViewModel(IHttpClientFactory clientFactory, IDialogService dialogService)
        {
            _onlineClient = clientFactory.CreateClient(Constants.HttpClientNames.OnlineClient);
            _offlineClient = clientFactory.CreateClient(Constants.HttpClientNames.OfflineClient);
            _dialogService = dialogService;
        }

        public override async Task Loaded()
        {
            try
            {
                Profile = await LoadContentAsync<ProfileEntity>("profile.json");
                Experiences = await LoadContentAsync<ExperienceEntity[]>("experiences.json") ?? [];
                Projects = await LoadContentAsync<ProjectEntity[]>("projects.json") ?? [];
                Skills = await LoadContentAsync<SkillEntity[]>("skills.json") ?? [];
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessageBox("Error", ex.ToString());
            }
        }

        private async Task<T?> LoadContentAsync<T>(string content)
        {
            try
            {
                var onlineContent = await GetGithubContentAsync<T>(content);
                if (onlineContent != null)
                {
                    return onlineContent;
                }
            }
            catch
            {
                await _dialogService.ShowMessageBox("Error", $"Failed to fetch online data: {content}");
            }

            return await _offlineClient.GetFromJsonAsync<T>($"data/{content}");
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
