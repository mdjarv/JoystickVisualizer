# Joystick Visualizer

Joystick Visualizer shows a 3D view of the Thrustmaster Warthog joystick and throttle that moves with the real joystick connected to the computer. The idea is to use this for some nice visuals when streaming games or record instructional videos for flight simulators.

If you want to see it in action you can follow me on [Twitch](http://www.twitch.tv/papapiishu "papapiishu on Twitch"), I don't stream often but when I do it is usually DCS using this Joystick Visualizer.

## Software description

Unfortunately, because of the way Unity handles joystick input by not reading it if the window is not in focus, the software is divided into two parts: The Joystick Visualizer and the Joystick Proxy.

### Joystick Proxy

Because Unity stops reading joystick input as soon as the window is not in focus I had to create this separate application to read the joystick input via DirectInput and serve it over local TCP port 9998. The port is not yet configurable, so if you have another application serving on this port you will not be able to use it at the moment.

### Joystick Visualizer

The fancy frontend, built using Unity to show the joystick state as a 3D model with most parts already moving, like stick, throttles, 4- and 8-way hats, buttons and trigger. A few buttons and flip switches are not yet rigged but will be as soon as I get around to it.

![Preview of Joystick Visualizer](https://raw.githubusercontent.com/mdjarv/JoystickVisualizer/master/Preview1.png)

## Usage

### Starting the Software

To use, start both the Joystick Proxy and the Joystick Visualizer. The Visualizer will ask you to select a resolution, since the window will usually be downscaled I find it works best when set to 640x480 and make sure to keep it in Windowed mode.

If the Visualizer window with the virtual joystick has a yellow lighting bolt in the upper left corner it means that it does not yet have a connection to the Proxy.

Once a connection is established the lightning bolt will dissapear and you should be able to see your joystick movement in the Visualizer window.

### Setup OBS

In OBS add a Window Capture source, give it a useful name like Joystick Visualizer, select Inner Window, enable Color Key and set the color to ```#1E3D5D``` or RGB: ```31,62,93``` and save your changes.

Then click on Preview Stream to get a video preview of how it will look. Click on Edit Scene, select the Joystick Visualizer source and move and scale it, and move it so that the UI camera buttons are hidden outside of the visual field.

## Credits

This project was made by Mathias Djärv using the Unity 5 game engine and SharpDX for parsing joystic input.

3D model of the Thrustmaster Warthog Joystick was made by Daniel S. and can be found on 3D Warehouse:

* https://3dwarehouse.sketchup.com/model.html?id=u688a84e3-d0f0-4e07-aed1-0715d11dd8f5
* https://3dwarehouse.sketchup.com/model.html?id=ue4b69784-5c08-4753-9d72-5cee5e6e5882

3D model of the Thrustmaster Warthog Throttle was made by Oliver G. and can be found on 3D Warehouse:

* https://3dwarehouse.sketchup.com/model.html?id=1870c8e3d1267a38c023ee32d47e2fa9

## Contact

You can find me on:

* GitHub: https://github.com/mdjarv
* Twitter: [@mdjarv](https://twitter.com/mdjarv "@mdjarv on twitter")
* Twitch: [papapiishu](http://www.twitch.tv/papapiishu "papapiishu on Twitch")
* https://plus.google.com/+MathiasDjarv
