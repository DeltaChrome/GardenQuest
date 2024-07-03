//https://www.reddit.com/r/Unity3D/comments/wjrg5q/how_to_use_the_pedometerstepcounter_sensor/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Android;
using TMPro;

public class pedManager : MonoBehaviour, IDataPersistence
{
    public InputAction stepAction;
    public int steps;
    int startSteps = 0;
    int deltaSteps = 0;
    int lastSteps = 0;
    public bool trackSteps = false;

    public TMP_Text textMesh;

    void Awake()
    {
        RequestPermission();
    }

    public void LoadData(GameData data)
    {
        this.steps = data.totalStepCount;
    }

    public void SaveData(ref GameData data)
    {
        data.totalStepCount = this.steps;
    }

    // Start is called before the first frame update
    void Start()
    {
        InputSystem.EnableDevice(AndroidStepCounter.current);

        AndroidStepCounter.current.MakeCurrent();

        //steps = 0;
    }

    async void RequestPermission()
    {
        AndroidRuntimePermissions.Permission result = await AndroidRuntimePermissions.RequestPermissionAsync( "android.permission.ACTIVITY_RECOGNITION" );
        //AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission( "android.permission.ACCESS_FINE_LOCATION" ); // Synchronous version (not recommended)
        if( result == AndroidRuntimePermissions.Permission.Granted )
            Debug.Log( "We have permission to access fine location!" );
        else
            Debug.Log( "Permission state: " + result );

        // Requesting ACCESS_FINE_LOCATION and CAMERA permissions simultaneously
        //AndroidRuntimePermissions.Permission[] result = await AndroidRuntimePermissions.RequestPermissionsAsync( "android.permission.ACCESS_FINE_LOCATION", "android.permission.CAMERA" );
        //if( result[0] == AndroidRuntimePermissions.Permission.Granted && result[1] == AndroidRuntimePermissions.Permission.Granted )
        //	Debug.Log( "We have all the permissions!" );
        //else
        //	Debug.Log( "Some permission(s) are not granted..." );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startSteps == 0)
        {
            startSteps = AndroidStepCounter.current.stepCounter.ReadValue();
            lastSteps = startSteps;
            Debug.Log( "StartSteps: " + startSteps );
            return;
        }

        if(trackSteps)
        {
            deltaSteps = AndroidStepCounter.current.stepCounter.ReadValue() - lastSteps;

            steps += deltaSteps;

            lastSteps = AndroidStepCounter.current.stepCounter.ReadValue();
        }
        
        //steps += 1;

        textMesh.text = steps.ToString();
    }

    public int getSteps()
    {
        return steps;
    }
}
