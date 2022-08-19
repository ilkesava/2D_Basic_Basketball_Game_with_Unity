using UnityEngine;

public static class PlayerPersistence
{
    public static void SaveData(Player player)
	{
		PlayerPrefs.SetInt("health",player.PlayerInfo.currentHealth);
		PlayerPrefs.SetInt("gold",player.PlayerInfo.currentGold);
		PlayerPrefs.SetInt("level",player.PlayerInfo.currentLevel);
		PlayerPrefs.SetInt("ball",player.PlayerInfo.currentBallindex);
		PlayerPrefs.SetInt("background",player.PlayerInfo.currentBackgroundindex);
		PlayerPrefs.SetInt("flag", player.PlayerInfo.flag);
		
	}
	
	public static PlayerInfo LoadData()
	{
		int health = PlayerPrefs.GetInt("health");
		int gold = PlayerPrefs.GetInt("gold");
		int level = PlayerPrefs.GetInt("level");
		int ball = PlayerPrefs.GetInt("ball");
		int background = PlayerPrefs.GetInt("background");
		int flag = PlayerPrefs.GetInt("flag");

		PlayerInfo playerInfo = new PlayerInfo()
		{
			currentHealth = health,
			currentGold = gold,
			currentLevel = level,
			currentBallindex = ball,
			currentBackgroundindex = background,
			flag = flag
			
		};
		
		return playerInfo;

	}
}
