using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.Threading;
using Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.SelectionListTests;

public class SelectionListItemTests
{
    [AvaloniaFact]
    public void SelectionListItem_Should_Initialize_With_Default_Values()
    {
        var item = new SelectionListItem();
        
        Assert.False(item.IsSelected);
        Assert.True(item.Focusable);
    }

    [AvaloniaFact]
    public void SelectionListItem_Should_Handle_IsSelected_Property()
    {
        var item = new SelectionListItem();
        
        item.IsSelected = true;
        Assert.True(item.IsSelected);
        
        item.IsSelected = false;
        Assert.False(item.IsSelected);
    }

    [AvaloniaFact]
    public void SelectionListItem_Should_Handle_Content()
    {
        var item = new SelectionListItem();
        var content = "Test Content";
        
        item.Content = content;
        
        Assert.Equal(content, item.Content);
    }

    [AvaloniaFact]
    public void SelectionListItem_Should_Trigger_Selection_On_Pointer_Press()
    {
        var window = new Window();
        var items = new List<string> { "Item 1", "Item 2", "Item 3" };
        var list = new SelectionList
        {
            ItemsSource = items,
            Width = 200,
            Height = 150
        };
        window.Content = list;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        // Get the first container
        var container = list.ContainerFromIndex(1) as SelectionListItem;
        Assert.NotNull(container);
        
        // Simulate pointer press on the container
        var position = container.TranslatePoint(new Point(10, 10), window);
        Assert.NotNull(position);
        
        window.MouseDown(position.Value, MouseButton.Left);
        window.MouseUp(position.Value, MouseButton.Left);
        Dispatcher.UIThread.RunJobs();
        
        // Check that the item is selected
        Assert.Equal(1, list.SelectedIndex);
        Assert.Equal("Item 2", list.SelectedItem);
        Assert.True(container.IsSelected);
    }

    [AvaloniaFact]
    public void SelectionListItem_Should_Update_Selection_State()
    {
        var window = new Window();
        var items = new List<string> { "Item 1", "Item 2", "Item 3" };
        var list = new SelectionList
        {
            ItemsSource = items
        };
        window.Content = list;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var container1 = list.ContainerFromIndex(0) as SelectionListItem;
        var container2 = list.ContainerFromIndex(1) as SelectionListItem;
        Assert.NotNull(container1);
        Assert.NotNull(container2);
        
        // Initially no items should be selected
        Assert.False(container1.IsSelected);
        Assert.False(container2.IsSelected);
        
        // Select first item
        list.SelectByIndex(0);
        Dispatcher.UIThread.RunJobs();
        
        Assert.True(container1.IsSelected);
        Assert.False(container2.IsSelected);
        
        // Select second item
        list.SelectByIndex(1);
        Dispatcher.UIThread.RunJobs();
        
        Assert.False(container1.IsSelected);
        Assert.True(container2.IsSelected);
    }

    [AvaloniaFact]
    public void SelectionListItem_Should_Be_Focusable()
    {
        var item = new SelectionListItem();
        
        Assert.True(item.Focusable);
    }

    [AvaloniaFact]
    public void SelectionListItem_Should_Handle_Focus()
    {
        var window = new Window();
        var items = new List<string> { "Item 1", "Item 2" };
        var list = new SelectionList
        {
            ItemsSource = items
        };
        window.Content = list;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var container = list.ContainerFromIndex(0) as SelectionListItem;
        Assert.NotNull(container);
        
        // Focus the container
        container.Focus();
        Dispatcher.UIThread.RunJobs();
        
        Assert.True(container.IsFocused);
    }

    [AvaloniaFact]
    public void SelectionListItem_Should_Work_Outside_SelectionList()
    {
        var window = new Window();
        var item = new SelectionListItem
        {
            Content = "Standalone Item"
        };
        window.Content = item;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        // Item should not crash when used outside of SelectionList
        Assert.Equal("Standalone Item", item.Content);
        Assert.False(item.IsSelected);
        
        // Pointer press should not crash
        window.MouseDown(new Point(10, 10), MouseButton.Left);
        window.MouseUp(new Point(10, 10), MouseButton.Left);
        Dispatcher.UIThread.RunJobs();
        
        // Item should still not be selected (no parent SelectionList to handle selection)
        Assert.False(item.IsSelected);
    }

    [AvaloniaFact]
    public void SelectionListItem_Should_Handle_Multiple_Pointer_Presses()
    {
        var window = new Window();
        var items = new List<string> { "Item 1", "Item 2", "Item 3" };
        var list = new SelectionList
        {
            ItemsSource = items
        };
        window.Content = list;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var container = list.ContainerFromIndex(1) as SelectionListItem;
        Assert.NotNull(container);
        
        var position = container.TranslatePoint(new Point(10, 10), window);
        Assert.NotNull(position);
        
        // First click should select
        window.MouseDown(position.Value, MouseButton.Left);
        window.MouseUp(position.Value, MouseButton.Left);
        Dispatcher.UIThread.RunJobs();
        
        Assert.Equal(1, list.SelectedIndex);
        Assert.True(container.IsSelected);
        
        // Second click on same item should keep it selected
        window.MouseDown(position.Value, MouseButton.Left);
        window.MouseUp(position.Value, MouseButton.Left);
        Dispatcher.UIThread.RunJobs();
        
        Assert.Equal(1, list.SelectedIndex);
        Assert.True(container.IsSelected);
    }
}