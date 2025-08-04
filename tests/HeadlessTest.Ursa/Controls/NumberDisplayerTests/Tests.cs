using Avalonia.Controls;
using Avalonia.Headless.XUnit;
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
}