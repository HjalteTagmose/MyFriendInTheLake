extends Node

# Called when the node enters the scene tree for the first time.
func _ready():
	process_mode = Node.PROCESS_MODE_ALWAYS

	# Enter fullscreen mode
	DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_EXCLUSIVE_FULLSCREEN, 0)
	DisplayServer.window_set_vsync_mode(DisplayServer.VSYNC_ENABLED)

	# DEBUGGING:
	if OS.has_feature("editor"):
		DisplayServer.window_set_current_screen(DisplayServer.get_screen_count() - 1)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	# Check for key press
	if Input.is_action_just_pressed("fullscreen_toggle"):
		toggle_fullscreen()

func toggle_fullscreen():
	# Toggle fullscreen mode
		if DisplayServer.window_get_mode() == DisplayServer.WINDOW_MODE_EXCLUSIVE_FULLSCREEN:
			DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED, 0)
		else:
			DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_EXCLUSIVE_FULLSCREEN, 0)