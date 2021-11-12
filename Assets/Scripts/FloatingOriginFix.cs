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
    public Transform[] allTiles;

    void LateUpdate()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        cameraPosition.y = 0f;

        List<GameObject> tiles = new List<GameObject>();

        if (cameraPosition.magnitude > threshold)
        {
            foreach (Transform child in tileHolder.gameObject.transform)
            {
                tiles.Add(child.gameObject);
                allTiles = tiles.ToArray();
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
