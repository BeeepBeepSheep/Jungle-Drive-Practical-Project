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

    public Transform nextTileSpawnPoint;

    int obsticlesToSpawnAmmount;
    public int minObsticles = 2;
    public int maxObsticles = 5;

    void Start()
    {
        groundSpawnerScript = GameObject.FindObjectOfType<GroundSpawner>();

        TileHolder = GameObject.FindGameObjectWithTag("TileHolder");
        transform.parent = TileHolder.transform;
        player = GameObject.FindGameObjectWithTag("Player");

        obsticlesToSpawnAmmount = Random.Range(minObsticles, maxObsticles);

        SpawnObsticle(obsticlesToSpawnAmmount);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("enter");
        player.transform.parent = transform;
        groundSpawnerScript.SpawnTile();

    }
    //void OnTriggerExit(Collider collider)
    //{
    //    Debug.Log("exit" + collider.transform.name);
    //    groundSpawnerScript.SpawnTile();
    //    Destroy(gameObject,1);
    //}

    void SpawnObsticle(int ammountToSpawn)
    {

        for (int i = minObsticles; i < ammountToSpawn; i++)
        {
            obsticleIndex = Random.Range(0, obsticles.Length);
            obsticleToSpawn = obsticles[obsticleIndex];
            GameObject myObsticle = Instantiate(obsticleToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, obsticleToSpawn.transform.rotation);

            myObsticle.transform.parent = transform;
        }
    }

    //void OnDestroy()
    //{
    //    Debug.Log("destroyed");
    //}
}
