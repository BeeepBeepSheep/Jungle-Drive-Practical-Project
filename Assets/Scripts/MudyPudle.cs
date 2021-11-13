using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudyPudle : MonoBehaviour
{
    public GameObject player;
    public GameObject car;
    PlayerMove playerMoveScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        car = GameObject.FindGameObjectWithTag("Car");

        playerMoveScript = player.GetComponent<PlayerMove>();
    }

    void OnTriggerEnter(Collider playerBox)
    {
        playerMoveScript.SlowDown();
        if (!playerMoveScript.suspensionIsRaised)
        {
            playerMoveScript.currantSpeed = playerMoveScript.mudSpeed;
        }
    }

    void OnTriggerExit(Collider playerBox2)
    {
        if(!playerMoveScript.suspensionIsRaised)
        {
            StartCoroutine(AllowSpeedUp());
        }
    }
    IEnumerator AllowSpeedUp()
    {
        yield return new WaitForSeconds(.25f);
        playerMoveScript.SpeedUp();
    }
}
