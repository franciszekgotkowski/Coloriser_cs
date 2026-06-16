using Raylib_cs;

namespace Gui;



public class ImageCommunication
{
    private ImageCommunication() { }

    public static ImageCommunication Instance = new ImageCommunication();

    public event DisplayImageEvent onUpdate;
    public event ChangeDisplayedImage changeDisplayedImage;

    public event SaveImage SaveImageToDisk;

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

            image = Raylib.LoadImage(_FilePath);
            if (!image.HasValue) {
                image = null;
            }

            onUpdate?.Invoke();
            Console.WriteLine(FilePathMethods.NewFileWithPath(_FilePath));
        }
    }

    public void TriggerImageChange(WhichImageToDraw whichImageToDraw) {
        this.changeDisplayedImage?.Invoke(whichImageToDraw);
    }

    public void TriggerSaveImage(string path) {
        this.SaveImageToDisk?.Invoke(path);
    }

    public Image? image;

    ~ImageCommunication() {
        if (image != null) {
            Raylib.UnloadImage(image.Value);
        }
    }

}
