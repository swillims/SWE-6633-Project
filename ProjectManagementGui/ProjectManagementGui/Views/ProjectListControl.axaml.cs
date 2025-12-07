using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ProjectManagementGui.Models;
using ProjectManagementGui.ViewModels;

namespace ProjectManagementGui.Views;

public partial class ProjectListControl : UserControl
{
    public ProjectListControl()
    {
        InitializeComponent();
    }
    
    private void ListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DataContext is ProjectListViewModel viewModel && 
            e.AddedItems.Count > 0 && 
            e.AddedItems[0] is ProjectViewModel selectedProject)
        {
            viewModel.OnProjectSelected();
        }
    }
}