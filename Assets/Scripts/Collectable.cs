using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Score scoreScript;
    public int worth = 1;
    public bool isSpinnable;
    public float spinSpeed = 200;

    void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Score>();
    }
    void Update()
    {
        if(isSpinnable)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -spinSpeed);
        }
    }
    void OnTriggerEnter()
    {
        scoreScript.CurrantCoinIncrease(worth);
    }
}
