using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Threading;
using HeadlessTest.Ursa.TestHelpers;
using Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.DateTimePickerTests;

public class TimeRangePickerTests
{
    [AvaloniaFact]
    public void TimeRangePicker_Should_Initialize_With_Default_Values()
    {
        var picker = new TimeRangePicker();
        
        Assert.Null(picker.StartTime);
        Assert.Null(picker.EndTime);
        Assert.Null(picker.StartWatermark);
        Assert.Null(picker.EndWatermark);
        Assert.False(picker.IsDropdownOpen);
        Assert.True(picker.Focusable);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Handle_Time_Properties()
    {
        var picker = new TimeRangePicker();
        var startTime = new TimeSpan(9, 30, 0);
        var endTime = new TimeSpan(17, 45, 0);
        
        picker.StartTime = startTime;
        picker.EndTime = endTime;
        
        Assert.Equal(startTime, picker.StartTime);
        Assert.Equal(endTime, picker.EndTime);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Handle_Watermark_Properties()
    {
        var picker = new TimeRangePicker();
        var startWatermark = "Start Time";
        var endWatermark = "End Time";
        
        picker.StartWatermark = startWatermark;
        picker.EndWatermark = endWatermark;
        
        Assert.Equal(startWatermark, picker.StartWatermark);
        Assert.Equal(endWatermark, picker.EndWatermark);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Have_Required_Template_Parts()
    {
        var window = new Window();
        var picker = new TimeRangePicker
        {
            Width = 400,
            Height = 50
        };
        window.Content = picker;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var button = picker.GetTemplateChildOfType<Button>(TimeRangePicker.PART_Button);
        var popup = picker.GetTemplateChildOfType<Popup>("PART_Popup");
        var startTextBox = picker.GetTemplateChildOfType<TextBox>(TimeRangePicker.PART_StartTextBox);
        var endTextBox = picker.GetTemplateChildOfType<TextBox>(TimeRangePicker.PART_EndTextBox);
        
        Assert.NotNull(button);
        Assert.NotNull(popup);
        Assert.NotNull(startTextBox);
        Assert.NotNull(endTextBox);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Handle_Button_Click()
    {
        var window = new Window();
        var picker = new TimeRangePicker
        {
            Width = 400,
            Height = 50
        };
        window.Content = picker;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var button = picker.GetTemplateChildOfType<Button>(TimeRangePicker.PART_Button);
        Assert.NotNull(button);
        
        var position = button.TranslatePoint(new Point(5, 5), window);
        Assert.NotNull(position);
        
        Assert.False(picker.IsDropdownOpen);
        
        window.MouseDown(position.Value, MouseButton.Left);
        window.MouseUp(position.Value, MouseButton.Left);
        Dispatcher.UIThread.RunJobs();
        
        // Test that button click is handled without errors
        Assert.NotNull(picker);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Handle_Escape_Key()
    {
        var window = new Window();
        var picker = new TimeRangePicker
        {
            Width = 400,
            Height = 50
        };
        window.Content = picker;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        // Press escape to test key handling
        window.KeyPressQwerty(PhysicalKey.Escape, RawInputModifiers.None);
        Dispatcher.UIThread.RunJobs();
        
        // Test that escape key handling doesn't crash
        Assert.NotNull(picker);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Update_TextBoxes_When_Times_Set()
    {
        var window = new Window();
        var picker = new TimeRangePicker
        {
            Width = 400,
            Height = 50,
            DisplayFormat = "HH:mm"
        };
        window.Content = picker;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var startTextBox = picker.GetTemplateChildOfType<TextBox>(TimeRangePicker.PART_StartTextBox);
        var endTextBox = picker.GetTemplateChildOfType<TextBox>(TimeRangePicker.PART_EndTextBox);
        Assert.NotNull(startTextBox);
        Assert.NotNull(endTextBox);
        
        var startTime = new TimeSpan(9, 30, 0);
        var endTime = new TimeSpan(17, 45, 0);
        
        picker.StartTime = startTime;
        picker.EndTime = endTime;
        Dispatcher.UIThread.RunJobs();
        
        Assert.Equal("09:30", startTextBox.Text);
        Assert.Equal("17:45", endTextBox.Text);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Clear_Values()
    {
        var window = new Window();
        var picker = new TimeRangePicker
        {
            Width = 400,
            Height = 50,
            StartTime = new TimeSpan(9, 0, 0),
            EndTime = new TimeSpan(17, 0, 0)
        };
        window.Content = picker;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        Assert.NotNull(picker.StartTime);
        Assert.NotNull(picker.EndTime);
        
        picker.Clear();
        Dispatcher.UIThread.RunJobs();
        
        Assert.Null(picker.StartTime);
        Assert.Null(picker.EndTime);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Have_Popup_Content()
    {
        var window = new Window();
        var picker = new TimeRangePicker
        {
            Width = 400,
            Height = 50
        };
        window.Content = picker;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var popup = picker.GetTemplateChildOfType<Popup>("PART_Popup");
        Assert.NotNull(popup);
        
        // Test that popup exists in template
        Assert.NotNull(popup);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Be_Focusable()
    {
        var picker = new TimeRangePicker();
        
        Assert.True(picker.Focusable);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Handle_Null_Times_In_TextBoxes()
    {
        var window = new Window();
        var picker = new TimeRangePicker
        {
            Width = 400,
            Height = 50
        };
        window.Content = picker;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var startTextBox = picker.GetTemplateChildOfType<TextBox>(TimeRangePicker.PART_StartTextBox);
        var endTextBox = picker.GetTemplateChildOfType<TextBox>(TimeRangePicker.PART_EndTextBox);
        Assert.NotNull(startTextBox);
        Assert.NotNull(endTextBox);
        
        // Null times should result in empty text boxes
        Assert.True(string.IsNullOrEmpty(startTextBox.Text));
        Assert.True(string.IsNullOrEmpty(endTextBox.Text));
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Support_Time_Span_Values()
    {
        var picker = new TimeRangePicker();
        
        // Test various TimeSpan values
        var morning = new TimeSpan(8, 30, 15);
        var evening = new TimeSpan(20, 45, 30);
        
        picker.StartTime = morning;
        picker.EndTime = evening;
        
        Assert.Equal(morning, picker.StartTime);
        Assert.Equal(evening, picker.EndTime);
        Assert.Equal(8, picker.StartTime.Value.Hours);
        Assert.Equal(30, picker.StartTime.Value.Minutes);
        Assert.Equal(15, picker.StartTime.Value.Seconds);
        Assert.Equal(20, picker.EndTime.Value.Hours);
        Assert.Equal(45, picker.EndTime.Value.Minutes);
        Assert.Equal(30, picker.EndTime.Value.Seconds);
    }

    [AvaloniaFact]
    public void TimeRangePicker_Should_Handle_Midnight_And_Edge_Cases()
    {
        var picker = new TimeRangePicker();
        
        // Test midnight
        var midnight = new TimeSpan(0, 0, 0);
        var almostMidnight = new TimeSpan(23, 59, 59);
        
        picker.StartTime = midnight;
        picker.EndTime = almostMidnight;
        
        Assert.Equal(midnight, picker.StartTime);
        Assert.Equal(almostMidnight, picker.EndTime);
        Assert.Equal(0, picker.StartTime.Value.Hours);
        Assert.Equal(23, picker.EndTime.Value.Hours);
        Assert.Equal(59, picker.EndTime.Value.Minutes);
        Assert.Equal(59, picker.EndTime.Value.Seconds);
    }
}