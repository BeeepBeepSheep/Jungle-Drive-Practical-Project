using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text currantCoinsText;
    public Text coinsCollected;
    public Text coinsBankText;

    public int currantCoins = 0;
    public int currantBank;


    void Start()
    {
        currantBank = PlayerPrefs.GetInt("TotalCoins", 0);
        coinsBankText.text = currantBank.ToString();
    }
    void Update()
    {
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
