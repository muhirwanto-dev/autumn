using Blazing.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MudBlazor;
using Autumn.Wasm.Models;

namespace Autumn.Wasm.ViewModel
{
    public partial class HomeViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        [ObservableProperty]
        private ProjectModel[] _projects = [];

        public HomeViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}
