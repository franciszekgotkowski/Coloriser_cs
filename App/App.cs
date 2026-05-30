using System.Runtime.CompilerServices;
using Gui;
using Raylib_cs;

namespace Colorister;


public static class App {
    public static void Main(string[] args) {

        Window window = new Window(
                800,
                600,
                60,
                "Ciszarp"
                );

        window.AssignRoot(
            new PlaneLayout()
        );


        AppTheme.Instance.SetTheme(ColorTheme.Kanagawa);

        ColorComunication.Instance.colorList[0] = new Color(20, 100, 40);
        ColorComunication.Instance.colorList[1] =  new Color(170, 200, 130);
        ColorComunication.Instance.colorList[2] = new Color(20, 100, 240);

        EdgesComunication.Instance.colorList[0] = ColorComunication.Instance.colorList[0];
        EdgesComunication.Instance.colorList[1] =  ColorComunication.Instance.colorList[1];
        EdgesComunication.Instance.colorList[2] =  ColorComunication.Instance.colorList[2];
        EdgesComunication.Instance.colorList[3] = Color.Gold;

        window.Loop();
    }
}
