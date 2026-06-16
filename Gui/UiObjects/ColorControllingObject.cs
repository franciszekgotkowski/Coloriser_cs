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

    private bool lastToggleState = true;
    bool toggleState = true;
    private void DrawSeeDefaultImageButton(
        IntRect intRect
    ) {
        toggleState = Raygui.GuiCheckBox(
            new Rectangle(
                intRect.x,
                intRect.y,
                intRect.width,
                intRect.height
            ),
            "",
            lastToggleState
        );
        
        if (toggleState && !lastToggleState) {
            ImageCommunication.Instance.TriggerImageChange(WhichImageToDraw.coloredImage);
            Console.WriteLine("Clicked");
        }
        if (!toggleState && lastToggleState ) {
            ImageCommunication.Instance.TriggerImageChange(WhichImageToDraw.baseImage);
            Console.WriteLine("Unclicked");
        }
        
        lastToggleState = toggleState;
    }

    private void DrawColorSliders(
        int idx,
        int y,
        int height
    ) {
        IntRect slider1 = new IntRect(
            this.coordinates.x + coordinates.width * 20 / 100,
            y,
            this.coordinates.width * 6 / 10,
            height*2/8
        );
        IntRect slider2 = new IntRect(
            this.coordinates.x + coordinates.width * 20 / 100,
            y + height*3/8,
            this.coordinates.width * 6 / 10,
            height*2/8
        );
        IntRect slider3 = new IntRect(
            this.coordinates.x + coordinates.width * 20 / 100,
            y + height*6/8,
            this.coordinates.width * 6 / 10,
            height*2/8
        );
        
        Raylib.DrawText(
            "R",
            this.coordinates.x + coordinates.width * 5 / 100,
            slider1.y,
            AppTheme.Instance.FontSize,
            Color.Red
        );
        R = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                slider1.x,
                slider1.y,
                slider1.width,
                slider1.height
            ),
            "0",
            "255",
            R,
            0.0f,
            255.0f
        ));
        Raylib.DrawText(
            "G",
            this.coordinates.x + coordinates.width * 5 / 100,
            slider2.y,
            AppTheme.Instance.FontSize,
            Color.Green
        );
        G = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                slider2.x,
                slider2.y,
                slider2.width,
                slider2.height
            ),
            "0",
            "255",
            G,
            0.0f,
            255.0f
        ));
        Raylib.DrawText(
            "B",
            this.coordinates.x + coordinates.width * 5 / 100,
            slider3.y,
            AppTheme.Instance.FontSize,
            Color.Blue
        );
        B = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                slider3.x,
                slider3.y,
                slider3.width,
                slider3.height
            ),
            "0",
            "255",
            B,
            0.0f,
            255.0f
        ));


        ColorCommunication.Instance.SetColor(idx, new Color(R, G, B, Byte.MaxValue));
        EdgesComunication.Instance.SetEgde(idx, new Color(R, G, B, Byte.MaxValue));
    }

    private void DrawSaveImageButton(
        IntRect intRect
    ) {

        Rectangle rect = new Rectangle(
            intRect.x,
            intRect.y,
            intRect.width,
            intRect.height
        );
        
        if (ImageCommunication.Instance.image == null) {
            Raygui.GuiDisable();
            Raygui.GuiButton(rect, "");
            Raygui.GuiEnable();
        }
        else {
            string newFileWithPath = FilePathMethods.NewFileWithPath(ImageCommunication.Instance.FilePath);
            string newFileWithoutPath = FilePathMethods.NewFileWithoutPath(ImageCommunication.Instance.FilePath);
            
            int pressed = Raygui.GuiButton(
                rect,
                newFileWithoutPath
            );
            if (pressed != 0) {
                ImageCommunication.Instance.TriggerSaveImage(newFileWithPath);
            }
        }
        
    }

    public override void Draw() {
        
        DrawFilepathSelector();
        DrawColorSliders(
            0,
            this.coordinates.y + this.coordinates.height *4/10,
            this.coordinates.height * 2/10
        );
        DrawSeeDefaultImageButton(
            new IntRect(
                coordinates.x + AppTheme.Instance.BorderSize,
                coordinates.y + coordinates.height -  AppTheme.Instance.FontSize*2,
                AppTheme.Instance.FontSize*2,
                AppTheme.Instance.FontSize*2
            )
        );
        DrawSaveImageButton(
            new IntRect(
                coordinates.x + AppTheme.Instance.BorderSize * 2 + AppTheme.Instance.FontSize*2,
                coordinates.y + coordinates.height -  AppTheme.Instance.FontSize*2,
                coordinates.width - AppTheme.Instance.BorderSize*3 - AppTheme.Instance.FontSize*2,
                AppTheme.Instance.FontSize*2
            )
        );

    }
}