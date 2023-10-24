using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStepsBtn : MonoBehaviour
{

    public GameObject pedObj;
    public GameObject playerObj;
    public GameObject[] shopItems;

    public void onClickPed()
    {
        pedManager ped = pedObj.GetComponent<pedManager>();
        ped.steps = 0;

        playerObj.GetComponent<playerData>().money = 1450;

        for (int i = 0; i < shopItems.Length; i++)
        {
            shopItems[i].GetComponent<shopItemScript>().hasBeenPurchased = false;
        }
        
    }

}
