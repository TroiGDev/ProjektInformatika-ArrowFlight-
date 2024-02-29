using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    private LockedAreas lckdAreas;

    private bool IsOpen;

    // Start is called before the first frame update
    void Start()
    {
        lckdAreas = (LockedAreas)FindObjectOfType(typeof (LockedAreas));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeadNewScene(string sceneName)
    {
        //gives the player money and saves, for elaving game before time runs out
        Score score = (Score)FindObjectOfType(typeof (Score));
        if (score != null)
        {score .addMoney(score.score);}
        
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNewArea(int AreaIndex)
    {
        if (AreaIndex == 1)
        {IsOpen = lckdAreas.Area1Open;}

        if (AreaIndex == 2)
        {IsOpen = lckdAreas.Area2Open;}

        if (AreaIndex == 3)
        {IsOpen = lckdAreas.Area3Open;}

        string sceneName = "Arrow" + AreaIndex.ToString();

        if (IsOpen)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (!IsOpen)
        {
            Debug.Log("area closed, purchase first");
        }
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
