using System.Numerics;
using Raylib_cs;

namespace Gui;

public delegate void DisplayImageEvent();

public class DisplayImageObject : UiObject {
    private Image? image;
    private Texture2D imageTexture;
    private RenderTexture renderTexture;

    private int oldWidth;
    private int oldHeight;

    public DisplayImageObject() {
        renderTexture = new RenderTexture(
                base.coordinates.width,
                base.coordinates.height
                );

        ImageCommunication.Instance.onUpdate += LoadFreshImage;
    }

    private void UpdateTexture() {
        if (image != null) {
            if (imageTexture.Id != 0) {
                Raylib.UnloadTexture(imageTexture);
            }
            imageTexture = Raylib.LoadTextureFromImage(
                image.Value
            );
        }
    }

    private float calculateScaleFactorForImage() {
        if (
                image == null || 
                image.Value.Width == 0 ||
                image.Value.Height == 0
            ) {
            return 1.0f;
        }

        float scaleX = (float)base.coordinates.width / (float)image.Value.Width;
        float scaleY = (float)base.coordinates.height / (float)image.Value.Height;

        if (scaleX > 1.0f || scaleY > 1.0f) {
            if (scaleX > scaleY) {
                return scaleY;
            } else {
                return scaleX;
            }
        } else {
            if (scaleX < scaleY) {
                return scaleX;
            } else {
                return scaleY;
            }
        }
    }

    private unsafe void ResizeImage() {
            if (image == null) return;

            float scale = calculateScaleFactorForImage();
            Image image1 = image.Value;
            Raylib.ImageResize(&image1, (int)(scale*image.Value.Width), (int)(scale*image.Value.Height));
            image = image1;
    }

    private void LoadFreshImage() {
        if (ImageCommunication.Instance.image != null) {
            image = Raylib.ImageCopy(ImageCommunication.Instance.image.Value);
            ResizeImage();
        }
        UpdateTexture();
    }

    public override void Resize(
            int xPos,
            int yPos,
            int width,
            int height
            ) {

        if (base.coordinates != null) {
            oldWidth = base.coordinates.width;
            oldHeight = base.coordinates.height;
        }
        
        base.Resize(xPos, yPos, width, height);
        if (renderTexture != null) {
            this.renderTexture.Resize(
                    width,
                    height
                    );
        }

        if (
                (renderTexture != null &&
                 imageTexture.Id != 0)
                &&
                (oldWidth != base.coordinates.width ||
                 oldHeight != base.coordinates.height)
            ) {
            LoadFreshImage();
        }

    }


    public override void Draw()
    {

        renderTexture.Activate();
        Raylib.ClearBackground(
                // AppTheme.Instance.Theme.backgroundColor
                Color.Red
                );

        if (imageTexture.Id != 0) {
            Raylib.DrawTexture(
                    imageTexture,
                    (coordinates.width - imageTexture.Width)/2,
                    (coordinates.height - imageTexture.Height)/2,
                    Color.White
                    );
        }

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
