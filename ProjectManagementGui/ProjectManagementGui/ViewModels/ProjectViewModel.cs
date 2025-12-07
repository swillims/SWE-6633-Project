using System;
using System.Collections.ObjectModel;
using ProjectManagementGui.Models;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public class ProjectViewModel(string projectName,  string projectOwner, string description) : ViewModelBase
{
    private readonly ProjectModel _projectModel = new ProjectModel(projectName, projectOwner, description);
    public ObservableCollection<string> TeamMembers { get; } = [];
    public ObservableCollection<RiskViewModel> Risks { get; }= [];
    
    private string _title = projectName;
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    private string _owner = projectOwner;
    public string Owner
    {
        get => _owner;
        set => this.RaiseAndSetIfChanged(ref _owner, value);
    }
    
    private string _description = description;
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public void UpdateDetails(string projectName,  string projectOwner, string description)
    {
        Title = projectName;
        Owner = projectOwner;
        Description = description;
    }

    public void AddTeamMember(string teamMemberName)
    {
        TeamMembers.Add(teamMemberName);
    }

    public void AddRisk(string description)
    {
        Risks.Add(new RiskViewModel(description));
    }
    
    public void RemoveTeamMember(object item)
    {
        TeamMembers.Remove((string)item);
    }

    public void RemoveRisk(object item)
    {
        Risks.Remove((RiskViewModel)item);
    }
}