using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Help : ButtonHandler
{
    public override void ShowChoosen(int which)
    {
        which = 0;
        SceneManager.LoadScene(which);
    }
}
