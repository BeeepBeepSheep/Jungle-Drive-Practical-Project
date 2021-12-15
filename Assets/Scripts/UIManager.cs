using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerMove playerMoveScript;
    public Image SpeedIndicator_Circle;
    public float DialFillAmmount = 1;
    public GameObject SpeedIndicator_SingleArrow;
    public GameObject SpeedIndicator_DoubleArrow;
    public GameObject SpeedIndicator_TrippleArrow;

    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject failMenuUI;

    public Text scorePaused;
    public Text highScorePaused;
    public Text coinsCollectedPaused;
    public Text scoreEnd;
    public Text highScoreEnd;
    public Text coinsCollectedEnd;

    public GameObject hud;

    public Score scoreScript;

    public bool canPauseResume = true;

    void Start()
    {
        ResumeGame();
        failMenuUI.SetActive(false);
    }
    void Update()
    {
        SpeedIndicators();

        if (Input.GetKeyDown(KeyCode.Tab) && canPauseResume)
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f;

        UpdateAllText();
    }

    public void PauseGame()
    {
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        hud.SetActive(false);
        Time.timeScale = 0f;

        UpdateAllText();
    }

    public void EndGame()
    {
        failMenuUI.SetActive(true);
        scoreScript.CoinsAddToTotal();
        hud.SetActive(false);
        Time.timeScale = 0f;

        UpdateAllText();
    }

    public void RestartGame()
    {
        failMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Play");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void UpdateAllText()
    {
        scorePaused.text = scoreScript.currantScore.ToString();
        scoreEnd.text = scoreScript.currantScore.ToString();

        highScorePaused.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScoreEnd.text = highScorePaused.text;

        coinsCollectedPaused.text = scoreScript.currantCoins.ToString();
        coinsCollectedEnd.text = scoreScript.currantCoins.ToString();
    }
    void SpeedIndicators()
    {
        if (playerMoveScript.speedState == 1)
        {
            SpeedIndicator_SingleArrow.SetActive(false);
            SpeedIndicator_DoubleArrow.SetActive(false);
            SpeedIndicator_TrippleArrow.SetActive(true);
        }
        if (playerMoveScript.speedState == 0)
        {
            SpeedIndicator_SingleArrow.SetActive(false);
            SpeedIndicator_DoubleArrow.SetActive(true);
            SpeedIndicator_TrippleArrow.SetActive(false);
        }
        if (playerMoveScript.speedState == -1)
        {
            SpeedIndicator_SingleArrow.SetActive(true);
            SpeedIndicator_DoubleArrow.SetActive(false);
            SpeedIndicator_TrippleArrow.SetActive(false);
        }
    }
    public void CountDownStart(float timerAmount)
    {
        StartCoroutine(CountdownDo(timerAmount));
    }
    IEnumerator CountdownDo(float timerAmount)
    {
        for (float i = 0; i < timerAmount;)
        {
            i += .05f;
            yield return new WaitForSeconds(0.05f);
            SpeedIndicator_Circle.fillAmount -= i;
        }
        CountDownRestet();
    }
    public void CountDownRestet()
    {
        SpeedIndicator_Circle.fillAmount = 1;
    }
}
