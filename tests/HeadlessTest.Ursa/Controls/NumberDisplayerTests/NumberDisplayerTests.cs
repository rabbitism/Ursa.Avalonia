using System;
using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.NumberDisplayerTests;

public class Int32DisplayerTests
{
    [AvaloniaFact]
    public void Int32Displayer_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var displayer = new UrsaControls.Int32Displayer();
        
        // Assert
        Assert.Equal(0, displayer.Value);
        Assert.False(displayer.IsSelectable);
        Assert.Equal(TimeSpan.Zero, displayer.Duration);
        Assert.Null(displayer.StringFormat);
    }

    [AvaloniaFact]
    public void Int32Displayer_Should_Set_Value_Property()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.Int32Displayer();
        window.Content = displayer;
        window.Show();

        // Act & Assert
        displayer.Value = 42;
        Assert.Equal(42, displayer.Value);

        displayer.Value = -100;
        Assert.Equal(-100, displayer.Value);

        displayer.Value = 0;
        Assert.Equal(0, displayer.Value);
    }

    [AvaloniaFact]
    public void Int32Displayer_Should_Set_StringFormat_Property()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.Int32Displayer();
        window.Content = displayer;
        window.Show();

        // Act
        displayer.StringFormat = "N0";
        displayer.Value = 1000;

        // Assert
        Assert.Equal("N0", displayer.StringFormat);
    }

    [AvaloniaFact]
    public void Int32Displayer_Should_Set_Duration_Property()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.Int32Displayer();
        window.Content = displayer;
        window.Show();

        // Act
        var duration = TimeSpan.FromSeconds(2);
        displayer.Duration = duration;

        // Assert
        Assert.Equal(duration, displayer.Duration);
    }

    [AvaloniaFact]
    public void Int32Displayer_Should_Set_IsSelectable_Property()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.Int32Displayer();
        window.Content = displayer;
        window.Show();

        // Act & Assert
        displayer.IsSelectable = true;
        Assert.True(displayer.IsSelectable);

        displayer.IsSelectable = false;
        Assert.False(displayer.IsSelectable);
    }

    [AvaloniaFact]
    public void Int32Displayer_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.Int32Displayer();
        
        // Act
        window.Content = displayer;
        window.Show();

        // Assert
        Assert.True(displayer.IsVisible);
    }

    [AvaloniaFact]
    public void Int32Displayer_Should_Inherit_From_NumberDisplayerBase()
    {
        // Arrange & Act
        var displayer = new UrsaControls.Int32Displayer();

        // Assert
        Assert.IsAssignableFrom<UrsaControls.NumberDisplayerBase>(displayer);
    }

    [AvaloniaFact]
    public void Int32Displayer_Should_Handle_Large_Values()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.Int32Displayer();
        window.Content = displayer;
        window.Show();

        // Act & Assert
        displayer.Value = int.MaxValue;
        Assert.Equal(int.MaxValue, displayer.Value);

        displayer.Value = int.MinValue;
        Assert.Equal(int.MinValue, displayer.Value);
    }
}

public class DoubleDisplayerTests
{
    [AvaloniaFact]
    public void DoubleDisplayer_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var displayer = new UrsaControls.DoubleDisplayer();
        
        // Assert
        Assert.Equal(0.0, displayer.Value);
        Assert.False(displayer.IsSelectable);
        Assert.Equal(TimeSpan.Zero, displayer.Duration);
        Assert.Null(displayer.StringFormat);
    }

    [AvaloniaFact]
    public void DoubleDisplayer_Should_Set_Value_Property()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.DoubleDisplayer();
        window.Content = displayer;
        window.Show();

        // Act & Assert
        displayer.Value = 42.5;
        Assert.Equal(42.5, displayer.Value);

        displayer.Value = -100.99;
        Assert.Equal(-100.99, displayer.Value);

        displayer.Value = 0.0;
        Assert.Equal(0.0, displayer.Value);
    }

    [AvaloniaFact]
    public void DoubleDisplayer_Should_Set_StringFormat_Property()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.DoubleDisplayer();
        window.Content = displayer;
        window.Show();

        // Act
        displayer.StringFormat = "F2";
        displayer.Value = 3.14159;

        // Assert
        Assert.Equal("F2", displayer.StringFormat);
    }

    [AvaloniaFact]
    public void DoubleDisplayer_Should_Handle_Special_Values()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.DoubleDisplayer();
        window.Content = displayer;
        window.Show();

        // Act & Assert
        displayer.Value = double.MaxValue;
        Assert.Equal(double.MaxValue, displayer.Value);

        displayer.Value = double.MinValue;
        Assert.Equal(double.MinValue, displayer.Value);

        displayer.Value = double.NaN;
        Assert.True(double.IsNaN(displayer.Value));

        displayer.Value = double.PositiveInfinity;
        Assert.True(double.IsPositiveInfinity(displayer.Value));

        displayer.Value = double.NegativeInfinity;
        Assert.True(double.IsNegativeInfinity(displayer.Value));
    }

    [AvaloniaFact]
    public void DoubleDisplayer_Should_Inherit_From_NumberDisplayerBase()
    {
        // Arrange & Act
        var displayer = new UrsaControls.DoubleDisplayer();

        // Assert
        Assert.IsAssignableFrom<UrsaControls.NumberDisplayerBase>(displayer);
    }
}

public class DateDisplayTests
{
    [AvaloniaFact]
    public void DateDisplay_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var displayer = new UrsaControls.DateDisplay();
        
        // Assert
        Assert.Equal(default(DateTime), displayer.Value);
        Assert.False(displayer.IsSelectable);
        Assert.Equal(TimeSpan.Zero, displayer.Duration);
        Assert.Null(displayer.StringFormat);
    }

    [AvaloniaFact]
    public void DateDisplay_Should_Set_Value_Property()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.DateDisplay();
        window.Content = displayer;
        window.Show();

        // Act & Assert
        var date = new DateTime(2023, 12, 25);
        displayer.Value = date;
        Assert.Equal(date, displayer.Value);

        var now = DateTime.Now;
        displayer.Value = now;
        Assert.Equal(now, displayer.Value);
    }

    [AvaloniaFact]
    public void DateDisplay_Should_Set_StringFormat_Property()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.DateDisplay();
        window.Content = displayer;
        window.Show();

        // Act
        displayer.StringFormat = "yyyy-MM-dd";
        displayer.Value = new DateTime(2023, 12, 25);

        // Assert
        Assert.Equal("yyyy-MM-dd", displayer.StringFormat);
    }

    [AvaloniaFact]
    public void DateDisplay_Should_Handle_Edge_Dates()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.DateDisplay();
        window.Content = displayer;
        window.Show();

        // Act & Assert
        displayer.Value = DateTime.MinValue;
        Assert.Equal(DateTime.MinValue, displayer.Value);

        displayer.Value = DateTime.MaxValue;
        Assert.Equal(DateTime.MaxValue, displayer.Value);
    }

    [AvaloniaFact]
    public void DateDisplay_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var displayer = new UrsaControls.DateDisplay();
        
        // Act
        window.Content = displayer;
        window.Show();

        // Assert
        Assert.True(displayer.IsVisible);
    }

    [AvaloniaFact]
    public void DateDisplay_Should_Inherit_From_NumberDisplayerBase()
    {
        // Arrange & Act
        var displayer = new UrsaControls.DateDisplay();

        // Assert
        Assert.IsAssignableFrom<UrsaControls.NumberDisplayerBase>(displayer);
    }
}