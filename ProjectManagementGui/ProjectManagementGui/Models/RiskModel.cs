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
    
    public int Id { get; private set; }
    private static int _count = 0;
    
    public RiskModel(string description)
    {
        Description = description;
        RiskStatus = Status.Open;
        Id = _count++;
    }
}