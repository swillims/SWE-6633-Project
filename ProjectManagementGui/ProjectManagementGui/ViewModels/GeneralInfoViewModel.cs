using System;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public class GeneralInfoViewModel : ViewModelBase
{
    private string _title;
    private string _projectOwner;
    private string _description;
    private string _riskText;
    private string _teamMemberText;

    private ProjectViewModel SelectProject;
    private Action? EditProjectRequested { get; set; }
    
    public bool IsEditing  { get; set; }
    
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public string Owner
    {
        get => _projectOwner;
        set => this.RaiseAndSetIfChanged(ref _projectOwner, value);
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
    
    public string TeamMemberText
    {
        get => _teamMemberText;
        set => this.RaiseAndSetIfChanged(ref _teamMemberText, value);
    }
    
    public string RiskText
    {
        get => _riskText;
        set => this.RaiseAndSetIfChanged(ref _riskText, value);
    }
    
    public ObservableCollection<string> TeamMembers { get;} =
        new ObservableCollection<string>();

    public ObservableCollection<RiskViewModel> Risks { get;} =
        new ObservableCollection<RiskViewModel>();

    public GeneralInfoViewModel(Action editProjectAction)
    {
        EditProjectRequested =  editProjectAction;
    }

    public void OnChangeProject(ProjectViewModel project)
    {
        SelectProject = project;
        
        Title = project.Title;
        Owner = project.Owner;
        Description = project.Description;
        TeamMembers.Clear();
        Risks.Clear();

        foreach (var teamMember in project.TeamMembers)
        {
            TeamMembers.Add(teamMember);
        }

        foreach (var risk in project.Risks)
        {
            Risks.Add(risk);
        }
    }

    public void AddTeamMember()
    {
        SelectProject?.AddTeamMember(TeamMemberText);
        
        TeamMembers.Add(TeamMemberText);
        TeamMemberText = string.Empty;
    }

    public void AddRisk()
    {
        SelectProject?.AddRisk(RiskText);
        
        Risks.Add(new RiskViewModel(RiskText));
        RiskText =  string.Empty;
    }

    public void RemoveTeamMember(object item)
    {
        SelectProject?.RemoveTeamMember(item);
        TeamMembers.Remove((string)item);
    }

    public void RemoveRisk(object item)
    {
        SelectProject?.RemoveRisk(item);
        Risks.Remove((RiskViewModel)item);
    }

    public void EditProjectDetails()
    {
        IsEditing =  true;
        EditProjectRequested?.Invoke();
    }
}

