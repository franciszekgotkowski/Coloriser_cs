using System.Numerics;

namespace Gui;

public abstract class UiObject {
    public IntRect coordinates;

    public UiObject(
        int xPos = 0,
        int yPos = 0,
        int width = 0,
        int height = 0
    ) {
        this.Resize(
            xPos,
            yPos,
            width,
            height
        );
    }

    public virtual void Resize(
        int xPos,
        int yPos,
        int width,
        int height
    ) {
        this.coordinates = new IntRect(
            xPos,
            yPos,
            width, 
            height
        );
    }

    public abstract void Draw();
}