using Godot;
using System;
using System.Threading.Tasks;

public partial class StoryController : Node
{
	public static StoryController Instance;
    public override void _EnterTree() => Instance = this;

	[Export] private SpeechBubble npcSpeechBubble;

	public override async void _Ready()
	{
		await Task.Yield();
		GD.Print("StoryController init");
		ContinueStory();
	}

	public override void _Input(InputEvent @event)
	{
		//https://docs.godotengine.org/en/stable/tutorials/inputs/mouse_and_input_coordinates.html

		if (@event is InputEventMouseButton eventMouseButton)
			if (eventMouseButton.Pressed)
				ContinueStory();
	}
	private void ContinueStory()
	{
		bool hasLine = DialogueSystem.Instance.TryGetNextLine(out string line);
		if (!hasLine)
			return;
		
		GD.Print(line);
		npcSpeechBubble.Say(line);
	}

    public void PickOption(string text)
    {
		DialogueSystem.Instance.PickOption(text);
		ContinueStory();
    }
}
