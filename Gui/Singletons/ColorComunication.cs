using Raylib_cs;

namespace Gui;

public class ColorComunication {
    
    private ColorComunication() {}

    public static ColorComunication Instance = new ColorComunication();

    public List<Color> colorList = new List<Color>();
}