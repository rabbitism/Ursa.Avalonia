using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Layout;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.MarqueeTests;

public class Tests
{
    [AvaloniaFact]
    public void Marquee_Should_Be_Created_Successfully()
    {
        var marquee = new UrsaControl.Marquee();
        
        Assert.NotNull(marquee);
        Assert.True(marquee.IsRunning);
        Assert.Equal(UrsaControl.Direction.Left, marquee.Direction);
        Assert.Equal(60.0, marquee.Speed);
        Assert.True(marquee.ClipToBounds);
    }
    
    [AvaloniaFact]
    public void Marquee_IsRunning_Property_Should_Work()
    {
        var marquee = new UrsaControl.Marquee();
        
        // Default should be true
        Assert.True(marquee.IsRunning);
        
        // Set to false
        marquee.IsRunning = false;
        Assert.False(marquee.IsRunning);
        
        // Set back to true
        marquee.IsRunning = true;
        Assert.True(marquee.IsRunning);
    }
    
    [AvaloniaFact]
    public void Marquee_Direction_Property_Should_Work()
    {
        var marquee = new UrsaControl.Marquee();
        
        // Default should be Left
        Assert.Equal(UrsaControl.Direction.Left, marquee.Direction);
        
        // Set to Right
        marquee.Direction = UrsaControl.Direction.Right;
        Assert.Equal(UrsaControl.Direction.Right, marquee.Direction);
        
        // Set to Up
        marquee.Direction = UrsaControl.Direction.Up;
        Assert.Equal(UrsaControl.Direction.Up, marquee.Direction);
        
        // Set to Down
        marquee.Direction = UrsaControl.Direction.Down;
        Assert.Equal(UrsaControl.Direction.Down, marquee.Direction);
    }
    
    [AvaloniaFact]
    public void Marquee_Speed_Property_Should_Work()
    {
        var marquee = new UrsaControl.Marquee();
        
        // Default should be 60.0
        Assert.Equal(60.0, marquee.Speed);
        
        // Set to different positive value
        marquee.Speed = 120.0;
        Assert.Equal(120.0, marquee.Speed);
        
        // Set to zero
        marquee.Speed = 0.0;
        Assert.Equal(0.0, marquee.Speed);
    }
    
    [AvaloniaFact]
    public void Marquee_Speed_Should_Not_Accept_Negative_Values()
    {
        var marquee = new UrsaControl.Marquee();
        
        // Try to set negative value, should be coerced to 0
        marquee.Speed = -50.0;
        Assert.Equal(0.0, marquee.Speed);
    }
    
    [AvaloniaFact]
    public void Marquee_Content_Should_Work()
    {
        var marquee = new UrsaControl.Marquee
        {
            Content = "This is a scrolling text message"
        };
        
        Assert.Equal("This is a scrolling text message", marquee.Content);
    }
    
    [AvaloniaFact]
    public void Marquee_HorizontalContentAlignment_Should_Have_Default()
    {
        var marquee = new UrsaControl.Marquee();
        
        // Should default to Center
        Assert.Equal(HorizontalAlignment.Center, marquee.HorizontalContentAlignment);
    }
    
    [AvaloniaFact]
    public void Marquee_VerticalContentAlignment_Should_Have_Default()
    {
        var marquee = new UrsaControl.Marquee();
        
        // Should default to Center
        Assert.Equal(VerticalAlignment.Center, marquee.VerticalContentAlignment);
    }
    
    [AvaloniaFact]
    public void Marquee_In_Window_Should_Render()
    {
        var window = new Window();
        var marquee = new UrsaControl.Marquee
        {
            Content = "🚀 This text should scroll continuously! 🚀",
            Direction = UrsaControl.Direction.Right,
            Speed = 30.0,
            IsRunning = true,
            Width = 300,
            Height = 50
        };
        
        window.Content = marquee;
        window.Show();
        
        Assert.Equal("🚀 This text should scroll continuously! 🚀", marquee.Content);
        Assert.Equal(UrsaControl.Direction.Right, marquee.Direction);
        Assert.Equal(30.0, marquee.Speed);
        Assert.True(marquee.IsRunning);
    }
}