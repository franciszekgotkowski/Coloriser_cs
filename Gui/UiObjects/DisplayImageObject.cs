using Raylib_cs;

namespace Gui;

public class DisplayImageObject : UiObject {
    private RenderTexture renderTexture;

    public override void Resize(
        int xPos, 
        int yPos, 
        int width, 
        int height
    ) {
        base.Resize(xPos, yPos, width, height);
        this.renderTexture.Resize(
            width,
            height
        );
    }

    public DisplayImageObject() {
        if (ImageCommunication.Instance.image == null) {
            renderTexture = new RenderTexture(0, 0);
        }
        else {
            renderTexture = new RenderTexture(
                ImageCommunication.Instance.image.Value.Width,
                ImageCommunication.Instance.image.Value.Height
            );
        }
    }

    public override void Draw() {
        renderTexture.Activate();
        Raylib.ClearBackground(AppTheme.Instance.Theme.backgroundColor);
        
        
        renderTexture.Deactivate();
    }
}