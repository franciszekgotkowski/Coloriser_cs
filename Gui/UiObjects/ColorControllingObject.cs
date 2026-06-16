using Colorister;
using raygui_cs;
using Raylib_cs;

namespace Gui;

public delegate void NewColorEvent();

public class ColorControllingObject : UiObject {
    // byte R = 125;
    // byte G = 125;
    // byte B = 125;

    ColorInt c0  = new ColorInt(Color.Gold);
    ColorInt c1  = new ColorInt(Color.Beige);
    ColorInt c2  = new ColorInt(Color.Maroon);

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
    
    private void DrawFilepathSelector(
            IntRect rect
            ) {
        UserInterface.DrawBox(
                rect
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
        int height,
        ColorInt colorInt
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
        colorInt.R = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                slider1.x,
                slider1.y,
                slider1.width,
                slider1.height
            ),
            "0",
            "255",
            colorInt.R,
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
        colorInt.G = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                slider2.x,
                slider2.y,
                slider2.width,
                slider2.height
            ),
            "0",
            "255",
            colorInt.G,
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
        colorInt.B = Convert.ToByte(Raygui.GuiSlider(
            new Rectangle(
                slider3.x,
                slider3.y,
                slider3.width,
                slider3.height
            ),
            "0",
            "255",
            colorInt.B,
            0.0f,
            255.0f
        ));


        ColorCommunication.Instance.SetColor(idx, new Color(colorInt.R, colorInt.G, colorInt.B, Byte.MaxValue));
        EdgesComunication.Instance.SetEgde(idx, new Color(colorInt.R, colorInt.G, colorInt.B, Byte.MaxValue));
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

    public void DrawAllSliders (
        IntRect intRect
    ) {

        Raylib.DrawRectangle(
                intRect.x,
                intRect.y,
                intRect.width,
                intRect.height,
                Color.Red
                );

        int slidersHeight = (intRect.height - 2 * AppTheme.Instance.FontSize)/3;

        DrawColorSliders(
                0,
                intRect.y,
                slidersHeight,
                c0
                );

        DrawColorSliders(
                1,
                intRect.y + slidersHeight + AppTheme.Instance.FontSize,
                slidersHeight,
                c1
                );

        DrawColorSliders(
                2,
                intRect.y + 2 *slidersHeight + 2 * AppTheme.Instance.FontSize,
                slidersHeight,
                c2
                );


    }

    public override void Draw() {

        DrawFilepathSelector(
                new IntRect(
                    this.coordinates.x + AppTheme.Instance.FontSize/4,
                    this.coordinates.y + AppTheme.Instance.FontSize/4,
                    this.coordinates.width - AppTheme.Instance.FontSize/2,
                    AppTheme.Instance.FontSize * 4
                    )
                );

        DrawAllSliders(
                new IntRect(
                        this.coordinates.x + AppTheme.Instance.FontSize/4,
                        this.coordinates.y + AppTheme.Instance.FontSize/4 + AppTheme.Instance.FontSize * 5,
                        this.coordinates.width - AppTheme.Instance.FontSize/2,
                        this.coordinates.height - (this.coordinates.y + AppTheme.Instance.FontSize/4 + AppTheme.Instance.FontSize * 7)
                    )
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
