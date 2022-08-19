using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class CreditsBackButtonHandler : MonoBehaviour
{
	Credits handler = new Credits();
	public void Back()
	{
		handler.ShowChoosen(0);
	}
}
