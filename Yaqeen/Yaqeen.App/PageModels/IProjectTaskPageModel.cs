using CommunityToolkit.Mvvm.Input;
using Yaqeen.App.Models;

namespace Yaqeen.App.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}