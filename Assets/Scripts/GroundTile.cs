using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawnerScript;

    public GameObject[] obsticles;
    public GameObject obsticleToSpawn;
    public int obsticleIndex;
    public Transform[] spawnPoints;
    //public int minObsticles = 2;
    void Start()
    {
        groundSpawnerScript = GameObject.FindObjectOfType<GroundSpawner>();
        transform.parent = groundSpawnerScript.transform;
        //SpawnObsticle(/*1*/);
    }

    void OnTriggerExit(Collider collider)
    {
        groundSpawnerScript.SpawnTile();
        Destroy(gameObject);
    }

    public void SpawnObsticle(/*int minObsticles*/)
    {
        //obsticleIndex = Random.Range(0, spawnPoints.Length);
        //obsticleToSpawn = obsticles[obsticleIndex];
        Instantiate(obsticleToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, obsticleToSpawn.transform.rotation);
        //obsticleToSpawn.transform.parent = groundSpawnerScript.tileEquivolent.transform;
    }
}
