using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public Text currantCoinsText;
    public Text coinsCollected;
    public Text coinsBankText;

    public int currantCoins = 0;
    public int currantBank;

    //float currantTime;
    //bool stopWatchActive = false;
    public Text currantTimeText;
    public Text logestTimFast;

    public int coinsForClump1 = 25;
    public int coinsForClump2 = 75;
    public int coinsForClump3 = 150;
    public int coinsForClump4 = 300;
    public int coinsForClump5 = 500;
    public int coinsForChest = 750;

    public GameObject coinsClump1;
    public GameObject coinsClump2;
    public GameObject coinsClump3;
    public GameObject coinsClump4;
    public GameObject coinsClump5;
    public GameObject coinsChest;

    void Start()
    {
        //StartStopWatch();
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);
        coinsBankText.text = currantBank.ToString();

        //currantTime = 0;
        coinsClump1.SetActive(false);
        coinsClump2.SetActive(false);
        coinsClump3.SetActive(false);
        coinsClump4.SetActive(false);
        coinsClump5.SetActive(false);
        coinsChest.SetActive(false);
    }
    void Update()
    {
        //StopWatch();

        if (Input.GetKeyDown("x"))
        {
            CurrantCoinIncrease(1);
        }

        if (Input.GetKeyDown("z"))
        {
            ResetStats();
        }
    }

    public void CurrantCoinIncrease(int coinsIntake)
    {
        //currant coins in level
        currantCoins += coinsIntake;

        currantCoinsText.text = currantCoins.ToString();
        coinsCollected.text = currantCoins.ToString();

        //bank
        currantBank += coinsIntake;

        CoinsInTruckBed();
        //if (currantCoins > PlayerPrefs.GetInt("TotalCoins", 0))
        //{
        //PlayerPrefs.SetInt("TotalCoins", currantCoins);

        //totalCoinsCore.text = currantCoins.ToString();
        //}
    }

    //void StopWatch()
    //{
    //    if(stopWatchActive)
    //    {
    //        currantTime = currantTime + Time.deltaTime;
    //    }
    //    TimeSpan time = TimeSpan.FromSeconds(currantTime);
    //    currantTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();

    //    if (currantTime > PlayerPrefs.GetFloat("LogestTimeFast", 0))
    //    {
    //        PlayerPrefs.SetFloat("LogestTimeFast", currantTime);
    //        //need to fix longest time fast scoreing 
    //        //need to fix longest time fast scoreing 
    //        //need to fix longest time fast scoreing 
    //        //need to fix longest time fast scoreing 
    //        //need to fix longest time fast scoreing 
    //        //need to fix longest time fast scoreing 
    //        //need to fix longest time fast scoreing 
    //        logestTimFast.text = currantTimeText.text;
    //    }
    //}

    //public void StartStopWatch()
    //{
    //    stopWatchActive = true;
    //    currantTime = 0;
    //}
    //public void StopStopWatch()
    //{
    //    stopWatchActive = false;
    //    currantTime = 0;
    //}

    void CoinsInTruckBed()
    {
        if (currantCoins >= coinsForClump1)
        {
            coinsClump1.SetActive(true);
        }
        else if (currantCoins >= coinsForClump2)
        {
            coinsClump2.SetActive(true);
        }
        else if (currantCoins >= coinsForClump3)
        {
            coinsClump3.SetActive(true);
        }
        else if (currantCoins >= coinsForClump4)
        {
            coinsClump4.SetActive(true);
        }
        else if (currantCoins >= coinsForClump5)
        {
            coinsClump5.SetActive(true);
        }
        else if (currantCoins >= coinsForChest)
        {
            coinsChest.SetActive(true);
            coinsClump5.SetActive(false);
        }
        else
        {
            coinsClump1.SetActive(false);
            coinsClump2.SetActive(false);
            coinsClump3.SetActive(false);
            coinsClump4.SetActive(false);
            coinsClump5.SetActive(false);
            coinsChest.SetActive(false);
        }
    }

    public void CoinsAddToTotal()
    {
        //add currant to main bank
        PlayerPrefs.SetInt("TotalCoins", currantBank);
        coinsBankText.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
    }
    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("TotalCoins");
        currantCoins = 0;
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);

        currantCoinsText.text = currantCoins.ToString();
        coinsCollected.text = currantCoins.ToString();
        //PlayerPrefs.DeleteAll();
    }
}
