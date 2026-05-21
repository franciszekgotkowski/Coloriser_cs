using System.Numerics;
using Raylib_cs;

namespace Gui;

public class EdgesComunication {
    private EdgesComunication() {}

    public static EdgesComunication Instance = new EdgesComunication();

    public Color[] colorList;
}