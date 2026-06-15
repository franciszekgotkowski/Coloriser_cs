using Raylib_cs;

namespace Gui;

public class ColorCommunication {

    private ColorCommunication() {}

    public static ColorCommunication Instance = new ColorCommunication();

    public event NewColorEvent onUpdate;

    public Color[] colorList {
        get;
        private set;
    }

    public void InitializeList(int i) {
        this.colorList = new Color[i];
    }

    public void SetColor(
        int i,
        Color c
    ) {
        bool b = false;
        if (colorList != null && colorList.Count() > i) {
            if (c.Equals(colorList[i]) == false) b = true;
            colorList[i] = c;
        }
        if (b == true) onUpdate?.Invoke();
    }
}