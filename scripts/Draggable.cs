using Godot;

public abstract partial class Draggable : Control
{
	private bool IsDragging;
	private Vector2 startOffset;
	private Control uiRoot;
	private Control parent;
	private Vector2 lastPos;

	public override void _Ready()
	{
		lastPos = Position;
		uiRoot = GetTree().Root.GetNode<Control>("main/UI");
		parent = GetParent<Control>();
	}

	public override void _Process(double delta)
	{
		HandleDrag();
	}

	public void HandleDrag()
	{
		if (!IsDragging)
			return;

		Position = GetViewport().GetMousePosition() + startOffset;
	}

	public void StartDrag()
	{
		startOffset = Position - GetViewport().GetMousePosition();
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
