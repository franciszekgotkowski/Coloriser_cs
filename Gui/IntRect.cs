namespace Gui;

using Raylib_cs;

public class IntRect {
    public int x;
    public int y;
    public int width;
    public int height;
    
    public IntRect(
        int x,
        int y,
        int width,
        int height

    ) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;       
    }
    
    public IntRect(){}

    public bool Inside(
        int x,
        int y
    ) {
        if (
            x >= this.x && x <= this.x + this.width &&
            y >= this.y && y <= this.y + this.height
        ) {
            return true;
        } else {
            return false;
        }
    }

    public override string ToString() {
        return $"X: {this.x}, Y: {this.y}, Width: {this.width}, Height: {this.height}";
    }
}