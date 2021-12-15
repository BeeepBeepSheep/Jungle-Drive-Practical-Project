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

    public Material primaryMat;
    public Material secondaryMat;

    //primary colour
    public MeshRenderer bodyMesh;

    //secondary colour
    public MeshRenderer spolerMesh;
    public MeshRenderer wheelArch1;
    public MeshRenderer wheelArch2;
    public MeshRenderer wheelArch3;
    public MeshRenderer wheelArch4;

    // this is the game one
    void Start()
    {
        GetSetInfo();
        GetSetPaint();
    }

    public void GetSetInfo()
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
    public void GetSetPaint()
    {

        //set
        bodyMesh.material = primaryMat;

        spolerMesh.material = secondaryMat;
        wheelArch1.material = secondaryMat;
        wheelArch2.material = secondaryMat;
        wheelArch3.material = secondaryMat;
        wheelArch4.material = secondaryMat;
    }
}
