namespace ProjectManagementGui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ProjectListViewModel ProjectListViewModel { get; set; }
    public GeneralInfoViewModel GeneralInfoViewModel { get; set; }

    public MainWindowViewModel()
    {
        ProjectListViewModel = new ProjectListViewModel();
        GeneralInfoViewModel = new GeneralInfoViewModel()
        {
            Title = "E-commerce Platform",
            ProjectOwner = "Alice Johnson",
            Description = "A next-generation online shopping platform...",

            TeamMembers =
            {
                "Bob Smith",
                "Charlie Brown",
                "Diana Prince"
            },

            Risks =
            {
                new RiskItemViewModel { Description = "Payment gateway integration delay", Status = "In Progress" },
                new RiskItemViewModel { Description = "Scalability issues during peak load", Status = "Open" }
            }
        };
        
        
    }
}