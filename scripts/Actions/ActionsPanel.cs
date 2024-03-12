using Godot;

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
		ask.Scale = think.Scale = go.Scale = Vector2.One;

		if (Item.draggedItem == null) 
		{
			ask.SetAlpha(.5f);
			think.SetAlpha(.5f);
			go.SetAlpha(.5f);
		}
		else 
		{
			ask.SetAlpha(1f);
			think.SetAlpha(1f);
			go.SetAlpha(Item.draggedItem.CanLeave?1f:.5f);
		}

		if (!preview.Visible)
			return;

		GD.Print("dragging: " + Item.draggedItem != null);
		if (Item.draggedItem == null) 
		{
			preview.Hide();
			return;
		}

		var globalMouse = GetGlobalMousePosition();
		bool askHasMouse = ask.GetGlobalRect().HasPoint(globalMouse);
		bool thinkHasMouse = think.GetGlobalRect().HasPoint(globalMouse);
		bool goHasMouse = go.GetGlobalRect().HasPoint(globalMouse) && Item.draggedItem.CanLeave; 
		bool containsMouse = askHasMouse || thinkHasMouse || goHasMouse;

		if (!containsMouse)
			preview.Hide();

		ask.Scale	= Vector2.One * (askHasMouse ?  1.25f : 1f);
		think.Scale = Vector2.One * (thinkHasMouse ?  1.25f : 1f);
		go.Scale  	= Vector2.One * (goHasMouse ?  1.25f : 1f);
	}

}
