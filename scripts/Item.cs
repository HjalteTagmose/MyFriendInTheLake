using Godot;
using System;

public partial class Item : Button
{
	public bool IsDragging { get; set; } 
	private Vector2 lastPos;

	public override void _Ready()
	{
		Pressed += OnPressed;
		lastPos = Position;
	}

    public override void _Process(double delta)
    {
        bool canPick = DialogueSystem.Instance.WaitingForChoice;
		Disabled = canPick;
		HandleDrag();
    }

    public void OnPressed()
	{
		GD.Print(Text);
		StoryController.Instance.PickOption(Text);
	}

	public void HandleDrag()
	{
		if (!IsDragging)
			return;

		var size = GetRect().Size;
		var offset = size/2f;
		Position = GetViewport().GetMousePosition() - offset;
	}

	public void StartDrag()
	{
		IsDragging = true;
		MouseFilter = MouseFilterEnum.Ignore;
		lastPos = Position;
	}

	public void StopDrag()
	{
		IsDragging = false;
		MouseFilter = MouseFilterEnum.Stop;
	}

	public void CancelDrag()
	{
		StopDrag();
		Position = lastPos;
	}

    public override Variant _GetDragData(Vector2 atPosition)
    {
		GD.Print("start drag");
		StartDrag();
        return this;
    }
	
	public override void _Notification(int what)
	{
		if (what == Node.NotificationDragEnd)
		{
			if (IsDragging)
				CancelDrag();
		}
		base._Notification(what);
	}
}
