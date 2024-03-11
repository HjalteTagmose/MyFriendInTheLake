using Godot;

public partial class Item : Draggable
{
	public static Item draggedItem = null;

	[Export] public bool CanLeave { get; private set; }
	[Export] public string Option { get; private set; } = "unknown";
	[Export] public string Question { get; private set; } = "test question";
	[Export] public string Thought { get; private set; } = "test thought";
	[Export] public string Leave { get; private set; } = "test leave";

	public void AskAbout()
	{
		GD.Print(Question);
		StoryController.Instance.PickOption(Option);
	}

	public void ThinkAbout()
	{
		GD.Print(Thought);
	}

	public void GoTo()
	{
		GD.Print(Leave);
	}
	
	protected override void StartDrag()
	{
		base.StartDrag();
		draggedItem = this;
	}

	public override void StopDrag()
	{
		base.StopDrag();
		draggedItem = null;
	}
}
