namespace Gui;

using Raylib_cs;

public class IntRect {
    public int X;
    public int Y;
    public int Width;
    public int Height;
    
    public IntRect(
        int X,
        int Y,
        int Width,
        int Height
    ) {
        this.X = X;
        this.Y = Y;
        this.Width = Width;
        this.Height = Height;       
    }
}