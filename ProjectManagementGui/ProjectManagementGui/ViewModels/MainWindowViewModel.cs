namespace ProjectManagementGui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ProjectListViewModel ProjectListViewModel { get; set; }

    public MainWindowViewModel()
    {
        ProjectListViewModel = new ProjectListViewModel();
    }
}