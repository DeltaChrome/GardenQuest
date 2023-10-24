using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadManageMenus : MonoBehaviour
{
    public GameObject[] menus;

    public void deActivateMenus()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }
}
