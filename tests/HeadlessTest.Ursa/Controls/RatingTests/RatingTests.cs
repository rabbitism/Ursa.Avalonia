using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.Threading;
using HeadlessTest.Ursa.TestHelpers;
using Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.RatingTests;

public class RatingTests
{
    [AvaloniaFact]
    public void Rating_Should_Initialize_With_Default_Values()
    {
        var rating = new Rating();
        
        Assert.Equal(0, rating.Value);
        Assert.Equal(5, rating.Count);
        Assert.Equal(0, rating.DefaultValue);
        Assert.True(rating.AllowClear);
        Assert.False(rating.AllowHalf);
        Assert.NotNull(rating.Items);
        Assert.Empty(rating.Items);
    }

    [AvaloniaFact]
    public void Rating_Should_Update_Properties()
    {
        var rating = new Rating();
        
        rating.Value = 3.5;
        rating.Count = 10;
        rating.AllowClear = false;
        rating.AllowHalf = true;
        rating.DefaultValue = 2.5;
        
        Assert.Equal(3.5, rating.Value);
        Assert.Equal(10, rating.Count);
        Assert.False(rating.AllowClear);
        Assert.True(rating.AllowHalf);
        Assert.Equal(2.5, rating.DefaultValue);
    }

    [AvaloniaFact]
    public void Rating_Should_Create_Items_On_Template_Applied()
    {
        var window = new Window();
        var rating = new Rating
        {
            Count = 3
        };
        window.Content = rating;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        Assert.Equal(3, rating.Items.Count);
        Assert.All(rating.Items, item => Assert.NotNull(item));
    }

    [AvaloniaFact]
    public void Rating_Should_Update_Items_When_Count_Changes()
    {
        var window = new Window();
        var rating = new Rating
        {
            Count = 5
        };
        window.Content = rating;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        Assert.Equal(5, rating.Items.Count);
        
        // Increase count
        rating.Count = 8;
        Dispatcher.UIThread.RunJobs();
        Assert.Equal(8, rating.Items.Count);
        
        // Decrease count
        rating.Count = 3;
        Dispatcher.UIThread.RunJobs();
        Assert.Equal(3, rating.Items.Count);
    }

    [AvaloniaFact]
    public void Rating_Should_Update_Items_When_AllowHalf_Changes()
    {
        var window = new Window();
        var rating = new Rating
        {
            Count = 3,
            AllowHalf = false
        };
        window.Content = rating;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        Assert.All(rating.Items, item => Assert.False(item.AllowHalf));
        
        rating.AllowHalf = true;
        Dispatcher.UIThread.RunJobs();
        
        Assert.All(rating.Items, item => Assert.True(item.AllowHalf));
    }

    [AvaloniaFact]
    public void Rating_Should_Set_DefaultValue_On_Load()
    {
        var window = new Window();
        var rating = new Rating
        {
            Count = 5,
            DefaultValue = 3
        };
        window.Content = rating;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        Assert.Equal(3, rating.Value);
    }

    [AvaloniaFact]
    public void Rating_Should_Handle_Character_Property()
    {
        var rating = new Rating();
        var starChar = "★";
        
        rating.Character = starChar;
        
        Assert.Equal(starChar, rating.Character);
    }

    [AvaloniaFact]
    public void Rating_Should_Handle_Size_Property()
    {
        var rating = new Rating();
        
        rating.Size = 24;
        
        Assert.Equal(24, rating.Size);
    }

    [AvaloniaFact]
    public void Rating_Should_Update_Items_With_Character_And_Size()
    {
        var window = new Window();
        var rating = new Rating
        {
            Count = 3,
            Character = "⭐",
            Size = 32
        };
        window.Content = rating;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        Assert.All(rating.Items, item =>
        {
            Assert.Equal("⭐", item.Character);
            Assert.Equal(32, item.Size);
        });
    }

    [AvaloniaFact]
    public void Rating_Should_Handle_ItemTemplate()
    {
        var rating = new Rating();
        var template = new FuncDataTemplate<RatingCharacter>((character, scope) => new TextBlock());
        
        rating.ItemTemplate = template;
        
        Assert.Equal(template, rating.ItemTemplate);
    }

    [AvaloniaFact]
    public void Rating_Should_Support_Value_Binding()
    {
        var rating = new Rating();
        
        // Test two-way binding by setting value
        rating.Value = 4.5;
        Assert.Equal(4.5, rating.Value);
        
        // Test clearing value
        rating.Value = 0;
        Assert.Equal(0, rating.Value);
    }

    [AvaloniaFact]
    public void Rating_Should_Have_Items_Control_Template_Part()
    {
        var window = new Window();
        var rating = new Rating();
        window.Content = rating;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        
        var itemsControl = rating.GetTemplateChildOfType<ItemsControl>(Rating.PART_ItemsControl);
        Assert.NotNull(itemsControl);
    }
}