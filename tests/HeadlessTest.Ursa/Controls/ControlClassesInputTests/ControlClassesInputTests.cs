using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Headless.XUnit;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.ControlClassesInputTests;

public class ControlClassesInputTests
{
    [AvaloniaFact]
    public void ControlClassesInput_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        
        // Assert
        Assert.Null(controlClassesInput.Target);
        Assert.NotNull(controlClassesInput.TargetClasses);
        Assert.Empty(controlClassesInput.TargetClasses);
        Assert.Equal(10, controlClassesInput.CountOfHistoricalRecord);
        Assert.Null(controlClassesInput.Separator);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Set_Target_Property()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        var targetButton = new Button();
        window.Content = controlClassesInput;
        window.Show();

        // Act
        controlClassesInput.Target = targetButton;

        // Assert
        Assert.Equal(targetButton, controlClassesInput.Target);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Set_Separator_Property()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        window.Content = controlClassesInput;
        window.Show();

        // Act
        controlClassesInput.Separator = ",";

        // Assert
        Assert.Equal(",", controlClassesInput.Separator);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Set_TargetClasses_Property()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        window.Content = controlClassesInput;
        window.Show();

        // Act
        var classes = new ObservableCollection<string> { "class1", "class2", "class3" };
        controlClassesInput.TargetClasses = classes;

        // Assert
        Assert.Equal(classes, controlClassesInput.TargetClasses);
        Assert.Equal(3, controlClassesInput.TargetClasses.Count);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Apply_Classes_To_Target()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        var targetButton = new Button();
        window.Content = controlClassesInput;
        window.Show();

        // Act
        controlClassesInput.Target = targetButton;
        controlClassesInput.TargetClasses!.Add("test-class");
        controlClassesInput.TargetClasses.Add("another-class");

        // Assert
        Assert.Contains("test-class", targetButton.Classes);
        Assert.Contains("another-class", targetButton.Classes);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Remove_Duplicates_From_Classes()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        var targetButton = new Button();
        window.Content = controlClassesInput;
        window.Show();

        // Act
        controlClassesInput.Target = targetButton;
        var classes = new ObservableCollection<string> { "class1", "class1", "class2", "class2", "class3" };
        controlClassesInput.TargetClasses = classes;

        // Assert - Target should only have unique classes
        Assert.Contains("class1", targetButton.Classes);
        Assert.Contains("class2", targetButton.Classes);
        Assert.Contains("class3", targetButton.Classes);
        // Count should reflect the unique classes only
        Assert.Equal(3, targetButton.Classes.Count);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Support_Undo_Operation()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        var targetButton = new Button();
        window.Content = controlClassesInput;
        window.Show();

        controlClassesInput.Target = targetButton;
        controlClassesInput.TargetClasses!.Add("initial-class");
        controlClassesInput.TargetClasses.Add("new-class");

        // Act - Should not throw
        controlClassesInput.UnDo();

        // Assert - Just ensure it doesn't crash
        Assert.NotNull(controlClassesInput.TargetClasses);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Support_Redo_Operation()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        var targetButton = new Button();
        window.Content = controlClassesInput;
        window.Show();

        controlClassesInput.Target = targetButton;
        controlClassesInput.TargetClasses!.Add("initial-class");
        controlClassesInput.TargetClasses.Add("new-class");
        controlClassesInput.UnDo();

        // Act - Should not throw
        controlClassesInput.Redo();

        // Assert - Just ensure it doesn't crash
        Assert.NotNull(controlClassesInput.TargetClasses);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Clear_All_Classes()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        var targetButton = new Button();
        window.Content = controlClassesInput;
        window.Show();

        controlClassesInput.Target = targetButton;
        controlClassesInput.TargetClasses!.Add("class1");
        controlClassesInput.TargetClasses.Add("class2");

        // Act
        controlClassesInput.Clear();

        // Assert
        Assert.Empty(targetButton.Classes);
        Assert.Empty(controlClassesInput.TargetClasses);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Handle_Null_Target()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        window.Content = controlClassesInput;
        window.Show();

        // Act - Should not throw when target is null
        controlClassesInput.Target = null;
        controlClassesInput.TargetClasses!.Add("test-class");

        // Assert
        Assert.Null(controlClassesInput.Target);
        Assert.Contains("test-class", controlClassesInput.TargetClasses);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        
        // Act
        window.Content = controlClassesInput;
        window.Show();

        // Assert
        Assert.True(controlClassesInput.IsVisible);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Inherit_From_TemplatedControl()
    {
        // Arrange & Act
        var controlClassesInput = new UrsaControls.ControlClassesInput();

        // Assert
        Assert.IsAssignableFrom<TemplatedControl>(controlClassesInput);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Filter_Empty_And_Whitespace_Classes()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        var targetButton = new Button();
        window.Content = controlClassesInput;
        window.Show();

        // Act
        controlClassesInput.Target = targetButton;
        var classes = new ObservableCollection<string> { "valid-class", "", "  ", "another-valid-class", null! };
        controlClassesInput.TargetClasses = classes;

        // Assert - Only valid classes should be applied
        Assert.Contains("valid-class", targetButton.Classes);
        Assert.Contains("another-valid-class", targetButton.Classes);
        Assert.Equal(2, targetButton.Classes.Count); // Only non-empty/non-whitespace classes
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Handle_CountOfHistoricalRecord_Property()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        window.Content = controlClassesInput;
        window.Show();

        // Act
        controlClassesInput.CountOfHistoricalRecord = 5;

        // Assert
        Assert.Equal(5, controlClassesInput.CountOfHistoricalRecord);
    }

    [AvaloniaFact]
    public void ControlClassesInput_Should_Support_AttachedProperty_Source()
    {
        // Arrange
        var window = new Window();
        var controlClassesInput = new UrsaControls.ControlClassesInput();
        var targetButton = new Button();
        window.Content = controlClassesInput;
        window.Show();

        // Act
        UrsaControls.ControlClassesInput.SetSource(targetButton, controlClassesInput);

        // Assert
        Assert.Equal(controlClassesInput, UrsaControls.ControlClassesInput.GetSource(targetButton));
    }
}