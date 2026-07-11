using raygui_cs;

namespace Gui;

public class AppTheme
{

	public bool WindowCreated = false;

	private AppTheme() { }

	public static readonly AppTheme Instance = new AppTheme();

	public ColorTheme Theme
	{
		get;
		private set;
	} = ColorTheme.LightBlue;

	public void SetTheme(
		ColorTheme theme
	)
	{
		this.Theme = theme;
		this.UpdateRayguiStyle();
	}

	public int FontSize
	{
		get;
		private set;
	} = 20;
	public void SetFontSize(
		int size
	)
	{
		this.FontSize = size;
		this.UpdateRayguiStyle();
	}

	public int LineWidth
	{
		get
		{
			return FontSize / 10;
		}
	}

	public int BorderSize
	{
		get;
		private set;
	} = 20;
	public void SetBorderSize(
		int size
	)
	{
		this.BorderSize = size;
		this.UpdateRayguiStyle();
	}

	private void UpdateRayguiStyle()
	{

		if (!WindowCreated)
		{
			return;
		}

		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.TEXT_SIZE, (uint)AppTheme.Instance.FontSize);
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.TEXT_SPACING, (uint)AppTheme.Instance.LineWidth);
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.BACKGROUND_COLOR, AppTheme.Instance.Theme.backgroundColor.ToUint());
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.LINE_COLOR, AppTheme.Instance.Theme.borderColor.ToUint());

		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.BORDER_COLOR_NORMAL, AppTheme.Instance.Theme.borderColor.ToUint());
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.BASE_COLOR_NORMAL, AppTheme.Instance.Theme.fillInColor.ToUint());
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.TEXT_COLOR_NORMAL, AppTheme.Instance.Theme.textColor.ToUint());

		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.BORDER_COLOR_FOCUSED, AppTheme.Instance.Theme.hoverBorderColor.ToUint());
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.BASE_COLOR_FOCUSED, AppTheme.Instance.Theme.hoverFillInColor.ToUint());
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.TEXT_COLOR_FOCUSED, AppTheme.Instance.Theme.hoverTextColor.ToUint());

		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.BORDER_COLOR_PRESSED, AppTheme.Instance.Theme.clickedBorderColor.ToUint());
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.BASE_COLOR_PRESSED, AppTheme.Instance.Theme.clickedFillInColor.ToUint());
		Raygui.GuiSetStyle(Raygui.DEFAULT, Raygui.TEXT_COLOR_PRESSED, AppTheme.Instance.Theme.clickedTextColor.ToUint());

		Raygui.GuiSetStyle((int)GuiControl.DEFAULT, (int)GuiControlProperty.BORDER_WIDTH, (uint)this.LineWidth);
		// Raygui.GuiSetStyle((int)GuiControl.DEFAULT, (int)GuiControlProperty.BORDER_WIDTH, (uint)this.BorderSize/2);

		// GuiSetStyle(DEFAULT, BORDER_COLOR_DISABLED, ColorToInt(cs.border));
		// GuiSetStyle(DEFAULT, BASE_COLOR_DISABLED,   ColorToInt(cs.background));
		// GuiSetStyle(DEFAULT, TEXT_COLOR_DISABLED,   ColorToInt(cs.textMuted));
	}

}