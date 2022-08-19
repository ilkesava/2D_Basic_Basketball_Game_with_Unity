using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreManager : MonoBehaviour
{
    public int[,] storeitems = new int[10, 10];
    float coins;
    public Text coinsTXT;
    void Start()
    {
        coins = PlayerPrefs.GetInt("gold");
        coinsTXT.text = coins.ToString();
        //ID
        storeitems[1, 1] = 1;
        storeitems[1, 2] = 2;
        storeitems[1, 3] = 3;
        storeitems[1, 4] = 4;
        storeitems[1, 5] = 5;
        storeitems[1, 6] = 6;
        storeitems[1, 7] = 7;
        storeitems[1, 8] = 8;
        storeitems[1, 9] = 9;

        //price
        storeitems[2, 1] = 100;
        storeitems[2, 2] = 100;
        storeitems[2, 3] = 100;
        storeitems[2, 4] = 100;
        storeitems[2, 5] = 100;
        storeitems[2, 6] = 100;
        storeitems[2, 7] = 100;
        storeitems[2, 8] = 100;
        storeitems[2, 9] = 100;

    }


    public void BuyBall()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        Debug.Log("Ball " + ButtonRef.GetComponent<ButtonInfo>().itemID);
        int ballindex =2;

        if (coins >= storeitems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            coins -= storeitems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            if (ButtonRef.GetComponent<ButtonInfo>().itemID == 1)
            {
                ballindex = 0;
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().itemID == 2)
            {
                ballindex = 1;
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().itemID == 4)
            {
                ballindex = 3;
            }
            PlayerPrefs.SetInt("currentBallindex", ballindex);
            PlayerPrefs.SetInt("gold", (int)coins);

            coinsTXT.text = coins.ToString();
        }
    }
    public void BuyHeart()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= storeitems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            coins -= storeitems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            PlayerPrefs.SetInt("gold", (int)coins);

            coinsTXT.text = coins.ToString();
        }
    }
    public void BuyBackGround()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        Debug.Log("BackGround " + ButtonRef.GetComponent<ButtonInfo>().itemID);
        int backgrounindex = 0;
        if (coins >= storeitems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            coins -= storeitems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            if(ButtonRef.GetComponent<ButtonInfo>().itemID == 7)
            {
                backgrounindex = 1;
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().itemID == 8)
            {
                backgrounindex = 2;
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().itemID == 9)
            {
                backgrounindex = 3;
            }
            PlayerPrefs.SetInt("currentBackgroundindex", backgrounindex);
            PlayerPrefs.SetInt("gold", (int)coins);

            coinsTXT.text = coins.ToString();
        }
    }
}
