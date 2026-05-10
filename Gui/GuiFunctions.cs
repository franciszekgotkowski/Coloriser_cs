using System.Diagnostics;

namespace Colorister;

using Raylib_cs;

public static class GuiFunctions {
    public static void DrawBox(
        Rectangle rect,
        Color? color = null
    ) {
        Color realColor = Color.Gray;
        if (color != null) {
            realColor = color.Value;
        }
        
        Debug.Assert(rect.Width > 0.0f);
        Debug.Assert(rect.Height > 0.0f);
        Debug.Assert(rect.X > 0.0f);
        Debug.Assert(rect.Y > 0.0f);
        
        // Counter clockwise lines
        Raylib.DrawLine(
            (int)rect.X,
            (int)rect.Y,
            (int)rect.X,
            (int)(rect.Y+rect.Height),
            realColor
        );
        Raylib.DrawLine(
            (int)rect.X,
            (int)(rect.Y+rect.Height),
            (int)(rect.X + rect.Width),
            (int)(rect.Y+rect.Height),
            realColor
        );
        Raylib.DrawLine(
            (int)(rect.X + rect.Width),
            (int)(rect.Y + rect.Height),
            (int)(rect.X + rect.Width),
            (int)(rect.Y),
            realColor
        );
        Raylib.DrawLine(
            (int)(rect.X + rect.Width),
            (int)(rect.Y),
            (int)(rect.X),
            (int)(rect.Y),
            realColor
        );
    }
    

    public static void DrawNamedBox(
        Rectangle rect,
        string txt,
        int fontSize = 20,
        Color? color = null
    ) {
        Color realColor = Color.Gray;
        if (color != null) {
            realColor = color.Value;
        }
        
        Debug.Assert(rect.Width > 0.0f);
        Debug.Assert(rect.Height > 0.0f);
        Debug.Assert(rect.X > 0.0f);
        Debug.Assert(rect.Y > 0.0f);
        Debug.Assert(fontSize > 0.0f);
        
        int textWidth = Raylib.MeasureText(txt, fontSize);
        int textOffset = 10;
        int textBorder = 10;
        
        // Counter clockwise lines
        Raylib.DrawLine(
            (int)rect.X,
            (int)rect.Y,
            (int)rect.X,
            (int)(rect.Y+rect.Height),
            realColor
        );
        Raylib.DrawLine(
            (int)rect.X,
            (int)(rect.Y+rect.Height),
            (int)(rect.X + rect.Width),
            (int)(rect.Y+rect.Height),
            realColor
        );
        if (rect.Width - (textOffset + textWidth + 2 * textBorder) <= 0) {
            Raylib.DrawLine(
                (int)(rect.X + rect.Width),
                (int)(rect.Y + rect.Height),
                (int)(rect.X + rect.Width),
                (int)(rect.Y + fontSize/2),
                realColor
            );
        } else {
            Raylib.DrawLine(
                (int)(rect.X + rect.Width),
                (int)(rect.Y + rect.Height),
                (int)(rect.X + rect.Width),
                (int)(rect.Y),
                realColor
            );
        }


        if (rect.Width - (textOffset + textWidth + 2 * textBorder) > 0) {
            Raylib.DrawLine(
                (int)(rect.X + rect.Width),
                (int)(rect.Y),
                (int)(rect.X + textOffset + textWidth + 2 * textBorder),
                (int)(rect.Y),
                realColor
            ); 
        }
        Raylib.DrawLine(
            (int)(rect.X + textOffset),
            (int)(rect.Y),
            (int)(rect.X),
            (int)(rect.Y),
            realColor
        ); 
        Raylib.DrawText(
            txt,
            (int)rect.X + textOffset + textBorder,
            (int)rect.Y-fontSize/2,
            fontSize,
            realColor
            );
    }
}