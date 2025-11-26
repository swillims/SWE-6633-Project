using System.Collections.ObjectModel;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public class GeneralInfoViewModel : ViewModelBase
{
    private string _title;
    private string _projectOwner;
    private string _description;

    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public string ProjectOwner
    {
        get => _projectOwner;
        set => this.RaiseAndSetIfChanged(ref _projectOwner, value);
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public ObservableCollection<string> TeamMembers { get; } =
        new ObservableCollection<string>();

    public ObservableCollection<RiskItemViewModel> Risks { get; } =
        new ObservableCollection<RiskItemViewModel>();
}

