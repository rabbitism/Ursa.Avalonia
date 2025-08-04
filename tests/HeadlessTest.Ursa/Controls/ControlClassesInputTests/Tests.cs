using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.ControlClassesInputTests;

public class Tests
{
    [AvaloniaFact]
    public void ControlClassesInput_Should_Be_Created_Successfully()
    {
        var controlClassesInput = new UrsaControl.ControlClassesInput();
        
        Assert.NotNull(controlClassesInput);
        Assert.Null(controlClassesInput.Target);
        Assert.NotNull(controlClassesInput.TargetClasses);
        Assert.Empty(controlClassesInput.TargetClasses);
        Assert.Equal(10, controlClassesInput.CountOfHistoricalRecord);
    }
    
    [AvaloniaFact]
    public void ControlClassesInput_Target_Property_Should_Work()
    {
        var controlClassesInput = new UrsaControl.ControlClassesInput();
        var targetButton = new Button { Content = "Target Button" };
        
        // Initially null
        Assert.Null(controlClassesInput.Target);
        
        // Set target
        controlClassesInput.Target = targetButton;
        Assert.Equal(targetButton, controlClassesInput.Target);
    }
    
    [AvaloniaFact]
    public void ControlClassesInput_Separator_Property_Should_Work()
    {
        var controlClassesInput = new UrsaControl.ControlClassesInput();
        
        // Set separator
        controlClassesInput.Separator = ";";
        Assert.Equal(";", controlClassesInput.Separator);
        
        controlClassesInput.Separator = ",";
        Assert.Equal(",", controlClassesInput.Separator);
    }
    
    [AvaloniaFact]
    public void ControlClassesInput_TargetClasses_Property_Should_Work()
    {
        var controlClassesInput = new UrsaControl.ControlClassesInput();
        var classes = new ObservableCollection<string> { "class1", "class2", "class3" };
        
        // Initially empty collection
        Assert.NotNull(controlClassesInput.TargetClasses);
        Assert.Empty(controlClassesInput.TargetClasses);
        
        // Set target classes
        controlClassesInput.TargetClasses = classes;
        Assert.Equal(classes, controlClassesInput.TargetClasses);
        Assert.Equal(3, controlClassesInput.TargetClasses.Count);
        Assert.Contains("class1", controlClassesInput.TargetClasses);
        Assert.Contains("class2", controlClassesInput.TargetClasses);
        Assert.Contains("class3", controlClassesInput.TargetClasses);
    }
    
    [AvaloniaFact]
    public void ControlClassesInput_CountOfHistoricalRecord_Property_Should_Work()
    {
        var controlClassesInput = new UrsaControl.ControlClassesInput();
        
        // Default should be 10
        Assert.Equal(10, controlClassesInput.CountOfHistoricalRecord);
        
        // Set to different value
        controlClassesInput.CountOfHistoricalRecord = 20;
        Assert.Equal(20, controlClassesInput.CountOfHistoricalRecord);
    }
    
    [AvaloniaFact]
    public void ControlClassesInput_In_Window_Should_Render()
    {
        var window = new Window();
        var targetButton = new Button { Content = "Test Button" };
        var controlClassesInput = new UrsaControl.ControlClassesInput
        {
            Target = targetButton,
            TargetClasses = new ObservableCollection<string> { "test-class" },
            Width = 200,
            Height = 40
        };
        
        window.Content = new StackPanel
        {
            Children = { targetButton, controlClassesInput }
        };
        window.Show();
        
        Assert.Equal(targetButton, controlClassesInput.Target);
        Assert.NotNull(controlClassesInput.TargetClasses);
        Assert.Single(controlClassesInput.TargetClasses);
        Assert.Equal("test-class", controlClassesInput.TargetClasses[0]);
    }
}