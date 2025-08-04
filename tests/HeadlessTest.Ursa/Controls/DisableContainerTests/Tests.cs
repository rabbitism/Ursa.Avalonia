using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.DisableContainerTests;

public class Tests
{
    [AvaloniaFact]
    public void DisableContainer_Should_Be_Created_Successfully()
    {
        var disableContainer = new UrsaControl.DisableContainer();
        
        Assert.NotNull(disableContainer);
        Assert.Null(disableContainer.Content);
        Assert.Null(disableContainer.DisabledTip);
    }
    
    [AvaloniaFact]
    public void DisableContainer_Content_Property_Should_Work()
    {
        var disableContainer = new UrsaControl.DisableContainer();
        var button = new Button { Content = "Test Button" };
        
        // Initially null
        Assert.Null(disableContainer.Content);
        
        // Set content
        disableContainer.Content = button;
        Assert.Equal(button, disableContainer.Content);
    }
    
    [AvaloniaFact]
    public void DisableContainer_DisabledTip_Property_Should_Work()
    {
        var disableContainer = new UrsaControl.DisableContainer();
        
        // Initially null
        Assert.Null(disableContainer.DisabledTip);
        
        // Set string tip
        disableContainer.DisabledTip = "This control is disabled";
        Assert.Equal("This control is disabled", disableContainer.DisabledTip);
        
        // Set object tip
        var tipContent = new TextBlock { Text = "Custom tip" };
        disableContainer.DisabledTip = tipContent;
        Assert.Equal(tipContent, disableContainer.DisabledTip);
    }
    
    [AvaloniaFact]
    public void DisableContainer_In_Window_Should_Render()
    {
        var window = new Window();
        var button = new Button { Content = "Disabled Button" };
        var disableContainer = new UrsaControl.DisableContainer
        {
            Content = button,
            DisabledTip = "This button is disabled",
            Width = 150,
            Height = 50
        };
        
        window.Content = disableContainer;
        window.Show();
        
        Assert.Equal(button, disableContainer.Content);
        Assert.Equal("This button is disabled", disableContainer.DisabledTip);
    }
    
    [AvaloniaFact]
    public void DisableContainer_With_Complex_Content_Should_Work()
    {
        var window = new Window();
        var panel = new StackPanel();
        panel.Children.Add(new Button { Content = "Button 1" });
        panel.Children.Add(new Button { Content = "Button 2" });
        
        var disableContainer = new UrsaControl.DisableContainer
        {
            Content = panel,
            DisabledTip = "All buttons are disabled"
        };
        
        window.Content = disableContainer;
        window.Show();
        
        Assert.Equal(panel, disableContainer.Content);
        Assert.Equal("All buttons are disabled", disableContainer.DisabledTip);
    }
}