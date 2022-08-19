using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using System;

public class Credits : ButtonHandler
{
   
	public override void ShowChoosen(int which)
    {
        which = 0;
        SceneManager.LoadScene(which);
    }
	
	
}