using Godot;
using GodotInk;
using Ink.Parsed;
using System;

public partial class DialogueSystem : Node
{
    [Export] private InkStory story;

	public bool TryGetNextLine(out string line)
	{
		if (!story.CanContinue)
		{
			line = "";
			return false;
		}

		line = story.Continue();
		return true;
	}

	public void PickOption(string option)
	{		
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
}
