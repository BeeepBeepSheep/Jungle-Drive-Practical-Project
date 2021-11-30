using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollider : MonoBehaviour
{

    public GroundTile hostScript;

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("enter test"); 
        hostScript.MyOnTriggerEnter(col);
    }

    void OnTriggerExit(Collider collider)
    {
        //Debug.Log("exit test");
        hostScript.MyOnTriggerExit(collider);
    }
}
