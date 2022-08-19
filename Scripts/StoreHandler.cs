using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    Store handler = new Store();
    public void Back()
    {
        handler.ShowChoosen(0);
    }
}
