using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGarden : MonoBehaviour
{

    public GameObject GardenMenu;
    public GameObject GlobalBackground;

    // public void Start()
    // {
    //     GardenMenu = GameObject.Find("GardenMenu");
    // }
    
    public void displayGarden()
    {
        GardenMenu.SetActive(true);
        GlobalBackground.SetActive(false);
    }

    public void hideGarden()
    {
        GlobalBackground.SetActive(true);
        GardenMenu.SetActive(false);
    }
}
