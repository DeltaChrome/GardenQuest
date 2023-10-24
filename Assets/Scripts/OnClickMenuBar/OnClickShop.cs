using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickShop : MonoBehaviour
{

    public GameObject shopMenu;

    // public void Start()
    // {
    //     shopMenu = GameObject.Find("ShopMenu");
    // }
    
    public void displayShop()
    {
        shopMenu.SetActive(true);
    }

    public void hideShop()
    {
        shopMenu.SetActive(false);
    }
}
