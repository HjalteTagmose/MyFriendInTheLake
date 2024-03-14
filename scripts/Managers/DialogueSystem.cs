using Godot;
using GodotInk;

public partial class DialogueSystem : Node
{ 
	public static DialogueSystem Instance;
    public override void _EnterTree() => Instance = this;

    [Export] private InkStory story;
	[Export] private Inventory inventory;

    public bool WaitingForChoice => story.CanContinue;
	public bool InIntro { get; private set; }

	public override void _Ready()
	{
		base._Ready();
		story.BindExternalFunction("show_item", (string name) => inventory.ShowItem(name));
		story.BindExternalFunction("hide_item", (string name) => inventory.HideItem(name));
		story.BindExternalFunction("show_char", (string name) => LocationManager.Instance.ShowCharacter(name));
		story.BindExternalFunction("hide_char", (string name) => LocationManager.Instance.HideCharacter(name));
		story.BindExternalFunction("set_line_type", (string type) => StoryController.Instance.SetLineType(type));
		story.BindExternalFunction("load_start", () => GetTree().ChangeSceneToFile("res://start.tscn"));
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		UpdateVariables();
	}

	public bool TryGetNextLine(out string line)
	{
		UpdateVariables();

		line = "";
		if (!story.CanContinue)
			return false;

		line = story.Continue();
		if (string.IsNullOrWhiteSpace(line))
			return TryGetNextLine(out line);

		return true;
	}

	public void PickOption(string option)
	{		
		UpdateVariables();
		
		if (story.CanContinue)
			return;

		int index = GetOptionIndex();
		story.ChooseChoiceIndex(index);

		int GetOptionIndex()
		{
			for (int i = 0; i < story.CurrentChoices.Count; i++)
			{
				var choice = story.CurrentChoices[i]; 
				if (choice.GetText() == option)
					return i;
			}

			return 0; // 0 is always unknown
		}
	}

	private void UpdateVariables()
	{
		InIntro = GetVar<bool>("intro");
	}

	private T GetVar<[MustBeVariant] T>(string name) => story.FetchVariable<T>(name);
}
