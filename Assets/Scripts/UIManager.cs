using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerMove playerMoveScript;
    public Image SpeedIndicator_Circle;
    public float DialFillAmmount = 1;
    public GameObject SpeedIndicator_SingleArrow;
    public GameObject SpeedIndicator_DoubleArrow;
    public GameObject SpeedIndicator_TrippleArrow;

    void Update()
    {
        SpeedIndicators();
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
            i += .1f;
            yield return new WaitForSeconds(0.1f);
            SpeedIndicator_Circle.fillAmount -= i;
        }
        CountDownRestet();
    }
    public void CountDownRestet()
    {
        SpeedIndicator_Circle.fillAmount = 1;
    }
}
