using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text currantCoinsText;
    public Text totalCoinsCore;

    public int currantCoins = 0;

    void Start()
    {
        //totalCoinsCore.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
        Debug.Log(PlayerPrefs.GetInt("TotalCoins"));
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
        currantCoins += coinsIntake;
        currantCoinsText.text = currantCoins.ToString();

        if (currantCoins > PlayerPrefs.GetInt("TotalCoins", 0))
        {
            //PlayerPrefs.SetInt("TotalCoins", currantCoins);

            //totalCoinsCore.text = currantCoins.ToString();
        }
    }

    public void CoinsAddToTotal()
    {
        PlayerPrefs.SetInt("TotalCoins", currantCoins + PlayerPrefs.GetInt("TotalCoins",0));
        Debug.Log(PlayerPrefs.GetInt("TotalCoins"));
        totalCoinsCore.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
    }
    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("TotalCoins");
        //PlayerPrefs.DeleteAll();
    }
}
