using Godot;

public partial class SpeechBubble : Panel
{
	private Label label;

    public override void _Ready()
    {
		label = GetNode("Text") as Label;
    }

    public void Say(string text)
	{
		label.Text = text;
	}
}
