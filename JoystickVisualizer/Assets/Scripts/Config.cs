using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{
    public static string PORT_KEY = "Port";
    public static int PORT = 11011;

    public static string BACKGROUND_COLOR_KEY = "Color";
    public static string BACKGROUND_COLOR = "#1F3E5D";


    public static int GetPort() {
         return PlayerPrefs.GetInt(PORT_KEY, PORT);
    }

    public static void SetPort(int port) {
        PlayerPrefs.SetInt(PORT_KEY, port);
    }

    public static Color GetBackgroundColor() {
        Color color;
        if(ColorUtility.TryParseHtmlString(
            PlayerPrefs.GetString(BACKGROUND_COLOR_KEY, BACKGROUND_COLOR),
            out color)) {
                return color;
        } else {
            ColorUtility.TryParseHtmlString(BACKGROUND_COLOR, out color);
        }

        return color;
    }

    public static Color SetBackgroundColor(string colorString) {
        Color color;
        if(ColorUtility.TryParseHtmlString(colorString, out color)) {
            PlayerPrefs.SetString(BACKGROUND_COLOR_KEY, colorString);
            return color;
        }
        return GetBackgroundColor();
    }

    public static string GetBackgroundColorString() {
        return "#" + ColorUtility.ToHtmlStringRGB(Config.GetBackgroundColor());
    }
}
