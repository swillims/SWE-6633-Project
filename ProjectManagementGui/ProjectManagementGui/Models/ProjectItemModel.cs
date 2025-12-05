using System.Dynamic;

namespace ProjectManagementGui.Models;

public class ProjectItemModel(string name, string owner)
{
    public static ProjectItemModel? currentProject;

    public string Name { get; set; } = name;
    public string Owner { get; set; } = owner;

    public bool IsSelected { get; set; }

    public void setCurrentProject(ProjectItemModel replace){ currentProject = replace;}
    
}