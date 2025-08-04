using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Media;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.LoadingTests;

public class LoadingTests
{
    [AvaloniaFact]
    public void Loading_Should_Be_Created_Successfully()
    {
        var loading = new UrsaControl.Loading();
        
        Assert.NotNull(loading);
        Assert.Null(loading.Indicator);
        Assert.False(loading.IsLoading);
    }
    
    [AvaloniaFact]
    public void Loading_Indicator_Property_Should_Work()
    {
        var loading = new UrsaControl.Loading();
        
        // Initially null
        Assert.Null(loading.Indicator);
        
        // Set string indicator
        loading.Indicator = "Loading...";
        Assert.Equal("Loading...", loading.Indicator);
        
        // Set control indicator
        var spinner = new ProgressBar { IsIndeterminate = true };
        loading.Indicator = spinner;
        Assert.Equal(spinner, loading.Indicator);
    }
    
    [AvaloniaFact]
    public void Loading_IsLoading_Property_Should_Work()
    {
        var loading = new UrsaControl.Loading();
        
        // Initially false
        Assert.False(loading.IsLoading);
        
        // Set to true
        loading.IsLoading = true;
        Assert.True(loading.IsLoading);
        
        // Set back to false
        loading.IsLoading = false;
        Assert.False(loading.IsLoading);
    }
    
    [AvaloniaFact]
    public void Loading_Content_Should_Work()
    {
        var loading = new UrsaControl.Loading
        {
            Content = "Loading content...",
            IsLoading = true
        };
        
        Assert.Equal("Loading content...", loading.Content);
        Assert.True(loading.IsLoading);
    }
    
    [AvaloniaFact]
    public void Loading_In_Window_Should_Render()
    {
        var window = new Window();
        var loading = new UrsaControl.Loading
        {
            Content = "Please wait...",
            Indicator = "🔄",
            IsLoading = true,
            Width = 200,
            Height = 100
        };
        
        window.Content = loading;
        window.Show();
        
        Assert.Equal("Please wait...", loading.Content);
        Assert.Equal("🔄", loading.Indicator);
        Assert.True(loading.IsLoading);
    }
}

public class LoadingContainerTests
{
    [AvaloniaFact]
    public void LoadingContainer_Should_Be_Created_Successfully()
    {
        var loadingContainer = new UrsaControl.LoadingContainer();
        
        Assert.NotNull(loadingContainer);
        Assert.Null(loadingContainer.Indicator);
        Assert.Null(loadingContainer.LoadingMessage);
        Assert.False(loadingContainer.IsLoading);
    }
    
    [AvaloniaFact]
    public void LoadingContainer_Indicator_Property_Should_Work()
    {
        var loadingContainer = new UrsaControl.LoadingContainer();
        
        // Initially null
        Assert.Null(loadingContainer.Indicator);
        
        // Set indicator
        loadingContainer.Indicator = "⏳";
        Assert.Equal("⏳", loadingContainer.Indicator);
    }
    
    [AvaloniaFact]
    public void LoadingContainer_LoadingMessage_Property_Should_Work()
    {
        var loadingContainer = new UrsaControl.LoadingContainer();
        
        // Initially null
        Assert.Null(loadingContainer.LoadingMessage);
        
        // Set loading message
        loadingContainer.LoadingMessage = "Processing your request...";
        Assert.Equal("Processing your request...", loadingContainer.LoadingMessage);
    }
    
    [AvaloniaFact]
    public void LoadingContainer_MessageForeground_Property_Should_Work()
    {
        var loadingContainer = new UrsaControl.LoadingContainer();
        var blueBrush = Brushes.Blue;
        
        // Set message foreground
        loadingContainer.MessageForeground = blueBrush;
        Assert.Equal(blueBrush, loadingContainer.MessageForeground);
    }
    
    [AvaloniaFact]
    public void LoadingContainer_IsLoading_Property_Should_Work()
    {
        var loadingContainer = new UrsaControl.LoadingContainer();
        
        // Initially false
        Assert.False(loadingContainer.IsLoading);
        
        // Set to true
        loadingContainer.IsLoading = true;
        Assert.True(loadingContainer.IsLoading);
    }
    
    [AvaloniaFact]
    public void LoadingContainer_In_Window_Should_Render()
    {
        var window = new Window();
        var loadingContainer = new UrsaControl.LoadingContainer
        {
            Content = new Button { Content = "Hidden Content" },
            Indicator = "🔄",
            LoadingMessage = "Loading...",
            IsLoading = true,
            Width = 250,
            Height = 150
        };
        
        window.Content = loadingContainer;
        window.Show();
        
        Assert.NotNull(loadingContainer.Content);
        Assert.Equal("🔄", loadingContainer.Indicator);
        Assert.Equal("Loading...", loadingContainer.LoadingMessage);
        Assert.True(loadingContainer.IsLoading);
    }
}