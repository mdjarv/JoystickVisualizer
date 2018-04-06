# Joystick Visualizer
[![GitHub release](https://img.shields.io/github/release/mdjarv/joystickvisualizer.svg)](https://github.com/mdjarv/JoystickVisualizer/releases/latest)
[![Donate](https://img.shields.io/badge/Tip%20Jar-PayPal-green.svg)](http://paypal.me/mdjarv)

Show your stick and throttle movement as an overlay while streaming or recording videos.

### **[Download latest release here](https://github.com/mdjarv/JoystickVisualizer/releases)**

This software will read buttons and axis input from supported devices and visualize them using 3D models on top of a flat colored background making it easy to apply chroma key and placing them as overlays using streaming software like OBS or XSplit

![Preview of Joystick Visualizer](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/preview_image.png)

Currently supported devices:

* CH Pro Pedals
* Logitech 3D Pro
* MFG Crosswind
* Saitek Rudder Pedals
* Saitek Combat Rudder Pedals
* Saitek X45 HOTAS (Using Warthog 3D model)
* Saitek X52 Throttle
* Saitek X52 Joystick (Using Warthog 3D model)
* Saitek X52 Pro HOTAS (Using Warthog 3D model)
* Saitek X55 Throttle
* Saitek X55 Joystick
* Saitek Pro Flight Throttle Quadrant
* Thrustmaster Warthog Joystick
* Thrustmaster Warthog Throttle
* Thrustmaster T.Flight Rudder
* Thrustmaster T16000M
* VKB Gunfighter (Using Warthog 3D model)

If you want to contact me the best way would be to hop on my [Discord](https://discord.gg/4nc3XtQ) server and say hello.

## Setting it up

### Start the Software

* Start `JoystickProxy.exe`, if you see a lot of numbers on the screen when you move your controllers then it should be ready

![Proxy Window](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/proxy_window.png)

* Start `JoystickVisualizer.exe`, select your resolution and make sure to run in Windowed Mode

![Visualizer Window](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/visualizer_window.png)

Your devices should show up in the Visualizer when you start moving them

### Configure OBS

1. In OBS add a `Window Capture` source, give it a useful name like "Joystick Visualizer"

![Add Window Capture Source](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/obs_1_add_window_capture.png)

2. Make sure you select `JoystickVisualizer.exe` and you can also uncheck "Capture Cursor"

![Select Inner Window](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/obs_2_add_window_capture.png)

3. Right click on the Source you just created and select `Filters`

![Add filter to source](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/obs_3_sources.png)

4. By clicking the + in the bottom left, add a `Color Key` filter. Change the `Key Color Type` to `Custom Color`

![Setup Color Key filter](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/obs_4_window_capture_filter.png)

5. Click `Select color` and enter `#1e3d5d` in the HTML field

![Select color](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/obs_5_custom_color.png)

6. Save and close the filter settings and you should have an overlay with transparent background to move around your Scene

![Placement](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/obs_6_placement.png)

### Controlling the camera

The camera in the Visualizer can be moved around by right-clicking and dragging, and the view can be zoomed using the mouse wheel.

There are also three camera presets that can be accessed with the `1`, `2` and `3` keys on the keyboard.

## Credits

The Visualizer was created in Unity3D, and the Proxy is a normal C# application that is using the SharpDX library for capturing the USB controllers.

3D model of the Thrustmaster Warthog Joystick was made by Daniel S. and can be found on 3D Warehouse:

* https://3dwarehouse.sketchup.com/model.html?id=u688a84e3-d0f0-4e07-aed1-0715d11dd8f5
* https://3dwarehouse.sketchup.com/model.html?id=ue4b69784-5c08-4753-9d72-5cee5e6e5882

3D model of the Thrustmaster Warthog Throttle was made by Oliver G. and can be found on 3D Warehouse:

* https://3dwarehouse.sketchup.com/model.html?id=1870c8e3d1267a38c023ee32d47e2fa9

3D model by By-Jokese (https://byjokese.com)

* Saitek X55 RHINO stick and throttle
* Saitek Rudder Pedals
* Saitek Combat Rudder Pedals

## Contact

You can find me on:

* Discord: https://discord.gg/4nc3XtQ
* GitHub: https://github.com/mdjarv
* Twitter: [@mdjarv](https://twitter.com/mdjarv "@mdjarv on twitter")
* Twitch: [papapiishu](http://www.twitch.tv/papapiishu "papapiishu on Twitch")
