using System.Collections.Generic;
using ProjectManagementGui.Models;

namespace ProjectManagementGui.ViewModels;

public class ProjectListViewModel : ViewModelBase
{
    public List<ProjectItemModel> Projects {get; set; } = new();
    public ProjectItemModel SelectedProject { get; set; }


    public void NewProjectCommand()
    {
        // logic to create and add new projects to a list
    }
}