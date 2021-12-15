using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintTransfer : MonoBehaviour
{

    public Material selectedPrimary;
    public Material selectedSecondary;
    public GameObject target;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Play")
        {
            target = GameObject.Find("CarPhysiscs");
            target.GetComponent<GetCostomization>().primaryMat = selectedPrimary;
            target.GetComponent<GetCostomization>().secondaryMat = selectedSecondary;
            target.GetComponent<GetCostomization>().GetSetPaint();
            Destroy(gameObject);
        }
    }
}
