using raygui_cs;
using Raylib_cs;

namespace Gui;

public class ColorControllingObject : UiObject {
    byte R = 125;
    byte G = 125;
    byte B = 125;
    public override void Draw() {


        R = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                this.coordinates.x + this.coordinates.width*2/10,
                this.coordinates.y+ this.coordinates.width*2/10,
                this.coordinates.width*6/10,
                20
            ),
            "0",
            "255",
            R,
            0.0f,
            255.0f
        ));
        G = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                this.coordinates.x + this.coordinates.width*2/10,
                this.coordinates.y+ this.coordinates.width*3/10,
                this.coordinates.width*6/10,
                20
            ),
            "0",
            "255",
            G,
            0.0f,
            255.0f
        ));
        B = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                this.coordinates.x + this.coordinates.width*2/10,
                this.coordinates.y+ this.coordinates.width*4/10,
                this.coordinates.width*6/10,
                20
            ),
            "0",
            "255",
            B,
            0.0f,
            255.0f
        ));

        ColorComunication.Instance.colorList[0] = new Color(R, G, B, Byte.MaxValue);
        EdgesComunication.Instance.colorList[0] = new Color(R, G, B, Byte.MaxValue);
    }
}