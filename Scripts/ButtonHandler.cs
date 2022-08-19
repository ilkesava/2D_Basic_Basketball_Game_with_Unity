using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler
{
    int flag;


    public void StoreChange()
    {
        flag = 1;
        ShowChoosen(flag);
    }
    public void CreditsChange()
    {
        flag = 2;
        ShowChoosen(flag);
    }
    public void HelpChange()
    {
        flag = 3;
        ShowChoosen(flag);
    }
    public void MainChange()
    {
        flag = 0;
        ShowChoosen(flag);
    }
    public void GameRestart()
    {
        flag = 4;
        ShowChoosen(flag);
    }
    public virtual void ShowChoosen(int which)
    {
        SceneManager.LoadScene(which);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
