using System.Collections.Generic;

namespace ProjectManagementGui.Models;

public class RequirementModel(string title)
{
    public enum EffortType
    {
        RequirementAnalysis = 0,
        Designing = 1,
        Coding = 2,
        Testing = 3,
        ProjectManagement = 4
    }
    
    public string Title { get; private set; } = title;

    public int TotalHours { get; private set; }

    public Dictionary<EffortType,int> Efforts { get; } = [];

    public void LogEffort(EffortType effortType, int hours)
    {
        if (Efforts.ContainsKey(effortType))
        {
            Efforts[effortType] += hours;
        }
        else
        {
            Efforts[effortType] = hours;
        }

        TotalHours = 0;

        foreach (int hour in Efforts.Values)
        {
            TotalHours += hour;
        }
    }
}