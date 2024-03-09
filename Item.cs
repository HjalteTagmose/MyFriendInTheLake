using Godot;
using System;

public partial class Item : Button
{
	public override void _Ready()
	{
		Pressed += OnPressed;
	}

	public void OnPressed()
	{
		GD.Print(Text);
	}
}
