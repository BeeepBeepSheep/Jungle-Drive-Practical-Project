using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text totalCoinsText;

    public GameObject shopMenu;
    bool shopIsOpen = false;

    public GameObject optionsMenu;
    bool optionsIsOpen = false;
    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            PlayerPrefs.DeleteAll();
            UpdateText();
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown("z"))
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins", 0) + 1000);
            UpdateText();
        }
    }

    public void UpdateText()
    {
        totalCoinsText.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
    }
    public void Play()
    {
        SceneManager.LoadScene("Play");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadPortfolio()
    {
        System.Diagnostics.Process.Start("https://www.lueke.live/page1.html#top");
    }

    public void ToggleShop()
    {
        if(shopIsOpen)
        {
            shopMenu.SetActive(false);
            shopIsOpen = false;

            optionsMenu.SetActive(false);
            optionsIsOpen = false;
        }
        else
        {
            shopMenu.SetActive(true);
            shopIsOpen = true;

            optionsMenu.SetActive(false);
            optionsIsOpen = false;
        }
    }

    public void ToggleOptions()
    {
        if (optionsIsOpen)
        {
            optionsMenu.SetActive(false);
            optionsIsOpen = false;

            shopMenu.SetActive(false);
            shopIsOpen = false;
        }
        else
        {
            optionsMenu.SetActive(true);
            optionsIsOpen = true;

            shopMenu.SetActive(false);
            shopIsOpen = false;
        }
    }
}
