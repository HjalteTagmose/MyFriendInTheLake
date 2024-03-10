using Godot;

public partial class StoryAction : Panel
{
	[Export]
	public ActionType type;
	private Label label;

	public override void _Ready()
	{
		label = GetNode<Label>("Label");
		switch (type)
		{
			case ActionType.ASKABOUT: 	label.Text = "Ask About"; 	break;
			case ActionType.THINKABOUT: label.Text = "Think About"; break;
			case ActionType.GOTO: 		label.Text = "Go To"; 		break;
			default: GD.Print($"Unsupported {type}"); 				break;
		}
	}

	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		GD.Print("on action");
		return true;
	}

	public override void _DropData(Vector2 atPosition, Variant data)
	{
		GD.Print("do action");
		var item = data.As<Item>();
		item.CancelDrag();
		switch (type)
		{
			case ActionType.ASKABOUT: 	item.AskAbout(); 	break;
			case ActionType.THINKABOUT: item.ThinkAbout(); 	break;
			case ActionType.GOTO: 		item.GoTo(); 		break;
			default: GD.Print($"Unsupported {type}"); 		break;
		}
	}
}

public enum ActionType
{
	ASKABOUT,
	THINKABOUT,
	GOTO,
}