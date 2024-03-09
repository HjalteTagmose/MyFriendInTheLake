using Godot;
using System;

public partial class Inventory : Panel
{
    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
		bool containsPoint = GetRect().HasPoint(atPosition);
		GD.Print(containsPoint);
        return containsPoint;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
		var item = data.As<Item>();
		GD.Print(item);
		item.Position = atPosition;
	}
}
