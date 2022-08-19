using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpHandle : MonoBehaviour
{
    // Start is called before the first frame update
    Help handler = new Help();
    public void Back()
    {
        handler.ShowChoosen(0);
    }
}
