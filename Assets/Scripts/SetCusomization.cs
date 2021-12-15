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

    //primary colour
    public MeshRenderer bodyMesh;

    //secondary colour
    public MeshRenderer spolerMesh;
    public MeshRenderer wheelArch1;
    public MeshRenderer wheelArch2;
    public MeshRenderer wheelArch3;
    public MeshRenderer wheelArch4;

    public PaintTransfer paintTransferer;

    //selected colour save
    string defaultRed = "";
    string defaultRed2 = "";
    string green = "";
    string green2 = "";
    string blue = "";
    string blue2 = "";
    string purple = "";
    string orrange = "";

    string black = "";
    string white = "";
    string pink = "";
    string silver = "";

    string gold = "";

    //this is the main menu customization one

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

        //spoiler
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
    public void SetPrimary(Material selectedPrimary)
    {
        bodyMesh.material = selectedPrimary;

        paintTransferer.selectedPrimary = selectedPrimary;
    }
    public void SetSecondary(Material selectedSecondary)
    {
        spolerMesh.material = selectedSecondary;
        wheelArch1.material = selectedSecondary;
        wheelArch2.material = selectedSecondary;
        wheelArch3.material = selectedSecondary;
        wheelArch4.material = selectedSecondary;

        paintTransferer.selectedSecondary = selectedSecondary;
    }
}
