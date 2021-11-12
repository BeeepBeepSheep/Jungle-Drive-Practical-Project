using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject nextTile;
    public GameObject[] tiles;

    int index;
    Vector3 spawnOrigin;

    Vector3 nextSpawnPoint;
    public int startSpawnTileAmmount = 25;

    public int totalTileAmmount;
    GroundTile groundTileScript;
    //public int obsticleAmmount = 2;

    void Start()
    {
        totalTileAmmount = startSpawnTileAmmount;
        for (int i = 0; i < startSpawnTileAmmount; i++)
        {
            SpawnTile();
        }
    }
    void Update()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    public void SpawnTile()
    {
        index = Random.Range(0, tiles.Length);
        nextTile = tiles[index];
        totalTileAmmount++;

        //spawntile
        GameObject temp = Instantiate(nextTile, nextSpawnPoint + spawnOrigin, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        //obsticles
        //groundTileScript = nextTile.GetComponent<GroundTile>();
        //groundTileScript.SpawnObsticle();
    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }
}
