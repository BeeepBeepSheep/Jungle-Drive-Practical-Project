using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    GroundSpawner groundSpawnerScript;
    void Start()
    {
        groundSpawnerScript = GameObject.FindObjectOfType<GroundSpawner>();
        //transform.parent = groundSpawnerScript.tileEquivolent.transform;
    }

    void Update()
    {
        
    }
}
