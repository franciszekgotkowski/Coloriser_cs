using System.Diagnostics;
using Gui;

namespace Colorister;

using Raylib_cs;

public static class UserInterface {
    
    public static void DrawBox(
        IntRect rect
    ) {
        Debug.Assert(rect.width > 0);
        Debug.Assert(rect.height > 0);
        Debug.Assert(rect.x > 0);
        Debug.Assert(rect.y > 0);
        
        Raylib.DrawRectangle(
            rect.x,
            rect.y,
            rect.width,
            rect.height,
            AppTheme.Instance.Theme.borderColor
        );
        Raylib.DrawRectangle(
            rect.x + AppTheme.Instance.LineWidth,
            rect.y+ AppTheme.Instance.LineWidth,
            rect.width - 2*AppTheme.Instance.LineWidth,
            rect.height - 2*AppTheme.Instance.LineWidth,
            AppTheme.Instance.Theme.backgroundColor
        );
    }
    
    public static void DrawNamedBox(
        IntRect rect,
        string txt
    ) {
        int textWidth = Raylib.MeasureText(txt, AppTheme.Instance.FontSize);
        int textOffset = AppTheme.Instance.BorderSize;
        int textBorder = AppTheme.Instance.BorderSize;
        
        Raylib.DrawRectangle(
            rect.x,
            rect.y,
            rect.width,
            rect.height,
            AppTheme.Instance.Theme.borderColor
        );
        Raylib.DrawRectangle(
            rect.x + AppTheme.Instance.LineWidth,
            rect.y+ AppTheme.Instance.LineWidth,
            rect.width - 2*AppTheme.Instance.LineWidth,
            rect.height - 2*AppTheme.Instance.LineWidth,
            AppTheme.Instance.Theme.backgroundColor
        );
        
        Raylib.DrawRectangle(
            rect.x + textOffset,
            rect.y,
            textWidth + 2 * textBorder,
            AppTheme.Instance.FontSize,
            AppTheme.Instance.Theme.backgroundColor
            
        );
    
        Raylib.DrawText(
            txt,
            rect.x + textOffset + textBorder,
            rect.y-AppTheme.Instance.FontSize/2,
            AppTheme.Instance.FontSize,
            AppTheme.Instance.Theme.textColor
        );
    }


}