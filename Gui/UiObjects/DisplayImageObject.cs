using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

namespace Gui;

public delegate void DisplayImageEvent();

public class DisplayImageObject : UiObject {
    private Image? baseImage;
    private Image? drawnImage;
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
        ColorCommunication.Instance.onUpdate += MakeNewColoredImage;
    }

    private void UpdateTexture() {
        if (drawnImage != null) {
            if (imageTexture.Id != 0) {
                Raylib.UnloadTexture(imageTexture);
            }
            imageTexture = Raylib.LoadTextureFromImage(
                drawnImage.Value
            );
        }
    }

    private float calculateScaleFactorForImageTexture() {
        if (
            baseImage == null ||
            baseImage.Value.Width == 0 ||
            baseImage.Value.Height == 0
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

    private void MakeNewColoredImage() {
        if (drawnImage != null) {
            Raylib.UnloadImage(drawnImage.Value);
        }
        Debug.Assert(baseImage != null);
        drawnImage = Raylib.ImageCopy(baseImage.Value);

        unsafe
        {
            byte* data = (byte*)drawnImage.Value.Data;

            if (drawnImage.Value.Format == PixelFormat.UncompressedR8G8B8A8) {
                for (int i = 0; i < drawnImage.Value.Width * drawnImage.Value.Height; i++) {

                    ColorInt currentColor = new ColorInt(
                        (int)data[4 * i] + 0,
                        (int)data[4 * i] + 1,
                        (int)data[4 * i] + 2
                    );

                    Color projectedColor = currentColor.Project(
                        ColorCommunication.Instance.colorList[0],
                        ColorCommunication.Instance.colorList[1],
                        ColorCommunication.Instance.colorList[2]
                    );

                    data[4 * i + 0] = projectedColor.R;
                    data[4 * i + 1] = projectedColor.G;
                    data[4 * i + 2] = projectedColor.B;
                    // data[4 * i + 3] = byte.MaxValue;
                }
            } else if (drawnImage.Value.Format == PixelFormat.UncompressedR8G8B8) {
                    for (int i = 0; i < drawnImage.Value.Width * drawnImage.Value.Height; i++) {

                        ColorInt currentColor = new ColorInt(
                            (int)data[3 * i] + 0,
                            (int)data[3 * i] + 1,
                            (int)data[3 * i] + 2
                        );

                        Color projectedColor = currentColor.Project(
                            ColorCommunication.Instance.colorList[0],
                            ColorCommunication.Instance.colorList[1],
                            ColorCommunication.Instance.colorList[2]
                        );

                        data[3 * i + 0] = projectedColor.R;
                        data[3 * i + 1] = projectedColor.G;
                        data[3 * i + 2] = projectedColor.B;
                    }
                }
            else {
                Console.WriteLine("Unsupported Pixel format!");
            }
            } 

        UpdateTexture();
    }

    private void LoadFreshImage() {
        if (ImageCommunication.Instance.image != null) {
            if (baseImage != null) {
                Raylib.UnloadImage(baseImage.Value);
            }
            baseImage = Raylib.ImageCopy(ImageCommunication.Instance.image.Value);
            if (drawnImage != null) {
                Raylib.UnloadImage(drawnImage.Value);
            }
            drawnImage = Raylib.ImageCopy(baseImage.Value);
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

        if (baseImage != null)  {
            Raylib.UnloadImage(baseImage.Value);
        }
        if (drawnImage != null)  {
            Raylib.UnloadImage(drawnImage.Value);
        }

        ImageCommunication.Instance.onUpdate -= LoadFreshImage;
        ColorCommunication.Instance.onUpdate -= MakeNewColoredImage;
    }
}