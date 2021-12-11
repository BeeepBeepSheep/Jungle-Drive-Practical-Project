using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text totalCoinsText;

    void Start()
    {
        totalCoinsText.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
    }

    void Update()
    {
        
    }

    public void UpdateText()
    {
        totalCoinsText.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();

    }
    public void Play()
    {
        SceneManager.LoadScene("Play");
    }
    public void LoadPortfolio()
    {
        System.Diagnostics.Process.Start("https://www.lueke.live/page1.html#top");
    }
}
