using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GroundSpawner groundSpawnerScript;

    public GameObject obsticleToSpawn;
    public int obsticleIndex;

    public float minTallTreeSize = 1.5f;
    public float maxTallTreeSize = 4f;
    public float minBasicTreeSize = 1f;
    public float maxBasicTreeSize = 3f;
    public float minHugeTreeSize = 1f;
    public float maxHugeTreeSize = 1.5f;

    public GameObject TileHolder;
    public GameObject player;

    public Transform nextTileSpawnPoint;

    public float obsticlesToSpawnAmmount;
    public int minObsticles = 2;
    public int maxObsticles = 5;

    int rockColourIndex;

    public GameObject[] obsticles;
    public Material[] rockColours;
    public Transform[] spawnPoints;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

        groundSpawnerScript = GameObject.FindObjectOfType<GroundSpawner>();

        TileHolder = GameObject.FindGameObjectWithTag("TileHolder");
        transform.parent = TileHolder.transform;
        //player = GameObject.FindGameObjectWithTag("Player");

        obsticlesToSpawnAmmount = Random.Range(minObsticles, maxObsticles);
        obsticlesToSpawnAmmount= Mathf.RoundToInt(obsticlesToSpawnAmmount);

        SpawnObsticles(obsticlesToSpawnAmmount);
    }

    public void MyOnTriggerEnter(Collider col)
    {
        player.transform.parent = transform;
    }
    public void MyOnTriggerExit(Collider collider)
    {
        groundSpawnerScript.SpawnTile();
        Destroy(gameObject, 1);
    }

    void SpawnObsticles(float ammountToSpawn)
    {
        for (int i = 0; i < ammountToSpawn; i++)
        {
            //select obsticle
            obsticleIndex = Random.Range(0, obsticles.Length);
            obsticleToSpawn = obsticles[obsticleIndex];

            //spawn
            GameObject myObsticle = Instantiate(obsticleToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, obsticleToSpawn.transform.rotation);
            myObsticle.transform.parent = transform;

            // random y rotation
            int randdonYRot = Random.Range(0, 360);
            myObsticle.transform.Rotate(Vector3.down * randdonYRot);

            // trees
            if (myObsticle.tag != "tree hugemini" && myObsticle.tag == "rock circle")
            {
                // random y rotation
                int randdonyrot = Random.Range(0, 360);
                myObsticle.transform.Rotate(Vector3.down * randdonyrot);

                //size
                if (myObsticle.tag == "treetall")
                {
                    float curranttreesize = Random.Range(minTallTreeSize, maxTallTreeSize);
                    myObsticle.transform.localScale = new Vector3(curranttreesize, curranttreesize, curranttreesize);
                }

                if (myObsticle.tag == "tree basic")
                {
                    float curranttreesize = Random.Range(minBasicTreeSize, maxBasicTreeSize);
                    myObsticle.transform.localScale = new Vector3(curranttreesize, curranttreesize, curranttreesize);
                }

                if (myObsticle.tag == "tree huge")
                {
                    float curranttreesize = Random.Range(minHugeTreeSize, maxHugeTreeSize);
                    myObsticle.transform.localScale = new Vector3(curranttreesize, curranttreesize, curranttreesize);
                }
            }

            //duckable obsticles 
            if (myObsticle.tag == "tree huge mini" || myObsticle.tag == "rock circle")
            {
                int index = Random.Range(0, 1);
                int yrotation;
                if (index == 0)
                {
                    yrotation = 0;
                }
                else
                {
                    yrotation = 180;
                }
                myObsticle.transform.Rotate(Vector3.down * yrotation);
            }

            if (myObsticle.tag == "Rock Circle" || myObsticle.tag == "Rock")
            {

                rockColourIndex = Random.Range(0, rockColours.Length);
                Material selectedColour = rockColours[rockColourIndex];

                myObsticle.transform.GetChild(0).GetComponent<MeshRenderer>().material = selectedColour;
            }
        }
    }
}