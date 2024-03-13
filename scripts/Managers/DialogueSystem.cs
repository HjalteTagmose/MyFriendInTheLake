using Godot;
using GodotInk;

public partial class DialogueSystem : Node
{ 
	public static DialogueSystem Instance;
    public override void _EnterTree() => Instance = this;

    [Export] private InkStory story;
    public bool WaitingForChoice => story.CanContinue;
	public bool InIntro { get; private set; }

	public override void _Ready()
	{
		base._Ready();
		story.BindExternalFunction("test", () => {GD.Print("test");UpdateVariables();});
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
		GD.Print("Intro: " + InIntro);
	}

	private T GetVar<[MustBeVariant] T>(string name) => story.FetchVariable<T>(name);
}
