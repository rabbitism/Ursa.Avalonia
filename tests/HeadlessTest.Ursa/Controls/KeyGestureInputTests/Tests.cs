using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.Layout;
using UrsaControl = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.KeyGestureInputTests;

public class Tests
{
    [AvaloniaFact]
    public void KeyGestureInput_Should_Be_Created_Successfully()
    {
        var keyGestureInput = new UrsaControl.KeyGestureInput();
        
        Assert.NotNull(keyGestureInput);
        Assert.Null(keyGestureInput.Gesture);
        Assert.True(keyGestureInput.ConsiderKeyModifiers);
        Assert.True(keyGestureInput.Focusable);
    }
    
    [AvaloniaFact]
    public void KeyGestureInput_Gesture_Property_Should_Work()
    {
        var keyGestureInput = new UrsaControl.KeyGestureInput();
        
        // Initially null
        Assert.Null(keyGestureInput.Gesture);
        
        // Set a gesture
        var gesture = new KeyGesture(Key.A, KeyModifiers.Control);
        keyGestureInput.Gesture = gesture;
        Assert.Equal(gesture, keyGestureInput.Gesture);
    }
    
    [AvaloniaFact]
    public void KeyGestureInput_AcceptableKeys_Property_Should_Work()
    {
        var keyGestureInput = new UrsaControl.KeyGestureInput();
        
        // Initially null
        Assert.Null(keyGestureInput.AcceptableKeys);
        
        // Set acceptable keys
        var acceptableKeys = new List<Key> { Key.A, Key.B, Key.C };
        keyGestureInput.AcceptableKeys = acceptableKeys;
        Assert.Equal(acceptableKeys, keyGestureInput.AcceptableKeys);
    }
    
    [AvaloniaFact]
    public void KeyGestureInput_ConsiderKeyModifiers_Property_Should_Work()
    {
        var keyGestureInput = new UrsaControl.KeyGestureInput();
        
        // Default should be true
        Assert.True(keyGestureInput.ConsiderKeyModifiers);
        
        // Set to false
        keyGestureInput.ConsiderKeyModifiers = false;
        Assert.False(keyGestureInput.ConsiderKeyModifiers);
    }
    
    [AvaloniaFact]
    public void KeyGestureInput_HorizontalContentAlignment_Property_Should_Work()
    {
        var keyGestureInput = new UrsaControl.KeyGestureInput();
        
        keyGestureInput.HorizontalContentAlignment = HorizontalAlignment.Right;
        Assert.Equal(HorizontalAlignment.Right, keyGestureInput.HorizontalContentAlignment);
    }
    
    [AvaloniaFact]
    public void KeyGestureInput_In_Window_Should_Render()
    {
        var window = new Window();
        var keyGestureInput = new UrsaControl.KeyGestureInput
        {
            Gesture = new KeyGesture(Key.S, KeyModifiers.Control),
            Width = 150,
            Height = 30
        };
        
        window.Content = keyGestureInput;
        window.Show();
        
        Assert.NotNull(keyGestureInput.Gesture);
        Assert.Equal(Key.S, keyGestureInput.Gesture.Key);
        Assert.Equal(KeyModifiers.Control, keyGestureInput.Gesture.KeyModifiers);
    }
    
    [AvaloniaFact]
    public void KeyGestureInput_Focus_Should_Work()
    {
        var window = new Window();
        var keyGestureInput = new UrsaControl.KeyGestureInput();
        
        window.Content = keyGestureInput;
        window.Show();
        
        keyGestureInput.Focus();
        Assert.True(keyGestureInput.IsFocused);
    }
}