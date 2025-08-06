using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.Layout;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.KeyGestureInputTests;

public class KeyGestureInputTests
{
    [AvaloniaFact]
    public void KeyGestureInput_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        
        // Assert
        Assert.Null(keyGestureInput.Gesture);
        Assert.Null(keyGestureInput.AcceptableKeys);
        Assert.True(keyGestureInput.ConsiderKeyModifiers);
        Assert.Equal(HorizontalAlignment.Center, keyGestureInput.HorizontalContentAlignment);
        Assert.Equal(VerticalAlignment.Center, keyGestureInput.VerticalContentAlignment);
        Assert.Null(keyGestureInput.InnerLeftContent);
        Assert.Null(keyGestureInput.InnerRightContent);
        Assert.True(keyGestureInput.Focusable);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Set_Gesture_Property()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        window.Content = keyGestureInput;
        window.Show();

        // Act
        var gesture = new KeyGesture(Key.A, KeyModifiers.Control);
        keyGestureInput.Gesture = gesture;

        // Assert
        Assert.Equal(gesture, keyGestureInput.Gesture);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Update_PseudoClass_When_Gesture_Changes()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        window.Content = keyGestureInput;
        window.Show();

        // Act & Assert - Initially should have :empty
        Assert.Contains(UrsaControls.KeyGestureInput.PC_Empty, keyGestureInput.Classes);

        keyGestureInput.Gesture = new KeyGesture(Key.A);
        Assert.DoesNotContain(UrsaControls.KeyGestureInput.PC_Empty, keyGestureInput.Classes);

        keyGestureInput.Gesture = null;
        Assert.Contains(UrsaControls.KeyGestureInput.PC_Empty, keyGestureInput.Classes);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Set_AcceptableKeys_Property()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        window.Content = keyGestureInput;
        window.Show();

        // Act
        var acceptableKeys = new List<Key> { Key.A, Key.B, Key.C };
        keyGestureInput.AcceptableKeys = acceptableKeys;

        // Assert
        Assert.Equal(acceptableKeys, keyGestureInput.AcceptableKeys);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Set_ConsiderKeyModifiers_Property()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        window.Content = keyGestureInput;
        window.Show();

        // Act & Assert
        keyGestureInput.ConsiderKeyModifiers = false;
        Assert.False(keyGestureInput.ConsiderKeyModifiers);

        keyGestureInput.ConsiderKeyModifiers = true;
        Assert.True(keyGestureInput.ConsiderKeyModifiers);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Set_ContentAlignment_Properties()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        window.Content = keyGestureInput;
        window.Show();

        // Act
        keyGestureInput.HorizontalContentAlignment = HorizontalAlignment.Left;
        keyGestureInput.VerticalContentAlignment = VerticalAlignment.Top;

        // Assert
        Assert.Equal(HorizontalAlignment.Left, keyGestureInput.HorizontalContentAlignment);
        Assert.Equal(VerticalAlignment.Top, keyGestureInput.VerticalContentAlignment);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Set_InnerContent_Properties()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        window.Content = keyGestureInput;
        window.Show();

        // Act
        var leftContent = "Left";
        var rightContent = "Right";
        keyGestureInput.InnerLeftContent = leftContent;
        keyGestureInput.InnerRightContent = rightContent;

        // Assert
        Assert.Equal(leftContent, keyGestureInput.InnerLeftContent);
        Assert.Equal(rightContent, keyGestureInput.InnerRightContent);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Clear_Gesture()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput
        {
            Gesture = new KeyGesture(Key.A, KeyModifiers.Control)
        };
        window.Content = keyGestureInput;
        window.Show();

        // Act
        keyGestureInput.Clear();

        // Assert
        Assert.Null(keyGestureInput.Gesture);
        Assert.Contains(UrsaControls.KeyGestureInput.PC_Empty, keyGestureInput.Classes);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        
        // Act
        window.Content = keyGestureInput;
        window.Show();

        // Assert
        Assert.True(keyGestureInput.IsVisible);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Inherit_From_TemplatedControl()
    {
        // Arrange & Act
        var keyGestureInput = new UrsaControls.KeyGestureInput();

        // Assert
        Assert.IsAssignableFrom<TemplatedControl>(keyGestureInput);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Implement_IClearControl()
    {
        // Arrange & Act
        var keyGestureInput = new UrsaControls.KeyGestureInput();

        // Assert
        Assert.IsAssignableFrom<Irihi.Avalonia.Shared.Contracts.IClearControl>(keyGestureInput);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Handle_Null_AcceptableKeys()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput
        {
            AcceptableKeys = new List<Key> { Key.A, Key.B }
        };
        window.Content = keyGestureInput;
        window.Show();

        // Act
        keyGestureInput.AcceptableKeys = null;

        // Assert
        Assert.Null(keyGestureInput.AcceptableKeys);
    }

    [AvaloniaFact]
    public void KeyGestureInput_Should_Handle_Empty_AcceptableKeys()
    {
        // Arrange
        var window = new Window();
        var keyGestureInput = new UrsaControls.KeyGestureInput();
        window.Content = keyGestureInput;
        window.Show();

        // Act
        var emptyKeys = new List<Key>();
        keyGestureInput.AcceptableKeys = emptyKeys;

        // Assert
        Assert.Equal(emptyKeys, keyGestureInput.AcceptableKeys);
        Assert.Empty(keyGestureInput.AcceptableKeys);
    }
}