using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerData : MonoBehaviour, IDataPersistence
{
    
    public GameObject moneyObj;
    private TMP_Text moneyText;

    public int money;
    //garden stuff probably

    public void Start()
    {
        moneyText = moneyObj.GetComponent<TMP_Text>();
    }

    public void LoadData(GameData data)
    {
        this.money = data.playerBalance;
    }

    public void SaveData(ref GameData data)
    {
        //data.totalStepCount = this.steps;
        data.playerBalance = this.money;
    }

    public void Update()
    {
        moneyText.text = money.ToString();
    }

}
