using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ProjectManagementGui.Models;
using ProjectManagementGui.ViewModels;

namespace ProjectManagementGui.Views;

public partial class RequirementsEffortControl : UserControl
{
    public RequirementsEffortControl()
    {
        InitializeComponent();
    }

    private async void LogEffort_Click(object? sender, RoutedEventArgs e)
    {
        if (this.VisualRoot is not Window parentWindow)
        {
            return;
        }

        var requirementName = (sender as Button)?.Tag as string ?? "Requirement";
        var dialog = new LogEffortWindow(requirementName);
        var result = await dialog.ShowDialog<LoggedEffortEntry?>(parentWindow);

        if (result is not null && DataContext is RequirementsEffortViewModel viewModel)
        {
            viewModel.RegisterLoggedEffort(result);
        }
    }
}
