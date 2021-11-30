using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollider : MonoBehaviour
{

    public GroundTile hostScript;

    void OnTriggerEnter(Collider col)
    {
        hostScript.MyOnTriggerEnter(col);
        Debug.Log("enter test"); 
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("exit test");
        hostScript.MyOnTriggerExit(collider);
    }
}
