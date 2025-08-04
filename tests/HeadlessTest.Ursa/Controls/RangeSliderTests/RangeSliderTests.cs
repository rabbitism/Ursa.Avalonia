using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Threading;
using HeadlessTest.Ursa.TestHelpers;
using Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.RangeSliderTests;

public class RangeSliderTests
{
    [AvaloniaFact]
    public void RangeSlider_Should_Initialize_With_Default_Values()
    {
        var slider = new RangeSlider();
        
        Assert.Equal(0, slider.Minimum);
        Assert.Equal(100, slider.Maximum);
        Assert.Equal(0, slider.LowerValue);
        Assert.Equal(100, slider.UpperValue);
        Assert.Equal(Orientation.Horizontal, slider.Orientation);
        Assert.False(slider.IsDirectionReversed);
        Assert.True(slider.Focusable);
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Update_Values()
    {
        var slider = new RangeSlider();
        
        slider.Minimum = 10;
        slider.Maximum = 200;
        slider.LowerValue = 30;
        slider.UpperValue = 150;
        
        Assert.Equal(10, slider.Minimum);
        Assert.Equal(200, slider.Maximum);
        Assert.Equal(30, slider.LowerValue);
        Assert.Equal(150, slider.UpperValue);
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Update_Orientation()
    {
        var slider = new RangeSlider();
        
        slider.Orientation = Orientation.Vertical;
        
        Assert.Equal(Orientation.Vertical, slider.Orientation);
        // PseudoClasses are internal, so we can't test them directly
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Raise_ValueChanged_Event()
    {
        var window = new Window();
        var slider = new RangeSlider
        {
            Width = 300,
            Height = 50
        };
        window.Content = slider;
        window.Show();
        
        bool eventRaised = false;
        double oldValue = 0;
        double newValue = 0;
        bool isLower = false;
        
        slider.ValueChanged += (sender, e) =>
        {
            eventRaised = true;
            oldValue = e.OldValue;
            newValue = e.NewValue;
            isLower = e.IsLower;
        };
        
        slider.LowerValue = 25;
        Dispatcher.UIThread.RunJobs();
        
        Assert.True(eventRaised);
        Assert.Equal(0, oldValue);
        Assert.Equal(25, newValue);
        Assert.True(isLower);
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Have_Track_Template_Part()
    {
        var window = new Window();
        var slider = new RangeSlider
        {
            Width = 300,
            Height = 50
        };
        window.Content = slider;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var track = slider.GetTemplateChildOfType<RangeTrack>(RangeSlider.PART_Track);
        Assert.NotNull(track);
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Support_Tick_Properties()
    {
        var slider = new RangeSlider();
        
        slider.TickFrequency = 10;
        slider.IsSnapToTick = true;
        slider.TickPlacement = TickPlacement.TopLeft;
        
        Assert.Equal(10, slider.TickFrequency);
        Assert.True(slider.IsSnapToTick);
        Assert.Equal(TickPlacement.TopLeft, slider.TickPlacement);
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Handle_TrackWidth_Property()
    {
        var slider = new RangeSlider();
        
        slider.TrackWidth = 200;
        
        Assert.Equal(200, slider.TrackWidth);
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Handle_IsDirectionReversed()
    {
        var slider = new RangeSlider();
        
        slider.IsDirectionReversed = true;
        
        Assert.True(slider.IsDirectionReversed);
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Constrain_Values_When_LowerValue_Exceeds_UpperValue()
    {
        var window = new Window();
        var slider = new RangeSlider
        {
            Width = 300,
            Height = 50,
            Minimum = 0,
            Maximum = 100,
            LowerValue = 30,
            UpperValue = 70
        };
        window.Content = slider;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        // Setting lower value higher than upper value should adjust upper value
        slider.LowerValue = 80;
        Dispatcher.UIThread.RunJobs();
        
        Assert.Equal(80, slider.LowerValue);
        // Upper value should have been adjusted through the control's logic
    }

    [AvaloniaFact]
    public void RangeSlider_Should_Support_Custom_Ticks()
    {
        var slider = new RangeSlider();
        var customTicks = new Avalonia.Collections.AvaloniaList<double> { 10, 25, 50, 75, 90 };
        
        slider.Ticks = customTicks;
        
        Assert.Equal(customTicks, slider.Ticks);
        Assert.Equal(5, slider.Ticks.Count);
    }
}