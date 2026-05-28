using System.Runtime.CompilerServices;
using Raylib_cs;

namespace Gui;

public class ImageCommunication {
    
    private ImageCommunication() {}

    public static ImageCommunication Instance = new ImageCommunication();

    public string FilePath {
        set {
            this.FilePath = value;

            if (this.image.Data != ) {
                Raylib.UnloadImage(image);
                Raylib.UnloadTexture(imageTexture);
            }

            this.image = Raylib.LoadImage(value);
        }
    }

    public Image image;
    public Texture2D imageTexture;


}