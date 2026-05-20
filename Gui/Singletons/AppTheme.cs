using Raylib_cs;

namespace Gui;

public class AppTheme {

    private AppTheme() {}

    public static readonly AppTheme Instance = new AppTheme();

    public ColorTheme Theme {
        get;
        private set;
    } = ColorTheme.LightBlue;
    public void SetTheme(
        ColorTheme theme
    ) {
        this.Theme = theme;
    }

    public int FontSize {
        get;
        private set;
    } = 20;
    public void SetFontSize(
        int size
    ) {
        this.FontSize = size;
    }

    public int BorderSize {
        get;
        private set;
    } = 20;
    public void SetBorderSize(
        int size
    ) {
        this.BorderSize = size;
    }
    
    
}