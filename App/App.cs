using System.Runtime.CompilerServices;
using Gui;
using Raylib_cs;

namespace Colorister;

public static class App {
    public static void Main(string[] args) {

        NamedBoxObject siemabox = new NamedBoxObject("siema");
        siemabox.AddGuiObject(new ColorControllingObject());
        Pane rootPane = new Pane(
                siemabox
                );

        Window window = new Window(
                800,
                600,
                60,
                "Ciszarp",
                rootPane
                );

        NamedBoxObject tenZTextura = new NamedBoxObject("mam render texture w sobie");


        rootPane.AssignChildPane(
                new Pane(tenZTextura),
                40,
                Direction.RIGHT
                );

        DisplayImageObject imageObject = new DisplayImageObject();

        rootPane.childPane.AssignChildPane(
                new Pane(
                    imageObject
                    // new ButtonObject(
                    // 	"Jestem trzeci!"
                    // )
                    ),
                50,
                Direction.DOWN
                );


        Visualisation3DObject vis = new Visualisation3DObject();
        PlaneScene plane = new PlaneScene(
                vis.camera,
                vis.renderTexture
                );
        vis.AddScene3D(plane);

        tenZTextura.AddGuiObject( vis );
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
