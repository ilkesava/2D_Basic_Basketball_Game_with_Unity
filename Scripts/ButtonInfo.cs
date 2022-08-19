using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;
    public Text PriceTXT;
    public GameObject StoreManager;

    // Update is called once per frame
    void Update()
    {
        PriceTXT.text = StoreManager.GetComponent<StoreManager>().storeitems[2, itemID].ToString();
    }
}
