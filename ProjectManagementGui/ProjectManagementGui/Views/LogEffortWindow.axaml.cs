using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ProjectManagementGui.Models;

namespace ProjectManagementGui.Views;

public partial class LogEffortWindow : Window
{
    private static readonly IReadOnlyList<string> EffortChoices =
    [
        "Requirements Analysis",
        "Designing",
        "Coding",
        "Testing",
        "Deployment",
        "Documentation",
        "Bug Fixing"
    ];

    public string RequirementName { get; }
    public IReadOnlyList<string> EffortOptions => EffortChoices;

    public LogEffortWindow() : this("Requirement")
    {
    }

    public LogEffortWindow(string requirementName)
    {
        RequirementName = requirementName;
        InitializeComponent();
        DataContext = this;
    }

    private void OnLogEffortClicked(object? sender, RoutedEventArgs e)
    {
        ErrorText.Text = string.Empty;
        var selectedEffort = EffortTypeComboBox.SelectedItem as string;
        var description = DescriptionBox.Text?.Trim();

        if (string.IsNullOrWhiteSpace(selectedEffort) ||
            string.IsNullOrWhiteSpace(description))
        {
            ErrorText.Text = "Select an effort type and add a short description.";
            return;
        }

        var entry = new LoggedEffortEntry(RequirementName, selectedEffort, description, DateTimeOffset.Now);
        Close(entry);
    }

    private void OnCancelClicked(object? sender, RoutedEventArgs e)
    {
        Close(null);
    }
}
