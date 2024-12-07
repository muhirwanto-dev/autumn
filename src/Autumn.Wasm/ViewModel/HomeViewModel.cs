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
        private readonly HttpClient _httpClient;
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

        public HomeViewModel(HttpClient httpClient, IDialogService dialogService)
        {
            _httpClient = httpClient;
            _dialogService = dialogService;

            //_httpClient.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue { NoCache = true };
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AppSettings.AccessToken);
            _httpClient.BaseAddress = new Uri(AppSettings.AssetsSource);
        }

        public override async Task Loaded()
        {
            try
            {
                Profile = await GetGithubContent<ProfileEntity>("profile.json");
                Experiences = await GetGithubContent<ExperienceEntity[]>("experiences.json") ?? [];
                Projects = await GetGithubContent<ProjectEntity[]>("projects.json") ?? [];
                Skills = await GetGithubContent<SkillEntity[]>("skills.json") ?? [];
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessageBox("Error", ex.ToString());
            }
        }

        private async Task<T?> GetGithubContent<T>(string path)
        {
            var asset = await _httpClient.GetFromJsonAsync<GithubAsset>(path);
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
