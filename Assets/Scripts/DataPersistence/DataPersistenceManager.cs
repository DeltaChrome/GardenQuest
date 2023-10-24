using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistanceObjects = new List<IDataPersistence>();
    private FileDataHandler dataHandler;
    private string filePathFriendly;
    public GameObject loadingObj;

    public static DataPersistenceManager instance  {get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple Data Persistance Managers detected.");
        }
        instance = this;
    }

    private void Start()
    {
        //this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        filePathFriendly = GetAndroidFriendlyFilesPath();
        //filePathFriendly = "Assets/Saves/";
        this.dataHandler = new FileDataHandler(filePathFriendly, fileName);
        this.dataPersistanceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        
        if (this.gameData == null)
        {
            Debug.Log("No game data found, creating new game with defaults.");
            NewGame();
        }

        foreach (IDataPersistence dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

        Debug.Log("Loaded Step Count: " + gameData.totalStepCount);

        //load finished
        loadingObj.GetComponent<loadManageMenus>().deActivateMenus();
        loadingObj.SetActive(false);
        Debug.Log("Load finished");

    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        // Debug.Log("Saved Step Count: " + gameData.totalStepCount);
        // Debug.Log("Saved Step Count to: " + filePathFriendly);

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationPause()
    {
        SaveGame();
    }

    // private void OnApplicationFocus()
    // {
    //     SaveGame();
    // }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistanceObjects);
    }

    private static string GetAndroidFriendlyFilesPath()
    {
            #if UNITY_ANDROID
                AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject applicationContext = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
                AndroidJavaObject path = applicationContext.Call<AndroidJavaObject>("getFilesDir");
                string filesPath = path.Call<string>("getCanonicalPath");
                Debug.Log("Saving with java call stuff");

                return filesPath;
            #endif
            return Application.persistentDataPath;
    }

    private static string GetAndroidFriendlyCachePath()
    {
        #if UNITY_ANDROID
            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject applicationContext = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
            AndroidJavaObject path = applicationContext.Call<AndroidJavaObject>("getCacheDir");
            string filesPath = path.Call<string>("getCanonicalPath");
            return filesPath;
        #endif
        return Application.temporaryCachePath;
    }
}
