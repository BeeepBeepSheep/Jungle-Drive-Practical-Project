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

                tilesArray[0].transform.position = tileHolder.transform.position;
                for (int placeInArray = 1; placeInArray < tilesArray.Length; placeInArray++)
                {
                    tilesArray[placeInArray].transform.position = tilesArray[placeInArray - 1].transform.GetChild(0).position;
                }

                levelGenirator.nextSpawnPoint = tilesArray[tilesArray.Length - 1].transform.GetChild(0).transform.position; ;
            }
        }
    }
}
