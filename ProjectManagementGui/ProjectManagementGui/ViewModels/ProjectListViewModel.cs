using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjectManagementGui.Models;

namespace ProjectManagementGui.ViewModels;

public class ProjectListViewModel(Action createProjectAction, Action onProjectSelected) : ViewModelBase
{
    public ObservableCollection<ProjectItemModel> Projects {get; set; } = new();
    public ProjectItemModel? SelectedProject { get; set; }
    
    private Action? CreateNewProjectRequested { get; set; } = createProjectAction;
    
    private Action? ProjectSelected { get; set; } = onProjectSelected;

    public void NewProjectCommand()
    {
        CreateNewProjectRequested?.Invoke();
    }

    public void AddNewProject(string projectName,  string projectOwner)
    {
        Projects.Add(new ProjectItemModel(projectName, projectOwner));
    }

    public void OnProjectSelected()
    {
        ProjectSelected?.Invoke();
    }
}