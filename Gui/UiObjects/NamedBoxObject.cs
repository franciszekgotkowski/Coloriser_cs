using System.Runtime.CompilerServices;
using Colorister;

namespace Gui;

public class NamedBoxObject : UiObject {
    string text;

    IntRect canvasCoordinates {
        get {
            return new IntRect(
                base.coordinates.x + AppTheme.Instance.BorderSize,
                base.coordinates.y - AppTheme.Instance.BorderSize + AppTheme.Instance.FontSize,
                base.coordinates.width - 2 * AppTheme.Instance.BorderSize,
                base.coordinates.height - 2 * AppTheme.Instance.BorderSize - AppTheme.Instance.FontSize
            );
        }
    }
    
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
        this.AddGuiObject(
            guiObject
        );
    }

    public void AddGuiObject(
        UiObject uiObject
    ) {
        this.guiObject = uiObject;
        if (this.guiObject != null) {
            
            this.guiObject.Resize(
                this.canvasCoordinates.x,
                this.canvasCoordinates.y,
                this.canvasCoordinates.width,
                this.canvasCoordinates.height
            );
        }
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
                canvasCoordinates.x,
                canvasCoordinates.y,
                canvasCoordinates.width,
                canvasCoordinates.height
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
