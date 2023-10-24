using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGarden : MonoBehaviour
{

    public GameObject GardenMenu;

    // public void Start()
    // {
    //     GardenMenu = GameObject.Find("GardenMenu");
    // }
    
    public void displayGarden()
    {
        GardenMenu.SetActive(true);
    }

    public void hideGarden()
    {
        GardenMenu.SetActive(false);
    }
}
