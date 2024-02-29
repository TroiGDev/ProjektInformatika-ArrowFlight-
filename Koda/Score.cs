using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//to save adn load data do the following:
/*
in scene a datapersistance manager script whould be active

the cript with the info should have the IDataPersistance
it should also contain a loda and save data function to get called
   (the functions should have the info get saved to GameData)
*/

public class Score : MonoBehaviour, IDataPersistance
{
    public bool sceneIsGame;

    [Header("common")]
    public float time;
    public float score;
    public float highScore;
    public float enemyNum;
    public float money;
    public float arrowNum;
    public float addedTime;
    public float addedMoney;

    public TextMeshProUGUI time_txt;
    public TextMeshProUGUI time_txt_shadow;

    public TextMeshProUGUI arrow_txt;

    public TextMeshProUGUI score_txt;
    public TextMeshProUGUI score_txt_shadow;

    public TextMeshProUGUI highScore_txt;
    public TextMeshProUGUI highScore_txt_shadow;

    public TextMeshProUGUI money_txt;
    public TextMeshProUGUI money_txt_shadow;

    private float previousMoney; //to check if last frames money isnt the current one/ need to save data

    [Header("player")]
    public HealthManager hlthMngr;

    // Start is called before the first frame update
    void Start()
    {
        hlthMngr = (HealthManager)FindObjectOfType(typeof (HealthManager));
    }

    // Update is called once per frame
    void Update()
    {
        //saves game when money isnt equal/a save is needed
        DataPersistanceManager dataMngr = (DataPersistanceManager)FindObjectOfType(typeof (DataPersistanceManager));
        if (previousMoney != money)
        {dataMngr.SaveGame();}
        previousMoney = money;

        if (score > highScore)
        {
            highScore = score;
        }

        //display value on text if text is present,         area menu has only money
        if (sceneIsGame)
        {time -= 1 * Time.deltaTime;}

        if (time_txt != null)
        {float finalValue = Mathf.RoundToInt(time * 10);
        finalValue = finalValue / 10;
        time_txt.text = finalValue.ToString();
        time_txt_shadow.text = finalValue.ToString();}
        

        if (score_txt != null)
        {score_txt.text = score.ToString();
        score_txt_shadow.text = score.ToString();}

        if (highScore_txt != null)
        {highScore_txt.text = highScore.ToString();
        highScore_txt_shadow.text = highScore.ToString();}

        if (arrow_txt != null)
        {arrow_txt.text = arrowNum.ToString();}

        if (money_txt != null)
        {money_txt.text = money.ToString();
        money_txt_shadow.text = money.ToString();}

        /*
        //gets any active arrow in scene
        GameObject activeArrow = GameObject.FindGameObjectWithTag("Arrow");
        
        //if no arrows left and no arrow active(to teleport to), reset and send to spawn point
        if (arrowNum <= 0 && activeArrow == null)
        {
            addMoney(score);
            score = 0;
            arrowNum = 10;
            time = 30;
            hlthMngr.gameObject.transform.position = hlthMngr.spawnPoint;
        }
        
        if (arrowNum > 30)
        {
            arrowNum = 30;
        }
        */

        if (time < 0 && sceneIsGame)
        {
            score = 0;
            arrowNum = 10;
            time = 10;
            hlthMngr.gameObject.transform.position = hlthMngr.spawnPoint;
        }
    }

    public void addMoney(float amount)
    {
        DataPersistanceManager dataMngr = (DataPersistanceManager)FindObjectOfType(typeof (DataPersistanceManager));
        money += amount;
        dataMngr.SaveGame();
    }

    public void LoadData(GameData data)
    {
        this.highScore = data.highScore;
        this.money = data.money;
    }

    public void SaveData(ref GameData data)
    {
        data.highScore = this.highScore;
        data.money = this.money;
    }
}
