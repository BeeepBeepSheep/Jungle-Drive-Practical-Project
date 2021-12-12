using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPurchase : MonoBehaviour
{
    public MenuManager menuScript;
    public int currantBank;
    public SetCusomization physicalCustomizationScript;

    public GameObject lockedFrameIcon;
    public GameObject FrameTogglePurchased;
    public Text framePriceTag;
    public int FrameCost;

    void Start()
    {
        GetInfo();

        framePriceTag.text = FrameCost.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            PlayerPrefs.SetInt("metalFrameIsEquiped", 1);
        }
        if (Input.GetKeyDown("0"))
        {
            PlayerPrefs.SetInt("metalFrameIsEquiped", 0);
        }
    }

    public void PurchaseFrame()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= FrameCost)
        {
            currantBank -= FrameCost;
            PlayerPrefs.SetInt("TotalCoins", currantBank);
            PlayerPrefs.SetInt("metalFrameIsOwned", 1);

            lockedFrameIcon.SetActive(false);
            FrameTogglePurchased.SetActive(true);
            physicalCustomizationScript.ToggleFrame();
        }
        else
        {
            Debug.Log("to expensive");
        }
        menuScript.UpdateText();
    }
    public void GetInfo()
    {
        //bank
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);

        //all player pref ints r bool

        //frame
        if (PlayerPrefs.GetInt("metalFrameIsOwned", 0) == 1) // if true
        {
            lockedFrameIcon.SetActive(false);
            FrameTogglePurchased.SetActive(true);
        }
        else
        {
            lockedFrameIcon.SetActive(true);
            FrameTogglePurchased.SetActive(false);
        }

        //exhaust
        if (PlayerPrefs.GetInt("bigExhasutIsOwned", 0) == 1) // if true
        {
        }
        else
        {
        }

        if (PlayerPrefs.GetInt("spoilerIsOwned", 0) == 1) // if true
        {
        }
        else
        {
        }
    }
}//
