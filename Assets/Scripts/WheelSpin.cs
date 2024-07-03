using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    public GameObject wheel;
    public Animator animator;
    public GameObject reward;

    float degrees = 0.0f;
    bool isMaxSpinSpeed = false;
    bool isStartSpin = false;
    bool isEndSpin = false;

    Transform transformStart;
    Transform transformEnd;

    float lerpSpeed = 0.01f;
    float lerpTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        isMaxSpinSpeed =  false;
        isEndSpin = false;
        //reward.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if(isMaxSpinSpeed)
            wheel.transform.Rotate(0.0f, 0.0f, -lerpSpeed, Space.Self);

        if(isEndSpin)
        {
            lerpSpeed -= Mathf.Sqrt(lerpSpeed) * 0.5f;
            if (lerpSpeed <= 0.05f)
            {
                lerpSpeed = 0.0f;
                //display random reward
                //reward.SetActive(true);
            }
        }
    }

    public void startSpin()
    {
        isMaxSpinSpeed =  false;
        isEndSpin = false;
        animator.SetTrigger("Tr_StartSpin");
        lerpTime = 0.0f;
        lerpSpeed = 40.0f;
    }

    void enableMaxSpin()
    {
        isMaxSpinSpeed = true;
    }

    void disableMaxSpin()
    {
        isMaxSpinSpeed = false;
    }

    public void endSpin()
    {
        //disableMaxSpin();
        // transformStart = wheel.transform;
        // transformEnd = transformStart;
        // transformEnd.Rotate(0.0f, 0.0f, -180.0f, Space.Self);

        isEndSpin = true;
        lerpSpeed = 40.0f;
        lerpTime = 0.0f;      
    }

}
