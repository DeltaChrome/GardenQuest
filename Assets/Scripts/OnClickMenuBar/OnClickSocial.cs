using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSocial : MonoBehaviour
{

    public GameObject socialMenu;

    // public void Start()
    // {
    //     shopMenu = GameObject.Find("ShopMenu");
    // }
    
    public void displaySocial()
    {
        socialMenu.SetActive(true);
    }

    public void hideSocial()
    {
        socialMenu.SetActive(false);
    }
}
