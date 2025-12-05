namespace ProjectManagementGui.Models;

public class ProjectItemModel(string name, string owner)
{
    public string Name { get; set; } = name;
    public string Owner { get; set; } = owner;
    public bool IsSelected { get; set; }
}