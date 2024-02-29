using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//has all info acctualy stored

[System.Serializable]
public class GameData
{
    public float highScore;
    public float money;

    public bool Area1Open;
    public bool Area2Open;
    public bool Area3Open;

    //defines default values for when a new game is started
    public GameData()
    {
        this.highScore = 0;
        this.money = 0;

        this.Area1Open = true;
        this.Area2Open = false;
        this.Area3Open = false;
    }
}
