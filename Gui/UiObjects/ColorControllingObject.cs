using Colorister;
using raygui_cs;
using Raylib_cs;

namespace Gui;

public delegate void NewColorEvent();

public class ColorControllingObject : UiObject {
    byte R = 125;
    byte G = 125;
    byte B = 125;

    private string lastPath;
    private string text = "";
    private bool editMode = false;
    private string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    public ColorControllingObject (
        Window window,
        int xPos = 0,
        int yPos = 0,
        int width = 0,
        int height = 0
    ) : base (
        xPos,
        yPos,
        width,
        height
    )  { }

    private void DrawFilepathSelector() {
        UserInterface.DrawBox(
            new IntRect(
                this.coordinates.x + AppTheme.Instance.FontSize/4,
                this.coordinates.y + AppTheme.Instance.FontSize/4,
                this.coordinates.width - AppTheme.Instance.FontSize/2,
                AppTheme.Instance.FontSize * 4
            )
        );
        
        Raylib.DrawText(
            "Filepath:",
            this.coordinates.x + AppTheme.Instance.FontSize,
            this.coordinates.y + AppTheme.Instance.FontSize*3/4,
            AppTheme.Instance.FontSize,
            AppTheme.Instance.Theme.textColor
        );
        
        bool clicked = Raygui.GuiTextBox(
            new Rectangle(
                this.coordinates.x + AppTheme.Instance.FontSize,
                this.coordinates.y + AppTheme.Instance.FontSize*2,
                this.coordinates.width - AppTheme.Instance.FontSize*2,
                AppTheme.Instance.FontSize *3/2
            ),
            ref text,
            64,
            editMode
        );
        if (!text.Equals(lastPath)) {
            lastPath = string.Copy(text);
            ImageCommunication.Instance.FilePath = Path.Combine(home, text);            
        }
        if (clicked) editMode = !editMode;
        
    }

    private void DrawColorSliders(
        int idx
    ) {
        
    }

    public override void Draw() {
        
        DrawFilepathSelector();

        R = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                this.coordinates.x + this.coordinates.width*2/10,
                this.coordinates.y+ this.coordinates.height*5/10,
                this.coordinates.width*6/10,
                AppTheme.Instance.FontSize *3/2
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
                AppTheme.Instance.FontSize *3/2
            ),
            "0",
            "255",
            G,
            0.0f,
            255.0f
        ));
        B = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                this.coordinates.x + this.coordinates.width * 2 / 10,
                this.coordinates.y + this.coordinates.height * 7 / 10,
                this.coordinates.width * 6 / 10,
                AppTheme.Instance.FontSize * 3 / 2
            ),
            "0",
            "255",
            B,
            0.0f,
            255.0f
        ));


        ColorCommunication.Instance.SetColor(0, new Color(R, G, B, Byte.MaxValue));
        EdgesComunication.Instance.SetEgde(0, new Color(R, G, B, Byte.MaxValue));
    }
}