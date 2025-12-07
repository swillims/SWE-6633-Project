using ProjectManagementGui.Models;
using ReactiveUI;
using System;
using System.Windows.Input;

namespace ProjectManagementGui.ViewModels;

public class RequirementsEffortViewModel(Action addRequirementAction) : ViewModelBase
{

    private Action? AddRequirementsRequested { get; set; } = addRequirementAction;
    //private Action? RequirementsEffortViewModel { get; set; } = addRequirementAction;
    public NewRequirementViewModel NewRequirementViewModel { get; }

    public void NewRequirement()
    {
        System.Diagnostics.Debug.WriteLine("BEEP");
        AddRequirementsRequested?.Invoke();
    }

}