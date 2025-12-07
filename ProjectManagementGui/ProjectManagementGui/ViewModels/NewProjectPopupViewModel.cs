using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public class NewProjectPopupViewModel(Action action) : ViewModelBase
{
    private string _projectName = string.Empty;
    private string _projectOwner = string.Empty;
    private string _projectDescription = string.Empty;
    private bool _isVisible;

    private Action? CreateProject { get; set; } = action;

    public bool IsVisible
    {
        get => _isVisible;
        set => this.RaiseAndSetIfChanged(ref _isVisible, value);
    }

    public string ProjectName
    {
        get => _projectName;
        set
        {
            if (_projectName != value)
            {
                this.RaiseAndSetIfChanged(ref _projectName, value);
            }
        }
    }

    public string ProjectOwner
    {
        get => _projectOwner;
        set
        {
            if (_projectOwner != value)
            {
                this.RaiseAndSetIfChanged(ref _projectOwner, value);
            }
        }
    }
    
    public string ProjectDescription
    {
        get => _projectDescription;
        set
        {
            if (_projectOwner != value)
            {
                this.RaiseAndSetIfChanged(ref _projectDescription, value);
            }
        }
    }

    private bool IsValid => !string.IsNullOrWhiteSpace(ProjectName) && 
                           !string.IsNullOrWhiteSpace(ProjectOwner);
    public bool DialogResult { get; private set; }

    public void Create()
    {
        if (IsValid)
        {
            DialogResult = true;
            CreateProject?.Invoke();
            
            ProjectName =  string.Empty;
            ProjectOwner = string.Empty;
            IsVisible = false;
        }
    }

    public void Cancel()
    {
        DialogResult = false;
        IsVisible = false;
    }
}