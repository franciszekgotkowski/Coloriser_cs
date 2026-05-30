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

    private float calculateScaleFactorForImageTexture() {
        if (
            image == null || 
            image.Value.Width == 0 ||
            image.Value.Height == 0
        ) {
            return 1.0f;
        }

        float scaleX = (float)base.coordinates.width / (float)imageTexture.Width;
        float scaleY = (float)base.coordinates.height / (float)imageTexture.Height;

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

    // private unsafe void ResizeImage() {
    //         if (image == null) return;
    //
    //         float scale = calculateScaleFactorForImage();
    //         Image image1 = image.Value;
    //         Raylib.ImageResize(&image1, (int)(scale*image.Value.Width), (int)(scale*image.Value.Height));
    //         image = image1;
    // }

    private void LoadFreshImage() {
        if (ImageCommunication.Instance.image != null) {
            if (image != null) {
                Raylib.UnloadImage(image.Value);
            }
            image = Raylib.ImageCopy(ImageCommunication.Instance.image.Value);
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
            renderTexture.Resize(
                width,
                height
            );
        }
    }


    public override void Draw()
    {

        renderTexture.Activate();
        Raylib.ClearBackground(
            AppTheme.Instance.Theme.backgroundColor
        );

        if (imageTexture.Id != 0) {
            float scale = calculateScaleFactorForImageTexture();
            float newWidth = imageTexture.Width * scale;
            float newHeight = imageTexture.Height * scale;
            Raylib.DrawTexturePro(
                imageTexture,
                new Rectangle (
                    0.0f,
                    0.0f,
                    imageTexture.Width,
                    imageTexture.Height
                ),
                new Rectangle (
                    0,
                    0,
                    newWidth,
                    newHeight
                ),
                new Vector2(
                    -(coordinates.width - newWidth)/2,
                    -(coordinates.height - newHeight)/2
                ),
                0.0f,
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

        if (image != null)  {
            Raylib.UnloadImage(image.Value);
        }

        ImageCommunication.Instance.onUpdate -= LoadFreshImage;
    }
}