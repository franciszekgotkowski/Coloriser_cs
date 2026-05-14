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
        
        // Counter clockwise lines
        Raylib.DrawLine(
            rect.x,
            rect.y,
            rect.x,
            (rect.y+rect.height),
            AppTheme.Instance.Theme.borderColor
        );
        Raylib.DrawLine(
            rect.x,
            (rect.y+rect.height),
            (rect.x + rect.width),
            (rect.y+rect.height),
            AppTheme.Instance.Theme.borderColor
        );
        Raylib.DrawLine(
            (rect.x + rect.width),
            (rect.y + rect.height),
            (rect.x + rect.width),
            (rect.y),
            AppTheme.Instance.Theme.borderColor
        );
        Raylib.DrawLine(
            (rect.x + rect.width),
            (rect.y),
            (rect.x),
            (rect.y),
            AppTheme.Instance.Theme.borderColor
        );
    }
    
    
    public static void DrawNamedBox(
        IntRect rect,
        string txt
    ) {
        
        Debug.Assert(rect.width > 0.0f);
        Debug.Assert(rect.height > 0.0f);
        Debug.Assert(rect.x > 0.0f);
        Debug.Assert(rect.y > 0.0f);
        
        int textWidth = Raylib.MeasureText(txt, AppTheme.Instance.FontSize);
        int textOffset = 10;
        int textBorder = 10;
        
        // Counter clockwise lines
        Raylib.DrawLine(
            rect.x,
            rect.y,
            rect.x,
            (rect.y+rect.height),
            AppTheme.Instance.Theme.borderColor
        );
        Raylib.DrawLine(
            rect.x,
            (rect.y+rect.height),
            (rect.x + rect.width),
            (rect.y+rect.height),
            AppTheme.Instance.Theme.borderColor
        );
        if (rect.width - (textOffset + textWidth + 2 * textBorder) <= 0) {
            Raylib.DrawLine(
                (rect.x + rect.width),
                (rect.y + rect.height),
                (rect.x + rect.width),
                (rect.y + AppTheme.Instance.FontSize/2),
                AppTheme.Instance.Theme.borderColor
            );
        } else {
            Raylib.DrawLine(
                (rect.x + rect.width),
                (rect.y + rect.height),
                (rect.x + rect.width),
                (rect.y),
            AppTheme.Instance.Theme.borderColor
            );
        }
    
    
        if (rect.width - (textOffset + textWidth + 2 * textBorder) > 0) {
            Raylib.DrawLine(
                (rect.x + rect.width),
                (rect.y),
                (rect.x + textOffset + textWidth + 2 * textBorder),
                (rect.y),
            AppTheme.Instance.Theme.borderColor
            ); 
        }
        Raylib.DrawLine(
            (rect.x + textOffset),
            (rect.y),
            (rect.x),
            (rect.y),
            AppTheme.Instance.Theme.borderColor
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