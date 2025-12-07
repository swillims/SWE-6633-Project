using System;
using System.Runtime.InteropServices;
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
        GeneralInfoViewModel = new GeneralInfoViewModel();
        RequirementsEffortViewModel = new RequirementsEffortViewModel(CreateProject);
        DashboardViewModel = new DashboardViewModel();
        NewProjectPopupViewModel = new NewProjectPopupViewModel(CreateProject);
    }

    private void ShowNewProjectPopup()
    {
        NewProjectPopupViewModel.IsVisible = true;
    }

    private void CreateProject()
    {
        ProjectListViewModel.AddNewProject(
            NewProjectPopupViewModel.ProjectName, 
            NewProjectPopupViewModel.ProjectOwner);
    }

    private void OnProjectSelected()
    {
        if (ProjectListViewModel.SelectedProject != null)
        {
            Title = ProjectListViewModel.SelectedProject.Name;
            ProjectOwner = ProjectListViewModel.SelectedProject.Owner;
            ProjectItemModel.currentProject = ProjectListViewModel.SelectedProject;
            //System.Diagnostics.Debug.WriteLine(ProjectItemModel.currentProject.Name);
            Title = ProjectItemModel.currentProject.Name;
            ProjectOwner = ProjectItemModel.currentProject.Owner;
        }
    }
}