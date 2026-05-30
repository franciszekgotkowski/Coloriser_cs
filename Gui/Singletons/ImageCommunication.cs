using Raylib_cs;

namespace Gui;



public class ImageCommunication
{

    private ImageCommunication() { }

    public static ImageCommunication Instance = new ImageCommunication();

    public bool modified = false;
    public event DisplayImageEvent onUpdate;

    private string _FilePath;
    public string FilePath {
        get {
            return _FilePath;
        }
        set {
            _FilePath = value;
            if (image != null) {
                Raylib.UnloadImage(image.Value);
            }

            modified = true;
            image = Raylib.LoadImage(_FilePath);
            if (!image.HasValue) {
                image = null;
            }

            onUpdate?.Invoke();

        }
    }

    public Image? image;

    ~ImageCommunication() {
        if (image != null) {
            Raylib.UnloadImage(image.Value);
        }
    }

}
