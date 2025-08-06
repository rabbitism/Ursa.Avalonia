using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.LoadingContainerTests;

public class LoadingContainerTests
{
    [AvaloniaFact]
    public void LoadingContainer_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var loadingContainer = new UrsaControls.LoadingContainer();
        
        // Assert
        Assert.Null(loadingContainer.Indicator);
        Assert.Null(loadingContainer.LoadingMessage);
        Assert.False(loadingContainer.IsLoading);
        Assert.Null(loadingContainer.MessageForeground);
    }

    [AvaloniaFact]
    public void LoadingContainer_Should_Set_IsLoading_Property()
    {
        // Arrange
        var window = new Window();
        var loadingContainer = new UrsaControls.LoadingContainer();
        window.Content = loadingContainer;
        window.Show();

        // Act & Assert
        loadingContainer.IsLoading = true;
        Assert.True(loadingContainer.IsLoading);

        loadingContainer.IsLoading = false;
        Assert.False(loadingContainer.IsLoading);
    }

    [AvaloniaFact]
    public void LoadingContainer_Should_Update_PseudoClass_When_IsLoading_Changes()
    {
        // Arrange
        var window = new Window();
        var loadingContainer = new UrsaControls.LoadingContainer();
        window.Content = loadingContainer;
        window.Show();

        // Act & Assert
        loadingContainer.IsLoading = true;
        Assert.Contains(UrsaControls.LoadingContainer.PC_Loading, loadingContainer.Classes);

        loadingContainer.IsLoading = false;
        Assert.DoesNotContain(UrsaControls.LoadingContainer.PC_Loading, loadingContainer.Classes);
    }

    [AvaloniaFact]
    public void LoadingContainer_Should_Set_Indicator_Property()
    {
        // Arrange
        var window = new Window();
        var loadingContainer = new UrsaControls.LoadingContainer();
        window.Content = loadingContainer;
        window.Show();

        // Act
        var indicator = "Custom Indicator";
        loadingContainer.Indicator = indicator;

        // Assert
        Assert.Equal(indicator, loadingContainer.Indicator);
    }

    [AvaloniaFact]
    public void LoadingContainer_Should_Set_LoadingMessage_Property()
    {
        // Arrange
        var window = new Window();
        var loadingContainer = new UrsaControls.LoadingContainer();
        window.Content = loadingContainer;
        window.Show();

        // Act
        var message = "Loading data...";
        loadingContainer.LoadingMessage = message;

        // Assert
        Assert.Equal(message, loadingContainer.LoadingMessage);
    }

    [AvaloniaFact]
    public void LoadingContainer_Should_Support_Content()
    {
        // Arrange
        var window = new Window();
        var loadingContainer = new UrsaControls.LoadingContainer
        {
            Content = "Test Content"
        };
        window.Content = loadingContainer;
        window.Show();

        // Assert
        Assert.Equal("Test Content", loadingContainer.Content);
    }

    [AvaloniaFact]
    public void LoadingContainer_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var loadingContainer = new UrsaControls.LoadingContainer();
        
        // Act
        window.Content = loadingContainer;
        window.Show();

        // Assert
        Assert.True(loadingContainer.IsVisible);
    }

    [AvaloniaFact]
    public void LoadingContainer_Should_Inherit_From_ContentControl()
    {
        // Arrange & Act
        var loadingContainer = new UrsaControls.LoadingContainer();

        // Assert
        Assert.IsAssignableFrom<ContentControl>(loadingContainer);
    }

    [AvaloniaFact]
    public void LoadingContainer_Should_Handle_Null_Values()
    {
        // Arrange
        var window = new Window();
        var loadingContainer = new UrsaControls.LoadingContainer
        {
            Indicator = "Test",
            LoadingMessage = "Loading..."
        };
        window.Content = loadingContainer;
        window.Show();

        // Act
        loadingContainer.Indicator = null;
        loadingContainer.LoadingMessage = null;

        // Assert
        Assert.Null(loadingContainer.Indicator);
        Assert.Null(loadingContainer.LoadingMessage);
    }
}