using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int totalStepCount;
    public int playerBalance;
    //public items inventoryItems;
    //public shopItems
    //public bool[] purchasedItemsIDs = new bool[] {};
    public List<bool> purchasedItemsIDs = new List<bool>();
    //public Quest currentQuest;

    //From Quest
    public int requiredSteps;
    public int currentSteps;
    public bool completed;
    public bool activeQuest;
    public int questID;
    public int activeQuestID;

    //default values
    public GameData()
    {
        this.totalStepCount = 0;
        this.playerBalance = 0;
        this.requiredSteps = 0;
        this.currentSteps = 0;
        this.activeQuestID = 0;
        this.completed = false;
        this.activeQuest = false;
        this.questID = 0;
        for (int i = 0; i < 25; ++i)
        {
            this.purchasedItemsIDs.Add(false);
        }
    }
}
