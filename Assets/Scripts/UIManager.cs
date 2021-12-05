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

    public Score scoreScript;


    void Start()
    {
        ResumeGame();
        failMenuUI.SetActive(false);
    }
    void Update()
    {
        SpeedIndicators();

        if (Input.GetKeyDown(KeyCode.Tab))
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
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void EndGame()
    {
        failMenuUI.SetActive(true);
        scoreScript.CoinsAddToTotal();
        Time.timeScale = 0f;
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
