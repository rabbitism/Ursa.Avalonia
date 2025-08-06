using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Layout;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.DividerTests;

public class DividerTests
{
    [AvaloniaFact]
    public void Divider_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var divider = new UrsaControls.Divider();
        
        // Assert
        Assert.Equal(Orientation.Horizontal, divider.Orientation);
        Assert.Equal(HorizontalAlignment.Center, divider.HorizontalContentAlignment);
    }

    [AvaloniaFact]
    public void Divider_Should_Set_Orientation_Property()
    {
        // Arrange
        var window = new Window();
        var divider = new UrsaControls.Divider();
        window.Content = divider;
        window.Show();

        // Act & Assert
        divider.Orientation = Orientation.Vertical;
        Assert.Equal(Orientation.Vertical, divider.Orientation);

        divider.Orientation = Orientation.Horizontal;
        Assert.Equal(Orientation.Horizontal, divider.Orientation);
    }

    [AvaloniaFact]
    public void Divider_Should_Support_Content()
    {
        // Arrange
        var window = new Window();
        var divider = new UrsaControls.Divider
        {
            Content = "Test Content"
        };
        window.Content = divider;
        window.Show();

        // Assert
        Assert.Equal("Test Content", divider.Content);
    }

    [AvaloniaFact]
    public void Divider_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var divider = new UrsaControls.Divider();
        
        // Act
        window.Content = divider;
        window.Show();

        // Assert
        Assert.True(divider.IsVisible);
    }

    [AvaloniaFact]
    public void Divider_Should_Inherit_From_ContentControl()
    {
        // Arrange & Act
        var divider = new UrsaControls.Divider();

        // Assert
        Assert.IsAssignableFrom<ContentControl>(divider);
    }
}