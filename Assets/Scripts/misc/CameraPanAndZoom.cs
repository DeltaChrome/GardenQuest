using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanAndZoom : MonoBehaviour
{
    public Camera cam;
    private Vector3 camPosition;
    private float width;
    private float height;
    private Vector2 startPos;
    private Vector2 direction;
    private float movementScale = 0.45f;

    // Start is called before the first frame update
    void Start()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
        startPos = new Vector2 (0.0f, 0.0f);
        //nextPos = new Vector2 (0.0f, 0.0f);
        direction = new Vector2 (0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount == 1)
        {
            Debug.Log("One touch");
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;
                    Debug.Log("Started touch");
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    direction *= movementScale;
                    Debug.Log(direction);
                    camPosition += new Vector3 (-direction.x, -direction.y, 0);
                    cam.transform.position = new Vector3 (camPosition.x, camPosition.y, cam.transform.position.z);;
                    startPos = touch.position;
                    
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    Debug.Log("Ended touch");
                    
                    break;
            }
        }
       
        if(Input.touchCount >= 2)
        {
            Debug.Log("Two plus touches");
        }

    }
}
