using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0; //private to prevent accidents
    static ScoreKeeper instance;

    public ScoreKeeper GetInstance()
    {
        return instance;
    }

    public int GetScore() // score getter
    {
        return score;
    }

    void Awake()
    {
        ManageSingleton(); //singleton for keeping score through game
    }

    void ManageSingleton()// singleton body
    {
        
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score,0 , int.MaxValue); //keeping score between 0 and max int values to prevent errors
        //Debug.Log(score);
        
    }
    public void ResetScore() // to reset score
    {
        score = 0;
    }





}
