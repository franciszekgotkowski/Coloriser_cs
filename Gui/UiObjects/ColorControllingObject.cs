using raygui_cs;
using Raylib_cs;

namespace Gui;

public class ColorControllingObject : UiObject {
    byte R = 125;
    byte G = 125;
    byte B = 125;

    string lastPath;

    string text = "";
    bool editMode = false;

    string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    public override void Draw() {

        bool clicked = Raygui.GuiTextBox(
                // new Rectangle (
                //     100, 100, 200, 30
                //     ),
                new Rectangle(
                    this.coordinates.x + this.coordinates.width*2/10,
                    this.coordinates.y+ this.coordinates.height*2/10,
                    this.coordinates.width*6/10,
                    AppTheme.Instance.FontSize *3/2
                    ), 
                ref text, 
                64, 
                editMode
                );

        if (!text.Equals(lastPath)) {
            lastPath = string.Copy(text);
            ImageCommunication.Instance.FilePath = Path.Combine(home, text);            Console.WriteLine("nowa sciezka!");
        }

        if (
            clicked
           ) {
            editMode = !editMode;
        }


        R = Convert.ToByte(Raygui.GuiSlider(
                    new Rectangle(
                        this.coordinates.x + this.coordinates.width*2/10,
                        this.coordinates.y+ this.coordinates.height*5/10,
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
                        this.coordinates.y+ this.coordinates.height*6/10,
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
                        this.coordinates.y+ this.coordinates.height*7/10,
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
