extends Node

var frame_target_leftover: float = 0
var eat_frames_end_frame: int = 0

func _ready():
	await get_tree().process_frame
	await get_tree().process_frame
	eat_frames()

func _process(_delta):
	# TEMP: If backspace pressed, eat up the buffer
	# if (Input.is_action_just_pressed("ui_text_backspace")):
	# 	eat_frames()

	if (Engine.get_frames_drawn() >= eat_frames_end_frame):
		var refresh_rate = DisplayServer.screen_get_refresh_rate()
		if (refresh_rate == 59||refresh_rate == 60):
			refresh_rate = 59.94

		var buffer_eating_drop = 0.01
		var target_fps = refresh_rate - buffer_eating_drop
		var target_fps_plus_leftover = target_fps + frame_target_leftover
		var rounded = round(target_fps_plus_leftover)
		frame_target_leftover = target_fps_plus_leftover - rounded

		Engine.max_fps = rounded

func eat_frames(frames: int=4):
	print("Eating buffered frames to reduce input latency")
	# Eat 6 frames by default to be safe
	# Lower the max fps for a small amount of time to eat up the buffer
	eat_frames_end_frame = Engine.get_frames_drawn() + 1
	var fps = DisplayServer.screen_get_refresh_rate() / frames
	Engine.max_fps = max(1, floor(fps))
