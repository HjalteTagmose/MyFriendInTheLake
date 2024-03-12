using Godot;

public abstract partial class Draggable : Control
{
	[Export] private bool unparentOnDrag = true;
	[Export] private bool resetPosOnCancel = true;
	[Export] private bool useOffset = false;

	private bool IsDragging;
	private Vector2 startOffset;
	private Control uiRoot;
	private Control parent;
	protected Vector2 lastPos;

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

		Position = GetViewport().GetMousePosition() + (useOffset ? startOffset : -Size / 2f);
		ClampPosition();
	}

	protected virtual void StartDrag()
	{
		if (unparentOnDrag)
		{
			parent.RemoveChild(this);
			uiRoot.AddChild(this);
		}

		startOffset = Position - GetViewport().GetMousePosition();

		IsDragging = true;
		MouseFilter = MouseFilterEnum.Ignore;
		lastPos = Position;
	}

	public virtual void StopDrag()
	{
		if (unparentOnDrag)
		{
			uiRoot.RemoveChild(this);
			parent.AddChild(this);
		}

		IsDragging = false;
		MouseFilter = MouseFilterEnum.Stop;

		Position = GetViewport().GetMousePosition() + startOffset;
		ClampPosition();
	}
	
	public void StopDrag(Vector2 pos)
	{
		StopDrag();
		Position = pos - Size/2f;
	}

	public void CancelDrag()
	{
		StopDrag();
		if (resetPosOnCancel)
			Position = lastPos;
	}

	protected virtual void ClampPosition()
	{

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
