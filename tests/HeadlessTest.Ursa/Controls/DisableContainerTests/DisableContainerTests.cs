using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.DisableContainerTests;

public class DisableContainerTests
{
    [AvaloniaFact]
    public void DisableContainer_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var disableContainer = new UrsaControls.DisableContainer();
        
        // Assert
        Assert.Null(disableContainer.Content);
        Assert.Null(disableContainer.DisabledTip);
    }

    [AvaloniaFact]
    public void DisableContainer_Should_Set_Content_Property()
    {
        // Arrange
        var window = new Window();
        var disableContainer = new UrsaControls.DisableContainer();
        var button = new Button { Content = "Test Button" };
        window.Content = disableContainer;
        window.Show();

        // Act
        disableContainer.Content = button;

        // Assert
        Assert.Equal(button, disableContainer.Content);
    }

    [AvaloniaFact]
    public void DisableContainer_Should_Set_DisabledTip_Property()
    {
        // Arrange
        var window = new Window();
        var disableContainer = new UrsaControls.DisableContainer();
        window.Content = disableContainer;
        window.Show();

        // Act
        var tip = "This control is disabled";
        disableContainer.DisabledTip = tip;

        // Assert
        Assert.Equal(tip, disableContainer.DisabledTip);
    }

    [AvaloniaFact]
    public void DisableContainer_Should_Accept_InputElement_Content()
    {
        // Arrange
        var window = new Window();
        var disableContainer = new UrsaControls.DisableContainer();
        var textBox = new TextBox { Text = "Test Text" };
        window.Content = disableContainer;
        window.Show();

        // Act
        disableContainer.Content = textBox;

        // Assert
        Assert.Equal(textBox, disableContainer.Content);
        Assert.IsAssignableFrom<InputElement>(disableContainer.Content);
    }

    [AvaloniaFact]
    public void DisableContainer_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var disableContainer = new UrsaControls.DisableContainer();
        
        // Act
        window.Content = disableContainer;
        window.Show();

        // Assert
        Assert.True(disableContainer.IsVisible);
    }

    [AvaloniaFact]
    public void DisableContainer_Should_Inherit_From_TemplatedControl()
    {
        // Arrange & Act
        var disableContainer = new UrsaControls.DisableContainer();

        // Assert
        Assert.IsAssignableFrom<TemplatedControl>(disableContainer);
    }

    [AvaloniaFact]
    public void DisableContainer_Should_Handle_Null_Content()
    {
        // Arrange
        var window = new Window();
        var disableContainer = new UrsaControls.DisableContainer
        {
            Content = new Button()
        };
        window.Content = disableContainer;
        window.Show();

        // Act
        disableContainer.Content = null;

        // Assert
        Assert.Null(disableContainer.Content);
    }

    [AvaloniaFact]
    public void DisableContainer_Should_Handle_Null_DisabledTip()
    {
        // Arrange
        var window = new Window();
        var disableContainer = new UrsaControls.DisableContainer
        {
            DisabledTip = "Test tip"
        };
        window.Content = disableContainer;
        window.Show();

        // Act
        disableContainer.DisabledTip = null;

        // Assert
        Assert.Null(disableContainer.DisabledTip);
    }

    [AvaloniaFact]
    public void DisableContainer_Should_Support_Various_Content_Types()
    {
        // Arrange
        var window = new Window();
        var disableContainer = new UrsaControls.DisableContainer();
        window.Content = disableContainer;
        window.Show();

        // Test with different InputElement types
        var controls = new InputElement[]
        {
            new Button(),
            new TextBox(),
            new CheckBox(),
            new ComboBox()
        };

        foreach (var control in controls)
        {
            // Act
            disableContainer.Content = control;

            // Assert
            Assert.Equal(control, disableContainer.Content);
        }
    }
}