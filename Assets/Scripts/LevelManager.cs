using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper; //scorekeeper referance

    public void LoadGame() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.ResetScore(); // for resetting score before new game
        SceneManager.LoadScene("Game"); // load scene named Game
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void LoadEnding()
    {
        SceneManager.LoadScene("Ending");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..."); // to control while in unity
        Application.Quit();
    }

}
