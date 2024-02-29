using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedAreas : MonoBehaviour, IDataPersistance
{
    public bool Area1Open;
    public bool Area2Open;
    public bool Area3Open;

    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = (Score)FindObjectOfType(typeof (Score));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.Area1Open = data.Area1Open;
        this.Area2Open = data.Area2Open;
        this.Area3Open = data.Area3Open;
    }

    public void SaveData(ref GameData data)
    {
        data.Area1Open = this.Area1Open;
        data.Area2Open = this.Area2Open;
        data.Area3Open = this.Area3Open;
    }
}
