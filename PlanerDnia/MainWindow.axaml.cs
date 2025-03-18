using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;

namespace PlanerDnia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    
    
    private void CreateTask(object sender, RoutedEventArgs e)
    {
        Task newTask = new(TextBox_TaskName.Text, ComboBox_Category?.SelectedItem.ToString(), false, ComboBox_Category.SelectedIndex);

        if (newTask.Name == null)
        {
            newTask.Name = "Zadanie bez nazwy";
        }
        
        var taskName = new TextBlock { Text = newTask.Name };
        var taskCategory = new ComboBox { };
        taskCategory.Items.Add(new TextBlock { Text = "Ważne" });
        taskCategory.Items.Add(new TextBlock { Text = "Priorytetowe" });
        taskCategory.Items.Add(new TextBlock { Text = "Poboczne" });
        taskCategory.SelectedIndex = newTask.CategoryIndex;
        var taskFinished = new CheckBox { IsChecked = newTask.IsFinished, Content = "Zakończono" };
        var taskDelete = new Button { Content = "Usuń" };

        var taskElement = new StackPanel { Width = 200, Height = 150 };
        taskElement.Children.Add(taskName);
        taskElement.Children.Add(taskCategory);
        taskElement.Children.Add(taskFinished);
        taskElement.Children.Add(taskDelete);
        
        Panel_TaskGrid.Children.Add(taskElement);

    }
}