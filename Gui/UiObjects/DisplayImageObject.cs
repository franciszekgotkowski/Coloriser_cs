using System.Numerics;
using Raylib_cs;

namespace Gui;

public delegate void DisplayImageEvent();

public class DisplayImageObject : UiObject {
    private RenderTexture renderTexture;
    private Texture2D imageTexture;

    public DisplayImageObject() {
        renderTexture = new RenderTexture(
            base.coordinates.width,
            base.coordinates.height
        );

        if (ImageCommunication.Instance.image != null) {
            imageTexture = Raylib.LoadTextureFromImage(
                ImageCommunication.Instance.image.Value
            );
        }

    }

    public override void Resize(
        int xPos,
        int yPos,
        int width,
        int height
    ) {
        base.Resize(xPos, yPos, width, height);
        if (renderTexture != null) {
            this.renderTexture.Resize(
                width,
                height
            );
        }

        
    }


    public override void Draw()
    {
        if (ImageCommunication.Instance.modified)
        {
            if (ImageCommunication.Instance.image != null)
            {
                if (imageTexture.Id != 0) {
                    Raylib.UnloadTexture(imageTexture);
                }
                imageTexture = Raylib.LoadTextureFromImage(
                    ImageCommunication.Instance.image.Value
                );
            }

            ImageCommunication.Instance.modified = false;
        }

        renderTexture.Activate();
        Raylib.ClearBackground(AppTheme.Instance.Theme.backgroundColor);

        if (imageTexture.Id != 0) {
            Raylib.DrawTexture(
                imageTexture,
                (coordinates.width - imageTexture.Width)/2,
                (coordinates.height - imageTexture.Height)/2,
                Color.White
            );
        }
        // Raylib.DrawCircle(renderTexture.width/2, renderTexture.height/2-100, 15.0f, Color.Re);

        renderTexture.Deactivate();

        Raylib.DrawTextureRec(
            renderTexture.renderTexture.Texture,
            new Rectangle(
                0.0f,
                0.0f,
                coordinates.width,
                -coordinates.height
            ),
            new Vector2(
                base.coordinates.x,
                base.coordinates.y
            ),
            Color.White
        );
    }

    ~DisplayImageObject() {
        if (this.imageTexture.Id != 0) {
            Raylib.UnloadTexture(this.imageTexture);
        }
    }
}
