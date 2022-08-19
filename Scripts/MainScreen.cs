using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{

     ButtonHandler handler = new ButtonHandler();
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        PlayerPrefs.SetInt("health", 5);
    }
    public void Credits()
    {
        handler.CreditsChange();
    }
    public void Store()
    {
        handler.StoreChange();
    }
    public void Help()
    {
        handler.HelpChange();
    }
    public void Exite()
    {
        handler.Exit();
    }
    public void Main()
    {
        handler.MainChange();
    }
    public void GameRestart()
    {
        handler.GameRestart();
    }
}
