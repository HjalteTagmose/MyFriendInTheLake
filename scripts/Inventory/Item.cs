using Godot;

public partial class Item : Draggable
{
	public static Item draggedItem = null;
	
	[Export] private float scaleWhenDragged = 1f;
	[Export] public bool CanLeave { get; private set; }
	[Export] public string Option { get; private set; } = "unknown";
	[Export] public string Question { get; private set; } = "test question";
	[Export] public string Thought { get; private set; } = "test thought";
	[Export] public string Leave { get; private set; } = "test leave";

	public override void _Ready()
	{
		base._Ready();
		ZIndex = 1;
	}

	public void AskAbout()
	{
		GD.Print(Question);
		StoryController.Instance.PickOption(Option);
	}

	public void ThinkAbout()
	{
		GD.Print(Thought);
		StoryController.Instance.Think(Thought);
	}

	public void GoTo()
	{
		GD.Print(Leave);
		LocationManager.Instance.GoToLocation(Option);
	}
	
	protected override void StartDrag()
	{
		base.StartDrag();
		ZIndex = 2000;
		draggedItem = this;
		Scale = Vector2.One * scaleWhenDragged;
	}

	public override void StopDrag()
	{
		base.StopDrag();
		ZIndex = 1;
		draggedItem = null;
		Scale = Vector2.One;
	}
}
