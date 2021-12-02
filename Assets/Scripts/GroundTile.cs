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

    public int obsticlesToSpawnAmmount;
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

        //obsticlesToSpawnAmmount = Random.Range(minObsticles, maxObsticles);

        SpawnObsticles(/*obsticlesToSpawnAmmount*/ 1);
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

    void SpawnObsticles(int ammountToSpawn)
    {
        for (int i = minObsticles; i < ammountToSpawn; i++)
        {
            obsticleIndex = Random.Range(0, obsticles.Length);
            obsticleToSpawn = obsticles[obsticleIndex];
            GameObject myObsticle = Instantiate(obsticleToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, obsticleToSpawn.transform.rotation);

            myObsticle.transform.parent = transform;
            // random y rotation
            int randdonYRot = Random.Range(0, 360);
            myObsticle.transform.Rotate(Vector3.down * randdonYRot);

            //// trees
            //if (myObsticle.tag != "Tree HugeMini" && myObsticle.tag == "Rock Circle")
            //{
            //    // random y rotation
            //    int randdonYRot = Random.Range(0, 360);
            //    myObsticle.transform.Rotate(Vector3.down * randdonYRot);

            //    //size
            //    if (myObsticle.tag == "TreeTall")
            //    {
            //        float currantTreeSize = Random.Range(minTallTreeSize, maxTallTreeSize);
            //        myObsticle.transform.localScale = new Vector3(currantTreeSize, currantTreeSize, currantTreeSize);
            //    }

            //    if (myObsticle.tag == "Tree Basic")
            //    {
            //        float currantTreeSize = Random.Range(minBasicTreeSize, maxBasicTreeSize);
            //        myObsticle.transform.localScale = new Vector3(currantTreeSize, currantTreeSize, currantTreeSize);
            //    }

            //    if (myObsticle.tag == "Tree Huge")
            //    {
            //        float currantTreeSize = Random.Range(minHugeTreeSize, maxHugeTreeSize);
            //        myObsticle.transform.localScale = new Vector3(currantTreeSize, currantTreeSize, currantTreeSize);
            //    }
            //}

            ////duckable obsticles 
            //if (myObsticle.tag == "Tree Huge Mini" || myObsticle.tag == "Rock Circle")
            //{
            //    int index = Random.Range(0, 1);
            //    int yRotation;
            //    if (index == 0)
            //    {
            //        yRotation = 0;
            //    }
            //    else
            //    {
            //        yRotation = 180;
            //    }
            //    myObsticle.transform.Rotate(Vector3.down * yRotation);
            //}

            if (myObsticle.tag == "Rock Circle" || myObsticle.tag == "Rock")
            {

                rockColourIndex = Random.Range(0, rockColours.Length);
                Material selectedColour = rockColours[rockColourIndex];

                myObsticle.transform.GetChild(0).GetComponent<MeshRenderer>().material = selectedColour;
            }
        }
    }
}