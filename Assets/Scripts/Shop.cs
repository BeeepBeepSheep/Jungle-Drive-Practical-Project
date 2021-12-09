using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int currantBank;
    public int cost;
    public MenuManager menuScript;

    void Start()
    {
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);
    }

    public void Purchase()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= cost)
        {
            currantBank -= cost;
            PlayerPrefs.SetInt("TotalCoins", currantBank);
        }
        else
        {
            Debug.Log("to expensive");
        }
        menuScript.UpdateText();
    }
}
