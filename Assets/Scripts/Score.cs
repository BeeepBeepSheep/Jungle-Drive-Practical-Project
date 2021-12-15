using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public Text currantCoinsText;

    public Text currantScoretext;
    public Text highScoretext;

    public int currantCoins = 0;
    public int currantBank;

    public float currantTime;
    public int currantScore;
    public float highScore;
    public float lifeBest = 0;
    public float multiplyer = 5;
    public bool allowScoring = true;

    public bool hitNewHighscore = false;

    public Animator notificationAnim;

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

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoretext.text = highScore.ToString();

        coinsClump1.SetActive(false);
        coinsClump2.SetActive(false);
        coinsClump3.SetActive(false);
        coinsClump4.SetActive(false);
        coinsClump5.SetActive(false);
        coinsChest.SetActive(false);

        currantTime = 0;

        hitNewHighscore = false;
    }
    void Update()
    {
        CurrentScore();
    }

    public void CurrantCoinIncrease(int coinsIntake)
    {
        //currant coins in level
        currantCoins += coinsIntake;

        currantCoinsText.text = currantCoins.ToString();

        //bank
        currantBank += coinsIntake;

        if(coinsIntake == 1)
        {
            notificationAnim.SetTrigger("oneCoin");
        }
        else
        {
            notificationAnim.SetTrigger("25Coin");
        }

        CoinsInTruckBed();
    }

    void CurrentScore()
    {
        if (allowScoring)
        {
            currantTime = currantTime + Time.deltaTime;
        }
        else
        {
            currantTime = 0;
            currantScore = 0;
        }
        currantScore = Mathf.RoundToInt(currantTime * multiplyer);
        TimeSpan time = TimeSpan.FromSeconds(currantTime);
        currantScoretext.text = currantScore.ToString();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if(currantScore >= lifeBest)
        {
            lifeBest = currantScore;
        }
        if(currantScore >= highScore)
        {
            PlayerPrefs.SetInt("HighScore", currantScore);
            highScoretext.text = highScore.ToString();
            if (!hitNewHighscore)
            {
                hitNewHighscore = true;
                notificationAnim.SetTrigger("newHighScore");
            }
        }
    }
    void CoinsInTruckBed()
    {
        if (currantCoins >= coinsForClump1)
        {
            coinsClump1.SetActive(true);
        }
        if (currantCoins >= coinsForClump2)
        {
            coinsClump2.SetActive(true);
        }
        if (currantCoins >= coinsForClump3)
        {
            coinsClump3.SetActive(true);
        }
        if (currantCoins >= coinsForClump4)
        {
            coinsClump4.SetActive(true);
        }
        if (currantCoins >= coinsForClump5)
        {
            coinsClump5.SetActive(true);
        }
        if (currantCoins >= coinsForChest)
        {
            coinsChest.SetActive(true);
            coinsClump5.SetActive(false);
        }
        if (currantCoins <= 0)
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
        PlayerPrefs.SetInt("TotalCoins", currantBank);
        allowScoring = false;
    }
}
