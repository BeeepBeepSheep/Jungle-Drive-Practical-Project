using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject lockedIcon;
    public GameObject unlockedIcon;
    void Start()
    {
        
    }

    public void HoverShowUnlock()
    {
        lockedIcon.SetActive(false);
        unlockedIcon.SetActive(true);
    }
    public void UnhoverShowLock()
    {
        lockedIcon.SetActive(true);
        unlockedIcon.SetActive(false);
    }
}
