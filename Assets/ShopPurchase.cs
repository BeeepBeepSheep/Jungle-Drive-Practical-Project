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
    public GameObject frameToggleButton;
    public Text framePriceTag;
    public int frameCost;

    public GameObject lockedSpoilerIcon;
    public GameObject spoilerToggleButton;
    public Text spoilerPriceTag;
    public int spoilerCost;

    public GameObject lockedExhaustIcon;
    public GameObject exhaustToggleButton;
    public Text exhaustPriceTag;
    public int exhaustCost;

    void Start()
    {
        GetInfo();

        framePriceTag.text = frameCost.ToString();
        spoilerPriceTag.text = spoilerCost.ToString();
        exhaustPriceTag.text = exhaustCost.ToString();
    }

    public void PurchaseFrame()
    {
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);

        if (PlayerPrefs.GetInt("TotalCoins") >= frameCost)
        {
            currantBank -= frameCost;
            PlayerPrefs.SetInt("TotalCoins", currantBank);
            PlayerPrefs.SetInt("metalFrameIsOwned", 1);

            lockedFrameIcon.SetActive(false);
            frameToggleButton.SetActive(true);
            physicalCustomizationScript.ToggleFrame();
        }
        else
        {
            Debug.Log("to expensive");
        }
        menuScript.UpdateText();
    }
    public void PurchaseSpoiler()
    {
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);

        if (PlayerPrefs.GetInt("TotalCoins") >= spoilerCost)
        {
            currantBank -= spoilerCost;
            PlayerPrefs.SetInt("TotalCoins", currantBank);
            PlayerPrefs.SetInt("spoilerIsOwned", 1);

            lockedSpoilerIcon.SetActive(false);
            spoilerToggleButton.SetActive(true);
            physicalCustomizationScript.ToggleSpoiler();
        }
        else
        {
            Debug.Log("to expensive");
        }
        menuScript.UpdateText();
    }
    public void PurchaseBigExhaust()
    {
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);

        if (PlayerPrefs.GetInt("TotalCoins") >= exhaustCost)
        {
            currantBank -= exhaustCost;
            PlayerPrefs.SetInt("TotalCoins", currantBank);
            PlayerPrefs.SetInt("bigExhasutIsOwned", 1);

            lockedExhaustIcon.SetActive(false);
            exhaustToggleButton.SetActive(true);
            physicalCustomizationScript.ToggleExhaust();
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
            frameToggleButton.SetActive(true);
        }
        else
        {
            lockedFrameIcon.SetActive(true);
            frameToggleButton.SetActive(false);
        }

        //spoiler
        if (PlayerPrefs.GetInt("spoilerIsOwned", 0) == 1) // if true
        {
            lockedSpoilerIcon.SetActive(false);
            spoilerToggleButton.SetActive(true);
        }
        else
        {
            lockedSpoilerIcon.SetActive(true);
            spoilerToggleButton.SetActive(false);
        }

        //exhaust
        if (PlayerPrefs.GetInt("bigExhasutIsOwned", 0) == 1) // if true
        {
            lockedExhaustIcon.SetActive(false);
            exhaustToggleButton.SetActive(true);
        }
        else
        {
            lockedExhaustIcon.SetActive(true);
            exhaustToggleButton.SetActive(false);
        }
    }
}//
