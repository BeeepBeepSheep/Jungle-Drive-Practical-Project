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

    void Start()
    {
        for (int i = 0; i < startSpawnTileAmmount; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        index = Random.Range(0, tiles.Length);
        nextTile = tiles[index];

        GameObject temp = Instantiate(nextTile, nextSpawnPoint + spawnOrigin, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }
}
