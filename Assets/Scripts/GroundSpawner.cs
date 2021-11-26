using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject nextTile;
    public GameObject[] tiles;

    int index;
    Vector3 spawnOrigin;

    public Vector3 nextSpawnPoint;
    public int startSpawnTileAmmount = 25;

    public int totalTileAmmount;
    public bool canSpawnTile = true;

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
        index = Random.Range(0, tiles.Length);
        nextTile = tiles[index];
        totalTileAmmount++;

        //spawntile
        GameObject temp = Instantiate(nextTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.GetComponent<GroundTile>().nextTileSpawnPoint.position; /* transform.GetChild(0).transform.position;*/

        player.SetSiblingIndex(totalTileAmmount);
    }
}
