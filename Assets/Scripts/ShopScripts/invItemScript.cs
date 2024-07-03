using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class invItemScript : MonoBehaviour//needs to implement data interface for saving ID and has been purchased
{

    //public image icon;
    public int quantity = 0;
    public int ID = 0;

    public string name = "unknown";

    //some item list linked to actual item

    public GameObject quantityText;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       
        //load save data for quantity

    }

    public void invItemClicked()
    {
        //activate tile selection mode, with this item as item to be placed

    }

    public void Update()
    {
        //update quantity text

        // if(hasBeenPurchased)
        // {
        //     //set colour to black
        //     quantityText.GetComponent<TMP_Text>().color = new Color32(10,10,10,255);
        //     quantityText.GetComponent<TMP_Text>().text = "Owned";
        // }
        // else
        // {
        //     if(player.GetComponent<playerData>().money < price)
        //     {
        //         //set colour to red
        //         quantityText.GetComponent<TMP_Text>().color = new Color32(255,20,20,255);

        //     }
        //     else
        //     {
        //         //set colour to green
        //         quantityText.GetComponent<TMP_Text>().color = new Color32(20,255,20,255);

        //     }

        //     quantityText.GetComponent<TMP_Text>().text = price.ToString();
        // }
    }

    

}
