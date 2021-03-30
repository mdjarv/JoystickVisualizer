using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image background;
    public Dropdown resolutionDropdown;
    public InputField portInput;
    public InputField colorInput;

    String[] resolutions;
    int port;

    void Start()
    {
        resolutions = Screen.resolutions
            .Select(res => resToString(res))
            .Distinct()
            .ToArray();

        resolutionDropdown.options.Clear();
        foreach (var res in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(res));
        }

        resolutionDropdown.value = resolutionDropdown.options.FindIndex(option => option.text == Screen.width + "x" + Screen.height);

        portInput.text = Config.GetPort().ToString();
        colorInput.text = "#" + ColorUtility.ToHtmlStringRGB(Config.GetBackgroundColor());
        background.color = Config.GetBackgroundColor();
    }

    string resToString(Resolution res) {
        return res.width + "x" + res.height;
    }

    public void StartVisualizer() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetResolution(int opt) {
        var resStr = resolutions[opt];
        var parts = resStr.Split('x').Select(d => Int32.Parse(d)).ToArray();
        if(parts.Length == 2) {
            Debug.Log(parts);
            Screen.SetResolution(parts[0], parts[1], false);
        } else {
            Debug.LogError("invalid screen resolution " + resStr);
        }
    }

    public void SetPort(String port) {
        Config.SetPort(Int32.Parse(port));
    }

    public void SetColor(String colorString) {
        background.color = Config.SetBackgroundColor(colorString);
    }
}
