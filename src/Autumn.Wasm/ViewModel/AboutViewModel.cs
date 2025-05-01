using Blazing.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MudBlazor;
using Autumn.Wasm.Models;
using Autumn.Wasm.Common.Enums;
using Autumn.Wasm.Interfaces;

namespace Autumn.Wasm.ViewModel
{
    public partial class AboutViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly IDataSourceService _dataSourceService;
        private readonly IScreenService _screenService;

        [ObservableProperty]
        private ProfileModel _profile = new() { Name = "Unknown" };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TopThreeSkills))]
        private SkillModel[] _skills = [];

        [ObservableProperty]
        private ProjectModel[] _projects = [];

        [ObservableProperty]
        private ExperienceModel[] _experiences = [];

        [ObservableProperty]
        private bool _isSmallDevice = false;

        public SkillModel[] TopThreeSkills => Skills.Length > 3
            ? Skills.Take(3).ToArray() : Skills;

        public Dictionary<string, string> ProjectIdMap = new();

        public string SendEmailHrefQuery => Profile.Email == null ? "#"
            : $"mailto:{Profile.Email}?subject=Profile%20Visitor%20Say%20Hi!";

        public AboutViewModel(IDialogService dialogService, IDataSourceService dataSourceService, IScreenService screenService)
        {
            _dialogService = dialogService;
            _dataSourceService = dataSourceService;
            _screenService = screenService;

            _screenService.Subscribe(() => IsSmallDevice = _screenService.IsSmallDown);
        }

        public override async Task Loaded()
        {
            try
            {
                var task0 = _dataSourceService.DownloadDataSourceAsync<ProfileModel>($"{DataSourceTypeNames.Profile}.json");
                var task1 = _dataSourceService.DownloadDataSourceAsync<ExperienceModel[]>($"{DataSourceTypeNames.Experiences}.json");
                var task2 = _dataSourceService.DownloadDataSourceAsync<SkillModel[]>($"{DataSourceTypeNames.Skills}.json");
                var task3 = _dataSourceService.DownloadDataSourceAsync<ProjectModel[]>($"{DataSourceTypeNames.Projects}.json");

                await Task.WhenAll(task0, task1, task2, task3);

                Profile = task0.Result ?? new ProfileModel { Name = "Unknown" };
                Experiences = task1.Result ?? [];
                Skills = task2.Result ?? [];
                Projects = task3.Result ?? [];

                ProjectIdMap.Clear();
                ProjectIdMap = Projects.Select(e => new KeyValuePair<string, string>(e.ProjectId, e.Title)).ToDictionary();
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessageBox("Error", ex.Message);
            }
        }
    }
}
