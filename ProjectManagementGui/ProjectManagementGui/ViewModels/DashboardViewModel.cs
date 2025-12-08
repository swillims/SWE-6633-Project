using System;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public class DashboardViewModel : ViewModelBase
{
    private ProjectViewModel SelectedProject;
    
    private int _totalHours;

    public int TotalHours
    {
        get => _totalHours;
        set => this.RaiseAndSetIfChanged(ref _totalHours, value);
    }

    public ObservableCollection<CategoryHoursViewModel> CategoryHours { get; } =
        new ObservableCollection<CategoryHoursViewModel>();

    public DashboardViewModel()
    {
        var categories = new[]
        {
            ("Requirements Analysis", 18),
            ("Designing", 16),
            ("Coding", 75),
            ("Testing", 26),
            ("Project Management", 5) // Changed from 0 to 5 so it's visible
        };

        // Calculate spacing to spread bars across ~600px width
        double chartWidth = 650;
        double barWidth = 80;
        double totalBarsWidth = categories.Length * barWidth;
        double totalSpacing = chartWidth - totalBarsWidth;
        double spacing = totalSpacing / (categories.Length + 1);

        for (int i = 0; i < categories.Length; i++)
        {
            double xPosition = spacing + (i * (barWidth + spacing));
        
            var item = new CategoryHoursViewModel(
                categories[i].Item1,
                categories[i].Item2,
                xPosition
            );
        
            CategoryHours.Add(item);
        
            // Debug output
            Console.WriteLine($"Added: {item.Category}, Hours: {item.Hours}, X: {item.XPosition}, Height: {item.BarHeight}");
        }

        TotalHours = 135;
    }

    public void OnUpdateTotalHours()
    {
        if(SelectedProject == null)
            return;
        Console.WriteLine("OnUpdateTotalHours");
        
        int totalHours = 0;
        
        foreach (RequirementViewModel requirementViewModel in SelectedProject.FunctionalRequirements)
        {
            totalHours += requirementViewModel.TotalHours;
        }
        
        foreach (RequirementViewModel requirementViewModel in SelectedProject.NonFunctionalRequirements)
        {
            totalHours += requirementViewModel.TotalHours;
        }
        
        TotalHours = totalHours;
    }

    public void OnChangeProject(ProjectViewModel project)
    {
        SelectedProject =  project;

        OnUpdateTotalHours();
    }
}

public class CategoryHoursViewModel : ViewModelBase
{
    public string Category { get; }
    public int Hours { get; }
    public double XPosition { get; }
    public double YPosition { get; }
    public double BarHeight { get; }

    public CategoryHoursViewModel(string category, int hours, double xPosition)
    {
        Category = category;
        Hours = hours;
        XPosition = xPosition;
        
        // Scale: 80 on chart = 240 pixels, so 1 hour = 3 pixels
        BarHeight = hours * 3.0;
        
        // Position from top (240 is the baseline)
        YPosition = 240 - BarHeight;
    }
}