using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Layout;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.MarqueeTests;

public class MarqueeTests
{
    [AvaloniaFact]
    public void Marquee_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var marquee = new UrsaControls.Marquee();
        
        // Assert
        Assert.True(marquee.IsRunning);
        Assert.Equal(UrsaControls.Direction.Left, marquee.Direction);
        Assert.Equal(60.0, marquee.Speed);
        Assert.True(marquee.ClipToBounds);
        Assert.Equal(HorizontalAlignment.Center, marquee.HorizontalContentAlignment);
        Assert.Equal(VerticalAlignment.Center, marquee.VerticalContentAlignment);
    }

    [AvaloniaFact]
    public void Marquee_Should_Set_IsRunning_Property()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Act & Assert
        marquee.IsRunning = false;
        Assert.False(marquee.IsRunning);

        marquee.IsRunning = true;
        Assert.True(marquee.IsRunning);
    }

    [AvaloniaFact]
    public void Marquee_Should_Set_Direction_Property()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Test all direction values
        var directions = new[]
        {
            UrsaControls.Direction.Up,
            UrsaControls.Direction.Down,
            UrsaControls.Direction.Left,
            UrsaControls.Direction.Right
        };

        foreach (var direction in directions)
        {
            // Act
            marquee.Direction = direction;

            // Assert
            Assert.Equal(direction, marquee.Direction);
        }
    }

    [AvaloniaFact]
    public void Marquee_Should_Set_Speed_Property()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Act & Assert
        marquee.Speed = 120.0;
        Assert.Equal(120.0, marquee.Speed);

        marquee.Speed = 0.0;
        Assert.Equal(0.0, marquee.Speed);

        marquee.Speed = 1.5;
        Assert.Equal(1.5, marquee.Speed);
    }

    [AvaloniaFact]
    public void Marquee_Should_Coerce_Negative_Speed_To_Zero()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Act
        marquee.Speed = -50.0;

        // Assert
        Assert.Equal(0.0, marquee.Speed);
    }

    [AvaloniaFact]
    public void Marquee_Should_Support_Content()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Act
        var content = "Scrolling text content";
        marquee.Content = content;

        // Assert
        Assert.Equal(content, marquee.Content);
    }

    [AvaloniaFact]
    public void Marquee_Should_Support_Complex_Content()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Act
        var stackPanel = new StackPanel();
        stackPanel.Children.Add(new TextBlock { Text = "Item 1" });
        stackPanel.Children.Add(new TextBlock { Text = "Item 2" });
        marquee.Content = stackPanel;

        // Assert
        Assert.Equal(stackPanel, marquee.Content);
        Assert.IsType<StackPanel>(marquee.Content);
    }

    [AvaloniaFact]
    public void Marquee_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        
        // Act
        window.Content = marquee;
        window.Show();

        // Assert
        Assert.True(marquee.IsVisible);
    }

    [AvaloniaFact]
    public void Marquee_Should_Inherit_From_ContentControl()
    {
        // Arrange & Act
        var marquee = new UrsaControls.Marquee();

        // Assert
        Assert.IsAssignableFrom<ContentControl>(marquee);
    }

    [AvaloniaFact]
    public void Marquee_Should_Handle_Large_Speed_Values()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Act
        marquee.Speed = 1000.0;

        // Assert
        Assert.Equal(1000.0, marquee.Speed);
    }

    [AvaloniaFact]
    public void Marquee_Should_Handle_Small_Speed_Values()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Act
        marquee.Speed = 0.1;

        // Assert
        Assert.Equal(0.1, marquee.Speed);
    }

    [AvaloniaFact]
    public void Marquee_Should_Handle_Null_Content()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee
        {
            Content = "Initial content"
        };
        window.Content = marquee;
        window.Show();

        // Act
        marquee.Content = null;

        // Assert
        Assert.Null(marquee.Content);
    }

    [AvaloniaFact]
    public void Marquee_Should_Maintain_ContentAlignment_Properties()
    {
        // Arrange
        var window = new Window();
        var marquee = new UrsaControls.Marquee();
        window.Content = marquee;
        window.Show();

        // Act
        marquee.HorizontalContentAlignment = HorizontalAlignment.Left;
        marquee.VerticalContentAlignment = VerticalAlignment.Bottom;

        // Assert
        Assert.Equal(HorizontalAlignment.Left, marquee.HorizontalContentAlignment);
        Assert.Equal(VerticalAlignment.Bottom, marquee.VerticalContentAlignment);
    }
}