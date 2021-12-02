using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooLogic : MonoBehaviour
{
    void OnTriggerEnter()
    {
        Debug.Log("bamboo");
        Destroy(gameObject);
    }
}
