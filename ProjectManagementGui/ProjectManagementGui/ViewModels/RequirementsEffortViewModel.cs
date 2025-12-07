using System.Collections.ObjectModel;
using ProjectManagementGui.Models;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public class RequirementsEffortViewModel : ViewModelBase
{
    private string _lastEffortSummary = "No effort logged yet.";

    public ObservableCollection<LoggedEffortEntry> LoggedEfforts { get; } = new();

    public string LastEffortSummary
    {
        get => _lastEffortSummary;
        private set => this.RaiseAndSetIfChanged(ref _lastEffortSummary, value);
    }

    public void RegisterLoggedEffort(LoggedEffortEntry entry)
    {
        LoggedEfforts.Insert(0, entry);
        LastEffortSummary =
            $"Logged {entry.EffortType} for {entry.RequirementName} ({entry.Timestamp:MMM d h:mm tt})";
    }
}
