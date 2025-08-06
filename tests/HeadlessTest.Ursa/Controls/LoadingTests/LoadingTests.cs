using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.LoadingTests;

public class LoadingTests
{
    [AvaloniaFact]
    public void Loading_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var loading = new UrsaControls.Loading();
        
        // Assert
        Assert.Null(loading.Indicator);
        Assert.False(loading.IsLoading);
    }

    [AvaloniaFact]
    public void Loading_Should_Set_IsLoading_Property()
    {
        // Arrange
        var window = new Window();
        var loading = new UrsaControls.Loading();
        window.Content = loading;
        window.Show();

        // Act & Assert
        loading.IsLoading = true;
        Assert.True(loading.IsLoading);

        loading.IsLoading = false;
        Assert.False(loading.IsLoading);
    }

    [AvaloniaFact]
    public void Loading_Should_Set_Indicator_Property()
    {
        // Arrange
        var window = new Window();
        var loading = new UrsaControls.Loading();
        window.Content = loading;
        window.Show();

        // Act
        var indicator = "Loading...";
        loading.Indicator = indicator;

        // Assert
        Assert.Equal(indicator, loading.Indicator);
    }

    [AvaloniaFact]
    public void Loading_Should_Support_Content()
    {
        // Arrange
        var window = new Window();
        var loading = new UrsaControls.Loading
        {
            Content = "Test Content"
        };
        window.Content = loading;
        window.Show();

        // Assert
        Assert.Equal("Test Content", loading.Content);
    }

    [AvaloniaFact]
    public void Loading_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var loading = new UrsaControls.Loading();
        
        // Act
        window.Content = loading;
        window.Show();

        // Assert
        Assert.True(loading.IsVisible);
    }

    [AvaloniaFact]
    public void Loading_Should_Inherit_From_ContentControl()
    {
        // Arrange & Act
        var loading = new UrsaControls.Loading();

        // Assert
        Assert.IsAssignableFrom<ContentControl>(loading);
    }

    [AvaloniaFact]
    public void Loading_Should_Handle_Null_Indicator()
    {
        // Arrange
        var window = new Window();
        var loading = new UrsaControls.Loading
        {
            Indicator = "Test"
        };
        window.Content = loading;
        window.Show();

        // Act
        loading.Indicator = null;

        // Assert
        Assert.Null(loading.Indicator);
    }
}