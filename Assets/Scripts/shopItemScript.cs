using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shopItemScript : MonoBehaviour//needs to implement data interface for saving ID and has been purchased
{

    //public image icon;
    public int price = 0;
    public int ID = 0;

    public string name = "unknown";

    //some item list linked to actual item

    public bool hasBeenPurchased = false;

    public GameObject shopText;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       
        if (hasBeenPurchased)
        {
            shopText.GetComponent<TMP_Text>().text = "Owned";
            /*
            disable onclick events
            change icon to grey or change price to say owned or remove from shop entirely
            */
        }
        else
        {
            shopText.GetComponent<TMP_Text>().text = price.ToString();
        }

    }

    public void shopItemClicked()
    {
        //should make a pop up box to confirm purchase first

        if (!hasBeenPurchased && player.GetComponent<playerData>().money >= price) //&& playerBalance >= price
        {
            hasBeenPurchased = true;
            player.GetComponent<playerData>().money -= price;
            shopText.GetComponent<TMP_Text>().text = "Owned";
            //grey out icon if need be
        }
    }

    public void Update()
    {
        if(hasBeenPurchased)
        {
            //set colour to black
            shopText.GetComponent<TMP_Text>().color = new Color32(10,10,10,255);
            shopText.GetComponent<TMP_Text>().text = "Owned";
        }
        else
        {
            if(player.GetComponent<playerData>().money < price)
            {
                //set colour to red
                shopText.GetComponent<TMP_Text>().color = new Color32(255,20,20,255);

            }
            else
            {
                //set colour to green
                shopText.GetComponent<TMP_Text>().color = new Color32(20,255,20,255);

            }

            shopText.GetComponent<TMP_Text>().text = price.ToString();
        }
    }

}
