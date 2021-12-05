using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollider : MonoBehaviour
{

    public GroundTile hostScript;
    public int spawnAmmount = 10;
    public int chanceForChestSpawn = 5;
    int chance;
    public float spawnHeight = 5f;
    public GameObject coin;
    public GameObject chest;

    void Start()
    {
        SpawnCollectables();
    }
    void SpawnCollectables()
    {
        for (int i = 0; i < spawnAmmount; i++)
        {
            GameObject objectToSpawn;

            chance = Random.Range(0, 100);
            if (chance <= chanceForChestSpawn)
            {
                objectToSpawn = chest;
            }
            else
            {
                objectToSpawn = coin;
            }

            GameObject temp = Instantiate(objectToSpawn);
            temp.transform.parent = transform;
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());

        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3
            (
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        // if point is outside collider
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = spawnHeight;
        return point;
    }


    //player parent logic
    void OnTriggerEnter(Collider col)
    {
        hostScript.MyOnTriggerEnter(col);
    }
    void OnTriggerExit(Collider collider)
    {
        hostScript.MyOnTriggerExit(collider);
    }
}
