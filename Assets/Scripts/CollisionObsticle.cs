using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionObsticle : MonoBehaviour
{
    FailManager failManager;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Play")
        {
            failManager = GameObject.FindGameObjectWithTag("Player").GetComponent<FailManager>();
        }
    }
    void OnCollisionEnter()
    {
        failManager.Fail();
    }
}
