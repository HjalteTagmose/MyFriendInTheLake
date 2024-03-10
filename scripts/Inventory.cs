using Godot;

public partial class Inventory : Panel
{
	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		bool containsPoint = GetRect().HasPoint(atPosition);
		GD.Print($"can drop: {containsPoint}");
		return containsPoint;
	}

	public override void _DropData(Vector2 atPosition, Variant data)
	{
		GD.Print("end drag");
		var item = data.As<Item>();
		item.StopDrag();
	}
}
