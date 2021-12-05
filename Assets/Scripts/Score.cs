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

    float currantTime;
    bool stopWatchActive = false;
    public Text currantTimeText;
    public Text logestTimFast;

    void Start()
    {
        StartStopWatch();
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);
        coinsBankText.text = currantBank.ToString();

        currantTime = 0;
    }
    void Update()
    {
        StopWatch();

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

        //if (currantCoins > PlayerPrefs.GetInt("TotalCoins", 0))
        //{
        //PlayerPrefs.SetInt("TotalCoins", currantCoins);

        //totalCoinsCore.text = currantCoins.ToString();
        //}
    }

    void StopWatch()
    {
        if(stopWatchActive)
        {
            currantTime = currantTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currantTime);
        currantTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();

        if (currantTime > PlayerPrefs.GetFloat("LogestTimeFast", 0))
        {
            PlayerPrefs.SetFloat("LogestTimeFast", currantTime);
            //need to fix longest time fast scoreing 
            //need to fix longest time fast scoreing 
            //need to fix longest time fast scoreing 
            //need to fix longest time fast scoreing 
            //need to fix longest time fast scoreing 
            //need to fix longest time fast scoreing 
            //need to fix longest time fast scoreing 
            logestTimFast.text = currantTimeText.text;
        }
    }

    public void StartStopWatch()
    {
        stopWatchActive = true;
        currantTime = 0;
    }
    public void StopStopWatch()
    {
        stopWatchActive = false;
        currantTime = 0;
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
