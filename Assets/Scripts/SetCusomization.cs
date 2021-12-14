using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCusomization : MonoBehaviour
{
    public GameObject metalFrame;
    public GameObject metalFrameLights;

    public GameObject bigExhaust;
    public GameObject smallExhaust;
    public GameObject bigExhaustIcon;
    public GameObject smallExhaustIcon;
    public GameObject spoiler;

    void Start()
    {
        GetInfo();
    }

    public void ToggleFrame()
    {
        if (PlayerPrefs.GetInt("metalFrameIsEquiped", 0) == 1) // if true
        {
            metalFrame.SetActive(false);
            metalFrameLights.SetActive(false);

            PlayerPrefs.SetInt("metalFrameIsEquiped", 0);
        }
        else
        {
            metalFrame.SetActive(true);
            metalFrameLights.SetActive(true);

            PlayerPrefs.SetInt("metalFrameIsEquiped", 1);
        }
    }

    public void ToggleSpoiler()
    {
        if (PlayerPrefs.GetInt("spoilerIsEquiped", 0) == 1) // if true
        {
            spoiler.SetActive(false);
            PlayerPrefs.SetInt("spoilerIsEquiped", 0);
        }
        else
        {
            spoiler.SetActive(true);
            PlayerPrefs.SetInt("spoilerIsEquiped", 1);
        }
    }

    public void ToggleExhaust()
    {
        if (PlayerPrefs.GetInt("bigExhasutIsEquiped", 0) == 1) // if true
        {
            bigExhaust.SetActive(false);
            smallExhaust.SetActive(true);

            bigExhaustIcon.SetActive(true);
            smallExhaustIcon.SetActive(false);
            PlayerPrefs.SetInt("bigExhasutIsEquiped", 0);
        }
        else
        {
            bigExhaust.SetActive(true);
            smallExhaust.SetActive(false);

            bigExhaustIcon.SetActive(false);
            smallExhaustIcon.SetActive(true);
            PlayerPrefs.SetInt("bigExhasutIsEquiped", 1);
        }
    }

    public void GetInfo()
    {
        //all player pref ints r bool

        //frame
        if (PlayerPrefs.GetInt("metalFrameIsEquiped", 0) == 1) // if true
        {
            metalFrame.SetActive(true);
            metalFrameLights.SetActive(true);

            PlayerPrefs.SetInt("metalFrameIsEquiped", 1);
        }
        else
        {
            metalFrame.SetActive(false);
            metalFrameLights.SetActive(false);

            PlayerPrefs.SetInt("metalFrameIsEquiped", 0);
        }

        //exhaust
        if (PlayerPrefs.GetInt("bigExhasutIsEquiped", 0) == 1) // if true
        {
            bigExhaust.SetActive(true);
            smallExhaust.SetActive(false);

            PlayerPrefs.SetInt("bigExhasutIsEquiped", 1);
        }
        else
        {
            bigExhaust.SetActive(false);
            smallExhaust.SetActive(true);
            PlayerPrefs.SetInt("bigExhasutIsEquiped", 0);
        }

        if (PlayerPrefs.GetInt("spoilerIsEquiped", 0) == 1) // if true
        {
            spoiler.SetActive(true);
            PlayerPrefs.SetInt("spoilerIsEquiped", 1);
        }
        else
        {
            spoiler.SetActive(false);
            PlayerPrefs.SetInt("spoilerIsEquiped", 0);
        }
    }
}
