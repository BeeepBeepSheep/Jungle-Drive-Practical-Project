using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointLoaction : MonoBehaviour
{
    public Transform target;

    void Awake()
    {
        transform.position = target.position;
    }
}
