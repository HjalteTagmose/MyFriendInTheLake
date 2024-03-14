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
			case "harukiya": 
				city.Show();
				StoryController.Instance.PickOption("loc_city");
				break;
			case "park": 
				park.Show();
				StoryController.Instance.PickOption("loc_park");
				break;
			case "lake": 
				lake.Show();
				StoryController.Instance.PickOption("loc_lake");
				break;
			default: GD.Print($"No location called {name}"); break;
		}
		GD.Print($"Go to {name}");
	}

	private Control GetCharacter(string name)
	{
		switch(name)
		{
			case "vlad": return vlad;
			case "kenzo": return kenzo;
			default: GD.Print($"No character called {name}"); return null;
		}
	}

	public void ShowCharacter(string name) => GetCharacter(name).Show();
	public void HideCharacter(string name) => GetCharacter(name).Hide();
}
