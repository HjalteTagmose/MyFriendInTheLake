using System;
using Godot;

public partial class SpeechBubble : Control
{
	[Export] private BubbleType type;
	private Panel speech, preview, thought, box;

	private Label label;

	public override void _Ready()
	{
		speech = GetNode("Speech") as Panel;
		preview = GetNode("Preview") as Panel;
		thought = GetNode("Thought") as Panel;
		box = GetNode("Box") as Panel;

		label = GetNode("Text") as Label;
		UpdateVisual(type);
	}

	public void Say(string text)
	{
		label.Text = text;
		UpdateVisual(type);
	}

	private void UpdateVisual(BubbleType type)
	{
		speech.Hide();
		preview.Hide();
		thought.Hide();
		box.Hide();
		
		switch (type)
		{
			case BubbleType.SPEECH: speech.Show(); 	break;
			case BubbleType.PREVIEW:preview.Show();	break;
			case BubbleType.THOUGHT:thought.Show(); break;
			case BubbleType.BOX: 	box.Show(); 	break;
			default: 				box.Show();		break;
		}
	}

	public void Preview(BubbleType type, string description)
	{
		this.type = type;
		Say(description);
		UpdateVisual(type);
	}
}

public enum BubbleType
{
	SPEECH,
	PREVIEW,
	THOUGHT,
	BOX,
}
