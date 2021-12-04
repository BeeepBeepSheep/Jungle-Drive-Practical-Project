using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailManager : MonoBehaviour
{
    public Score scoreScipt;
    public void Fail()
    {
        Debug.Log("fail");

        scoreScipt.CoinsAddToTotal();
        Time.timeScale = 0;
    }
}
