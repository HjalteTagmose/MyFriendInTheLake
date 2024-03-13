using Godot;
using GodotInk;
using Ink.Parsed;
using System;

public partial class DialogueSystem : Node
{ 
	public static DialogueSystem Instance;
    public override void _EnterTree() => Instance = this;

    [Export] private InkStory story;
    public bool WaitingForChoice => story.CanContinue;
	public bool InIntro { get; private set; }

	void poop() => GD.Print("INTRO!");
	public override void _Ready()
	{
		// THIS DOESNT WORK FSR
		// IT DOES CALL THO
		// FIGURE OUT CALLABLES OR SOMETHING
		// base._Ready();
		// var callable = new Callable(this, "poop");
		// story.ObserveVariable("intro", callable);

		/*
		ERROR: Invalid call. Nonexistent callable 'Node(DialogueSystem.cs)::poop'.
			at: void Godot.NativeInterop.ExceptionUtils.DebugCheckCallError(Godot.NativeInterop.godot_callable&, Godot.NativeInterop.godot_variant**, int, Godot.NativeInterop.godot_variant_call_error) (/root/godot/modules/mono/glue/GodotSharp/GodotSharp/Core/NativeInterop/ExceptionUtils.cs:159)
		ERROR: Invalid call. Nonexistent callable 'Node(DialogueSystem.cs)::'.
			at: void Godot.NativeInterop.ExceptionUtils.DebugCheckCallError(Godot.NativeInterop.godot_callable&, Godot.NativeInterop.godot_variant**, int, Godot.NativeInterop.godot_variant_call_error) (/root/godot/modules/mono/glue/GodotSharp/GodotSharp/Core/NativeInterop/ExceptionUtils.cs:159)
		*/
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
