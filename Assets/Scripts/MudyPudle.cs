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
        playerMoveScript.isInMud = true;

        if (playerMoveScript.speedState != 1)
        {
            playerMoveScript.exitMudRaisedFast = false;
        }
    }

    void OnTriggerExit(Collider playerBox2)
    {
        playerMoveScript.isInMud = false;

        if(playerMoveScript.suspensionIsRaised && playerMoveScript.speedState ==1)
        {
            playerMoveScript.exitMudRaisedFast = true;
        }
        if(playerMoveScript.speedState != 1)
        {
            playerMoveScript.exitMudRaisedFast = false;
        }
    }
}
