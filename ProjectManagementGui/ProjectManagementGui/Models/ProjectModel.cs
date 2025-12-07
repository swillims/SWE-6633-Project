namespace ProjectManagementGui.Models;

public class ProjectModel(string name, string owner, string description)
{
    public string Name { get; set; } = name;
    public string Owner { get; set; } = owner;
    public string Description { get; set; } = description;
}