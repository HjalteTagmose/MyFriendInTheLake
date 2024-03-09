using Godot;
using System;

public partial class StoryController : Node
{
	public override void _Ready()
	{
		GD.Print("StoryController init");
		ContinueStory();
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is not InputEventKey eventKey)
			return;

		if (eventKey.Pressed && eventKey.Keycode == Key.Space)
			ContinueStory();

		// if (eventKey.Pressed && eventKey.Keycode == Key.Escape)
		// 	GetTree().Quit();
	}

	private void ContinueStory()
	{
		bool hasLine = DialogueSystem.Instance.TryGetNextLine(out string line);
		if (hasLine)
			GD.Print(line);
	}
}
