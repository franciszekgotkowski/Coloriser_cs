namespace Gui;

using Raylib_cs;

public class ColorTheme {

    public Color backgroundColor;
    
    public Color borderColor;
    public Color fillInColor;
    public Color textColor;
    
    public Color hoverBorderColor;
    public Color hoverFillInColor;
    public Color hoverTextColor;
    
    public Color clickedBorderColor;
    public Color clickedFillInColor;
    public Color clickedTextColor;

    public ColorTheme(
        Color backgroundColor,
        
        Color borderColor,
        Color fillInColor,
        Color textColor,
        
        Color hoverBorderColor,
        Color hoverFillInColor,
        Color hoverTextColor,
        
        Color clickedBorderColor,
        Color clickedFillInColor,
        Color clickedTextColor
        
    ) {
        this.backgroundColor = backgroundColor;
        this.borderColor = borderColor;
        this.fillInColor = fillInColor;
        this.textColor = textColor;
        
        this.hoverBorderColor = hoverBorderColor;
        this.hoverFillInColor = hoverFillInColor;
        this.hoverTextColor = hoverTextColor;
        
        this.clickedBorderColor = clickedBorderColor;
        this.clickedFillInColor = clickedFillInColor;
        this.clickedTextColor = clickedTextColor;
    }

    public static readonly ColorTheme LightBlue = new ColorTheme(
        Color.White,
        Color.Gray,
        Color.LightGray,
        Color.Gray,
        
        Color.Blue,
        Color.SkyBlue,
        Color.Blue,
        
        Color.SkyBlue,
        Color.Blue,
        Color.SkyBlue
    );

    public static readonly ColorTheme Kanagawa = new ColorTheme(
        new Color(31, 31, 40),
        new Color(200, 192, 147),
        new Color(220, 215, 186),
        new Color(200, 192, 147),
        
        new Color(228, 104, 118),
        new Color(200, 192, 147),
        new Color(228, 104, 118),
        
        new Color(200, 192, 147),
        new Color(228, 104, 118),
        new Color(200, 192, 147)
    );
    
    
}
