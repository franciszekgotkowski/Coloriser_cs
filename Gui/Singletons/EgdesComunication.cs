using System.Numerics;
using Raylib_cs;

namespace Gui;

public class EdgesComunication {
    private EdgesComunication() {}

    public static EdgesComunication Instance = new EdgesComunication();

    public Color[] colorList {
        get;
        private set;
    }
    
    public void SetEgde(
        int i,
        Color c
    ) {
        if (colorList != null && colorList.Count() > i) {
            colorList[i] = c;
        }
    }
    
    public void InitializeList(int i) {
        this.colorList = new Color[i];
    }
}