using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public bool isFullScreen = false;
    public GameObject fullscreenTick;

    public Slider masterVolSlider;
    public Slider musicVolSlider;

    public AudioMixer masterMixer;

    void Start()
    {
        FullScreen_Toggle();
    }

    public void Set_MasterVolume(float value)
    {
        masterMixer.SetFloat("MasterVol", value);
    }
    public void Set_MusicVolume(float value)
    {
        masterMixer.SetFloat("MusicVol", value);
    }
    public void Set_EffectsVolume(float value)
    {
        masterMixer.SetFloat("EffectsVol", value);
    }
    public void Set_EnvironmentVolume(float value)
    {
        masterMixer.SetFloat("EnvironmentVol", value);
    }

    public void FullScreen_Toggle()
    {
        if (isFullScreen)
        {
            isFullScreen = false;
            Screen.fullScreen = isFullScreen;
            fullscreenTick.SetActive(false);
        }
        else
        {
            isFullScreen = true;
            Screen.fullScreen = isFullScreen;
            fullscreenTick.SetActive(true);
        }
    }
    public void ResetStats()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }
}
