using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	#region Singleton class: GameManager

	public static GameManager Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	#endregion

	Camera cam;

	Player player;

	public Ball ball;
	public Trajectory trajectory;
	public int speed;
	public Obstacle[] obs;
	[SerializeField] float pushForce;
	public Vector3 BallStartingPoint;

	public Vector3[] VortexCreationPoints;
	public Vector3[] VortexEdgesLeftXandDownY;  //Vector in köseleri icin gereken pozisyon topun degebilicegi noktalar , Vector simgesinin sol X pozisyonu ve Asagi Y pozisyonu girilmeli.
	public Vector3[] VortexEdgesRightXandUpY;
	public Vector3[] VortexScales;


	public Vector3 HeartCreationPoint; 
	public Vector3 HeartEdgesLeftXandDownY;  //Heart in köseleri icin gereken pozisyon topun degebilicegi noktalar , Heart simgesinin sol X pozisyonu ve Asagi Y pozisyonu girilmeli.
	public Vector3 HeartEdgesRightXandUpY;

	public GameObject Background;
	SpriteRenderer BackgroundSpriteRenderer;

	public GameObject Bar1;
	public GameObject Bar2;
	public GameObject Bar3;
	public GameObject Bar4;
	public GameObject Bar5;
	static int BarCount;

	public Vector3 EndingPointLeftXandDownY;
	public Vector3 EndingPointRightXandUpY;

	public int BallType;
	public int WhereToGo;

	bool fly = false;
	bool isDragging = false;
	bool GetLifeCheck = false;
	bool LoselifeCheck = false;
	bool GetGoldCheck = false;
	public bool IsMoving;
	bool BarCheck = true;
	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;
	float bally;
	float ballx;

	public Sprite Type0, Type1, Type2, Type3;

	static int health;
	int Gold;
	SpriteRenderer rendererH;
	SpriteRenderer rendererA;

	public Sprite vortexx;
	public Sprite Heartt;

	//---------------------------------------
	void Start()
	{
		ball.Type = PlayerPrefs.GetInt("currentBallindex"); // Ball type control mechanism

		BackgroundSpriteRenderer = Background.GetComponent<SpriteRenderer>();
		if (PlayerPrefs.GetInt("currentBackgroundindex") == 0)
        {
			BackgroundSpriteRenderer.sprite = Type0;
        }
		else if(PlayerPrefs.GetInt("currentBackgroundindex") == 1)
        {
			BackgroundSpriteRenderer.sprite = Type1;
        }
		else if (PlayerPrefs.GetInt("currentBackgroundindex") == 2)
		{
			BackgroundSpriteRenderer.sprite = Type2;
		}
		else if (PlayerPrefs.GetInt("currentBackgroundindex") == 3)
		{
			BackgroundSpriteRenderer.sprite = Type3;
		}

		cam = Camera.main;
		ball.DesactivateRb();
		CreateVortex();
		CreateLife();
		ChangeObsBehav();

		health = PlayerPrefs.GetInt("health");
		Gold = PlayerPrefs.GetInt("gold");


	}

	void Update()
	{
		if (BarCheck == true)
		{
			switch (health)
			{
				case 5:
					Bar1.SetActive(true);
					Bar2.SetActive(true);
					Bar3.SetActive(true);
					Bar4.SetActive(true);
					Bar5.SetActive(true);
					BarCheck = false;
					break;
				case 4:
					Bar1.SetActive(true);
					Bar2.SetActive(true);
					Bar3.SetActive(true);
					Bar4.SetActive(true);
					Bar5.SetActive(false);
					BarCheck = false;
					break;
				case 3:
					Bar1.SetActive(true);
					Bar2.SetActive(true);
					Bar3.SetActive(true);
					Bar4.SetActive(false);
					Bar5.SetActive(false);
					BarCheck = false;
					break;
				case 2:
					Bar1.SetActive(true);
					Bar2.SetActive(true);
					Bar3.SetActive(false);
					Bar4.SetActive(false);
					Bar5.SetActive(false);
					BarCheck = false;
					break;
				case 1:
					Bar1.SetActive(true);
					Bar2.SetActive(false);
					Bar3.SetActive(false);
					Bar4.SetActive(false);
					Bar5.SetActive(false);
					BarCheck = false;
					break;
				case 0:
					RestartAllGame();
					break;
			}
		}

		bally = ball.pos.y;
		ballx = ball.pos.x;

		if (ballx > HeartEdgesLeftXandDownY.x && ballx < HeartEdgesRightXandUpY.x)
        {

			if(bally > HeartEdgesLeftXandDownY.y && bally < HeartEdgesRightXandUpY.y)
            {
				if(GetLifeCheck == false)
                {
					GetLifeCheck = true;
					GetLife();
                }
			}
        }

		if (bally > EndingPointLeftXandDownY.y && bally < EndingPointRightXandUpY.y)
		{


			if (ballx >= EndingPointLeftXandDownY.x && ballx <= EndingPointRightXandUpY.x)
            {

				if (GetGoldCheck == false)
                {
					GetGoldCheck = true;
					LevelUp();
				}
			}
		}
		for (int i = 0; i < VortexCreationPoints.Length; i++)
        {
			if (ballx > VortexEdgesLeftXandDownY[i].x && ballx < VortexEdgesRightXandUpY[i].x)
			{
				//if(bally > 14 && bally < 222)
				if (bally < VortexEdgesRightXandUpY[i].y && bally > VortexEdgesLeftXandDownY[i].y)
				{
					if (LoselifeCheck == false)
					{
						LoseLife();
					}
					RestartGame();
				}
			}
		}
		if (fly == false)
		{
			if (Input.GetMouseButtonDown(0))
			{
				isDragging = true;
				OnDragStart();
			}
			if (Input.GetMouseButtonUp(0))
			{
				isDragging = false;
				OnDragEnd();
			}

			if (isDragging)
			{
				OnDrag();
			}
		}
	}

	//-Drag--------------------------------------

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ball")
		{
			LoseLife();
			RestartGame();
		}
	}

	void OnDragStart()
	{
		ball.DesactivateRb();
		startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

		trajectory.Show();
	}

	void OnDrag()
	{
		endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
		distance = Vector2.Distance(startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		//just for debug
		Debug.DrawLine(startPoint, endPoint);


		trajectory.UpdateDots(ball.pos, force);
	}

	void OnDragEnd()
	{
		//push the ball
		ball.ActivateRb();

		ball.Push(force);
		fly = true;
		trajectory.Hide();
	}
	public void RestartGame()
    {
		LoselifeCheck = false;
		GetGoldCheck = false;
		isDragging = false;
		LoselifeCheck = false;
		ball.transform.position = BallStartingPoint;

		fly = false;
		ball.DesactivateRb();
	}

	public void RestartAllGame()
    {
		health = 5;
		fly = false;
		LoselifeCheck = false;
		GetGoldCheck = false;
		isDragging = false;
		LoselifeCheck = false;
		PlayerPrefs.SetInt("health", health);
		SceneManager.LoadScene(24);
	}

	void ChangeObsBehav()
	{
		for (int i = 0; i < obs.Length; i++)
		{ 
			obs[i].Move(IsMoving);
		}
    }


	void GetLife()
    {
		if (health < 5)
		{
			Debug.Log("Bar Count1 : " + BarCount);
			BarCount = BarCount + 1;
			Debug.Log("Bar Count2 : " + BarCount);
			health = health + 1;
			BarCheck = true;
			PlayerPrefs.SetInt("health", health);
		}
		Debug.Log("Helal can kazandin ");
		rendererH.sortingLayerName = "Default";
	}

	void GetGold()
    {
		Gold = Gold + 100;
		PlayerPrefs.SetInt("gold", Gold);
		Debug.Log("Helal para kazandin ");
	}

	void LevelUp()
    {
		GetGold();
		SceneManager.LoadScene(WhereToGo);
	}

	void LoseLife()
    {
		health = health - 1;
		BarCount = BarCount - 1;
		Debug.Log("health Count : " + health);
		PlayerPrefs.SetInt("health", health);
		BarCheck = true;
		Debug.Log("Helal can kaybettin ");
	}

	/*void SetDifficulty()
    {

    }*/


	void CreateVortex()
    {
		for (int i = 0; i < VortexCreationPoints.Length; i++)
		{
			GameObject vortex = new GameObject("Vortex");
			SpriteRenderer renderer = vortex.AddComponent<SpriteRenderer>();
			renderer.sprite = vortexx;
			vortex.transform.position = VortexCreationPoints[i];
			vortex.transform.localScale = VortexScales[i];
			renderer.sortingLayerName = "Ball";
		}
	}

	void CreateLife()
    {
		GameObject Heart = new GameObject("Heart");
		rendererH = Heart.AddComponent<SpriteRenderer>();
		rendererH.sprite = Heartt;
		Heart.transform.position = HeartCreationPoint;
		Heart.transform.localScale = new Vector3(20, 20, 0);
		rendererH.sortingLayerName = "Ball";
	}
}
