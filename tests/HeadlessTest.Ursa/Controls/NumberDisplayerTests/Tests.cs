using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Threading;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.NumberDisplayerTests;

public class DateDisplayTests
{
    [AvaloniaFact]
    public void DateDisplay_Should_Be_Created_Successfully()
    {
        var dateDisplay = new UrsaControl.DateDisplay();
        
        Assert.NotNull(dateDisplay);
    }
    
    [AvaloniaFact]
    public void DateDisplay_Value_Property_Should_Work()
    {
        var dateDisplay = new UrsaControl.DateDisplay();
        var testDate = new DateTime(2024, 1, 15, 14, 30, 0);
        
        dateDisplay.Value = testDate;
        Assert.Equal(testDate, dateDisplay.Value);
    }
    
    [AvaloniaFact]
    public void DateDisplay_StringFormat_Should_Work()
    {
        var window = new Window();
        var dateDisplay = new UrsaControl.DateDisplay
        {
            Value = new DateTime(2024, 1, 15, 14, 30, 0),
            StringFormat = "yyyy-MM-dd HH:mm"
        };
        
        window.Content = dateDisplay;
        window.Show();
        
        Assert.Equal("yyyy-MM-dd HH:mm", dateDisplay.StringFormat);
    }
    
    [AvaloniaFact]
    public void DateDisplay_In_Window_Should_Render()
    {
        var window = new Window();
        var dateDisplay = new UrsaControl.DateDisplay
        {
            Value = DateTime.Now,
            Width = 200,
            Height = 50
        };
        
        window.Content = dateDisplay;
        window.Show();
        
        Assert.NotEqual(default(DateTime), dateDisplay.Value);
    }
    
    [AvaloniaFact]
    public async Task DateDisplay_InternalText_Should_Update_When_Value_Changes()
    {
        var window = new Window();
        var dateDisplay = new UrsaControl.DateDisplay
        {
            StringFormat = "yyyy-MM-dd HH:mm:ss",
            Duration = TimeSpan.FromMilliseconds(50) // Short animation
        };
        
        window.Content = dateDisplay;
        window.Show();
        
        // Allow UI to update and template to be applied
        Dispatcher.UIThread.RunJobs();
        
        var testDate = new DateTime(2024, 1, 15, 14, 30, 45);
        dateDisplay.Value = testDate;
        
        // Allow UI to update
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(100); // Wait for animation to complete
        
        Assert.NotNull(dateDisplay.InternalText);
        Assert.Contains("2024-01-15", dateDisplay.InternalText);
    }
    
    [AvaloniaFact]
    public async Task DateDisplay_InternalText_Should_Change_Multiple_Times_During_Animation()
    {
        var window = new Window();
        var dateDisplay = new UrsaControl.DateDisplay
        {
            Duration = TimeSpan.FromMilliseconds(500), // Longer duration for more changes
            StringFormat = "yyyy-MM-dd HH:mm:ss"
        };
        
        window.Content = dateDisplay;
        window.Show();
        
        // Allow template to be applied
        Dispatcher.UIThread.RunJobs();
        
        var textValues = new List<string?>();
        
        // Subscribe to property changes using AvaloniaPropertyChangedEventArgs
        dateDisplay.PropertyChanged += (sender, args) =>
        {
            if (args.Property == UrsaControl.NumberDisplayerBase.InternalTextProperty)
            {
                textValues.Add(args.NewValue as string);
            }
        };
        
        var initialDate = new DateTime(2024, 1, 1, 12, 0, 0);
        var finalDate = new DateTime(2024, 12, 31, 12, 0, 0);
        
        dateDisplay.Value = initialDate;
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(100); // Wait for initial animation
        
        textValues.Clear(); // Clear initial values
        
        dateDisplay.Value = finalDate;
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(600); // Wait for animation to complete
        
        // Should have collected multiple text values during animation
        Assert.True(textValues.Count > 1, $"Expected multiple text values, but got {textValues.Count}");
    }
}

public class DoubleDisplayerTests
{
    [AvaloniaFact]
    public void DoubleDisplayer_Should_Be_Created_Successfully()
    {
        var doubleDisplayer = new UrsaControl.DoubleDisplayer();
        
        Assert.NotNull(doubleDisplayer);
        Assert.Equal(0.0, doubleDisplayer.Value);
    }
    
    [AvaloniaFact]
    public void DoubleDisplayer_Value_Property_Should_Work()
    {
        var doubleDisplayer = new UrsaControl.DoubleDisplayer();
        
        doubleDisplayer.Value = 123.456;
        Assert.Equal(123.456, doubleDisplayer.Value);
        
        doubleDisplayer.Value = -789.123;
        Assert.Equal(-789.123, doubleDisplayer.Value);
    }
    
    [AvaloniaFact]
    public void DoubleDisplayer_StringFormat_Should_Work()
    {
        var window = new Window();
        var doubleDisplayer = new UrsaControl.DoubleDisplayer
        {
            Value = 123.456789,
            StringFormat = "F2"
        };
        
        window.Content = doubleDisplayer;
        window.Show();
        
        Assert.Equal("F2", doubleDisplayer.StringFormat);
    }
    
    [AvaloniaFact]
    public void DoubleDisplayer_In_Window_Should_Render()
    {
        var window = new Window();
        var doubleDisplayer = new UrsaControl.DoubleDisplayer
        {
            Value = 999.99,
            Width = 100,
            Height = 30
        };
        
        window.Content = doubleDisplayer;
        window.Show();
        
        Assert.Equal(999.99, doubleDisplayer.Value);
    }
    
    [AvaloniaFact]
    public async Task DoubleDisplayer_InternalText_Should_Update_When_Value_Changes()
    {
        var window = new Window();
        var doubleDisplayer = new UrsaControl.DoubleDisplayer
        {
            StringFormat = "F2",
            Duration = TimeSpan.FromMilliseconds(50) // Short animation
        };
        
        window.Content = doubleDisplayer;
        window.Show();
        
        // Allow UI to update and template to be applied
        Dispatcher.UIThread.RunJobs();
        
        doubleDisplayer.Value = 123.456;
        
        // Allow UI to update
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(100); // Wait for animation to complete
        
        Assert.NotNull(doubleDisplayer.InternalText);
        Assert.Equal("123.46", doubleDisplayer.InternalText);
    }
    
    [AvaloniaFact]
    public async Task DoubleDisplayer_InternalText_Should_Change_Multiple_Times_During_Animation()
    {
        var window = new Window();
        var doubleDisplayer = new UrsaControl.DoubleDisplayer
        {
            Duration = TimeSpan.FromMilliseconds(500), // Longer duration for more changes
            StringFormat = "F2"
        };
        
        window.Content = doubleDisplayer;
        window.Show();
        
        // Allow template to be applied
        Dispatcher.UIThread.RunJobs();
        
        var textValues = new List<string?>();
        
        // Subscribe to property changes using AvaloniaPropertyChangedEventArgs
        doubleDisplayer.PropertyChanged += (sender, args) =>
        {
            if (args.Property == UrsaControl.NumberDisplayerBase.InternalTextProperty)
            {
                textValues.Add(args.NewValue as string);
            }
        };
        
        doubleDisplayer.Value = 0.0;
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(100); // Wait for initial animation
        
        textValues.Clear(); // Clear initial values
        
        doubleDisplayer.Value = 1000.0;
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(600); // Wait for animation to complete
        
        // Should have collected multiple text values during animation
        Assert.True(textValues.Count > 1, $"Expected multiple text values, but got {textValues.Count}");
    }
}

public class Int32DisplayerTests
{
    [AvaloniaFact]
    public void Int32Displayer_Should_Be_Created_Successfully()
    {
        var intDisplayer = new UrsaControl.Int32Displayer();
        
        Assert.NotNull(intDisplayer);
        Assert.Equal(0, intDisplayer.Value);
    }
    
    [AvaloniaFact]
    public void Int32Displayer_Value_Property_Should_Work()
    {
        var intDisplayer = new UrsaControl.Int32Displayer();
        
        intDisplayer.Value = 12345;
        Assert.Equal(12345, intDisplayer.Value);
        
        intDisplayer.Value = -6789;
        Assert.Equal(-6789, intDisplayer.Value);
    }
    
    [AvaloniaFact]
    public void Int32Displayer_StringFormat_Should_Work()
    {
        var window = new Window();
        var intDisplayer = new UrsaControl.Int32Displayer
        {
            Value = 1234,
            StringFormat = "N0"
        };
        
        window.Content = intDisplayer;
        window.Show();
        
        Assert.Equal("N0", intDisplayer.StringFormat);
    }
    
    [AvaloniaFact]
    public void Int32Displayer_In_Window_Should_Render()
    {
        var window = new Window();
        var intDisplayer = new UrsaControl.Int32Displayer
        {
            Value = 42,
            Width = 80,
            Height = 25
        };
        
        window.Content = intDisplayer;
        window.Show();
        
        Assert.Equal(42, intDisplayer.Value);
    }
    
    [AvaloniaFact]
    public async Task Int32Displayer_InternalText_Should_Update_When_Value_Changes()
    {
        var window = new Window();
        var intDisplayer = new UrsaControl.Int32Displayer
        {
            Duration = TimeSpan.FromMilliseconds(50) // Short animation
        };
        
        window.Content = intDisplayer;
        window.Show();
        
        // Allow UI to update and template to be applied
        Dispatcher.UIThread.RunJobs();
        
        // Set the value after template is applied
        intDisplayer.Value = 12345;
        
        // Allow UI to update again
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(100); // Wait for animation to complete
        
        Assert.NotNull(intDisplayer.InternalText);
        Assert.Equal("12345", intDisplayer.InternalText); // Should equal the formatted number
    }
    
    [AvaloniaFact]
    public async Task Int32Displayer_InternalText_Should_Change_Multiple_Times_During_Animation()
    {
        var window = new Window();
        var intDisplayer = new UrsaControl.Int32Displayer
        {
            Duration = TimeSpan.FromMilliseconds(500) // Longer duration for more changes
        };
        
        window.Content = intDisplayer;
        window.Show();
        
        // Allow template to be applied
        Dispatcher.UIThread.RunJobs();
        
        var textValues = new List<string?>();
        
        // Subscribe to property changes using AvaloniaPropertyChangedEventArgs
        intDisplayer.PropertyChanged += (sender, args) =>
        {
            if (args.Property == UrsaControl.NumberDisplayerBase.InternalTextProperty)
            {
                textValues.Add(args.NewValue as string);
            }
        };
        
        intDisplayer.Value = 0;
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(100); // Wait for initial animation
        
        textValues.Clear(); // Clear initial values
        
        intDisplayer.Value = 1000;
        Dispatcher.UIThread.RunJobs();
        await Task.Delay(600); // Wait for animation to complete
        
        // Should have collected multiple text values during animation
        Assert.True(textValues.Count > 1, $"Expected multiple text values, but got {textValues.Count}");
    }
}