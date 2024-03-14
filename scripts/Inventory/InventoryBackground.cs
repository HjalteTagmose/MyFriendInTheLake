using Godot;
using System;

public partial class InventoryBackground : Draggable
{
	[Export] private Control overlay;

	public override void _Ready()
	{
		base._Ready();
		ZIndex = 0;
		overlay.ZIndex = 999;
		Zoom(-0.1f);
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		bool intro = DialogueSystem.Instance.InIntro;
		overlay.Visible = intro;
		MoveChild(overlay, -1);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			switch (mouseEvent.ButtonIndex)
			{
				case MouseButton.WheelUp:
					Zoom(+0.1f);
					break;
				case MouseButton.WheelDown:
					Zoom(-0.1f);
					break;
			}
		}
	}

	private void Zoom(float adj)
	{
		if (Scale.X < 0.8 && adj < 0 || Scale.X > 1.25f && adj > 0)
			return;

		Scale += Vector2.One * adj;
	}

	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		return true;
	}

	public override void _DropData(Vector2 atPosition, Variant data)
	{
		GD.Print("end drag");
		var item = data.As<Item>();
		item.StopDrag(atPosition);
		MoveChild(item, -1);
	}

	protected override void ClampPosition()
	{
		float x = 2048 * Scale.X - 960 - 8;
		float y = 2048 * Scale.Y -1080 - 8;
		float xx = Math.Clamp(Position.X, -x, 0);
		float yy = Math.Clamp(Position.Y, -y, 0);	
		Position = new Vector2(xx, yy);
	}
}
