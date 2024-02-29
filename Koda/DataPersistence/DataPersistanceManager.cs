using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("Saving")]
    public float time;
    private float curTime;
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistance> dataPersistanceObjects;
    private FileDataHandler dataHandler;

    public static DataPersistanceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Error: Found more than one DataPersistanceManager in this scene.");
        }
        instance = this;
    }

    private void Update()
    {
        curTime += 1 * Time.deltaTime;
        if (curTime > time)
        {
            curTime = 0;
            SaveGame();
        }
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);   //keep in mind: application.persiste... points to a location on the machine
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();                      // depending on os it might change - possible error when going into android and ios
        LoadGame();                                                        //VERY POSSIBLE :https://www.youtube.com/watch?v=aUi9aijvpgs  -- time- 15.40-
    }
                       //possible solution, the data isnt stored to the right file, to check we have to find that file, FileDataHandler line 25 logs the "fullPath"
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //load any game data from other file using missing<data handler>
        this.gameData = dataHandler.Load();

        //if no game data found, initialize to a new game
        if (this.gameData == null)
        {
            Debug.Log("LoadError: No data was found in this scene. Initalizing to Defaults.");
            NewGame();
        }

        //push the game data to missing<> other script
        foreach (IDataPersistance DataPersistanceObj in dataPersistanceObjects)
        {
            DataPersistanceObj.LoadData(gameData);
        }

        Debug.Log("Loaded High Score = " + gameData.highScore);

    }

    public void SaveGame()
    {
        //todo : pass the data to other scripts so they can update it
        foreach (IDataPersistance DataPersistanceObj in dataPersistanceObjects)
        {
            DataPersistanceObj.SaveData(ref gameData);
        }

        //todo : save data to a file using missing<data handler>
        dataHandler.Save(gameData);

        Debug.Log("Saved High Score = " + gameData.highScore);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void QuitApp()
    {
        SaveGame();
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}


// to call certain functions in game (using pos, buttons, time, interface ...) use DataPersistanceManager.instance.<NewGame();>
// for now it will be set for game closed and game opened