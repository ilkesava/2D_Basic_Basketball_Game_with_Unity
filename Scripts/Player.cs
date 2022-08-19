using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public int currentHealth;
	public int currentGold;
	public int currentLevel;
	public int currentBallindex;
	public int currentBackgroundindex;
	public int flag;
	private Text levelText;
	private Text goldText;

	public PlayerInfo PlayerInfo { get; private set; }
	
	private void Awake()
	{
		levelText = transform.Find("levelText").GetComponent<Text>();
		goldText = transform.Find("GoldText").GetComponent<Text>();
		goldText.text = "Gold " + (PlayerPrefs.GetInt("gold"));
		ShowLevel(currentLevel);

	}
	
	public void ShowLevel(int levelnumber)
	{
		levelText.text = "LEVEL " + (levelnumber );
	}

	private void OnEnable()
	{
		PlayerInfo = PlayerPersistence.LoadData();

	}
	
	/*private void OnDisable()
	{
		PlayerPersistence.SaveData(this);
	}*/
	
	private void UpDate()
	{
		
	}
	
}
