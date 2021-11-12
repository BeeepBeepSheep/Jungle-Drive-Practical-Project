using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class FloatingOriginFix : MonoBehaviour
{
    public float threshold = 100.0f;
    public GroundSpawner levelGenirator;
    public GameObject tileHolder;
    public GameObject[] tilesArray;

    Vector3 moveDelta;

    public Transform player;
    void Update()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        cameraPosition.y = 0f;

        List<GameObject> tileList = new List<GameObject>();

        if (cameraPosition.magnitude > threshold)
        {
            foreach (Transform child in tileHolder.gameObject.transform)
            {
                tileList.Add(child.gameObject);
                tilesArray = tileList.ToArray();

                //player.SetSiblingIndex(tilesArray.Length);
                //player.position = new Vector3(0, 0, 16);
                Debug.Log("recentering, origin delta = ");
                tilesArray[0].transform.position = tileHolder.transform.position;

                for (int count = 1 /*= 0*/; count < tilesArray.Length ; count++)
                {
                    if(count > 0)
                    { 
                    }
                    tilesArray[count].transform.position = tilesArray[count - 1].transform.GetChild(0).position;
                }

                //player.position = playerSpawn;

                Vector3 originDelta = Vector3.zero + cameraPosition;
                levelGenirator.UpdateSpawnOrigin(originDelta);
                Debug.Log("recentering, origin delta = " + originDelta);

                //foreach (GameObject singleTile in tilesArray)
                //{
                //    singleTile.transform.position -= new Vector3(0, 0, threshold);
                //}
            }
        }
        

        //{

        //    for (int z = 0; z < SceneManager.sceneCount; z++)
        //    {
        //        foreach (GameObject myGameObject in SceneManager.GetSceneAt(z).GetRootGameObjects())
        //        {
        //            myGameObject.transform.position -= cameraPosition;
        //        }
        //    }

        //    Vector3 originDelta = Vector3.zero - cameraPosition;
        //    levelGenirator.UpdateSpawnOrigin(originDelta);
        //    Debug.Log("recentering, origin delta = " + originDelta);
        //}
    }
}
