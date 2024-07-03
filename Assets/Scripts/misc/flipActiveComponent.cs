using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipActiveComponent : MonoBehaviour
{
    public void flipActive()
    {
        if(this.gameObject.activeSelf)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);
    }
}
