namespace Gui;

public class PlaneLayout : Layout {

    public PlaneLayout(
        Window window
    ) : base (
        new NamedBoxObject("Kolorki")
    ) {

        NamedBoxObject siemabox = (NamedBoxObject)base.uiObject;
        siemabox.AddGuiObject(
            new ColorControllingObject(
                window
            )
        );


        NamedBoxObject tenZSzescianem = new NamedBoxObject(
            "wizualizuje rzut na plaszyzne"
        );


        AssignChildPane(
            new Pane(tenZSzescianem),
            40,
            Direction.RIGHT
        );

        NamedBoxObject tenZeZdieciem = new NamedBoxObject(
            "wyswietlam zdiecie",
            new DisplayImageObject()
        );

        childPane.AssignChildPane(
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


    }
}