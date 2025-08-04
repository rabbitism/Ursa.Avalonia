using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.DateTimePickerMainTests;

public class Tests
{
    [AvaloniaFact]
    public void DateTimePicker_Should_Be_Created_Successfully()
    {
        var dateTimePicker = new UrsaControl.DateTimePicker();
        
        Assert.NotNull(dateTimePicker);
        Assert.Null(dateTimePicker.SelectedDate);
        Assert.True(dateTimePicker.Focusable);
    }
    
    [AvaloniaFact]
    public void DateTimePicker_SelectedDate_Property_Should_Work()
    {
        var dateTimePicker = new UrsaControl.DateTimePicker();
        var testDate = new DateTime(2024, 6, 15, 14, 30, 0);
        
        // Initially null
        Assert.Null(dateTimePicker.SelectedDate);
        
        // Set selected date
        dateTimePicker.SelectedDate = testDate;
        Assert.Equal(testDate, dateTimePicker.SelectedDate);
        
        // Set back to null
        dateTimePicker.SelectedDate = null;
        Assert.Null(dateTimePicker.SelectedDate);
    }
    
    [AvaloniaFact]
    public void DateTimePicker_Watermark_Property_Should_Work()
    {
        var dateTimePicker = new UrsaControl.DateTimePicker();
        
        // Initially null
        Assert.Null(dateTimePicker.Watermark);
        
        // Set watermark
        dateTimePicker.Watermark = "Select a date and time";
        Assert.Equal("Select a date and time", dateTimePicker.Watermark);
    }
    
    [AvaloniaFact]
    public void DateTimePicker_PanelFormat_Property_Should_Work()
    {
        var dateTimePicker = new UrsaControl.DateTimePicker();
        
        // Default should be "HH mm ss"
        Assert.Equal("HH mm ss", dateTimePicker.PanelFormat);
        
        // Set custom format
        dateTimePicker.PanelFormat = "HH:mm:ss";
        Assert.Equal("HH:mm:ss", dateTimePicker.PanelFormat);
    }
    
    [AvaloniaFact]
    public void DateTimePicker_NeedConfirmation_Property_Should_Work()
    {
        var dateTimePicker = new UrsaControl.DateTimePicker();
        
        // Default should be false
        Assert.False(dateTimePicker.NeedConfirmation);
        
        // Set to true
        dateTimePicker.NeedConfirmation = true;
        Assert.True(dateTimePicker.NeedConfirmation);
    }
    
    [AvaloniaFact]
    public void DateTimePicker_In_Window_Should_Render()
    {
        var window = new Window();
        var dateTimePicker = new UrsaControl.DateTimePicker
        {
            SelectedDate = DateTime.Now,
            Watermark = "Pick a date",
            PanelFormat = "HH:mm",
            Width = 200,
            Height = 35
        };
        
        window.Content = dateTimePicker;
        window.Show();
        
        Assert.NotNull(dateTimePicker.SelectedDate);
        Assert.Equal("Pick a date", dateTimePicker.Watermark);
        Assert.Equal("HH:mm", dateTimePicker.PanelFormat);
    }
    
    [AvaloniaFact]
    public void DateTimePicker_Focus_Should_Work()
    {
        var window = new Window();
        var dateTimePicker = new UrsaControl.DateTimePicker();
        
        window.Content = dateTimePicker;
        window.Show();
        
        dateTimePicker.Focus();
        Assert.True(dateTimePicker.IsFocused);
    }
}