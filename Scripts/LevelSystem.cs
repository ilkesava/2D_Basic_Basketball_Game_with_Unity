using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSystem : MonoBehaviour
{
	public int index;
	//public string levelnumber;
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Untagged"))
		{
			SceneManager.LoadScene(index);
			//SceneManager.LoadScene(levelnumber);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	

}
