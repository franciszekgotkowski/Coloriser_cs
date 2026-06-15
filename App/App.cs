using Gui;
using Raylib_cs;

namespace Colorister;


public static class App {
    public static void Main(string[] args) {

        Window window = new Window(
                1400,
                900,
                60,
                "Ciszarp"
                );

        window.SetLayout(
            new PlaneLayout(
                window
                )
        );


        AppTheme.Instance.SetTheme(ColorTheme.Kanagawa);

        ColorCommunication.Instance.colorList[0] = new Color(20, 100, 40);
        ColorCommunication.Instance.colorList[1] =  new Color(170, 200, 130);
        ColorCommunication.Instance.colorList[2] = new Color(20, 100, 240);

        EdgesComunication.Instance.colorList[0] = ColorCommunication.Instance.colorList[0];
        EdgesComunication.Instance.colorList[1] =  ColorCommunication.Instance.colorList[1];
        EdgesComunication.Instance.colorList[2] =  ColorCommunication.Instance.colorList[2];
        EdgesComunication.Instance.colorList[3] = Color.Gold;

        window.Loop();
    }
}
