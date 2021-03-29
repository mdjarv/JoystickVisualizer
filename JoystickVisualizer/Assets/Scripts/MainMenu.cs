using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public InputField portInput;

    Resolution[] resolutions;
    int port;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.options.Clear();
        foreach (var res in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resToString(res)));
        }

        resolutionDropdown.value = resolutionDropdown.options.FindIndex(option => option.text == Screen.width + "x" + Screen.height);
        portInput.text = PlayerPrefs.GetInt("Port", 11011).ToString();
    }

    string resToString(Resolution res) {
        return res.width + "x" + res.height;
    }

    public void StartVisualizer() {
        PlayerPrefs.SetInt("Port", Int32.Parse(portInput.text));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetResolution(int opt) {
        var res = resolutions[opt];
        Debug.Log(resToString(res));
        Screen.SetResolution(res.width, res.height, false);
    }
}
