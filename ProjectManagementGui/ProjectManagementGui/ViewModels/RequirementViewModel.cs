using System;
using System.Collections.ObjectModel;
using ProjectManagementGui.Models;
using ReactiveUI;
using Tmds.DBus.Protocol;

namespace ProjectManagementGui.ViewModels;

public class RequirementViewModel : ViewModelBase
{
    private RequirementModel _requirement;
    private Action? _onTotalHoursChanged;
    
    private string _title;
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private int _totalHours;
    public int TotalHours
    {
        get => _totalHours;
        set => this.RaiseAndSetIfChanged(ref _totalHours, value);
    }
    
    // Logging
    private int _effort;
    public int Effort
    {
        get => _effort;
        set => this.RaiseAndSetIfChanged(ref _effort, value);
    }
    
    private decimal? _hours = 0;
    public decimal? Hours
    {
        get => _hours;
        set => this.RaiseAndSetIfChanged(ref _hours, value ?? 0);
    }

    private bool _logControlIsEnabled;
    public bool LogControlIsEnabled
    {
        get => _logControlIsEnabled;
        set =>this.RaiseAndSetIfChanged(ref _logControlIsEnabled, value);
    }

    public RequirementViewModel(string title, Action? onTotalHoursChanged = null)
    {
        _requirement = new RequirementModel(title);
        Title = title;
        _onTotalHoursChanged = onTotalHoursChanged;
    }

    public struct EffortModel
    {
        public string Type { get; set; }
        public int Hours { get; set; }
    }

    public ObservableCollection<EffortModel> EffortTypes { get; }= [];
    
    public void LogEffort()
    {
        LogControlIsEnabled = true;
        Console.WriteLine(LogControlIsEnabled);
    }

    public void Confirm()
    {
        if(Hours == null)
            Hours = 0;
        
        _requirement.LogEffort((RequirementModel.EffortType)Effort,(int)Hours);
        UpdateTotalHours();
        
        EffortTypes.Clear();

        foreach (var effort in _requirement.Efforts)
        {
            EffortTypes.Add(new EffortModel
            {
                Type = effort.Key.ToString(),
                Hours = effort.Value
            });
        }
        
        Hours = 0;
        LogControlIsEnabled = false;
    }

    private void UpdateTotalHours()
    {
        TotalHours = _requirement.TotalHours;
        _onTotalHoursChanged?.Invoke();
    }

    public void Cancel()
    {
        LogControlIsEnabled = false;
    }
}