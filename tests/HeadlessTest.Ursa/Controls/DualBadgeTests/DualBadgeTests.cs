using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Headless.XUnit;
using Avalonia.Media;
using UrsaControls = Ursa.Controls;

namespace HeadlessTest.Ursa.Controls.DualBadgeTests;

public class DualBadgeTests
{
    [AvaloniaFact]
    public void DualBadge_Should_Initialize_With_Default_Values()
    {
        // Arrange & Act
        var dualBadge = new UrsaControls.DualBadge();
        
        // Assert
        Assert.Null(dualBadge.Icon);
        Assert.Null(dualBadge.Header);
        Assert.Null(dualBadge.Content);
        Assert.Null(dualBadge.IconTemplate);
        Assert.Null(dualBadge.IconForeground);
        Assert.Null(dualBadge.HeaderForeground);
        Assert.Null(dualBadge.HeaderBackground);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Set_Icon_Property()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act
        var icon = "TestIcon";
        dualBadge.Icon = icon;

        // Assert
        Assert.Equal(icon, dualBadge.Icon);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Set_Header_Property()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act
        var header = "Test Header";
        dualBadge.Header = header;

        // Assert
        Assert.Equal(header, dualBadge.Header);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Set_Content_Property()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act
        var content = "Test Content";
        dualBadge.Content = content;

        // Assert
        Assert.Equal(content, dualBadge.Content);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Update_PseudoClasses_When_Icon_Changes()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act & Assert - Initially should have :icon-empty
        Assert.Contains(UrsaControls.DualBadge.PC_IconEmpty, dualBadge.Classes);

        dualBadge.Icon = "Test Icon";
        Assert.DoesNotContain(UrsaControls.DualBadge.PC_IconEmpty, dualBadge.Classes);

        dualBadge.Icon = null;
        Assert.Contains(UrsaControls.DualBadge.PC_IconEmpty, dualBadge.Classes);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Update_PseudoClasses_When_Header_Changes()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act & Assert - Initially should have :header-empty
        Assert.Contains(UrsaControls.DualBadge.PC_HeaderEmpty, dualBadge.Classes);

        dualBadge.Header = "Test Header";
        Assert.DoesNotContain(UrsaControls.DualBadge.PC_HeaderEmpty, dualBadge.Classes);

        dualBadge.Header = null;
        Assert.Contains(UrsaControls.DualBadge.PC_HeaderEmpty, dualBadge.Classes);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Update_PseudoClasses_When_Content_Changes()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act & Assert - Initially should have :content-empty
        Assert.Contains(UrsaControls.DualBadge.PC_ContentEmpty, dualBadge.Classes);

        dualBadge.Content = "Test Content";
        Assert.DoesNotContain(UrsaControls.DualBadge.PC_ContentEmpty, dualBadge.Classes);

        dualBadge.Content = null;
        Assert.Contains(UrsaControls.DualBadge.PC_ContentEmpty, dualBadge.Classes);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Set_Foreground_Properties()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act
        var iconBrush = Brushes.Red;
        var headerBrush = Brushes.Blue;
        dualBadge.IconForeground = iconBrush;
        dualBadge.HeaderForeground = headerBrush;

        // Assert
        Assert.Equal(iconBrush, dualBadge.IconForeground);
        Assert.Equal(headerBrush, dualBadge.HeaderForeground);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Set_HeaderBackground_Property()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act
        var backgroundBrush = Brushes.Green;
        dualBadge.HeaderBackground = backgroundBrush;

        // Assert
        Assert.Equal(backgroundBrush, dualBadge.HeaderBackground);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Be_Visible_When_Added_To_Window()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        
        // Act
        window.Content = dualBadge;
        window.Show();

        // Assert
        Assert.True(dualBadge.IsVisible);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Inherit_From_HeaderedContentControl()
    {
        // Arrange & Act
        var dualBadge = new UrsaControls.DualBadge();

        // Assert
        Assert.IsAssignableFrom<HeaderedContentControl>(dualBadge);
    }

    [AvaloniaFact]
    public void DualBadge_Should_Handle_Complex_Content()
    {
        // Arrange
        var window = new Window();
        var dualBadge = new UrsaControls.DualBadge();
        window.Content = dualBadge;
        window.Show();

        // Act
        var button = new Button { Content = "Button Content" };
        var textBlock = new TextBlock { Text = "Text Block Header" };
        
        dualBadge.Icon = button;
        dualBadge.Header = textBlock;
        dualBadge.Content = new TextBox { Text = "TextBox Content" };

        // Assert
        Assert.Equal(button, dualBadge.Icon);
        Assert.Equal(textBlock, dualBadge.Header);
        Assert.IsType<TextBox>(dualBadge.Content);
    }
}