using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject nextTile;

    int index;
    Vector3 spawnOrigin;

    public Vector3 nextSpawnPoint;
    public int startSpawnTileAmmount = 25;

    public int totalTileAmmount;
    public bool canSpawnTile = true;

    public GameObject player;
    public Transform tileHolder;

    public GameObject[] tiles;

    public Transform firstTile;
    public GroundTile firstTileScript;

    void Start()
    {
        totalTileAmmount = startSpawnTileAmmount;
        nextSpawnPoint = tileHolder.position;

        SpawnTile();

        for (int i = 0; i < startSpawnTileAmmount - 1; i++)
        {
            SpawnTile();
        }

        //firstTile = tileHolder.transform.GetChild(1).transform;
        //firstTileScript = firstTile.GetComponent<GroundTile>();
        //firstTileScript.MyOnTriggerEnter(null);
    }

    public void SpawnTile()
    {
        index = Random.Range(0, tiles.Length);
        nextTile = tiles[index];
        totalTileAmmount++;

        //spawntile
        GameObject temp = Instantiate(nextTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.GetComponent<GroundTile>().nextTileSpawnPoint.position;
        temp.GetComponent<GroundTile>().player = player;
        player.transform.SetSiblingIndex(totalTileAmmount);
    }
}
