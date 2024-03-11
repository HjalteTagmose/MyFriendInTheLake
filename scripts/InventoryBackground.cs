using Godot;
using System;

public partial class InventoryBackground : Draggable
{
	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		return true;
	}

	public override void _DropData(Vector2 atPosition, Variant data)
	{
		GD.Print("end drag");
		var item = data.As<Item>();
		item.StopDrag();
	}

	protected override void ClampPosition()
	{
		float x = Math.Clamp(Position.X, -1060, 0);
		float y = Math.Clamp(Position.Y,  -960, 0);	
		Position = new Vector2(x, y);
	}
}
