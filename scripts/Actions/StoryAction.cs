using Godot;

public partial class StoryAction : Panel
{
	[Export] private ActionType type;
	[Export] private SpeechBubble preview;
	private TextureRect textureRect;

	public override void _Ready()
	{
		textureRect = GetNode<TextureRect>("Icon");
	}

	public void SetAlpha(float a)
	{
		textureRect.SelfModulate = new Color(1,1,1,a);
	}

	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		if(data.As<Draggable>() is InventoryBackground)
			return true;
		
		if (DialogueSystem.Instance.WaitingForChoice)
			return false;

		var item = data.As<Item>(); 
		var bubble = (BubbleType)(type+1);
		string previewText = "N/A";

		switch (type)
		{
			case ActionType.ASKABOUT: 	previewText = item.Question;break;
			case ActionType.THINKABOUT: previewText = item.Thought;	break;
			case ActionType.GOTO: 		previewText = item.Leave;	break;
			default: GD.Print($"Unsupported {type}"); 				break;
		}

		preview.Show();
		preview.Preview(bubble, previewText);

		return type != ActionType.GOTO || item.CanLeave;
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