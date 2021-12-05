using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailManager : MonoBehaviour
{
    public Score scoreScipt;
    public UIManager uiManagerScript;

    public void Fail()
    {
        uiManagerScript.EndGame();
        scoreScipt.CoinsAddToTotal();
        Time.timeScale = 0;
    }
}
