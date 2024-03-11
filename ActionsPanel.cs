using Godot;
using System;

public partial class ActionsPanel : Panel
{
	[Export] private SpeechBubble preview;
	private StoryAction ask, think, go;

	public override void _Ready()
	{
		ask = GetNode<StoryAction>("Ask");
		think = GetNode<StoryAction>("Think");
		go = GetNode<StoryAction>("Go");
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		UpdatePreview();
	}

	private void UpdatePreview()
	{
		if (!preview.Visible)
			return;

		GD.Print("dragging: " + Item.draggedItem != null);
		if (Item.draggedItem == null) 
		{
			preview.Hide();
			return;
		}

		var globalMouse = GetGlobalMousePosition();
		bool containsMouse = 
			ask.GetGlobalRect().HasPoint(globalMouse) ||
			think.GetGlobalRect().HasPoint(globalMouse) ||
			go.GetGlobalRect().HasPoint(globalMouse); 

		if (!containsMouse)
			preview.Hide();
	}

}
