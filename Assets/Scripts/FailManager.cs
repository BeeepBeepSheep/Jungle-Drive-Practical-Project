using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailManager : MonoBehaviour
{
    public void Fail()
    {
        Debug.Log("fail");
        Time.timeScale = 0;
    }
}
