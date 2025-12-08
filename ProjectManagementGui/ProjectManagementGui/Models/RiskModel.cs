namespace ProjectManagementGui.Models;

public class RiskModel
{
    public enum Status
    {
        Open = 0,
        InProgress = 1,
        Closed = 2
    }
    public string Description { get; private set; }
    public Status RiskStatus { get; set; }
    
    public RiskModel(string description)
    {
        Description = description;
        RiskStatus = Status.Open;
    }
}