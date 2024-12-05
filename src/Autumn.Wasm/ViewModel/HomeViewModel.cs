using System.Net.Http.Json;
using Blazing.Mvvm.ComponentModel;
using Autumn.Contract.Entities;
using MudBlazor;
using CommunityToolkit.Mvvm.ComponentModel;

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
        }

        public override async Task Loaded()
        {
            try
            {
                Profile = await _httpClient.GetFromJsonAsync<ProfileEntity>("data/profile.json");
                Experiences = await _httpClient.GetFromJsonAsync<ExperienceEntity[]>("data/experiences.json");
                Projects = await _httpClient.GetFromJsonAsync<ProjectEntity[]>("data/projects.json");
                Skills = await _httpClient.GetFromJsonAsync<SkillEntity[]>("data/skills.json");
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessageBox("Error", ex.ToString());
            }
        }
    }
}
