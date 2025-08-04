using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Media;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.DualBadgeTests;

public class Tests
{
    [AvaloniaFact]
    public void DualBadge_Should_Be_Created_Successfully()
    {
        var dualBadge = new UrsaControl.DualBadge();
        
        Assert.NotNull(dualBadge);
        Assert.Null(dualBadge.Icon);
        Assert.Null(dualBadge.Header);
        Assert.Null(dualBadge.Content);
    }
    
    [AvaloniaFact]
    public void DualBadge_Icon_Property_Should_Work()
    {
        var dualBadge = new UrsaControl.DualBadge();
        
        // Initially null
        Assert.Null(dualBadge.Icon);
        
        // Set string icon
        dualBadge.Icon = "TestIcon";
        Assert.Equal("TestIcon", dualBadge.Icon);
        
        // Set control icon
        var button = new Button { Content = "Button Icon" };
        dualBadge.Icon = button;
        Assert.Equal(button, dualBadge.Icon);
    }
    
    [AvaloniaFact]
    public void DualBadge_Header_And_Content_Should_Work()
    {
        var dualBadge = new UrsaControl.DualBadge
        {
            Header = "Test Header",
            Content = "Test Content"
        };
        
        Assert.Equal("Test Header", dualBadge.Header);
        Assert.Equal("Test Content", dualBadge.Content);
    }
    
    [AvaloniaFact]
    public void DualBadge_Foreground_Properties_Should_Work()
    {
        var dualBadge = new UrsaControl.DualBadge();
        var redBrush = Brushes.Red;
        var blueBrush = Brushes.Blue;
        
        // Set IconForeground
        dualBadge.IconForeground = redBrush;
        Assert.Equal(redBrush, dualBadge.IconForeground);
        
        // Set HeaderForeground
        dualBadge.HeaderForeground = blueBrush;
        Assert.Equal(blueBrush, dualBadge.HeaderForeground);
    }
    
    [AvaloniaFact]
    public void DualBadge_In_Window_Should_Render()
    {
        var window = new Window();
        var dualBadge = new UrsaControl.DualBadge
        {
            Icon = "🎯",
            Header = "Badge Header",
            Content = "Badge Content",
            Width = 200,
            Height = 100
        };
        
        window.Content = dualBadge;
        window.Show();
        
        Assert.Equal("🎯", dualBadge.Icon);
        Assert.Equal("Badge Header", dualBadge.Header);
        Assert.Equal("Badge Content", dualBadge.Content);
    }
}