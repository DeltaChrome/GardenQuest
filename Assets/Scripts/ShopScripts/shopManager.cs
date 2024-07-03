using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour, IDataPersistence
{
    
    public GameObject[] shopItems;

    public void LoadData(GameData data)
    {
        //this.steps = data.totalStepCount;
        for (int i = 0; i < shopItems.Length; i++)
        {
            //shopItems[i].GetComponent<shopItemScript>().hasBeenPurchased = false;
            shopItems[i].GetComponent<shopItemScript>().hasBeenPurchased = data.purchasedItemsIDs[i];
            //Debug.Log("ON LOAD data.purchasedItemsIDs[i] = " + data.purchasedItemsIDs[i]);
        }
    }

    public void SaveData(ref GameData data)
    {
        //data.totalStepCount = this.steps;

        for (int i = 0; i < shopItems.Length; i++)
        {
            data.purchasedItemsIDs[i] = shopItems[i].GetComponent<shopItemScript>().hasBeenPurchased;
            //Debug.Log("ON SAVE data.purchasedItemsIDs[i] = " + data.purchasedItemsIDs[i]);
        }
    }
}
