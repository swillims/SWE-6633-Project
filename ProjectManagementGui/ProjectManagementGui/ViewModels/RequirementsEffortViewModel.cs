using System;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public class RequirementsEffortViewModel : ViewModelBase
{
    private ProjectViewModel SelectProject;
    public ObservableCollection<RequirementViewModel> FunctionalRequirements { get; set; } = [];
    public ObservableCollection<RequirementViewModel> NonFunctionalRequirements { get; set; } = [];
    
    private string _title;
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private int _selectedIndex;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedIndex, value);
    }

    private Action? _onTotalHoursChanged;
    public RequirementsEffortViewModel(Action? onTotalHoursChanged = null)
    {
        _onTotalHoursChanged =  onTotalHoursChanged;
    }

    public void AddRequirement()
    {
        if (SelectedIndex == 0)
        {
            FunctionalRequirements.Add(new RequirementViewModel(Title,_onTotalHoursChanged));
        }
        else if (SelectedIndex == 1)
        {
            NonFunctionalRequirements.Add(new RequirementViewModel(Title,_onTotalHoursChanged));
        }
        
        SelectProject?.FunctionalRequirements.Clear();
        SelectProject?.NonFunctionalRequirements.Clear();
        
        foreach (RequirementViewModel requirementViewModel in FunctionalRequirements)
        {
            SelectProject?.FunctionalRequirements.Add(requirementViewModel);
        }
        
        foreach (RequirementViewModel requirementViewModel in NonFunctionalRequirements)
        {
            SelectProject?.NonFunctionalRequirements.Add(requirementViewModel);
        }
        
        Title = string.Empty;
    }

    public void OnChangeProject(ProjectViewModel project)
    {
        SelectProject?.FunctionalRequirements.Clear();
        SelectProject?.NonFunctionalRequirements.Clear();
        
        foreach (RequirementViewModel requirementViewModel in FunctionalRequirements)
        {
            SelectProject?.FunctionalRequirements.Add(requirementViewModel);
        }
        
        foreach (RequirementViewModel requirementViewModel in NonFunctionalRequirements)
        {
            SelectProject?.NonFunctionalRequirements.Add(requirementViewModel);
        }
        
        SelectProject =  project;
        
        FunctionalRequirements.Clear();
        NonFunctionalRequirements.Clear();

        foreach (RequirementViewModel requirementViewModel in project.FunctionalRequirements)
        {
            FunctionalRequirements.Add(requirementViewModel);
        }
        
        foreach (RequirementViewModel requirementViewModel in project.NonFunctionalRequirements)
        {
            NonFunctionalRequirements.Add(requirementViewModel);
        }
    }
}