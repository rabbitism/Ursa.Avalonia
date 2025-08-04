using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Layout;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.DividerTests;

public class Tests
{
    [AvaloniaFact]
    public void Divider_Should_Be_Created_Successfully()
    {
        var divider = new UrsaControl.Divider();
        
        Assert.NotNull(divider);
        Assert.Equal(Orientation.Horizontal, divider.Orientation);
        Assert.Equal(HorizontalAlignment.Center, divider.HorizontalContentAlignment);
    }
    
    [AvaloniaFact]
    public void Divider_Orientation_Property_Should_Work()
    {
        var divider = new UrsaControl.Divider();
        
        // Default should be Horizontal
        Assert.Equal(Orientation.Horizontal, divider.Orientation);
        
        // Set to Vertical
        divider.Orientation = Orientation.Vertical;
        Assert.Equal(Orientation.Vertical, divider.Orientation);
    }
    
    [AvaloniaFact]
    public void Divider_Content_Should_Work()
    {
        var window = new Window();
        var divider = new UrsaControl.Divider
        {
            Content = "Test Content"
        };
        
        window.Content = divider;
        window.Show();
        
        Assert.Equal("Test Content", divider.Content);
        Assert.Equal(HorizontalAlignment.Center, divider.HorizontalContentAlignment);
    }
    
    [AvaloniaFact]
    public void Divider_With_Complex_Content_Should_Work()
    {
        var window = new Window();
        var innerPanel = new StackPanel();
        var divider = new UrsaControl.Divider
        {
            Content = innerPanel
        };
        
        window.Content = divider;
        window.Show();
        
        Assert.Equal(innerPanel, divider.Content);
    }
}