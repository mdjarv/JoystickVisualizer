# Joystick Visualizer

Joystick Visualizer shows a 3D view of the Thrustmaster Warthog joystick and throttle that moves with the real joystick connected to the computer. The idea is to use this for some nice visuals when streaming games or record instructional videos for flight simulators.

If you want to contact me the best way would be to hop on my [Discord](https://discord.gg/4nc3XtQ) server and say hello.

## Usage

If you just want to use the software, make sure you download a prebuilt release under the [Releases](https://github.com/mdjarv/JoystickVisualizer/releases) page instead of using the green "Clone or download" button which will get you the source code instead.

### Starting the Software

For normal usage start the two applications, the Proxy and the Visualizer. In the Proxy window you can check that its found your stick and throttle by moving them around.

In the Visualizer window you select the window resolution you want and then when the application is running you move your devices around and they will show up.

### Controlling the camera

The camera in the Visualizer can be moved around by right-clicking and dragging, and the view can be zoomed using the mouse wheel.

There are also three camera presets that can be accessed with the `1`, `2` and `3` keys on the keyboard.

### Setup OBS

In OBS add a Window Capture source, give it a useful name like Joystick Visualizer, select Inner Window, enable Color Key and set the color to ```#1E3D5D``` or RGB: ```31,62,93``` and save your changes.

Then click on Preview Stream to get a video preview of how it will look. Click on Edit Scene, select the Joystick Visualizer source and move and scale it, and move it so that the UI camera buttons are hidden outside of the visual field.

## Overview

Unfortunately, because of the way Unity handles joystick input by not reading it if the window is not in focus, the software is divided into two parts: The Joystick Visualizer and the Joystick Proxy.

### Joystick Proxy

This application will read the USB device input via DirectInput and send the events over UDP. The `settings.ini` file is used to configure host and port of the computer running the visualizer. If it has detected your joystick and/or throttle it should print event values for movement and button pushes.

If you for some reason want to run the visualizer on another PC you can change the host and port in the `settings.ini` file.

### Joystick Visualizer

The Visualizer part is the graphical frontend, built using Unity3D to show a 3D model moving. Using Color Key in OBS you can then remove the background and add it as an overlay to your stream like in the image below.

![Preview of Joystick Visualizer](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/Preview1.png)

## Credits

The Visualizer was created in Unity3D, and the Proxy is a normal C# application that is using the SharpDX library for capturing the USB controllers.

3D model of the Thrustmaster Warthog Joystick was made by Daniel S. and can be found on 3D Warehouse:

* https://3dwarehouse.sketchup.com/model.html?id=u688a84e3-d0f0-4e07-aed1-0715d11dd8f5
* https://3dwarehouse.sketchup.com/model.html?id=ue4b69784-5c08-4753-9d72-5cee5e6e5882

3D model of the Thrustmaster Warthog Throttle was made by Oliver G. and can be found on 3D Warehouse:

* https://3dwarehouse.sketchup.com/model.html?id=1870c8e3d1267a38c023ee32d47e2fa9

3D model of the Saitek X55 RHINO stick and throttle were made by By-Jokese

* https://byjokese.com

## Contact

You can find me on:

* Discord: https://discord.gg/4nc3XtQ
* GitHub: https://github.com/mdjarv
* Twitter: [@mdjarv](https://twitter.com/mdjarv "@mdjarv on twitter")
* Twitch: [papapiishu](http://www.twitch.tv/papapiishu "papapiishu on Twitch")
