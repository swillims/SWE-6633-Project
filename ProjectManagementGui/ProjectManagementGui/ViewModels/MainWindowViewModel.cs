using System;
using ProjectManagementGui.Models;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ProjectListViewModel ProjectListViewModel { get; set; }
    public GeneralInfoViewModel GeneralInfoViewModel { get; set; }
    public RequirementsEffortViewModel RequirementsEffortViewModel { get; set; }
    public DashboardViewModel DashboardViewModel { get; set; }
    
    public NewProjectPopupViewModel NewProjectPopupViewModel { get; set; }
    
    private string _title;
    private string _projectOwner;

    private const string DefaultTitle = "Project Templat";
    private const string DefaultOwner = "None";
    
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

    public MainWindowViewModel()
    {
        Title = DefaultTitle;
        ProjectOwner = DefaultOwner;
        
        ProjectListViewModel = new ProjectListViewModel(ShowNewProjectPopup,OnProjectSelected);
        GeneralInfoViewModel = new GeneralInfoViewModel(ShowNewProjectPopup);
        RequirementsEffortViewModel = new RequirementsEffortViewModel();
        DashboardViewModel = new DashboardViewModel();
        NewProjectPopupViewModel = new NewProjectPopupViewModel(CreateProject);
    }

    private void ShowNewProjectPopup()
    {
        NewProjectPopupViewModel.IsVisible = true;
    }

    private void CreateProject()
    {
        if (GeneralInfoViewModel.IsEditing)
        {
            ProjectListViewModel.SelectedProject?.UpdateDetails(
                NewProjectPopupViewModel.ProjectName, 
                NewProjectPopupViewModel.ProjectOwner,
                NewProjectPopupViewModel.ProjectDescription);
            OnProjectSelected();
            GeneralInfoViewModel.IsEditing =  false;
        }
        else
        {
            ProjectListViewModel.AddNewProject(
                NewProjectPopupViewModel.ProjectName, 
                NewProjectPopupViewModel.ProjectOwner,
                NewProjectPopupViewModel.ProjectDescription);
        }
    }

    private void OnProjectSelected()
    {
        if (ProjectListViewModel.SelectedProject != null)
        {
            Title = ProjectListViewModel.SelectedProject.Title;
            ProjectOwner = ProjectListViewModel.SelectedProject.Owner;
            GeneralInfoViewModel.OnChangeProject(ProjectListViewModel.SelectedProject);
        }
    }
}