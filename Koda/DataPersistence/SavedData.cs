using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//has all saved information, we do this so we can send from any script to this one and then from this one to json


public class SavedData : MonoBehaviour, IDataPersistance
{
    public float highScore;      //from Score script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.highScore = data.highScore;
    }

    public void SaveData(ref GameData data)
    {
        data.highScore = this.highScore;
    }
}
