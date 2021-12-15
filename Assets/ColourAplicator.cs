using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourAplicator : MonoBehaviour
{
    public Material selectedMaterial;
    public Material primary;
    public Material secondary;

    public Material defaultRed;
    public Material defaultRed2;
    public Material green;
    public Material green2;
    public Material blue;
    public Material blue2;
    public Material purple;
    public Material orrange;

    public Material black;
    public Material white;
    public Material pink;
    public Material silver;

    public Material gold;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetPrimary()
    {
        primary = selectedMaterial;
        gameObject.SetActive(false);
    }
    public void SetSecondary()
    {
        secondary = selectedMaterial;
        gameObject.SetActive(false);
    }

    public void RedSelect()
    {
        selectedMaterial = defaultRed;
    }
    public void Red2Select()
    {
        selectedMaterial = defaultRed2;
    }
    public void GreenSelect()
    {
        selectedMaterial = green;
    }
    public void Green2Select()
    {
        selectedMaterial = green2;
    }
    public void BlueSelect()
    {
        selectedMaterial = blue;
    }
    public void Blue2Select()
    {
        selectedMaterial = blue2;
    }
    public void PurpleSelect()
    {
        selectedMaterial = purple;
    }
    public void OrrangeSelect()
    {
        selectedMaterial = orrange;
    }
    public void BlackSelect()
    {
        selectedMaterial = black;
    }
    public void WhiteSelect()
    {
        selectedMaterial = white;
    }
    public void PinkSelect()
    {
        selectedMaterial = pink;
    }
    public void SilverSelect()
    {
        selectedMaterial = silver;
    }
    public void GoldSelect()
    {
        selectedMaterial = gold;
    }
}
