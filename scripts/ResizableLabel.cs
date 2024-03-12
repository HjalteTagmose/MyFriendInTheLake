using Godot;

public partial class ResizableLabel : Label
{
	private string oldText = "";

	public override void _Process(double delta)
	{
		if(Text != oldText)
			FitText();

		oldText = Text;
	}

	public void FitText()
	{
		int fontSize = 51;
		var font = GetThemeFont("font");
		var textWidth = float.MaxValue; 

		while(textWidth > Size.X)
		{
			fontSize -= 1;
			textWidth = font.GetStringSize(Text, HorizontalAlignment, -1, fontSize).X;
		}	

		AddThemeFontSizeOverride("font_size", fontSize);
    }
}
