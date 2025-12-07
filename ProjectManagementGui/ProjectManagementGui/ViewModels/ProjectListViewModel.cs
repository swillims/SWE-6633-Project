using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjectManagementGui.Models;

namespace ProjectManagementGui.ViewModels;

public class ProjectListViewModel(Action createProjectAction, Action onProjectSelected) : ViewModelBase
{
    public ObservableCollection<ProjectViewModel> Projects {get; set; } = [];
    public ProjectViewModel? SelectedProject { get; set; }
    
    private Action? CreateNewProjectRequested { get; set; } = createProjectAction;
    
    private Action? ProjectSelected { get; set; } = onProjectSelected;

    public void NewProjectCommand()
    {
        CreateNewProjectRequested?.Invoke();
    }

    public void AddNewProject(string projectName,  string projectOwner, string description)
    {
        Projects.Add(new ProjectViewModel(projectName, projectOwner, description));
    }

    public void OnProjectSelected()
    {
        ProjectSelected?.Invoke();
    }
}