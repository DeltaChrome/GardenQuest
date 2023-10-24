using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGoals : MonoBehaviour
{

    public GameObject goalsMenu;
    public GameObject panel;

    // public void Start()
    // {
    //     shopMenu = GameObject.Find("ShopMenu");
    // }
    
    public void displayGoals()
    {
        goalsMenu.SetActive(true);
        panel.SetActive(false);
    }

    public void hideGoals()
    {
        goalsMenu.SetActive(false);
        panel.SetActive(false);

    }
}
