using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Inventory : Panel
{
	private Item[] items;

	public override void _Ready()
	{
		items = GetChild(0)
				.GetChildren()
				.Where(c => c is Item)
				.Select(c => c as Item)
				.ToArray();

		foreach(var item in items)
			item.Hide();
	}

	private bool TryGetItem(string name, out Item item)
	{
		item = items.FirstOrDefault(i => i.Name.ToString().ToLower() == name);
		if (item == null)
		{
			GD.Print($"Couldn't find item called {name}!");
			return false;
		}
		return true;
	}

	public void ShowItem(string name)
	{
		if (TryGetItem(name, out Item item))
			item.Show();
	}

	public void HideItem(string name)
	{
		if (TryGetItem(name, out Item item))
			item.Hide();
	}

	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		bool containsPoint = GetRect().HasPoint(atPosition);
		GD.Print($"can drop: {containsPoint}");
		return containsPoint;
	}

	public override void _DropData(Vector2 atPosition, Variant data)
	{
		GD.Print("end drag");
		var background = data.As<InventoryBackground>();
		background.StopDrag();
	}
}
