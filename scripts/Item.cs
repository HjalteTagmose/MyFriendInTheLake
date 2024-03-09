using Godot;
using System;

public partial class Item : Button
{
	public override void _Ready()
	{
		Pressed += OnPressed;
	}

    public override void _Process(double delta)
    {
        bool canPick = DialogueSystem.Instance.WaitingForChoice;
		Disabled = canPick;
    }

    public void OnPressed()
	{
		GD.Print(Text);
		StoryController.Instance.PickOption(Text);
	}

    public override Variant _GetDragData(Vector2 atPosition)
    {
		GD.Print("drag");
        return this;
    }
}
