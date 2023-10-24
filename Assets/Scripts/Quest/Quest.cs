using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest : MonoBehaviour
{
    //enum reward type
    //time remaining
    public int questID = 0;
    public int requiredSteps;
    public int currentSteps = 0;
    public bool completed;
    public bool isActive;

    public GameObject statusObj;
    public GameObject stepCountObj;
    public GameObject detailsPanel;
    public GameObject questManager;
    //private GameObject statusObj;

    public void Start()
    {
        stepCountObj.GetComponent<TMP_Text>().text = requiredSteps.ToString() + " Steps";
    }

    public void onQuestClick()
    {
        //open details panel
        detailsPanel.SetActive(true);

        GameObject requiredStepsObj = detailsPanel.transform.Find("DistanceText").gameObject;
        requiredStepsObj.GetComponent<TMP_Text>().text = requiredSteps.ToString() + " Steps";

        if(completed)
        {
            //something with the button
            //maybe deactivate
        }
    }

    public void closePanel()
    {
        detailsPanel.SetActive(false);
    }

    public void setActiveQuest()
    {
        isActive = true;
        setStatus(true);

        questManager.GetComponent<QuestManagerScript>().setActiveQuest(gameObject);
        closePanel();
    }

    public void setStatus(bool active)
    {
        if(active)
        {
            statusObj.GetComponent<TMP_Text>().text = "Active";
        }
    }

    public void updateSteps(int steps)
    {
        currentSteps = steps;
        stepCountObj.GetComponent<TMP_Text>().text = currentSteps.ToString() + "/" + requiredSteps.ToString() + " Steps";
    }

    public void Update()
    {
        //update remaining time
    }
}
