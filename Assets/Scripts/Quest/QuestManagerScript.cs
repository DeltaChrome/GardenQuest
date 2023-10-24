using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManagerScript : MonoBehaviour, IDataPersistence
{

    //Active Quest
    public GameObject activeQuestObj;
    public GameObject questListObj;
    public GameObject ped;
    private pedManager pManager;
    private Quest currentQuest = new Quest();
    private bool loaded = false;

    private int activeQuestID;

    // Start is called before the first frame update
    void Start()
    {
        pManager = ped.GetComponent<pedManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //activeQuest.
        if(currentQuest.isActive && loaded == true)
        {
            pManager.trackSteps = true;
            currentQuest.updateSteps(pManager.getSteps());
        }
        //if compeleted
    }

    public void setActiveQuest(GameObject aQuestObj)//comes from quest because shits wack
    {
        activeQuestObj = aQuestObj;//set game object to current quest object
        currentQuest = activeQuestObj.GetComponent<Quest>();//set current quest class instance to the new active quest
        pManager.trackSteps = true;
    }

    public void LoadData(GameData data)
    {
        //get ID of quest
        activeQuestID = data.questID;

        activeQuestObj = questListObj.transform.GetChild(activeQuestID).gameObject;//find quest with ID
        currentQuest = activeQuestObj.GetComponent<Quest>();

        this.currentQuest.requiredSteps = data.requiredSteps;
        this.currentQuest.currentSteps = data.currentSteps;
        this.currentQuest.completed = data.completed;
        this.currentQuest.isActive = data.activeQuest;
        this.currentQuest.questID = data.questID;

        if(data.activeQuest)
        {
            currentQuest.setStatus(true);
            //pManager.trackSteps = true;
        }

        loaded = true;

        //pManager.trackSteps = true;

    }

    public void SaveData(ref GameData data)
    {
        data.requiredSteps = this.currentQuest.requiredSteps;
        data.currentSteps = this.currentQuest.currentSteps;
        data.completed = this.currentQuest.completed;
        data.activeQuest = this.currentQuest.isActive;
        data.questID = this.currentQuest.questID;
    }
}
