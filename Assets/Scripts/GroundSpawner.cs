using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject nextTile;
    public GameObject lastTile;
    public GameObject[] tiles;

    int index;
    Vector3 spawnOrigin;

    public Vector3 nextSpawnPoint;
    public int startSpawnTileAmmount = 25;

    public int totalTileAmmount;
    GroundTile groundTileScript;
    public bool canSpawnTile = true;
    //public int obsticleAmmount = 2;

    public Transform player;

    void Start()
    {
        totalTileAmmount = startSpawnTileAmmount;
        for (int i = 0; i < startSpawnTileAmmount; i++)
        {
            SpawnTile();
        }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    public void SpawnTile()
    {
        lastTile = nextTile;
        index = Random.Range(0, tiles.Length);
        nextTile = tiles[index];
        totalTileAmmount++;

        //spawntile
        GameObject temp = Instantiate(nextTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;

        player.SetSiblingIndex(totalTileAmmount);

        //obsticles
        //groundTileScript = nextTile.GetComponent<GroundTile>();
        //groundTileScript.SpawnObsticle();
    }
}
