using Godot;

public partial class LocationManager : Node
{
	[Export] private Control city, park, lake;
	[Export] private Control vlad, kenzo;

	public static LocationManager Instance;
    public override void _EnterTree() => Instance = this;

	private string curLocation = "lake";

	public void GoToLocation(string name)
	{
		if (name == curLocation)
		{
			GD.Print($"You're already here!");
			return;
		}

		curLocation = name;
		lake.Hide();
		park.Hide();
		vlad.Hide();
		city.Hide();
		kenzo.Hide();

		switch (name)
		{
			case "city": 
				city.Show();
				kenzo.Show();
				StoryController.Instance.PickOption("city");
				break;
			case "park": 
				park.Show();
				vlad.Show();
				StoryController.Instance.PickOption("park");
				break;
			case "lake": 
				lake.Show();
				break;
			default: GD.Print($"No location called {name}"); break;
		}
		GD.Print($"Go to {name}");
	}
}
