namespace Gui;

public class PlaneLayout : Layout {

    public PlaneLayout() : base () {

        NamedBoxObject siemabox = new NamedBoxObject("siema");
        siemabox.AddGuiObject(new ColorControllingObject());
        Pane rootPane = new Pane(
                siemabox
                );


        NamedBoxObject tenZSzescianem = new NamedBoxObject(
                "wizualizuje rzut na plaszyzne"
                );


        rootPane.AssignChildPane(
                new Pane(tenZSzescianem),
                40,
                Direction.RIGHT
                );

        NamedBoxObject tenZeZdieciem = new NamedBoxObject(
                "wyswietlam zdiecie",
                new DisplayImageObject()
                );

        rootPane.childPane.AssignChildPane(
                new Pane(
                    tenZeZdieciem
                    // imageObject
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

        tenZSzescianem.AddGuiObject( vis );


        childPane = rootPane;
        percentOfCanvasForUiObject = 0;
    }
}
