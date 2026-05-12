using System.Runtime.CompilerServices;
using Colorister;

namespace Gui;

public class NamedBoxObject : UiObject {
    string text;
    IntRect canvasCoordinates;
    
    UiObject? guiObject;

    public NamedBoxObject (
        int xPos = 0,
        int yPos = 0,
        int width = 0,
        int height = 0
    ) : base (
        xPos,
        yPos,
        width,
        height
    ) { }
    
    public NamedBoxObject(
        string text
    ) : this() {
        this.text = text;
    }

    public NamedBoxObject(
        string text,
        UiObject guiObject
    ) : base() {
        this.text = text;
        this.guiObject = guiObject;
        this.canvasCoordinates = new IntRect(
            this.coordinates.x + AppTheme.Instance.BorderSize,
            this.coordinates.y + AppTheme.Instance.BorderSize,
            this.coordinates.width - 2 * AppTheme.Instance.BorderSize,
            this.coordinates.height - 2 * AppTheme.Instance.BorderSize
        );
        this.guiObject.Resize(
            this.canvasCoordinates.x,
            this.canvasCoordinates.y,
            this.canvasCoordinates.width,
            this.canvasCoordinates.height
        );
    }

    public override void Resize(
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
        if (this.guiObject != null) {
            this.guiObject.Resize(
                xPos + AppTheme.Instance.BorderSize,
                yPos + AppTheme.Instance.BorderSize,
                width - 2 * AppTheme.Instance.BorderSize,
                height - 2 * AppTheme.Instance.BorderSize
            );
        } 
    }

    public override void Draw(){
        UserInterface.DrawNamedBox(
            this.coordinates,
            this.text
        );
        if (this.guiObject != null) {
            this.guiObject.Draw();
        }
    }
}