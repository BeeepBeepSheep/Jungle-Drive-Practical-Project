using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObsticle : MonoBehaviour
{
    FailManager failManager;

    void Start()
    {
        failManager = GameObject.FindGameObjectWithTag("Player").GetComponent<FailManager>();
    }
    void OnCollisionEnter()
    {
        failManager.Fail();
    }
}
