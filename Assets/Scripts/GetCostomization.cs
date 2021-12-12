using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCostomization : MonoBehaviour
{
    public GameObject metalFrame;
    public GameObject metalFrameLights;

    public GameObject bigExhaust;
    public GameObject smallExhaust;

    public GameObject spoiler;

    void Start()
    {
        GetInfo();
    }

    public void GetInfo()
    {
        //all player pref ints r bool

        //frame
        if(PlayerPrefs.GetInt("metalFrameIsEquiped", 0) == 1) // if true
        {
            metalFrame.SetActive(true);
            metalFrameLights.SetActive(true);
        }
        else
        {
            metalFrame.SetActive(false);
            metalFrameLights.SetActive(false);
        }

        //exhaust
        if (PlayerPrefs.GetInt("bigExhasutIsEquiped", 0) == 1) // if true
        {
            bigExhaust.SetActive(true);
            smallExhaust.SetActive(false);
        }
        else
        {
            bigExhaust.SetActive(false);
            smallExhaust.SetActive(true);
        }

        if (PlayerPrefs.GetInt("spoilerIsEquiped", 0) == 1) // if true
        {
            spoiler.SetActive(true);
        }
        else
        {
            spoiler.SetActive(false);
        }
    }
}
