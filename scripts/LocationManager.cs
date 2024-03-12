using Godot;

public partial class LocationManager : Node
{
	public static LocationManager Instance;
    public override void _EnterTree() => Instance = this;

	private string curLocation = "park";

	public void GoToLocation(string name)
	{
		if (name == curLocation)
		{
			GD.Print($"You're already here!");
			return;
		}

		GD.Print($"Go to {name}");
		switch (name)
		{
			case "city": break;
			case "park": break;
			default: GD.Print($"No location called {name}"); break;
		}
	}
}
