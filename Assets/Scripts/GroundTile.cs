using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GroundSpawner groundSpawnerScript;

    public GameObject[] obsticles;
    public GameObject obsticleToSpawn;
    public int obsticleIndex;
    public Transform[] spawnPoints;
    public GameObject TileHolder;
    public GameObject player;
    //public int minObsticles = 2;
    void Start()
    {
        groundSpawnerScript = GameObject.FindObjectOfType<GroundSpawner>();
        //transform.parent = groundSpawnerScript.transform;
        //SpawnObsticle(/*1*/);
        TileHolder = GameObject.FindGameObjectWithTag("TileHolder");
        transform.parent = TileHolder.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter(Collider col)
    {
        player.transform.parent = transform;
    }
    void OnTriggerExit(Collider collider)
    {
        groundSpawnerScript.SpawnTile();
        Destroy(gameObject,1);
    }

    //public void SpawnObsticle(/*int minObsticles*/)
    //{
    //    //obsticleIndex = Random.Range(0, spawnPoints.Length);
    //    //obsticleToSpawn = obsticles[obsticleIndex];
    //    Instantiate(obsticleToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, obsticleToSpawn.transform.rotation);
    //}
}
