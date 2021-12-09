using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineOverheat : MonoBehaviour
{

    public float currantEngineTemp;
    public float upMultiplyer = 1;
    public float downMultiplyer = 2;
    public bool carIsFast;

    public Image thermometerFiller;
    public float currantTimer;

    void Start()
    {
        
    }

    void Update()
    {
        if(carIsFast)
        {
            IncreaseHeat();
        }
        else
        {
            DecreaseHeat();
        }
    }

    void IncreaseHeat()
    {
        currantTimer = currantTimer + Time.deltaTime;
        //TimeSpan time = TimeSpan.FromSeconds(currantTimer);
        thermometerFiller.fillAmount = 1;
    }

    void DecreaseHeat()
    {
        currantTimer = 0;
        thermometerFiller.fillAmount = 0;
    }

}
